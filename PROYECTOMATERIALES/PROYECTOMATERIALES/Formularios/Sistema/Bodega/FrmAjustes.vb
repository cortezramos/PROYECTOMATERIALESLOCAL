Public Class FrmAjustes
#Region "Controles"

    Sub bloquear()
        cmbBodega.Enabled = False
        cmbTipoAjuste.Enabled = False
        txtObservaciones.Enabled = False
        cmbProducto.Enabled = False
        txtCantidad.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Sub desbloquear()
        cmbBodega.Enabled = True
        cmbTipoAjuste.Enabled = True
        txtObservaciones.Enabled = True
        cmbProducto.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Sub bloquearPoliza()
        txtDescripcion.Enabled = False
        cmbCentroPoliza.Enabled = False
        cmbCuentaPoliza.Enabled = False
        txtCargo.Enabled = False
        txtAbono.Enabled = False
        btnAgregaPoliza.Enabled = False
        btnEliminaPoliza.Enabled = False
        btnCancelaPoliza.Enabled = False
    End Sub
    Sub desbloquearPoliza()
        txtDescripcion.Enabled = True
        cmbCentroPoliza.Enabled = True
        cmbCuentaPoliza.Enabled = True
        txtCargo.Enabled = True
        txtAbono.Enabled = True
        btnAgregaPoliza.Enabled = True
        btnCancelaPoliza.Enabled = True
    End Sub

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
        With cmbTipoAjuste
            .SelectedIndex = Valor
        End With
    End Sub

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
            With cmbCentroPoliza
                .DataSource = dtConsultaDeCentro
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbCentroPoliza
                .DataSource = dtConsultaDeCentro
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub

    Sub cargarCuentasContables(Valor As String)
        If dtConsultaCuentas.Rows.Count = 0 Then
            dtConsultaCuentas = clcuentas.consultaCuentaContable()
        End If
        If Valor <> Nothing Then
            With cmbCuentaPoliza
                .DataSource = dtConsultaCuentas
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbCuentaPoliza
                .DataSource = dtConsultaCuentas
                .ValueMember = "Cuenta"
                .DisplayMember = "Descripcion"
                .SelectedValue = 0
            End With
        End If
    End Sub

    Function validarEncabezado() As Boolean
        If cmbBodega.SelectedValue = 0 Then
            MsgBox("Seleccion bodega de ajuste", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        ElseIf cmbTipoAjuste.SelectedIndex = 0 Then
            MsgBox("Seleccione tipo de ajuste", MsgBoxStyle.Exclamation, "Advertencia")
            cmbTipoAjuste.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtObservaciones.Text) Then
            MsgBox("Ingrese observaciones", MsgBoxStyle.Exclamation, "Advertencia")
            txtObservaciones.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarDetalle() As Boolean
        If cmbProducto.SelectedValue = 0 Then
            MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Aviso")
            cmbProducto.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtCantidad.Text) Then
            MsgBox("Ingrese cantidad a ajustar", MsgBoxStyle.Exclamation, "Aviso")
            txtCantidad.Focus()
            Return False
        ElseIf CDec(txtCantidad.Text) <= 0 Then
            MsgBox("Cantidad debe ser mayor a cero", MsgBoxStyle.Exclamation, "Aviso")
            txtCantidad.Focus()
            Return False
        ElseIf cmbTipoAjuste.SelectedIndex = 2 Then
            If vSaldoProducto - CDec(txtCantidad.Text) < 0 Then
                Me.Hide()
                MsgBox("No existe saldo para realizar este ajuste, el Producto " & vNombreProducto & " Solamente tiene existencia de " & vSaldoProducto, MsgBoxStyle.Exclamation, "Aviso")
                Me.Show()
                txtCantidad.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Function validarExisteProducto() As Boolean
        Dim existe As Integer = 0
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                If cmbProducto.SelectedValue = dgvDetalle.Item(0, i).Value Then
                    existe += 1
                End If
            Next
            If existe > 0 Then
                MsgBox("Este producto ya fue agregado a el ajuste", MsgBoxStyle.Exclamation, "Aviso")
                Return False
            End If
        End If
        Return True
    End Function

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
        Dim dtDato As DataTable = clsolicitud.consultarInformacionCentroCosto(cmbCentroPoliza.SelectedValue)
        If dtDato.Rows.Count > 0 Then
            vDescripcionCentro = dtDato.Rows(0)(0).ToString()
        Else
            vDescripcionCentro = "N/A"
        End If
    End Sub

    Sub obtenerInfroCuentaContable()
        Dim dtDato As DataTable = clsolicitud.consultarInformacionCuentaContable(cmbCuentaPoliza.SelectedValue)
        If dtDato.Rows.Count > 0 Then
            vDescripcionCuenta = dtDato.Rows(0)(0).ToString()
        Else
            vDescripcionCuenta = "N/A"
        End If
    End Sub

    Sub bloquearEncabezado()
        cmbBodega.Enabled = False
        cmbTipoAjuste.Enabled = False
        txtObservaciones.Enabled = False
    End Sub

    Sub obtenerNumero()
        If vTipoAjuste = 0 Then
            txtNumero.Text = cAjustes.consultarNumeroPorTipo(vTipoAjuste) - 1
        Else
            txtNumero.Text = cAjustes.consultarNumeroPorTipo(vTipoAjuste)
        End If
    End Sub

    Sub numeroPoliza()
        txtNumeroPoliza.Text = cAjustes.numeroPoliza()
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
        If cAjustes.insertarMovimientoMaestro(CInt(txtNumero.Text), vTipoAjuste, CDate(dtFecha.Text), CInt(cmbBodega.SelectedValue), txtObservaciones.Text) Then
            Return True
        End If
        Return False
    End Function

    Function guardarPoliza() As Boolean
        If cAjustes.guardarPoliza(CInt(txtNumeroPoliza.Text), CDate(dtFecha.Text), txtDescripcion.Text, CInt(txtNumero.Text), vTipoAjuste) Then
            Return True
        End If
        Return False
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If cAjustes.insertarMovimientoDetalle(CInt(txtNumero.Text), dgvDetalle.Item(0, i).Value, vTipoAjuste, dgvDetalle.Item(1, i).Value, CDec(dgvDetalle.Item(2, i).Value), CInt(cmbBodega.SelectedValue)) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Function guardarPolizaDetalle() As Boolean
        For i As Integer = 0 To dgvPoliza.Rows.Count - 1
            If cAjustes.guardarPolizaDetalle(CInt(txtNumeroPoliza.Text), dgvPoliza.Item(2, i).Value, dgvPoliza.Item(0, i).Value, CDec(dgvPoliza.Item(4, i).Value), CDec(dgvPoliza.Item(5, i).Value), ".") = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub renderizarGrid()
        With dgvDetalle
            .Columns(0).Width = 60
            .Columns(2).Width = 60
            .Columns(3).Width = 100
        End With
    End Sub

    Function validarPoliza() As Boolean
        If String.IsNullOrEmpty(txtDescripcion.Text) Then
            MsgBox("Ingrese descripcion de poliza", MsgBoxStyle.Exclamation, "Advertencia")
            txtDescripcion.Focus()
            Return False
        ElseIf dgvPoliza.Rows.Count <= 0 Then
            MsgBox("Ingrese datos de poliza", MsgBoxStyle.Exclamation, "Advertencia")
            cmbCentroPoliza.Focus()
            Return False
        ElseIf CDec(txtTotalCargo.Text) - CDec(txtTotalAbono.Text) <> 0 Then
            MsgBox("Poliza debe cuadrar el cargo y abono", MsgBoxStyle.Exclamation, "Advertencia")
            cmbCentroPoliza.Focus()
            Return False
        End If
        Return True
    End Function

    Function validarCamposPoliza() As Boolean
        If cmbCuentaPoliza.Text = "" Then
            MsgBox("Seleccione Cuenta", MsgBoxStyle.Exclamation)
            cmbCuentaPoliza.Focus()
            Return False
        ElseIf cmbCentroPoliza.Text = "" Then
            MsgBox("Seleccione Centro", MsgBoxStyle.Exclamation)
            cmbCentroPoliza.Focus()
            Return False
        ElseIf txtCargo.Text = "" And txtAbono.Text = "" Then
            MsgBox("Los campos cargo y abono no pueden ser vacios", MsgBoxStyle.Exclamation)
            txtCargo.Focus()
            Return False
        ElseIf txtCargo.Text = 0 And txtAbono.Text = 0 Then
            MsgBox("Los campos cargo y abono no pueden ser 0", MsgBoxStyle.Exclamation)
            txtCargo.Focus()
            Return False
        ElseIf txtCargo.Text <> 0 And txtAbono.Text <> 0 Then
            MsgBox("Solo puede ingresar un valor con datos ", MsgBoxStyle.Exclamation)
            txtCargo.Focus()
            Return False
        ElseIf txtNota.Text = "" Then
            MsgBox("Ingrese nota para esta operacion", MsgBoxStyle.Exclamation)
            txtNota.Focus()
            Return False
        End If
        Return True
    End Function

    Function validaingresocuentas() As Boolean
        Dim cuentagrid As String
        Dim centrogrid As String

        If dgvPoliza.Rows.Count >= 1 Then
            For a = 0 To dgvPoliza.Rows.Count - 1
                cuentagrid = dgvPoliza.Item(2, a).Value
                If cmbCuentaPoliza.SelectedValue = cuentagrid Then
                    For j As Integer = 0 To dgvPoliza.Rows.Count - 1
                        centrogrid = dgvPoliza.Item(0, a).Value
                        If cmbCentroPoliza.SelectedValue = centrogrid Then
                            MsgBox("La cuenta ya fue ingresada", MsgBoxStyle.Critical)
                            Return False
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next
        End If
        Return True
    End Function

    Function validacionvalores() As Boolean
        If Val(txtCargo.Text) <> 0 And Val(txtAbono.Text) <> 0 Then
            MsgBox("Error al ingresar valores", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub sumavalores()
        Dim totalcargo As Decimal = 0
        Dim totalabono As Decimal = 0

        For a = 0 To DGVpoliza.Rows.Count - 1
            totalcargo += CDec(dgvPoliza.Item(4, a).Value)
            totalabono += CDec(dgvPoliza.Item(5, a).Value)
        Next

        txtTotalCargo.Text = Decimal.Round(totalcargo, 2)
        txtTotalAbono.Text = Decimal.Round(totalabono, 2)
    End Sub

    Sub mostrarReporte()
        Dim frm As New RptAjustes
        With frm
            .Numero = CInt(txtNumero.Text)
            .Tipo = vTipoAjuste
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

    Private cAjustes As New clAjustes
    Private clordenes As New clOrdenesCompra
    Private clsolicitud As New clSolicitudMateriales
    Private clsalidas As New clSalidaBodega
    Private clcentro As New clCentroCosto
    Private clcuentas As New clCuentaContable
    Private dtConsultaDeProducto As New DataTable
    Private dtConsultaDeCentro As New DataTable
    Private dtConsultaCuentas As New DataTable
    Private vNombreProducto As String
    Private vSaldoProducto As Decimal
    Private vMedidaProducto As String
    Private vCentroCosto As String
    Private vDescripcionCentro As String
    Private vCuentaContable As String
    Private vDescripcionCuenta As String
    Private vTipoAjuste As Integer

    Private Sub FrmAjustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquear()
        bloquearPoliza()
        renderizarGrid()
        cargarBodega(Nothing)
        cargarTipo(0)
        cargarProductos(Nothing)
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub cmbTipoAjuste_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbTipoAjuste.MouseWheel
        If cmbTipoAjuste.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblTipoAjuste.Focus()
        End If
    End Sub

    Private Sub cmbProducto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProducto.MouseWheel
        If cmbProducto.DroppedDown Then
            Exit Sub
        Else
            cmbProducto.SelectedIndex = -1
            lblProducto.Focus()
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
        btnLimpiar_Click(sender, e)
        tabAjuste.Parent = tabControl
        tabPoliza.Parent = Nothing
        desbloquear()
        btnNuevo.Visible = False
        btnContabilidad.Visible = True
    End Sub

    Private Sub cmbTipoAjuste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoAjuste.SelectedIndexChanged
        If cmbTipoAjuste.SelectedIndex > 0 Then
            If cmbTipoAjuste.SelectedIndex = 1 Then
                vTipoAjuste = 4
                obtenerNumero()
            ElseIf cmbTipoAjuste.SelectedIndex = 2 Then
                vTipoAjuste = 8
                obtenerNumero()
            End If
        Else
            vTipoAjuste = 0
            obtenerNumero()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If validarDetalle() Then
            If validarExisteProducto() Then
                dgvDetalle.Rows.Add(cmbProducto.SelectedValue, vNombreProducto, CDec(txtCantidad.Text), vMedidaProducto)
                cargarProductos(Nothing)
                txtCantidad.Text = ""
                cmbProducto.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If dgvDetalle.Rows.Count = 0 Then
            desbloquear()
        End If
        cargarProductos(Nothing)
        txtCantidad.Text = ""
        btnEliminar.Enabled = False
        cmbProducto.Enabled = True
        btnAgregar.Enabled = True
        txtCantidad.Enabled = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cargarBodega(Nothing)
        cargarTipo(0)
        txtObservaciones.Text = ""
        txtDescripcion.Text = ""
        cargarProductos(Nothing)
        cargarCentroDeCostos(Nothing)
        cargarCuentasContables(Nothing)
        txtCantidad.Text = ""
        txtCargo.Text = "0"
        txtAbono.Text = "0"
        bloquear()
        bloquearPoliza()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnContabilidad.Visible = False
        tabAjuste.Parent = tabControl
        tabPoliza.Parent = Nothing
        dgvDetalle.Rows.Clear()
        dgvPoliza.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If validarPoliza() Then
                If vTipoAjuste = 4 Then 'Guardar ajuste positivo
                    obtenerNumero()
                    numeroPoliza()
                    BeginTransaction()
                    If guardarMaestro() Then
                        If guardarDetalle() Then
                            If guardarPoliza() Then
                                If guardarPolizaDetalle() Then
                                    CommitTransaction()
                                    MsgBox("Ajuste guardado con exito", MsgBoxStyle.Information, "Aviso")
                                    If MessageBox.Show("Desa imprimir el ajuste", "Imprimir ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        mostrarReporte()
                                    End If
                                    btnLimpiar_Click(sender, e)
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
                        MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                    End If
                ElseIf vTipoAjuste = 8 Then 'Guardar ajuste negativo
                    If revalidarExistencia() Then
                        obtenerNumero()
                        numeroPoliza()
                        BeginTransaction()
                        If guardarMaestro() Then
                            If guardarDetalle() Then
                                If guardarPoliza() Then
                                    If guardarPolizaDetalle() Then
                                        CommitTransaction()
                                        MsgBox("Ajuste guardado con exito", MsgBoxStyle.Information, "Aviso")
                                        btnLimpiar_Click(sender, e)
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
                            MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                        End If
                    End If
                Else
                    MsgBox("Seleccione tipo de ajuste", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End If
        Else
            MsgBox("No existen datos agregados a este ajuste", MsgBoxStyle.Exclamation, "Aviso")
            cmbProducto.Focus()
        End If
    End Sub

    Private Sub dgvDetalle_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvDetalle.CellPainting
        e.PaintBackground(e.ClipBounds, True)
        e.PaintContent(e.ClipBounds)
        e.Handled = True
    End Sub

    Private Sub txtCargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCargo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtCargo.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAbono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAbono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtAbono.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbCentroPoliza_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCentroPoliza.KeyDown
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

    Private Sub cmbCentroPoliza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCentroPoliza.SelectedIndexChanged
        If cmbCentroPoliza.SelectedIndex > 0 Then
            obtenerInfroCentroCosto()
        End If
    End Sub

    Private Sub cmbCuentaPoliza_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCuentaPoliza.KeyDown
        If e.KeyValue = Keys.F7 Then
            Dim frm As New FrmBusquedaDeCuentasContables
            With frm
                .StartPosition = FormStartPosition.CenterParent
                If .ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    cargarCuentasContables(.cuentacontableseleccion)
                Else
                    cargarCuentasContables(Nothing)
                    MsgBox("No se selecciono ninguna cuenta contable", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End With
        End If
    End Sub

    Private Sub cmbCuentaPoliza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCuentaPoliza.SelectedIndexChanged
        If cmbCuentaPoliza.SelectedIndex > 0 Then
            obtenerInfroCuentaContable()
        End If
    End Sub

    Private Sub btnContabilidad_Click(sender As Object, e As EventArgs) Handles btnContabilidad.Click
        If dgvDetalle.Rows.Count > 0 Then
            numeroPoliza()
            cargarCentroDeCostos(Nothing)
            cargarCuentasContables(Nothing)
            desbloquearPoliza()
            tabPoliza.Parent = tabControl
            btnGuardar.Visible = True
            btnContabilidad.Visible = False
            btnNuevo.Visible = False
        Else
            cmbProducto.Focus()
            MsgBox("Realice una operacion de ajuste, para poder realizar la poliza", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnAgregaPoliza_Click(sender As Object, e As EventArgs) Handles btnAgregaPoliza.Click
        If txtCargo.Text = "" And txtAbono.Text <> "" Then
            txtCargo.Text = 0
        ElseIf txtAbono.Text = "" And txtCargo.Text <> "" Then
            txtAbono.Text = 0
        ElseIf txtCargo.Text = "" And txtAbono.Text = "" Then
            txtCargo.Text = 0
            txtAbono.Text = 0
        End If
        If validarCamposPoliza() Then
            If validaingresocuentas() Then
                If validacionvalores() Then
                    dgvPoliza.Rows.Add(cmbCentroPoliza.SelectedValue, vDescripcionCentro, cmbCuentaPoliza.SelectedValue, vDescripcionCuenta, CDec(txtCargo.Text), CDec(txtAbono.Text), txtNota.Text)
                    sumavalores()
                    cargarCentroDeCostos(Nothing)
                    cargarCuentasContables(Nothing)
                    txtCargo.Text = "0"
                    txtAbono.Text = "0"
                    txtNota.Text = ""
                    cmbCentroPoliza.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim I As Integer = dgvDetalle.CurrentRow.Index
            cargarProductos(dgvDetalle.Item(0, I).Value)
            txtCantidad.Text = dgvDetalle.Item(2, I).Value
            cmbProducto.Enabled = False
            txtCantidad.Enabled = False
            btnAgregar.Enabled = False
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
        cargarProductos(Nothing)
        txtCantidad.Text = ""
        cmbProducto.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnEliminar.Enabled = False
    End Sub

    Private Sub dgvPoliza_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPoliza.CellDoubleClick
        If dgvPoliza.Rows.Count > 0 Then
            Dim i As Integer = dgvPoliza.CurrentRow.Index
            cargarCentroDeCostos(dgvPoliza.Item(0, i).Value)
            cargarCuentasContables(dgvPoliza.Item(2, i).Value)
            txtCargo.Text = dgvPoliza.Item(4, i).Value
            txtAbono.Text = dgvPoliza.Item(5, i).Value
            txtNota.Text = dgvPoliza.Item(6, i).Value
            cmbCentroPoliza.Enabled = False
            cmbCuentaPoliza.Enabled = False
            txtCargo.Enabled = False
            txtAbono.Enabled = False
            txtNota.Enabled = False
            btnAgregaPoliza.Enabled = False
            btnEliminaPoliza.Enabled = True
        End If
    End Sub

    Private Sub btnEliminaPoliza_Click(sender As Object, e As EventArgs) Handles btnEliminaPoliza.Click
        dgvPoliza.Rows.Remove(dgvPoliza.CurrentRow)
        sumavalores()
        cargarCentroDeCostos(Nothing)
        cargarCuentasContables(Nothing)
        txtCargo.Text = ""
        txtAbono.Text = ""
        txtNota.Text = ""
        cmbCentroPoliza.Enabled = True
        cmbCuentaPoliza.Enabled = True
        txtCargo.Enabled = True
        txtAbono.Enabled = True
        txtNota.Enabled = True
        btnAgregaPoliza.Enabled = True
        btnEliminaPoliza.Enabled = False
    End Sub

    Private Sub btnCancelaPoliza_Click(sender As Object, e As EventArgs) Handles btnCancelaPoliza.Click
        cargarCentroDeCostos(Nothing)
        cargarCuentasContables(Nothing)
        txtCargo.Text = "0"
        txtAbono.Text = "0"
        txtNota.Text = ""
        cmbCentroPoliza.Enabled = True
        cmbCuentaPoliza.Enabled = True
        txtCargo.Enabled = True
        txtAbono.Enabled = True
        txtNota.Enabled = True
        btnAgregaPoliza.Enabled = True
        btnEliminaPoliza.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaAjustes
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
            Dim frm As New FrmBusquedaAjustes
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