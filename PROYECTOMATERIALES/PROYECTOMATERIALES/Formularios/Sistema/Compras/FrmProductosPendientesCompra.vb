Public Class FrmProductosPendientesCompra
#Region "Controles"
    Sub cargarDatos()
        If dgvDatos.Rows.Count > 0 Then
            renderizarGrid()
        End If
        If dtDatos.Rows.Count = 0 Then
            dtDatos = clordenescompra.productosPendientesDeCompra()
        End If
        dgvDatos.DataSource = dtDatos
        dgvDatos.Columns(0).Width = 75
        dgvDatos.Columns(1).Width = 100
        dgvDatos.Columns(2).Width = 100
        dgvDatos.Columns(3).Width = 75
        dgvDatos.Columns(5).Width = 75
    End Sub

    Sub buscarNumero()
        Dim dv As DataView = dtDatos.DefaultView
        If dtDatos.Rows.Count > 0 Then
            dv.RowFilter = "Numero = " & txtNumero.Text & ""
            dgvDatos.Columns(0).Width = 75
            dgvDatos.Columns(1).Width = 100
            dgvDatos.Columns(2).Width = 100
            dgvDatos.Columns(3).Width = 75
            dgvDatos.Columns(5).Width = 75
        End If
    End Sub

    Sub buscarProducto()
        Dim dv As DataView = dtDatos.DefaultView
        'dtDatos.DefaultView.RowFilter = "Descripcion like '%" & txtProducto.Text & "%'"
        dv.RowFilter = "Descripcion like '%" & txtProducto.Text & "%'"
        dgvDatos.DataSource = dv
        dgvDatos.Columns(0).Width = 75
        dgvDatos.Columns(1).Width = 100
        dgvDatos.Columns(2).Width = 100
        dgvDatos.Columns(3).Width = 75
        dgvDatos.Columns(5).Width = 75
    End Sub

    Sub renderizarGrid()
        dgvDatos.Columns(0).Width = 150
        dgvDatos.Columns(1).Width = 150
        dgvDatos.Columns(2).Width = 200
        dgvDatos.Columns(3).Width = 150
        dgvDatos.Columns(5).Width = 150
    End Sub

    Sub confirmarMaestroSolicitud()
        For i As Integer = 0 To dgvDatos.Rows.Count - 1
            If clsolicitudes.consultarDetalleProductosPendientes(dgvDatos.Item(0, i).Value) = 0 Then
                BeginTransaction()
                If clsolicitudes.cambiarEstadoSolicitudMaestro(dgvDatos.Item(0, i).Value, "T") Then
                    CommitTransaction()
                Else
                    RollBackTransaction()
                    'MsgBox("Error confirmando solcitudes pendientes, no se realizaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End If
        Next
    End Sub

    Sub confirmados()
        Dim dv As DataView = dtDatos.DefaultView
        'dtDatos.DefaultView.RowFilter = "Descripcion like '%" & txtProducto.Text & "%'"
        dv.RowFilter = "Finalizar = True"
        dgvDatos.DataSource = dv
        dgvDatos.Columns(0).Width = 75
        dgvDatos.Columns(1).Width = 100
        dgvDatos.Columns(2).Width = 100
        dgvDatos.Columns(3).Width = 75
        dgvDatos.Columns(5).Width = 75
    End Sub

    Function confirmarProductosEnTransito() As Integer
        For i As Integer = 0 To dgvDatos.Rows.Count - 1
            If CBool(dgvDatos.Item(5, i).Value) = True Then
                If clordenescompra.verificarProductoEnTransitoTerminar(dgvDatos.Item(0, i).Value, dgvDatos.Item(3, i).Value) = False Then
                    MsgBox("Producto " & dgvDatos.Item(4, i).Value & " en Solicitud " & dgvDatos.Item(0, i).Value & " tiene orden pendiente de completar", MsgBoxStyle.Exclamation, "Advertencia")
                    confirmados()
                    Return False
                End If
            End If
        Next
        Return True
    End Function
#End Region
    Private clordenescompra As New clOrdenesCompra
    Private clsolicitudes As New clSolicitudMateriales
    Private dtDatos As New DataTable
    Private drDatos As DataRow
    Private Sub FrmProductosPendientesCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        If String.IsNullOrEmpty(txtNumero.Text) Then
            'cargarDatos()
            txtProducto.Text = ""
            buscarProducto()
        Else
            txtProducto.Text = ""
            buscarNumero()
        End If
    End Sub

    Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs) Handles txtProducto.TextChanged
        If String.IsNullOrEmpty(txtProducto.Text) Then
            'cargarDatos()
            buscarProducto()
        Else
            txtNumero.Text = ""
            buscarProducto()
        End If
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        Dim i As Integer = dgvDatos.CurrentRow.Index
        If e.KeyValue = Keys.Space Then
            If dgvDatos.Item(5, i).Value = True Then
                dgvDatos.Item(5, i).Value = False
            Else
                dgvDatos.Item(5, i).Value = True
            End If
        End If
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        For i As Integer = 0 To dgvDatos.Rows.Count - 1
            dgvDatos.Item(5, i).Value = True
        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lblNumero.Focus()
        confirmados()
        If confirmarProductosEnTransito() Then
            BeginTransaction()
            For i As Integer = 0 To dgvDatos.Rows.Count - 1
                If CBool(dgvDatos.Item(5, i).Value) = True Then
                    If clsolicitudes.cambiarEstadoSolicitudDetallePorProducto(dgvDatos.Item(0, i).Value, "T", dgvDatos.Item(3, i).Value) = True Then
                        If clsolicitudes.insertarBitacoraProductosTerminados(dgvDatos.Item(0, i).Value, CDate(dgvDatos.Item(1, i).Value), dgvDatos.Item(3, i).Value) = False Then
                            RollBackTransaction()
                            MsgBox("No se cambiara el estado a los productos seleccionados", MsgBoxStyle.Exclamation, "Advertencia")
                            Exit For
                        End If
                    Else
                        RollBackTransaction()
                        MsgBox("No se cambiara el estado a los productos seleccionados", MsgBoxStyle.Exclamation, "Advertencia")
                        Exit For
                    End If
                End If
            Next
            CommitTransaction()
            confirmarMaestroSolicitud()
            dtDatos = New DataTable()
            cargarDatos()
            MsgBox("Proceso completado con exito", MsgBoxStyle.Information, "Advertencia")
        End If
    End Sub

    Private Sub dgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            dgvDatos.Rows(i).Selected = True
        End If
    End Sub

    Private Sub dgvDatos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellEnter
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            dgvDatos.Rows(i).Selected = True
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            If dgvDatos.Item(5, i).Value = True Then
                dgvDatos.Item(5, i).Value = False
            Else
                dgvDatos.Item(5, i).Value = True
            End If
        End If
    End Sub
End Class