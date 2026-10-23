<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busqueda
    Inherits System.Windows.Forms.UserControl

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busqueda))
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GV_Consulta = New System.Windows.Forms.DataGridView()
        Me.btnMode = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tableLayoutPanel1.SuspendLayout()
        CType(Me.GV_Consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tableLayoutPanel1.ColumnCount = 5
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.GV_Consulta, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.btnMode, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.btnSearch, 3, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.txtSearch, 1, 3)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 5
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(448, 379)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'GV_Consulta
        '
        Me.GV_Consulta.AllowUserToAddRows = False
        Me.GV_Consulta.AllowUserToDeleteRows = False
        Me.GV_Consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GV_Consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GV_Consulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GV_Consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.GV_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tableLayoutPanel1.SetColumnSpan(Me.GV_Consulta, 3)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GV_Consulta.DefaultCellStyle = DataGridViewCellStyle1
        Me.GV_Consulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GV_Consulta.Location = New System.Drawing.Point(13, 13)
        Me.GV_Consulta.Name = "GV_Consulta"
        Me.GV_Consulta.ReadOnly = True
        Me.GV_Consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GV_Consulta.Size = New System.Drawing.Size(420, 319)
        Me.GV_Consulta.TabIndex = 2
        '
        'btnMode
        '
        Me.btnMode.BackColor = System.Drawing.Color.Transparent
        Me.btnMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMode.FlatAppearance.BorderSize = 0
        Me.btnMode.Location = New System.Drawing.Point(379, 347)
        Me.btnMode.Name = "btnMode"
        Me.btnMode.Size = New System.Drawing.Size(24, 21)
        Me.btnMode.TabIndex = 3
        Me.btnMode.TabStop = False
        Me.btnMode.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = Global.SAAB.My.Resources.Resources.s_search
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.Location = New System.Drawing.Point(409, 347)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(24, 21)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearch.Location = New System.Drawing.Point(13, 347)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(360, 20)
        Me.txtSearch.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "s_fx.png")
        '
        'ErrP
        '
        Me.ErrP.ContainerControl = Me
        '
        'busqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "busqueda"
        Me.Size = New System.Drawing.Size(448, 379)
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        CType(Me.GV_Consulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents tableLayoutPanel1 As TableLayoutPanel
    Private WithEvents GV_Consulta As DataGridView
    Private WithEvents btnMode As Button
    Private WithEvents btnSearch As Button
    Private WithEvents txtSearch As TextBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ErrP As ErrorProvider
End Class
