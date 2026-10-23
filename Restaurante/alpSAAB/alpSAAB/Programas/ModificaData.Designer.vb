<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificaData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificaData))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdGrabar = New System.Windows.Forms.Button()
        Me.gtData = New SAAB.GridTouch()
        Me.PanelControles = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.ListaPngs.Images.SetKeyName(7, "icon_edit.png")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdEdit, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGrabar, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.gtData, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelControles, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(766, 279)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.Color.White
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdEdit.ImageIndex = 7
        Me.cmdEdit.ImageList = Me.ListaPngs
        Me.cmdEdit.Location = New System.Drawing.Point(385, 237)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(185, 39)
        Me.cmdEdit.TabIndex = 13
        Me.cmdEdit.Text = "&Editar"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdGrabar
        '
        Me.cmdGrabar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdGrabar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdGrabar.ImageIndex = 0
        Me.cmdGrabar.ImageList = Me.ListaPngs
        Me.cmdGrabar.Location = New System.Drawing.Point(576, 237)
        Me.cmdGrabar.Name = "cmdGrabar"
        Me.cmdGrabar.Size = New System.Drawing.Size(187, 39)
        Me.cmdGrabar.TabIndex = 12
        Me.cmdGrabar.Text = "&Grabar"
        Me.cmdGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdGrabar.UseVisualStyleBackColor = False
        '
        'gtData
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.gtData, 4)
        Me.gtData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gtData.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gtData.Location = New System.Drawing.Point(6, 6)
        Me.gtData.Margin = New System.Windows.Forms.Padding(6)
        Me.gtData.Name = "gtData"
        Me.gtData.Size = New System.Drawing.Size(754, 105)
        Me.gtData.TabIndex = 0
        '
        'PanelControles
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.PanelControles, 6)
        Me.PanelControles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControles.Location = New System.Drawing.Point(3, 120)
        Me.PanelControles.Name = "PanelControles"
        Me.PanelControles.Size = New System.Drawing.Size(760, 111)
        Me.PanelControles.TabIndex = 1
        '
        'ModificaData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "ModificaData"
        Me.Size = New System.Drawing.Size(766, 279)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents gtData As SAAB.GridTouch
    Friend WithEvents PanelControles As System.Windows.Forms.Panel
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Minsector As New Area
End Class
