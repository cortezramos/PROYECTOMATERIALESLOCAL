Public Class FrmSalidaBodega
#Region "Controles"
    Sub disenoGrid()
        With dgvDetalle
            .Columns(0).Width = 50
            .Columns(2).Width = 50
            .Columns(3).Width = 75
            .Columns(4).Width = 50
            .Columns(5).Width = 175
        End With
    End Sub

    Sub limpiar()
        txtSolicitante.Text = ""
        cargarBodega(Nothing)
        cargarTipo(Nothing)
        cargarResponsables(Nothing)
        cargarProductos(Nothing)
        cargarCentroDeCostos(Nothing)
        cargarClientes(Nothing)
        txtCantidad.Text = ""
        txtObservaciones.Text = ""
        dgvDetalle.Rows.Clear()
        dtFecha.Value = Today
    End Sub


    Sub bloquearEncabezado()
        txtSolicitante.Enabled = False
        txtObservaciones.Enabled = False
        cmbBodega.Enabled = False
        cmbTipo.Enabled = False
        cmbResponsable.Enabled = False
        cmbCliente.Enabled = False
    End Sub

    Sub bloquearSeleccion()
        cmbProducto.Enabled = False
        cmbCentroCosto.Enabled = False
        txtCantidad.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarDetalle.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Sub desbloquearEncabezado()
        txtSolicitante.Enabled = True
        txtObservaciones.Enabled = True
        cmbBodega.Enabled = True
        cmbTipo.Enabled = True
        cmbResponsable.Enabled = True
    End Sub

    Sub desbloquearSeleccion()
        cmbProducto.Enabled = True
        cmbCentroCosto.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Function validarEncabezado() As Boolean
        If String.IsNullOrEmpty(txtSolicitante.Text) Then
            MsgBox("Ingrese nombre de solicitante", MsgBoxStyle.Exclamation, "Advertencia")
            txtSolicitante.Focus()
            Return False
        ElseIf cmbBodega.SelectedValue = 0 Then
            MsgBox("Seleccion bodega de salida de materiales", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        ElseIf cmbTipo.SelectedValue = 0 Then
            MsgBox("Seleccione tipo de salida", MsgBoxStyle.Exclamation, "Advertencia")
            cmbTipo.Focus()
            Return False
        ElseIf cmbResponsable.SelectedValue = 0 Then
            MsgBox("Seleccione responsable de producto", MsgBoxStyle.Exclamation, "Advertencia")
            cmbResponsable.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtObservaciones.Text) Then
            MsgBox("Ingrese observaciones", MsgBoxStyle.Exclamation, "Advertencia")
            txtObservaciones.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarSeleccion() As Boolean
        If cmbProducto.SelectedValue = 0 Then
            MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Advertencia")
            cmbProducto.Focus()
            Return False
        ElseIf cmbCentroCosto.SelectedValue = 0 Then
            MsgBox("Seleccione centro de costo", MsgBoxStyle.Exclamation, "Advertencia")
            cmbCentroCosto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtCantidad.Text) Then
            MsgBox("Ingrese cantidad de producto", MsgBoxStyle.Exclamation, "Advertencia")
            txtCantidad.Focus()
            Return False
        ElseIf Decimal.Round(CDec(txtCantidad.Text), 2) <= 0 Then
            MsgBox("Cantidad debe ser mayor a cero, verifique decimales solamente pueden ser dos", MsgBoxStyle.Exclamation, "Advertencia")
            txtCantidad.Focus()
            Return False
        ElseIf vSaldoProducto - CDec(txtCantidad.Text) < 0 Then
            Me.Hide()
            MsgBox("Producto " & cmbProducto.Text & " Solamente tiene existencia de " & vSaldoProducto, MsgBoxStyle.Exclamation, "Advertencia")
            Me.Show()
            txtCantidad.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarExisteProducto() As Boolean
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If cmbProducto.SelectedValue = dgvDetalle.Item(0, i).Value Then
                    If cmbCentroCosto.SelectedValue = dgvDetalle.Item(4, i).Value Then
                        MsgBox("Producto " & cmbProducto.Text & " ya fue agregado")
                        Return False
                    End If
                End If
            Next
        End If
        Return True
    End Function


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

    Sub cargarTipo(Valor As Integer)
        If Valor <> Nothing Then
            With cmbTipo
                .DataSource = clsalidas.consultarTipoEnvio()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbTipo
                .DataSource = clsalidas.consultarTipoEnvio()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Function cargarParametrosSalida() As Boolean
        Dim dtDatos As DataTable = clsalidas.consultarParametrosTipoSalida(vTipoSalida)
        If dtDatos.Rows.Count > 0 Then
            vCentroCosto = dtDatos.Rows(0)(0).ToString()
            vCuentaConta = dtDatos.Rows(0)(1).ToString()
            vUtilizaCliente = dtDatos.Rows(0)(2).ToString()
        Else
            Return False
        End If
        Return True
    End Function


    Sub cargarProductos(Valor As String)
        If dtConsultaDeProducto.Rows.Count = 0 Then
            dtConsultaDeProducto = clsolicitud.consultaProductos()
        End If
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = dtConsultaDeProducto
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = dtConsultaDeProducto
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub

    Sub cargarCentroDeCostos(Valor As String)
        If dtConsultaDeCentro.Rows.Count = 0 Then
            dtConsultaDeCentro = clcentro.consultaCentroDeCosto()
        End If
        If Valor <> Nothing Then
            With cmbCentroCosto
                .DataSource = dtConsultaDeCentro
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbCentroCosto
                .DataSource = dtConsultaDeCentro
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub

    Sub cargarResponsables(Valor As Integer)
        If Valor <> Nothing Then
            With cmbResponsable
                .DataSource = clresponsable.consultarNombreResponsable()
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .SelectedValue = Valor
            End With
        Else
            With cmbResponsable
                .DataSource = clresponsable.consultarNombreResponsable()
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
            End With
        End If
    End Sub

    Sub cargarClientes(Valor As Integer)
        If Valor <> Nothing Then
            With cmbCliente
                .DataSource = clcliente.consultarClientes()
                .DisplayMember = "Nombre"
                .ValueMember = "Codigo"
                .SelectedValue = Valor
            End With
        Else
            With cmbCliente
                .DataSource = clcliente.consultarClientes()
                .DisplayMember = "Nombre"
                .ValueMember = "Codigo"
            End With
        End If

    End Sub


    Sub obtenerNumero()
        txtNumero.Text = clsalidas.ultimoNumeroSalida()
    End Sub

    Sub obtenerInfoProducto()
        Dim dtDato As DataTable = clsalidas.consultarDatosProducto(cmbProducto.SelectedValue, CInt(cmbBodega.SelectedValue))
        If dtDato.Rows.Count > 0 Then
            vNombreProducto = dtDato.Rows(0)(0).ToString()
            vSaldoProducto = CDec(dtDato.Rows(0)(1).ToString())
            vMedidaProducto = dtDato.Rows(0)(2).ToString()
        Else
            vNombreProducto = "N/A"
            vSaldoProducto = 0.0
            vMedidaProducto = "N/A"
        End If
    End Sub

    Sub obtenerInfroCentroCosto()
        Dim dtDato As DataTable = clsolicitud.consultarInformacionCentroCosto(cmbCentroCosto.SelectedValue)
        If dtDato.Rows.Count > 0 Then
            vDescripcionCentro = dtDato.Rows(0)(0).ToString()
        Else
            vDescripcionCentro = "N/A"
        End If
    End Sub

    Sub verificarDia()
        vDia = clsalidas.consultarDiaEnServidor()
        If vDia = 1 Then
            dtFecha.Enabled = True
        ElseIf vDia = 2 Then
            dtFecha.Enabled = True
        ElseIf vDia = 7 Then
            dtFecha.Enabled = True
        Else
            dtFecha.Enabled = False
        End If
    End Sub

    Function revalidarExistencia() As Boolean
        Dim Existencia As Decimal = 0
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            Existencia = clsalidas.consultarExistenciaProductoPorBodega(dgvDetalle.Item(0, i).Value, CInt(cmbBodega.SelectedValue))
            If Existencia - CDec(dgvDetalle.Item(2, i).Value) < 0 Then
                Me.Hide()
                MsgBox("Producto " & dgvDetalle.Item(0, i).Value & " " & dgvDetalle.Item(1, i).Value & " Solamente tiene existencia de " & Existencia, MsgBoxStyle.Exclamation, "Advertencia")
                dgvDetalle.Rows(i).Selected = True
                Me.Show()
                Return False
            End If
        Next
        Return True
    End Function

    Function guardarMaestro() As Boolean
        If clsalidas.insertarMaestro(CInt(txtNumero.Text), CDate(dtFecha.Text), txtSolicitante.Text,
                                     CInt(cmbBodega.SelectedValue), txtObservaciones.Text, CInt(cmbTipo.SelectedValue),
                                     vCliente, CInt(cmbResponsable.SelectedValue)) = False Then
            Me.Hide()
            MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
            Me.Show()
            Return False
        End If
        Return True
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If clsalidas.insertarDetalle(CInt(txtNumero.Text), dgvDetalle.Item(0, i).Value, dgvDetalle.Item(1, i).Value,
                                         CDec(dgvDetalle.Item(2, i).Value), dgvDetalle.Item(4, i).Value, dgvDetalle.Item(5, i).Value) = False Then
                Me.Hide()
                MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advertencia")
                Me.Show()
                Return False
            End If
        Next
        Return True
    End Function

    Sub mostrarReporte()
        Dim frm As New RptSalidas
        With frm
            .Numero = CInt(txtNumero.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

    Private clsalidas As New clSalidaBodega
    Private clsolicitud As New clSolicitudMateriales
    Private clcentro As New clCentroCosto
    Private clresponsable As New clResponsable
    Private clproducto As New clProductos
    Private clordenes As New clOrdenesCompra
    Private clcliente As New clCliente
    Private clcorreo As New clCorreos
    Private vSaldoProducto As Decimal
    Private vNombreProducto As String
    Private vMedidaProducto As String
    Private vDescripcionCentro As String
    Private vCliente As Integer = Nothing
    Private vDia As Integer
    Private dtConsultaDeProducto As New DataTable
    Private dtConsultaDeCentro As New DataTable
    Private vCentroCosto As String
    Private vCuentaConta As String
    Private vUtilizaCliente As Integer
    Private vTipoSalida As Integer = 0

    Private Sub FrmSalidaBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disenoGrid()
        bloquearEncabezado()
        bloquearSeleccion()
        cargarCentroDeCostos(Nothing)
        cargarProductos(Nothing)
    End Sub

    Private Sub cmbProducto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProducto.MouseWheel
        If cmbProducto.DroppedDown Then
            Exit Sub
        Else
            cmbProducto.SelectedIndex = -1
            lblProducto.Focus()
        End If
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cmbProducto.SelectedIndex > 0 Then
            If validarEncabezado() Then
                bloquearEncabezado()
                obtenerInfoProducto()
            Else
                cargarProductos(Nothing)
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir sin guardar", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtSolicitante.Text = ""
        txtObservaciones.Text = ""
        cargarBodega(Nothing)
        cargarTipo(Nothing)
        cargarResponsables(Nothing)
        txtCantidad.Text = ""
        dgvDetalle.Rows.Clear()
        dtFecha.Value = Today

        desbloquearEncabezado()
        desbloquearSeleccion()
        verificarDia()
        obtenerNumero()

        btnNuevo.Visible = False
        btnGuardar.Visible = True
        btnPlantillas.Visible = True
        txtSolicitante.Focus()
    End Sub

    Private Sub cmbProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyValue = Keys.F7 Then
            Dim frm As New FrmBusquedaDeProductos
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    cargarProductos(.codigoseleccion)
                Else
                    cargarProductos(Nothing)
                    MsgBox("No se selecciono ningun producto", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End With
        End If
    End Sub

    Private Sub cmbCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCentroCosto.KeyDown
        If e.KeyValue = Keys.F7 Then
            Dim frm As New FrmBusquedaDeCentroCostos
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    cargarCentroDeCostos(.centrocostoseleccion)
                Else
                    cargarCentroDeCostos(Nothing)
                    MsgBox("No se selecciono ningun centro de costo", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End With
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If validarSeleccion() Then
            If validarExisteProducto() Then
                dgvDetalle.Rows.Add(cmbProducto.SelectedValue, vNombreProducto, CDec(txtCantidad.Text), vMedidaProducto, cmbCentroCosto.SelectedValue, vDescripcionCentro)
                cargarProductos(Nothing)
                cargarCentroDeCostos(Nothing)
                txtCantidad.Text = ""
                cmbProducto.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cargarProductos(Nothing)
        cargarCentroDeCostos(Nothing)
        txtCantidad.Text = ""
        desbloquearSeleccion()
        If dgvDetalle.Rows.Count = 0 Then
            desbloquearEncabezado()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtCantidad.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbCentroCosto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbCentroCosto.MouseWheel
        If cmbCentroCosto.DroppedDown Then
            Exit Sub
        Else
            cmbCentroCosto.SelectedIndex = -1
            lblCentroCosto.Focus()
        End If
    End Sub

    Private Sub cmbCentroCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCentroCosto.SelectedIndexChanged
        If cmbCentroCosto.SelectedIndex > 0 Then
            obtenerInfroCentroCosto()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
        bloquearEncabezado()
        bloquearSeleccion()
        verificarDia()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnPlantillas.Visible = False
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            cargarProductos(dgvDetalle.Item(0, i).Value)
            cargarCentroDeCostos(dgvDetalle.Item(4, i).Value)
            txtCantidad.Text = dgvDetalle.Item(2, i).Value
            btnAgregar.Enabled = False
            dgvDetalle.Rows(i).Selected = True
            bloquearSeleccion()
            btnEliminarDetalle.Enabled = True
            btnCancelar.Enabled = True
        End If
    End Sub

    Private Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
        cargarProductos(Nothing)
        cargarCentroDeCostos(Nothing)
        txtCantidad.Text = ""
        cmbProducto.Focus()
        btnAgregar.Enabled = True
        btnEliminarDetalle.Enabled = False
        desbloquearSeleccion()
    End Sub

    Private Sub dtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFecha.KeyDown
        If e.KeyValue = Keys.F2 Then
            If vDia = 7 Then 'Dia domingo
                dtFecha.Text = dtFecha.Value.AddDays(-1)
                dtFecha.Enabled = False
            ElseIf vDia = 1 Then 'Dia lunes
                dtFecha.Text = dtFecha.Value.AddDays(-2)
                dtFecha.Enabled = False
            ElseIf vDia = 2 Then 'Dia martes
                dtFecha.Text = dtFecha.Value.AddDays(-3)
                dtFecha.Enabled = False
            Else
                MsgBox("Esta funcion no esta habilitada", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtFecha.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If revalidarExistencia() Then
                obtenerNumero()
                BeginTransaction()
                If guardarMaestro() Then
                    If guardarDetalle() Then
                        If clsalidas.insertarMovimientoMaestro(CInt(txtNumero.Text)) Then
                            If clsalidas.insertarMovimientoDetalle(CInt(txtNumero.Text), CInt(cmbBodega.SelectedValue)) Then
                                If clsalidas.ejecutarPolizaSalida(CInt(txtNumero.Text)) Then
                                    CommitTransaction()
                                    bloquearEncabezado()
                                    bloquearSeleccion()
                                    MsgBox("Salida guardada con exito", MsgBoxStyle.Information, "Aviso")
                                    If CDate(dtFecha.Value) <> Today Then
                                        clcorreo.enviarCorreo("Salidas", "El dia de hoy " & Today & " se realizo la salida No. " & txtNumero.Text & " con fecha " & dtFecha.Text & ". " & empresa & "<br/>")
                                    End If
                                    If MessageBox.Show("Desa imprimir la salida", "Imprimir salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        mostrarReporte()
                                    End If
                                    btnNuevo_Click(sender, e)
                                    bloquearEncabezado()
                                    bloquearSeleccion()
                                    btnNuevo.Visible = True
                                    btnGuardar.Visible = False
                                    btnPlantillas.Visible = False
                                Else
                                    RollBackTransaction()
                                    MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                                End If
                            Else
                                RollBackTransaction()
                                MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                            End If
                        Else
                            RollBackTransaction()
                            MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                        End If
                    Else
                        RollBackTransaction()
                    End If
                Else
                    RollBackTransaction()
                End If
            End If
        Else
            MsgBox("Ingrese productos para esta salida", MsgBoxStyle.Exclamation, "Advertencia")
            cmbProducto.Focus()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaSalidaBodega
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
            Dim frm As New FrmBusquedaSalidaBodega
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        End If
    End Sub

    Private Sub cmbTipo_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbTipo.MouseWheel
        If cmbTipo.DroppedDown Then
            Exit Sub
        Else
            cmbTipo.SelectedIndex = -1
            lblTipo.Focus()
        End If
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub cmbResponsable_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbResponsable.MouseWheel
        If cmbResponsable.DroppedDown Then
            Exit Sub
        Else
            cmbResponsable.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Try
            vTipoSalida = cmbTipo.SelectedValue
        Catch ex As Exception
            vTipoSalida = 0
            lblCliente.Visible = False
            cmbCliente.Visible = False
            cmbCliente.Enabled = False
        End Try
        If vTipoSalida > 0 Then
            If cargarParametrosSalida() Then
                If vUtilizaCliente > 0 Then
                    cargarClientes(Nothing)
                    lblCliente.Visible = True
                    cmbCliente.Visible = True
                    cmbCliente.Enabled = True
                Else
                    cargarClientes(Nothing)
                    lblCliente.Visible = False
                    cmbCliente.Visible = False
                    cmbCliente.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        If cmbCliente.SelectedIndex > 0 Then
            vCliente = cmbCliente.SelectedValue
        Else
            vCliente = Nothing
        End If
    End Sub

    Private Sub dtFecha_MouseDown(sender As Object, e As MouseEventArgs) Handles dtFecha.MouseDown
        lblBodega.Focus()
    End Sub
End Class