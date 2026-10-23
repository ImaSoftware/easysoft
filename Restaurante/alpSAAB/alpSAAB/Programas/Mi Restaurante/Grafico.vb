Imports System.Windows.Forms.DataVisualization.Charting

Public Enum tipoGrafico
    Ocupacion
    Meseros_Cuentas
    Cuentas

End Enum
Public Class Grafico
    Property TablaGrafico As DataTable
    Sub New(ByVal tipo As tipoGrafico, ByVal argdatasource As DataTable)


        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        '  Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TablaGrafico = argdatasource
        Select Case tipo
            Case tipoGrafico.Ocupacion
                graphChart.Series.Add("Ocupacion")

                graphChart.Series("Ocupacion").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                graphChart.Series("Ocupacion")("PieLabelStyle") = "Outside"
                graphChart.Series("Ocupacion")("PieLineColor") = "Black"
                graphChart.Series("Ocupacion").XValueMember = TablaGrafico.Columns(0).ColumnName
                graphChart.Series("Ocupacion").YValueMembers = TablaGrafico.Columns(1).ColumnName
                graphChart.Series("Ocupacion").IsValueShownAsLabel = True
                graphChart.DataSource = TablaGrafico
                graphChart.DataBind()
            Case tipoGrafico.Meseros_Cuentas
                graphChart.Series.Add("Cuentas Atendidas")
                graphChart.Series("Cuentas Atendidas").ChartType = DataVisualization.Charting.SeriesChartType.Column
                graphChart.Series("Cuentas Atendidas").XValueMember = TablaGrafico.Columns(0).ColumnName
                graphChart.Series("Cuentas Atendidas").YValueMembers = TablaGrafico.Columns(1).ColumnName
                graphChart.Series("Cuentas Atendidas").IsValueShownAsLabel = True
                graphChart.DataSource = TablaGrafico
                graphChart.DataBind()
            Case tipoGrafico.Cuentas
                graphChart.Series.Add("Total Cuenta")
                graphChart.Series("Total Cuenta").ChartType = DataVisualization.Charting.SeriesChartType.Point
                graphChart.Series("Total Cuenta").XValueMember = TablaGrafico.Columns(0).ColumnName
                graphChart.Series("Total Cuenta").YValueMembers = TablaGrafico.Columns(1).ColumnName
                graphChart.Series("Total Cuenta").IsValueShownAsLabel = True
                graphChart.DataSource = TablaGrafico
                graphChart.DataBind()
        End Select

    End Sub
    Public Sub Actualiza(ByVal argdatasource As DataTable)
        TablaGrafico = argdatasource
        graphChart.DataBind()
    End Sub
End Class