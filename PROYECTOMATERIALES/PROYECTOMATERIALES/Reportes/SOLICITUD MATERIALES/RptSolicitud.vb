﻿Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net
Public Class RptSolicitud
    Public Numero As Integer
    Private Sub RptSolicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False
        rpt.ProcessingMode = ProcessingMode.Remote
        'rpt.ServerReport.ReportServerUrl = New Uri("http://APPS2/ReportServer/")
        'rpt.ServerReport.ReportPath = "/Reports/SOLICITUD"
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/SOLICITUD"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("numero", Numero))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
End Class