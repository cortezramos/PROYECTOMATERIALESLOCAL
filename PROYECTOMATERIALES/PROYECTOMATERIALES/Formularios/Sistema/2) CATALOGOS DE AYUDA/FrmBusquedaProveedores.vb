Public Class FrmBusquedaProveedores
#Region "Controles"
    Sub cargarProveedores()
        dgvDatos.DataSource = clordenes.consultarProveedoresPantallaBusqueda()
        dgvDatos.Columns(0).Visible = False
    End Sub

    Sub buscarProveedores()
        dgvDatos.DataSource = clordenes.buscarProveedoresPantallaBusqueda(txtBuscar.Text)
        dgvDatos.Columns(0).Visible = False
    End Sub

#End Region
    Private clordenes As New clOrdenesCompra
    Public codigoseleccionado As Integer
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub FrmBusquedaProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarProveedores()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) Then
            cargarProveedores()
        Else
            buscarProveedores()
        End If
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            codigoseleccionado = CInt(dgvDatos.Item(0, i).Value.ToString())
            txtBuscar.Text = ""
            txtBuscar.Focus()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyValue = Keys.Enter Then
            If dgvDatos.Rows.Count > 0 Then
                Dim i As Integer = dgvDatos.CurrentRow.Index
                codigoseleccionado = CInt(dgvDatos.Item(0, i).Value.ToString())
                txtBuscar.Text = ""
                txtBuscar.Focus()
                Me.DialogResult = Windows.Forms.DialogResult.Yes
            End If
        End If
    End Sub
End Class