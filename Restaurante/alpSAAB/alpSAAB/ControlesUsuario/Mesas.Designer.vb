<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mesa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mesa))
        Me.MenuMesa = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarTamañoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarQRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.numAlias = New System.Windows.Forms.Label()
        Me.MenuMesa.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MenuMesa
        '
        Me.MenuMesa.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoverToolStripMenuItem, Me.CambiarTamañoToolStripMenuItem, Me.PropiedadesToolStripMenuItem, Me.VisualizarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.GenerarQRToolStripMenuItem})
        Me.MenuMesa.Name = "MenuMesa"
        Me.MenuMesa.Size = New System.Drawing.Size(167, 136)
        '
        'MoverToolStripMenuItem
        '
        Me.MoverToolStripMenuItem.Name = "MoverToolStripMenuItem"
        Me.MoverToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MoverToolStripMenuItem.Text = "Mover"
        '
        'CambiarTamañoToolStripMenuItem
        '
        Me.CambiarTamañoToolStripMenuItem.Name = "CambiarTamañoToolStripMenuItem"
        Me.CambiarTamañoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CambiarTamañoToolStripMenuItem.Text = "Cambiar Tamaño"
        '
        'PropiedadesToolStripMenuItem
        '
        Me.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem"
        Me.PropiedadesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.PropiedadesToolStripMenuItem.Text = "Propiedades"
        '
        'VisualizarToolStripMenuItem
        '
        Me.VisualizarToolStripMenuItem.Name = "VisualizarToolStripMenuItem"
        Me.VisualizarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.VisualizarToolStripMenuItem.Text = "Visualizar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'GenerarQRToolStripMenuItem
        '
        Me.GenerarQRToolStripMenuItem.Name = "GenerarQRToolStripMenuItem"
        Me.GenerarQRToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.GenerarQRToolStripMenuItem.Text = "GenerarQR"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'numAlias
        '
        Me.numAlias.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.numAlias.AutoSize = True
        Me.numAlias.BackColor = System.Drawing.Color.White
        Me.numAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAlias.Location = New System.Drawing.Point(66, 71)
        Me.numAlias.Name = "numAlias"
        Me.numAlias.Size = New System.Drawing.Size(21, 13)
        Me.numAlias.TabIndex = 3
        Me.numAlias.Text = "13"
        Me.numAlias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.numAlias.Visible = False
        '
        'Mesa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContextMenuStrip = Me.MenuMesa
        Me.Controls.Add(Me.numAlias)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "Mesa"
        Me.Size = New System.Drawing.Size(169, 169)
        Me.MenuMesa.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuMesa As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MoverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarTamañoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropiedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents numAlias As System.Windows.Forms.Label
    Friend WithEvents GenerarQRToolStripMenuItem As ToolStripMenuItem
End Class
