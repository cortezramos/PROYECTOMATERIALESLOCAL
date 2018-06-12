Public Class FrmConfigReportServer
#Region "Controles"
    Sub cargarConfiguracion()
        dgvDatos.DataSource = clconfigrs.consultarReportServer()
    End Sub

#End Region
    Private clconfigrs As New clConfigReportServer
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmConfigReportServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarConfiguracion()
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            txtUrl.Text = dgvDatos.Item(0, i).Value
            txtPath.Text = dgvDatos.Item(1, i).Value
            
            btnNuevo.Visible = False
            btnGuardar.Visible = False
            btnModificar.Visible = False
            btnEditar.Visible = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If dgvDatos.Rows.Count > 0 Then
            MsgBox("No puede agregar una configuracion nueva, ya existe una", MsgBoxStyle.Exclamation, "Validacion")
        Else
            txtUrl.Enabled = True
            txtPath.Enabled = True
            btnNuevo.Visible = False
            btnGuardar.Visible = True
            btnModificar.Visible = False
            btnEditar.Visible = False
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        txtUrl.Enabled = True
        txtPath.Enabled = True

        btnNuevo.Visible = False
        btnGuardar.Visible = False
        btnModificar.Visible = True
        btnEditar.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrEmpty(txtUrl.Text) = False Then
            If String.IsNullOrEmpty(txtPath.Text) = False Then
                clconfigrs.insertarReportServer(txtUrl.Text, txtPath.Text)
                cargarConfiguracion()
                txtUrl.Text = ""
                txtPath.Text = ""
                txtUrl.Enabled = False
                txtPath.Enabled = False
                btnNuevo.Visible = True
                btnGuardar.Visible = False
                btnModificar.Visible = False
                btnEditar.Visible = False
                MsgBox("Se guardaron los datos de configuracion", MsgBoxStyle.Information, "Proceso exitoso")
            Else
                MsgBox("Ingrese Path de Report Server", MsgBoxStyle.Exclamation, "Error de ingreso")
            End If
        Else
            MsgBox("Ingrese URL de Report Server", MsgBoxStyle.Exclamation, "Error de ingreso")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If String.IsNullOrEmpty(txtUrl.Text) = False Then
            If String.IsNullOrEmpty(txtPath.Text) = False Then
                clconfigrs.modificarReportServer(txtUrl.Text, txtPath.Text)
                cargarConfiguracion()
                txtUrl.Text = ""
                txtPath.Text = ""
                txtUrl.Enabled = False
                txtPath.Enabled = False
                btnNuevo.Visible = True
                btnGuardar.Visible = False
                btnModificar.Visible = False
                btnEditar.Visible = False
                MsgBox("Se modificaron los datos de configuracion", MsgBoxStyle.Information, "Proceso exitoso")
            Else
                MsgBox("Ingrese Path de Report Server", MsgBoxStyle.Exclamation, "Error de ingreso")
            End If
        Else
            MsgBox("Ingrese URL de Report Server", MsgBoxStyle.Exclamation, "Error de ingreso")
        End If
    End Sub
End Class