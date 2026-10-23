'use strict';
const $ = (s, root = document) => root.querySelector(s);
const $$ = (s, root = document) => [...root.querySelectorAll(s)];
let token = '', selectedId = null, currentPanel = 'config', pending = null, pollBusy = false, lineNumber = 0;
const stateNames = {Queued:'En cola',Signed:'Firmado',AwaitingAuthorization:'Consultando autorización',Authorized:'Autorizado en PRUEBAS',Rejected:'Rechazado por el SRI',LocalError:'Revisar firma o validación',NeedsAttention:'Requiere revisión'};
function focusDestination(node) {
  requestAnimationFrame(() => requestAnimationFrame(() => {
    node.focus({preventScroll:true});
    node.scrollIntoView({block:'center',behavior:matchMedia('(prefers-reduced-motion: reduce)').matches?'instant':'smooth'});
  }));
}
function navigate(target) {
  currentPanel = target;
  $$('.panel').forEach(p => p.hidden = p.id !== target);
  $$('nav button').forEach(b => { if (b.dataset.target === target) b.setAttribute('aria-current','step'); else b.removeAttribute('aria-current'); });
  $('#notice').hidden = true;
  focusDestination($('#'+target+' h2'));
}
function notify(text, error = false, focus = true) {
  $('#notice-text').textContent = text; $('#notice').hidden = false;
  $('#notice').classList.toggle('error',error);
  if (focus) focusDestination($('#notice-text'));
}
async function api(path, options = {}) {
  const response = await fetch('/api'+path,{...options,headers:{Authorization:'Bearer '+token,...(options.body?{'Content-Type':'application/json'}:{}),...options.headers}});
  if (!response.ok) {
    if (response.status === 401) throw new Error('Clave de acceso incorrecta o sesión de consola vencida.');
    const problem = await response.json().catch(()=>null);
    throw new Error(problem?.detail || 'La operación no se pudo completar. Si fue un envío, consulta Seguimiento antes de crear otra solicitud.');
  }
  return response;
}
async function config() {
  const data = await (await api('/configuracion')).json();
  if (data.emisor) for (const [name,value] of Object.entries(data.emisor)) {
    const input = $('#issuer-form').elements.namedItem(name);
    if (input) input.value = value == null ? '' : String(value);
  }
  $('#certificate-status').textContent = data.firma.loaded ? 'Firma cargada en memoria. Vigente hasta '+new Date(data.firma.expiresAt).toLocaleDateString('es-EC')+'.' : 'Firma pendiente de cargar para este emisor.';
}
$('#login-form').addEventListener('submit',async e=>{
  e.preventDefault(); token = $('#api-key').value.trim();
  try {
    await config(); $('#api-key').value=''; $('#login').hidden=true; $('#workspace').hidden=false;
    navigate('config');
  } catch(err) { $('#login-error').textContent=err.message; token=''; focusDestination($('#login-error')); }
});
$('#logout').addEventListener('click',()=>{
  token=''; selectedId=null; $('#workspace').hidden=true; $('#login').hidden=false;
  $('#login h1').tabIndex=-1; focusDestination($('#login h1'));
});
$$('nav button').forEach(b=>b.addEventListener('click',async()=>{
  navigate(b.dataset.target);
  if (currentPanel==='tracking') { try { await refresh(); } catch(err) { notify(err.message,true); } }
}));
async function submitBusy(form, action) {
  const button = $('button[type=submit]',form); button.disabled=true;
  try { await action(); } catch(err) { notify(err.message,true); } finally { button.disabled=false; }
}
$('#issuer-form').addEventListener('submit',e=>{
  e.preventDefault(); submitBusy(e.currentTarget,async()=>{
    const data=Object.fromEntries(new FormData(e.target));
    for (const [key,value] of Object.entries(data)) if (value==='') data[key]=null;
    data.primerSecuencial=Number(data.primerSecuencial); data.obligadoContabilidad=data.obligadoContabilidad==='true';
    await api('/configuracion/emisor',{method:'PUT',body:JSON.stringify(data)}); await config();
    notify('Emisor guardado. Carga su firma para emitir en pruebas.');
  });
});
$('#certificate-form').addEventListener('submit',e=>{
  e.preventDefault(); submitBusy(e.currentTarget,async()=>{
    const data=Object.fromEntries(new FormData(e.target));
    try { await api('/configuracion/firma',{method:'POST',body:JSON.stringify(data)}); await config(); notify('Firma cargada en memoria. Ya puedes preparar una factura de prueba.'); }
    finally { e.target.elements.password.value=''; data.password=''; }
  });
});
function field(label, name, attrs) {
  const container=document.createElement('label'); container.append(document.createTextNode(label));
  const input=document.createElement('input'); input.dataset.field=name;
  for(const [key,value] of Object.entries(attrs)) input.setAttribute(key,value);
  container.append(input); return container;
}
function addLine() {
  const row=document.createElement('div'); row.className='line';
  const top=document.createElement('div'); top.className='line-top';
  const title=document.createElement('span'); title.tabIndex=-1; title.textContent='Línea '+(++lineNumber); top.append(title);
  const remove=document.createElement('button'); remove.type='button'; remove.className='remove'; remove.textContent='Quitar';
  remove.addEventListener('click',()=>{
    if ($$('.line').length===1) { notify('La factura necesita al menos una línea.',true); return; }
    row.remove(); preview(); focusDestination($('#details-title'));
  }); top.append(remove); row.append(top);
  const grid=document.createElement('div'); grid.className='grid';
  grid.append(field('Código','codigo',{required:'',maxlength:'25',value:'PRUEBA-'+lineNumber}),
    field('Descripción','descripcion',{required:'',maxlength:'300',value:'Servicio de prueba'}),
    field('Cantidad','cantidad',{type:'number',min:'0.000001',max:'999999999',step:'0.000001',value:'1',required:''}),
    field('Precio unitario','precioUnitario',{type:'number',min:'0',max:'999999999',step:'0.000001',value:'1.00',required:''}),
    field('Descuento','descuento',{type:'number',min:'0',step:'0.01',value:'0',required:''}));
  const label=document.createElement('label'); label.textContent='IVA';
  const select=document.createElement('select'); select.dataset.field='codigoIva';
  for(const [value,text] of [['4','15 %'],['0','0 %']]) { const option=document.createElement('option'); option.value=value; option.textContent=text; select.append(option); }
  label.append(select); grid.append(label); row.append(grid); $('#lines').append(row); preview(); return title;
}
function lines() { return $$('.line').map(row=>{
  const result={}; $$('[data-field]',row).forEach(input=>result[input.dataset.field]=input.value);
  for(const name of ['cantidad','precioUnitario','descuento']) result[name]=Number(result[name]);
  result.tarifaIva=result.codigoIva==='4'?15:0; return result;
}); }
const round=v=>Math.round((v+Number.EPSILON)*100)/100;
function total() { return round(lines().reduce((sum,l)=>{ const net=round(l.cantidad*l.precioUnitario-l.descuento); return sum+net+round(net*l.tarifaIva/100); },0)+Number($('#invoice-form').elements.propina.value)); }
function preview(){ const amount=total(); $('#preview-total').textContent=Number.isFinite(amount)?amount.toLocaleString('es-EC',{style:'currency',currency:'USD'}):'—'; }
$('#add-line').addEventListener('click',()=>focusDestination(addLine()));
$('#invoice-form').addEventListener('input',preview); $('#invoice-form').addEventListener('change',preview);
$('#invoice-form').elements.fechaEmision.value=new Intl.DateTimeFormat('en-CA',{timeZone:'America/Guayaquil',year:'numeric',month:'2-digit',day:'2-digit'}).format(new Date());
addLine();
$('#invoice-form').addEventListener('submit',e=>{
  e.preventDefault(); submitBusy(e.currentTarget,async()=>{
    const f=Object.fromEntries(new FormData(e.target));
    const request={fechaEmision:f.fechaEmision,referencia:f.referencia,comprador:{tipoIdentificacion:f.tipoIdentificacion,identificacion:f.identificacion,razonSocial:f.razonSocial,direccion:f.direccion||null},
      detalles:lines(),pagos:[{formaPago:f.formaPago,total:total()}],propina:Number(f.propina)};
    const body=JSON.stringify(request);
    if (pending?.body!==body) pending={body,key:crypto.randomUUID()};
    const result=await (await api('/facturas',{method:'POST',body,headers:{'Idempotency-Key':pending.key}})).json();
    selectedId=result.id; navigate('tracking'); await refresh(); focusDestination($('#result h3'));
  });
});
function textElement(tag,text,className) { const el=document.createElement(tag);el.textContent=text;if(className)el.className=className;return el; }
function displayRecord(r) {
  const body=$('#result-body'); body.replaceChildren();
  body.append(textElement('span',stateNames[r.state]||r.state,'state '+r.state));
  const dl=document.createElement('dl');
  for(const [name,value] of [['Referencia',r.referencia],['Clave de acceso',r.accessKey],['Secuencial',String(r.sequence).padStart(9,'0')],['Total',Number(r.total).toLocaleString('es-EC',{style:'currency',currency:'USD'})],['Autorización',r.authorizationNumber||'Pendiente']]) dl.append(textElement('dt',name),textElement('dd',value));
  body.append(dl);
  if(r.lastError) body.append(textElement('p',r.lastError,'message'));
  for(const m of r.messages) body.append(textElement('p',[m.identificador,m.mensaje,m.informacionAdicional].filter(Boolean).join(' · '),'message'));
  const downloads=document.createElement('div');downloads.className='downloads';
  for(const [kind,label,available] of [['generado','XML generado',true],['firmado','XML firmado',r.hasSignedXml],['autorizado','XML autorizado',r.hasAuthorizedXml]]) {
    if(!available) continue;
    const button=textElement('button',label,'secondary');button.type='button';
    button.addEventListener('click',async()=>{
      try { const response=await api('/comprobantes/'+r.id+'/xml/'+kind); const blob=await response.blob(); const url=URL.createObjectURL(blob);
        const a=document.createElement('a');a.href=url;a.download=r.accessKey+'-'+kind+'.xml';a.click();setTimeout(()=>URL.revokeObjectURL(url),1000);
      }catch(err){notify(err.message,true);}
    });downloads.append(button);
  }
  body.append(downloads,textElement('h4','Historial'));
  if(r.state==='LocalError'||r.state==='NeedsAttention') {
    const resume=textElement('button',r.state==='LocalError'?'Reintentar tras corregir la firma':'Reanudar consulta de autorización','secondary');resume.type='button';
    resume.addEventListener('click',async()=>{
      resume.disabled=true;
      try {await api('/comprobantes/'+r.id+'/reactivar',{method:'POST'});await refresh();focusDestination($('#result h3'));}
      catch(err){notify(err.message,true);} finally{resume.disabled=false;}
    });body.append(resume);
  }
  const history=document.createElement('ol');history.className='timeline';
  for(const event of r.history) {const li=document.createElement('li');li.append(textElement('time',new Date(event.at).toLocaleString('es-EC')),document.createTextNode(event.detail));history.append(li);}
  body.append(history);
}
// Background refresh only changes text. It never calls navigation/focus and avoids replacing a focused control.
async function refresh(background=false) {
  if(pollBusy || !token) return; pollBusy=true;
  try {
    const records=await (await api('/comprobantes')).json();
    const list=$('#invoice-list');
    if(!background || !list.contains(document.activeElement)) {
      list.replaceChildren();
      if(!records.length) list.append(textElement('p','Todavía no hay solicitudes. Prepara tu primera factura de prueba.'));
      for(const r of records) {
        const button=document.createElement('button');button.className='request'+(selectedId===r.id?' selected':'');
        button.append(textElement('strong',r.referencia),textElement('span',stateNames[r.state]||r.state));
        button.addEventListener('click',()=>{selectedId=r.id;displayRecord(r);focusDestination($('#result h3'));});list.append(button);
      }
    }
    let selected=records.find(r=>r.id===selectedId);
    if(!selected && selectedId) selected=await (await api('/comprobantes/'+selectedId)).json();
    if(selected && (!background || !$('#result-body').contains(document.activeElement))) displayRecord(selected);
  } finally {pollBusy=false;}
}
$('#refresh').addEventListener('click',async()=>{try{await refresh();focusDestination($('#tracking h2'));}catch(err){notify(err.message,true);}});
setInterval(()=>{if(token&&currentPanel==='tracking'&&!document.hidden)refresh(true).catch(()=>{});},5000);
