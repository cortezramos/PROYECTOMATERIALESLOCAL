Public Class FrmPedirFechas

    Public vFechaSeleccionada As Date

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        vFechaSeleccionada = dtFecha.Text
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("Desea salir sin seleccionar una fecha", "Desea salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            DialogResult = Windows.Forms.DialogResult.No
        Else
            Exit Sub
        End If
    End Sub
End Class