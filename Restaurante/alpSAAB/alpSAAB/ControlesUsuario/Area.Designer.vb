<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Area
    Inherits System.Windows.Forms.UserControl


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.menuArea = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarPuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSector = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarElementosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEtiquetas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDeTextoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDeFondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DialogoImagen = New System.Windows.Forms.OpenFileDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ImagenFondo = New System.Windows.Forms.ImageList(Me.components)
        Me.CDColor = New System.Windows.Forms.ColorDialog()
        Me.PanelArea = New System.Windows.Forms.Panel()
        Me.bwEstados = New System.ComponentModel.BackgroundWorker()
        Me.menuArea.SuspendLayout()
        Me.MenuSector.SuspendLayout()
        Me.MenuEtiquetas.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuArea
        '
        Me.menuArea.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarPuntoToolStripMenuItem, Me.PropiedadesToolStripMenuItem})
        Me.menuArea.Name = "menuArea"
        Me.menuArea.Size = New System.Drawing.Size(152, 48)
        '
        'AgregarPuntoToolStripMenuItem
        '
        Me.AgregarPuntoToolStripMenuItem.Name = "AgregarPuntoToolStripMenuItem"
        Me.AgregarPuntoToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.AgregarPuntoToolStripMenuItem.Text = "Agregar punto"
        '
        'PropiedadesToolStripMenuItem
        '
        Me.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem"
        Me.PropiedadesToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.PropiedadesToolStripMenuItem.Text = "Propiedades"
        '
        'MenuSector
        '
        Me.MenuSector.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarElementosToolStripMenuItem})
        Me.MenuSector.Name = "ContextMenuStrip1"
        Me.MenuSector.Size = New System.Drawing.Size(114, 26)
        '
        'ModificarElementosToolStripMenuItem
        '
        Me.ModificarElementosToolStripMenuItem.Name = "ModificarElementosToolStripMenuItem"
        Me.ModificarElementosToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ModificarElementosToolStripMenuItem.Text = "Diseñar"
        '
        'MenuEtiquetas
        '
        Me.MenuEtiquetas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.MoverToolStripMenuItem, Me.ColorDeTextoToolStripMenuItem, Me.ColorDeFondoToolStripMenuItem})
        Me.MenuEtiquetas.Name = "MenuEtiquetas"
        Me.MenuEtiquetas.Size = New System.Drawing.Size(157, 114)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'MoverToolStripMenuItem
        '
        Me.MoverToolStripMenuItem.Name = "MoverToolStripMenuItem"
        Me.MoverToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.MoverToolStripMenuItem.Text = "Mover"
        '
        'ColorDeTextoToolStripMenuItem
        '
        Me.ColorDeTextoToolStripMenuItem.Name = "ColorDeTextoToolStripMenuItem"
        Me.ColorDeTextoToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ColorDeTextoToolStripMenuItem.Text = "Color de Texto"
        '
        'ColorDeFondoToolStripMenuItem
        '
        Me.ColorDeFondoToolStripMenuItem.Name = "ColorDeFondoToolStripMenuItem"
        Me.ColorDeFondoToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ColorDeFondoToolStripMenuItem.Text = "Color de Fondo"
        '
        'DialogoImagen
        '
        Me.DialogoImagen.FileName = "ImagenEscogida"
        Me.DialogoImagen.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF;*.PNG"
        '
        'ImagenFondo
        '
        Me.ImagenFondo.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImagenFondo.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImagenFondo.TransparentColor = System.Drawing.Color.Black
        '
        'CDColor
        '
        Me.CDColor.AnyColor = True
        Me.CDColor.Color = System.Drawing.Color.Transparent
        Me.CDColor.FullOpen = True
        '
        'PanelArea
        '
        Me.PanelArea.AutoScroll = True
        Me.PanelArea.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelArea.ContextMenuStrip = Me.menuArea
        Me.PanelArea.Location = New System.Drawing.Point(-6, -7)
        Me.PanelArea.Name = "PanelArea"
        Me.PanelArea.Size = New System.Drawing.Size(115, 88)
        Me.PanelArea.TabIndex = 3
        '
        'bwEstados
        '
        '
        'Area
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContextMenuStrip = Me.MenuSector
        Me.Controls.Add(Me.PanelArea)
        Me.Margin = New System.Windows.Forms.Padding(10)
        Me.Name = "Area"
        Me.Size = New System.Drawing.Size(359, 202)
        Me.menuArea.ResumeLayout(False)
        Me.MenuSector.ResumeLayout(False)
        Me.MenuEtiquetas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents menuArea As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarPuntoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropiedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSector As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarElementosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEtiquetas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DialogoImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ImagenFondo As System.Windows.Forms.ImageList
    Friend WithEvents ColorDeTextoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDeFondoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CDColor As System.Windows.Forms.ColorDialog
    Friend WithEvents PanelArea As System.Windows.Forms.Panel
    Friend WithEvents bwEstados As System.ComponentModel.BackgroundWorker

End Class
