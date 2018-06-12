Public Class FrmAprobarCompras
#Region "Controles"
    Sub cargarOrdenes()
        Dim dtOrdenes As DataTable = clordenes.consultarOrdenesCompraPendientesAprobar()
        For i As Integer = 0 To dtOrdenes.Rows.Count - 1
            dgvOrdenes.Rows.Add(dtOrdenes.Rows(i)(0).ToString(), dtOrdenes.Rows(i)(1).ToString(), dtOrdenes.Rows(i)(2).ToString())
        Next
        dgvOrdenes.Columns(0).Width = 70
        dgvOrdenes.Columns(1).Width = 100
    End Sub

    Sub cargarAprobadas()
        With dgvAprobadas
            .Columns(0).Width = 70
            .Columns(1).Width = 100
        End With
    End Sub

    Function compbrobarDerecha() As Boolean
        For i = 0 To dgvAprobadas.Rows.Count - 1
            If dgvAprobadas.Item(0, i).Value = vNumero Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function

    Function compbrobarIzquierda() As Boolean
        For i = 0 To dgvOrdenes.Rows.Count - 1
            If dgvOrdenes.Item(0, i).Value = vNumero Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function

    Sub cargarDetalle()
        Dim dtDetalle As DataTable = clordenes.consultarDetalleOrdenesCompraPendientesAprobar(vNumero)
        Dim suma As Decimal = 0
        Dim mult As Decimal = 0
        dgvDetalle.Rows.Clear()
        For i As Integer = 0 To dtDetalle.Rows.Count - 1
            dgvDetalle.Rows.Add(dtDetalle.Rows(i)(0).ToString(), dtDetalle.Rows(i)(1).ToString(), dtDetalle.Rows(i)(2).ToString(), dtDetalle.Rows(i)(3).ToString(), dtDetalle.Rows(i)(4).ToString(), dtDetalle.Rows(i)(5).ToString(), dtDetalle.Rows(i)(6).ToString())
            mult = CDec(dtDetalle.Rows(i)(3).ToString()) * CDec(dtDetalle.Rows(i)(5).ToString())
            suma += mult
        Next
        txtTotal.Text = suma
        renderizarDetalle()
    End Sub

    Sub renderizarDetallePositivo()
        dgvDetalle.Columns(0).Width = 50 + 100
        dgvDetalle.Columns(2).Width = 100 + 200
        dgvDetalle.Columns(3).Width = 75 + 150
        dgvDetalle.Columns(4).Width = 75 + 150
        dgvDetalle.Columns(5).Width = 75 + 150
        dgvDetalle.Columns(6).Width = 75 + 150
    End Sub

    Sub renderizarDetalle()
        dgvDetalle.Columns(0).Width = 50
        dgvDetalle.Columns(2).Width = 100
        dgvDetalle.Columns(3).Width = 75
        dgvDetalle.Columns(4).Width = 75
        dgvDetalle.Columns(5).Width = 75
        dgvDetalle.Columns(6).Width = 75
        dgvDetalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Function aprobarOrdenes() As Boolean
        For i As Integer = 0 To dgvAprobadas.Rows.Count - 1
            If clordenes.aprobarOrdenesDeCompra(CInt(dgvAprobadas.Item(0, i).Value)) = False Then
                Return False
            End If
        Next
        Return True
    End Function
#End Region
    Private clordenes As New clOrdenesCompra
    Private vNumero As Integer
    Private vSolicitante As String
    Private vObservaciones As String
    Private vBodega As Integer
    Private vFechaI As Date
    Private Sub FrmAprobarCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarOrdenes()
        cargarAprobadas()
        renderizarDetalle()
    End Sub

    Private Sub btnDerecha_Click(sender As Object, e As EventArgs) Handles btnDerecha.Click
        If vNumero > 0 Then
            If String.IsNullOrEmpty(vSolicitante) = False Then
                If compbrobarDerecha() Then
                    dgvAprobadas.Rows.Add(vNumero, vSolicitante, vObservaciones)
                    dgvOrdenes.Rows.Remove(dgvOrdenes.CurrentRow)
                    dgvDetalle.Rows.Clear()
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                Else
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                End If
            Else
                MsgBox("Seleccione orden de compra", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione orden de compra", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnIzquierda_Click(sender As Object, e As EventArgs) Handles btnIzquierda.Click
        If vNumero > 0 Then
            If String.IsNullOrEmpty(vSolicitante) = False Then
                If compbrobarIzquierda() Then
                    dgvOrdenes.Rows.Add(vNumero, vSolicitante, vObservaciones)
                    dgvAprobadas.Rows.Remove(dgvAprobadas.CurrentRow)
                    dgvDetalle.Rows.Clear()
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                Else
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                End If
            Else
                MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnDerechaTodo_Click(sender As Object, e As EventArgs) Handles btnDerechaTodo.Click
        If dgvOrdenes.Rows.Count > 0 Then
            For i As Integer = 0 To dgvOrdenes.Rows.Count - 1
                dgvAprobadas.Rows.Add(dgvOrdenes.Item(0, i).Value, dgvOrdenes.Item(1, i).Value, dgvOrdenes.Item(2, i).Value)
            Next
            dgvOrdenes.Rows.Clear()
            dgvDetalle.Rows.Clear()
        Else
            MsgBox("No existen ordenes para trasladar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnIzquierdaTodo_Click(sender As Object, e As EventArgs) Handles btnIzquierdaTodo.Click
        If dgvAprobadas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAprobadas.Rows.Count - 1
                dgvOrdenes.Rows.Add(dgvAprobadas.Item(0, i).Value, dgvAprobadas.Item(1, i).Value, dgvAprobadas.Item(2, i).Value)
            Next
            dgvAprobadas.Rows.Clear()
            dgvDetalle.Rows.Clear()
        Else
            MsgBox("No existen ordenes para trasladar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvAprobadas.Rows.Count > 0 Then
            BeginTransaction()
            If aprobarOrdenes() Then
                CommitTransaction()
                dgvOrdenes.Rows.Clear()
                dgvAprobadas.Rows.Clear()
                dgvDetalle.Rows.Clear()
                cargarOrdenes()
                cargarAprobadas()
                renderizarDetalle()
                MsgBox("Ordenes de compra aprobadas", MsgBoxStyle.Information)
            Else
                RollBackTransaction()
                MsgBox("Ocurrio un error no se pudieron aprobar las ordenes seleccionadas", MsgBoxStyle.Exclamation, "Error de sistema")
            End If
        Else
            MsgBox("No existen ordenes para aprobar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub dgvOrdenes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrdenes.CellClick
        If dgvOrdenes.Rows.Count > 0 Then
            Dim i As Integer = dgvOrdenes.CurrentRow.Index
            dgvOrdenes.Rows(i).Selected = True
            vNumero = CInt(dgvOrdenes.Item(0, i).Value)
            vSolicitante = dgvOrdenes.Item(1, i).Value
            vObservaciones = dgvOrdenes.Item(2, i).Value
            cargarDetalle()
        End If
    End Sub

    Private Sub dgvAprobadas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAprobadas.CellClick
        If dgvAprobadas.Rows.Count > 0 Then
            renderizarDetallePositivo()
            Dim i As Integer = dgvAprobadas.CurrentRow.Index
            dgvAprobadas.Rows(i).Selected = True
            vNumero = CInt(dgvAprobadas.Item(0, i).Value)
            vSolicitante = dgvAprobadas.Item(1, i).Value
            vObservaciones = dgvAprobadas.Item(2, i).Value
            cargarDetalle()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvAprobadas.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos sin aprobar, Desea salir?", "Desea salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            vBodega = 0
            vFechaI = Today
            lblAprobadas.Focus()
            Dim frm As New FrmBusquedaBodega
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    vBodega = .Bodega
                    vFechaI = .Fechai
                Else
                    MsgBox("No se mostrara kardex solicitado", MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If
            End With
            If vBodega > 0 Then
                Dim frmK As New RptKardexCompra
                With frmK
                    .Bodega = vBodega
                    .FechaI = vFechaI
                    .Producto = dgvDetalle.Item(0, i).Value
                    .WindowState = FormWindowState.Maximized
                    .Text = "Kardex Producto: " & dgvDetalle.Item(1, i).Value & " Codigo: " & dgvDetalle.Item(0, i).Value
                    .Show()
                End With
            Else
                MsgBox("No se ha seleccionado una bodega", MsgBoxStyle.Exclamation, "Error de ingreso de datos")
            End If
        End If
    End Sub

    Private Sub dgvAprobadas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAprobadas.CellDoubleClick
        If dgvAprobadas.Rows.Count > 0 Then
            Dim i As Integer = dgvAprobadas.CurrentRow.Index
            Dim frm As New RptOrdenCompra
            With frm
                .Numero = CInt(dgvAprobadas.Item(0, i).Value)
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        End If
    End Sub
End Class