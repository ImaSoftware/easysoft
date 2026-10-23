<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemInventario
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Abajo = New System.Windows.Forms.Button()
        Me.BtnImagen = New System.Windows.Forms.Button()
        Me.Arriba = New System.Windows.Forms.Button()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Abajo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnImagen, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Arriba, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDesc, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNum, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.82474!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.17526!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(241, 165)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Abajo
        '
        Me.Abajo.BackColor = System.Drawing.Color.Transparent
        Me.Abajo.BackgroundImage = Global.SAAB.My.Resources.Resources._1downarrow
        Me.Abajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Abajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Abajo.Location = New System.Drawing.Point(172, 107)
        Me.Abajo.Name = "Abajo"
        Me.Abajo.Size = New System.Drawing.Size(66, 55)
        Me.Abajo.TabIndex = 3
        Me.Abajo.UseVisualStyleBackColor = False
        '
        'BtnImagen
        '
        Me.BtnImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnImagen.Location = New System.Drawing.Point(3, 3)
        Me.BtnImagen.Name = "BtnImagen"
        Me.TableLayoutPanel1.SetRowSpan(Me.BtnImagen, 2)
        Me.BtnImagen.Size = New System.Drawing.Size(163, 98)
        Me.BtnImagen.TabIndex = 2
        Me.BtnImagen.UseVisualStyleBackColor = True
        '
        'Arriba
        '
        Me.Arriba.BackColor = System.Drawing.Color.Transparent
        Me.Arriba.BackgroundImage = Global.SAAB.My.Resources.Resources._1uparrow
        Me.Arriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Arriba.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Arriba.Location = New System.Drawing.Point(172, 3)
        Me.Arriba.Name = "Arriba"
        Me.Arriba.Size = New System.Drawing.Size(66, 57)
        Me.Arriba.TabIndex = 4
        Me.Arriba.UseVisualStyleBackColor = False
        '
        'lblDesc
        '
        Me.lblDesc.AutoEllipsis = True
        Me.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDesc.Location = New System.Drawing.Point(3, 104)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(163, 61)
        Me.lblDesc.TabIndex = 1
        Me.lblDesc.Text = "EjProducto"
        Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNum
        '
        Me.txtNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNum.Location = New System.Drawing.Point(172, 66)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(66, 33)
        Me.txtNum.TabIndex = 5
        '
        'ItemInventario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ItemInventario"
        Me.Size = New System.Drawing.Size(241, 165)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents BtnImagen As System.Windows.Forms.Button
    Friend WithEvents Abajo As System.Windows.Forms.Button
    Friend WithEvents Arriba As System.Windows.Forms.Button
    Friend WithEvents txtNum As System.Windows.Forms.TextBox

End Class
