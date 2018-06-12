Public Class FrmSolicitudMateriales
#Region "Controles"
    Sub cargarGrid()
        dgvDetalle.Rows.Clear()
        dgvDetalle.Columns(0).Width = 50
        dgvDetalle.Columns(2).Width = 50
        dgvDetalle.Columns(3).Width = 50
        dgvDetalle.Columns(5).Width = 100
        dgvDetalle.Columns(6).Width = 100
        dgvDetalle.Columns(7).Width = 100
        dgvDetalle.Columns(8).Width = 75
        dgvDetalle.Columns(4).Visible = False
        dgvDetalle.Columns(0).ReadOnly = True
        dgvDetalle.Columns(1).ReadOnly = True
        dgvDetalle.Columns(2).ReadOnly = True
        dgvDetalle.Columns(3).ReadOnly = True
        dgvDetalle.Columns(5).ReadOnly = True
        dgvDetalle.Columns(8).ReadOnly = True
    End Sub

    Sub bloquearGrid()
        With dgvDetalle
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
        End With
    End Sub
    Sub bloquearEncabezado()
        cmbSolicitante.Enabled = False
        txtObservaciones.Enabled = False
    End Sub
    Sub desbloquearEncabezado()
        cmbSolicitante.Enabled = True
        txtObservaciones.Enabled = True
    End Sub
    Sub bloquearDetalle()
        cmbCentroCosto.Enabled = False
        dtFechaD.Enabled = False
        txtCantidad.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarDetalle.Enabled = False
        btnCancelar.Enabled = False
        cmbProducto.Enabled = False
    End Sub

    Sub desbloquearDetalle()
        cmbCentroCosto.Enabled = True
        dtFechaD.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        cmbProducto.Enabled = True
    End Sub
    Sub cargarSolicitaDetalle()
        With colSolicita
            .DataSource = clsolicitante.consultarNombreSolicitante()
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
        End With
    End Sub

    Sub cargarSolicitantes(Valor As Integer)
        If Valor <> Nothing Then
            With cmbSolicitante
                .DataSource = clsolicitante.consultarNombreSolicitante()
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .SelectedValue = Valor
            End With
        Else
            With cmbSolicitante
                .DataSource = clsolicitante.consultarNombreSolicitante()
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
            End With
        End If
    End Sub

    Public Sub cargarProductos(Valor As String)
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
            dtConsultaDeCentro = clcentrocosto.consultaCentroDeCosto()
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

    Sub obtenerNumero()
        txtNumero.Text = clsolicitud.ultimoNumeroSolicitud()
    End Sub

    Sub obtenerInfoProducto()
        Dim dtDato As DataTable = clproducto.consultarInformacionPantallaBusqueda(cmbProducto.SelectedValue)
        If dtDato.Rows.Count > 0 Then
            nombreproducto = dtDato.Rows(0)(0).ToString()
            saldoproducto = CDec(dtDato.Rows(0)(1).ToString())
        Else
            nombreproducto = "N/A"
            saldoproducto = 0.0
        End If
    End Sub

    Sub obtenerInforCentroCosto()
        Dim dtDato As DataTable = clsolicitud.consultarInformacionCentroCosto(cmbCentroCosto.SelectedValue)
        descripcioncentro = dtDato.Rows(0)(0).ToString()
    End Sub

    Function guardarMaestro() As Boolean
        BeginTransaction()
        If clsolicitud.insertarSolicitudMaestro(CInt(txtNumero.Text), CDate(dtFecha.Text), CInt(cmbSolicitante.SelectedValue), txtObservaciones.Text) Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Function guardarDetalle() As Boolean
        For i As Integer = 0 To dgvDetalle.Rows.Count - 1
            If IsDBNull(dgvDetalle.Item(6, i).Value) Then
                dgvDetalle.Item(6, i).Value = "."
                lblProducto.Focus()
            ElseIf dgvDetalle.Item(6, i).Value = "" Then
                dgvDetalle.Item(6, i).Value = "."
                lblProducto.Focus()
            End If
            BeginTransaction()
            If clsolicitud.insertarSolicitudDetalle(CInt(txtNumero.Text), dgvDetalle.Item(0, i).Value, dgvDetalle.Item(1, i).Value, CDec(dgvDetalle.Item(2, i).Value), dgvDetalle.Item(6, i).Value, dgvDetalle.Item(8, i).Value, dgvDetalle.Item(7, i).Value, dgvDetalle.Item(4, i).Value, dgvDetalle.Item(5, i).Value) Then
                CommitTransaction()
            Else
                RollBackTransaction()
                Return False
            End If
        Next
        Return True
    End Function

    Function eliminarMaestro() As Boolean
        BeginTransaction()
        If clsolicitud.eliminarSolicitudMaestro(CInt(txtNumero.Text)) Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Function anularDocumento() As Boolean
        BeginTransaction()
        If clsolicitud.cambiarEstadoSolicitudMaestro(CInt(txtNumero.Text), "T") Then
            If clsolicitud.cambiarEstadoSolicitudDetalle(CInt(txtNumero.Text), "T") Then
                CommitTransaction()
            Else
                RollBackTransaction()
                Return False
            End If
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Function verificarProductoEnDetalle(Producto As String) As Boolean
        For i = 0 To dgvDetalle.Rows.Count - 1
            If dgvDetalle.Item(0, i).Value = Producto Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function

    Function eliminarDetalle() As Boolean
        BeginTransaction()
        If clsolicitud.eliminarSolicitudDetalle(CInt(txtNumero.Text)) Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Sub imprimirSolicitud()
        Dim frm As New RptSolicitud
        With frm
            .Numero = CInt(Me.txtNumero.Text)
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Function verificarFechaSolicitud() As Boolean
        If dtFechaD.Value < Today.AddDays(6) Then
            If MessageBox.Show("La fecha de solicitud de producto tiene un rango muy corto, desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If
        Return True
    End Function
#End Region
    Private clsolicitud As New clSolicitudMateriales
    Private clsolicitante As New clSolicitante
    Private clproducto As New clProductos
    Private clcentrocosto As New clCentroCosto
    Private saldoproducto As Decimal
    Private nombreproducto As String
    Private descripcioncentro As String
    Private dtConsultaDeProducto As New DataTable
    Private dtConsultaDeCentro As New DataTable

    Private Sub FrmSolicitudMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bloquearEncabezado()
        bloquearDetalle()
        cargarSolicitantes(Nothing)
        cargarCentroDeCostos(Nothing)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos ingresados, Dese salir?", "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                dtConsultaProductos = New DataTable
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            dtConsultaProductos = New DataTable
            Me.Close()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        desbloquearEncabezado()
        desbloquearDetalle()
        obtenerNumero()
        cargarGrid()
        cargarProductos(Nothing)
        btnNuevo.Visible = False
        btnGuardar.Visible = True
        lblEstatus.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        lblNumero.Focus()
        obtenerNumero()
        If cmbSolicitante.SelectedValue > 0 Then
            If String.IsNullOrEmpty(txtObservaciones.Text) Then
                MsgBox("Ingrese una observacion de la solicitud", MsgBoxStyle.Exclamation, "Error de validacion")
                cmbProducto.SelectedIndex = 0
                txtObservaciones.Focus()
            Else
                If dgvDetalle.Rows.Count > 0 Then
                    If guardarMaestro() Then
                        If guardarDetalle() Then
                            bloquearEncabezado()
                            bloquearDetalle()
                            MsgBox("Registro guardado correctamente", MsgBoxStyle.Information)
                            If MessageBox.Show("Desea imprimir solicitud", "Imprimir?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                imprimirSolicitud()
                            End If
                            txtNumero.Text = ""
                            dtFechaD.Value = Today
                            cargarSolicitantes(Nothing)
                            txtObservaciones.Text = ""
                            cargarProductos(Nothing)
                            cargarCentroDeCostos(Nothing)
                            txtCantidad.Text = ""
                            dgvDetalle.Rows.Clear()
                            lblEstatus.Text = ""
                            btnGuardar.Visible = False
                            btnNuevo.Visible = True
                        Else
                            If eliminarMaestro() Then
                                MsgBox("No se guardo el registro", MsgBoxStyle.Exclamation, "Error de sistema")
                            Else
                                MsgBox("No se guardo el registro, error eliminando datos", MsgBoxStyle.Exclamation, "Error de sistema")
                            End If
                        End If
                    End If
                Else
                    MsgBox("Debe ingresar materiales para esta solicitud", MsgBoxStyle.Exclamation, "Error de validacion")
                    cmbProducto.Focus()
                End If
            End If
        Else
            MsgBox("Seleccione solicitante", MsgBoxStyle.Exclamation, "Error de validacion")
            cmbSolicitante.Focus()
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbProducto.SelectedValue > 0 Then
            If cmbCentroCosto.SelectedValue <> "0" Then
                If String.IsNullOrEmpty(txtCantidad.Text) Then
                    MsgBox("Ingrese cantidad de producto a solicitar", MsgBoxStyle.Exclamation, "Error de validacion")
                    txtCantidad.Focus()
                Else
                    If CDec(txtCantidad.Text) > 0 Then
                        If CDate(dtFechaD.Text) >= Today Then
                            If (dtFechaD.Value.Month - Today.Month) <= 2 Then
                                If verificarProductoEnDetalle(cmbProducto.SelectedValue) Then
                                    If verificarFechaSolicitud() Then
                                        obtenerInfoProducto()
                                        obtenerInforCentroCosto()
                                        dgvDetalle.Rows.Add(cmbProducto.SelectedValue, nombreproducto, CDec(txtCantidad.Text), saldoproducto, cmbCentroCosto.SelectedValue, descripcioncentro, ".", 0, dtFechaD.Text)
                                        cargarProductos(Nothing)
                                        cargarCentroDeCostos(Nothing)
                                        txtCantidad.Text = ""
                                        dtFechaD.Value = Today
                                        cmbProducto.Focus()
                                        cargarSolicitaDetalle()
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    MsgBox("Producto ya fue agregado a solicitud", MsgBoxStyle.Exclamation, "Error de validacion")
                                    cmbProducto.Focus()
                                End If
                            Else
                                MsgBox("Fecha recepcion no puede ser mayor a dos meses", MsgBoxStyle.Exclamation, "Error de validacion")
                                dtFechaD.Focus()
                            End If
                        Else
                            MsgBox("Fecha no puede ser menor a hoy", MsgBoxStyle.Exclamation, "Error de validacion")
                            dtFechaD.Focus()
                        End If
                    Else
                        MsgBox("Ingrese cantidad mayor a cero no se aceptan valores negativos", MsgBoxStyle.Exclamation, "Error de validacion")
                        txtCantidad.Focus()
                    End If
                End If
            Else
                MsgBox("Seleccione centro de costo", MsgBoxStyle.Exclamation, "Advertencia")
                cmbCentroCosto.Focus()
            End If
        Else
            MsgBox("Seleccione producto para realizar solicitud", MsgBoxStyle.Exclamation, "Advertencia")
            cmbProducto.Focus()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If btnNuevo.Visible = True Then
            Dim frm As New FrmBusquedaSolicitudes
            With frm
                .ControlBox = False
                .Show()
                .MdiParent = Me.MdiParent
                .Location = New Point(302, 2)
            End With
            Me.Close()
        Else
            'MsgBox("No se puede buscar informacion mientras se editan datos", MsgBoxStyle.Exclamation, "Advertencia")
            If MessageBox.Show("Existen datos en pantalla desea salir e ir a la busqueda?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New FrmBusquedaSolicitudes
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

    Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        If lblEstatus.Text = "Grabado" Or lblEstatus.Text = "" Then
            If dgvDetalle.Rows.Count > 0 Then
                Dim i As Integer = dgvDetalle.CurrentRow.Index
                cargarProductos(dgvDetalle.Item(0, i).Value)
                txtCantidad.Text = dgvDetalle.Item(2, i).Value
                cargarCentroDeCostos(dgvDetalle.Item(4, i).Value)
                dtFechaD.Text = dgvDetalle.Item(8, i).Value

                btnAgregar.Enabled = False
                btnEliminarDetalle.Enabled = True
                btnCancelar.Enabled = True
                cmbProducto.Enabled = False
                cmbCentroCosto.Enabled = False
                txtCantidad.Enabled = False
                dtFechaD.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)

        cargarProductos(Nothing)
        txtCantidad.Text = ""
        cargarCentroDeCostos(Nothing)
        dtFechaD.Value = Today

        btnAgregar.Enabled = True
        btnEliminarDetalle.Enabled = False
        btnCancelar.Enabled = False
        cmbProducto.Enabled = True
        cmbCentroCosto.Enabled = True
        txtCantidad.Enabled = True
        dtFechaD.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cargarProductos(Nothing)
        dtFechaD.Value = Today
        dtFechaD.Enabled = True
        txtCantidad.Text = ""
        cargarCentroDeCostos(Nothing)

        btnAgregar.Enabled = True
        btnEliminarDetalle.Enabled = False
        btnCancelar.Enabled = False
        cmbProducto.Enabled = True
        cmbCentroCosto.Enabled = True
        txtCantidad.Enabled = True
    End Sub

    Private Sub btnSalirConsulta_Click(sender As Object, e As EventArgs) Handles btnSalirConsulta.Click
        If dgvDetalle.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos sin guardar, desea salir?", "Existen datos ingresados!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                dtConsultaProductos = New DataTable
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            dtConsultaProductos = New DataTable
            Me.Close()
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If lblEstatus.Text = "Cerrado" Then
            MsgBox("Este documento se encuentra en estatus cerrado", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Grabado" Then
            If MessageBox.Show("Desea anular este documento", "Anular!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                If anularDocumento() Then
                    bloquearEncabezado()
                    bloquearDetalle()
                    txtNumero.Text = ""
                    cargarSolicitantes(Nothing)
                    txtObservaciones.Text = ""
                    cargarProductos(Nothing)
                    cargarCentroDeCostos(Nothing)
                    txtCantidad.Text = ""
                    dgvDetalle.Rows.Clear()
                    lblEstatus.Text = ""
                    btnModificar.Visible = False
                    btnAnular.Visible = False
                    btnSalirConsulta.Visible = False
                    btnSalir.Visible = True
                    btnNuevo.Visible = True
                    MsgBox("Anulacion de documento correcta", MsgBoxStyle.Information)
                Else
                    MsgBox("No se pudo realizar la anulacion", MsgBoxStyle.Exclamation, "Error de sistema")
                End If
            End If
        ElseIf lblEstatus.Text = "Aprobado" Then
            MsgBox("No se puede anular un documento aprobado", MsgBoxStyle.Information, "Advertencia")
        ElseIf lblEstatus.Text = "" Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        lblNumero.Focus()
        If lblEstatus.Text = "Grabado" Then
            If MessageBox.Show("Desea modificar los datos de esta solicitud", "Modificar!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                If eliminarDetalle() Then
                    If guardarDetalle() Then
                        bloquearEncabezado()
                        bloquearDetalle()
                        txtNumero.Text = ""
                        dtFechaD.Value = Today
                        cargarSolicitantes(Nothing)
                        txtObservaciones.Text = ""
                        cargarProductos(Nothing)
                        cargarCentroDeCostos(Nothing)
                        txtCantidad.Text = ""
                        dgvDetalle.Rows.Clear()
                        lblEstatus.Text = ""
                        btnModificar.Visible = False
                        btnAnular.Visible = False
                        btnSalirConsulta.Visible = False
                        btnSalir.Visible = True
                        btnNuevo.Visible = True
                        MsgBox("Registro modificado correctamente", MsgBoxStyle.Information)
                    Else
                        MsgBox("No se guardo la informacion ", MsgBoxStyle.Exclamation, "Error de sistema")
                    End If
                Else
                    MsgBox("No es posible guardar las modificaciones", MsgBoxStyle.Exclamation, "Error de sistema")
                End If
            End If
        ElseIf lblEstatus.Text = "Cerrado" Then
            MsgBox("Este documento se encuentra en estatus cerrado", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf lblEstatus.Text = "Aprobado" Then
            MsgBox("No se puede modificar un documento aprobado", MsgBoxStyle.Information, "Advertencia")
        ElseIf lblEstatus.Text = "" Then
            MsgBox("Debe estar un documento activo", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub cmbSolicitante_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbSolicitante.MouseWheel
        If cmbSolicitante.DroppedDown Then
            Exit Sub
        Else
            cmbSolicitante.SelectedIndex = -1
            lblSolicitante.Focus()
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

    Private Sub cmbCentroCosto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbCentroCosto.MouseWheel
        If cmbCentroCosto.DroppedDown Then
            Exit Sub
        Else
            cmbCentroCosto.SelectedIndex = -1
            lblSolicitante.Focus()
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

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If txtObservaciones.Text.Length = 50 Then
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            dgvDetalle.Rows(i).Selected = True
        End If
    End Sub

    Private Sub dgvDetalle_Enter(sender As Object, e As EventArgs) Handles dgvDetalle.Enter
        If dgvDetalle.Rows.Count > 0 Then
            Dim i As Integer = dgvDetalle.CurrentRow.Index
            dgvDetalle.Rows(i).Selected = True
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
                imprimirSolicitud()
            End If
        End If
    End Sub
End Class