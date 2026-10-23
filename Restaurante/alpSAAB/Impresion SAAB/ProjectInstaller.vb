Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.ServiceProcess

Public Class ProjectInstaller

    Public Sub New()
        MyBase.New()

        'El Diseñador de componentes requiere esta llamada.
        InitializeComponent()
        'Agregue el código de inicialización después de llamar a InitializeComponent
        ' Instantiate installers for process and services.
        ServiceProcessInstaller1.Account = ServiceAccount.LocalSystem
        ServiceInstaller1.StartType = ServiceStartMode.Automatic
        ServiceInstaller1.ServiceName = "SAAB_IMP"
    End Sub

    Private Sub ServiceInstaller1_AfterInstall(sender As Object, e As InstallEventArgs) Handles ServiceInstaller1.AfterInstall

    End Sub
End Class

