<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Esquematizador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Esquematizador))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Sector = New Area()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdImagen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdMesa = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdGrabar = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(855, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.TableLayoutPanel1)
        Me.Ventana.Size = New System.Drawing.Size(885, 734)
        Me.Ventana.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(885, 28)
        '
        'ListaPngs
        '
        Me.ListaPngs.ImageStream = CType(resources.GetObject("ListaPngs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaPngs.Images.SetKeyName(0, "save.png")
        Me.ListaPngs.Images.SetKeyName(1, "NoSign.png")
        Me.ListaPngs.Images.SetKeyName(2, "Bill.png")
        Me.ListaPngs.Images.SetKeyName(3, "Agrega.png")
        Me.ListaPngs.Images.SetKeyName(4, "ComandaICon.png")
        Me.ListaPngs.Images.SetKeyName(5, "db.png")
        Me.ListaPngs.Images.SetKeyName(6, "go-previous.png")
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.Location = New System.Drawing.Point(757, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(799, 0)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblNombre, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Sector, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGrabar, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(883, 732)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.AutoEllipsis = True
        Me.lblNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblNombre, 2)
        Me.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.White
        Me.lblNombre.Location = New System.Drawing.Point(3, 570)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(229, 71)
        Me.lblNombre.TabIndex = 10
        Me.lblNombre.Text = "Nombre de Area"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Sector
        '
        Me.Sector.AutoScroll = True
        Me.Sector.AutoSize = True
        Me.Sector.BackColor = System.Drawing.Color.Transparent
        Me.Sector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Sector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sector.Location = New System.Drawing.Point(245, 10)
        Me.Sector.Margin = New System.Windows.Forms.Padding(10)
        Me.Sector.Name = "Sector"
        Me.TableLayoutPanel1.SetRowSpan(Me.Sector, 3)
        Me.Sector.Size = New System.Drawing.Size(628, 692)
        Me.Sector.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 564)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdImagen, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdMesa, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.28283!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.050505!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.28283!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.050505!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.28283!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.050505!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(229, 564)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'cmdImagen
        '
        Me.cmdImagen.BackgroundImage = Global.SAAB.My.Resources.Resources.pictureEj
        Me.cmdImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdImagen.Location = New System.Drawing.Point(3, 3)
        Me.cmdImagen.Name = "cmdImagen"
        Me.cmdImagen.Size = New System.Drawing.Size(223, 153)
        Me.cmdImagen.TabIndex = 0
        Me.cmdImagen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 533)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Insertar Etiqueta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Insertar Nueva Imagen"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackgroundImage = My.Resources.Resources.font
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(3, 377)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(223, 153)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdMesa
        '
        Me.cmdMesa.BackgroundImage = My.Resources.Resources.table
        Me.cmdMesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdMesa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMesa.Location = New System.Drawing.Point(3, 190)
        Me.cmdMesa.Name = "cmdMesa"
        Me.cmdMesa.Size = New System.Drawing.Size(223, 153)
        Me.cmdMesa.TabIndex = 0
        Me.cmdMesa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 28)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Insertar Nueva Mesa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdGrabar
        '
        Me.cmdGrabar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabar.ImageKey = "save.png"
        Me.cmdGrabar.ImageList = Me.ListaPngs
        Me.cmdGrabar.Location = New System.Drawing.Point(3, 644)
        Me.cmdGrabar.Name = "cmdGrabar"
        Me.cmdGrabar.Size = New System.Drawing.Size(106, 65)
        Me.cmdGrabar.TabIndex = 3
        Me.cmdGrabar.Text = "Grabar"
        Me.cmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGrabar.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(238, 712)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(219, 20)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Seleccione una forma para agregar"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.ImageIndex = 5
        Me.Button1.ImageList = Me.ListaPngs
        Me.Button1.Location = New System.Drawing.Point(115, 644)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 65)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Cargar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Esquematizador
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(885, 762)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "Esquematizador"
        Me.Text = "Esquematizador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Sector As SAAB.Area
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdImagen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdMesa As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
End Class
