Public Class FrmConfigSucursales
#Region "Controles"
    Sub bloquear()
        cmbUsuarios.Enabled = False
        cmbEmpresas.Enabled = False
        cmbSucursal.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
    End Sub

    Sub desbloquear()
        cmbUsuarios.Enabled = True
        cmbEmpresas.Enabled = True
    End Sub

    Sub cargarUsuarios()
        With cmbUsuarios
            .DataSource = clusuarios.consultarListaUsuarios()
            .ValueMember = "UsuarioID"
            .DisplayMember = "Usuario"
        End With
    End Sub

    Sub cargarEmpresas()
        With cmbEmpresas
            .DataSource = clempresas.consultaEmpresasCombo()
            .ValueMember = "EmpresaID"
            .DisplayMember = "Empresa"
        End With
    End Sub

    Sub cargarSucursal()
        With cmbSucursal
            .DataSource = clusuarios.seleccionSucursalParaUsuario(CInt(cmbEmpresas.SelectedValue))
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub sucursalesPorUsuario()
        With dgvDatos
            .DataSource = clusuarios.consultarSucursalesParaUsuario(CInt(cmbEmpresas.SelectedValue), CInt(cmbUsuarios.SelectedValue))
        End With
    End Sub

#End Region

    Private clempresas As New clsEmpresas
    Private clusuarios As New clsUsuarios
    Private clroles As New clsRoles

    Private Sub FrmConfigSucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
        btnNuevo.Visible = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        desbloquear()
        cargarEmpresas()
        cargarUsuarios()
        btnNuevo.Visible = False
        btnConsultar.Visible = True
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If cmbUsuarios.SelectedValue > 0 Then
            If cmbEmpresas.SelectedValue > 0 Then
                bloquear()
                cmbSucursal.Enabled = True
                btnAgregar.Enabled = True
                cargarSucursal()
                sucursalesPorUsuario()
                btnNuevo.Visible = False
                btnConsultar.Visible = False
            Else
                MsgBox("Seleccione empresa")
            End If
        Else
            MsgBox("Seleccione usuario")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbUsuarios.SelectedValue > 0 Then
            If cmbEmpresas.SelectedValue > 0 Then
                If cmbSucursal.SelectedValue > 0 Then
                    If clusuarios.verificarExisteSucursal(CInt(cmbUsuarios.SelectedValue), CInt(cmbEmpresas.SelectedValue), CInt(cmbSucursal.SelectedValue)) Then
                        clusuarios.asignarSucursalesPorUsuario(CInt(cmbUsuarios.SelectedValue), CInt(cmbEmpresas.SelectedValue), CInt(cmbSucursal.SelectedValue))
                        sucursalesPorUsuario()
                        cargarSucursal()
                        MsgBox("Sucursal asignada")
                    Else
                        MsgBox("Sucursal ya ha sido asignada")
                        cmbSucursal.Focus()
                    End If
                Else
                    MsgBox("Seleccione sucursal")
                    cmbSucursal.Focus()
                End If
            Else
                MsgBox("Seleccione empresa")
                cmbEmpresas.Focus()
            End If
        Else
            MsgBox("Seleccione usuario")
            cmbUsuarios.Focus()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        bloquear()
        cargarEmpresas()
        cargarUsuarios()
        cargarSucursal()
        sucursalesPorUsuario()
        btnNuevo.Visible = True
        btnConsultar.Visible = False
    End Sub
End Class