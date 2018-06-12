Public Class FrmConfigFincas
#Region "Controles"
    ''Limpia controles en pantalla
    Private Sub limpiar()
        txtFincaID.Text = ""
        txtFinca.Text = ""
        cargarGrid()
        cargarEmpresas(Nothing)
    End Sub
    ''Bloquea controles en pantalla
    Private Sub bloquear()
        txtFincaID.ReadOnly = True
        cmbEmpresa.Enabled = False
        txtFinca.ReadOnly = True
    End Sub
    ''Desbloquea controles en pantalla
    Private Sub desbloquear()
        txtFincaID.ReadOnly = False
        cmbEmpresa.Enabled = True
        txtFinca.ReadOnly = False
    End Sub
    ''Cargar grid con datos de fincas
    Private Sub cargarGrid()
        With dgvFincas
            .DataSource = fincas.consultarFincas()
            .Columns(1).Visible = False
        End With
    End Sub
    ''Combo para cargar empresas
    Private Sub cargarEmpresas(Valor As Integer)
        If Valor <> Nothing Then
            With cmbEmpresa
                .DataSource = empresas.consultaEmpresasCombo()
                .ValueMember = "EmpresaID"
                .DisplayMember = "Empresa"
                .SelectedValue = Valor
            End With
        Else
            With cmbEmpresa
                .DataSource = empresas.consultaEmpresasCombo()
                .ValueMember = "EmpresaID"
                .DisplayMember = "Empresa"
            End With
        End If
    End Sub
#End Region
    Public fincas As New clsFincas
    Public empresas As New clsEmpresas
    Private Sub FrmConfigFincas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrid()
        cargarEmpresas(Nothing)
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
            If txtFincaID.Text <> "" Then
                If cmbEmpresa.SelectedValue > 0 Then
                    If txtFinca.Text <> "" Then
                        fincas.insertarFincas(CInt(txtFincaID.Text), CInt(cmbEmpresa.SelectedValue), txtFinca.Text)
                        limpiar()
                        bloquear()
                        btnGuardar.Visible = False
                        btnNuevo.Visible = True
                        cargarGrid()
                        cargarEmpresas(Nothing)
                    Else
                        txtFinca.Focus()
                        MsgBox("Ingrese nombre de finca")
                    End If
                Else
                    MsgBox("Seleccione empresa a la que pertenece finca")
                    cmbEmpresa.Focus()
                End If
            Else
                MsgBox("Ingrese numero de planta en finca")
                txtFincaID.Focus()
            End If
        Else
            MsgBox("Su usuario no cuenta con privilegios para crear nuevos registros")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If modificarlog = 1 Then
            desbloquear()
            txtFincaID.ReadOnly = True
            btnModificar.Visible = True
            btnEliminar.Visible = False
            btnEditar.Visible = False
        Else
            MsgBox("Su usuario no cuenta con privilegios para modificar registros")
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If cmbEmpresa.SelectedValue > 0 Then
            If txtFinca.Text <> "" Then
                fincas.modificarFincas(CInt(txtFincaID.Text), CInt(cmbEmpresa.SelectedValue), txtFinca.Text)
                btnModificar.Visible = False
                btnNuevo.Visible = True
                limpiar()
                bloquear()
                cargarGrid()
                cargarEmpresas(Nothing)
            Else
                MsgBox("Ingrese nombre de Finca")
                txtFinca.Focus()
            End If
        Else
            MsgBox("Seleccione empresa a la que pertenece finca")
            cmbEmpresa.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If eliminarlog = 1 Then
            If MessageBox.Show("Desea eliminar esta Finca?", "Eliminar!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                fincas.eliminarFinca(CInt(txtFincaID.Text))
                btnNuevo.Visible = True
                btnEditar.Visible = False
                btnEliminar.Visible = False
                cargarGrid()
                cargarEmpresas(Nothing)
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
        cargarEmpresas(Nothing)
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

    Private Sub dgvFincas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFincas.CellClick
        If dgvFincas.Rows.Count > 0 Then
            Dim i As Integer = dgvFincas.CurrentRow.Index

            bloquear()

            txtFincaID.Text = dgvFincas.Item(0, i).Value
            txtFinca.Text = dgvFincas.Item(3, i).Value
            cargarEmpresas(CInt(dgvFincas.Item(1, i).Value))

            btnNuevo.Visible = False
            btnGuardar.Visible = False
            btnEditar.Visible = True
            btnEliminar.Visible = True
        End If
    End Sub
End Class