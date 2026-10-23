<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Comandas
    Inherits DolphinCtl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comandas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.prevCoci = New System.Windows.Forms.Button()
        Me.pnlOrd = New System.Windows.Forms.Panel()
        Me.NomCocina = New System.Windows.Forms.Label()
        Me.nextCoci = New System.Windows.Forms.Button()
        Me.btnShrink = New System.Windows.Forms.Button()
        Me.btnS_Res = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlNav = New System.Windows.Forms.DataGridView()
        Me.btnEscucha = New System.Windows.Forms.Button()
        Me.GetOrders = New System.Windows.Forms.Timer(Me.components)
        Me.waitinLista = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.waitinConf = New System.Windows.Forms.Timer(Me.components)
        Me.waitinComando = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pnlNav, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ListaPngs.Images.SetKeyName(7, "shrink.png")
        Me.ListaPngs.Images.SetKeyName(8, "boca.png")
        Me.ListaPngs.Images.SetKeyName(9, "oreja.png")
        Me.ListaPngs.Images.SetKeyName(10, "noboca.png")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.prevCoci, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlOrd, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NomCocina, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.nextCoci, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShrink, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnS_Res, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlNav, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEscucha, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(549, 405)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'prevCoci
        '
        Me.prevCoci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prevCoci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.prevCoci.ImageIndex = 5
        Me.prevCoci.ImageList = Me.ListaPngs
        Me.prevCoci.Location = New System.Drawing.Point(3, 3)
        Me.prevCoci.Name = "prevCoci"
        Me.prevCoci.Size = New System.Drawing.Size(44, 44)
        Me.prevCoci.TabIndex = 6
        Me.prevCoci.UseVisualStyleBackColor = True
        '
        'pnlOrd
        '
        Me.pnlOrd.AutoScroll = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.pnlOrd, 5)
        Me.pnlOrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrd.Location = New System.Drawing.Point(3, 53)
        Me.pnlOrd.Name = "pnlOrd"
        Me.pnlOrd.Size = New System.Drawing.Size(490, 249)
        Me.pnlOrd.TabIndex = 2
        '
        'NomCocina
        '
        Me.NomCocina.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.NomCocina, 2)
        Me.NomCocina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NomCocina.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NomCocina.Location = New System.Drawing.Point(53, 0)
        Me.NomCocina.Name = "NomCocina"
        Me.NomCocina.Size = New System.Drawing.Size(343, 50)
        Me.NomCocina.TabIndex = 4
        Me.NomCocina.Text = "Cocina Caliente"
        Me.NomCocina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nextCoci
        '
        Me.nextCoci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nextCoci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nextCoci.ImageIndex = 6
        Me.nextCoci.ImageList = Me.ListaPngs
        Me.nextCoci.Location = New System.Drawing.Point(499, 3)
        Me.nextCoci.Name = "nextCoci"
        Me.nextCoci.Size = New System.Drawing.Size(47, 44)
        Me.nextCoci.TabIndex = 5
        Me.nextCoci.UseVisualStyleBackColor = True
        '
        'btnShrink
        '
        Me.btnShrink.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShrink.ImageIndex = 7
        Me.btnShrink.ImageList = Me.ListaPngs
        Me.btnShrink.Location = New System.Drawing.Point(450, 3)
        Me.btnShrink.Name = "btnShrink"
        Me.btnShrink.Size = New System.Drawing.Size(43, 44)
        Me.btnShrink.TabIndex = 7
        Me.btnShrink.UseVisualStyleBackColor = True
        '
        'btnS_Res
        '
        Me.btnS_Res.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnS_Res.ImageIndex = 3
        Me.btnS_Res.ImageList = Me.ListaPngs
        Me.btnS_Res.Location = New System.Drawing.Point(499, 53)
        Me.btnS_Res.Name = "btnS_Res"
        Me.btnS_Res.Size = New System.Drawing.Size(47, 249)
        Me.btnS_Res.TabIndex = 8
        Me.btnS_Res.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.ImageIndex = 5
        Me.Button1.ImageList = Me.ListaPngs
        Me.Button1.Location = New System.Drawing.Point(3, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 94)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.ImageIndex = 6
        Me.Button2.ImageList = Me.ListaPngs
        Me.Button2.Location = New System.Drawing.Point(499, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 94)
        Me.Button2.TabIndex = 9
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlNav
        '
        Me.pnlNav.AllowUserToAddRows = False
        Me.pnlNav.AllowUserToDeleteRows = False
        Me.pnlNav.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.pnlNav.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlNav.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.pnlNav.ColumnHeadersVisible = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.pnlNav, 4)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pnlNav.DefaultCellStyle = DataGridViewCellStyle1
        Me.pnlNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNav.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.pnlNav.Location = New System.Drawing.Point(53, 308)
        Me.pnlNav.MultiSelect = False
        Me.pnlNav.Name = "pnlNav"
        Me.pnlNav.ReadOnly = True
        Me.pnlNav.RowHeadersVisible = False
        Me.pnlNav.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.pnlNav.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.pnlNav.Size = New System.Drawing.Size(440, 94)
        Me.pnlNav.TabIndex = 10
        '
        'btnEscucha
        '
        Me.btnEscucha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEscucha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscucha.ImageKey = "oreja.png"
        Me.btnEscucha.ImageList = Me.ListaPngs
        Me.btnEscucha.Location = New System.Drawing.Point(402, 3)
        Me.btnEscucha.Name = "btnEscucha"
        Me.btnEscucha.Size = New System.Drawing.Size(42, 44)
        Me.btnEscucha.TabIndex = 7
        Me.btnEscucha.UseVisualStyleBackColor = True
        '
        'GetOrders
        '
        Me.GetOrders.Interval = 5000
        '
        'waitinLista
        '
        '
        'waitinConf
        '
        '
        'waitinComando
        '
        '
        'Comandas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Name = "Comandas"
        Me.Size = New System.Drawing.Size(549, 405)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.pnlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlOrd As Panel
    Friend WithEvents GetOrders As Timer
    Friend WithEvents prevCoci As Button
    Friend WithEvents NomCocina As Label
    Friend WithEvents nextCoci As Button
    Friend WithEvents btnShrink As Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnlNav As System.Windows.Forms.DataGridView
    Friend WithEvents btnS_Res As Button
    Friend WithEvents waitinLista As Timer
    Friend WithEvents btnEscucha As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents waitinConf As Timer
    Friend WithEvents waitinComando As Timer
End Class
