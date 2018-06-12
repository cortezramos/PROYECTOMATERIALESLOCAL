Public Class FrmBusquedaOrdenesCompra
#Region "Controles"
    Sub cargarOrdenesCompra()
        With dgvDatos
            .DataSource = clordenes.consultarOrdenesCompra()
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(4).Width = 75
        End With
    End Sub

    Sub buscarOrdenesCompra()
        With dgvDatos
            .DataSource = clordenes.buscarOrdenesCompra(txtBuscar.Text)
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(4).Width = 75
        End With
    End Sub

    Sub buscarOrdenesPendientes()
        With dgvDatos
            .DataSource = clordenes.buscarOrdenesCompraPendientes()
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(4).Width = 75
        End With
    End Sub

#End Region
    Private clordenes As New clOrdenesCompra

    Private Sub FrmBusquedaOrdenesCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarOrdenesCompra()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            buscarOrdenesCompra()
        Else
            cargarOrdenesCompra()
        End If
    End Sub

    Private Sub chkPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkPendientes.CheckedChanged
        If chkPendientes.Checked = True Then
            buscarOrdenesPendientes()
            txtBuscar.Text = ""
            txtBuscar.Enabled = False
        Else
            cargarOrdenesCompra()
            txtBuscar.Text = ""
            txtBuscar.Enabled = True
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            Dim frm As New FrmOrdenCompra
            With frm
                Dim dtMaestro As DataTable = clordenes.consultaOrdenCompraBuscada(CInt(dgvDatos.Item(0, i).Value))
                Dim dtDetalle As DataTable = clordenes.consultaOrdenDetalleCompraBuscada(CInt(dgvDatos.Item(0, i).Value))
                .txtNumero.Text = dtMaestro.Rows(0)(0).ToString
                .dtFecha.Text = dtMaestro.Rows(0)(1).ToString
                .cargarProveedores(CInt(dtMaestro.Rows(0)(2).ToString))
                .txtAtencion.Text = dtMaestro.Rows(0)(3).ToString
                .txtObservaciones.Text = dtMaestro.Rows(0)(4).ToString
                If dtMaestro.Rows(0)(5).ToString = "G" Then
                    .lblEstatus.Text = "Grabado"
                ElseIf dtMaestro.Rows(0)(5).ToString = "A" Then
                    .lblEstatus.Text = "Aprobado"
                ElseIf dtMaestro.Rows(0)(5).ToString = "T" Then
                    .lblEstatus.Text = "Cerrada"
                ElseIf dtMaestro.Rows(0)(5).ToString = "U" Then
                    .lblEstatus.Text = "Anulada"
                End If
                .cargarDetalle()
                For j As Integer = 0 To dtDetalle.Rows.Count - 1
                    row = dtDetalleOrdenes.NewRow()
                    row.Item("Numero") = dtDetalle.Rows(j)(0).ToString()
                    row.Item("Codigo") = dtDetalle.Rows(j)(1).ToString()
                    row.Item("Descripcion") = dtDetalle.Rows(j)(2).ToString()
                    row.Item("Cantidad Solicitada") = CDec(dtDetalle.Rows(j)(3).ToString())
                    row.Item("Precio Ultima Compra") = CDec(dtDetalle.Rows(j)(4).ToString())
                    row.Item("Cantidad a Comprar") = CDec(dtDetalle.Rows(j)(5).ToString())
                    row.Item("Precio a Pagar") = CDec(dtDetalle.Rows(j)(6).ToString())
                    row.Item("Observaciones") = dtDetalle.Rows(j)(7).ToString()
                    row.Item("Estado") = dtDetalle.Rows(j)(8).ToString()
                    dtDetalleOrdenes.Rows.Add(row)
                Next
                If .dgvDetalle.Rows.Count <= 0 Then
                    .dgvDetalle.Columns.Clear()
                End If
                .cargarMoneda(CInt(dtMaestro.Rows(0)(6).ToString))
                .txtTipoCambio.Text = dtMaestro.Rows(0)(7).ToString
                .Show()
                .ControlBox = False
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
                .gridDetalle()
                .cargarSolicitudesPendientes()
                '.cmbSolicitud.Enabled = True
                .bloqueoGridConsulta()
                .sumarPrecios()
                .desbloquear()
                .btnNuevo.Visible = False
                .btnGuardar.Visible = False
                .btnAnular.Visible = True
                .btnCerrar.Visible = True
                .btnModificar.Visible = True
            End With
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            dgvDatos.Rows(i).Selected = True
        End If
    End Sub
End Class