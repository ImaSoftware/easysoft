using System.Net;
using System.Text;
using Facturacion.Core;
using Facturacion.Infrastructure;
using Xunit;

namespace Facturacion.Tests;

public sealed class StoreAndWorkflowTests : IDisposable
{
    private readonly string directory = Path.Combine(Path.GetTempPath(), "easysoft-sri-tests-"+Guid.NewGuid().ToString("N"));
    private SqliteInvoiceStore Store() => new(Path.Combine(directory, "tests.db"), Fixtures.Schema());
    public void Dispose() { if (Directory.Exists(directory)) Directory.Delete(directory, true); }
    [Fact]
    public async Task ConcurrentCreationAllocatesUniqueSequencesAndDeduplicatesRequests()
    {
        var store = Store();
        var repeated = await Task.WhenAll(Enumerable.Range(0,8).Select(_ => Task.Run(() => store.Create(Fixtures.Issuer,Fixtures.Invoice(),"same"))));
        Assert.Single(repeated.Select(r=>r.Id).Distinct());
        var distinct = await Task.WhenAll(Enumerable.Range(0,12).Select(i => Task.Run(() => store.Create(Fixtures.Issuer,Fixtures.Invoice("REF-"+i),"key-"+i))));
        Assert.Equal(12,distinct.Select(r=>r.Sequence).Distinct().Count()); Assert.Equal(13,distinct.Max(r=>r.Sequence));
        var restarted=Store(); Assert.Equal(repeated[0].Id,restarted.Create(Fixtures.Issuer,Fixtures.Invoice(),"same").Id);
        Assert.Throws<IdempotencyConflictException>(() => store.Create(Fixtures.Issuer,Fixtures.Invoice("OTHER"),"same"));
        Assert.Throws<IdempotencyConflictException>(() => store.Create(Fixtures.Issuer,Fixtures.Invoice(),"another-key"));
    }
    [Fact]
    public void SchemaFailureRollsBackSequence()
    {
        var store=Store();
        Assert.Throws<InvoiceValidationException>(() => store.Create(Fixtures.Issuer with {AgenteRetencion="incorrecto"},Fixtures.Invoice(),"invalid"));
        Assert.Equal(1,store.Create(Fixtures.Issuer,Fixtures.Invoice(),"valid").Sequence);
    }
    [Fact]
    public async Task FullSimulatedWorkflowAuthorizesAndPreservesEvidenceAcrossRestart()
    {
        var store=Store(); using var cert=Fixtures.Certificate();
        var sri=new StubSri(); var processor=new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri);
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        await processor.ProcessAsync(r.Id,CancellationToken.None);
        var final=Store().Get(r.Id)!;
        Assert.Equal(InvoiceState.Authorized,final.State); Assert.Equal(final.AccessKey,final.AuthorizationNumber);
        Assert.NotNull(final.AuthorizedXml); Assert.Equal(2,final.Exchanges.Count); Assert.Equal(1,sri.Sends);
        await processor.ProcessAsync(r.Id,CancellationToken.None); Assert.Equal(1,sri.Sends);
        Assert.True(XadesSigner.Verify(final.SignedXml!,cert));
    }
    [Fact]
    public async Task LostReceptionResponseNeverResubmitsAfterRestart()
    {
        var store=Store(); using var cert=Fixtures.Certificate();
        var sri=new StubSri {LoseResponse=true};
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        await new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri).ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.AwaitingAuthorization,store.Get(r.Id)!.State);
        sri.LoseResponse=false;
        await new InvoiceProcessor(Store(),new ThrowingSigner(),Fixtures.Schema(),sri).ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.Authorized,store.Get(r.Id)!.State); Assert.Equal(1,sri.Sends);
    }
    [Fact]
    public async Task PendingAndRejectedStatesRemainDistinctAndError70OnlyPolls()
    {
        using var cert=Fixtures.Certificate(); var store=Store();
        var sri=new StubSri {Pending=true, ReceptionCode="70"};
        var processor=new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri);
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        await processor.ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.AwaitingAuthorization,store.Get(r.Id)!.State);
        await processor.ProcessAsync(r.Id,CancellationToken.None); Assert.Equal(1,sri.Sends);
        sri.Pending=false;sri.Reject=true;
        await processor.ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.Rejected,store.Get(r.Id)!.State);
    }
    [Fact]
    public async Task ReturnedInvoiceFromAnotherRequestCannotBeMarkedAuthorized()
    {
        using var cert=Fixtures.Certificate(); var store=Store();
        var sri=new StubSri {ModifyReturnedInvoice=true};
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        await new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri).ProcessAsync(r.Id,CancellationToken.None);
        var result=store.Get(r.Id)!; Assert.NotEqual(InvoiceState.Authorized,result.State); Assert.Null(result.AuthorizedXml);
    }
    [Fact]
    public async Task ManualResumeKeepsIdentityAndNeverResendsUncertainReception()
    {
        using var cert=Fixtures.Certificate(); var store=Store(); var sri=new StubSri {Pending=true};
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        var processor=new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri);
        await processor.ProcessAsync(r.Id,CancellationToken.None);
        var stalled=store.Get(r.Id)!; stalled.Attempts=29; store.Save(stalled);
        await processor.ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.NeedsAttention,store.Get(r.Id)!.State);
        var resumed=await processor.ResumeAsync(r.Id,CancellationToken.None);
        Assert.Equal(r.AccessKey,resumed.AccessKey);Assert.Equal(r.Sequence,resumed.Sequence);
        sri.Pending=false;await processor.ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.Authorized,store.Get(r.Id)!.State);Assert.Equal(1,sri.Sends);
        await Assert.ThrowsAsync<InvoiceValidationException>(()=>processor.ResumeAsync(r.Id,CancellationToken.None));
    }
    [Fact]
    public async Task LocalSignatureFailureCanBeReactivatedWithoutAllocatingAnotherSequence()
    {
        using var cert=Fixtures.Certificate(); var store=Store(); var sri=new StubSri();
        var r=store.Create(Fixtures.Issuer,Fixtures.Invoice(),"key");
        await new InvoiceProcessor(store,new InvalidSigner(),Fixtures.Schema(),sri).ProcessAsync(r.Id,CancellationToken.None);
        Assert.Equal(InvoiceState.LocalError,store.Get(r.Id)!.State);Assert.Equal(0,sri.Sends);
        var processor=new InvoiceProcessor(store,new XadesSigner(cert),Fixtures.Schema(),sri);
        await processor.ResumeAsync(r.Id,CancellationToken.None);await processor.ProcessAsync(r.Id,CancellationToken.None);
        var result=store.Get(r.Id)!;Assert.Equal(InvoiceState.Authorized,result.State);Assert.Equal(r.AccessKey,result.AccessKey);
        Assert.Equal(1,result.Sequence);Assert.Single(store.Recent());
    }
    [Fact]
    public void ParserRejectsSoapFaultsOtherKeysMalformedXmlAndProduction()
    {
        Assert.Throws<SriProtocolException>(() => SriClient.ParseReception(Fixtures.Soap("<s:Fault xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><faultstring>synthetic</faultstring></s:Fault>")));
        Assert.Throws<SriProtocolException>(() => SriClient.ParseReception("not xml"));
        string key=InvoiceBuilder.AccessKey(Fixtures.Issuer,Fixtures.Invoice().FechaEmision,1,"12345678");
        Assert.Throws<SriProtocolException>(()=>SriClient.ParseAuthorization(Fixtures.Authorization(key),"other"));
        Assert.Throws<SriProtocolException>(()=>SriClient.ParseAuthorization(Fixtures.Authorization(key,Fixtures.Xml()).Replace("PRUEBAS","PRODUCCION"),key));
    }
    [Fact]
    public async Task SoapClientUsesOnlyTestEndpointsAndBase64OfExactSignedBytes()
    {
        using var cert=Fixtures.Certificate(); string xml=new XadesSigner(cert).Sign(Fixtures.Xml());
        var handler=new InspectHandler(xml); using var http=new HttpClient(handler);
        var client=new SriClient(http); await client.ReceiveAsync(xml,CancellationToken.None);
        Assert.Equal(1,handler.Calls);
        await Assert.ThrowsAsync<InvoiceValidationException>(()=>client.ReceiveAsync(xml.Replace("<ambiente>1","<ambiente>2"),CancellationToken.None));
        Assert.Equal(1,handler.Calls);
    }
    private sealed class InspectHandler(string xml) : HttpMessageHandler
    {
        public int Calls;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct)
        {
            Calls++; Assert.Equal(SriClient.ReceptionUrl,request.RequestUri!.AbsoluteUri);
            var body=XmlSafety.Load(await request.Content!.ReadAsStringAsync(ct));
            var encoded=body.GetElementsByTagName("xml")[0]!.InnerText;
            Assert.Equal(Encoding.UTF8.GetBytes(xml),Convert.FromBase64String(encoded));
            return new(HttpStatusCode.OK){Content=new StringContent(Fixtures.Reception())};
        }
    }
    private sealed class ThrowingSigner : IInvoiceSigner { public string Sign(string xml)=>throw new InvalidOperationException("Must not sign twice"); }
    private sealed class InvalidSigner : IInvoiceSigner { public string Sign(string xml)=>throw new InvoiceValidationException("Certificado sintético inválido"); }
    private sealed class StubSri : ISriClient
    {
        public bool LoseResponse,Pending,Reject,ModifyReturnedInvoice;
        public string ReceptionCode=""; public int Sends; private string signed="";
        public Task<ReceptionResult> ReceiveAsync(string xml,CancellationToken ct)
        {
            Sends++;signed=xml; if(LoseResponse)throw new HttpRequestException("Simulated network loss AFTER acceptance");
            return Task.FromResult(SriClient.ParseReception(Fixtures.Reception(ReceptionCode.Length>0?"DEVUELTA":"RECIBIDA",ReceptionCode)));
        }
        public Task<AuthorizationResult> AuthorizeAsync(string key,CancellationToken ct)=>Task.FromResult(SriClient.ParseAuthorization(
            Fixtures.Authorization(key,Pending?null:ModifyReturnedInvoice?signed.Replace("Servicio sintético","Otra factura"):signed,Reject?"NO AUTORIZADO":"AUTORIZADO"),key));
    }
}
