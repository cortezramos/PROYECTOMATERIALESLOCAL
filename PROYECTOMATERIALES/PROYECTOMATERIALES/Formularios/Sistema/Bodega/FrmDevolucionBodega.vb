Public Class FrmDevolucionBodega
#Region "Controles"
    Sub bloquearEncabezado()
        txtSolicitante.Enabled = False
        txtObservaciones.Enabled = False
        cmbBodega.Enabled = False
        cmbTipo.Enabled = False
        cmbSalida.Enabled = False
    End Sub

    Sub desbloquearEncabezado()
        txtSolicitante.Enabled = True
        txtObservaciones.Enabled = True
        cmbBodega.Enabled = True
        cmbTipo.Enabled = True
        cmbSalida.Enabled = True
    End Sub

    Sub limpiar()
        txtSolicitante.Text = ""
        txtObservaciones.Text = ""
        cargarBodega(Nothing)
        cargarTipo(Nothing)
        dgvDetalle.DataSource = ""
        dtFecha.Value = Today
    End Sub

    Function validarEncabezado() As Boolean
        If String.IsNullOrEmpty(txtSolicitante.Text) Then
            MsgBox("Ingrese solicitante", MsgBoxStyle.Exclamation, "Advertencia")
            txtSolicitante.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtObservaciones.Text) Then
            MsgBox("Ingrese una observacion para realizar la devolucion", MsgBoxStyle.Exclamation, "Advertencia")
            txtObservaciones.Focus()
            Return False
        ElseIf cmbBodega.SelectedValue <= 0 Then
            MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation, "Advertencia")
            cmbBodega.Focus()
            Return False
        ElseIf cmbTipo.SelectedValue <= 0 Then
            MsgBox("Seleccione tipo de salida", MsgBoxStyle.Exclamation, "Advertencia")
            cmbTipo.Focus()
            Return False
        ElseIf cmbSalida.SelectedValue <= 0 Then
            MsgBox("Seleccione salida de bodega, para operar devolucion", MsgBoxStyle.Exclamation, "Advertencia")
            cmbSalida.Focus()
            Return False
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

    Sub obtenerNumero()
        txtNumero.Text = cldevoluciones.ultimoNumeroDevolucion()
    End Sub

    Sub cargarSalidas(Valor As Integer)
        If Valor <> Nothing Then
            With cmbSalida
                .DataSource = cldevoluciones.consultarSalidasDeBodega(vBodega)
                .ValueMember = "Numero"
                .DisplayMember = "Observaciones"
                .SelectedValue = Valor
            End With
        Else
            With cmbSalida
                .DataSource = cldevoluciones.consultarSalidasDeBodega(vBodega)
                .ValueMember = "Numero"
                .DisplayMember = "Observaciones"
            End With
        End If
    End Sub

    Function cargarDetalle() As Boolean
        With dgvDetalle
            .DataSource = cldevoluciones.consultarDetalleSalidasDeBodegaDevolver(CInt(cmbSalida.SelectedValue))
        End With
        If dgvDetalle.Rows.Count > 0 Then
            renderizarGrid()
        Else
            MsgBox("Ya se ha realizado la devolucion total para esta salida", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        End If
        Return True
    End Function

    Sub renderizarGrid()
        With dgvDetalle
            .Columns(3).Visible = False
            .Columns(5).Visible = False

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True

            .Columns(0).Width = 65
            .Columns(1).Width = 200
            .Columns(2).Width = 50
            .Columns(4).Width = 65
            .Columns(6).Width = 110
            .Columns(7).Width = 50
            .Columns(8).Width = 65

            .Columns(7).DefaultCellStyle.BackColor = Color.Khaki
            .Columns(8).DefaultCellStyle.BackColor = Color.Khaki
        End With
    End Sub

    Function validarCantidades() As Boolean
        Dim dtVerificacion As DataTable = cldevoluciones.verificarCantidadesPendientesDevolucion(CInt(cmbSalida.SelectedValue))
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            dgvDetalle.Rows(i).DefaultCellStyle.BackColor = Color.White
            If CBool(dgvDetalle.Item(8, i).Value) = True Then
                If Decimal.Round(CDec(dgvDetalle.Item(7, i).Value), 2) > 0 Then
                    For j As Integer = 0 To dtVerificacion.Rows.Count - 1
                        If dgvDetalle.Item(0, i).Value = dtVerificacion.Rows(j)(0) And dgvDetalle.Item(5, i).Value = dtVerificacion.Rows(j)(1) Then
                            If (CDec(dtVerificacion.Rows(j)(2).ToString()) - CDec(dgvDetalle.Item(7, i).Value)) < 0 Then
                                MsgBox("Producto " & dgvDetalle.Item(1, i).Value & " Centro " & dgvDetalle.Item(6, i).Value & " no puede realizar una devolucion mayor a la de salida", MsgBoxStyle.Exclamation, "Validacion")
                                dgvDetalle.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
                                Return False
                            End If
                        End If
                    Next
                Else
                    MsgBox("Producto " & dgvDetalle.Item(1, i).Value & " debe tener ingresado un numero mayor a cero, verifique decimales solamente pueden ser dos", MsgBoxStyle.Exclamation, "Validacion")
                    dgvDetalle.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Function validarDatos() As Boolean
        Dim validar As Integer = 0
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CBool(dgvDetalle.Item(8, i).Value) = True Then
                validar += 1
            End If
        Next
        If validar = 0 Then
            MsgBox("Debe seleccionar por lo menos un producto para realizar devoluciones", MsgBoxStyle.Exclamation, "Advertencia")
            Return False
        End If
        Return True
    End Function


    Function guardarMaestro() As Boolean
        If cldevoluciones.insertarMaestro(CInt(txtNumero.Text), CDate(dtFecha.Text), txtSolicitante.Text, CInt(cmbBodega.SelectedValue), txtObservaciones.Text, CInt(cmbTipo.SelectedValue), vCliente) Then
            If cldevoluciones.insertarMovimientoMaestro(CInt(txtNumero.Text)) = False Then
                Return False
            End If
        End If
        Return True
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If CBool(dgvDetalle.Item(8, i).Value) = True Then
                If cldevoluciones.insertarDetalle(CInt(txtNumero.Text), dgvDetalle.Item(0, i).Value, dgvDetalle.Item(1, i).Value, CDec(dgvDetalle.Item(7, i).Value), dgvDetalle.Item(5, i).Value, dgvDetalle.Item(6, i).Value) = False Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Function guardarMovimientoDetalle() As Boolean
        If cldevoluciones.insertarMovimientoDetalle(CInt(txtNumero.Text), CInt(cmbBodega.SelectedValue)) = False Then
            Return False
        End If
        Return True
    End Function

    Sub mostrarReporte()
        Dim frm As New RptDevoluciones
        With frm
            .Numero = CInt(txtNumero.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
#End Region

    Private clsolicitud As New clSolicitudMateriales
    Private clcentro As New clCentroCosto
    Private clproducto As New clProductos
    Private clordenes As New clOrdenesCompra
    Private cldevoluciones As New clDevolucionBodega
    Private clsalidas As New clSalidaBodega
    Private vCliente As Integer = Nothing
    Private vBodega As Integer = 0
    Private Sub FrmDevolucionBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquearEncabezado()
        cargarBodega(Nothing)
        cargarTipo(Nothing)
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
        End If
    End Sub

    Private Sub cmbBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodega.SelectedIndexChanged
        If cmbBodega.SelectedIndex > 0 Then
            vBodega = cmbBodega.SelectedValue
            cargarSalidas(Nothing)
        Else
            vBodega = 0
            cargarSalidas(Nothing)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        obtenerNumero()
        desbloquearEncabezado()
        btnNuevo.Visible = False
        btnGuardar.Visible = True
        btnSeleccion.Visible = True
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

    Private Sub cmbSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSalida.KeyDown
        If e.KeyValue = Keys.Enter Then
            If validarEncabezado() Then
                If cargarDetalle() Then
                    bloquearEncabezado()
                End If
            End If
        End If
    End Sub

    Private Sub btnSeleccion_Click(sender As Object, e As EventArgs) Handles btnSeleccion.Click
        If dgvDetalle.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalle.Rows.Count - 1
                dgvDetalle.Item(8, i).Value = True
            Next
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

    Private Sub cmbSalida_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbSalida.MouseWheel
        If cmbSalida.DroppedDown Then
            Exit Sub
        Else
            cmbSalida.SelectedIndex = -1
            lblSalida.Focus()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
        bloquearEncabezado()
        btnNuevo.Visible = True
        btnGuardar.Visible = False
        btnSeleccion.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lblNumero.Focus()
        If validarCantidades() Then
            If validarDatos() Then
                obtenerNumero()
                BeginTransaction()
                If guardarMaestro() Then
                    If guardarDetalle() Then
                        If guardarMovimientoDetalle() Then
                            If cldevoluciones.ejecutarPolizaDevolucion(CInt(txtNumero.Text)) Then
                                If cldevoluciones.insertarSalidasMovimientos(CInt(cmbBodega.SelectedValue), CInt(cmbSalida.SelectedValue), CInt(txtNumero.Text)) Then
                                    CommitTransaction()
                                    MsgBox("Devolucion realizada", MsgBoxStyle.Information, "Guardado")
                                    If MessageBox.Show("Desa imprimir la devolucion", "Imprimir devolucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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
                Else
                    RollBackTransaction()
                    MsgBox("No se pudieron grabar los datos, operacion no se realizara", MsgBoxStyle.Exclamation, "Advetencia")
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados desea salir e ir a la busqueda?", "Ir a busqueda", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaDevolucionBodega
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
            Dim frm As New FrmBusquedaDevolucionBodega
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If validarEncabezado() Then
            If cargarDetalle() Then
                bloquearEncabezado()
            End If
        End If
    End Sub
End Class