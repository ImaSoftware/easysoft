<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MesaDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PanelElementos = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AbrirDialog = New System.Windows.Forms.Button()
        Me.chkTrans = New System.Windows.Forms.CheckBox()
        Me.chkescirc = New System.Windows.Forms.CheckBox()
        Me.btnA = New System.Windows.Forms.Button()
        Me.lblfullname = New System.Windows.Forms.Label()
        Me.ControlCapacidad = New System.Windows.Forms.NumericUpDown()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelVistaPrevia = New System.Windows.Forms.Panel()
        Me.ElementoMesa = New Mesa()
        Me.textDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tam_height = New System.Windows.Forms.NumericUpDown()
        Me.tam_width = New System.Windows.Forms.NumericUpDown()
        Me.posy = New System.Windows.Forms.NumericUpDown()
        Me.posx = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColorPick = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelElementos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ControlCapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVistaPrevia.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tam_height, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tam_width, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.posy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.posx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(304, 387)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'PanelElementos
        '
        Me.PanelElementos.BackColor = System.Drawing.Color.White
        Me.PanelElementos.Controls.Add(Me.GroupBox1)
        Me.PanelElementos.Controls.Add(Me.chkescirc)
        Me.PanelElementos.Controls.Add(Me.btnA)
        Me.PanelElementos.Controls.Add(Me.lblfullname)
        Me.PanelElementos.Controls.Add(Me.ControlCapacidad)
        Me.PanelElementos.Controls.Add(Me.txtAlias)
        Me.PanelElementos.Controls.Add(Me.Label2)
        Me.PanelElementos.Controls.Add(Me.Label3)
        Me.PanelElementos.Controls.Add(Me.Label1)
        Me.PanelElementos.Controls.Add(Me.PanelVistaPrevia)
        Me.PanelElementos.Location = New System.Drawing.Point(9, 20)
        Me.PanelElementos.Name = "PanelElementos"
        Me.PanelElementos.Size = New System.Drawing.Size(404, 327)
        Me.PanelElementos.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AbrirDialog)
        Me.GroupBox1.Controls.Add(Me.chkTrans)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(226, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 113)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color"
        '
        'AbrirDialog
        '
        Me.AbrirDialog.Location = New System.Drawing.Point(6, 31)
        Me.AbrirDialog.Name = "AbrirDialog"
        Me.AbrirDialog.Size = New System.Drawing.Size(148, 41)
        Me.AbrirDialog.TabIndex = 11
        Me.AbrirDialog.UseVisualStyleBackColor = True
        '
        'chkTrans
        '
        Me.chkTrans.AutoSize = True
        Me.chkTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrans.Location = New System.Drawing.Point(6, 78)
        Me.chkTrans.Name = "chkTrans"
        Me.chkTrans.Size = New System.Drawing.Size(148, 29)
        Me.chkTrans.TabIndex = 10
        Me.chkTrans.Text = "Transparente"
        Me.chkTrans.UseVisualStyleBackColor = True
        '
        'chkescirc
        '
        Me.chkescirc.AutoSize = True
        Me.chkescirc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkescirc.Location = New System.Drawing.Point(228, 89)
        Me.chkescirc.Name = "chkescirc"
        Me.chkescirc.Size = New System.Drawing.Size(121, 29)
        Me.chkescirc.TabIndex = 4
        Me.chkescirc.Text = "Es circular"
        Me.chkescirc.UseVisualStyleBackColor = True
        '
        'btnA
        '
        Me.btnA.Location = New System.Drawing.Point(362, 257)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(26, 25)
        Me.btnA.TabIndex = 5
        Me.btnA.Text = "..."
        Me.btnA.UseVisualStyleBackColor = True
        '
        'lblfullname
        '
        Me.lblfullname.AutoEllipsis = True
        Me.lblfullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblfullname.Location = New System.Drawing.Point(96, 258)
        Me.lblfullname.Name = "lblfullname"
        Me.lblfullname.Size = New System.Drawing.Size(262, 23)
        Me.lblfullname.TabIndex = 5
        Me.lblfullname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ControlCapacidad
        '
        Me.ControlCapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlCapacidad.Location = New System.Drawing.Point(321, 53)
        Me.ControlCapacidad.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.ControlCapacidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ControlCapacidad.Name = "ControlCapacidad"
        Me.ControlCapacidad.Size = New System.Drawing.Size(71, 30)
        Me.ControlCapacidad.TabIndex = 2
        Me.ControlCapacidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtAlias
        '
        Me.txtAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.Location = New System.Drawing.Point(96, 289)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(292, 30)
        Me.txtAlias.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Capacidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Textura"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Alias"
        '
        'PanelVistaPrevia
        '
        Me.PanelVistaPrevia.AutoScroll = True
        Me.PanelVistaPrevia.BackColor = System.Drawing.Color.White
        Me.PanelVistaPrevia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelVistaPrevia.Controls.Add(Me.ElementoMesa)
        Me.PanelVistaPrevia.Location = New System.Drawing.Point(18, 14)
        Me.PanelVistaPrevia.Name = "PanelVistaPrevia"
        Me.PanelVistaPrevia.Size = New System.Drawing.Size(200, 223)
        Me.PanelVistaPrevia.TabIndex = 7
        '
        'ElementoMesa
        '
        Me.ElementoMesa.AutoScroll = True
        Me.ElementoMesa.AutoSize = True
        Me.ElementoMesa.BackColor = System.Drawing.Color.Transparent
        Me.ElementoMesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ElementoMesa.Location = New System.Drawing.Point(0, 0)
        Me.ElementoMesa.Name = "ElementoMesa"
        Me.ElementoMesa.Size = New System.Drawing.Size(111, 88)
        Me.ElementoMesa.TabIndex = 1
        Me.ElementoMesa.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(442, 379)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelElementos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(434, 353)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tam_height)
        Me.TabPage2.Controls.Add(Me.tam_width)
        Me.TabPage2.Controls.Add(Me.posy)
        Me.TabPage2.Controls.Add(Me.posx)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(434, 353)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Posicion y tamaño"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tam_height
        '
        Me.tam_height.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tam_height.Location = New System.Drawing.Point(215, 196)
        Me.tam_height.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.tam_height.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tam_height.Name = "tam_height"
        Me.tam_height.Size = New System.Drawing.Size(71, 30)
        Me.tam_height.TabIndex = 7
        Me.tam_height.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tam_width
        '
        Me.tam_width.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tam_width.Location = New System.Drawing.Point(215, 167)
        Me.tam_width.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.tam_width.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tam_width.Name = "tam_width"
        Me.tam_width.Size = New System.Drawing.Size(71, 30)
        Me.tam_width.TabIndex = 6
        Me.tam_width.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'posy
        '
        Me.posy.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posy.Location = New System.Drawing.Point(215, 79)
        Me.posy.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.posy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.posy.Name = "posy"
        Me.posy.Size = New System.Drawing.Size(71, 30)
        Me.posy.TabIndex = 5
        Me.posy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'posx
        '
        Me.posx.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posx.Location = New System.Drawing.Point(215, 52)
        Me.posx.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.posx.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.posx.Name = "posx"
        Me.posx.Size = New System.Drawing.Size(71, 30)
        Me.posx.TabIndex = 4
        Me.posx.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(119, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 25)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Alto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(161, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 25)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Y"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(119, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 25)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Ancho"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(161, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 25)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "X"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 25)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Tamaño"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 25)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Posicion"
        '
        'MesaDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(462, 428)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MesaDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MesaDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelElementos.ResumeLayout(False)
        Me.PanelElementos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ControlCapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVistaPrevia.ResumeLayout(False)
        Me.PanelVistaPrevia.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tam_height, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tam_width, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.posy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.posx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PanelElementos As System.Windows.Forms.Panel
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ControlCapacidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelVistaPrevia As System.Windows.Forms.Panel
    Friend WithEvents btnA As System.Windows.Forms.Button
    Friend WithEvents lblfullname As System.Windows.Forms.Label
    Friend WithEvents textDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ElementoMesa As Mesa
    Friend WithEvents chkescirc As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tam_height As System.Windows.Forms.NumericUpDown
    Friend WithEvents tam_width As System.Windows.Forms.NumericUpDown
    Friend WithEvents posy As System.Windows.Forms.NumericUpDown
    Friend WithEvents posx As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColorPick As System.Windows.Forms.ColorDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AbrirDialog As System.Windows.Forms.Button
    Friend WithEvents chkTrans As System.Windows.Forms.CheckBox

End Class
