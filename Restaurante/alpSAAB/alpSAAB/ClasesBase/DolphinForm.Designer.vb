<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DolphinForm
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DolphinForm))
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.Ventana = New System.Windows.Forms.Panel()
        Me.panelForms = New System.Windows.Forms.Panel()
        Me.PanelTitulo = New System.Windows.Forms.Panel()
        Me.MINIMIZE = New System.Windows.Forms.Button()
        Me.WINBTN = New System.Windows.Forms.Button()
        Me.ListaPngs = New System.Windows.Forms.ImageList(Me.components)
        Me.MasterTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.cmdSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Location = New System.Drawing.Point(1221, 0)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(28, 26)
        Me.cmdSalir.TabIndex = 0
        Me.cmdSalir.TabStop = False
        Me.cmdSalir.Text = "X"
        Me.cmdSalir.UseVisualStyleBackColor = False
        '
        'Ventana
        '
        Me.Ventana.BackColor = System.Drawing.Color.White
        Me.Ventana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ventana.Controls.Add(Me.panelForms)
        Me.Ventana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ventana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ventana.Location = New System.Drawing.Point(0, 28)
        Me.Ventana.Name = "Ventana"
        Me.Ventana.Size = New System.Drawing.Size(1251, 472)
        Me.Ventana.TabIndex = 6
        '
        'panelForms
        '
        Me.panelForms.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelForms.AutoSize = True
        Me.panelForms.BackColor = System.Drawing.Color.White
        Me.panelForms.Location = New System.Drawing.Point(1059, 0)
        Me.panelForms.Name = "panelForms"
        Me.panelForms.Size = New System.Drawing.Size(189, 24)
        Me.panelForms.TabIndex = 4
        Me.panelForms.Visible = False
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.Transparent
        Me.PanelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelTitulo.Controls.Add(Me.MINIMIZE)
        Me.PanelTitulo.Controls.Add(Me.WINBTN)
        Me.PanelTitulo.Controls.Add(Me.cmdSalir)
        Me.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(1251, 28)
        Me.PanelTitulo.TabIndex = 5
        '
        'MINIMIZE
        '
        Me.MINIMIZE.AutoSize = True
        Me.MINIMIZE.BackColor = System.Drawing.Color.FromArgb(CType(CType(134, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.MINIMIZE.Dock = System.Windows.Forms.DockStyle.Right
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MINIMIZE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MINIMIZE.Location = New System.Drawing.Point(1123, 0)
        Me.MINIMIZE.Name = "MINIMIZE"
        Me.MINIMIZE.Size = New System.Drawing.Size(42, 26)
        Me.MINIMIZE.TabIndex = 2
        Me.MINIMIZE.TabStop = False
        Me.MINIMIZE.Text = "MIN"
        Me.MINIMIZE.UseVisualStyleBackColor = False
        '
        'WINBTN
        '
        Me.WINBTN.AutoSize = True
        Me.WINBTN.BackColor = System.Drawing.Color.White
        Me.WINBTN.Dock = System.Windows.Forms.DockStyle.Right
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WINBTN.ImageIndex = 7
        Me.WINBTN.ImageList = Me.ListaPngs
        Me.WINBTN.Location = New System.Drawing.Point(1165, 0)
        Me.WINBTN.Name = "WINBTN"
        Me.WINBTN.Size = New System.Drawing.Size(56, 26)
        Me.WINBTN.TabIndex = 1
        Me.WINBTN.TabStop = False
        Me.WINBTN.UseVisualStyleBackColor = False
        '
        'ListaPngs
        '
        Me.ListaPngs.ImageStream = CType(resources.GetObject("ListaPngs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaPngs.TransparentColor = System.Drawing.Color.White
        Me.ListaPngs.Images.SetKeyName(0, "save.png")
        Me.ListaPngs.Images.SetKeyName(1, "NoSign.png")
        Me.ListaPngs.Images.SetKeyName(2, "Agrega.png")
        Me.ListaPngs.Images.SetKeyName(3, "Bill.png")
        Me.ListaPngs.Images.SetKeyName(4, "ComandaICon.png")
        Me.ListaPngs.Images.SetKeyName(5, "go-previous.png")
        Me.ListaPngs.Images.SetKeyName(6, "go-next.png")
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        Me.ListaPngs.Images.SetKeyName(8, "shrink.png")
        Me.ListaPngs.Images.SetKeyName(9, "delete.png")
        Me.ListaPngs.Images.SetKeyName(10, "delete2.png")
        Me.ListaPngs.Images.SetKeyName(11, "billT.png")
        '
        'DolphinForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1251, 500)
        Me.Controls.Add(Me.Ventana)
        Me.Controls.Add(Me.PanelTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DolphinForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DolphinForm"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents cmdSalir As System.Windows.Forms.Button
    Public WithEvents Ventana As System.Windows.Forms.Panel
    Public WithEvents PanelTitulo As System.Windows.Forms.Panel
    Public WithEvents ListaPngs As System.Windows.Forms.ImageList
    Public WithEvents MINIMIZE As System.Windows.Forms.Button
    Public WithEvents WINBTN As System.Windows.Forms.Button
    Friend WithEvents panelForms As System.Windows.Forms.Panel
    Friend WithEvents MasterTip As ToolTip
End Class
