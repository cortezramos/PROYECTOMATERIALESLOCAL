Public Class FrmConsultarProductos
#Region "Controles"
    Sub consultarProductos()
        dgvDatos.DataSource = clproductos.consultarTodosProductos(estado)
        dgvDatos.Columns(0).Width = 100
    End Sub

    Sub buscarProductos()
        dgvDatos.DataSource = clproductos.consultarProductosEstadoYNombre(txtBuscar.Text, estado)
        dgvDatos.Columns(0).Width = 100
    End Sub

    Sub buscarProductosYTipo()
        dgvDatos.DataSource = clproductos.consultarProductosEstadoYNombreYTipo(txtBuscar.Text, estado, CInt(cmbTipoInventario.SelectedValue))
        dgvDatos.Columns(0).Width = 100
    End Sub

    Sub buscarProductosPorTipo()
        dgvDatos.DataSource = clproductos.consultarProductosPorTipoInventario(estado, CInt(cmbTipoInventario.SelectedValue))
        dgvDatos.Columns(0).Width = 100
    End Sub

    Sub cargarTipoInventario()
        With cmbTipoInventario
            .DataSource = clproductos.consultarTipoInventario()
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
        End With
    End Sub
#End Region
    Private clproductos As New clProductos
    Private estado As String = "Activo"
    Private Sub FrmConsultarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarProductos()
        cargarTipoInventario()
        chkActivos.Checked = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkActivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivos.CheckedChanged
        If chkActivos.Checked = True Then
            estado = "Activo"
            chkInactivos.Checked = False
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosYTipo()
                Else
                    buscarProductos()
                End If
            Else
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosPorTipo()
                Else
                    consultarProductos()
                End If
            End If
        Else
            estado = "Inactivo"
            chkInactivos.Checked = True
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosYTipo()
                Else
                    buscarProductos()
                End If
            Else
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosPorTipo()
                Else
                    consultarProductos()
                End If
            End If
        End If
    End Sub

    Private Sub chkInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkInactivos.CheckedChanged
        If chkInactivos.Checked = True Then
            estado = "Inactivo"
            chkActivos.Checked = False
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosYTipo()
                Else
                    buscarProductos()
                End If
            Else
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosPorTipo()
                Else
                    consultarProductos()
                End If
            End If
        Else
            estado = "Activo"
            chkActivos.Checked = True
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosYTipo()
                Else
                    buscarProductos()
                End If
            Else
                If cmbTipoInventario.SelectedValue > 0 Then
                    buscarProductosPorTipo()
                Else
                    consultarProductos()
                End If
            End If
        End If
    End Sub

    Private Sub cmbTipoInventario_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbTipoInventario.MouseWheel
        If cmbTipoInventario.DroppedDown Then
            Exit Sub
        Else
            cmbTipoInventario.SelectedIndex = -1
            lblTipoInventario.Focus()
        End If
    End Sub

    Private Sub cmbTipoInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoInventario.SelectedIndexChanged
        If cmbTipoInventario.SelectedIndex > 0 Then
            If String.IsNullOrEmpty(txtBuscar.Text) = False Then
                buscarProductosYTipo()
            Else
                buscarProductosPorTipo()
            End If
        Else
            consultarProductos()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            If cmbTipoInventario.SelectedValue > 0 Then
                buscarProductosYTipo()
            Else
                buscarProductos()
            End If
        Else
            If cmbTipoInventario.SelectedValue > 0 Then
                buscarProductosPorTipo()
            Else
                consultarProductos()
            End If
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim j As Integer = dgvDatos.CurrentRow.Index
            Dim dtDatos As DataTable = clproductos.consultarYSeleccionarProducto(dgvDatos.Item(0, j).Value)
            Dim frm As New FrmProductos
            With frm
                .txtCodigo.Text = dtDatos.Rows(0)(0).ToString()
                .txtEstado.Text = dtDatos.Rows(0)(1).ToString()
                .cargarTipoInventario(CInt(dtDatos.Rows(0)(2).ToString()))
                .txtDescripcion.Text = dtDatos.Rows(0)(3).ToString()
                .txtMinimo.Text = dtDatos.Rows(0)(4).ToString()
                .txtMaximo.Text = dtDatos.Rows(0)(5).ToString()
                If dtDatos.Rows(0)(6).ToString() = "True" Then
                    .chkAfectaExistencia.Checked = True
                Else
                    .chkAfectaExistencia.Checked = False
                End If
                .txtObservaciones.Text = dtDatos.Rows(0)(7).ToString()
                .cargarMoneda(dtDatos.Rows(0)(8).ToString())
                If dtDatos.Rows(0)(9).ToString() = "True" Then
                    .chkMaterialVenta.Checked = True
                Else
                    .chkMaterialVenta.Checked = False
                End If
                .cargarMedida(dtDatos.Rows(0)(10).ToString())
                .vMedidaDefault = CInt(dtDatos.Rows(0)(10).ToString())
                .txtPrecio.Text = dtDatos.Rows(0)(11).ToString()
                .vPrecioDefault = CDec(dtDatos.Rows(0)(11).ToString())
                .btnEditar.Visible = True
                .btnEliminar.Visible = True
                .btnAlta.Visible = True
                .btnNuevo.Visible = False
                .btnGuardar.Visible = False
                .Show()
                .ControlBox = False
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvDatos.Rows.Count > 0 Then
            btnExportar.Enabled = False
            Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
            Dim libro As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
            Dim hoja As Microsoft.Office.Interop.Excel._Worksheet = Nothing
            hoja = libro.Sheets("Hoja1")
            hoja = libro.ActiveSheet

            For i As Integer = 1 To dgvDatos.Columns.Count
                hoja.Cells(1, i) = dgvDatos.Columns(i - 1).HeaderText
            Next

            For i As Integer = 0 To dgvDatos.Rows.Count - 1
                For j As Integer = 0 To dgvDatos.Columns.Count - 1
                    hoja.Cells(i + 2, j + 1) = dgvDatos.Rows(i).Cells(j).Value.ToString()
                Next
            Next

            hoja.Rows.Item(1).Font.Bold = 1
            hoja.Rows.Item(1).HorizontalAlignment = 3
            hoja.Columns.HorizontalAlignment = 2

            app.Visible = True
            app = Nothing
            libro = Nothing
            hoja = Nothing
            FileClose(1)
            GC.Collect()
            btnExportar.Enabled = True
        Else
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub
End Class