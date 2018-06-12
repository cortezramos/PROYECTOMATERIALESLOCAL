Public Class FrmConfigSucursalSistema
#Region "Controles"
    Sub cargarSucursal()
        With cmbSucursal
            .DataSource = usuarios.seleccionSucursalSistema(empresaid, usuarioid)
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub
#End Region

    Private usuarios As New clsUsuarios

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSucursal()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If CInt(cmbSucursal.SelectedValue) > 0 Then
            sucursallog = CInt(cmbSucursal.SelectedValue)
            MsgBox("Cambio de sucursal correcto", MsgBoxStyle.Information, "Cambio de sucursal")
            Me.Close()
        Else
            MsgBox("Seleccione sucursal", MsgBoxStyle.Exclamation, "Validacion")
            cmbSucursal.Focus()
        End If
    End Sub
End Class