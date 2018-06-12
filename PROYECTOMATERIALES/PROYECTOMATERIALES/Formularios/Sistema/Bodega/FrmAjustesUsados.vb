Public Class FrmAjustesUsados
#Region "Controles"

    Sub bloquear()
        cmbBodega.Enabled = False
        txtObservaciones.Enabled = False
        cmbProducto.Enabled = False
        txtCantidad.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Sub desbloquear()
        cmbBodega.Enabled = True
        txtObservaciones.Enabled = True
        cmbProducto.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Sub cargarBodega(Valor As Integer)
        If Valor <> Nothing Then
            With cmbBodega
                .DataSource = clordenes.seleccionBodegaConsultaKardex()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbBodega
                .DataSource = clordenes.seleccionBodegaConsultaKardex()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Sub cargarProductos(Valor As String)
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = cProductos.busquedaProductosPantallaBusqueda()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = cProductos.busquedaProductosPantallaBusqueda()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub
    
    Function validarEncabezado() As Boolean
        If cmbBodega.SelectedValue = 0 Then
            MsgBox("Seleccion bodega de ajuste", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtObservaciones.Text) Then
            MsgBox("Ingrese observaciones", MsgBoxStyle.Exclamation, "Advertencia")
            txtObservaciones.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarDetalle() As Boolean
        If cmbProducto.SelectedValue = 0 Then
            MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Aviso")
            cmbProducto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtCantidad.Text) Then
            MsgBox("Ingrese cantidad a ajustar", MsgBoxStyle.Exclamation, "Aviso")
            txtCantidad.Focus()
            Return False
        ElseIf CDec(txtCantidad.Text) <= 0 Then
            MsgBox("Cantidad debe ser mayor a cero", MsgBoxStyle.Exclamation, "Aviso")
            txtCantidad.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarExisteProducto() As Boolean
        Dim existe As Integer = 0
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If cmbProducto.SelectedValue = dgvDetalle.Item(0, i).Value Then
                    existe += 1
                End If
            Next
            If existe > 0 Then
                MsgBox("Este producto ya fue agregado a el ajuste", MsgBoxStyle.Exclamation, "Aviso")
                Return False
            End If
        End If
        Return True
    End Function

    Sub obtenerInfoProducto()
        Dim dtDato As DataTable = clsalidas.consultarDatosProducto(cmbProducto.SelectedValue, CInt(cmbBodega.SelectedValue))
        If dtDato.Rows.Count > 0 Then
            vNombreProducto = dtDato.Rows(0)(0).ToString()
            vMedidaProducto = dtDato.Rows(0)(2).ToString()
        Else
            vNombreProducto = "N/A"
            vMedidaProducto = "N/A"
        End If
    End Sub

    Sub bloquearEncabezado()
        cmbBodega.Enabled = False
        txtObservaciones.Enabled = False
    End Sub

    Sub obtenerNumero()
        txtNumero.Text = cAjustes.consultarNumeroPorTipo(vTipoAjuste)
    End Sub

    Function revalidarExistencia() As Boolean
        Dim Existencia As Decimal = 0
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            Existencia = clsalidas.consultarExistenciaProductoPorBodega(dgvDetalle.Item(0, i).Value, CInt(cmbBodega.SelectedValue))
            If Existencia - CDec(dgvDetalle.Item(2, i).Value) < 0 Then
                Me.Hide()
                MsgBox("Producto " & dgvDetalle.Item(0, i).Value & " " & dgvDetalle.Item(1, i).Value & " Solamente tiene existencia de " & Existencia, MsgBoxStyle.Exclamation, "Advertencia")
                dgvDetalle.Rows(i).Selected = True
                Me.Show()
                Return False
            End If
        Next
        Return True
    End Function

    Function guardarMaestro() As Boolean
        If cAjustes.insertarMovimientoMaestro(CInt(txtNumero.Text), vTipoAjuste, CDate(dtFecha.Text), CInt(cmbBodega.SelectedValue), txtObservaciones.Text) Then
            Return True
        End If
        Return False
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If cAjustes.insertarMovimientoDetalle(CInt(txtNumero.Text), dgvDetalle.Item(0, i).Value, vTipoAjuste, dgvDetalle.Item(1, i).Value, CDec(dgvDetalle.Item(2, i).Value), CInt(cmbBodega.SelectedValue)) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub renderizarGrid()
        With dgvDetalle
            .Columns(0).Width = 60
            .Columns(2).Width = 60
            .Columns(3).Width = 100
        End With
    End Sub

    Sub mostrarReporte()
        Dim frm As New RptAjustes
        With frm
            .Numero = CInt(txtNumero.Text)
            .Tipo = vTipoAjuste
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

    Private cAjustes As New clAjustes
    Private cProductos As New clProductos
    Private clordenes As New clOrdenesCompra
    Private clsolicitud As New clSolicitudMateriales
    Private clsalidas As New clSalidaBodega
    Private clcentro As New clCentroCosto
    Private clcuentas As New clCuentaContable
    Private dtConsultaDeProducto As New DataTable
    Private dtConsultaDeCentro As New DataTable
    Private dtConsultaCuentas As New DataTable
    Private vNombreProducto As String
    Private vSaldoProducto As Decimal
    Private vMedidaProducto As String
    Private vCentroCosto As String
    Private vDescripcionCentro As String
    Private vCuentaContable As String
    Private vDescripcionCuenta As String
    Private vTipoAjuste As Integer = 4

    Private Sub FrmAjustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
        renderizarGrid()
        cargarBodega(Nothing)
        cargarProductos(Nothing)
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

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtCantidad.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cmbProducto.SelectedIndex > 0 Then
            If cmbProducto.SelectedValue <> "0" Then
                If validarEncabezado() Then
                    bloquearEncabezado()
                    obtenerInfoProducto()
                Else
                    cargarProductos(Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir sin guardar", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnLimpiar_Click(sender, e)
        obtenerNumero()
        desbloquear()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If validarDetalle() Then
            If vNombreProducto <> "N/A" Then
                If validarExisteProducto() Then
                    dgvDetalle.Rows.Add(cmbProducto.SelectedValue, vNombreProducto, CDec(txtCantidad.Text), vMedidaProducto)
                    cargarProductos(Nothing)
                    txtCantidad.Text = ""
                    cmbProducto.Focus()
                End If
            Else
                MsgBox("Producto no existe en esta bodega", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If dgvDetalle.Rows.Count = 0 Then
            desbloquear()
        End If
        cargarProductos(Nothing)
        txtCantidad.Text = ""
        btnEliminar.Enabled = False
        cmbProducto.Enabled = True
        btnAgregar.Enabled = True
        txtCantidad.Enabled = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        obtenerNumero()
        cargarBodega(Nothing)
        txtObservaciones.Text = ""
        cargarProductos(Nothing)
        txtCantidad.Text = ""
        bloquear()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        dgvDetalle.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvDetalle.Rows.Count > 0 Then
            obtenerNumero()
            BeginTransaction()
            If guardarMaestro() Then
                If guardarDetalle() Then
                    CommitTransaction()
                    MsgBox("Ajuste guardado con exito", MsgBoxStyle.Information, "Aviso")
                    If MessageBox.Show("Desa imprimir el ajuste", "Imprimir ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        mostrarReporte()
                    End If
                    btnLimpiar_Click(sender, e)
                Else
                    RollBackTransaction()
                    MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                End If
            Else
                RollBackTransaction()
                MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
            End If
        Else
            MsgBox("No existen datos agregados a este ajuste", MsgBoxStyle.Exclamation, "Aviso")
            cmbProducto.Focus()
        End If
    End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        e.PaintBackground(e.ClipBounds, True)
        e.PaintContent(e.ClipBounds)
        e.Handled = True
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim I As Integer = dgvDetalle.CurrentRow.Index
            cargarProductos(dgvDetalle.Item(0, I).Value)
            txtCantidad.Text = dgvDetalle.Item(2, I).Value
            cmbProducto.Enabled = False
            txtCantidad.Enabled = False
            btnAgregar.Enabled = False
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
        cargarProductos(Nothing)
        txtCantidad.Text = ""
        cmbProducto.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnEliminar.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaAjustes
                With frm
                    .ControlBox = False
                    .Show()
                    .MdiParent = Me.MdiParent
                    .Location = New Point(302, 2)
                End With
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Dim frm As New FrmBusquedaAjustes
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        End If
    End Sub
End Class