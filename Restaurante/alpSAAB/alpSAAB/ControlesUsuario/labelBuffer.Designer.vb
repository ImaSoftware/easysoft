<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class labelBuffer
    Inherits System.Windows.Forms.Label
    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Name = "labelBuffer"
        Me.Size = New System.Drawing.Size(166, 47)
        Me.ResumeLayout(False)

    End Sub

End Class
