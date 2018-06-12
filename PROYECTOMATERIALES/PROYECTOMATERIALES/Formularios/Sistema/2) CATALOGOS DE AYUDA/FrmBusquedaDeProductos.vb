Public Class FrmBusquedaDeProductos
#Region "Controles"
    Sub consultarDatos()
        If dtConsultaProductos.Rows.Count = 0 Then
            dtConsultaProductos = clproductos.consultaProductosPantallaBusqueda()
        End If
        With dgvDatos
            .DataSource = dtConsultaProductos
            '.Columns(0).Width = 50
            '.Columns(1).Width = 200
            '.Columns(2).Width = 50
        End With
    End Sub

    Sub buscarDatos()
        Dim dv As DataView = dtConsultaProductos.DefaultView
        If dtConsultaProductos.Rows.Count > 0 Then
            dv.RowFilter = "Descripcion like '%" & txtBuscar.Text & "%' or Codigo like '%" & txtBuscar.Text & "%'"
        Else
            dtConsultaProductos = clproductos.consultaProductosPantallaBusqueda()
        End If

        With dgvDatos
            renderizarGrid()
            '.DataSource = clproductos.busquedaProductosPantallaBusqueda(txtBuscar.Text)
            .DataSource = dv
            .Columns(0).Width = 50
            .Columns(1).Width = 200
            .Columns(2).Width = 50
            .Columns(3).Width = 75
        End With
    End Sub

    Sub renderizarGrid()
        With dgvDatos
            '.DataSource = clproductos.busquedaProductosPantallaBusqueda(txtBuscar.Text)
            .Columns(0).Width += 50
            .Columns(1).Width += 200
            .Columns(2).Width += 50
            .Columns(3).Width += 75
        End With
    End Sub

#End Region

    Private clproductos As New clProductos
    Public codigoseleccion As String

    Public Sub FrmBusquedaDeProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarDatos()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If String.IsNullOrEmpty(txtBuscar.Text) Then
            consultarDatos()
        Else
            buscarDatos()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        txtBuscar.Text = ""
        txtBuscar.Focus()
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub

    Private Sub dgvDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
        If dgvDatos.Rows.Count > 0 Then
            Dim i As Integer = dgvDatos.CurrentRow.Index
            codigoseleccion = dgvDatos.Item(0, i).Value.ToString()
            txtBuscar.Text = ""
            txtBuscar.Focus()
            buscarDatos()
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyValue = Keys.Enter Then
            If dgvDatos.Rows.Count > 0 Then
                Dim i As Integer = dgvDatos.CurrentRow.Index
                codigoseleccion = dgvDatos.Item(0, i).Value.ToString()
                txtBuscar.Text = ""
                txtBuscar.Focus()
                buscarDatos()
                Me.DialogResult = Windows.Forms.DialogResult.Yes
            End If
        End If
    End Sub
End Class