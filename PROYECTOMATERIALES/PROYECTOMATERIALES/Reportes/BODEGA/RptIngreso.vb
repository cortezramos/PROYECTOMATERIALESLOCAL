Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptIngreso
#Region "Controles"
    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/INGRESO"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = False

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("numero", Numero))
        parametros.Add(New ReportParameter("ingreso", Ingreso))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
#End Region
    Public Numero As Integer
    Public Ingreso As Integer

    Private Sub RptIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarReporte()
    End Sub
End Class