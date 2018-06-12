Public Class FrmBusquedaIngresoBodega
#Region "Controles"

    Sub cargarProductos(Valor As String)
        If dtConsultaDeProducto.Rows.Count = 0 Then
            dtConsultaDeProducto = clsolicitud.consultaProductos()
        End If
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = dtConsultaDeProducto
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = dtConsultaDeProducto
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub

    Sub cargarBusqueda()
        With dgvConsulta
            .DataSource = clingresos.consultarIngresoMaestroBodega(CDate(dtFechaI.Text), CDate(dtFechaF.Text), vCodigoProducto)
            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With
        renderizarGridBusqueda()
    End Sub

    Sub cargarBusquedaNumero()
        With dgvConsulta
            .DataSource = clingresos.consultarIngresoMaestroPorNumero(CInt(txtBuscar.Text))
            If dgvConsulta.Rows.Count > 0 Then
                .Columns(3).Visible = False
                .Columns(4).Visible = False
            Else
                MsgBox("No existen datos para su consulta", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End With
        renderizarGridBusqueda()
    End Sub

    Sub renderizarGridBusqueda()
        With dgvConsulta
            .Columns(0).Width = 65
            .Columns(1).Width = 85
        End With
    End Sub

    Sub cargarDetalle()
        With dgvDetalle
            .DataSource = clingresos.consultarIngresoDetalleBodega(CInt(txtNumero.Text), Ingreso)
        End With
        renderizarGridDetalle()
    End Sub

    Sub renderizarGridDetalle()
        With dgvDetalle
            .Columns(0).Width = 50
            .Columns(1).Width = 75
            .Columns(3).Width = 75
            .Columns(4).Width = 100
        End With
    End Sub

    Sub seleccionarBusqueda()
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If dgvDetalle.Item(1, i).Value Like vCodigoProducto Then
                dgvDetalle.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
            End If
        Next
    End Sub

    Sub mostrarReporte()
        Dim frm As New RptIngreso
        With frm
            .Numero = CInt(txtNumero.Text)
            .Ingreso = Me.Ingreso
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Sub limpiarSeleccion()
        txtNumero.Text = ""
        txtDescripcion.Text = ""
        lblEstatus.Visible = False
        dgvDetalle.DataSource = ""
    End Sub

#End Region

    Private clingresos As New clIngresoBodega
    Private clsolicitud As New clSolicitudMateriales
    Private dtConsultaDeProducto As New DataTable
    Private vCodigoProducto As String = ""
    Private Ingreso As Integer

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                txtNumero.Text = ""
                txtDescripcion.Text = ""
                dgvDetalle.DataSource = ""
                cargarBusquedaNumero()
            Else
                MsgBox("Ingrese numero de orden", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            limpiarSeleccion()
            txtNumero.Text = ""
            txtDescripcion.Text = ""
            dgvDetalle.DataSource = ""
            cargarBusquedaNumero()
        Else
            limpiarSeleccion()
            MsgBox("Ingrese numero de orden", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) Then
            limpiarSeleccion()
            dtFechaI.Enabled = True
            dtFechaF.Enabled = True
            cmbProducto.Enabled = True
            cargarBusqueda()
        Else
            limpiarSeleccion()
            cargarProductos(Nothing)
            dtFechaI.Enabled = False
            dtFechaF.Enabled = False
            cmbProducto.Enabled = False
        End If
    End Sub

    Private Sub dtFechaI_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaI.ValueChanged
        limpiarSeleccion()
        cargarBusqueda()
    End Sub

    Private Sub dtFechaF_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaF.ValueChanged
        limpiarSeleccion()
        cargarBusqueda()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If String.IsNullOrEmpty(txtNumero.Text) Then
            MsgBox("Debe tener seleccionada un orden", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            mostrarReporte()
        End If
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyValue = Keys.F7 Then
            limpiarSeleccion()
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

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cmbProducto.SelectedIndex > 0 Then
            limpiarSeleccion()
            vCodigoProducto = cmbProducto.SelectedValue
            cargarBusqueda()
        Else
            limpiarSeleccion()
            vCodigoProducto = ""
            cargarBusqueda()
        End If
    End Sub

    Private Sub FrmBusquedaIngresoBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarProductos(Nothing)
    End Sub

    Private Sub dgvConsulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        If dgvConsulta.Rows.Count > 0 Then
            Dim i As Integer = dgvConsulta.CurrentRow.Index
            txtNumero.Text = dgvConsulta.Item(0, i).Value
            txtDescripcion.Text = dgvConsulta.Item(1, i).Value & " " & dgvConsulta.Item(2, i).Value
            Ingreso = CInt(dgvConsulta.Item(4, i).Value)
            dgvConsulta.Rows(i).Selected = True
            cargarDetalle()
            seleccionarBusqueda()
        End If
    End Sub
End Class