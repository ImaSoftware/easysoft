<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputClave
    Inherits DolphinForm

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NumericaPad1 = New NumericaPad()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.LabelBuffer1 = New labelBuffer()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(297, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.LabelBuffer1)
        Me.Ventana.Controls.Add(Me.txtClave)
        Me.Ventana.Controls.Add(Me.Label1)
        Me.Ventana.Controls.Add(Me.NumericaPad1)
        Me.Ventana.Size = New System.Drawing.Size(327, 444)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(327, 28)
        '
        'NumericaPad1
        '
        Me.NumericaPad1.Location = New System.Drawing.Point(24, 90)
        Me.NumericaPad1.Name = "NumericaPad1"
        Me.NumericaPad1.Size = New System.Drawing.Size(275, 273)
        Me.NumericaPad1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.Font = New System.Drawing.Font("Harrington", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 85)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Este proceso requiere permisos elevados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(39, 383)
        Me.txtClave.MaxLength = 4
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.ReadOnly = True
        Me.txtClave.Size = New System.Drawing.Size(242, 30)
        Me.txtClave.TabIndex = 3
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelBuffer1
        '
        Me.LabelBuffer1.AutoSize = True
        Me.LabelBuffer1.BackColor = System.Drawing.Color.Transparent
        Me.LabelBuffer1.Location = New System.Drawing.Point(40, 357)
        Me.LabelBuffer1.Name = "LabelBuffer1"
        Me.LabelBuffer1.Size = New System.Drawing.Size(67, 13)
        Me.LabelBuffer1.TabIndex = 4
        Me.LabelBuffer1.Text = "LabelBuffer1"
        Me.LabelBuffer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InputClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 472)
        Me.Name = "InputClave"
        Me.Text = "InputClave"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents NumericaPad1 As SAAB.NumericaPad
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClave As New System.Windows.Forms.TextBox
    Friend WithEvents LabelBuffer1 As SAAB.labelBuffer
End Class
