Public Class FrmConfigMenu
#Region "Controles"
    Private Sub cargarCombo()
        With cmbPadre
            .DataSource = configMenu.consultaPadres()
            .DisplayMember = "Nombre"
            .ValueMember = "MenuID"
        End With
    End Sub
    Private Sub cargarGrid()
        With dgvMenu
            .DataSource = configMenu.consultaMenu()
            .Columns(0).Visible = False
            .Columns(5).Visible = False
        End With
    End Sub
    Private Sub bloquear()
        txtNombre.ReadOnly = True
        cmbPadre.Enabled = False
        txtFormulario.ReadOnly = True
        txtImagen.ReadOnly = True
    End Sub
    Private Sub desbloquear()
        txtNombre.ReadOnly = False
        cmbPadre.Enabled = True
        txtFormulario.ReadOnly = False
        txtImagen.ReadOnly = False
    End Sub
    Private Sub limpiar()
        txtMenuID.Text = ""
        txtBuscar.Text = ""
        txtNombre.Text = ""
        cargarCombo()
        cargarGrid()
        txtFormulario.Text = ""
        txtImagen.Text = ""
        txtMenuID.Text = ""
    End Sub
#End Region
    'Instanciacion de clase menu que maneja esta vista
    Public configMenu As New clsMenu

    Private Sub FrmConfigMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCombo()
        cargarGrid()
        bloquear()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text <> "" Then
            dgvMenu.DataSource = configMenu.buscaMenu(txtBuscar.Text)
        Else
            cargarGrid()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        desbloquear()
        limpiar()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        bloquear()
        limpiar()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnEditar.Visible = False
        btnModificar.Visible = False
        btnEliminar.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ''Evaluamos el menu padre seleccionado si es uno guardamos 0 ya que seria un menu padre
        Dim padre As Integer
        If cmbPadre.SelectedValue = 1 Then
            padre = 0
        Else
            padre = CInt(cmbPadre.SelectedValue)
        End If

        If txtNombre.Text <> "" Then
            If txtImagen.Text <> "" Then
                If cmbPadre.SelectedValue > 1 Then
                    If txtFormulario.Text <> "" Then
                        configMenu.ingresaMenu(txtNombre.Text, padre, txtFormulario.Text, CInt(txtImagen.Text))
                        limpiar()
                        bloquear()
                        btnGuardar.Visible = False
                        btnNuevo.Visible = True
                    Else
                        MsgBox("Ingrese nombre de el formulario a ejecutar")
                        txtFormulario.Focus()
                    End If
                ElseIf cmbPadre.SelectedValue = 1 Then
                    configMenu.ingresaMenu(txtNombre.Text, padre, Nothing, CInt(txtImagen.Text))
                    limpiar()
                    bloquear()
                    btnGuardar.Visible = False
                    btnNuevo.Visible = True
                ElseIf cmbPadre.SelectedValue = 0 Then
                    MsgBox("Seleccione menu padre")
                    cmbPadre.Focus()
                End If
            Else
                MsgBox("Ingrese index para imagen a mostrar en el menu")
                txtImagen.Focus()
            End If
        Else
            MsgBox("Ingrese nombre a mostrar para el menu")
            txtNombre.Focus()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        desbloquear()
        btnModificar.Visible = True
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnEliminar.Visible = False
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim padre As Integer
        If cmbPadre.SelectedValue = 1 Then
            padre = 0
        Else
            padre = CInt(cmbPadre.SelectedValue)
        End If

        If txtNombre.Text <> "" Then
            If txtImagen.Text <> "" Then
                If cmbPadre.SelectedValue > 1 Then
                    If txtFormulario.Text <> "" Then
                        configMenu.modificaMenu(CInt(txtMenuID.Text), txtNombre.Text, padre, txtFormulario.Text, CInt(txtImagen.Text))
                        limpiar()
                        bloquear()
                        btnNuevo.Visible = True
                        btnModificar.Visible = False
                    Else
                        MsgBox("Ingrese nombre de el formulario a ejecutar")
                        txtFormulario.Focus()
                    End If
                ElseIf cmbPadre.SelectedValue = 1 Then
                    configMenu.modificaMenu(CInt(txtMenuID.Text), txtNombre.Text, padre, txtFormulario.Text, CInt(txtImagen.Text))
                    limpiar()
                    bloquear()
                    btnNuevo.Visible = True
                    btnModificar.Visible = False
                ElseIf cmbPadre.SelectedValue = 0 Then
                    MsgBox("Seleccione menu padre")
                    cmbPadre.Focus()
                End If
            Else
                MsgBox("Ingrese index para imagen a mostrar en el menu")
                txtImagen.Focus()
            End If
        Else
            MsgBox("Ingrese nombre a mostrar para el menu")
            txtNombre.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Desea eliminar este menu?", "Eliminar menu", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If configMenu.consultaHijos(txtMenuID.Text) < 1 Then
                configMenu.eliminarMenu(CInt(txtMenuID.Text))
                cargarGrid()
                limpiar()
                bloquear()
                btnEditar.Visible = False
                btnEliminar.Visible = False
                btnNuevo.Visible = True
            Else
                MsgBox("Menu tiene menus que dependen de este")
            End If
        End If
    End Sub

    Private Sub dgvMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick
        Dim i As Integer = dgvMenu.CurrentRow.Index

        txtMenuID.Text = dgvMenu.Item(0, i).Value.ToString()
        txtNombre.Text = dgvMenu.Item(1, i).Value.ToString()
        If CInt(dgvMenu.Item(2, i).Value.ToString()) = 0 Then
            cmbPadre.SelectedValue = 1
        Else
            cmbPadre.SelectedValue = CInt(dgvMenu.Item(2, i).Value.ToString())
        End If
        txtFormulario.Text = dgvMenu.Item(3, i).Value.ToString()
        txtImagen.Text = dgvMenu.Item(4, i).Value.ToString()

        btnNuevo.Visible = False
        btnGuardar.Visible = False
        btnEditar.Visible = True
        btnEliminar.Visible = True

        bloquear()
    End Sub

    Private Sub txtImagen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImagen.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Introduzca valores numericos")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class