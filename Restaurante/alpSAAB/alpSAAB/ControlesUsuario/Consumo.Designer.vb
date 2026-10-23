<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Consumo
    Inherits UserControl

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCant = New System.Windows.Forms.Label()
        Me.lblNomProd = New System.Windows.Forms.Label()
        Me.chkCons = New SAAB.MyCheckBox()
        Me.comm = New SAAB.dolfinBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCant, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNomProd, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkCons, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.comm, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(158, 55)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCant
        '
        Me.lblCant.AutoSize = True
        Me.lblCant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCant.Location = New System.Drawing.Point(3, 0)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(34, 30)
        Me.lblCant.TabIndex = 1
        Me.lblCant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNomProd
        '
        Me.lblNomProd.AutoSize = True
        Me.lblNomProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNomProd.Location = New System.Drawing.Point(43, 0)
        Me.lblNomProd.Name = "lblNomProd"
        Me.lblNomProd.Size = New System.Drawing.Size(72, 30)
        Me.lblNomProd.TabIndex = 2
        Me.lblNomProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkCons
        '
        Me.chkCons.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkCons.Location = New System.Drawing.Point(121, 3)
        Me.chkCons.Name = "chkCons"
        Me.chkCons.Size = New System.Drawing.Size(34, 24)
        Me.chkCons.TabIndex = 3
        Me.chkCons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCons.UseVisualStyleBackColor = True
        '
        'comm
        '
        Me.comm.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.comm, 3)
        Me.comm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comm.Location = New System.Drawing.Point(3, 33)
        Me.comm.Multiline = True
        Me.comm.Name = "comm"
        Me.comm.ReadOnly = True
        Me.comm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.comm.Size = New System.Drawing.Size(152, 19)
        Me.comm.TabIndex = 4
        '
        'Consumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Consumo"
        Me.Size = New System.Drawing.Size(158, 55)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblCant As Label
    Friend WithEvents lblNomProd As Label
    Friend WithEvents chkCons As MyCheckBox
    Friend WithEvents comm As dolfinBox
End Class
