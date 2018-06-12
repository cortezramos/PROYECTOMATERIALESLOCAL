Public Class FrmConfigEmpresas
#Region "Controles"
    ''Limpia controles en pantalla
    Private Sub limpiar()
        txtEmpresaID.Text = ""
        txtEmpresa.Text = ""
        cargarGrid()
    End Sub
    ''Bloquea controles en pantalla
    Private Sub bloquear()
        txtEmpresaID.ReadOnly = True
        txtEmpresa.ReadOnly = True
    End Sub
    ''Desbloquea controles en pantalla
    Private Sub desbloquear()
        txtEmpresaID.ReadOnly = False
        txtEmpresa.ReadOnly = False
    End Sub
    ''Cargar grid con datos de fincas
    Private Sub cargarGrid()
        With dgvEmpresa
            .DataSource = empresas.consultarEmpresas()
            .Columns(0).Visible = False
            .Columns(2).Visible = False
        End With
    End Sub
    ''Combo para cargar empresas
#End Region
    Public fincas As New clsFincas
    Public empresas As New clsEmpresas
    Private Sub FrmConfigEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrid()
        bloquear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
        desbloquear()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If crearlog = 1 Then
            If txtEmpresa.Text <> "" Then
                empresas.insertarEmpresa(txtEmpresa.Text)
                limpiar()
                bloquear()
                btnGuardar.Visible = False
                btnNuevo.Visible = True
                cargarGrid()
            Else
                txtEmpresa.Focus()
                MsgBox("Ingrese Nombre de empresa")
            End If
        Else
            MsgBox("Su usuario no cuenta con privilegios para crear nuevos registros")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If modificarlog = 1 Then
            desbloquear()
            btnModificar.Visible = True
            btnEliminar.Visible = False
            btnEditar.Visible = False
        Else
            MsgBox("Su usuario no cuenta con privilegios para modificar registros")
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If txtEmpresa.Text <> "" Then
            empresas.modificarEmpresa(CInt(txtEmpresaID.Text), txtEmpresa.Text)
            btnModificar.Visible = False
            btnNuevo.Visible = True
            limpiar()
            bloquear()
            cargarGrid()
        Else
            txtEmpresa.Focus()
            MsgBox("Ingrese nombre de contratista")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If eliminarlog = 1 Then
            If MessageBox.Show("Desea eliminar esta Empresa?", "Eliminar!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                empresas.eliminarEmpresa(CInt(txtEmpresaID.Text))
                btnNuevo.Visible = True
                btnEditar.Visible = False
                btnEliminar.Visible = False
                cargarGrid()
                bloquear()
                limpiar()
            End If
        Else
            MsgBox("Su usuario no cuenta con privilegios para eliminar registros")
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiar()
        bloquear()
        cargarGrid()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnEditar.Visible = False
        btnModificar.Visible = False
        btnEliminar.Visible = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("Desea salir de este formulario?", "Salir!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub dgvEmpresa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpresa.CellClick
        If dgvEmpresa.Rows.Count > 0 Then
            Dim i As Integer = dgvEmpresa.CurrentRow.Index

            bloquear()

            txtEmpresaID.Text = dgvEmpresa.Item(0, i).Value
            txtEmpresa.Text = dgvEmpresa.Item(1, i).Value

            btnNuevo.Visible = False
            btnGuardar.Visible = False
            btnEditar.Visible = True
            btnEliminar.Visible = True
        End If
    End Sub
End Class