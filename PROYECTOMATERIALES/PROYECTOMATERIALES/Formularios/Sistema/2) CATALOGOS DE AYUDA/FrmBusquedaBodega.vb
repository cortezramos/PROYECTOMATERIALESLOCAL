Public Class FrmBusquedaBodega
#Region "Controles"
    Sub cargarBodegas()
        With cmbBodega
            .DataSource = clordenes.seleccionBodegaConsultaKardex()
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub
#End Region
    Private clordenes As New clOrdenesCompra
    Public Bodega As Integer
    Public Fechai As Date
    Private Sub FrmBusquedaBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarBodegas()
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            gbxGeneral.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Bodega = 0
        Fechai = Today
        If cmbBodega.SelectedIndex > 0 Then
            If CDate(dtFechaI.Text) < Today Then
                Bodega = cmbBodega.SelectedValue
                Fechai = CDate(dtFechaI.Text)
                dtFechaI.Value = Today
                DialogResult = Windows.Forms.DialogResult.Yes
            Else
                MsgBox("Fecha de inicio de consulta debe ser menor a fecha de hoy", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class