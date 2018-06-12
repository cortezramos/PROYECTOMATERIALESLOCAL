Public Class FrmAprobarSolicitudes
#Region "Controles"
    Sub cargarSolicitudes()
        Dim dtSolicitudes As DataTable = clsolicitud.consultarSolicitudesPendientesAprobacion()
        For i = 0 To dtSolicitudes.Rows.Count - 1
            dgvSolicitudes.Rows.Add(dtSolicitudes.Rows(i)(0).ToString(), dtSolicitudes.Rows(i)(1).ToString(), dtSolicitudes.Rows(i)(2).ToString())
        Next
        dgvSolicitudes.Columns(0).Width = 70
        dgvSolicitudes.Columns(1).Width = 100
    End Sub

    Sub cargarAprobadas()
        With dgvAprobadas
            .Columns(0).Width = 70
            .Columns(1).Width = 100
        End With
    End Sub

    Function compbrobarDerecha() As Boolean
        For i = 0 To dgvAprobadas.Rows.Count - 1
            If dgvAprobadas.Item(0, i).Value = vNumero Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function

    Function compbrobarIzquierda() As Boolean
        For i = 0 To dgvSolicitudes.Rows.Count - 1
            If dgvSolicitudes.Item(0, i).Value = vNumero Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function

    Sub cargarSolicitaDetalle()
        With colSolicita
            .DataSource = clsolicitante.consultarNombreSolicitante()
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
        End With
    End Sub

    Sub cargarDetalle()
        Dim dtDetalle As DataTable = clsolicitud.seleccionSolicitudDetalle(vNumero)
        cargarSolicitaDetalle()
        dgvDetalle.Rows.Clear()
        For a As Integer = 0 To dtDetalle.Rows.Count - 1
            dgvDetalle.Rows.Add(dtDetalle.Rows(a)(1).ToString(), dtDetalle.Rows(a)(2).ToString(), dtDetalle.Rows(a)(3).ToString(), dtDetalle.Rows(a)(4).ToString(), dtDetalle.Rows(a)(5).ToString(), dtDetalle.Rows(a)(6).ToString(), dtDetalle.Rows(a)(7).ToString())
            dgvDetalle.Rows(a).Cells("colSolicita").Value = CInt(dtDetalle.Rows(a)(8).ToString())
        Next
        'dgvDetalle.Columns(0).Width = 50
        'dgvDetalle.Columns(4).Width = 65
        dgvDetalle.Columns(0).Visible = False
        dgvDetalle.Columns(4).Visible = False
        dgvDetalle.Columns(1).Width = 180
        dgvDetalle.Columns(2).Width = 60
        dgvDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(3).Width = 60
        dgvDetalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(6).Width = 150
        dgvDetalle.Columns(7).Width = 100
    End Sub

    Function detallesPendientesAGuardado() As Boolean
        BeginTransaction()
        If clsolicitud.modificarDetalleEstadoPendiente("G") Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

    Function aprobacionDetalle(Numero As Integer) As Boolean
        BeginTransaction()
        If clsolicitud.confirmarAprobacionDeSolicitudDetalle(Numero, "A") Then
            CommitTransaction()
        Else
            RollBackTransaction()
            Return False
        End If
        Return True
    End Function

#End Region
    Private dtAprobadas As DataTable
    Private clsolicitud As New clSolicitudMateriales
    Private clsolicitante As New clSolicitante
    Private vNumero As Integer
    Private vSolicitante As String
    Private vObservaciones As String
    Private indiceGrid As Integer

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If dgvAprobadas.Rows.Count > 0 Then
            If MessageBox.Show("Existen datos pendientes de aprobar desea salir?", "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                detallesPendientesAGuardado()
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub FrmAprobarSolicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSolicitudes()
        cargarAprobadas()
        dgvDetalle.Columns(0).Visible = False
        dgvDetalle.Columns(4).Visible = False
        dgvDetalle.Columns(1).Width = 180
        dgvDetalle.Columns(2).Width = 50
        dgvDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(3).Width = 50
        dgvDetalle.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns(6).Width = 150
        dgvDetalle.Columns(7).Width = 100
    End Sub

    Private Sub dgvSolicitudes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSolicitudes.CellClick
        If dgvSolicitudes.Rows.Count > 0 Then
            Dim i As Integer = dgvSolicitudes.CurrentRow.Index
            dgvSolicitudes.Rows(i).Selected = True
            vNumero = CInt(dgvSolicitudes.Item(0, i).Value)
            vSolicitante = dgvSolicitudes.Item(1, i).Value
            vObservaciones = dgvSolicitudes.Item(2, i).Value
            cargarDetalle()
        End If
    End Sub

    Private Sub btnDerecha_Click(sender As Object, e As EventArgs) Handles btnDerecha.Click
        If vNumero > 0 Then
            If String.IsNullOrEmpty(vSolicitante) = False Then
                If compbrobarDerecha() Then
                    dgvAprobadas.Rows.Add(vNumero, vSolicitante, vObservaciones)
                    dgvSolicitudes.Rows.Remove(dgvSolicitudes.CurrentRow)
                    dgvDetalle.Rows.Clear()
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                Else
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                End If
            Else
                MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnIzquierda_Click(sender As Object, e As EventArgs) Handles btnIzquierda.Click
        If vNumero > 0 Then
            If String.IsNullOrEmpty(vSolicitante) = False Then
                If compbrobarIzquierda() Then
                    dgvSolicitudes.Rows.Add(vNumero, vSolicitante, vObservaciones)
                    dgvAprobadas.Rows.Remove(dgvAprobadas.CurrentRow)
                    detallesPendientesAGuardado()
                    dgvDetalle.Rows.Clear()
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                Else
                    vNumero = 0
                    vSolicitante = ""
                    vObservaciones = ""
                End If
            Else
                MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione solicitud", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub dgvAprobadas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAprobadas.CellClick
        If dgvAprobadas.Rows.Count > 0 Then
            Dim i As Integer = dgvAprobadas.CurrentRow.Index
            dgvAprobadas.Rows(i).Selected = True
            vNumero = CInt(dgvAprobadas.Item(0, i).Value)
            vSolicitante = dgvAprobadas.Item(1, i).Value
            vObservaciones = dgvAprobadas.Item(2, i).Value
            cargarDetalle()
        End If
    End Sub

    Private Sub btnDerechaTodo_Click(sender As Object, e As EventArgs) Handles btnDerechaTodo.Click
        If dgvSolicitudes.Rows.Count > 0 Then
            For i As Integer = 0 To dgvSolicitudes.Rows.Count - 1
                dgvAprobadas.Rows.Add(dgvSolicitudes.Item(0, i).Value, dgvSolicitudes.Item(1, i).Value, dgvSolicitudes.Item(2, i).Value)
            Next
            dgvSolicitudes.Rows.Clear()
            dgvDetalle.Rows.Clear()
        Else
            MsgBox("No existen solicitudes para trasladar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnIzquierdaTodo_Click(sender As Object, e As EventArgs) Handles btnIzquierdaTodo.Click
        If dgvAprobadas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAprobadas.Rows.Count - 1
                dgvSolicitudes.Rows.Add(dgvAprobadas.Item(0, i).Value, dgvAprobadas.Item(1, i).Value, dgvAprobadas.Item(2, i).Value)
            Next
            detallesPendientesAGuardado()
            dgvAprobadas.Rows.Clear()
            dgvDetalle.Rows.Clear()
        Else
            MsgBox("No existen solicitudes para trasladar", MsgBoxStyle.Exclamation, "Advertencia")
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
                    dgvDetalle.ContextMenuStrip = menuContext
                End If
            End If
        End If
    End Sub

    Private Sub AnularItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularItemToolStripMenuItem.Click
        If MessageBox.Show("Desa anular el Producto: " & dgvDetalle.Item(0, indiceGrid).Value & " " & dgvDetalle.Item(1, indiceGrid).Value, "Anular?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            BeginTransaction()
            If clsolicitud.cambiarEstadoSolicitudDetallePorProducto(vNumero, "P", dgvDetalle.Item(0, indiceGrid).Value) Then
                CommitTransaction()
                cargarDetalle()
            Else
                RollBackTransaction()
                MsgBox("No se anulara el producto", MsgBoxStyle.Exclamation, "Error de sistema")
            End If
        Else
            MsgBox("No se anulara el producto", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvAprobadas.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAprobadas.Rows.Count - 1
                BeginTransaction()
                If clsolicitud.cambiarEstadoSolicitudMaestro(CInt(dgvAprobadas.Item(0, i).Value), "A") Then
                    CommitTransaction()
                    If aprobacionDetalle(CInt(dgvAprobadas.Item(0, i).Value)) Then
                        clsolicitud.anulacionSolicitudDetalleConfirmada(CInt(dgvAprobadas.Item(0, i).Value), "T")
                        dgvDetalle.Rows.Clear()
                        dgvSolicitudes.Rows.Clear()
                        cargarSolicitudes()
                    Else
                        MsgBox("Verificar Aprobacion de Solicitud Numero: " & dgvAprobadas.Item(0, i).Value, MsgBoxStyle.Exclamation, "Advertencia")
                    End If
                Else
                    RollBackTransaction()
                    MsgBox("Verificar Aprobacion de Solicitud Numero: " & dgvAprobadas.Item(0, i).Value, MsgBoxStyle.Exclamation, "Advertencia")
                    Exit Sub
                End If
            Next
            dgvAprobadas.Rows.Clear()
            MsgBox("Solicitudes aprobadas", MsgBoxStyle.Information, "Validado")
        Else
            MsgBox("No existen solicitudes para aprobar", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub
End Class