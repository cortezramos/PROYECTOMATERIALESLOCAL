Public Class FrmConfigUsuarioMasivo
#Region "Controles"
    Sub bloquear()
        cmbUsuarios.Enabled = False
        cmbEmpresas.Enabled = False
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
#End Region

    Private clempresas As New clsEmpresas
    Private clusuarios As New clsUsuarios
    Private clroles As New clsRoles

    Private Sub FrmUsuarioMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        btnGuardar.Visible = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If CInt(cmbEmpresas.SelectedValue) > 0 Then
            If CInt(cmbUsuarios.SelectedValue) > 0 Then
                If clroles.verificarIngresoMasivoUsuarios(CInt(cmbUsuarios.SelectedValue), CInt(cmbEmpresas.SelectedValue)) Then
                    clroles.ingresoPermisosMasivos(CInt(cmbEmpresas.SelectedValue), CInt(cmbUsuarios.SelectedValue))
                    MsgBox("Datos agregados")
                Else
                    MsgBox("Ya existe permisos masivos para usuario: " & cmbUsuarios.Text & " en esta empresa, debe agregarlos manualmente")
                End If
            Else
                MsgBox("Seleccione usuario", MsgBoxStyle.Exclamation)
                cmbEmpresas.Focus()
            End If
        Else
            MsgBox("Seleccione empresa", MsgBoxStyle.Exclamation)
            cmbEmpresas.Focus()
        End If
    End Sub
End Class