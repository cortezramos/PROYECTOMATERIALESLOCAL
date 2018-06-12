Public Class FrmOrdenCompra
#Region "Controles"
    Sub cargarProveedores(Valor As Integer)
        If Valor <> Nothing Then
            With cmbProveedor
                .DataSource = clordenes.consultarProveedoresParaCombo()
                .DisplayMember = "Nombre"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbProveedor
                .DataSource = clordenes.consultarProveedoresParaCombo()
                .DisplayMember = "Nombre"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub cargarMoneda(Valor As Integer)
        If Valor <> Nothing Then
            With cmbMoneda
                .DataSource = clproductos.consultarTipoMoneda()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbMoneda
                .DataSource = clproductos.consultarTipoMoneda()
                .DisplayMember = "Descripcion"
                .ValueMember = "Codigo"
            End With
        End If
    End Sub

    Sub cargarSolicitudesPendientes()
        With cmbSolicitud
            .DataSource = clordenes.consultarOrdenesPendientesCompras()
            .ValueMember = "Numero"
            .DisplayMember = "Nombre"
        End With
    End Sub

    Sub bloquear()
        cmbProveedor.Enabled = False
        txtAtencion.Enabled = False
        txtObservaciones.Enabled = False
        cmbMoneda.Enabled = False
        txtTipoCambio.Enabled = False
        cmbSolicitud.Enabled = False
    End Sub

    Sub desbloquear()
        cmbProveedor.Enabled = True
        txtAtencion.Enabled = True
        txtObservaciones.Enabled = True
        cmbMoneda.Enabled = True
        cmbSolicitud.Enabled = True
    End Sub

    Sub cargarDetalle()
        dtDetalleOrdenes = New DataTable
        Dim Numero As New DataColumn("Numero", Type.GetType("System.String"))
        Dim Codigo As New DataColumn("Codigo", Type.GetType("System.String"))
        Dim Descripcion As New DataColumn("Descripcion", Type.GetType("System.String"))
        Dim Cantidad As New DataColumn("Cantidad Solicitada", Type.GetType("System.Decimal"))
        Dim PrecioUCompra As New DataColumn("Precio Ultima Compra", Type.GetType("System.Decimal"))
        Dim CantidadC As New DataColumn("Cantidad a Comprar", Type.GetType("System.Decimal"))
        Dim Precio As New DataColumn("Precio a Pagar", Type.GetType("System.Decimal"))
        Dim Observaciones As New DataColumn("Observaciones", Type.GetType("System.String"))
        Dim Estado As New DataColumn("Estado", Type.GetType("System.String"))

        dtDetalleOrdenes.Columns.Add(Numero)
        dtDetalleOrdenes.Columns.Add(Codigo)
        dtDetalleOrdenes.Columns.Add(Descripcion)
        dtDetalleOrdenes.Columns.Add(Cantidad)
        dtDetalleOrdenes.Columns.Add(PrecioUCompra)
        dtDetalleOrdenes.Columns.Add(CantidadC)
        dtDetalleOrdenes.Columns.Add(Precio)
        dtDetalleOrdenes.Columns.Add(Observaciones)
        dtDetalleOrdenes.Columns.Add(Estado)
    End Sub

    Sub gridDetalle()
        With dgvDetalle
            .DataSource = dtDetalleOrdenes
            .Columns(0).Visible = False
            .Columns(8).Visible = False
            .Columns(1).Width = 75
            .Columns(2).Width = 300
            .Columns(3).Width = 75
            .Columns(4).Width = 75
            .Columns(5).Width = 75
            .Columns(6).Width = 75
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).DefaultCellStyle.BackColor = Color.Khaki
            .Columns(6).DefaultCellStyle.BackColor = Color.Khaki
            .Columns(7).DefaultCellStyle.BackColor = Color.Khaki
        End With
    End Sub

    Sub bloqueoGridConsulta()
        With dgvDetalle
            If lblEstatus.Text = "Grabado" Then
                cmbSolicitud.Enabled = True
                .Columns(6).ReadOnly = False
                .Columns(7).ReadOnly = False
            Else
                cmbSolicitud.Enabled = False
                .Columns(6).ReadOnly = True
                .Columns(7).ReadOnly = True
            End If
            .Columns(5).ReadOnly = True
            .Columns(5).DefaultCellStyle.BackColor = Color.Khaki
            .Columns(6).DefaultCellStyle.BackColor = Color.Khaki
            .Columns(7).DefaultCellStyle.BackColor = Color.Khaki
        End With
    End Sub

    Function eliminarDetalle() As Boolean
        If clordenes.eliminarOrdenDetalle(CInt(txtNumero.Text)) = False Then
            Return False
        End If
        Return True
    End Function


    Sub obtenerNumero()
        txtNumero.Text = clordenes.consultarUltimoNumeroOrdenCompra()
    End Sub

    Function camposVacios() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If IsDBNull(dgvDetalle.Item(5, i).Value) Then
                MsgBox("Campo cantidad en el detalle se encuentran vacio, favor ingresar una cantidad", MsgBoxStyle.Exclamation, "Advertencia")
                dgvDetalle.Rows(i).Selected = True
                Return False
            ElseIf IsDBNull(dgvDetalle.Item(6, i).Value) Then
                MsgBox("Campo precio en el detalle se encuentran vacio, favor ingresar un precio", MsgBoxStyle.Exclamation, "Advertencia")
                dgvDetalle.Rows(i).Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Function validarCampos() As Boolean
        If cmbProveedor.SelectedValue <= 0 Then
            MsgBox("Seleccione proveedor", MsgBoxStyle.Exclamation, "Error de validacion")
            cmbProveedor.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNumero.Text) Then
            MsgBox("Debe existir numero de orden de compra para operarse", MsgBoxStyle.Exclamation, "Error de validacion")
            txtNumero.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtAtencion.Text) Then
            MsgBox("Ingrese nombre de persona que atiende la compra", MsgBoxStyle.Exclamation, "Error de validacion")
            txtAtencion.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtObservaciones.Text) Then
            MsgBox("Ingrese almenos una observacion sobre la compra", MsgBoxStyle.Exclamation, "Error de validacion")
            txtObservaciones.Focus()
            Return False
        ElseIf cmbMoneda.SelectedValue <= 0 Then
            MsgBox("Seleccione moneda para orden de compra", MsgBoxStyle.Exclamation, "Error de validacion")
            cmbMoneda.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtTipoCambio.Text) Then
            MsgBox("Ingrese tipo de cambio para orden de compra", MsgBoxStyle.Exclamation, "Error de validacion")
            txtTipoCambio.Focus()
            Return False
        ElseIf CDec(txtTipoCambio.Text) <= 0 Then
            MsgBox("Ingrese tipo de cambio para orden de compra", MsgBoxStyle.Exclamation, "Error de validacion")
            txtTipoCambio.Focus()
            Return False
        ElseIf dgvDetalle.Rows.Count <= 0 Then
            MsgBox("Ingrese materiales para esta solicitud de compra", MsgBoxStyle.Exclamation, "Error de validacion")
            cmbSolicitud.Focus()
            Return False
        ElseIf camposVacios() = False Then
            Return False
        End If
        Return True
    End Function

    Function guardarMaestro() As Boolean
        BeginTransaction()
        If clordenes.insertarOrdenMaestro(CInt(txtNumero.Text), CDate(dtFecha.Text), CInt(cmbProveedor.SelectedValue), txtAtencion.Text, txtObservaciones.Text, CInt(cmbMoneda.SelectedValue), CDec(txtTipoCambio.Text), CInt(dgvDetalle.Item(0, 0).Value)) Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Function guardarDetalle() As Boolean
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If IsDBNull(dgvDetalle.Item(7, i).Value) Then
                    dgvDetalle.Item(7, i).Value = "."
                    lblNumero.Focus()
                ElseIf dgvDetalle.Item(7, i).Value = "" Then
                    dgvDetalle.Item(7, i).Value = "."
                    lblNumero.Focus()
                End If
                If clordenes.insertarOrdenDetalle(CInt(txtNumero.Text), dgvDetalle.Item(1, i).Value, dgvDetalle.Item(2, i).Value, CDec(dgvDetalle.Item(5, i).Value), CDec(dgvDetalle.Item(6, i).Value), CInt(dgvDetalle.Item(0, i).Value), dgvDetalle.Item(7, i).Value) = False Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Sub confirmarMaestroSolicitud()
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If clsolicitudes.consultarDetalleProductosPendientes(dgvDetalle.Item(0, i).Value) = 0 Then
                BeginTransaction()
                If clsolicitudes.cambiarEstadoSolicitudMaestro(dgvDetalle.Item(0, i).Value, "T") Then
                    CommitTransaction()
                Else
                    RollBackTransaction()
                End If
            End If
        Next
    End Sub

    Function confirmarDetalleSolicitud() As Boolean
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If clsolicitudes.cambiarEstadoSolicitudDetallePorProducto(CInt(dgvDetalle.Item(0, i).Value), dgvDetalle.Item(8, i).Value, dgvDetalle.Item(1, i).Value) = False Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Function verificarDiferenciasProducto() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If Decimal.Round(CDec(dgvDetalle.Item(5, i).Value), 2) > 0 Then
                If CDec(dgvDetalle.Item(3, i).Value) - CDec(dgvDetalle.Item(5, i).Value) > 0 Then
                    If MessageBox.Show("Se comprara menos de lo solicitado del Producto? " & dgvDetalle.Item(2, i).Value, "Comprara menos?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        If MessageBox.Show("Desea dejar pendiente el saldo de solicitud de producto?", "Pendiente saldo?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                            dtDetalleOrdenes.Rows(i).Item("Estado") = "A"
                            lblAtencion.Focus()
                        End If
                    Else
                        dgvDetalle.Rows(i).Selected = True
                        Return False
                    End If
                End If
            Else
                MsgBox("Ingrese cantidad de compra para producto cantidad debe ser mayor a cero, verifique decimales solamente pueden ser dos " & dgvDetalle.Item(2, i).Value, MsgBoxStyle.Exclamation, "Error de validacion")
                dgvDetalle.Rows(i).Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Function verificarPrecio() As Boolean
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If CDec(dgvDetalle.Item(6, i).Value) >= 0 Then
                    If CDec(dgvDetalle.Item(6, i).Value) = 0 Then
                        If MessageBox.Show("Guardara con precio 0 el producto " & dgvDetalle.Item(2, i).Value, "Valor cero?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                            Return False
                        End If
                    End If
                Else
                    MsgBox("Precio debe ser mayor a cero", MsgBoxStyle.Exclamation, "Error de validacion")
                    dgvDetalle.Rows(i).Selected = True
                    Return False
                End If
            Next
        Else
            MsgBox("No existen datos a comparar")
            Return False
        End If
        Return True
    End Function

    Function verificarCantidadPendienteProducto() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If Decimal.Round(CDec(dgvDetalle.Item(5, i).Value), 2) > 0 Then
                cantidadPendiente = clordenes.verificarCantidadPorProductoSolicitado(CInt(dgvDetalle.Item(1, i).Value), CInt(dgvDetalle.Item(0, i).Value))
                If cantidadPendiente > 0 Then
                    If cantidadPendiente - CDec(dgvDetalle.Item(5, i).Value) < 0 Then
                        MsgBox("Producto " & dgvDetalle.Item(2, i).Value & " solamente tiene saldo de solicitud pendiente por " & cantidadPendiente & " unidades", MsgBoxStyle.Exclamation, "Error de validacion")
                        dgvDetalle.Item(3, i).Value = cantidadPendiente
                        lblNumero.Focus()
                        dgvDetalle.Rows(i).Selected = True
                        Return False
                    End If
                Else
                    MsgBox("Producto " & dgvDetalle.Item(2, i).Value & " no tiene saldo de solicitud pendiente", MsgBoxStyle.Exclamation, "Error de validacion")
                    dgvDetalle.Item(3, i).Value = cantidadPendiente
                    lblNumero.Focus()
                    dgvDetalle.Rows(i).Selected = True
                    Return False
                End If
            Else
                MsgBox("Ingrese cantidad de compra para producto cantidad debe ser mayor a cero, verifique decimales solamente pueden ser dos " & dgvDetalle.Item(2, i).Value, MsgBoxStyle.Exclamation, "Error de validacion")
                dgvDetalle.Rows(i).Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Function verificarCantidadPendienteProductoModificacion() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CDec(dgvDetalle.Item(5, i).Value) > 0 Then
                cantidadPendiente = clordenes.verificarCantidadPorProductoSolicitadoModificar(CInt(dgvDetalle.Item(1, i).Value), CInt(dgvDetalle.Item(0, i).Value), CInt(txtNumero.Text))
                If cantidadPendiente > 0 Then
                    If cantidadPendiente - CDec(dgvDetalle.Item(5, i).Value) < 0 Then
                        MsgBox("Producto " & dgvDetalle.Item(2, i).Value & " solamente tiene saldo de solicitud pendiente por " & cantidadPendiente & " unidades", MsgBoxStyle.Exclamation, "Error de validacion")
                        dgvDetalle.Item(3, i).Value = cantidadPendiente
                        lblNumero.Focus()
                        dgvDetalle.Rows(i).Selected = True
                        Return False
                    End If
                Else
                    MsgBox("Producto " & dgvDetalle.Item(2, i).Value & " no tiene saldo de solicitud pendiente", MsgBoxStyle.Exclamation, "Error de validacion")
                    dgvDetalle.Item(3, i).Value = cantidadPendiente
                    lblNumero.Focus()
                    dgvDetalle.Rows(i).Selected = True
                    Return False
                End If
            Else
                MsgBox("Ingrese cantidad de compra para Producto " & dgvDetalle.Item(2, i).Value)
                dgvDetalle.Rows(i).Selected = True
                Return False
            End If
        Next
        Return True
    End Function

    Function anularOrdenCompra() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If clsolicitudes.cambiarEstadoSolicitudMaestro(CInt(dtDetalleOrdenes.Rows(i)(0).ToString()), "A") Then
                If clsolicitudes.cambiarEstadoSolicitudDetallePorProducto(CInt(dtDetalleOrdenes.Rows(i)(0).ToString()), "A", dtDetalleOrdenes.Rows(i)(1).ToString()) = False Then
                    Return False
                End If
            Else
                Return False
            End If
        Next
        Return True
    End Function

    Public Sub sumarPrecios()
        If dgvDetalle.Rows.Count > 0 Then
            Dim suma As Decimal = 0
            Dim multiplicacion As Decimal = 0
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                multiplicacion = CDec(dgvDetalle.Item(6, i).Value) * CDec(dgvDetalle.Item(5, i).Value)
                suma += multiplicacion
                multiplicacion = 0
            Next
            txtTotal.Text = suma
        End If
    End Sub

    Function modificarMaestro() As Boolean
        If clordenes.modificarOrdenMaestro(CInt(txtNumero.Text), CInt(cmbProveedor.SelectedValue), txtAtencion.Text, txtObservaciones.Text, CInt(cmbMoneda.SelectedValue), CDec(txtTipoCambio.Text)) = False Then
            Return False
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

    Function fechaAnulacion() As Boolean
        Dim frm As New FrmPedirFechas
        With frm
            .StartPosition = FormStartPosition.CenterParent
            If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                vFechaAnulacion = .vFechaSeleccionada
            Else
                Return False
            End If
        End With
        If consultarFechasParametro() Then
            If vFechaAnulacion < vFechaCierre Then
                MsgBox("Fecha de Anulacion ingresada " & vFechaAnulacion & " no puede ser menor a fecha de Cierre " & vFechaCierre, MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            ElseIf vFechaAnulacion < vFechaOrden Then
                MsgBox("Fecha de Anulacion ingresada " & vFechaAnulacion & ", no puede ser menor a fecha de Orden", MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            ElseIf vFechaAnulacion > vFechaActual Then
                MsgBox("Fecha de Anulacion ingresada " & vFechaAnulacion & " no puede ser posterior a la fecha Actual", MsgBoxStyle.Exclamation, "Advertencia")
                Return False
            End If
        Else
            MsgBox("No es posible consultar fechas", MsgBoxStyle.Exclamation, "Error de sistema")
            Return False
        End If
        Return True
    End Function

    Sub imprimirOrden()
        Dim frm As New RptOrdenCompra
        With frm
            .Numero = CInt(Me.txtNumero.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region
    Private clordenes As New clOrdenesCompra
    Private clproductos As New clProductos
    Private clsolicitudes As New clSolicitudMateriales
    Private cantidadPendiente As Decimal
    Private indiceGrid As Integer
    Private vSolicitud As Integer
    Private vFechaAnulacion As Date
    Private vFechaOrden As Date
    Private vFechaCierre As Date
    Private vFechaActual As Date

    Private Sub FrmOrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cargarProveedores(Nothing)
        cargarMoneda(Nothing)
        txtTipoCambio.Text = "1.000"
        lblEstatus.Text = ""
        btnNuevo.Visible = False
        btnGuardar.Visible = True
        btnAnular.Visible = False
        cargarSolicitudesPendientes()
        cargarDetalle()
        obtenerNumero()
        desbloquear()
    End Sub

    Private Sub cmbProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProveedor.KeyDown
        If e.KeyValue = Keys.F7 Then
            Dim frm As New FrmBusquedaProveedores
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    cargarProveedores(.codigoseleccionado)
                Else
                    MsgBox("No se selecciono ningun proveedor", MsgBoxStyle.Exclamation, "Error de ingreso de datos")
                End If
            End With
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        cargarSolicitudesPendientes()
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos sin guardar, desea salir?", "Existen datos ingresados!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmbSolicitud_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbSolicitud.MouseWheel
        If cmbSolicitud.DroppedDown Then
            Exit Sub
        Else
            cmbSolicitud.SelectedIndex = -1
            lblSolicitud.Focus()
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                If txtTipoCambio.Text.Length = 3 Then
                    If Not txtTipoCambio.Text.IndexOf(".") Then
                        e.Handled = False
                        toolDecimal.Active = True
                    Else
                        e.Handled = True
                    End If
                Else
                    e.Handled = False
                    txtTipoCambio.MaxLength = 9
                End If
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtTipoCambio.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lblNumero.Focus()
        If validarCampos() Then
            If verificarCantidadPendienteProducto() Then
                If verificarPrecio() Then
                    If verificarDiferenciasProducto() Then
                        obtenerNumero()
                        If guardarMaestro() Then
                            BeginTransaction()
                            If guardarDetalle() Then
                                If confirmarDetalleSolicitud() Then
                                    CommitTransaction()
                                    confirmarMaestroSolicitud()
                                    cargarProveedores(Nothing)
                                    cargarMoneda(Nothing)
                                    cargarSolicitudesPendientes()
                                    txtTipoCambio.Text = "1.000"
                                    txtAtencion.Text = ""
                                    lblEstatus.Text = ""
                                    txtObservaciones.Text = ""
                                    btnNuevo.Visible = True
                                    btnGuardar.Visible = False
                                    btnAnular.Visible = False
                                    MsgBox("Orden de compra guardada con exito", MsgBoxStyle.Information)
                                    If MessageBox.Show("Desea imprimir orden", "Imprimir?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                        imprimirOrden()
                                    End If
                                    cargarDetalle()
                                    gridDetalle()
                                    obtenerNumero()
                                    bloquear()
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se pudo realizar la operacion detalle compra porque no se pudo confirmar detalle de solicitud", MsgBoxStyle.Exclamation, "Error de sistema")
                                End If
                            Else
                                RollBackTransaction()
                                clordenes.eliminarOrdenMaestro(CInt(txtNumero.Text))
                                MsgBox("Error en procedimiento, no se guardaran los datos ingresados", MsgBoxStyle.Exclamation, "Error de sistema")
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtAtencion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtencion.KeyPress
        If txtAtencion.Text.Length = 50 Then
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If txtAtencion.Text.Length = 300 Then
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub AnularItemToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnularItemToolStripMenuItem1.Click
        If lblEstatus.Text = "Aprobado" Then
            MsgBox("No puede editar items, aprobados", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf lblEstatus.Text = "Anulada" Then
            MsgBox("No puede editar items, anulados", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf lblEstatus.Text = "Cerrada" Then
            MsgBox("No puede editar items, terminados", MsgBoxStyle.Exclamation, "Validacion")
        Else
            If MessageBox.Show("Desa quitar este Producto: " & dgvDetalle.Item(1, indiceGrid).Value & " " & dgvDetalle.Item(2, indiceGrid).Value, "Anular?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                vSolicitud = CInt(dgvDetalle.Item(0, indiceGrid).Value)
                If btnModificar.Visible = True Then
                    BeginTransaction()
                    If clsolicitudes.cambiarEstadoSolicitudMaestro(CInt(dtDetalleOrdenes.Rows(indiceGrid)(0).ToString()), "A") Then
                        If clsolicitudes.cambiarEstadoSolicitudDetallePorProducto(CInt(dtDetalleOrdenes.Rows(indiceGrid)(0).ToString()), "A", dtDetalleOrdenes.Rows(indiceGrid)(1).ToString()) Then
                            CommitTransaction()
                            cargarSolicitudesPendientes()
                            cmbSolicitud.SelectedValue = vSolicitud
                        Else
                            RollBackTransaction()
                            MsgBox("No se puede completar la anulacion de detalle de solicitud", MsgBoxStyle.Exclamation, "Error de sistema")
                        End If
                    Else
                        RollBackTransaction()
                        MsgBox("No se pudo completar la anulacion de solicitud", MsgBoxStyle.Exclamation, "Error de sistema")
                    End If
                End If
                dtDetalleOrdenes.Rows(indiceGrid).Delete()
                cmbSolicitud.Focus()
                lblAtencion.Focus()
            End If
        End If
    End Sub

    Private Sub dgvDetalle_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvDetalle.MouseDown
        If dgvDetalle.Rows.Count > 0 Then
            Dim gridInfo As DataGridView.HitTestInfo = dgvDetalle.HitTest(e.X, e.Y)
            If gridInfo.Type = DataGridViewHitTestType.Cell Then
                If gridInfo.RowIndex >= 0 Then
                    indiceGrid = gridInfo.RowIndex
                    dgvDetalle.CurrentCell = dgvDetalle.Rows(gridInfo.RowIndex).Cells(gridInfo.ColumnIndex)
                    dgvDetalle.Rows(gridInfo.RowIndex).Selected = True
                    If lblEstatus.Text = "Aprobado" Then
                        AnularProductoToolStripMenuItem.Visible = True
                        AnularItemToolStripMenuItem1.Visible = False
                    End If
                    dgvDetalle.ContextMenuStrip = menuContext
                End If
            End If
        End If
    End Sub

    Private Sub cmbMoneda_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbMoneda.MouseWheel
        If cmbMoneda.DroppedDown Then
            Exit Sub
        Else
            cmbMoneda.SelectedIndex = -1
            lblTipoMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
        If cmbMoneda.SelectedIndex > 0 Then
            txtTipoCambio.Enabled = True
            txtTipoCambio.Text = "0.00"
        Else
            txtTipoCambio.Enabled = False
            txtTipoCambio.Text = "1.00"
        End If
    End Sub

    Private Sub cmbProveedor_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProveedor.MouseWheel
        If cmbProveedor.DroppedDown Then
            Exit Sub
        Else
            cmbProveedor.SelectedIndex = -1
            lblProveedor.Focus()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If btnNuevo.Visible Then
            Dim frm As New FrmBusquedaOrdenesCompra
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        Else
            cmbSolicitud.SelectedValue = 0
            'MsgBox("No se puede buscar informacion mientras se editan datos", MsgBoxStyle.Exclamation, "Advertencia")
            If MessageBox.Show("Existen datos en pantalla desea salir e ir a la busqueda?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaOrdenesCompra
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
        End If
    End Sub

    Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            dgvDetalle.Rows(i).Selected = True
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If lblEstatus.Text = "Grabado" Then
            If eliminarlog = 1 Then
                If MessageBox.Show("Desea anular esta orden de compra", "Anular orden?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    BeginTransaction()
                    If clordenes.anularOrdenCompra(CInt(txtNumero.Text), "U", Today) Then
                        If anularOrdenCompra() Then
                            CommitTransaction()
                            cargarProveedores(Nothing)
                            cargarMoneda(Nothing)
                            cargarSolicitudesPendientes()
                            txtTipoCambio.Text = "1.000"
                            txtAtencion.Text = ""
                            txtObservaciones.Text = ""
                            lblEstatus.Text = ""
                            btnNuevo.Visible = True
                            btnGuardar.Visible = False
                            btnModificar.Visible = False
                            btnAnular.Visible = False
                            cargarDetalle()
                            gridDetalle()
                            obtenerNumero()
                            bloquear()
                            MsgBox("Orden de compra anulada", MsgBoxStyle.Information)
                        Else
                            RollBackTransaction()
                            MsgBox("No se realizo la operacion de anulacion de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                        End If
                    Else
                        RollBackTransaction()
                        MsgBox("No se realizo la operacion de anulacion de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                    End If
                End If
            Else
                MsgBox("No tiene permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        ElseIf lblEstatus.Text = "Aprobado" Then
            If eliminarlog = 1 Then
                If clordenes.confirmarExisteIngresoOrdenCompra(CInt(txtNumero.Text)) Then
                    If MessageBox.Show("Desea anular esta orden de compra", "Anular orden?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        If fechaAnulacion() Then
                            BeginTransaction()
                            If clordenes.anularOrdenCompra(CInt(txtNumero.Text), "U", vFechaAnulacion) Then
                                If anularOrdenCompra() Then
                                    CommitTransaction()
                                    cargarProveedores(Nothing)
                                    cargarMoneda(Nothing)
                                    cargarSolicitudesPendientes()
                                    txtTipoCambio.Text = "1.000"
                                    txtAtencion.Text = ""
                                    txtObservaciones.Text = ""
                                    lblEstatus.Text = ""
                                    btnNuevo.Visible = True
                                    btnGuardar.Visible = False
                                    btnModificar.Visible = False
                                    btnAnular.Visible = False
                                    cargarDetalle()
                                    gridDetalle()
                                    obtenerNumero()
                                    bloquear()
                                    MsgBox("Orden de compra anulada", MsgBoxStyle.Information)
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se realizo la operacion de anulacion de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                                End If
                            Else
                                RollBackTransaction()
                                MsgBox("No se realizo la operacion de anulacion de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                            End If
                        End If
                    End If
                Else
                    MsgBox("No se puede anular una orden de compra aprobada, que ya tenga ingreso a bodega", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("No tiene permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        ElseIf lblEstatus.Text = "Cerrada" Then
            MsgBox("No se puede anular una orden de compra cerrada", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "" Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Anulada" Then
            MsgBox("Esta orden de compra ya se encuentra anulada", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If lblEstatus.Text = "Grabado" Then
            If validarCampos() Then
                If MessageBox.Show("Desea modificar datos de orden de compra", "Modificar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    lblNumero.Focus()
                    If verificarCantidadPendienteProductoModificacion() Then
                        If verificarPrecio() Then
                            If verificarDiferenciasProducto() Then
                                BeginTransaction()
                                If modificarMaestro() Then
                                    If eliminarDetalle() Then
                                        If guardarDetalle() Then
                                            If confirmarDetalleSolicitud() Then
                                                CommitTransaction()
                                                confirmarMaestroSolicitud()
                                                cargarProveedores(Nothing)
                                                cargarMoneda(Nothing)
                                                cargarSolicitudesPendientes()
                                                txtTipoCambio.Text = "1.000"
                                                txtAtencion.Text = ""
                                                lblEstatus.Text = ""
                                                txtObservaciones.Text = ""
                                                btnNuevo.Visible = True
                                                btnGuardar.Visible = False
                                                btnModificar.Visible = False
                                                btnAnular.Visible = False
                                                cargarDetalle()
                                                gridDetalle()
                                                obtenerNumero()
                                                bloquear()
                                                MsgBox("Orden de compra modificada", MsgBoxStyle.Information)
                                            Else
                                                RollBackTransaction()
                                                MsgBox("No se pudo confirmar detalle solicitud, no se ejecuto el proceso de actualizacion", MsgBoxStyle.Exclamation, "Error de sistema")
                                            End If
                                        Else
                                            RollBackTransaction()
                                            MsgBox("No se pudo guardar detalle de compra, no se ejecuto el proceso de actualizacion", MsgBoxStyle.Exclamation, "Error de sistema")
                                        End If
                                    Else
                                        RollBackTransaction()
                                        MsgBox("No se pudo guardar detalle compra, no se ejecuto el proceso de actualizacion", MsgBoxStyle.Exclamation, "Error de sistema")
                                    End If
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se ejecuto el proceso de actualizacion", MsgBoxStyle.Exclamation, "Advertencia")
                                End If
                            End If
                        End If
                    End If
                Else
                    Exit Sub
                End If
            End If
        ElseIf lblEstatus.Text = "Aprobado" Then
            MsgBox("No se puede modificar una orden de compra Aprobada", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Cerrada" Then
            MsgBox("No se puede modificar una orden de compra Cerrada", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "" Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Anulada" Then
            MsgBox("No se puede modificar una orden de compra Anulada", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub dgvDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetalle.KeyDown
        If dgvDetalle.Rows.Count > 0 Then
            If e.KeyValue = Keys.F7 Then
                Dim i As Integer = dgvDetalle.CurrentRow.Index
                numeroSolicitud = CInt(dgvDetalle.Item(0, i).Value)
                cmbSolicitud.SelectedValue = numeroSolicitud
                Dim frm As New FrmOrdenCompraDetalle
                With frm
                    .StartPosition = FormStartPosition.CenterParent
                    .Text = "DETALLE DE SOLICITUD NUMERO: " & numeroSolicitud
                    If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                        If dgvDetalle.Rows.Count <= 0 Then
                            dgvDetalle.Columns.Clear()
                        End If
                        gridDetalle()
                        sumarPrecios()
                    Else
                        MsgBox("No se agrego ningun producto para orden de compra Numero " & cmbSolicitud.SelectedValue, MsgBoxStyle.Exclamation, "Error de validacion")
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If btnGuardar.Visible = True Then
            MsgBox("Debe guardar primero la operacion actual", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf btnNuevo.Visible = True Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Validacion")
        Else
            If String.IsNullOrEmpty(txtNumero.Text) Then
                MsgBox("Debe tener un documento activo", MsgBoxStyle.Exclamation, "Error de operacion")
            Else
                imprimirOrden()
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        If e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
            If camposVacios() Then
                sumarPrecios()
            End If
        End If
    End Sub

    Private Sub cmbSolicitud_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSolicitud.KeyDown
        If e.KeyValue = Keys.Enter Then
            numeroSolicitud = cmbSolicitud.SelectedValue
            Dim frm As New FrmOrdenCompraDetalle
            With frm
                .StartPosition = FormStartPosition.CenterParent
                .Text = "DETALLE DE SOLICITUD NUMERO: " & cmbSolicitud.SelectedValue
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    .txtBuscar.Focus()
                    If dgvDetalle.Rows.Count <= 0 Then
                        dgvDetalle.Columns.Clear()
                    End If
                    gridDetalle()
                    sumarPrecios()
                    cargarSolicitudesPendientes()
                Else
                    MsgBox("No se agrego ningun producto para orden de compra Numero " & cmbSolicitud.SelectedValue, MsgBoxStyle.Exclamation, "Error de validacion")
                End If
            End With
        End If
    End Sub

    Private Sub cmbSolicitud_Leave(sender As Object, e As EventArgs) Handles cmbSolicitud.Leave
        If cmbSolicitud.SelectedIndex > 0 Then
            numeroSolicitud = cmbSolicitud.SelectedValue
            Dim frm As New FrmOrdenCompraDetalle
            With frm
                .StartPosition = FormStartPosition.CenterParent
                .Text = "DETALLE DE SOLICITUD NUMERO: " & cmbSolicitud.SelectedValue
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    .txtBuscar.Focus()
                    If dgvDetalle.Rows.Count <= 0 Then
                        dgvDetalle.Columns.Clear()
                    End If
                    gridDetalle()
                    sumarPrecios()
                    cargarSolicitudesPendientes()
                Else
                    MsgBox("No se agrego ningun producto para orden de compra Numero " & cmbSolicitud.SelectedValue, MsgBoxStyle.Exclamation, "Error de validacion")
                End If
            End With
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If lblEstatus.Text = "Grabado" Then
            If eliminarlog = 1 Then
                If MessageBox.Show("Desea cerrar esta orden de compra", "Cerrar orden?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    If clordenes.consultarProductosParcialesEnSolicitud(CInt(txtNumero.Text)) Then
                        BeginTransaction()
                        If clordenes.anularOrdenCompra(CInt(txtNumero.Text), "T", Today) Then
                            CommitTransaction()
                            cargarProveedores(Nothing)
                            cargarMoneda(Nothing)
                            cargarSolicitudesPendientes()
                            txtTipoCambio.Text = "1.000"
                            txtAtencion.Text = ""
                            txtObservaciones.Text = ""
                            lblEstatus.Text = ""
                            btnNuevo.Visible = True
                            btnGuardar.Visible = False
                            btnModificar.Visible = False
                            btnAnular.Visible = False
                            cargarDetalle()
                            gridDetalle()
                            obtenerNumero()
                            bloquear()
                            MsgBox("Orden de compra cerrada", MsgBoxStyle.Information, "Aviso")
                        Else
                            RollBackTransaction()
                            MsgBox("No se realizo la operacion de cierre de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                        End If
                    Else
                        MsgBox("No puede cerrar una orden con compra de productos parciales", MsgBoxStyle.Exclamation, "Advertencia")
                    End If
                End If
            Else
                MsgBox("No tiene permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        ElseIf lblEstatus.Text = "Aprobado" Then
            If eliminarlog = 1 Then
                If clordenes.confirmarExisteIngresoOrdenCompra(CInt(txtNumero.Text)) Then
                    If MessageBox.Show("Desea cerrar esta orden de compra", "Cerrar orden?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        If clordenes.consultarProductosParcialesEnSolicitud(CInt(txtNumero.Text)) Then
                            If fechaAnulacion() Then
                                BeginTransaction()
                                If clordenes.anularOrdenCompra(CInt(txtNumero.Text), "T", vFechaAnulacion) Then
                                    CommitTransaction()
                                    cargarProveedores(Nothing)
                                    cargarMoneda(Nothing)
                                    cargarSolicitudesPendientes()
                                    txtTipoCambio.Text = "1.000"
                                    txtAtencion.Text = ""
                                    txtObservaciones.Text = ""
                                    lblEstatus.Text = ""
                                    btnNuevo.Visible = True
                                    btnGuardar.Visible = False
                                    btnModificar.Visible = False
                                    btnAnular.Visible = False
                                    cargarDetalle()
                                    gridDetalle()
                                    obtenerNumero()
                                    bloquear()
                                    MsgBox("Orden de compra cerrada", MsgBoxStyle.Information)
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se realizo la operacion de cierre de orden de compra", MsgBoxStyle.Exclamation, "Error de sistema")
                                End If
                            End If
                        Else
                            MsgBox("No puede cerrar una orden con compra de productos parciales", MsgBoxStyle.Exclamation, "Advertencia")
                        End If
                    End If
                Else
                    MsgBox("No se puede cerrar una orden de compra aprobada, que ya tenga ingreso a bodega", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("No tiene permisos para realizar esta accion", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        ElseIf lblEstatus.Text = "Cerrada" Then
            MsgBox("No se puede cerrar una orden de compra cerrada", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "" Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Anulada" Then
            MsgBox("Esta orden de compra ya se encuentra cerrada", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub AnularProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularProductoToolStripMenuItem.Click
        If lblEstatus.Text = "Guardado" Then
            MsgBox("No puede anular ingreso de items, Guardados", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf lblEstatus.Text = "Anulada" Then
            MsgBox("No puede anular ingreso de items, Anulados", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf lblEstatus.Text = "Cerrada" Then
            MsgBox("No puede anular ingreso de items, Terminados", MsgBoxStyle.Exclamation, "Validacion")
        ElseIf lblEstatus.Text = "Aprobado" Then
            If MessageBox.Show("Desa quitar de ingreso a bodega el Producto: " & dgvDetalle.Item(1, indiceGrid).Value & " " & dgvDetalle.Item(2, indiceGrid).Value, "Anular?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                If clordenes.verificarCantidadProductoTerminar(CInt(txtNumero.Text), dtDetalleOrdenes.Rows(indiceGrid)(1).ToString(), CInt(dgvDetalle.Item(0, indiceGrid).Value)) > 0 Then
                    If clordenes.verificarExisteProductoNoIngresado(CInt(txtNumero.Text), dtDetalleOrdenes.Rows(indiceGrid)(1).ToString(), CInt(dgvDetalle.Item(0, indiceGrid).Value)) Then
                        If fechaAnulacion() Then
                            BeginTransaction()
                            If clordenes.anularProductoIngreso(CInt(txtNumero.Text), dtDetalleOrdenes.Rows(indiceGrid)(1).ToString(), CInt(dgvDetalle.Item(0, indiceGrid).Value)) Then
                                If clordenes.ejecutarPolizaPorProducto(CInt(txtNumero.Text), dtDetalleOrdenes.Rows(indiceGrid)(1).ToString(), vFechaAnulacion) Then
                                    CommitTransaction()
                                    MsgBox("Producto terminado", MsgBoxStyle.Information, "Aviso")
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se podran guardar los cambios", MsgBoxStyle.Exclamation, "Aviso")
                                End If
                            Else
                                RollBackTransaction()
                                MsgBox("No se podran guardar los cambios", MsgBoxStyle.Exclamation, "Aviso")
                            End If
                        End If
                    End If
                Else
                    MsgBox("Producto ya ha sido ingreso en su totalidad, no existen productos para terminarlos", MsgBoxStyle.Exclamation, "Aviso")
                End If
            End If
        End If
    End Sub
End Class