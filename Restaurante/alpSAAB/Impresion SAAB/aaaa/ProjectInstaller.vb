Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.ServiceProcess

Public Class ProjectInstaller


    Public Sub New()
        ' Instantiate installers for process and services.
        ServiceProcessInstaller1 = New ServiceProcessInstaller()
        ServiceInstaller1 = New ServiceInstaller()
        ' The services will run under the system account.
        ServiceProcessInstaller1.Account = ServiceAccount.LocalSystem
        ' The services will be started manually.
        ServiceInstaller1.StartType = ServiceStartMode.Automatic
        ' ServiceName must equal those on ServiceBase derived classes.
        ServiceInstaller1.ServiceName = "Service1"
        ' Add installers to collection. Order is not important.
        Installers.Add(ServiceInstaller1)
        Installers.Add(ServiceProcessInstaller1)
    End Sub

End Class
