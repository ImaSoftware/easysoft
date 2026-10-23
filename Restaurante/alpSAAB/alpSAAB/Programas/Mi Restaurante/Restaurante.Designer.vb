<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restaurante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restaurante))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Todo = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PanLeyenda = New System.Windows.Forms.TabPage()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.design = New System.Windows.Forms.Button()
        Me.panelestAct = New System.Windows.Forms.Panel()
        Me.lblmesero = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMesasIncl = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Sector = New SAAB.Area()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdAbrir = New System.Windows.Forms.Button()
        Me.lblMesas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCuentas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPersonasSector = New System.Windows.Forms.Label()
        Me.lblMeserosxSec = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.numpad = New SAAB.NumericaPad()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNoMesa = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbSectores = New System.Windows.Forms.ComboBox()
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Todo.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Todo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1182, 537)
        Me.SplitContainer1.SplitterDistance = 693
        Me.SplitContainer1.TabIndex = 1
        '
        'Todo
        '
        Me.Todo.AutoSize = True
        Me.Todo.Controls.Add(Me.TabControl1)
        Me.Todo.Controls.Add(Me.PanelInfo)
        Me.Todo.Controls.Add(Me.Sector)
        Me.Todo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Todo.Location = New System.Drawing.Point(0, 0)
        Me.Todo.Name = "Todo"
        Me.Todo.Size = New System.Drawing.Size(693, 537)
        Me.Todo.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PanLeyenda)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 444)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(693, 93)
        Me.TabControl1.TabIndex = 3
        '
        'PanLeyenda
        '
        Me.PanLeyenda.Location = New System.Drawing.Point(4, 29)
        Me.PanLeyenda.Name = "PanLeyenda"
        Me.PanLeyenda.Padding = New System.Windows.Forms.Padding(3)
        Me.PanLeyenda.Size = New System.Drawing.Size(685, 60)
        Me.PanLeyenda.TabIndex = 0
        Me.PanLeyenda.Text = "Leyenda"
        Me.PanLeyenda.UseVisualStyleBackColor = True
        '
        'PanelInfo
        '
        Me.PanelInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInfo.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.PanelInfo.Controls.Add(Me.Button3)
        Me.PanelInfo.Controls.Add(Me.design)
        Me.PanelInfo.Controls.Add(Me.panelestAct)
        Me.PanelInfo.Controls.Add(Me.lblmesero)
        Me.PanelInfo.Controls.Add(Me.lblCuenta)
        Me.PanelInfo.Controls.Add(Me.Label13)
        Me.PanelInfo.Controls.Add(Me.Label12)
        Me.PanelInfo.Controls.Add(Me.lblTiempo)
        Me.PanelInfo.Controls.Add(Me.Label9)
        Me.PanelInfo.Controls.Add(Me.Label11)
        Me.PanelInfo.Controls.Add(Me.lblMesasIncl)
        Me.PanelInfo.Controls.Add(Me.Label10)
        Me.PanelInfo.Location = New System.Drawing.Point(0, 287)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(693, 250)
        Me.PanelInfo.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = Global.SAAB.My.Resources.Resources.hide
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(634, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 52)
        Me.Button3.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Button3, "Ocultar panel de informacion")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'design
        '
        Me.design.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.design.BackgroundImage = Global.SAAB.My.Resources.Resources.design
        Me.design.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.design.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.design.Location = New System.Drawing.Point(634, 3)
        Me.design.Name = "design"
        Me.design.Size = New System.Drawing.Size(55, 48)
        Me.design.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.design, "Diseñar Sector")
        Me.design.UseVisualStyleBackColor = True
        '
        'panelestAct
        '
        Me.panelestAct.Location = New System.Drawing.Point(138, 105)
        Me.panelestAct.Name = "panelestAct"
        Me.panelestAct.Size = New System.Drawing.Size(746, 45)
        Me.panelestAct.TabIndex = 2
        '
        'lblmesero
        '
        Me.lblmesero.AutoSize = True
        Me.lblmesero.Location = New System.Drawing.Point(102, 80)
        Me.lblmesero.Name = "lblmesero"
        Me.lblmesero.Size = New System.Drawing.Size(84, 20)
        Me.lblmesero.TabIndex = 1
        Me.lblmesero.Text = "Pepe Mujica"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(94, 13)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(63, 20)
        Me.lblCuenta.TabIndex = 1
        Me.lblCuenta.Text = "pedido n"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(13, 116)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 20)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Estados Activos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(13, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 20)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Atiende: "
        '
        'lblTiempo
        '
        Me.lblTiempo.AutoSize = True
        Me.lblTiempo.Location = New System.Drawing.Point(484, 13)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(110, 20)
        Me.lblTiempo.TabIndex = 1
        Me.lblTiempo.Text = "Tiempo en Mesa"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(350, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Tiempo en Mesa:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(13, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 20)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Pedido:"
        '
        'lblMesasIncl
        '
        Me.lblMesasIncl.AutoSize = True
        Me.lblMesasIncl.Location = New System.Drawing.Point(172, 44)
        Me.lblMesasIncl.Name = "lblMesasIncl"
        Me.lblMesasIncl.Size = New System.Drawing.Size(105, 20)
        Me.lblMesasIncl.TabIndex = 1
        Me.lblMesasIncl.Text = "Mesas Incluidas"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(15, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 20)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Incluye a las mesas:"
        '
        'Sector
        '
        Me.Sector.AutoScroll = True
        Me.Sector.AutoSize = True
        Me.Sector.BackColor = System.Drawing.Color.Transparent
        Me.Sector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Sector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sector.Location = New System.Drawing.Point(0, 0)
        Me.Sector.Margin = New System.Windows.Forms.Padding(10)
        Me.Sector.Name = "Sector"
        Me.Sector.Size = New System.Drawing.Size(693, 537)
        Me.Sector.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdAbrir, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMesas, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCuentas, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPersonasSector, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMeserosxSec, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.numpad, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(485, 537)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.BackColor = System.Drawing.Color.Snow
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(275, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 111)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Abrir Mesa"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAbrir
        '
        Me.cmdAbrir.BackColor = System.Drawing.Color.Snow
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmdAbrir, 2)
        Me.cmdAbrir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAbrir.Location = New System.Drawing.Point(3, 480)
        Me.cmdAbrir.Name = "cmdAbrir"
        Me.cmdAbrir.Size = New System.Drawing.Size(479, 54)
        Me.cmdAbrir.TabIndex = 10
        Me.cmdAbrir.Text = "Abrir"
        Me.cmdAbrir.UseVisualStyleBackColor = False
        '
        'lblMesas
        '
        Me.lblMesas.BackColor = System.Drawing.Color.Cornsilk
        Me.lblMesas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMesas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesas.Location = New System.Drawing.Point(275, 180)
        Me.lblMesas.Name = "lblMesas"
        Me.lblMesas.Size = New System.Drawing.Size(207, 30)
        Me.lblMesas.TabIndex = 5
        Me.lblMesas.Text = "Z"
        Me.lblMesas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Wheat
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(266, 30)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Mesas Ocupadas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCuentas
        '
        Me.lblCuentas.BackColor = System.Drawing.Color.Cornsilk
        Me.lblCuentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentas.Location = New System.Drawing.Point(275, 150)
        Me.lblCuentas.Name = "lblCuentas"
        Me.lblCuentas.Size = New System.Drawing.Size(207, 30)
        Me.lblCuentas.TabIndex = 5
        Me.lblCuentas.Text = "Y"
        Me.lblCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Cornsilk
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 50)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Zoom"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Wheat
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(266, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total Clientes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Cornsilk
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sector:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Wheat
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(266, 31)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Mesero(s) atendiendo "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPersonasSector
        '
        Me.lblPersonasSector.AutoSize = True
        Me.lblPersonasSector.BackColor = System.Drawing.Color.Cornsilk
        Me.lblPersonasSector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPersonasSector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPersonasSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonasSector.Location = New System.Drawing.Point(275, 90)
        Me.lblPersonasSector.Name = "lblPersonasSector"
        Me.lblPersonasSector.Size = New System.Drawing.Size(207, 29)
        Me.lblPersonasSector.TabIndex = 2
        Me.lblPersonasSector.Text = "n"
        Me.lblPersonasSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMeserosxSec
        '
        Me.lblMeserosxSec.BackColor = System.Drawing.Color.Cornsilk
        Me.lblMeserosxSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMeserosxSec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMeserosxSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeserosxSec.Location = New System.Drawing.Point(275, 119)
        Me.lblMeserosxSec.Name = "lblMeserosxSec"
        Me.lblMeserosxSec.Size = New System.Drawing.Size(207, 31)
        Me.lblMeserosxSec.TabIndex = 5
        Me.lblMeserosxSec.Text = "X"
        Me.lblMeserosxSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Wheat
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(266, 30)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Cuentas Abiertas"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(275, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(207, 44)
        Me.Panel1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 44)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "-"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(157, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(50, 44)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'numpad
        '
        Me.numpad.BackColor = System.Drawing.Color.Snow
        Me.numpad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numpad.Location = New System.Drawing.Point(3, 213)
        Me.numpad.Name = "numpad"
        Me.TableLayoutPanel1.SetRowSpan(Me.numpad, 3)
        Me.numpad.Size = New System.Drawing.Size(266, 261)
        Me.numpad.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Snow
        Me.Panel3.Controls.Add(Me.txtNoMesa)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(275, 324)
        Me.Panel3.Name = "Panel3"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel3, 2)
        Me.Panel3.Size = New System.Drawing.Size(207, 150)
        Me.Panel3.TabIndex = 13
        '
        'txtNoMesa
        '
        Me.txtNoMesa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNoMesa.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoMesa.Location = New System.Drawing.Point(0, 0)
        Me.txtNoMesa.Name = "txtNoMesa"
        Me.txtNoMesa.ReadOnly = True
        Me.txtNoMesa.Size = New System.Drawing.Size(207, 48)
        Me.txtNoMesa.TabIndex = 8
        Me.txtNoMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel2.Controls.Add(Me.cmbSectores)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(275, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 34)
        Me.Panel2.TabIndex = 15
        '
        'cmbSectores
        '
        Me.cmbSectores.BackColor = System.Drawing.SystemColors.Control
        Me.cmbSectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSectores.FormattingEnabled = True
        Me.cmbSectores.Location = New System.Drawing.Point(0, 0)
        Me.cmbSectores.Name = "cmbSectores"
        Me.cmbSectores.Size = New System.Drawing.Size(207, 28)
        Me.cmbSectores.TabIndex = 1
        '
        'TimerClock
        '
        Me.TimerClock.Enabled = True
        Me.TimerClock.Interval = 20000
        '
        'Restaurante
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "Restaurante"
        Me.Size = New System.Drawing.Size(1182, 537)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Todo.ResumeLayout(False)
        Me.Todo.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.PanelInfo.ResumeLayout(False)
        Me.PanelInfo.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblMesas As System.Windows.Forms.Label
    Friend WithEvents lblCuentas As System.Windows.Forms.Label
    Friend WithEvents lblMeserosxSec As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPersonasSector As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Sector As SAAB.Area
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents numpad As SAAB.NumericaPad
    Friend WithEvents cmdAbrir As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNoMesa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbSectores As System.Windows.Forms.ComboBox
    Friend WithEvents Todo As System.Windows.Forms.Panel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblMesasIncl As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents panelestAct As System.Windows.Forms.Panel
    Friend WithEvents lblmesero As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TimerClock As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents PanLeyenda As System.Windows.Forms.TabPage
    Friend WithEvents design As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
