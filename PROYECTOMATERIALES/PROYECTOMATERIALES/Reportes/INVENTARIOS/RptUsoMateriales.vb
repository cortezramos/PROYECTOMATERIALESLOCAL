Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptUsoMateriales
#Region "Controles"
    Public Sub cargarProductos(Valor As String)
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = clsolicitud.consultaProductosReporteria()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = clsolicitud.consultaProductosReporteria()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Sub cargarBodegas()
        With cmbBodega
            .DataSource = clordenes.seleccionBodegaConsultaKardex()
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub cargarFincas()
        With cmbFinca
            .DataSource = clproductos.consultarFincasReporteria
            .ValueMember = "Valor"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub cargarCentroCosto()
        With cmbCentroCosto
            .DataSource = clproductos.consultarCentroCostoReporteria()
            .ValueMember = "Valor"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False
        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/SALIDA DEVOLUCION"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("bodega", CInt(cmbBodega.SelectedValue)))
        parametros.Add(New ReportParameter("finca", CStr(cmbFinca.SelectedValue)))
        parametros.Add(New ReportParameter("muestra", CInt(cmbMuestra.SelectedIndex)))
        parametros.Add(New ReportParameter("centro", CStr(cmbCentroCosto.SelectedValue)))
        parametros.Add(New ReportParameter("fechai", CDate(dtFechaI.Text)))
        parametros.Add(New ReportParameter("producto", CStr(cmbProducto.SelectedValue)))
        parametros.Add(New ReportParameter("fechaf", CDate(dtFechaF.Text)))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub

#End Region

    Private clsolicitud As New clSolicitudMateriales
    Private clordenes As New clOrdenesCompra
    Private clproductos As New clProductos

    Private Sub RptUsoMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 175
        cargarProductos(Nothing)
        cargarBodegas()
        cargarFincas()
        cargarCentroCosto()
        cmbMuestra.SelectedIndex = 0
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyValue = Keys.F7 Then
            Dim frm As New FrmBusquedaDeProductos
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    cargarProductos(.codigoseleccion)
                Else
                    cargarProductos(Nothing)
                    MsgBox("No se selecciono ningun producto", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End With
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbMuestra.SelectedIndex > 0 Then
                If cmbProducto.SelectedValue <> "0" Then
                    If cmbBodega.SelectedValue > 0 Then
                        If cmbFinca.SelectedIndex > 0 Then
                            If cmbCentroCosto.SelectedIndex > 0 Then
                                mostrarReporte()
                            Else
                                MsgBox("Seleccione centro de costo", MsgBoxStyle.Exclamation, "Error de ingreso")
                                cmbFinca.Focus()
                            End If
                        Else
                            MsgBox("Seleccione finca", MsgBoxStyle.Exclamation, "Error de ingreso")
                            cmbFinca.Focus()
                        End If
                    Else
                        MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation, "Error de ingreso")
                        cmbBodega.Focus()
                    End If
                Else
                    MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Error de ingreso")
                    cmbProducto.Focus()
                End If
            Else
                MsgBox("Seleccione nivel a mostrar datos", MsgBoxStyle.Exclamation, "Error de ingreso")
                cmbMuestra.Focus()
            End If
        Else
            MsgBox("Fecha final debe ser mayor a fecha inicial", MsgBoxStyle.Exclamation, "Error de ingreso")
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

    Private Sub cmbCentroCosto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbCentroCosto.MouseWheel
        If cmbCentroCosto.DroppedDown Then
            Exit Sub
        Else
            cmbCentroCosto.SelectedIndex = -1
            lblCentroCosto.Focus()
        End If
    End Sub

    Private Sub cmbFinca_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbFinca.MouseWheel
        If cmbFinca.DroppedDown Then
            Exit Sub
        Else
            cmbFinca.SelectedIndex = -1
            lblFinca.Focus()
        End If
    End Sub

    Private Sub cmbMuestra_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbMuestra.MouseWheel
        If cmbMuestra.DroppedDown Then
            Exit Sub
        Else
            cmbMuestra.SelectedIndex = -1
            lblMuestra.Focus()
        End If
    End Sub

    Private Sub cmbProducto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProducto.MouseWheel
        If cmbProducto.DroppedDown Then
            Exit Sub
        Else
            cmbProducto.SelectedIndex = -1
            lblProducto.Focus()
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