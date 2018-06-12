﻿Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net
Public Class RptSolicitudPendiente

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
            ServicePointManager.Expect100Continue = False

            rpt.ProcessingMode = ProcessingMode.Remote
            rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
            rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/SOLICITUD PENDIENTE"

            rpt.Visible = True
            rpt.ShowParameterPrompts = False
            rpt.ShowCredentialPrompts = True


            Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
            parametros.Add(New ReportParameter("empresa", empresaid))
            parametros.Add(New ReportParameter("fechai", CDate(dtFechaI.Text)))
            parametros.Add(New ReportParameter("fechaf", CDate(dtFechaF.Text)))

            rpt.ServerReport.SetParameters(parametros)
            rpt.RefreshReport()
        Else
            MsgBox("Fecha final debe ser mayor a fecha inicial", MsgBoxStyle.Exclamation, "Error de validacion")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub RptSolicitudPendiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 100
    End Sub

    Private Sub dtFechaI_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFechaI.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.SendWait("{RIGHT}")
        End If
    End Sub

    Private Sub dtFechaF_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFechaF.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.SendWait("{RIGHT}")
        End If
    End Sub
End Class