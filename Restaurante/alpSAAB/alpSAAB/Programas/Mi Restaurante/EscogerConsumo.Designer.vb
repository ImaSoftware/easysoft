<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EscogerConsumo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EscogerConsumo))
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.layoutBotones = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAceptar2 = New System.Windows.Forms.Button()
        Me.ListaImagenes1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdReiniciar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Ttip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NumericaPad1 = New SAAB.NumericaPad()
        Me.PanelSelProd = New System.Windows.Forms.Panel()
        Me.txtComent = New System.Windows.Forms.TextBox()
        Me.ImgItmEscogido = New System.Windows.Forms.PictureBox()
        Me.txtCant = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreProd = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.panelNiveles = New System.Windows.Forms.Panel()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.PanelBotones.SuspendLayout()
        Me.layoutBotones.SuspendLayout()
        Me.PanelSelProd.SuspendLayout()
        CType(Me.ImgItmEscogido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        '
        'Ventana
        '
        Me.Ventana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ventana.Controls.Add(Me.panelNiveles)
        Me.Ventana.Controls.Add(Me.PanelSelProd)
        Me.Ventana.Controls.Add(Me.PanelBotones)
        Me.Ventana.Size = New System.Drawing.Size(1251, 589)
        Me.Ventana.Controls.SetChildIndex(Me.PanelBotones, 0)
        Me.Ventana.Controls.SetChildIndex(Me.PanelSelProd, 0)
        Me.Ventana.Controls.SetChildIndex(Me.panelNiveles, 0)
        '
        'ListaPngs
        '
        Me.ListaPngs.ImageStream = CType(resources.GetObject("ListaPngs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaPngs.Images.SetKeyName(0, "save.png")
        Me.ListaPngs.Images.SetKeyName(1, "NoSign.png")
        Me.ListaPngs.Images.SetKeyName(2, "Bill.png")
        Me.ListaPngs.Images.SetKeyName(3, "Agrega.png")
        Me.ListaPngs.Images.SetKeyName(4, "ComandaICon.png")
        Me.ListaPngs.Images.SetKeyName(5, "go-previous.png")
        Me.ListaPngs.Images.SetKeyName(6, "go-next.png")
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        '
        'PanelBotones
        '
        Me.PanelBotones.Controls.Add(Me.layoutBotones)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBotones.Location = New System.Drawing.Point(0, 510)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(1247, 75)
        Me.PanelBotones.TabIndex = 0
        '
        'layoutBotones
        '
        Me.layoutBotones.ColumnCount = 4
        Me.layoutBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.layoutBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.layoutBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.layoutBotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.layoutBotones.Controls.Add(Me.btnAceptar2, 0, 0)
        Me.layoutBotones.Controls.Add(Me.cmdReiniciar, 0, 0)
        Me.layoutBotones.Controls.Add(Me.btnAceptar, 2, 0)
        Me.layoutBotones.Controls.Add(Me.btnCancelar, 3, 0)
        Me.layoutBotones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutBotones.Location = New System.Drawing.Point(0, 0)
        Me.layoutBotones.Name = "layoutBotones"
        Me.layoutBotones.RowCount = 1
        Me.layoutBotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutBotones.Size = New System.Drawing.Size(1247, 75)
        Me.layoutBotones.TabIndex = 0
        '
        'btnAceptar2
        '
        Me.btnAceptar2.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
        Me.btnAceptar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAceptar2.ImageKey = "ok.png"
        Me.btnAceptar2.ImageList = Me.ListaImagenes1
        Me.btnAceptar2.Location = New System.Drawing.Point(377, 3)
        Me.btnAceptar2.Name = "btnAceptar2"
        Me.btnAceptar2.Size = New System.Drawing.Size(243, 69)
        Me.btnAceptar2.TabIndex = 3
        Me.btnAceptar2.Text = "&Aceptar"
        Me.btnAceptar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar2.UseVisualStyleBackColor = True
        '
        'ListaImagenes1
        '
        Me.ListaImagenes1.ImageStream = CType(resources.GetObject("ListaImagenes1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenes1.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenes1.Images.SetKeyName(0, "restart.png")
        Me.ListaImagenes1.Images.SetKeyName(1, "ok.png")
        Me.ListaImagenes1.Images.SetKeyName(2, "cancelado.png")
        Me.ListaImagenes1.Images.SetKeyName(3, "exit.png")
        '
        'cmdReiniciar
        '
        Me.cmdReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
        Me.cmdReiniciar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdReiniciar.ImageIndex = 0
        Me.cmdReiniciar.ImageList = Me.ListaImagenes1
        Me.cmdReiniciar.Location = New System.Drawing.Point(3, 3)
        Me.cmdReiniciar.Name = "cmdReiniciar"
        Me.cmdReiniciar.Size = New System.Drawing.Size(368, 69)
        Me.cmdReiniciar.TabIndex = 0
        Me.cmdReiniciar.Text = "&Reiniciar"
        Me.cmdReiniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdReiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdReiniciar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
        Me.btnAceptar.BackColor = System.Drawing.Color.Gray
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.ImageKey = "exit.png"
        Me.btnAceptar.ImageList = Me.ListaImagenes1
        Me.btnAceptar.Location = New System.Drawing.Point(626, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(243, 69)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = " Salir"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ListaImagenes1
        Me.btnCancelar.Location = New System.Drawing.Point(875, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(369, 69)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'NumericaPad1
        '
        Me.NumericaPad1.Location = New System.Drawing.Point(85, 22)
        Me.NumericaPad1.Name = "NumericaPad1"
        Me.NumericaPad1.Size = New System.Drawing.Size(275, 273)
        Me.NumericaPad1.TabIndex = 0
        Me.Ttip1.SetToolTip(Me.NumericaPad1, "Ingrese la cantidad")
        '
        'PanelSelProd
        '
        Me.PanelSelProd.Controls.Add(Me.txtComent)
        Me.PanelSelProd.Controls.Add(Me.ImgItmEscogido)
        Me.PanelSelProd.Controls.Add(Me.txtCant)
        Me.PanelSelProd.Controls.Add(Me.Label2)
        Me.PanelSelProd.Controls.Add(Me.Label1)
        Me.PanelSelProd.Controls.Add(Me.lblNombreProd)
        Me.PanelSelProd.Controls.Add(Me.lblTotal)
        Me.PanelSelProd.Controls.Add(Me.NumericaPad1)
        Me.PanelSelProd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelSelProd.Location = New System.Drawing.Point(0, 185)
        Me.PanelSelProd.Name = "PanelSelProd"
        Me.PanelSelProd.Size = New System.Drawing.Size(1247, 325)
        Me.PanelSelProd.TabIndex = 1
        '
        'txtComent
        '
        Me.txtComent.AccessibleName = "TxtCom"
        Me.txtComent.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
        Me.txtComent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComent.Location = New System.Drawing.Point(730, 96)
        Me.txtComent.Multiline = True
        Me.txtComent.Name = "txtComent"
        Me.txtComent.Size = New System.Drawing.Size(300, 78)
        Me.txtComent.TabIndex = 14
        '
        'ImgItmEscogido
        '
        Me.ImgItmEscogido.Location = New System.Drawing.Point(404, 64)
        Me.ImgItmEscogido.Name = "ImgItmEscogido"
        Me.ImgItmEscogido.Size = New System.Drawing.Size(290, 222)
        Me.ImgItmEscogido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgItmEscogido.TabIndex = 13
        Me.ImgItmEscogido.TabStop = False
        '
        'txtCant
        '
        Me.txtCant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant.Location = New System.Drawing.Point(869, 184)
        Me.txtCant.MaxLength = 3
        Me.txtCant.Name = "txtCant"
        Me.txtCant.ReadOnly = True
        Me.txtCant.Size = New System.Drawing.Size(161, 30)
        Me.txtCant.TabIndex = 12
        Me.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(730, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 27)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Comentario"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(730, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 27)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cantidad"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNombreProd
        '
        Me.lblNombreProd.AutoEllipsis = True
        Me.lblNombreProd.AutoSize = True
        Me.lblNombreProd.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNombreProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProd.ForeColor = System.Drawing.Color.Black
        Me.lblNombreProd.Location = New System.Drawing.Point(404, 13)
        Me.lblNombreProd.Name = "lblNombreProd"
        Me.lblNombreProd.Size = New System.Drawing.Size(290, 35)
        Me.lblNombreProd.TabIndex = 11
        Me.lblNombreProd.Text = "Nombre De Producto"
        Me.lblNombreProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Black
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(730, 223)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(300, 72)
        Me.lblTotal.TabIndex = 11
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelNiveles
        '
        Me.panelNiveles.AutoSize = True
        Me.panelNiveles.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelNiveles.Location = New System.Drawing.Point(0, 0)
        Me.panelNiveles.Name = "panelNiveles"
        Me.panelNiveles.Size = New System.Drawing.Size(1247, 0)
        Me.panelNiveles.TabIndex = 2
        '
        'EscogerConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1251, 617)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "EscogerConsumo"
        Me.Text = "EscogerConsumo"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.PanelBotones.ResumeLayout(False)
        Me.layoutBotones.ResumeLayout(False)
        Me.PanelSelProd.ResumeLayout(False)
        Me.PanelSelProd.PerformLayout()
        CType(Me.ImgItmEscogido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBotones As System.Windows.Forms.Panel
    Friend WithEvents layoutBotones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelSelProd As System.Windows.Forms.Panel
    Friend WithEvents NumericaPad1 As SAAB.NumericaPad
    Friend WithEvents cmdReiniciar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Ttip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ListaImagenes1 As System.Windows.Forms.ImageList
    Friend WithEvents lblNombreProd As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtCant As System.Windows.Forms.TextBox
    Friend WithEvents ImgItmEscogido As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents panelNiveles As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar2 As System.Windows.Forms.Button
End Class
