Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net
Public Class RptInventarioFisico

    Private Sub RptInventarioFisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/TOMA FISICA"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class