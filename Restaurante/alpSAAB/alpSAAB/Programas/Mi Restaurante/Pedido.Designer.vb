<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pedido
    Inherits DolphinForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pedido))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdVolver = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.cmdGrabar = New System.Windows.Forms.Button()
        Me.cmdGrabaPrefac = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelMesas = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPersonas = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdMas = New System.Windows.Forms.Button()
        Me.cmdMenos = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMesero = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cmdComanda = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdNuevoConsumo = New System.Windows.Forms.Button()
        Me.GridConsumos = New System.Windows.Forms.DataGridView()
        Me.IdConsumo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Consumos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._EstadoImagen = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CCOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadosImagen = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.minSector = New SAAB.Area()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.comm = New System.ComponentModel.BackgroundWorker()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.GridConsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.TableLayoutPanel1)
        Me.Ventana.Controls.Add(Me.Panel3)
        Me.Ventana.Size = New System.Drawing.Size(1251, 622)
        Me.Ventana.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Ventana.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
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
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        '
        'CmdVolver
        '
        Me.CmdVolver.AutoEllipsis = True
        Me.CmdVolver.BackgroundImage = Global.SAAB.My.Resources.Resources.back1
        Me.CmdVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CmdVolver.Dock = System.Windows.Forms.DockStyle.Left
        Me.CmdVolver.FlatAppearance.BorderSize = 0
        Me.CmdVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVolver.Location = New System.Drawing.Point(0, 0)
        Me.CmdVolver.Name = "CmdVolver"
        Me.CmdVolver.Size = New System.Drawing.Size(49, 66)
        Me.CmdVolver.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdVolver, "Volver")
        Me.CmdVolver.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.CmdCancel.ImageIndex = 1
        Me.CmdCancel.ImageList = Me.ListaPngs
        Me.CmdCancel.Location = New System.Drawing.Point(467, 44)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(185, 87)
        Me.CmdCancel.TabIndex = 12
        Me.CmdCancel.Text = "&Salir"
        Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.CmdCancel, "Vuelve a la pantalla anterior sin grabar los datos")
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmdGrabar
        '
        Me.cmdGrabar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdGrabar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdGrabar.ImageIndex = 0
        Me.cmdGrabar.ImageList = Me.ListaPngs
        Me.cmdGrabar.Location = New System.Drawing.Point(662, 44)
        Me.cmdGrabar.Name = "cmdGrabar"
        Me.cmdGrabar.Size = New System.Drawing.Size(187, 87)
        Me.cmdGrabar.TabIndex = 11
        Me.cmdGrabar.Text = "&Grabar"
        Me.cmdGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.cmdGrabar, "Graba Todos los Cambios Realizados y no cierra la cuenta")
        Me.cmdGrabar.UseVisualStyleBackColor = False
        '
        'cmdGrabaPrefac
        '
        Me.cmdGrabaPrefac.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdGrabaPrefac.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdGrabaPrefac.ImageIndex = 2
        Me.cmdGrabaPrefac.ImageList = Me.ListaPngs
        Me.cmdGrabaPrefac.Location = New System.Drawing.Point(855, 44)
        Me.cmdGrabaPrefac.Name = "cmdGrabaPrefac"
        Me.cmdGrabaPrefac.Size = New System.Drawing.Size(177, 87)
        Me.cmdGrabaPrefac.TabIndex = 10
        Me.cmdGrabaPrefac.Text = "PreFacturas y &Proformas"
        Me.cmdGrabaPrefac.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabaPrefac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.cmdGrabaPrefac, "Graba los cambios, cierra la cuenta y presenta el asistente para facturacion")
        Me.cmdGrabaPrefac.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdCerrar.ImageIndex = 5
        Me.cmdCerrar.ImageList = Me.ListaPngs
        Me.cmdCerrar.Location = New System.Drawing.Point(1038, 44)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(178, 87)
        Me.cmdCerrar.TabIndex = 14
        Me.cmdCerrar.Text = "Cerrar &Cuenta"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.cmdCerrar, "Graba los cambios, cierra la cuenta y presenta el asistente para facturacion")
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.08407!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.91593!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdComanda, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.01307!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.98693!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1249, 466)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.lblNoCuenta)
        Me.Panel4.Controls.Add(Me.CmdVolver)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(682, 66)
        Me.Panel4.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Snow
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(49, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(401, 66)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Pedido"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoCuenta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.Color.White
        Me.lblNoCuenta.Location = New System.Drawing.Point(450, 0)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(232, 66)
        Me.lblNoCuenta.TabIndex = 9
        Me.lblNoCuenta.Text = "15"
        Me.lblNoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PanelMesas, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotal, 2, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPersonas, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMesero, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.label2, 0, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(691, 75)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.54945!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45055!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(555, 372)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'PanelMesas
        '
        Me.PanelMesas.AutoScroll = True
        Me.PanelMesas.BackColor = System.Drawing.Color.Cornsilk
        Me.PanelMesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMesas.Location = New System.Drawing.Point(202, 3)
        Me.PanelMesas.Name = "PanelMesas"
        Me.PanelMesas.Size = New System.Drawing.Size(350, 70)
        Me.PanelMesas.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Harrington", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 336)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 36)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Total Cuenta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(202, 336)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(350, 36)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "15"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPersonas
        '
        Me.lblPersonas.AutoSize = True
        Me.lblPersonas.BackColor = System.Drawing.Color.Snow
        Me.lblPersonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPersonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonas.Location = New System.Drawing.Point(3, 76)
        Me.lblPersonas.Name = "lblPersonas"
        Me.lblPersonas.Size = New System.Drawing.Size(146, 74)
        Me.lblPersonas.TabIndex = 17
        Me.lblPersonas.Text = "7"
        Me.lblPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(155, 79)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(41, 68)
        Me.Panel5.TabIndex = 18
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Snow
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cmdMas, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdMenos, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(41, 68)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'cmdMas
        '
        Me.cmdMas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMas.Location = New System.Drawing.Point(3, 3)
        Me.cmdMas.Name = "cmdMas"
        Me.cmdMas.Size = New System.Drawing.Size(35, 28)
        Me.cmdMas.TabIndex = 0
        Me.cmdMas.Text = "+"
        Me.cmdMas.UseVisualStyleBackColor = True
        '
        'cmdMenos
        '
        Me.cmdMenos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMenos.Location = New System.Drawing.Point(3, 37)
        Me.cmdMenos.Name = "cmdMenos"
        Me.cmdMenos.Size = New System.Drawing.Size(35, 28)
        Me.cmdMenos.TabIndex = 1
        Me.cmdMenos.Text = "-"
        Me.cmdMenos.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(155, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(41, 70)
        Me.Panel1.TabIndex = 20
        '
        'lblMesero
        '
        Me.lblMesero.AutoSize = True
        Me.lblMesero.Location = New System.Drawing.Point(202, 298)
        Me.lblMesero.Name = "lblMesero"
        Me.lblMesero.Size = New System.Drawing.Size(49, 16)
        Me.lblMesero.TabIndex = 22
        Me.lblMesero.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Snow
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(202, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(350, 74)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Personas Incluidas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Cornsilk
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 25.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 76)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Mesas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.label2.Location = New System.Drawing.Point(3, 298)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 29)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Atiende:"
        '
        'cmdComanda
        '
        Me.cmdComanda.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdComanda.ImageIndex = 0
        Me.cmdComanda.ImageList = Me.ImageList1
        Me.cmdComanda.Location = New System.Drawing.Point(1056, 3)
        Me.cmdComanda.Name = "cmdComanda"
        Me.cmdComanda.Size = New System.Drawing.Size(190, 66)
        Me.cmdComanda.TabIndex = 8
        Me.cmdComanda.Text = "Generar Comanda"
        Me.cmdComanda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdComanda.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ComandaICon.png")
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.cmdNuevoConsumo, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.GridConsumos, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 75)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(682, 372)
        Me.TableLayoutPanel5.TabIndex = 9
        '
        'cmdNuevoConsumo
        '
        Me.cmdNuevoConsumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdNuevoConsumo.Font = New System.Drawing.Font("Monotype Corsiva", 26.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNuevoConsumo.ImageIndex = 3
        Me.cmdNuevoConsumo.ImageList = Me.ListaPngs
        Me.cmdNuevoConsumo.Location = New System.Drawing.Point(3, 309)
        Me.cmdNuevoConsumo.Name = "cmdNuevoConsumo"
        Me.cmdNuevoConsumo.Size = New System.Drawing.Size(676, 60)
        Me.cmdNuevoConsumo.TabIndex = 8
        Me.cmdNuevoConsumo.Text = " Agregar Producto"
        Me.cmdNuevoConsumo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNuevoConsumo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.cmdNuevoConsumo.UseVisualStyleBackColor = True
        '
        'GridConsumos
        '
        Me.GridConsumos.AllowUserToAddRows = False
        Me.GridConsumos.AllowUserToDeleteRows = False
        Me.GridConsumos.AllowUserToOrderColumns = True
        Me.GridConsumos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridConsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridConsumos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdConsumo, Me._Consumos, Me._Valor, Me._Estado, Me._EstadoImagen, Me.CCOM})
        Me.GridConsumos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridConsumos.Location = New System.Drawing.Point(3, 3)
        Me.GridConsumos.Name = "GridConsumos"
        Me.GridConsumos.ReadOnly = True
        Me.GridConsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridConsumos.Size = New System.Drawing.Size(676, 300)
        Me.GridConsumos.TabIndex = 7
        '
        'IdConsumo
        '
        Me.IdConsumo.DataPropertyName = "Id"
        Me.IdConsumo.HeaderText = "Id"
        Me.IdConsumo.Name = "IdConsumo"
        Me.IdConsumo.ReadOnly = True
        Me.IdConsumo.Visible = False
        '
        '_Consumos
        '
        Me._Consumos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me._Consumos.DataPropertyName = "Consumo"
        Me._Consumos.FillWeight = 131.7259!
        Me._Consumos.HeaderText = "Consumos"
        Me._Consumos.Name = "_Consumos"
        Me._Consumos.ReadOnly = True
        '
        '_Valor
        '
        Me._Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me._Valor.DataPropertyName = "ValorTotal"
        Me._Valor.FillWeight = 131.7259!
        Me._Valor.HeaderText = "Total Consumo"
        Me._Valor.Name = "_Valor"
        Me._Valor.ReadOnly = True
        Me._Valor.Width = 114
        '
        '_Estado
        '
        Me._Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me._Estado.DataPropertyName = "Estado"
        Me._Estado.HeaderText = "Estado"
        Me._Estado.Name = "_Estado"
        Me._Estado.ReadOnly = True
        Me._Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me._Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me._Estado.Visible = False
        Me._Estado.Width = 82
        '
        '_EstadoImagen
        '
        Me._EstadoImagen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me._EstadoImagen.FillWeight = 30.0!
        Me._EstadoImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me._EstadoImagen.HeaderText = "Est"
        Me._EstadoImagen.Name = "_EstadoImagen"
        Me._EstadoImagen.ReadOnly = True
        Me._EstadoImagen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me._EstadoImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me._EstadoImagen.Text = ""
        Me._EstadoImagen.UseColumnTextForButtonValue = True
        Me._EstadoImagen.Width = 30
        '
        'CCOM
        '
        Me.CCOM.DataPropertyName = "Comentario"
        Me.CCOM.HeaderText = "Comentario"
        Me.CCOM.Name = "CCOM"
        Me.CCOM.ReadOnly = True
        Me.CCOM.Visible = False
        '
        'EstadosImagen
        '
        Me.EstadosImagen.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.EstadosImagen.ImageSize = New System.Drawing.Size(24, 24)
        Me.EstadosImagen.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 466)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1249, 154)
        Me.Panel3.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.85714!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.14286!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.cmdCerrar, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CmdCancel, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cmdGrabar, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cmdGrabaPrefac, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.minSector, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ReportViewer1, 5, 2)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1249, 154)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'minSector
        '
        Me.minSector.AutoScroll = True
        Me.minSector.AutoSize = True
        Me.minSector.BackColor = System.Drawing.Color.Transparent
        Me.minSector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.minSector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.minSector.Location = New System.Drawing.Point(10, 10)
        Me.minSector.Margin = New System.Windows.Forms.Padding(10)
        Me.minSector.Name = "minSector"
        Me.TableLayoutPanel4.SetRowSpan(Me.minSector, 3)
        Me.minSector.Size = New System.Drawing.Size(444, 134)
        Me.minSector.TabIndex = 13
        Me.minSector.Visible = False
        '
        'ReportViewer1
        '
        Me.ReportViewer1.DocumentMapWidth = 17
        Me.ReportViewer1.Location = New System.Drawing.Point(1222, 137)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(19, 14)
        Me.ReportViewer1.TabIndex = 25
        Me.ReportViewer1.Visible = False
        '
        'comm
        '
        Me.comm.WorkerReportsProgress = True
        '
        'Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 650)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "Pedido"
        Me.Text = "Cuenta"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.GridConsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblNoCuenta As System.Windows.Forms.Label
    Friend WithEvents CmdVolver As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelMesas As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents EstadosImagen As System.Windows.Forms.ImageList
    Friend WithEvents lblPersonas As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdMas As System.Windows.Forms.Button
    Friend WithEvents cmdMenos As System.Windows.Forms.Button
    Friend WithEvents cmdComanda As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
    Friend WithEvents cmdGrabaPrefac As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdNuevoConsumo As System.Windows.Forms.Button
    Friend WithEvents GridConsumos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents minSector As SAAB.Area
    Friend WithEvents IdConsumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _Consumos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _EstadoImagen As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CCOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents lblMesero As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents comm As System.ComponentModel.BackgroundWorker
End Class
