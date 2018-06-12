Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptKardex
#Region "Controles"
    Sub cargarBodegas()
        With cmbBodega
            .DataSource = clordenes.seleccionBodegaConsultaKardex()
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Public Sub cargarProductos(Valor As String)
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = clsolicitud.consultaProductos()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = clsolicitud.consultaProductos()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Sub cargarProductosFiltrados()
        With cmbProducto
            .DataSource = clsolicitud.consultaProductosFiltrados(txtFiltro.Text)
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub
#End Region

    Private clordenes As New clOrdenesCompra
    Private clsolicitud As New clSolicitudMateriales
    Private Sub RptKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarBodegas()
        cargarProductos(Nothing)
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 175
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

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        If String.IsNullOrEmpty(txtFiltro.Text) = False Then
            cargarProductosFiltrados()
        Else
            cargarProductos(Nothing)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        lblBodega.Focus()
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbProducto.SelectedValue > 0 Then
                If cmbBodega.SelectedValue > 0 Then
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
                    parametros.Add(New ReportParameter("fechai", CDate(dtFechaI.Text)))
                    parametros.Add(New ReportParameter("fechaf", CDate(dtFechaF.Text)))
                    parametros.Add(New ReportParameter("producto", CStr(cmbProducto.SelectedValue)))
                    parametros.Add(New ReportParameter("bodega", CInt(cmbBodega.SelectedValue)))
                    parametros.Add(New ReportParameter("medida", "0"))

                    rpt.ServerReport.SetParameters(parametros)
                    rpt.RefreshReport()
                Else
                    MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation, "Error de operacion")
                    cmbBodega.Focus()
                End If
            Else
                MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Error de operacion")
                cmbProducto.Focus()
            End If
        Else
            MsgBox("Fecha final no puede ser menor a fecha inicial", MsgBoxStyle.Exclamation, "Error de operacion")
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