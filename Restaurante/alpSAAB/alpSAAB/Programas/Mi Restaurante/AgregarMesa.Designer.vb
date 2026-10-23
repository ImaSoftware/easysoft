<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarMesa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarMesa))
        Me.gridDisponibles = New SAAB.GridTouch()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gridOcupadas = New SAAB.GridTouch()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelMesas = New System.Windows.Forms.Panel()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.cmdGrabar = New System.Windows.Forms.Button()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(789, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.CmdCancel)
        Me.Ventana.Controls.Add(Me.cmdGrabar)
        Me.Ventana.Controls.Add(Me.PanelMesas)
        Me.Ventana.Controls.Add(Me.Label2)
        Me.Ventana.Controls.Add(Me.Label3)
        Me.Ventana.Controls.Add(Me.Label1)
        Me.Ventana.Controls.Add(Me.gridOcupadas)
        Me.Ventana.Controls.Add(Me.gridDisponibles)
        Me.Ventana.MaximumSize = New System.Drawing.Size(819, 560)
        Me.Ventana.Size = New System.Drawing.Size(819, 560)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(819, 28)
        '
        'ListaPngs
        '
        Me.ListaPngs.ImageStream = CType(resources.GetObject("ListaPngs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaPngs.Images.SetKeyName(0, "save.png")
        Me.ListaPngs.Images.SetKeyName(1, "NoSign.png")
        Me.ListaPngs.Images.SetKeyName(2, "Bill.png")
        Me.ListaPngs.Images.SetKeyName(3, "Agrega.png")
        Me.ListaPngs.Images.SetKeyName(4, "ComandaICon.png")
        Me.ListaPngs.Images.SetKeyName(5, "go-next.png")
        Me.ListaPngs.Images.SetKeyName(6, "go-previous.png")
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.Location = New System.Drawing.Point(694, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(733, 0)
        '
        'gridDisponibles
        '
        Me.gridDisponibles.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDisponibles.Location = New System.Drawing.Point(14, 40)
        Me.gridDisponibles.Margin = New System.Windows.Forms.Padding(6)
        Me.gridDisponibles.Name = "gridDisponibles"
        Me.gridDisponibles.Size = New System.Drawing.Size(540, 192)
        Me.gridDisponibles.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mesas Disponibles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mesas Ocupadas"
        '
        'gridOcupadas
        '
        Me.gridOcupadas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridOcupadas.Location = New System.Drawing.Point(14, 272)
        Me.gridOcupadas.Margin = New System.Windows.Forms.Padding(6)
        Me.gridOcupadas.Name = "gridOcupadas"
        Me.gridOcupadas.Size = New System.Drawing.Size(782, 174)
        Me.gridOcupadas.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SandyBrown
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(563, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 77)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Mesas en esta cuenta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelMesas
        '
        Me.PanelMesas.AutoScroll = True
        Me.PanelMesas.BackColor = System.Drawing.Color.Cornsilk
        Me.PanelMesas.Location = New System.Drawing.Point(563, 122)
        Me.PanelMesas.Name = "PanelMesas"
        Me.PanelMesas.Size = New System.Drawing.Size(233, 110)
        Me.PanelMesas.TabIndex = 14
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.ImageIndex = 1
        Me.CmdCancel.ImageList = Me.ListaPngs
        Me.CmdCancel.Location = New System.Drawing.Point(248, 480)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(274, 67)
        Me.CmdCancel.TabIndex = 16
        Me.CmdCancel.Text = "&Salir"
        Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmdGrabar
        '
        Me.cmdGrabar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdGrabar.ImageIndex = 0
        Me.cmdGrabar.ImageList = Me.ListaPngs
        Me.cmdGrabar.Location = New System.Drawing.Point(522, 480)
        Me.cmdGrabar.Name = "cmdGrabar"
        Me.cmdGrabar.Size = New System.Drawing.Size(274, 67)
        Me.cmdGrabar.TabIndex = 15
        Me.cmdGrabar.Text = "&Grabar"
        Me.cmdGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGrabar.UseVisualStyleBackColor = False
        '
        'AgregarMesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 588)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "AgregarMesa"
        Me.Text = "AgregarMesa"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridDisponibles As SAAB.GridTouch
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridOcupadas As SAAB.GridTouch
    Friend WithEvents PanelMesas As System.Windows.Forms.Panel
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
End Class
