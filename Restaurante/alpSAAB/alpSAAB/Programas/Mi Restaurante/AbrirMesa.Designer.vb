<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbrirMesa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AbrirMesa))
        Me.NumericaPad1 = New SAAB.NumericaPad()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdAbrir = New System.Windows.Forms.Button()
        Me.PanelIDentificado = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.imagenEpl = New System.Windows.Forms.PictureBox()
        Me.PanelCuenta = New System.Windows.Forms.Panel()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.lblMesas = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.tmrIden = New System.Windows.Forms.Timer(Me.components)
        Me.lblMesaD = New System.Windows.Forms.Label()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelIDentificado.SuspendLayout()
        CType(Me.imagenEpl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCuenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(546, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.PanelCuenta)
        Me.Ventana.Controls.Add(Me.PanelIDentificado)
        Me.Ventana.Controls.Add(Me.Panel3)
        Me.Ventana.Controls.Add(Me.lblMesaD)
        Me.Ventana.Controls.Add(Me.Label1)
        Me.Ventana.Controls.Add(Me.txtClave)
        Me.Ventana.Controls.Add(Me.NumericaPad1)
        Me.Ventana.Size = New System.Drawing.Size(576, 594)
        Me.Ventana.Controls.SetChildIndex(Me.NumericaPad1, 0)
        Me.Ventana.Controls.SetChildIndex(Me.txtClave, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Label1, 0)
        Me.Ventana.Controls.SetChildIndex(Me.lblMesaD, 0)
        Me.Ventana.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Ventana.Controls.SetChildIndex(Me.PanelIDentificado, 0)
        Me.Ventana.Controls.SetChildIndex(Me.PanelCuenta, 0)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(576, 28)
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
        Me.MINIMIZE.Location = New System.Drawing.Point(448, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(490, 0)
        '
        'NumericaPad1
        '
        Me.NumericaPad1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericaPad1.Location = New System.Drawing.Point(11, 40)
        Me.NumericaPad1.Name = "NumericaPad1"
        Me.NumericaPad1.Size = New System.Drawing.Size(275, 276)
        Me.NumericaPad1.TabIndex = 0
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(311, 75)
        Me.txtClave.MaxLength = 4
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.ReadOnly = True
        Me.txtClave.Size = New System.Drawing.Size(242, 30)
        Me.txtClave.TabIndex = 2
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Consolas", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 36)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mesero"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Location = New System.Drawing.Point(17, 497)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(536, 78)
        Me.Panel3.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdAbrir, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(536, 78)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cmdAbrir
        '
        Me.cmdAbrir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAbrir.Location = New System.Drawing.Point(3, 3)
        Me.cmdAbrir.Name = "cmdAbrir"
        Me.cmdAbrir.Size = New System.Drawing.Size(530, 72)
        Me.cmdAbrir.TabIndex = 10
        Me.cmdAbrir.Text = "&Acceder"
        Me.cmdAbrir.UseVisualStyleBackColor = True
        '
        'PanelIDentificado
        '
        Me.PanelIDentificado.Controls.Add(Me.Label4)
        Me.PanelIDentificado.Controls.Add(Me.Label2)
        Me.PanelIDentificado.Controls.Add(Me.txtCod)
        Me.PanelIDentificado.Controls.Add(Me.txtNombres)
        Me.PanelIDentificado.Controls.Add(Me.imagenEpl)
        Me.PanelIDentificado.Location = New System.Drawing.Point(311, 111)
        Me.PanelIDentificado.Name = "PanelIDentificado"
        Me.PanelIDentificado.Size = New System.Drawing.Size(242, 205)
        Me.PanelIDentificado.TabIndex = 6
        Me.PanelIDentificado.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Consolas", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 36)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cod"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Consolas", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 36)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Nombres"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCod
        '
        Me.txtCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCod.Location = New System.Drawing.Point(12, 55)
        Me.txtCod.MaxLength = 4
        Me.txtCod.Name = "txtCod"
        Me.txtCod.ReadOnly = True
        Me.txtCod.Size = New System.Drawing.Size(136, 21)
        Me.txtCod.TabIndex = 6
        '
        'txtNombres
        '
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.Location = New System.Drawing.Point(12, 127)
        Me.txtNombres.MaxLength = 4
        Me.txtNombres.Multiline = True
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(216, 75)
        Me.txtNombres.TabIndex = 6
        '
        'imagenEpl
        '
        Me.imagenEpl.Image = Global.SAAB.My.Resources.Resources.User
        Me.imagenEpl.Location = New System.Drawing.Point(154, 22)
        Me.imagenEpl.Name = "imagenEpl"
        Me.imagenEpl.Size = New System.Drawing.Size(79, 74)
        Me.imagenEpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imagenEpl.TabIndex = 4
        Me.imagenEpl.TabStop = False
        '
        'PanelCuenta
        '
        Me.PanelCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelCuenta.Controls.Add(Me.lblNoCuenta)
        Me.PanelCuenta.Controls.Add(Me.lblMesas)
        Me.PanelCuenta.Controls.Add(Me.Label3)
        Me.PanelCuenta.Controls.Add(Me.lblTotal)
        Me.PanelCuenta.Location = New System.Drawing.Point(17, 323)
        Me.PanelCuenta.Name = "PanelCuenta"
        Me.PanelCuenta.Size = New System.Drawing.Size(533, 156)
        Me.PanelCuenta.TabIndex = 7
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.Color.White
        Me.lblNoCuenta.Location = New System.Drawing.Point(15, 6)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(504, 44)
        Me.lblNoCuenta.TabIndex = 10
        Me.lblNoCuenta.Text = "15"
        Me.lblNoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMesas
        '
        Me.lblMesas.AutoEllipsis = True
        Me.lblMesas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesas.Location = New System.Drawing.Point(16, 56)
        Me.lblMesas.Name = "lblMesas"
        Me.lblMesas.Size = New System.Drawing.Size(504, 58)
        Me.lblMesas.TabIndex = 0
        Me.lblMesas.Text = "Mesas :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total Cuenta : "
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(366, 110)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(160, 42)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "0,00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmrIden
        '
        Me.tmrIden.Interval = 1000
        '
        'lblMesaD
        '
        Me.lblMesaD.Font = New System.Drawing.Font("Consolas", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesaD.Location = New System.Drawing.Point(11, 2)
        Me.lblMesaD.Name = "lblMesaD"
        Me.lblMesaD.Size = New System.Drawing.Size(542, 36)
        Me.lblMesaD.TabIndex = 3
        Me.lblMesaD.Text = "Mesa 1:"
        Me.lblMesaD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AbrirMesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 622)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "AbrirMesa"
        Me.Text = "AbrirMesa"
        Me.TopMost = True
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelIDentificado.ResumeLayout(False)
        Me.PanelIDentificado.PerformLayout()
        CType(Me.imagenEpl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCuenta.ResumeLayout(False)
        Me.PanelCuenta.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NumericaPad1 As SAAB.NumericaPad
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelIDentificado As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents imagenEpl As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdAbrir As System.Windows.Forms.Button
    Friend WithEvents PanelCuenta As System.Windows.Forms.Panel
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblMesas As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNoCuenta As System.Windows.Forms.Label
    Friend WithEvents tmrIden As System.Windows.Forms.Timer
    Friend WithEvents lblMesaD As Label
End Class
