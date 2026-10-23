<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class botonpunto
    Inherits System.Windows.Forms.Button

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
        Me.Menupunto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Eliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Propiedades = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Menupunto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menupunto
        '
        Me.Menupunto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Eliminar, Me.Propiedades})
        Me.Menupunto.Name = "Menupunto"
        Me.Menupunto.Size = New System.Drawing.Size(140, 48)
        '
        'Eliminar
        '
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(139, 22)
        Me.Eliminar.Text = "Eliminar"
        '
        'Propiedades
        '
        Me.Propiedades.Name = "Propiedades"
        Me.Propiedades.Size = New System.Drawing.Size(139, 22)
        Me.Propiedades.Text = "Propiedades"
        '
        'botonpunto
        '
        Me.FlatStyle = Windows.Forms.FlatStyle.Flat
        Me.BackColor = Color.Black
        Me.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Red)
        Me.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Black)
        Me.ContextMenuStrip = Me.Menupunto
        Me.Menupunto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Menupunto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Propiedades As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
