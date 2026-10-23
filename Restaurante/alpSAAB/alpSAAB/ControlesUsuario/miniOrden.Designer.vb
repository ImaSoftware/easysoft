<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class miniOrden
    Inherits System.Windows.Forms.UserControl

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
        Me.lblOrden = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblOrden
        '
        Me.lblOrden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrden.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.lblOrden.FlatAppearance.BorderSize = 0
        Me.lblOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(0, 0)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(130, 115)
        Me.lblOrden.TabIndex = 0
        Me.lblOrden.Text = "# 15"
        Me.lblOrden.UseVisualStyleBackColor = True
        '
        'miniOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblOrden)
        Me.Name = "miniOrden"
        Me.Size = New System.Drawing.Size(130, 115)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblOrden As Button
End Class
