<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SysParam
    Inherits DolphinCtl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SysParam))
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblimg2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SD_OrigenesMeseros = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkResMesero = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ParadiseName = New System.Windows.Forms.TextBox()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TiempoEsperaAceptable = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TiempoEsperaMaximo = New System.Windows.Forms.NumericUpDown()
        Me.MeseroDigitos = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SD_SysParam_Temas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkVerEsquema = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtpwd = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdGrabar = New System.Windows.Forms.Button()
        Me.lblimg = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtProfo = New System.Windows.Forms.TextBox()
        Me.btnBusqSP1 = New System.Windows.Forms.Button()
        Me.txtBode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTempCli = New System.Windows.Forms.TextBox()
        Me.btnBusqSP2 = New System.Windows.Forms.Button()
        Me.btnBusqSP3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkCierre = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NuMtop = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMesaLLeva = New System.Windows.Forms.TextBox()
        Me.txtMesaDomi = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.asistenteEspera = New System.Windows.Forms.NumericUpDown()
        Me.txtNombreAsistente = New System.Windows.Forms.TextBox()
        Me.recargaSector = New System.Windows.Forms.NumericUpDown()
        Me.escoge = New System.Windows.Forms.OpenFileDialog()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TiempoEsperaAceptable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TiempoEsperaMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeseroDigitos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuMtop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.asistenteEspera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.recargaSector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 1109)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.85366!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.14634!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 271.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button5, 2, 17)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 0, 17)
        Me.TableLayoutPanel2.Controls.Add(Me.lblimg2, 1, 17)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.SD_OrigenesMeseros, 1, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 0, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.chkResMesero, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.ParadiseName, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdEditar, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.TiempoEsperaAceptable, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TiempoEsperaMaximo, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.MeseroDigitos, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.SD_SysParam_Temas, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ChkVerEsquema, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAdd, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtpwd, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdGrabar, 1, 22)
        Me.TableLayoutPanel2.Controls.Add(Me.lblimg, 1, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 2, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtProfo, 1, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBusqSP1, 2, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBode, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTempCli, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBusqSP2, 2, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBusqSP3, 2, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.chkCierre, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 0, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.NuMtop, 1, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 0, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Label17, 0, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMesaLLeva, 1, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMesaDomi, 1, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 2, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Button4, 2, 14)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 0, 18)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 0, 19)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 0, 20)
        Me.TableLayoutPanel2.Controls.Add(Me.asistenteEspera, 1, 18)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNombreAsistente, 1, 19)
        Me.TableLayoutPanel2.Controls.Add(Me.recargaSector, 1, 20)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 24
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1163, 1088)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button5.Location = New System.Drawing.Point(848, 802)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 41)
        Me.Button5.TabIndex = 40
        Me.Button5.Text = "..."
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoEllipsis = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Location = New System.Drawing.Point(3, 799)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(551, 47)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Imagen del panel Superior"
        '
        'lblimg2
        '
        Me.lblimg2.AutoEllipsis = True
        Me.lblimg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblimg2.Location = New System.Drawing.Point(560, 799)
        Me.lblimg2.Name = "lblimg2"
        Me.lblimg2.Size = New System.Drawing.Size(282, 47)
        Me.lblimg2.TabIndex = 37
        Me.lblimg2.Text = "ejemplo"
        '
        'Label11
        '
        Me.Label11.AutoEllipsis = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(3, 752)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(551, 47)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Imagen de publicidad Inicio"
        '
        'SD_OrigenesMeseros
        '
        Me.SD_OrigenesMeseros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SD_OrigenesMeseros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SD_OrigenesMeseros.FormattingEnabled = True
        Me.SD_OrigenesMeseros.Location = New System.Drawing.Point(560, 708)
        Me.SD_OrigenesMeseros.Name = "SD_OrigenesMeseros"
        Me.SD_OrigenesMeseros.Size = New System.Drawing.Size(255, 28)
        Me.SD_OrigenesMeseros.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoEllipsis = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(3, 705)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(551, 47)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Origen de Empleados"
        '
        'chkResMesero
        '
        Me.chkResMesero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkResMesero.Location = New System.Drawing.Point(560, 332)
        Me.chkResMesero.Name = "chkResMesero"
        Me.chkResMesero.Size = New System.Drawing.Size(282, 41)
        Me.chkResMesero.TabIndex = 9
        Me.chkResMesero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkResMesero.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 282)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(551, 47)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Ver Esquema"
        '
        'ParadiseName
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ParadiseName, 2)
        Me.ParadiseName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParadiseName.Location = New System.Drawing.Point(560, 238)
        Me.ParadiseName.MaxLength = 50
        Me.ParadiseName.Multiline = True
        Me.ParadiseName.Name = "ParadiseName"
        Me.ParadiseName.Size = New System.Drawing.Size(328, 41)
        Me.ParadiseName.TabIndex = 3
        '
        'cmdEditar
        '
        Me.cmdEditar.BackgroundImage = Global.SAAB.My.Resources.Resources.icon_edit
        Me.cmdEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdEditar.Location = New System.Drawing.Point(848, 97)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(32, 33)
        Me.cmdEditar.TabIndex = 4
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(551, 47)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nombre para Mostrar"
        '
        'TiempoEsperaAceptable
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TiempoEsperaAceptable, 2)
        Me.TiempoEsperaAceptable.Location = New System.Drawing.Point(560, 191)
        Me.TiempoEsperaAceptable.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.TiempoEsperaAceptable.Name = "TiempoEsperaAceptable"
        Me.TiempoEsperaAceptable.Size = New System.Drawing.Size(168, 26)
        Me.TiempoEsperaAceptable.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(551, 47)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clave de Administrador"
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(551, 47)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Maximo de digitos para clave de mesero"
        '
        'TiempoEsperaMaximo
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TiempoEsperaMaximo, 2)
        Me.TiempoEsperaMaximo.Location = New System.Drawing.Point(560, 144)
        Me.TiempoEsperaMaximo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.TiempoEsperaMaximo.Name = "TiempoEsperaMaximo"
        Me.TiempoEsperaMaximo.Size = New System.Drawing.Size(168, 26)
        Me.TiempoEsperaMaximo.TabIndex = 1
        '
        'MeseroDigitos
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.MeseroDigitos, 2)
        Me.MeseroDigitos.Location = New System.Drawing.Point(560, 50)
        Me.MeseroDigitos.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.MeseroDigitos.Name = "MeseroDigitos"
        Me.MeseroDigitos.Size = New System.Drawing.Size(124, 26)
        Me.MeseroDigitos.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(551, 47)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tiempo de espera Aceptable [ minutos]"
        '
        'SD_SysParam_Temas
        '
        Me.SD_SysParam_Temas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SD_SysParam_Temas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SD_SysParam_Temas.FormattingEnabled = True
        Me.SD_SysParam_Temas.Location = New System.Drawing.Point(560, 97)
        Me.SD_SysParam_Temas.Name = "SD_SysParam_Temas"
        Me.SD_SysParam_Temas.Size = New System.Drawing.Size(255, 28)
        Me.SD_SysParam_Temas.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(551, 47)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tema"
        '
        'Label4
        '
        Me.Label4.AutoEllipsis = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(551, 47)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tiempo de espera Maximo [ minutos ]"
        '
        'ChkVerEsquema
        '
        Me.ChkVerEsquema.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChkVerEsquema.Location = New System.Drawing.Point(560, 285)
        Me.ChkVerEsquema.Name = "ChkVerEsquema"
        Me.ChkVerEsquema.Size = New System.Drawing.Size(282, 41)
        Me.ChkVerEsquema.TabIndex = 6
        Me.ChkVerEsquema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkVerEsquema.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(551, 47)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Solo el mesero que crea la cuenta puede agregar consumos en ella"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.ImageIndex = 3
        Me.btnAdd.ImageList = Me.ListaPngs
        Me.btnAdd.Location = New System.Drawing.Point(894, 97)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 33)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtpwd
        '
        Me.txtpwd.Location = New System.Drawing.Point(560, 3)
        Me.txtpwd.MaxLength = 50
        Me.txtpwd.Name = "txtpwd"
        Me.txtpwd.Size = New System.Drawing.Size(228, 26)
        Me.txtpwd.TabIndex = 12
        Me.txtpwd.UseSystemPasswordChar = True
        '
        'Button1
        '
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.BackgroundImage = Global.SAAB.My.Resources.Resources.ojo1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.ImageIndex = 7
        Me.Button1.Location = New System.Drawing.Point(848, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 41)
        Me.Button1.TabIndex = 13
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdGrabar
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.cmdGrabar, 3)
        Me.cmdGrabar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGrabar.ImageKey = "save.png"
        Me.cmdGrabar.ImageList = Me.ListaPngs
        Me.cmdGrabar.Location = New System.Drawing.Point(560, 1037)
        Me.cmdGrabar.Name = "cmdGrabar"
        Me.cmdGrabar.Size = New System.Drawing.Size(600, 41)
        Me.cmdGrabar.TabIndex = 14
        Me.cmdGrabar.Text = "Grabar"
        Me.cmdGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGrabar.UseVisualStyleBackColor = True
        '
        'lblimg
        '
        Me.lblimg.AutoEllipsis = True
        Me.lblimg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblimg.Location = New System.Drawing.Point(560, 752)
        Me.lblimg.Name = "lblimg"
        Me.lblimg.Size = New System.Drawing.Size(282, 47)
        Me.lblimg.TabIndex = 16
        Me.lblimg.Text = "ejemplo"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(848, 755)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 41)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "..."
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(204, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Tipo de transaccion de Proforma"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 423)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 20)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Bodega Proforma"
        '
        'txtProfo
        '
        Me.txtProfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProfo.Location = New System.Drawing.Point(560, 379)
        Me.txtProfo.Name = "txtProfo"
        Me.txtProfo.ReadOnly = True
        Me.txtProfo.Size = New System.Drawing.Size(282, 26)
        Me.txtProfo.TabIndex = 20
        '
        'btnBusqSP1
        '
        Me.btnBusqSP1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBusqSP1.Location = New System.Drawing.Point(848, 379)
        Me.btnBusqSP1.Name = "btnBusqSP1"
        Me.btnBusqSP1.Size = New System.Drawing.Size(40, 41)
        Me.btnBusqSP1.TabIndex = 21
        Me.btnBusqSP1.Text = "..."
        Me.btnBusqSP1.UseVisualStyleBackColor = True
        '
        'txtBode
        '
        Me.txtBode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBode.Location = New System.Drawing.Point(560, 426)
        Me.txtBode.Name = "txtBode"
        Me.txtBode.ReadOnly = True
        Me.txtBode.Size = New System.Drawing.Size(282, 26)
        Me.txtBode.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 470)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 20)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Cliente Temporal Proforma"
        '
        'txtTempCli
        '
        Me.txtTempCli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTempCli.Location = New System.Drawing.Point(560, 473)
        Me.txtTempCli.Name = "txtTempCli"
        Me.txtTempCli.ReadOnly = True
        Me.txtTempCli.Size = New System.Drawing.Size(282, 26)
        Me.txtTempCli.TabIndex = 24
        '
        'btnBusqSP2
        '
        Me.btnBusqSP2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBusqSP2.Location = New System.Drawing.Point(848, 426)
        Me.btnBusqSP2.Name = "btnBusqSP2"
        Me.btnBusqSP2.Size = New System.Drawing.Size(40, 41)
        Me.btnBusqSP2.TabIndex = 25
        Me.btnBusqSP2.Text = "..."
        Me.btnBusqSP2.UseVisualStyleBackColor = True
        '
        'btnBusqSP3
        '
        Me.btnBusqSP3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBusqSP3.Location = New System.Drawing.Point(848, 473)
        Me.btnBusqSP3.Name = "btnBusqSP3"
        Me.btnBusqSP3.Size = New System.Drawing.Size(40, 41)
        Me.btnBusqSP3.TabIndex = 26
        Me.btnBusqSP3.Text = "..."
        Me.btnBusqSP3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 517)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(285, 20)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Mensajes de confirmacion al cierre de pedido"
        '
        'chkCierre
        '
        Me.chkCierre.AutoSize = True
        Me.chkCierre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkCierre.Location = New System.Drawing.Point(560, 520)
        Me.chkCierre.Name = "chkCierre"
        Me.chkCierre.Size = New System.Drawing.Size(282, 41)
        Me.chkCierre.TabIndex = 28
        Me.chkCierre.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 564)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(242, 20)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "TOP N  los mas pedidos (0 para omitir)"
        '
        'NuMtop
        '
        Me.NuMtop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NuMtop.Location = New System.Drawing.Point(560, 567)
        Me.NuMtop.Name = "NuMtop"
        Me.NuMtop.Size = New System.Drawing.Size(282, 26)
        Me.NuMtop.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 611)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 20)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = " Mesa para LLevar"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 658)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(166, 20)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Mesa pedidos a Domicilio"
        '
        'txtMesaLLeva
        '
        Me.txtMesaLLeva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMesaLLeva.Location = New System.Drawing.Point(560, 614)
        Me.txtMesaLLeva.Name = "txtMesaLLeva"
        Me.txtMesaLLeva.ReadOnly = True
        Me.txtMesaLLeva.Size = New System.Drawing.Size(282, 26)
        Me.txtMesaLLeva.TabIndex = 33
        '
        'txtMesaDomi
        '
        Me.txtMesaDomi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMesaDomi.Location = New System.Drawing.Point(560, 661)
        Me.txtMesaDomi.Name = "txtMesaDomi"
        Me.txtMesaDomi.ReadOnly = True
        Me.txtMesaDomi.Size = New System.Drawing.Size(282, 26)
        Me.txtMesaDomi.TabIndex = 34
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Location = New System.Drawing.Point(848, 614)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 41)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.Location = New System.Drawing.Point(848, 661)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 41)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 846)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(180, 20)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Tiempo de Espera Asistente"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 893)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 20)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "nombreAsistente"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 940)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(191, 20)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Tiempo de Recarga de Sector"
        '
        'asistenteEspera
        '
        Me.asistenteEspera.Location = New System.Drawing.Point(560, 849)
        Me.asistenteEspera.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.asistenteEspera.Name = "asistenteEspera"
        Me.asistenteEspera.Size = New System.Drawing.Size(178, 26)
        Me.asistenteEspera.TabIndex = 46
        '
        'txtNombreAsistente
        '
        Me.txtNombreAsistente.Location = New System.Drawing.Point(560, 896)
        Me.txtNombreAsistente.Name = "txtNombreAsistente"
        Me.txtNombreAsistente.Size = New System.Drawing.Size(282, 26)
        Me.txtNombreAsistente.TabIndex = 47
        '
        'recargaSector
        '
        Me.recargaSector.Location = New System.Drawing.Point(560, 943)
        Me.recargaSector.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.recargaSector.Name = "recargaSector"
        Me.recargaSector.Size = New System.Drawing.Size(178, 26)
        Me.recargaSector.TabIndex = 48
        '
        'escoge
        '
        Me.escoge.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Fi" &
    "les (*.gif)|*.gif"
        '
        'SysParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "SysParam"
        Me.Size = New System.Drawing.Size(1206, 1155)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TiempoEsperaAceptable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TiempoEsperaMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeseroDigitos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuMtop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.asistenteEspera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.recargaSector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SD_OrigenesMeseros As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkResMesero As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ParadiseName As System.Windows.Forms.TextBox
    Friend WithEvents cmdEditar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TiempoEsperaAceptable As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TiempoEsperaMaximo As System.Windows.Forms.NumericUpDown
    Friend WithEvents MeseroDigitos As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SD_SysParam_Temas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkVerEsquema As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtpwd As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblimg As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents escoge As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label6 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtProfo As TextBox
    Friend WithEvents btnBusqSP1 As Button
    Friend WithEvents txtBode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTempCli As TextBox
    Friend WithEvents btnBusqSP2 As Button
    Friend WithEvents btnBusqSP3 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents chkCierre As CheckBox
    Friend WithEvents Label15 As Label
    Friend WithEvents NuMtop As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMesaLLeva As TextBox
    Friend WithEvents txtMesaDomi As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents lblimg2 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents asistenteEspera As NumericUpDown
    Friend WithEvents txtNombreAsistente As TextBox
    Friend WithEvents recargaSector As NumericUpDown
End Class
