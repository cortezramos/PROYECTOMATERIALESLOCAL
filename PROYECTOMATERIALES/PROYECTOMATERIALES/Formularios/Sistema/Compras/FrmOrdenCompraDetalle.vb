Public Class FrmOrdenCompraDetalle
#Region "Controles"
    Sub cargarDetalle()
        If dgvDatos.Rows.Count > 0 Then
            renderizarGrid()
        End If
        If dtDatos.Rows.Count = 0 Then
            dtDatos = clordenescompra.consultarDetalleProductosDeSolicitud(numeroSolicitud)
        End If
        With dgvDatos
            .DataSource = dtDatos
            .Columns(0).Visible = False
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(1).Width = 60
            .Columns(3).Width = 75
            .Columns(4).Width = 75
            .Columns(5).Width = 60
            .Columns(6).Width = 60
            .Columns(7).Width = 75
        End With
        'MsgBox("No existen datos para esta orden de compra", MsgBoxStyle.Exclamation, "Advertencia")
        'DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Sub buscarDetalle()
        Dim dv As DataView = dtDatos.DefaultView
        If dtDatos.Rows.Count > 0 Then
            dv.RowFilter = "Descripcion like '%" & txtBuscar.Text & "%'"
            dgvDatos.DataSource = dv
        End If
    End Sub

    Sub renderizarGrid()
        With dgvDatos
            .Columns(1).Width = .Columns(1).Width + 120
            .Columns(3).Width = .Columns(3).Width + 150
            .Columns(4).Width = .Columns(4).Width + 150
            .Columns(5).Width = .Columns(5).Width + 120
            .Columns(6).Width = .Columns(6).Width + 120
            .Columns(7).Width = .Columns(7).Width + 75
        End With
    End Sub

    Private Sub ValidarEnteros(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function camposVacios() As Boolean
        For i As Integer = 0 To dgvDatos.Rows.Count - 1
            If IsDBNull(dgvDatos.Item(5, i).Value) Then
                MsgBox("Campo cantidad en el detalle se encuentran vacio, favor ingresar una cantidad", MsgBoxStyle.Exclamation, "Advertencia")
                dgvDatos.Rows(i).Selected = True
                Return False
            ElseIf IsDBNull(dgvDatos.Item(6, i).Value) Then
                MsgBox("Campo precio en el detalle se encuentran vacio, favor ingresar un precio", MsgBoxStyle.Exclamation, "Advertencia")
                dgvDatos.Rows(i).Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Function validarExisteProductoDT(Numero As Integer, Producto As String) As Boolean
        For a As Integer = 0 To dtDetalleOrdenes.Rows.Count - 1
            If CInt(dtDetalleOrdenes.Rows(a)(0).ToString()) = Numero And dtDetalleOrdenes.Rows(a)(1).ToString() = Producto Then
                MsgBox("Producto " & Producto & " de esta solicitud ya fue asignado", MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            End If
        Next
        Return True
    End Function
#End Region
    Private clordenescompra As New clOrdenesCompra
    Private valorseleccionado As Integer
    Private dtDatos As New DataTable
    Private Sub FrmOrdenCompraDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub dgvDatos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvDatos.EditingControlShowing
        RemoveHandler e.Control.KeyPress, AddressOf ValidarEnteros
        AddHandler e.Control.KeyPress, AddressOf ValidarEnteros
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        txtBuscar.Text = ""
        txtBuscar.Focus()
        dtDatos = New DataTable
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        If camposVacios() Then
            gbxGeneral.Focus()
            txtBuscar.Text = ""
            For i As Integer = 0 To dgvDatos.Rows.Count - 1
                If CBool(dgvDatos.Item(7, i).Value) = True Then
                    If dtDetalleOrdenes.Rows.Count <= 30 Then
                        If validarExisteProductoDT(CInt(dgvDatos.Item(0, i).Value), dgvDatos.Item(1, i).Value) Then
                            row = dtDetalleOrdenes.NewRow()
                            row.Item("Numero") = dgvDatos.Item(0, i).Value
                            row.Item("Codigo") = dgvDatos.Item(1, i).Value
                            row.Item("Descripcion") = dgvDatos.Item(2, i).Value
                            row.Item("Cantidad Solicitada") = CDec(dgvDatos.Item(3, i).Value)
                            row.Item("Precio Ultima Compra") = CDec(dgvDatos.Item(4, i).Value)
                            row.Item("Cantidad a Comprar") = CDec(dgvDatos.Item(5, i).Value)
                            row.Item("Precio a Pagar") = CDec(dgvDatos.Item(6, i).Value)
                            row.Item("Observaciones") = "."
                            row.Item("Estado") = "T"
                            dtDetalleOrdenes.Rows.Add(row)
                        End If
                    Else
                        MsgBox("Solo puede agregar 30 items a orden de compra", MsgBoxStyle.Exclamation, "Advertencia")
                        Exit For
                        Exit Sub
                    End If
                End If
            Next
            If dtDetalleOrdenes.Rows.Count > 0 Then
                renderizarGrid()
                dtDatos = New DataTable
                txtBuscar.Focus()
                DialogResult = Windows.Forms.DialogResult.Yes
            Else
                renderizarGrid()
                dtDatos = New DataTable
                txtBuscar.Focus()
                DialogResult = Windows.Forms.DialogResult.No
            End If
        End If
    End Sub

    Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
        For i As Integer = 0 To dgvDatos.Rows.Count - 1
            dgvDatos.Item(7, i).Value = True
        Next
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

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        If e.RowIndex = -1 Then
            Return
        End If
        If dgvDatos.Columns(e.ColumnIndex).Name = "Agregar" Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            If e.ColumnIndex = Me.dgvDatos.Columns.Item("Agregar").Index Then
                Dim chk As DataGridViewCheckBoxCell = Me.dgvDatos.Rows(e.RowIndex).Cells("Agregar")
                chk.Value = Not chk.Value
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyValue = Keys.Space Then
            Dim a As Integer = dgvDatos.CurrentRow.Index
            If dgvDatos.Item(7, a).Value = True Then
                dgvDatos.Item(7, a).Value = False
            Else
                dgvDatos.Item(7, a).Value = True
            End If
        End If
        If e.KeyValue = Keys.F2 Then
            If camposVacios() Then
                gbxGeneral.Focus()
                txtBuscar.Text = ""
                For i As Integer = 0 To dgvDatos.Rows.Count - 1
                    If CBool(dgvDatos.Item(7, i).Value) = True Then
                        If dtDetalleOrdenes.Rows.Count <= 30 Then
                            If validarExisteProductoDT(CInt(dgvDatos.Item(0, i).Value), dgvDatos.Item(1, i).Value) Then
                                row = dtDetalleOrdenes.NewRow()
                                row.Item("Numero") = dgvDatos.Item(0, i).Value
                                row.Item("Codigo") = dgvDatos.Item(1, i).Value
                                row.Item("Descripcion") = dgvDatos.Item(2, i).Value
                                row.Item("Cantidad Solicitada") = CDec(dgvDatos.Item(3, i).Value)
                                row.Item("Precio Ultima Compra") = CDec(dgvDatos.Item(4, i).Value)
                                row.Item("Cantidad a Comprar") = CDec(dgvDatos.Item(5, i).Value)
                                row.Item("Precio a Pagar") = CDec(dgvDatos.Item(6, i).Value)
                                row.Item("Observaciones") = "."
                                row.Item("Estado") = "T"
                                dtDetalleOrdenes.Rows.Add(row)
                            End If
                        Else
                            MsgBox("Solo puede agregar 30 items a orden de compra", MsgBoxStyle.Exclamation, "Advertencia")
                            Exit For
                            Exit Sub
                        End If
                    End If
                Next
                If dtDetalleOrdenes.Rows.Count > 0 Then
                    renderizarGrid()
                    txtBuscar.Focus()
                    dtDatos = New DataTable
                    DialogResult = Windows.Forms.DialogResult.Yes
                Else
                    renderizarGrid()
                    txtBuscar.Focus()
                    dtDatos = New DataTable
                    DialogResult = Windows.Forms.DialogResult.No
                End If
            End If
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text <> "" Then
            buscarDetalle()
        Else
            txtBuscar.Text = ""
            buscarDetalle()
        End If
    End Sub
End Class