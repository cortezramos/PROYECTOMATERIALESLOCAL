Imports System.Linq
Public Class FrmBusquedaSalidaBodega
#Region "Controles"
    Sub cargarBusqueda()
        With dgvConsulta
            .DataSource = clsalidas.busquedaSalidasBodega(CDate(dtFechaI.Text), CDate(dtFechaF.Text), vCodigoProducto)
            .Columns(3).Visible = False
        End With
        renderizarGridBusqueda()
    End Sub

    Sub cargarBusquedaNumero()
        With dgvConsulta
            .DataSource = clsalidas.buscarSalidaBodegaPorNumero(CInt(txtBuscar.Text))
            If dgvConsulta.Rows.Count > 0 Then
                .Columns(3).Visible = False
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
            .DataSource = clsalidas.consultarDetalleSalidaBodega(CInt(txtNumero.Text))
        End With
        renderizarGridDetalle()
    End Sub

    Sub seleccionarBusqueda()
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If dgvDetalle.Item(0, i).Value Like vCodigoProducto Then
                dgvDetalle.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
            End If
        Next
    End Sub


    Sub renderizarGridDetalle()
        With dgvDetalle
            .Columns(0).Width = 75
            .Columns(2).Width = 60
            .Columns(3).Width = 75
            .Columns(4).Width = 150
        End With
    End Sub

    Function consultarFechas() As Boolean
        Dim dtDatos As DataTable = clsalidas.consultarFechasSalidaBodega(CInt(txtNumero.Text))
        If dtDatos.Rows.Count > 0 Then
            vFechaSalida = CDate(dtDatos.Rows(0)(0).ToString())
            vFechaServidor = CDate(dtDatos.Rows(0)(1).ToString())
        Else
            vFechaSalida = ""
            vFechaServidor = ""
            Return False
        End If
        Return True
    End Function

    Function validarDatos() As Boolean
        If String.IsNullOrEmpty(txtNumero.Text) Then
            MsgBox("Debe tener seleccionada una salida", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        ElseIf consultarFechas() = False Then
            MsgBox("No es posible consultar fechas", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        ElseIf CDate(vFechaServidor) <> CDate(vFechaSalida) Then
            MsgBox("No se puede anular un documento con fecha anterior ni posterior", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        ElseIf lblEstatus.Visible = True Then
            MsgBox("Ya se encuentra anulada esta salida", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        ElseIf Not clsalidas.verificarExisteDevolucionSalida(CInt(txtNumero.Text)) Then
            MsgBox("Esta salida ya cuenta con una devolucion, no puede ser anulada", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        End If
        Return True
    End Function

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

    Sub mostrarReporte()
        Dim frm As New RptSalidas
        With frm
            .Numero = CInt(txtNumero.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Sub limpiarSeleccion()
        dgvDetalle.DataSource = ""
        txtNumero.Text = ""
        txtDescripcion.Text = ""
        lblEstatus.Visible = False
    End Sub
#End Region

    Private clsalidas As New clSalidaBodega
    Private clsolicitud As New clSolicitudMateriales
    Private dtConsultaDeProducto As New DataTable
    Private vFechaSalida As Date
    Private vFechaServidor As Date
    Private vCodigoProducto As String = ""

    Private Sub FrmBusquedaSalidaBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarBusqueda()
        cargarProductos(Nothing)
    End Sub

    Private Sub dgvConsulta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsulta.CellClick
        If dgvConsulta.Rows.Count > 0 Then
            Dim i As Integer = dgvConsulta.CurrentRow.Index
            txtNumero.Text = dgvConsulta.Item(0, i).Value
            txtDescripcion.Text = dgvConsulta.Item(1, i).Value & " " & dgvConsulta.Item(2, i).Value
            If dgvConsulta.Item(3, i).Value = "A" Then
                lblEstatus.Visible = True
            Else
                lblEstatus.Visible = False
            End If
            dgvConsulta.Rows(i).Selected = True
            cargarDetalle()
            seleccionarBusqueda()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If validarDatos() Then
            If MessageBox.Show("Desea anular la salida Numero: " & txtNumero.Text, "Confirmacion de anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                BeginTransaction()
                If clsalidas.ejecuarPolizaAnulaSalida(CInt(txtNumero.Text)) Then
                    If clsalidas.actualizarExistenciaAnulacionSalida(CInt(txtNumero.Text)) Then
                        If clsalidas.anularEnvioYMovimientoMaestro(CInt(txtNumero.Text)) Then
                            If clsalidas.anularEnvioYMovimientoDetalle(CInt(txtNumero.Text)) Then
                                CommitTransaction()
                                MsgBox("Documento anulado correctamente", MsgBoxStyle.Information, "Aviso")
                                txtNumero.Text = ""
                                txtDescripcion.Text = ""
                                lblEstatus.Visible = False
                                dgvDetalle.DataSource = ""
                                cargarBusqueda()
                                cargarProductos(Nothing)
                            Else
                                RollBackTransaction()
                                MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
                            End If
                        Else
                            RollBackTransaction()
                            MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
                        End If
                    Else
                        RollBackTransaction()
                        MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
                    End If
                Else
                    RollBackTransaction()
                    MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If String.IsNullOrEmpty(txtNumero.Text) Then
            MsgBox("Debe tener seleccionada una salida", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            mostrarReporte()
        End If
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            limpiarSeleccion()
            txtNumero.Text = ""
            txtDescripcion.Text = ""
            dgvDetalle.DataSource = ""
            lblEstatus.Visible = False
            cargarBusquedaNumero()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyValue = Keys.Enter Then
            limpiarSeleccion()
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                txtNumero.Text = ""
                txtDescripcion.Text = ""
                dgvDetalle.DataSource = ""
                lblEstatus.Visible = False
                cargarBusquedaNumero()
            End If
        End If
    End Sub
End Class