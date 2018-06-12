Public Class FrmBusquedaSolicitudes
#Region "Controles"
    Sub cargarDatos()
        With dgvDatos
            .DataSource = clsolicitud.consultarSolicitudMateriales()
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(4).Width = 75
        End With
    End Sub

    Sub buscarDatos()
        With dgvDatos
            .DataSource = clsolicitud.buscarSolicitudMateriales(txtBuscar.Text)
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(4).Width = 75
        End With
    End Sub

    Sub cargarPendientes()
        With dgvDatos
            .DataSource = clsolicitud.consultarSolicitudMaterialesPendientes()
            .Columns(0).Width = 75
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(4).Width = 75
        End With
    End Sub

#End Region
    Private clsolicitud As New clSolicitudMateriales
    Private numero As Integer
    Private Sub FrmBusquedaSolicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) Then
            cargarDatos()
        Else
            buscarDatos()
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            numero = CInt(dgvDatos.Item(0, i).Value)
            Dim dtMaestro As DataTable = clsolicitud.seleccionSolicitudMaestro(numero)
            Dim dtDetalle As DataTable = clsolicitud.seleccionSolicitudDetalle(numero)
            Dim frm As New FrmSolicitudMateriales
            With frm
                .txtNumero.Text = numero
                .cargarSolicitantes(CInt(dtMaestro.Rows(0)(3).ToString()))
                .txtObservaciones.Text = dtMaestro.Rows(0)(4).ToString()
                .dtFecha.Text = dtMaestro.Rows(0)(2).ToString()
                .cargarSolicitaDetalle()
                .cargarGrid()
                For a As Integer = 0 To dtDetalle.Rows.Count - 1
                    .dgvDetalle.Rows.Add(dtDetalle.Rows(a)(1).ToString(), dtDetalle.Rows(a)(2).ToString(), dtDetalle.Rows(a)(3).ToString(), dtDetalle.Rows(a)(4).ToString(), dtDetalle.Rows(a)(5).ToString(), dtDetalle.Rows(a)(6).ToString(), dtDetalle.Rows(a)(7).ToString(), CInt(dtDetalle.Rows(a)(8).ToString()), dtDetalle.Rows(a)(9).ToString())
                    '.dgvDetalle.Rows(a).Cells("colSolicita").Value = CInt(dtDetalle.Rows(a)(8).ToString())
                Next
                .Show()
                .ControlBox = False
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
                .txtNumero.Text = numero
                .cargarSolicitantes(CInt(dtMaestro.Rows(0)(3).ToString()))
                .txtObservaciones.Text = dtMaestro.Rows(0)(4).ToString()
                .dtFecha.Text = dtMaestro.Rows(0)(2).ToString()
                If dtMaestro.Rows(0)(5).ToString() = "G" Then
                    .lblEstatus.Text = "Grabado"
                    .desbloquearDetalle()
                ElseIf dtMaestro.Rows(0)(5).ToString() = "A" Then
                    .lblEstatus.Text = "Aprobado"
                    .dgvDetalle.Columns(0).ReadOnly = True
                    .dgvDetalle.Columns(1).ReadOnly = True
                    .dgvDetalle.Columns(2).ReadOnly = True
                    .dgvDetalle.Columns(3).ReadOnly = True
                    .dgvDetalle.Columns(4).ReadOnly = True
                    .dgvDetalle.Columns(5).ReadOnly = True
                    .dgvDetalle.Columns(6).ReadOnly = True
                    .dgvDetalle.Columns(7).ReadOnly = True
                ElseIf dtMaestro.Rows(0)(5).ToString() = "T" Then
                    .lblEstatus.Text = "Cerrada"
                    .dgvDetalle.Columns(0).ReadOnly = True
                    .dgvDetalle.Columns(1).ReadOnly = True
                    .dgvDetalle.Columns(2).ReadOnly = True
                    .dgvDetalle.Columns(3).ReadOnly = True
                    .dgvDetalle.Columns(4).ReadOnly = True
                    .dgvDetalle.Columns(5).ReadOnly = True
                    .dgvDetalle.Columns(6).ReadOnly = True
                    .dgvDetalle.Columns(7).ReadOnly = True
                End If
                .cargarProductos(Nothing)
                .btnNuevo.Visible = False
                .btnSalir.Visible = False
                .btnAnular.Visible = True
                .btnModificar.Visible = True
                .btnSalirConsulta.Visible = True
            End With
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkPendientes.CheckedChanged
        If chkPendientes.Checked Then
            txtBuscar.Text = ""
            txtBuscar.ReadOnly = True
            cargarPendientes()
        Else
            txtBuscar.Text = ""
            txtBuscar.ReadOnly = False
            cargarDatos()
        End If
    End Sub

    Private Sub dgvDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            dgvDatos.Rows(i).Selected = True
        End If
    End Sub
End Class