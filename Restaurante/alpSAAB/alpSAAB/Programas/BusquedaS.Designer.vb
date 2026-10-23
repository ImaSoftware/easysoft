<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.busqueda1 = New SAAB.busqueda(Me.idForm, Me.idCol)
        Me.SuspendLayout()
        '
        'busqueda1
        '
        Me.busqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.busqueda1.Location = New System.Drawing.Point(0, 0)
        Me.busqueda1.Name = "busqueda1"
        Me.busqueda1.Size = New System.Drawing.Size(420, 336)
        Me.busqueda1.TabIndex = 0
        '
        'BusquedaS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 336)
        Me.Controls.Add(Me.busqueda1)
        Me.Name = "BusquedaS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BusquedaS"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents busqueda1 As busqueda

End Class
