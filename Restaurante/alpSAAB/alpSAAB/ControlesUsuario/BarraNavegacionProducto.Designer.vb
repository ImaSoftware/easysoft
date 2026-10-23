<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarraNavegacionProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarraNavegacionProducto))
        Me.cmdback = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPagina = New System.Windows.Forms.Label()
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
        '
        'cmdback
        '
        Me.cmdback.BackColor = System.Drawing.Color.White
        Me.cmdback.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdback.FlatAppearance.BorderSize = 0
        Me.cmdback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange
        Me.cmdback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow
        Me.cmdback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdback.ImageKey = "go-previous.png"
        Me.cmdback.ImageList = Me.ListaPngs
        Me.cmdback.Location = New System.Drawing.Point(3, 3)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(94, 34)
        Me.cmdback.TabIndex = 0
        Me.cmdback.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.White
        Me.cmdNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange
        Me.cmdNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Snow
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.ImageKey = "go-next.png"
        Me.cmdNext.ImageList = Me.ListaPngs
        Me.cmdNext.Location = New System.Drawing.Point(565, 3)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(94, 34)
        Me.cmdNext.TabIndex = 0
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdback, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdNext, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPagina, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(662, 40)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblPagina
        '
        Me.lblPagina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPagina.Location = New System.Drawing.Point(103, 0)
        Me.lblPagina.Name = "lblPagina"
        Me.lblPagina.Size = New System.Drawing.Size(456, 40)
        Me.lblPagina.TabIndex = 1
        Me.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraNavegacionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "BarraNavegacionProducto"
        Me.Size = New System.Drawing.Size(662, 40)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents lblPagina As System.Windows.Forms.Label

End Class
