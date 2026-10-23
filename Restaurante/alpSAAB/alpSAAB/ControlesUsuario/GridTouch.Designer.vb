<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridTouch
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Abajo = New System.Windows.Forms.Button()
        Me.Arriba = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GridDeDatos = New System.Windows.Forms.DataGridView()
        Me.PanelBotones.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1202, 560)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No existen registros que mostrar"
        '
        'PanelBotones
        '
        Me.PanelBotones.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBotones.Location = New System.Drawing.Point(1114, 0)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(88, 560)
        Me.PanelBotones.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Abajo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Arriba, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(88, 560)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Abajo
        '
        Me.Abajo.BackColor = System.Drawing.Color.Transparent
        Me.Abajo.BackgroundImage = Global.SAAB.My.Resources.Resources._1downarrow
        Me.Abajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Abajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abajo.Location = New System.Drawing.Point(3, 283)
        Me.Abajo.Name = "Abajo"
        Me.Abajo.Size = New System.Drawing.Size(82, 274)
        Me.Abajo.TabIndex = 3
        Me.Abajo.UseVisualStyleBackColor = False
        '
        'Arriba
        '
        Me.Arriba.BackColor = System.Drawing.Color.Transparent
        Me.Arriba.BackgroundImage = Global.SAAB.My.Resources.Resources._1uparrow
        Me.Arriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Arriba.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Arriba.Location = New System.Drawing.Point(3, 3)
        Me.Arriba.Name = "Arriba"
        Me.Arriba.Size = New System.Drawing.Size(82, 274)
        Me.Arriba.TabIndex = 2
        Me.Arriba.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.PanelBotones)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1204, 562)
        Me.Panel3.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridDeDatos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1114, 560)
        Me.Panel1.TabIndex = 5
        '
        'GridDeDatos
        '
        Me.GridDeDatos.AllowUserToAddRows = False
        Me.GridDeDatos.AllowUserToDeleteRows = False
        Me.GridDeDatos.AllowUserToOrderColumns = True
        Me.GridDeDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridDeDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridDeDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDeDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDeDatos.Location = New System.Drawing.Point(0, 0)
        Me.GridDeDatos.Margin = New System.Windows.Forms.Padding(6)
        Me.GridDeDatos.MultiSelect = False
        Me.GridDeDatos.Name = "GridDeDatos"
        Me.GridDeDatos.ReadOnly = True
        Me.GridDeDatos.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.GridDeDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridDeDatos.Size = New System.Drawing.Size(1114, 560)
        Me.GridDeDatos.TabIndex = 4
        '
        'GridTouch
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "GridTouch"
        Me.Size = New System.Drawing.Size(1204, 562)
        Me.PanelBotones.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanelBotones As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GridDeDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Abajo As System.Windows.Forms.Button
    Friend WithEvents Arriba As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
