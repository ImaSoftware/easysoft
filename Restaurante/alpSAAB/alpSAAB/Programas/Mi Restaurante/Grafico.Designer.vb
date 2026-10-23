<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grafico
    Inherits DolphinForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grafico))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.graphChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Ventana.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        CType(Me.graphChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.FlatAppearance.BorderSize = 0
        Me.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.cmdSalir.Location = New System.Drawing.Point(506, 0)
        '
        'Ventana
        '
        Me.Ventana.Controls.Add(Me.graphChart)
        Me.Ventana.Size = New System.Drawing.Size(536, 390)
        Me.Ventana.Controls.SetChildIndex(Me.graphChart, 0)
        '
        'PanelTitulo
        '
        Me.PanelTitulo.Size = New System.Drawing.Size(536, 28)
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
        Me.ListaPngs.Images.SetKeyName(7, "WINLOGO.jpg")
        '
        'MINIMIZE
        '
        Me.MINIMIZE.FlatAppearance.BorderSize = 0
        Me.MINIMIZE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.MINIMIZE.Location = New System.Drawing.Point(408, 0)
        '
        'WINBTN
        '
        Me.WINBTN.FlatAppearance.BorderSize = 0
        Me.WINBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.WINBTN.Location = New System.Drawing.Point(450, 0)
        '
        'graphChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.graphChart.ChartAreas.Add(ChartArea1)
        Me.graphChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.graphChart.Legends.Add(Legend1)
        Me.graphChart.Location = New System.Drawing.Point(0, 0)
        Me.graphChart.Name = "graphChart"
        Me.graphChart.Size = New System.Drawing.Size(534, 388)
        Me.graphChart.TabIndex = 1
        Me.graphChart.Text = "Ocupacion de Zona"
        '
        'Grafico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 418)
        Me.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Name = "Grafico"
        Me.Text = "Grafico"
        Me.Ventana.ResumeLayout(False)
        Me.Ventana.PerformLayout()
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelTitulo.PerformLayout()
        CType(Me.graphChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents graphChart As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
