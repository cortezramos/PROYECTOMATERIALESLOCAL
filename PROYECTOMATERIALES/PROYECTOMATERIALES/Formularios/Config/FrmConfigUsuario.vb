Public Class FrmConfigUsuario

#Region "Controles"
    Private Sub bloquear()
        txtUsuarioID.ReadOnly = True
        txtUsuario.ReadOnly = True
        txtContra.ReadOnly = True
        txtConfirmar.ReadOnly = True
        cmbEmpresas.Enabled = False
        cmbFinca.Enabled = False
        cmbSucursal.Enabled = False
        chkAdmin.Enabled = False
    End Sub
    Private Sub desbloquear()
        txtUsuario.ReadOnly = False
        txtContra.ReadOnly = False
        txtConfirmar.ReadOnly = False
        cmbEmpresas.Enabled = True
        cmbFinca.Enabled = True
        cmbSucursal.Enabled = True
        chkAdmin.Enabled = True
    End Sub
    Private Sub limpiar()
        txtUsuarioID.Text = ""
        txtUsuario.Text = ""
        txtContra.Text = ""
        txtConfirmar.Text = ""
        txtBuscar.Text = ""
        chkAdmin.Checked = False
        cargarEmpresas()
        cargarfincas(Nothing)
        cargarSucursal(Nothing)
    End Sub
    Private Sub cargarGrid()
        With dgvUsuarios
            .DataSource = usuarios.consultaTodosUsuarios()
            .Columns(0).Visible = False
        End With
    End Sub
    Private Sub cargarEmpresas()
        With cmbEmpresas
            .DataSource = empresas.consultaEmpresasCombo()
            .ValueMember = "EmpresaID"
            .DisplayMember = "Empresa"
        End With
    End Sub
    Private Sub cargarEmpresasID(Empresa As Integer)
        With cmbEmpresas
            .DataSource = empresas.consultaEmpresasCombo()
            .ValueMember = "EmpresaID"
            .DisplayMember = "Empresa"
            .SelectedValue = Empresa
        End With
    End Sub

    Private Sub cargarfincas(Valor As Integer)
        If Valor <> Nothing Then
            With cmbFinca
                .DataSource = fincas.comboFincas(CInt(cmbEmpresas.SelectedValue))
                .ValueMember = "FincaID"
                .DisplayMember = "Finca"
                .SelectedValue = Valor
            End With
        Else
            With cmbFinca
                .DataSource = fincas.comboFincas(CInt(cmbEmpresas.SelectedValue))
                .ValueMember = "FincaID"
                .DisplayMember = "Finca"
            End With
        End If
    End Sub

    Sub cargarSucursal(Valor As Integer)
        If Valor <> Nothing Then
            With cmbSucursal
                .DataSource = usuarios.seleccionSucursalParaUsuario(CInt(cmbEmpresas.SelectedValue))
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbSucursal
                .DataSource = usuarios.seleccionSucursalParaUsuario(CInt(cmbEmpresas.SelectedValue))
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

#End Region
    'Instanciacion de clase usuarios que maneja esta vista
    Public usuarios As New clsUsuarios
    'Instanciacion de clases para manejar vista
    Public empresas As New clsEmpresas
    Public fincas As New clsFincas
    ''Variable de tipo de usuario
    Public tipo As Integer

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        desbloquear()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtUsuario.Text <> "" Then
            If cmbEmpresas.SelectedValue > 0 Then
                If cmbFinca.SelectedValue > 0 Then
                    If txtContra.Text <> "" Then
                        If txtConfirmar.Text <> "" Then
                            If txtContra.Text = txtConfirmar.Text Then
                                If cmbSucursal.SelectedValue > 0 Then
                                    If usuarios.verificaUsuario(txtUsuario.Text, CInt(cmbSucursal.SelectedValue), CInt(cmbEmpresas.SelectedValue)) Then
                                        If MessageBox.Show("Desea agregar estos datos?", "Guardar datos", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                            usuarios.ingresarUsuario(txtUsuario.Text, txtContra.Text, CInt(cmbEmpresas.SelectedValue), CInt(cmbFinca.SelectedValue), tipo, CInt(cmbSucursal.SelectedValue))
                                            limpiar()
                                            cargarGrid()
                                            bloquear()
                                            btnNuevo.Visible = True
                                            btnGuardar.Visible = False
                                        End If
                                    Else
                                        MsgBox("Nombre de usuario ya existe en la base de datos")
                                    End If
                                Else
                                    MsgBox("Seleccione sucursal para usuario")
                                End If
                            Else
                                MsgBox("Contraseñas no coinciden")
                            End If
                        Else
                            MsgBox("Confirmar contraseña")
                            txtConfirmar.Focus()
                        End If
                    Else
                        MsgBox("Ingresar contraseña")
                        txtContra.Focus()
                    End If
                Else
                    MsgBox("Seleccione finca")
                    cmbFinca.Focus()
                End If
            Else
                MsgBox("Seleccione empresa")
                cmbEmpresas.Focus()
            End If
        Else
            MsgBox("Ingresar usuario")
            txtUsuario.Focus()
        End If

    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
        cargarGrid()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text <> "" Then
            With dgvUsuarios
                .DataSource = usuarios.buscaTodosUsuarios(txtBuscar.Text)
                .Columns(0).Visible = False
            End With
        Else
            cargarGrid()
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If txtContra.Text <> "" Then
            If txtConfirmar.Text <> "" Then
                If txtContra.Text = txtConfirmar.Text Then
                    If MessageBox.Show("Se modificaran los datos esta seguro?", "Modificar datos", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        usuarios.modificarUsuario(txtUsuarioID.Text, txtContra.Text)
                        limpiar()
                        cargarGrid()
                        bloquear()
                        btnModificar.Visible = False
                        btnNuevo.Visible = True
                        MsgBox("Usuario modificado")
                    End If
                Else
                    MsgBox("Contraseñas no coinciden")
                    txtConfirmar.Focus()
                End If
            Else
                MsgBox("Confirmar contraseña")
                txtConfirmar.Focus()
            End If
        Else
            MsgBox("Ingresar contraseña nueva")
            txtContra.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Desea eliminar usuario?", "Eliminar usuario", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            usuarios.eliminarUsuario(CInt(txtUsuarioID.Text))
            limpiar()
            cargarGrid()
            bloquear()
            MsgBox("Usuario eliminado")
            btnEliminar.Visible = False
            btnEditar.Visible = False
            btnNuevo.Visible = True
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnEliminar.Visible = False
        btnModificar.Visible = True
        desbloquear()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnEditar.Visible = False
        btnEliminar.Visible = False
        btnModificar.Visible = False
        limpiar()
        bloquear()
        cargarGrid()
    End Sub

    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        Dim i As Integer = dgvUsuarios.CurrentRow.Index
        bloquear()
        txtUsuarioID.Text = dgvUsuarios.Item(0, i).Value.ToString()
        txtUsuario.Text = dgvUsuarios.Item(1, i).Value.ToString()
        
        btnEditar.Visible = True
        btnEliminar.Visible = True
    End Sub

    Private Sub chkAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdmin.CheckedChanged
        If chkAdmin.Checked = True Then
            tipo = 1
        Else
            tipo = 0
        End If
    End Sub

    Private Sub cmbEmpresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresas.SelectedIndexChanged
        If cmbEmpresas.SelectedIndex > 0 Then
            cargarfincas(CInt(cmbEmpresas.SelectedValue))
            cargarSucursal(Nothing)
        End If
    End Sub
End Class