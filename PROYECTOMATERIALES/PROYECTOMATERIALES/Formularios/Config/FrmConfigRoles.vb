Public Class FrmConfigRoles
#Region "Controles"
    Private Sub cargarComboUsuario()
        With cmbUsuario
            .DataSource = usuarios.consultarUsuarios()
            .ValueMember = "UsuarioID"
            .DisplayMember = "Usuario"
        End With
    End Sub
    Private Sub cargarComboPadre()
        With cmbPadre
            .DataSource = roles.consultaMenusPadres()
            .ValueMember = "MenuID"
            .DisplayMember = "Nombre"
        End With
    End Sub
    Sub cargarComboMenus(padre As Integer)
        With cmbMenus
            .DataSource = configMenu.consultaMenusHijos(padre)
            .ValueMember = "MenuID"
            .DisplayMember = "Nombre"
        End With
    End Sub
    Private Sub bloquear()
        cmbUsuario.Enabled = False
        chkCrear.Enabled = False
        chkModificar.Enabled = False
        chkEliminar.Enabled = False
        btnCrear.Enabled = False
        cmbPadre.Enabled = False
        btnSeleccionar.Enabled = False
        cmbMenus.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarMenu.Enabled = False
        dgvRoles.Enabled = False
    End Sub
    Private Sub cargarGrid(usuario)
        With dgvRoles
            .DataSource = roles.detalleRoles(usuario)
            .Columns(0).Visible = False
        End With
    End Sub

#End Region
    'Instanciamiento de clases necesarias para creacion de perfil
    Public usuarios As New clsUsuarios
    Public configMenu As New clsMenu
    'Instanciacion de clase roles que maneja esta vista
    Public roles As New clsRoles
    'Variables para asignar valores de creacion de perfil
    Public user As Integer
    Public crear As Integer
    Public modificar As Integer
    Public eliminar As Integer
    Public padre As Integer
    Public dtPermisos As DataTable

    Private Sub FrmConfigRoles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        If cmbUsuario.SelectedValue > 0 Then
            If chkCrear.Checked = True Or chkModificar.Checked = True Or chkEliminar.Checked = True Then
                If chkCrear.Checked = True Then
                    crear = 1
                Else
                    crear = 0
                End If
                If chkModificar.Checked = True Then
                    modificar = 1
                Else
                    modificar = 0
                End If
                If chkEliminar.Checked = True Then
                    eliminar = 1
                Else
                    eliminar = 0
                End If
                user = CInt(cmbUsuario.SelectedValue)
                chkCrear.Enabled = False
                chkModificar.Enabled = False
                chkEliminar.Enabled = False
                btnCrear.Enabled = False
                cmbUsuario.Enabled = False
                cargarComboPadre()
                cmbPadre.Enabled = True
                cmbPadre.Focus()
                btnSeleccionar.Enabled = True
            Else
                MsgBox("Seleccione por lo menos un permiso para este perfil")
            End If
        Else
            MsgBox("Seleccione usuario para perfil")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cargarComboUsuario()
        cmbUsuario.Enabled = True
        btnCrear.Enabled = True
        chkCrear.Enabled = True
        chkModificar.Enabled = True
        chkEliminar.Enabled = True
        btnCrear.Enabled = True
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If cmbPadre.SelectedValue > 0 Then
            If MessageBox.Show("Desea agregar submenus para este menu?", "Menu padre", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                padre = CInt(cmbPadre.SelectedValue)
                If roles.verificarMenuAgregado(cmbUsuario.Text, padre) = 0 Then
                    roles.ingresarRol(user, padre, crear, modificar, eliminar)
                End If
                cmbPadre.Enabled = False
                btnSeleccionar.Enabled = False
                cargarGrid(user)
                cargarComboMenus(padre)
                cmbMenus.Enabled = True
                cmbMenus.Focus()
                btnCambiar.Enabled = True
                btnAgregar.Enabled = True
                btnEliminarMenu.Enabled = True
                dgvRoles.Enabled = True
            Else
                Exit Sub
            End If
        Else
            MsgBox("Seleccione menu padre para agregar submenus")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If roles.verificarMenuAgregado(cmbUsuario.Text, CInt(cmbMenus.SelectedValue)) > 0 Then
            MsgBox("Ya esta asignado este menu")
        Else
            If MessageBox.Show("Agregar menu", "Agregar menu", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                roles.ingresarRol(user, CInt(cmbMenus.SelectedValue), crear, modificar, eliminar)
                cargarGrid(user)
            Else
                MsgBox("No se agrego menu")
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        bloquear()
    End Sub

    Private Sub btnEliminarMenu_Click(sender As Object, e As EventArgs) Handles btnEliminarMenu.Click
        If MessageBox.Show("Desea eliminar acceso a menu", "Eliminar acceso", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            roles.eliminarRol(CInt(txtRolID.Text))
            cargarGrid(user)
        Else
            MsgBox("No se realizo la eliminacion")
        End If
    End Sub

    Private Sub dgvRoles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRoles.CellClick
        Dim i As Integer = dgvRoles.CurrentRow.Index
        txtRolID.Text = dgvRoles.Item(0, i).Value.ToString()
        cmbMenus.SelectedValue = CInt(dgvRoles.Item(1, i).Value)
    End Sub

    Private Sub cmbUsuario_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbUsuario.SelectionChangeCommitted
        If cmbUsuario.SelectedValue > 0 Then
            If roles.consultaExistenciaRol(CInt(cmbUsuario.SelectedValue)).Rows.Count > 0 Then
                dtPermisos = roles.consultaExistenciaRol(CInt(cmbUsuario.SelectedValue))
                crear = dtPermisos.Rows(0)(0).ToString()
                modificar = dtPermisos.Rows(0)(1).ToString()
                eliminar = dtPermisos.Rows(0)(2).ToString()
                chkCrear.Enabled = False
                chkModificar.Enabled = False
                chkEliminar.Enabled = False
            End If
            If crear = 1 Then
                chkCrear.Checked = True
            End If
            If modificar = 1 Then
                chkModificar.Checked = True
            End If
            If eliminar = 1 Then
                chkEliminar.Checked = True
            End If
        End If
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        cmbPadre.Enabled = True
        btnSeleccionar.Enabled = True
        cmbMenus.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarMenu.Enabled = False
        btnCambiar.Enabled = False
    End Sub
End Class