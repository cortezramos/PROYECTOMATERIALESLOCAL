﻿Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.IO

Public Class RptDevoluciones
#Region "Controles"
    Sub mostraReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/DEVOLUCION"

        rpt.Visible = True
        rpt.ShowCredentialPrompts = False
        rpt.ShowParameterPrompts = False

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("numero", Numero))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub

#End Region
    Public Numero As Integer

    Private Sub RptDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostraReporte()
    End Sub
End Class