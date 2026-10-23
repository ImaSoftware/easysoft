<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BotonCinta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BotonCinta))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmBotonRb = New System.Windows.Forms.Button()
        Me.CmdDes = New System.Windows.Forms.Label()
        Me.ToolTipbtn = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmBotonRb)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.CmdDes)
        Me.SplitContainer1.Size = New System.Drawing.Size(114, 127)
        Me.SplitContainer1.SplitterDistance = 83
        Me.SplitContainer1.TabIndex = 0
        '
        'cmBotonRb
        '
        Me.cmBotonRb.BackColor = System.Drawing.SystemColors.Control
        Me.cmBotonRb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmBotonRb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmBotonRb.Location = New System.Drawing.Point(0, 0)
        Me.cmBotonRb.Name = "cmBotonRb"
        Me.cmBotonRb.Size = New System.Drawing.Size(114, 83)
        Me.cmBotonRb.TabIndex = 0
        Me.cmBotonRb.UseVisualStyleBackColor = False
        '
        'CmdDes
        '
        Me.CmdDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CmdDes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmdDes.Location = New System.Drawing.Point(0, 0)
        Me.CmdDes.Name = "CmdDes"
        Me.CmdDes.Size = New System.Drawing.Size(114, 40)
        Me.CmdDes.TabIndex = 0
        Me.CmdDes.Text = "&Mi boton"
        Me.CmdDes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BotonCinta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "BotonCinta"
        Me.Size = New System.Drawing.Size(114, 127)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmBotonRb As System.Windows.Forms.Button
    Friend WithEvents CmdDes As System.Windows.Forms.Label
    Friend WithEvents ToolTipbtn As System.Windows.Forms.ToolTip

End Class
