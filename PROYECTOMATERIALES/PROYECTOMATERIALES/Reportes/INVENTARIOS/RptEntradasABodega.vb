Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptEntradasABodega
#Region "Controles"
    Sub cargarBodegas()
        With cmbBodega
            .DataSource = clordenes.seleccionBodegaConsultaKardex()
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub cargarClientes()
        With cmbCliente
            .DataSource = clproductos.seleccionarClienteReporteria()
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
        End With
    End Sub

#End Region

    Private clordenes As New clOrdenesCompra
    Private clproductos As New clProductos

    Private Sub RptEntradasABodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 150
        cargarClientes()
        cargarBodegas()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbCliente.SelectedValue <> "0" Then
                If cmbBodega.SelectedValue > 0 Then
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
                    ServicePointManager.Expect100Continue = False

                    rpt.ProcessingMode = ProcessingMode.Remote
                    rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
                    rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/ENTRADABODEGA"

                    rpt.Visible = True
                    rpt.ShowParameterPrompts = False
                    rpt.ShowCredentialPrompts = True

                    Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
                    parametros.Add(New ReportParameter("empresa", empresaid))
                    parametros.Add(New ReportParameter("Fecha_Ini", CDate(dtFechaI.Text)))
                    parametros.Add(New ReportParameter("Fecha_Fin", CDate(dtFechaF.Text)))
                    parametros.Add(New ReportParameter("Cliente", CStr(cmbCliente.SelectedValue)))
                    parametros.Add(New ReportParameter("Bodega", CInt(cmbBodega.SelectedValue)))

                    rpt.ServerReport.SetParameters(parametros)
                    rpt.RefreshReport()
                Else
                    MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation, "Error de ingreso")
                End If
            Else
                MsgBox("Seleccione cliente", MsgBoxStyle.Exclamation, "Error de ingreso")
                cmbCliente.Focus()
            End If
        Else
            MsgBox("Fecha final no puede ser menor a fecha inicial", MsgBoxStyle.Exclamation, "Error de ingreso")
            dtFechaF.Focus()
        End If
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub cmbCliente_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbCliente.MouseWheel
        If cmbCliente.DroppedDown Then
            Exit Sub
        Else
            cmbCliente.SelectedIndex = -1
            cmbCliente.Focus()
        End If
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