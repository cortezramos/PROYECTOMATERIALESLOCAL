Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptKardexCompra
    Public Producto As String
    Public Bodega As Integer
    Public FechaI As New Date
    
    Private Sub RptKardexCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fechai = Date.Today
        'fechai = fechai.AddMonths(-Month(fechai))
        'fechai = fechai.AddDays(-fechai.Day + 1)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False
        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/KARDEX"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("fechai", FechaI))
        parametros.Add(New ReportParameter("fechaf", Date.Today))
        parametros.Add(New ReportParameter("producto", Producto))
        parametros.Add(New ReportParameter("bodega", Bodega))
        parametros.Add(New ReportParameter("medida", "0"))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
End Class