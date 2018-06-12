Public Class FrmProveedor
#Region "Controles"
    Sub bloquear()
        txtNit.Enabled = False
        cmbTipo.Enabled = False
        txtNombre.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        txtTelefono2.Enabled = False
        txtEmail.Enabled = False
        txtLimite.Enabled = False
        txtContacto.Enabled = False
        txtDias.Enabled = False
        cmbImpuesto.Enabled = False
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
    End Sub

    Sub desbloquear()
        txtNit.Enabled = True
        cmbTipo.Enabled = True
        txtNombre.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
        txtTelefono2.Enabled = True
        txtEmail.Enabled = True
        txtLimite.Enabled = True
        txtContacto.Enabled = True
        txtDias.Enabled = True
        cmbImpuesto.Enabled = True
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
    End Sub

    Sub limpiar()
        txtNit.Text = ""
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtTelefono2.Text = ""
        txtEmail.Text = ""
        txtLimite.Text = ""
        txtContacto.Text = ""
        txtDias.Text = ""
        cargarTipo(Nothing)
        cargarImpuesto(Nothing)
        dgvImpuesto.Rows.Clear()
    End Sub

    Sub cargarTipo(Valor As Integer)
        If Valor <> Nothing Then
            With cmbTipo
                .DataSource = clprovee.consultarTipoProveedor()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbTipo
                .DataSource = clprovee.consultarTipoProveedor()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If

    End Sub

    Sub cargarImpuesto(Valor As Integer)
        If Valor <> Nothing Then
            With cmbImpuesto
                .DataSource = clprovee.consultarImpuestoProveedor()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbImpuesto
                .DataSource = clprovee.consultarImpuestoProveedor()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub consultarCodigo()
        txtCodigo.Text = clprovee.codigoProveedor()
    End Sub

    Function validarDatos() As Boolean
        If String.IsNullOrEmpty(txtNit.Text) Then
            MsgBox("Ingrese nit para proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtNit.Focus()
            Return False
        ElseIf clprovee.consultaExisteNit(txtNit.Text) = False And btnGuardar.Visible = True Then
            MsgBox("Este nit ya existe para otro proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtNit.Focus()
            Return False
        ElseIf CInt(cmbTipo.SelectedValue) = 0 Then
            MsgBox("Seleccione tipo de proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            cmbTipo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNombre.Text) Then
            MsgBox("Ingrese nombre de proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtNombre.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDireccion.Text) Then
            MsgBox("Ingrese direccion para proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtDireccion.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtTelefono.Text) Then
            MsgBox("Ingrese numero de telefono para proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtTelefono.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtLimite.Text) Then
            MsgBox("Ingrese limite de credito para proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtLimite.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtContacto.Text) Then
            MsgBox("Ingrese contacto de proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtContacto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDias.Text) Then
            MsgBox("Ingrese dias de credito permitidos para este proveedor", MsgBoxStyle.Exclamation, "Advertencia")
            txtDias.Focus()
            Return False
        ElseIf dgvImpuesto.Rows.Count <= 0 Then
            If MessageBox.Show("Este proveedor es exento de impuestos?", "Cliente exento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                MsgBox("Asigne impuesto a este proveedor", MsgBoxStyle.Exclamation, "Advertencia")
                cmbImpuesto.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Function guardarProveedor() As Boolean
        If clprovee.insertarProveedor(CInt(txtCodigo.Text), 0, CInt(txtDias.Text), CInt(cmbTipo.SelectedValue),
                                      CDec(txtLimite.Text), txtContacto.Text, txtEmail.Text, txtTelefono.Text,
                                      txtTelefono2.Text, txtDireccion.Text, txtNit.Text, txtNombre.Text) = False Then
            Return False
        End If
        Return True
    End Function

    Function guardarImpuestos() As Boolean
        If dgvImpuesto.Rows.Count > 0 Then
            For i As Integer = 0 To dgvImpuesto.Rows.Count - 1
                If Not clprovee.insertarImpuestoPorProveedor(CInt(txtCodigo.Text), dgvImpuesto.Item(0, i).Value, dgvImpuesto.Item(1, i).Value) Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Function modificarProveedor() As Boolean
        If clprovee.modificarProveedor(CInt(txtCodigo.Text), 0, CInt(txtDias.Text), CInt(cmbTipo.SelectedValue),
                                        CDec(txtLimite.Text), txtContacto.Text, txtEmail.Text, txtTelefono.Text,
                                        txtTelefono2.Text, txtDireccion.Text, txtNit.Text, txtNombre.Text) = False Then
            Return False
        End If
        Return True
    End Function

    Function eliminarImpuestos() As Boolean
        If clprovee.eliminarProveedorImpuesto(CInt(txtCodigo.Text)) = False Then
            Return False
        End If
        Return True
    End Function

#End Region

    Private clprovee As New clProveedor
    Private Sub FrmProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
        cargarImpuesto(Nothing)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        desbloquear()
        txtEstado.Text = "Activo"
        cargarTipo(Nothing)
        consultarCodigo()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtLimite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimite.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtLimite.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDias.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnInactivar_Click(sender As Object, e As EventArgs) Handles btnInactivar.Click
        If txtEstado.Text = "Inactivo" Then
            MsgBox("Proveedor ya se encuenta inactivo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf String.IsNullOrEmpty(txtCodigo.Text) = False Then
            If clprovee.consultarExisteOrdenParaProveedor(CInt(txtCodigo.Text)) Then
                BeginTransaction()
                If clprovee.cambiarEstadoProveedor(CInt(txtCodigo.Text), 1) Then
                    CommitTransaction()
                    MsgBox("Proveedor ha sido dado de baja", MsgBoxStyle.Information, "Aviso")
                    limpiar()
                    bloquear()
                Else
                    RollBackTransaction()
                    MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("Este proveedor tiene ordenes en curso, no puede ser dado de baja", MsgBoxStyle.Exclamation, "Aviso")
                txtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub btnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        If txtEstado.Text = "Activo" Then
            MsgBox("Proveedor ya se encuentra activo")
        ElseIf String.IsNullOrEmpty(txtCodigo.Text) = False Then
            BeginTransaction()
            If clprovee.cambiarEstadoProveedor(CInt(txtCodigo.Text), 0) Then
                CommitTransaction()
                MsgBox("Proveedor ha sido dado de alta", MsgBoxStyle.Information, "Aviso")
                limpiar()
                bloquear()
            Else
                RollBackTransaction()
                MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("Desea salir del formulario actual", "Desea Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarDatos() Then
            BeginTransaction()
            If guardarProveedor() Then
                If guardarImpuestos() Then
                    CommitTransaction()
                    MsgBox("Proveedor ha sido dado de alta", MsgBoxStyle.Information, "Aviso")
                    limpiar()
                    bloquear()
                    btnNuevo.Visible = True
                    btnGuardar.Visible = False
                Else
                    RollBackTransaction()
                    MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                RollBackTransaction()
                MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If CInt(cmbImpuesto.SelectedValue) > 0 Then
            dgvImpuesto.Rows.Add(cmbImpuesto.SelectedValue, cmbImpuesto.Text)
            cargarImpuesto(Nothing)
        Else
            MsgBox("Seleccione impuesto a agregar", MsgBoxStyle.Exclamation, "Advertencia")
            cmbImpuesto.Focus()
        End If
    End Sub

    Private Sub dgvImpuesto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvImpuesto.CellDoubleClick
        If dgvImpuesto.Rows.Count > 0 Then
            Dim i As Integer = dgvImpuesto.CurrentRow.Index
            cargarImpuesto(CInt(dgvImpuesto.Item(0, i).Value))
            btnAgregar.Visible = False
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cargarImpuesto(Nothing)
        btnAgregar.Visible = True
        btnEliminar.Visible = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        dgvImpuesto.Rows.Remove(dgvImpuesto.CurrentRow)
        cargarImpuesto(Nothing)
        btnAgregar.Visible = True
        btnEliminar.Visible = False
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If validarDatos() Then
            BeginTransaction()
            If modificarProveedor() Then
                If eliminarImpuestos() Then
                    If guardarImpuestos() Then
                        CommitTransaction()
                        MsgBox("Modificacion correcta", MsgBoxStyle.Information, "Aviso")
                        limpiar()
                        bloquear()
                        btnNuevo.Visible = True
                        btnModificar.Visible = False
                    Else
                        RollBackTransaction()
                        MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
                    End If
                Else
                    RollBackTransaction()
                    MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                RollBackTransaction()
                MsgBox("Ocurrio un error al guardar la informacion, no se guardaran los cambios", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvImpuesto.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos en pantalla, desea salir?", "Desea salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaDeProveedores
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
            Dim frm As New FrmBusquedaDeProveedores
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class