Imports Microsoft.Reporting.WinForms
Imports Microsoft.ReportingServices
Imports System.Net
Imports System.IO

Public Class RptSalidas
#Region "Controles"
    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/ENVIO"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = False

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("numero", Numero))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
#End Region

    Public Numero As Integer

    Private Sub RptSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarReporte()
    End Sub
End Class