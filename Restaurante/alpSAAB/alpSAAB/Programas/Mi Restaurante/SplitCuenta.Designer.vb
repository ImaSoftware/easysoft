<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplitCuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplitCuenta))
        Me.layoutTablaPrinc = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridTouchDisp = New SAAB.GridTouch()
        Me.GridTouchSeparado = New SAAB.GridTouch()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.derTodos = New System.Windows.Forms.Button()
        Me.dercant = New System.Windows.Forms.Button()
        Me.izqcant = New System.Windows.Forms.Button()
        Me.izqTodos = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Abajo = New System.Windows.Forms.Button()
        Me.Arriba = New System.Windows.Forms.Button()
        Me.txtcantPasar = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdGrabar1 = New System.Windows.Forms.Button()
        Me.cmdGPT = New System.Windows.Forms.Button()
        Me.cmdGP1 = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdsig = New System.Windows.Forms.Button()
        Me.lbltotamb = New System.Windows.Forms.Label()
        Me.cmdAnt = New System.Windows.Forms.Button()
        Me.txtNoFac = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.cmdGrabarT = New System.Windows.Forms.Button()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.layoutTablaPrinc.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(1074, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.layoutTablaPrinc)
        Me.Ventana.Size = New System.Drawing.Size(1104, 572)
        Me.Ventana.Controls.SetChildIndex(Me.layoutTablaPrinc, 0)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(1104, 28)
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
        Me.ListaPngs.Images.SetKeyName(8, "delete.png")
        Me.ListaPngs.Images.SetKeyName(9, "delete2.png")
        Me.ListaPngs.Images.SetKeyName(10, "billT.png")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.Location = New System.Drawing.Point(976, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(1018, 0)
        '
        'layoutTablaPrinc
        '
        Me.layoutTablaPrinc.ColumnCount = 1
        Me.layoutTablaPrinc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutTablaPrinc.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.layoutTablaPrinc.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.layoutTablaPrinc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutTablaPrinc.Location = New System.Drawing.Point(0, 0)
        Me.layoutTablaPrinc.Name = "layoutTablaPrinc"
        Me.layoutTablaPrinc.RowCount = 2
        Me.layoutTablaPrinc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.layoutTablaPrinc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.layoutTablaPrinc.Size = New System.Drawing.Size(1102, 570)
        Me.layoutTablaPrinc.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GridTouchDisp, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GridTouchSeparado, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.32507!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.67493!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1096, 393)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Harrington", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(638, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(455, 56)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Pre - Factura"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Harrington", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(454, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consumos en Pedido"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridTouchDisp
        '
        Me.GridTouchDisp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTouchDisp.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTouchDisp.Location = New System.Drawing.Point(6, 62)
        Me.GridTouchDisp.Margin = New System.Windows.Forms.Padding(6)
        Me.GridTouchDisp.Name = "GridTouchDisp"
        Me.GridTouchDisp.Size = New System.Drawing.Size(448, 325)
        Me.GridTouchDisp.TabIndex = 1
        '
        'GridTouchSeparado
        '
        Me.GridTouchSeparado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTouchSeparado.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTouchSeparado.Location = New System.Drawing.Point(641, 62)
        Me.GridTouchSeparado.Margin = New System.Windows.Forms.Padding(6)
        Me.GridTouchSeparado.Name = "GridTouchSeparado"
        Me.GridTouchSeparado.Size = New System.Drawing.Size(449, 325)
        Me.GridTouchSeparado.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.derTodos, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dercant, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.izqcant, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.izqTodos, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(463, 59)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(169, 331)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'derTodos
        '
        Me.derTodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.derTodos.Location = New System.Drawing.Point(3, 3)
        Me.derTodos.Name = "derTodos"
        Me.derTodos.Size = New System.Drawing.Size(163, 60)
        Me.derTodos.TabIndex = 0
        Me.derTodos.Text = ">>"
        Me.derTodos.UseVisualStyleBackColor = True
        '
        'dercant
        '
        Me.dercant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dercant.Location = New System.Drawing.Point(3, 69)
        Me.dercant.Name = "dercant"
        Me.dercant.Size = New System.Drawing.Size(163, 60)
        Me.dercant.TabIndex = 1
        Me.dercant.Text = ">"
        Me.dercant.UseVisualStyleBackColor = True
        '
        'izqcant
        '
        Me.izqcant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.izqcant.Location = New System.Drawing.Point(3, 201)
        Me.izqcant.Name = "izqcant"
        Me.izqcant.Size = New System.Drawing.Size(163, 60)
        Me.izqcant.TabIndex = 3
        Me.izqcant.Text = "<"
        Me.izqcant.UseVisualStyleBackColor = True
        '
        'izqTodos
        '
        Me.izqTodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.izqTodos.Location = New System.Drawing.Point(3, 267)
        Me.izqTodos.Name = "izqTodos"
        Me.izqTodos.Size = New System.Drawing.Size(163, 61)
        Me.izqTodos.TabIndex = 4
        Me.izqTodos.Text = "<<"
        Me.izqTodos.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtcantPasar, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 135)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(163, 60)
        Me.TableLayoutPanel3.TabIndex = 5
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Abajo, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Arriba, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(117, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(43, 54)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Abajo
        '
        Me.Abajo.BackColor = System.Drawing.Color.Transparent
        Me.Abajo.BackgroundImage = Global.SAAB.My.Resources.Resources._1downarrow
        Me.Abajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Abajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abajo.Location = New System.Drawing.Point(3, 30)
        Me.Abajo.Name = "Abajo"
        Me.Abajo.Size = New System.Drawing.Size(37, 21)
        Me.Abajo.TabIndex = 1
        Me.Abajo.UseVisualStyleBackColor = False
        '
        'Arriba
        '
        Me.Arriba.BackColor = System.Drawing.Color.Transparent
        Me.Arriba.BackgroundImage = Global.SAAB.My.Resources.Resources._1uparrow
        Me.Arriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Arriba.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Arriba.Location = New System.Drawing.Point(3, 3)
        Me.Arriba.Name = "Arriba"
        Me.Arriba.Size = New System.Drawing.Size(37, 21)
        Me.Arriba.TabIndex = 2
        Me.Arriba.UseVisualStyleBackColor = False
        '
        'txtcantPasar
        '
        Me.txtcantPasar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtcantPasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantPasar.Location = New System.Drawing.Point(3, 3)
        Me.txtcantPasar.Multiline = True
        Me.txtcantPasar.Name = "txtcantPasar"
        Me.txtcantPasar.ReadOnly = True
        Me.txtcantPasar.Size = New System.Drawing.Size(108, 54)
        Me.txtcantPasar.TabIndex = 1
        Me.txtcantPasar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 402)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1096, 165)
        Me.SplitContainer1.SplitterDistance = 109
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblTotal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel6)
        Me.SplitContainer2.Size = New System.Drawing.Size(1096, 109)
        Me.SplitContainer2.SplitterDistance = 455
        Me.SplitContainer2.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(134, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(321, 109)
        Me.lblTotal.TabIndex = 17
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Harrington", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 34)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 11
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.1!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09!))
        Me.TableLayoutPanel6.Controls.Add(Me.cmdGrabar1, 6, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdGPT, 9, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdGP1, 8, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdDelete, 7, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdNuevo, 5, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdsig, 4, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.lbltotamb, 3, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cmdAnt, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.txtNoFac, 2, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(637, 109)
        Me.TableLayoutPanel6.TabIndex = 4
        '
        'cmdGrabar1
        '
        Me.cmdGrabar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGrabar1.ImageKey = "save.png"
        Me.cmdGrabar1.ImageList = Me.ListaPngs
        Me.cmdGrabar1.Location = New System.Drawing.Point(345, 37)
        Me.cmdGrabar1.Name = "cmdGrabar1"
        Me.cmdGrabar1.Size = New System.Drawing.Size(51, 34)
        Me.cmdGrabar1.TabIndex = 8
        Me.cmdGrabar1.UseVisualStyleBackColor = True
        '
        'cmdGPT
        '
        Me.cmdGPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGPT.ImageIndex = 10
        Me.cmdGPT.ImageList = Me.ListaPngs
        Me.cmdGPT.Location = New System.Drawing.Point(516, 37)
        Me.cmdGPT.Name = "cmdGPT"
        Me.cmdGPT.Size = New System.Drawing.Size(51, 34)
        Me.cmdGPT.TabIndex = 7
        Me.cmdGPT.UseVisualStyleBackColor = True
        '
        'cmdGP1
        '
        Me.cmdGP1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGP1.ImageKey = "Bill.png"
        Me.cmdGP1.ImageList = Me.ListaPngs
        Me.cmdGP1.Location = New System.Drawing.Point(459, 37)
        Me.cmdGP1.Name = "cmdGP1"
        Me.cmdGP1.Size = New System.Drawing.Size(51, 34)
        Me.cmdGP1.TabIndex = 5
        Me.cmdGP1.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdDelete.ImageKey = "delete2.png"
        Me.cmdDelete.ImageList = Me.ListaPngs
        Me.cmdDelete.Location = New System.Drawing.Point(402, 37)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(51, 34)
        Me.cmdDelete.TabIndex = 4
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdNuevo.ImageKey = "Agrega.png"
        Me.cmdNuevo.ImageList = Me.ListaPngs
        Me.cmdNuevo.Location = New System.Drawing.Point(288, 37)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(51, 34)
        Me.cmdNuevo.TabIndex = 3
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdsig
        '
        Me.cmdsig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdsig.ImageKey = "go-previous.png"
        Me.cmdsig.ImageList = Me.ListaPngs
        Me.cmdsig.Location = New System.Drawing.Point(231, 37)
        Me.cmdsig.Name = "cmdsig"
        Me.cmdsig.Size = New System.Drawing.Size(51, 34)
        Me.cmdsig.TabIndex = 3
        Me.cmdsig.UseVisualStyleBackColor = True
        '
        'lbltotamb
        '
        Me.lbltotamb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbltotamb.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotamb.Location = New System.Drawing.Point(174, 34)
        Me.lbltotamb.Name = "lbltotamb"
        Me.lbltotamb.Size = New System.Drawing.Size(51, 40)
        Me.lbltotamb.TabIndex = 3
        Me.lbltotamb.Text = "/n"
        Me.lbltotamb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAnt
        '
        Me.cmdAnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAnt.ImageIndex = 6
        Me.cmdAnt.ImageList = Me.ListaPngs
        Me.cmdAnt.Location = New System.Drawing.Point(60, 37)
        Me.cmdAnt.Name = "cmdAnt"
        Me.cmdAnt.Size = New System.Drawing.Size(51, 34)
        Me.cmdAnt.TabIndex = 3
        Me.cmdAnt.UseVisualStyleBackColor = True
        '
        'txtNoFac
        '
        Me.txtNoFac.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNoFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoFac.Location = New System.Drawing.Point(117, 37)
        Me.txtNoFac.Name = "txtNoFac"
        Me.txtNoFac.ReadOnly = True
        Me.txtNoFac.Size = New System.Drawing.Size(51, 35)
        Me.txtNoFac.TabIndex = 2
        Me.txtNoFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.CmdCancel, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cmdGrabarT, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1096, 52)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmdCancel.ImageIndex = 1
        Me.CmdCancel.ImageList = Me.ListaPngs
        Me.CmdCancel.Location = New System.Drawing.Point(3, 3)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(542, 46)
        Me.CmdCancel.TabIndex = 7
        Me.CmdCancel.Text = "&Salir"
        Me.CmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'cmdGrabarT
        '
        Me.cmdGrabarT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGrabarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdGrabarT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGrabarT.ImageIndex = 0
        Me.cmdGrabarT.ImageList = Me.ListaPngs
        Me.cmdGrabarT.Location = New System.Drawing.Point(551, 3)
        Me.cmdGrabarT.Name = "cmdGrabarT"
        Me.cmdGrabarT.Size = New System.Drawing.Size(542, 46)
        Me.cmdGrabarT.TabIndex = 6
        Me.cmdGrabarT.Text = "&Prefacturar y Salir"
        Me.cmdGrabarT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabarT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGrabarT.UseVisualStyleBackColor = False
        '
        'SplitCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 600)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "SplitCuenta"
        Me.Text = "SplitCuenta"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.layoutTablaPrinc.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutTablaPrinc As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridTouchDisp As SAAB.GridTouch
    Friend WithEvents GridTouchSeparado As SAAB.GridTouch
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents derTodos As System.Windows.Forms.Button
    Friend WithEvents dercant As System.Windows.Forms.Button
    Friend WithEvents izqcant As System.Windows.Forms.Button
    Friend WithEvents izqTodos As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtcantPasar As System.Windows.Forms.TextBox
    Friend WithEvents Abajo As System.Windows.Forms.Button
    Friend WithEvents Arriba As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdGrabarT As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtNoFac As System.Windows.Forms.TextBox
    Friend WithEvents cmdsig As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents lbltotamb As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cmdAnt As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents cmdGPT As Button
    Friend WithEvents cmdGP1 As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdGrabar1 As Button
End Class
