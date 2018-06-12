Public Class FrmIngresoBodega
#Region "Controles"
    Sub cargarBodega(Valor As Integer)
        If Valor <> Nothing Then
            With cmbBodega
                .DataSource = clordenes.seleccionBodegaConsultaKardex()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbBodega
                .DataSource = clordenes.seleccionBodegaConsultaKardex()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Sub consultarOrdenesPendientes()
        With dgvPendientes
            .DataSource = clingresos.consultarOrdenesProductosPendientes(vProducto)
            .Columns(0).Width = 60
        End With
    End Sub

    Sub buscarOrdenesPendientes()
        With dgvPendientes
            .DataSource = clingresos.buscarOrdenCompraPorNumero(txtBuscar.Text)
            .Columns(0).Width = 60
        End With
    End Sub

    Sub cargarDetalle()
        With dgvDetalle
            .DataSource = clingresos.consultarProductosPendientesIngreso(CInt(txtOrden.Text))
        End With
        renderizarGrid()
        disenoGrid()
    End Sub

    Sub cargarVistaPrevia()
        With dgvVista
            .DataSource = clingresos.consultarProductosPendientesVistaPrevia(CInt(txtOrden.Text))
            .Columns(0).Width = 75
        End With
    End Sub

    Sub disenoGrid()
        If dgvDetalle.Rows.Count > 0 Then
            With dgvDetalle
                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = True
                .Columns(6).ReadOnly = True
                .Columns(0).Width = 50
                .Columns(1).Width = 50
                .Columns(3).Width = 50
                .Columns(4).Width = 50
                .Columns(5).Width = 75
                .Columns(6).Visible = False
                .Columns(4).DefaultCellStyle.BackColor = Color.Khaki
                .Columns(5).DefaultCellStyle.BackColor = Color.Khaki
            End With
        End If
    End Sub

    Sub renderizarGrid()
        If dgvDetalle.Rows.Count > 0 Then
            With dgvDetalle
                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = True
                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 150
                .Columns(4).DefaultCellStyle.BackColor = Color.Khaki
                .Columns(5).DefaultCellStyle.BackColor = Color.Khaki
            End With
        End If
    End Sub

    Sub bloquear()
        txtBuscar.Enabled = False
        dgvPendientes.Enabled = False
        chkOrdenes.Enabled = False
        chkEnvios.Enabled = False
        cmbBodega.Enabled = False
    End Sub

    Sub desbloquear()
        txtBuscar.Enabled = True
        dgvPendientes.Enabled = True
        chkOrdenes.Enabled = True
        chkEnvios.Enabled = True
        cmbBodega.Enabled = True
    End Sub

    Sub consultarNumero()
        txtNumero.Text = CInt(txtOrden.Text)
        txtIngreso.Text = clingresos.ultimoNumeroIngreso(CInt(txtNumero.Text))
    End Sub

    Function validarCampos() As Boolean
        If cmbBodega.SelectedValue <= 0 Then
            MsgBox("Seleccione bodega para el ingreso", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        ElseIf dgvDetalle.Rows.Count <= 0 Then
            MsgBox("Debe estar consultado por lo menos un producto", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        Else
            Dim validar As Integer = 0
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If CBool(dgvDetalle.Item(5, i).Value) = True Then
                    validar += 1
                End If
            Next
            If validar = 0 Then
                MsgBox("Debe seleccionar por lo menos un producto para dar ingreso", MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            End If
        End If
        Return True
    End Function

    Function consultarFechasParametro() As Boolean
        Dim dtConsulta As DataTable = clordenes.consultarFechasParametros(CInt(txtNumero.Text))
        If dtConsulta.Rows.Count > 0 Then
            vFechaOrden = dtConsulta.Rows(0)(0).ToString()
            vFechaCierre = dtConsulta.Rows(0)(1).ToString()
            vFechaActual = dtConsulta.Rows(0)(2).ToString()
        Else
            Return False
        End If
        Return True
    End Function

    Function validacionFechas() As Boolean
        vFechaAnulacion = Today
        If consultarFechasParametro() Then
            If vFechaAnulacion < vFechaCierre Then
                MsgBox("Fecha de ingreso no puede ser menor a fecha de Cierre " & vFechaCierre, MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            ElseIf vFechaAnulacion > vFechaActual Then
                MsgBox("Fecha de ingreso no puede ser posterior a la fecha Actual", MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            End If
        Else
            MsgBox("No es posible consultar fechas", MsgBoxStyle.Exclamation, "Error de sistema")
            Return False
        End If
        Return True
    End Function

    Function validarDatos() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CBool(dgvDetalle.Item(5, i).Value) = True Then
                If dgvDetalle.Item(4, i).Value > dgvDetalle.Item(3, i).Value Then
                    MsgBox("No puede ingresar mas de la cantidad pendiente del producto " & dgvDetalle.Item(2, i).Value, MsgBoxStyle.Exclamation, "Advertencia")
                    Return False
                ElseIf dgvDetalle.Item(4, i).Value <= 0 Then
                    MsgBox("Cantidad a ingresar debe ser mayor a 0" & dgvDetalle.Item(2, i).Value, MsgBoxStyle.Exclamation, "Advertencia")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Sub correoPendientes()
        Dim Producto As String = ""
        Dim Solicitud As String = ""
        vListaPendientes = ""
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CBool(dgvDetalle.Item(5, i).Value) = True Then
                If CDec(dgvDetalle.Item(4, i).Value) < CDec(dgvDetalle.Item(3, i).Value) Then
                    Producto = dgvDetalle.Item(2, i).Value
                    Solicitud = CStr(dgvDetalle.Item(6, i).Value)
                    If CInt(txtIngreso.Text) > 1 Then
                        Producto = Producto.Substring(0, (Producto.Length - Solicitud.Length) - 1)
                    End If
                    vListaPendientes = vListaPendientes & "Producto " & dgvDetalle.Item(1, i).Value & " " & Producto & " ingresaron " _
                        & dgvDetalle.Item(4, i).Value & " de " & dgvDetalle.Item(3, i).Value & "<br/> "
                End If
            End If
        Next
        If String.IsNullOrEmpty(vListaPendientes) = False Then
            clcorreos.enviarCorreo("Bodega", "Se informa del Ingreso parcial de los siguientes productos: <br/> <br/> Orden " & CInt(txtNumero.Text) & " Ingreso " & CInt(txtIngreso.Text) & "<br/>" & vListaPendientes & "<br/>")
        End If
    End Sub

    Function guardarMaestro() As Boolean
        If clingresos.insertarIngresoMaestro(CInt(txtNumero.Text), CInt(txtIngreso.Text), CDate(dtFecha.Text), CInt(cmbBodega.SelectedValue)) = False Then
            Return False
        End If
        Return True
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CBool(dgvDetalle.Item(5, i).Value) = True Then
                If clingresos.insertarIngresoDetalle(CInt(txtNumero.Text), dgvDetalle.Item(1, i).Value, CInt(txtIngreso.Text), dgvDetalle.Item(2, i).Value & " " & dgvDetalle.Item(6, i).Value, CDec(dgvDetalle.Item(4, i).Value), CInt(dgvDetalle.Item(6, i).Value)) = False Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Sub imprimirIngreso()
        Dim frm As New RptIngreso
        With frm
            .Numero = CInt(txtNumero.Text)
            .Ingreso = CInt(txtIngreso.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

    Private clordenes As New clOrdenesCompra
    Private clingresos As New clIngresoBodega
    Private clcorreos As New clCorreos
    Private vProducto As Integer = 0
    Private vFechaAnulacion As Date
    Private vFechaOrden As Date
    Private vFechaCierre As Date
    Private vFechaActual As Date
    Private vListaPendientes As String

    Private Sub FrmIngresoBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarOrdenesPendientes()
        desbloquear()
        cargarBodega(Nothing)
        chkOrdenes.Checked = True
        tbIngreso.Parent = Nothing
        btnConsultar.Visible = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados, desea salir sin guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub chkOrdenes_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrdenes.CheckedChanged
        If chkOrdenes.Checked = True Then
            chkEnvios.Checked = False
        Else
            chkEnvios.Checked = True
        End If
    End Sub

    Private Sub chkEnvios_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnvios.CheckedChanged
        If chkEnvios.Checked = True Then
            chkOrdenes.Checked = False
        Else
            chkOrdenes.Checked = True
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If txtOrden.Text <> "" Then
            If CInt(txtOrden.Text) > 0 Then
                lblSeleccion.Text = ""
                tbIngreso.Parent = tabControl
                tbConsulta.Parent = Nothing
                btnGuardar.Visible = True
                btnConsultar.Visible = False
                btnSeleccion.Visible = True
                bloquear()
                cmbBodega.Enabled = True
                cmbBodega.Focus()
                consultarNumero()
                cargarDetalle()
            Else
                MsgBox("Seleccione orden a ingresar en el panel izquierdo", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione orden a ingresar en el panel izquierdo", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnSeleccion_Click(sender As Object, e As EventArgs) Handles btnSeleccion.Click
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                dgvDetalle.Item(5, i).Value = True
            Next
        End If
    End Sub

    Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            dgvDetalle.Rows(i).Selected = True
        End If
    End Sub

    Private Sub dgvDetalle_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            dgvDetalle.Rows(i).Selected = True
        End If
    End Sub

    Private Sub dgvDetalle_KeyDown(sender As Object, e As KeyEventArgs)
        If dgvDetalle.Rows.Count > 0 Then
            If e.KeyValue = Keys.Space Then
                Dim i As Integer = dgvDetalle.CurrentRow.Index
                If CBool(dgvDetalle.Item(5, i).Value) = True Then
                    dgvDetalle.Item(5, i).Value = False
                Else
                    dgvDetalle.Item(5, i).Value = True
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        vProducto = 0
        consultarOrdenesPendientes()
        chkOrdenes.Checked = True
        txtNumero.Text = ""
        txtOrden.Text = 0
        txtIngreso.Text = ""
        btnGuardar.Visible = False
        btnConsultar.Visible = True
        btnSeleccion.Visible = False
        cargarVistaPrevia()
        cargarDetalle()
        desbloquear()
        tbIngreso.Parent = Nothing
        tbConsulta.Parent = tabControl
    End Sub

    Private Sub dgvPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendientes.CellClick
        If dgvPendientes.Rows.Count > 0 Then
            Dim i As Integer = dgvPendientes.CurrentRow.Index
            txtOrden.Text = dgvPendientes.Item(0, i).Value
            lblSeleccion.Text = dgvPendientes.Item(1, i).Value
            dgvPendientes.Rows(i).Selected = True
            cargarVistaPrevia()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyValue = Keys.F7 Then
            txtBuscar.Text = ""
            txtOrden.Text = 0
            cargarVistaPrevia()
            Dim frm As New FrmBusquedaDeProductos
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    vProducto = .codigoseleccion
                    consultarOrdenesPendientes()
                Else
                    MsgBox("No se selecciono ningun producto", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End With
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text <> "" Then
            txtOrden.Text = 0
            cargarVistaPrevia()
            buscarOrdenesPendientes()
        Else
            txtOrden.Text = 0
            cargarVistaPrevia()
            consultarOrdenesPendientes()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lblNumero.Focus()
        If validarCampos() Then
            If validacionFechas() Then
                If validarDatos() Then
                    BeginTransaction()
                    If guardarMaestro() Then
                        If guardarDetalle() Then
                            If clingresos.ejecutarIngresoCompra(CInt(txtNumero.Text), CInt(txtIngreso.Text)) Then
                                CommitTransaction()
                                MsgBox("Ingreso realizado correctamente", MsgBoxStyle.Information, "Aviso")
                                correoPendientes()
                                If MessageBox.Show("Desea imprimir ingreso?", "Imprimir ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                    imprimirIngreso()
                                End If
                                btnCancelar_Click(sender, e)
                                desbloquear()
                            Else
                                MsgBox("Ocurrio un error al guardar los datos, No se completara la transaccion", MsgBoxStyle.Exclamation, "Error de sistema")
                                RollBackTransaction()
                            End If
                        Else
                            MsgBox("Ocurrio un error al guardar los datos, No se completara la transaccion", MsgBoxStyle.Exclamation, "Error de sistema")
                            RollBackTransaction()
                        End If
                    Else
                        MsgBox("Ocurrio un error al guardar los datos, No se completara la transaccion", MsgBoxStyle.Exclamation, "Error de sistema")
                        RollBackTransaction()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown = True Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos consultados desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaIngresoBodega
                With frm
                    .ControlBox = False
                    .Show()
                    .MdiParent = Me.MdiParent
                    .Location = New Point(302, 2)
                End With
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Dim frm As New FrmBusquedaIngresoBodega
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        End If
    End Sub
End Class