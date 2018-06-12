Public Class FrmProductos
#Region "Controles"
    Sub cargarTipoInventario(Valor As Integer)
        If Valor <> Nothing Then
            With cmbTipoInventario
                .DataSource = clproductos.consultarTipoInventario()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbTipoInventario
                .DataSource = clproductos.consultarTipoInventario()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub cargarMedida(Valor As Integer)
        If Valor <> Nothing Then
            With cmbMedida
                .DataSource = clproductos.consultarMedidaProductos()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbMedida
                .DataSource = clproductos.consultarMedidaProductos()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub cargarMoneda(Valor As Integer)
        If Valor <> Nothing Then
            With cmbMoneda
                .DataSource = clproductos.consultarTipoMoneda()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbMoneda
                .DataSource = clproductos.consultarTipoMoneda()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub cargarSugerencias()
        dgvDatos.DataSource = clproductos.consultarSugerenciasNombresProductos(txtDescripcion.Text)
    End Sub

    Sub consultarCodigo()
        txtCodigo.Text = clproductos.consultarUltimoCodigoProducto(cmbTipoInventario.SelectedValue)
    End Sub

    Sub bloquear()
        cmbTipoInventario.Enabled = False
        txtDescripcion.Enabled = False
        txtMinimo.Enabled = False
        txtMaximo.Enabled = False
        chkMaterialVenta.Enabled = False
        chkAfectaExistencia.Enabled = False
        txtObservaciones.Enabled = False
        cmbMoneda.Enabled = False
        cmbMedida.Enabled = False
        txtPrecio.Enabled = False
    End Sub

    Sub desbloquear()
        cmbTipoInventario.Enabled = True
        txtDescripcion.Enabled = True
        txtMinimo.Enabled = True
        txtMaximo.Enabled = True
        chkMaterialVenta.Enabled = True
        chkAfectaExistencia.Enabled = True
        txtObservaciones.Enabled = True
        cmbMoneda.Enabled = True
        cmbMedida.Enabled = True
        txtPrecio.Enabled = True
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtEstado.Text = ""
        cargarTipoInventario(Nothing)
        txtDescripcion.Text = ""
        txtMinimo.Text = ""
        txtMaximo.Text = ""
        chkMaterialVenta.Checked = False
        chkAfectaExistencia.Checked = True
        txtObservaciones.Text = ""
        cargarMoneda(Nothing)
        cargarMedida(Nothing)
        txtPrecio.Text = "0.00"
    End Sub

    Sub enviarCorreo()
        If vPrecioDefault <> CDec(txtPrecio.Text) And vMedidaDefault <> CInt(cmbMedida.SelectedValue) Then
            clcorreo.enviarCorreo("Productos", "El producto " & txtDescripcion.Text & " cambio su unidad de medida a: " & cmbMedida.Text & " y su precio de " & vPrecioDefault & " a " & txtPrecio.Text & "<br/>")
        ElseIf vPrecioDefault <> CDec(txtPrecio.Text) Then
            clcorreo.enviarCorreo("Productos", "El producto " & txtDescripcion.Text & " cambio precio de " & vPrecioDefault & " a " & txtPrecio.Text & "<br/>")
        ElseIf vMedidaDefault <> cmbMedida.SelectedValue Then
            clcorreo.enviarCorreo("Productos", "El producto " & txtDescripcion.Text & " cambio su unidad de medida a: " & cmbMedida.Text & "<br/>")
        End If
    End Sub

    Sub guardar()
        If cmbTipoInventario.SelectedValue > 0 Then
            If String.IsNullOrEmpty(txtDescripcion.Text) = False Then
                If clproductos.verificarNombreProductoNoExista(txtDescripcion.Text) Then
                    If String.IsNullOrEmpty(txtMinimo.Text) = False Then
                        If String.IsNullOrEmpty(txtMaximo.Text) = False Then
                            If cmbMoneda.SelectedValue > 0 Then
                                If cmbMedida.SelectedValue > 0 Then
                                    If String.IsNullOrEmpty(txtPrecio.Text) = False Then
                                        If CDec(txtPrecio.Text) >= 0 Then
                                            If CDec(txtPrecio.Text) = 0 Then
                                                If MessageBox.Show("Producto se guardara con valor cero en precio?", "Precio Cero!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                                                    txtPrecio.Focus()
                                                    Exit Sub
                                                End If
                                            End If
                                            BeginTransaction()
                                            If clproductos.insertarProducto(txtCodigo.Text, txtDescripcion.Text, CInt(cmbTipoInventario.SelectedValue), txtObservaciones.Text, CInt(txtMaximo.Text), CInt(txtMinimo.Text), vExistencia, CInt(cmbMoneda.SelectedValue), vVenta, CInt(cmbMedida.SelectedValue), CDec(txtPrecio.Text)) Then
                                                CommitTransaction()
                                                limpiar()
                                                bloquear()
                                                cargarSugerencias()
                                                btnNuevo.Visible = True
                                                btnGuardar.Visible = False
                                                MsgBox("Producto guardado correctamente", MsgBoxStyle.Information)
                                            Else
                                                RollBackTransaction()
                                                MsgBox("Error insertando producto, no se realizo la accion", MsgBoxStyle.Exclamation, "Error de sistema")
                                            End If

                                        Else
                                            MsgBox("Ingrese un valor mayor a cero", MsgBoxStyle.Exclamation, "Error de validacion")
                                            txtPrecio.Focus()
                                        End If
                                    Else
                                        MsgBox("Precio debe ser valor 0 o mayor, no puede estar vacio", MsgBoxStyle.Exclamation, "Error de validacion")
                                        txtPrecio.Focus()
                                    End If
                                Else
                                    MsgBox("Seleccione unidad de medida para producto", MsgBoxStyle.Exclamation, "Error de validacion")
                                    cmbMedida.Focus()
                                End If
                            Else
                                MsgBox("Seleccione tipo de moneda para este producto", MsgBoxStyle.Exclamation, "Error de validacion")
                                cmbMoneda.Focus()
                            End If
                        Else
                            MsgBox("Ingrese valora para maximo", MsgBoxStyle.Exclamation, "Error de validacion")
                            txtMaximo.Focus()
                        End If
                    Else
                        MsgBox("Ingrese valora para minimo", MsgBoxStyle.Exclamation, "Error de validacion")
                        txtMinimo.Focus()
                    End If
                Else
                    MsgBox("Nombre de producto ya existe", MsgBoxStyle.Exclamation, "Error de validacion")
                    txtDescripcion.Focus()
                End If
            Else
                MsgBox("Ingrese nombre de producto", MsgBoxStyle.Exclamation, "Error de validacion")
                txtDescripcion.Focus()
            End If
        Else
            MsgBox("Seleccione tipo de inventario para este producto", MsgBoxStyle.Exclamation, "Error de validacion")
            cmbTipoInventario.Focus()
        End If
    End Sub
#End Region

    Private clproductos As New clProductos
    Private clcorreo As New clCorreos
    Private vVenta As Integer
    Private vExistencia As Integer
    Public vMedidaDefault As Integer
    Public vPrecioDefault As Decimal

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtPrecio.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyValue = Keys.F2 And btnGuardar.Visible = True Then
            If txtCodigo.ReadOnly = True Then
                txtCodigo.ReadOnly = False
            Else
                txtCodigo.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            txtDescripcion.Text = dgvDatos.Item(0, i).Value
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        If String.IsNullOrEmpty(txtDescripcion.Text) = False Then
            cargarSugerencias()
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
            If btnGuardar.Visible = True Then
                consultarCodigo()
            End If
        End If
    End Sub

    Private Sub txtMinimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinimo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtMinimo.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMaximo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaximo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtMinimo.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        ElseIf txtDescripcion.Text.Length = 200 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If txtObservaciones.Text.Length = 150 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        desbloquear()
        limpiar()
        txtEstado.Text = "Activo"
        chkAfectaExistencia.Checked = True
        btnGuardar.Visible = True
        btnNuevo.Visible = False
        btnEliminar.Visible = False
        btnAlta.Visible = False
        btnEditar.Visible = False
        btnModificar.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If modificarlog = 1 Then
            If String.IsNullOrEmpty(txtCodigo.Text) = False Then
                If vExistencia = 0 Then
                    If MessageBox.Show("Este producto no afectara existencia, es correcto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        guardar()
                    Else
                        chkAfectaExistencia.Focus()
                        Exit Sub
                    End If
                Else
                    guardar()
                End If
            Else
                MsgBox("Debe existir codigo, consulte con el administrador del sistema", MsgBoxStyle.Exclamation, "Error de validacion")
            End If
        Else
            MsgBox("No cuenta con permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub chkMaterialVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chkMaterialVenta.CheckedChanged
        If chkMaterialVenta.Checked Then
            vVenta = 1
        Else
            vVenta = 0
        End If
    End Sub

    Private Sub chkAfectaExistencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkAfectaExistencia.CheckedChanged
        If chkAfectaExistencia.Checked Then
            vExistencia = 1
        Else
            vExistencia = 0
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If btnNuevo.Visible Then
            Dim frm As New FrmConsultarProductos
            With frm
                .Show()
                .ControlBox = False
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        Else
            If MessageBox.Show("Se estan editando datos desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmConsultarProductos
                With frm
                    .Show()
                    .ControlBox = False
                    .MdiParent = Me.MdiParent
                    .Location = New Point(302, 2)
                End With
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtEstado.Text = "Inactivo" Then
            MsgBox("Este producto ya se encuenta inactivo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf eliminarlog = 0 Then
            MsgBox("No cuenta con permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf txtEstado.Text = "Activo" Then
            If clproductos.verificarInventarioEnTransito(txtCodigo.Text) Then
                If clproductos.verificarExistenciaProducto(txtCodigo.Text) Then
                    If MessageBox.Show("Desea inactivar este producto?", "Inactivar producto!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        BeginTransaction()
                        If clproductos.cambiarEstadoProducto("Inactivo", txtCodigo.Text) Then
                            CommitTransaction()
                            txtEstado.Text = ""
                            txtEstado.Text = "Inactivo"
                            btnEliminar.Visible = False
                            btnAlta.Visible = False
                            btnEditar.Visible = False
                            btnModificar.Visible = False
                            btnGuardar.Visible = False
                            btnNuevo.Visible = True
                            MsgBox("Se ha inactivado este producto", MsgBoxStyle.Information)
                        Else
                            RollBackTransaction()
                            MsgBox("No se ha inactivado este producto", MsgBoxStyle.Exclamation, "Error de sistema")
                        End If
                    Else
                        MsgBox("No se inactivara el producto", MsgBoxStyle.Exclamation, "Advertencia")
                    End If
                Else
                    MsgBox("Este producto tiene existencia, no puede ser inactivado", MsgBoxStyle.Exclamation, "Error de validacion")
                End If
            Else
                MsgBox("Este producto tiene inventario en transito no puede ser inactivado", MsgBoxStyle.Exclamation, "Error de validacion")
            End If
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If txtEstado.Text = "Inactivo" Then
            MsgBox("No se puede editar un Producto Inactivo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf modificarlog = 0 Then
            MsgBox("No cuenta con permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Aviso")
        ElseIf txtEstado.Text = "Activo" Then
            desbloquear()
            btnEditar.Visible = False
            btnEliminar.Visible = False
            btnAlta.Visible = False
            btnNuevo.Visible = False
            btnGuardar.Visible = False
            btnModificar.Visible = True
        End If
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        If txtEstado.Text = "Activo" Then
            MsgBox("Este producto ya se encuenta Activo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf eliminarlog = 0 Then
            MsgBox("No cuenta con permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf txtEstado.Text = "Inactivo" Then
            If MessageBox.Show("Desea Activar este producto?", "Activar producto!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                BeginTransaction()
                If clproductos.cambiarEstadoProducto("Activo", txtCodigo.Text) Then
                    CommitTransaction()
                    txtEstado.Text = "Activo"
                    btnEliminar.Visible = False
                    btnAlta.Visible = False
                    btnEditar.Visible = False
                    btnModificar.Visible = False
                    btnGuardar.Visible = False
                    btnNuevo.Visible = True
                    MsgBox("Se ha activado este producto", MsgBoxStyle.Information)
                Else
                    RollBackTransaction()
                    MsgBox("No se ha Activado este producto", MsgBoxStyle.Exclamation, "Error de sistema")
                End If
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If modificarlog = 1 Then
            If String.IsNullOrEmpty(txtCodigo.Text) = False Then
                If cmbTipoInventario.SelectedValue > 0 Then
                    If String.IsNullOrEmpty(txtDescripcion.Text) = False Then
                        If clproductos.verificarNombreProductoNoExista(txtDescripcion.Text) Then
                            If String.IsNullOrEmpty(txtMinimo.Text) = False Then
                                If String.IsNullOrEmpty(txtMaximo.Text) = False Then
                                    If cmbMoneda.SelectedValue > 0 Then
                                        If cmbMedida.SelectedValue > 0 Then
                                            If String.IsNullOrEmpty(txtPrecio.Text) = False Then
                                                If CDec(txtPrecio.Text) >= 0 Then
                                                    If CDec(txtPrecio.Text) = 0 Then
                                                        If MessageBox.Show("Producto se guardara con valor cero en precio?", "Precio Cero!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                                                            txtPrecio.Focus()
                                                            Exit Sub
                                                        End If
                                                    End If
                                                    If MessageBox.Show("Desea modificar con estos nuevos datos el producto", "Modificar datos!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                                        If vMedidaDefault <> CInt(cmbMedida.SelectedValue) Or vPrecioDefault <> CDec(txtPrecio.Text) Then
                                                            If MessageBox.Show("Se cambiara medida o precio al producto desea continuar?", "Cambio de medida o precio!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                                                BeginTransaction()
                                                                If clproductos.eliminarEInsertarProductoUnidad(txtCodigo.Text, CInt(cmbMedida.SelectedValue), CDec(txtPrecio.Text)) Then
                                                                    CommitTransaction()
                                                                    enviarCorreo()
                                                                Else
                                                                    RollBackTransaction()
                                                                    MsgBox("Error modificando medida o precio, no se operara esta modificacion", MsgBoxStyle.Exclamation, "Error de sistema")
                                                                    Exit Sub
                                                                End If
                                                            Else
                                                                Exit Sub
                                                            End If
                                                        End If
                                                        BeginTransaction()
                                                        If clproductos.modificarProducto(txtCodigo.Text, txtDescripcion.Text, CInt(cmbTipoInventario.SelectedValue), txtObservaciones.Text, CInt(txtMaximo.Text), CInt(txtMinimo.Text), vExistencia, CInt(cmbMoneda.SelectedValue), vVenta) Then
                                                            CommitTransaction()
                                                            limpiar()
                                                            bloquear()
                                                            cargarSugerencias()
                                                            btnNuevo.Visible = True
                                                            btnGuardar.Visible = False
                                                            btnModificar.Visible = False
                                                            MsgBox("Producto modificado correctamente", MsgBoxStyle.Information)
                                                        Else
                                                            RollBackTransaction()
                                                            MsgBox("Error insertando producto, no se realizo la accion", MsgBoxStyle.Exclamation, "Error de sistema")
                                                        End If
                                                    End If
                                                Else
                                                    MsgBox("Ingrese un valor mayor a cero", MsgBoxStyle.Exclamation, "Error de validacion")
                                                    txtPrecio.Focus()
                                                End If
                                            Else
                                                MsgBox("Precio debe ser valor 0 o mayor, no puede estar vacio", MsgBoxStyle.Exclamation, "Error de validacion")
                                                txtPrecio.Focus()
                                            End If
                                        Else
                                            MsgBox("Seleccione unidad de medida para producto", MsgBoxStyle.Exclamation, "Error de validacion")
                                            cmbMedida.Focus()
                                        End If
                                    Else
                                        MsgBox("Seleccione tipo de moneda para este producto", MsgBoxStyle.Exclamation, "Error de validacion")
                                        cmbMoneda.Focus()
                                    End If
                                Else
                                    MsgBox("Ingrese valora para maximo", MsgBoxStyle.Exclamation, "Error de validacion")
                                    txtMaximo.Focus()
                                End If
                            Else
                                MsgBox("Ingrese valora para minimo", MsgBoxStyle.Exclamation, "Error de validacion")
                                txtMinimo.Focus()
                            End If
                        Else
                            MsgBox("Nombre de producto ya existe", MsgBoxStyle.Exclamation, "Error de validacion")
                            txtDescripcion.Focus()
                        End If
                    Else
                        MsgBox("Ingrese nombre de producto", MsgBoxStyle.Exclamation, "Error de validacion")
                        txtDescripcion.Focus()
                    End If
                Else
                    MsgBox("Seleccione tipo de inventario para este producto", MsgBoxStyle.Exclamation, "Error de validacion")
                    cmbTipoInventario.Focus()
                End If
            Else
                MsgBox("Debe existir codigo, consulte con el administrador del sistema", MsgBoxStyle.Exclamation, "Error de validacion")
            End If
        Else
            MsgBox("No tiene permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub cmbMedida_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbMedida.MouseWheel
        If cmbMedida.DroppedDown Then
            Exit Sub
        Else
            cmbMedida.SelectedIndex = -1
            lblMedida.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbMoneda.MouseWheel
        If cmbMoneda.DroppedDown Then
            Exit Sub
        Else
            cmbMoneda.SelectedIndex = -1
            lblMoneda.Focus()
        End If
    End Sub
End Class