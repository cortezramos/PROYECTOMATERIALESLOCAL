Public Class FrmBusquedaDeProveedores
#Region "Controles"
    Sub cargarProveedores()
        With dgvDetalle
            .DataSource = clprovee.busquedaProveedor("")
            .Columns(0).Visible = False
        End With
    End Sub

    Sub buscarProveedores()
        With dgvDetalle
            .DataSource = clprovee.busquedaProveedor(txtBuscar.Text)
            .Columns(0).Visible = False
        End With
    End Sub

#End Region
    Private clprovee As New clProveedor
    Private Sub FrmBusquedaDeProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarProveedores()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) = False Then
            buscarProveedores()
        Else
            cargarProveedores()
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            Dim dtDatos As DataTable = clprovee.consultarProveedorPorCodigo(CInt(dgvDetalle.Item(0, i).Value))
            Dim dtDetalle As DataTable = clprovee.consultarImpuestoPorProveedor(CInt(dgvDetalle.Item(0, i).Value))
            Dim frm As New FrmProveedor
            With frm
                .txtCodigo.Text = dtDatos.Rows(0)(0).ToString()
                .txtNombre.Text = dtDatos.Rows(0)(2).ToString()
                .txtNit.Text = dtDatos.Rows(0)(3).ToString()
                .txtDireccion.Text = dtDatos.Rows(0)(4).ToString()
                .txtTelefono.Text = dtDatos.Rows(0)(5).ToString()
                .txtTelefono2.Text = dtDatos.Rows(0)(6).ToString()
                .txtEmail.Text = dtDatos.Rows(0)(7).ToString()
                .txtContacto.Text = dtDatos.Rows(0)(9).ToString()
                .txtLimite.Text = dtDatos.Rows(0)(10).ToString()
                .cargarTipo(CInt(dtDatos.Rows(0)(11).ToString()))
                .txtDias.Text = dtDatos.Rows(0)(12).ToString()
                If CBool(dtDatos.Rows(0)(13).ToString()) = True Then
                    .txtEstado.Text = "Inactivo"
                Else
                    .txtEstado.Text = "Activo"
                End If
                .dgvImpuesto.Rows.Clear()
                For a As Integer = 0 To dtDetalle.Rows.Count - 1
                    .dgvImpuesto.Rows.Add(dtDetalle.Rows(a)(0).ToString(), dtDetalle.Rows(a)(1).ToString())
                Next
                .Show()
                .btnNuevo.Visible = False
                .btnGuardar.Visible = False
                .btnModificar.Visible = True
                .btnInactivar.Visible = True
                .btnActivar.Visible = True
                .desbloquear()
                .ControlBox = False
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
                Me.Close()
            End With
        End If
    End Sub
End Class