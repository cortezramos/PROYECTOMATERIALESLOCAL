Public Class FrmResponsables
#Region "Controles"
    Sub obtenerCodigo()
        txtCodigo.Text = clresponsable.ultimoCodigo()
    End Sub

    Sub consultarResponsables()
        With dgvDetalle
            .DataSource = clresponsable.consultarResponsables()
            .Columns(0).Width = 75
        End With
    End Sub

    Sub buscarResponsables()
        With dgvDetalle
            .DataSource = clresponsable.buscarResponsables(txtBuscar.Text)
            .Columns(0).Width = 75
        End With
    End Sub
#End Region
    Private clresponsable As New clResponsable
    Private Sub FrmResponsables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarResponsables()
        txtNombre.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtNombre.Enabled = True
        obtenerCodigo()
        btnGuardar.Visible = True
        btnNuevo.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrEmpty(txtCodigo.Text) = False Then
            If CInt(txtCodigo.Text) > 0 Then
                If String.IsNullOrEmpty(txtNombre.Text) = False Then
                    clresponsable.insertarResponsable(CInt(txtCodigo.Text), txtNombre.Text)
                    consultarResponsables()
                    txtCodigo.Text = ""
                    txtNombre.Text = ""
                    txtBuscar.Text = ""
                    txtNombre.Enabled = False
                    btnGuardar.Visible = False
                    btnEliminar.Visible = False
                    btnNuevo.Visible = True
                Else
                    MsgBox("Ingrese nombre para nuevo soliicitante", MsgBoxStyle.Exclamation, "Error de validacion")
                    txtNombre.Focus()
                End If
            Else
                MsgBox("Ingrese codigo", MsgBoxStyle.Exclamation, "Error de validacion")
                txtNombre.Focus()
            End If
        Else
            MsgBox("Ingrese codigo", MsgBoxStyle.Exclamation, "Error de validacion")
            txtNombre.Focus()
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            txtCodigo.Text = dgvDetalle.Item(0, i).Value
            txtNombre.Text = dgvDetalle.Item(1, i).Value
            txtNombre.Enabled = False
            btnNuevo.Visible = False
            btnGuardar.Visible = False
            btnEliminar.Visible = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If String.IsNullOrEmpty(txtCodigo.Text) = False Then
            If MessageBox.Show("Desea dar de baja a este solicitante", "Dar de baja!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                clresponsable.eliminarResponsable(CInt(txtCodigo.Text))
                consultarResponsables()
                txtCodigo.Text = ""
                txtNombre.Text = ""
                txtBuscar.Text = ""
                txtNombre.Enabled = False
                btnGuardar.Visible = False
                btnEliminar.Visible = False
                btnNuevo.Visible = True
            Else
                MsgBox("No se dara de baja a este solicitante", MsgBoxStyle.Information)
                consultarResponsables()
                txtCodigo.Text = ""
                txtNombre.Text = ""
                txtBuscar.Text = ""
                txtNombre.Enabled = False
                btnGuardar.Visible = False
                btnEliminar.Visible = False
                btnNuevo.Visible = True
            End If
        Else
            MsgBox("Seleccione solicitante a dar de baja", MsgBoxStyle.Exclamation, "Advertnecia")
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            buscarResponsables()
        Else
            consultarResponsables()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        consultarResponsables()
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtBuscar.Text = ""
        txtNombre.Enabled = False
        btnGuardar.Visible = False
        btnEliminar.Visible = False
        btnNuevo.Visible = True
    End Sub
End Class