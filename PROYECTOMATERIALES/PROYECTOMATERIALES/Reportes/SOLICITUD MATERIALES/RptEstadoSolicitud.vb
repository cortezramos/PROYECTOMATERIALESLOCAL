Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net
Public Class RptEstadoSolicitud
    Private Numero As Integer
#Region "Controles"
    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/ESTADO SOLICITUD"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("numero", txtNumero.Text))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
#End Region
    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub RptEstadoSolicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 100
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If String.IsNullOrEmpty(txtNumero.Text) = False Then
            mostrarReporte()
        Else
            MsgBox("Ingrese numero de solicitud a consultar", MsgBoxStyle.Exclamation, "Error de ingreso")
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(txtNumero.Text) = False Then
                mostrarReporte()
            Else
                MsgBox("Ingrese numero de solicitud a consultar", MsgBoxStyle.Exclamation, "Error de ingreso")
                txtNumero.Focus()
            End If
        End If
    End Sub
End Class