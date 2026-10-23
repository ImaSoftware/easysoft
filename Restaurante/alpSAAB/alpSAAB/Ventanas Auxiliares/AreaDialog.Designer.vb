<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AreaDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TabTodo = New System.Windows.Forms.TabControl()
        Me.Data = New System.Windows.Forms.TabPage()
        Me.txtDSC = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Alto = New System.Windows.Forms.NumericUpDown()
        Me.Ancho = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkNoImagen = New System.Windows.Forms.CheckBox()
        Me.cmbLayout = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblfullname = New System.Windows.Forms.Label()
        Me.btnA = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AbrirDialog = New System.Windows.Forms.Button()
        Me.chkTrans = New System.Windows.Forms.CheckBox()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.CD = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabTodo.SuspendLayout()
        Me.Data.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Alto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ancho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(303, 366)
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
        'TabTodo
        '
        Me.TabTodo.Controls.Add(Me.Data)
        Me.TabTodo.Controls.Add(Me.TabPage2)
        Me.TabTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabTodo.Location = New System.Drawing.Point(12, 26)
        Me.TabTodo.Name = "TabTodo"
        Me.TabTodo.SelectedIndex = 0
        Me.TabTodo.Size = New System.Drawing.Size(438, 321)
        Me.TabTodo.TabIndex = 1
        '
        'Data
        '
        Me.Data.Controls.Add(Me.txtDSC)
        Me.Data.Controls.Add(Me.txtName)
        Me.Data.Controls.Add(Me.Label2)
        Me.Data.Controls.Add(Me.Label1)
        Me.Data.Location = New System.Drawing.Point(4, 34)
        Me.Data.Name = "Data"
        Me.Data.Padding = New System.Windows.Forms.Padding(3)
        Me.Data.Size = New System.Drawing.Size(430, 283)
        Me.Data.TabIndex = 0
        Me.Data.Text = "Data"
        Me.Data.UseVisualStyleBackColor = True
        '
        'txtDSC
        '
        Me.txtDSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDSC.Location = New System.Drawing.Point(22, 91)
        Me.txtDSC.MaxLength = 200
        Me.txtDSC.Multiline = True
        Me.txtDSC.Name = "txtDSC"
        Me.txtDSC.Size = New System.Drawing.Size(382, 105)
        Me.txtDSC.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(106, 28)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(298, 26)
        Me.txtName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(430, 283)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Fondo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Alto)
        Me.GroupBox2.Controls.Add(Me.Ancho)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.chkNoImagen)
        Me.GroupBox2.Controls.Add(Me.cmbLayout)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblfullname)
        Me.GroupBox2.Controls.Add(Me.btnA)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(407, 168)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imagen"
        '
        'Alto
        '
        Me.Alto.Location = New System.Drawing.Point(103, 129)
        Me.Alto.Maximum = New Decimal(New Integer() {7000, 0, 0, 0})
        Me.Alto.Name = "Alto"
        Me.Alto.Size = New System.Drawing.Size(81, 30)
        Me.Alto.TabIndex = 12
        '
        'Ancho
        '
        Me.Ancho.Location = New System.Drawing.Point(105, 94)
        Me.Ancho.Maximum = New Decimal(New Integer() {7000, 0, 0, 0})
        Me.Ancho.Name = "Ancho"
        Me.Ancho.Size = New System.Drawing.Size(81, 30)
        Me.Ancho.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 25)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Alto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 25)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Ancho"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Textura"
        '
        'chkNoImagen
        '
        Me.chkNoImagen.AutoSize = True
        Me.chkNoImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoImagen.Location = New System.Drawing.Point(18, 29)
        Me.chkNoImagen.Name = "chkNoImagen"
        Me.chkNoImagen.Size = New System.Drawing.Size(130, 29)
        Me.chkNoImagen.TabIndex = 10
        Me.chkNoImagen.Text = "Sin Imagen"
        Me.chkNoImagen.UseVisualStyleBackColor = True
        '
        'cmbLayout
        '
        Me.cmbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayout.FormattingEnabled = True
        Me.cmbLayout.Items.AddRange(New Object() {"None", "Tile", "Center", "Stretch", "Zoom"})
        Me.cmbLayout.Location = New System.Drawing.Point(270, 109)
        Me.cmbLayout.Name = "cmbLayout"
        Me.cmbLayout.Size = New System.Drawing.Size(121, 33)
        Me.cmbLayout.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Layout"
        '
        'lblfullname
        '
        Me.lblfullname.AutoEllipsis = True
        Me.lblfullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblfullname.Location = New System.Drawing.Point(99, 61)
        Me.lblfullname.Name = "lblfullname"
        Me.lblfullname.Size = New System.Drawing.Size(262, 23)
        Me.lblfullname.TabIndex = 7
        Me.lblfullname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnA
        '
        Me.btnA.Location = New System.Drawing.Point(365, 60)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(26, 25)
        Me.btnA.TabIndex = 8
        Me.btnA.Text = "..."
        Me.btnA.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AbrirDialog)
        Me.GroupBox1.Controls.Add(Me.chkTrans)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(17, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 84)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color "
        '
        'AbrirDialog
        '
        Me.AbrirDialog.Location = New System.Drawing.Point(18, 29)
        Me.AbrirDialog.Name = "AbrirDialog"
        Me.AbrirDialog.Size = New System.Drawing.Size(148, 41)
        Me.AbrirDialog.TabIndex = 11
        Me.AbrirDialog.UseVisualStyleBackColor = True
        '
        'chkTrans
        '
        Me.chkTrans.AutoSize = True
        Me.chkTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrans.Location = New System.Drawing.Point(213, 36)
        Me.chkTrans.Name = "chkTrans"
        Me.chkTrans.Size = New System.Drawing.Size(148, 29)
        Me.chkTrans.TabIndex = 10
        Me.chkTrans.Text = "Transparente"
        Me.chkTrans.UseVisualStyleBackColor = True
        '
        'AreaDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(461, 407)
        Me.Controls.Add(Me.TabTodo)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AreaDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AreaDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabTodo.ResumeLayout(False)
        Me.Data.ResumeLayout(False)
        Me.Data.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Alto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ancho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TabTodo As System.Windows.Forms.TabControl
    Friend WithEvents Data As System.Windows.Forms.TabPage
    Friend WithEvents txtDSC As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnA As System.Windows.Forms.Button
    Friend WithEvents lblfullname As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbLayout As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AbrirDialog As System.Windows.Forms.Button
    Friend WithEvents chkTrans As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CD As System.Windows.Forms.ColorDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Alto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Ancho As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkNoImagen As System.Windows.Forms.CheckBox

End Class
