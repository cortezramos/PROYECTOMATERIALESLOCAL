Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptIngresoProducto
#Region "Controles"
    Sub cargarTipoInventario()
        With cmbTipoInventario
            .DataSource = clproductos.consultarTipoInventario()
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
        End With
    End Sub

    Public Sub cargarProductos(Valor As String)
        If Valor <> Nothing Then
            With cmbProducto
                .DataSource = clsolicitud.consultaProductosReporteria()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
                .SelectedValue = Valor
            End With
        Else
            With cmbProducto
                .DataSource = clsolicitud.consultaProductosReporteria()
                .ValueMember = "Codigo"
                .DisplayMember = "Descripcion"
            End With
        End If
    End Sub

    Sub mostrarReporte()
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
            ServicePointManager.Expect100Continue = False
            rpt.ProcessingMode = ProcessingMode.Remote
            rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
            rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/PRODUCTO INGRESO"

            rpt.Visible = True
            rpt.ShowParameterPrompts = False
            rpt.ShowCredentialPrompts = True

            Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
            parametros.Add(New ReportParameter("empresa", empresaid))
            parametros.Add(New ReportParameter("fechai", CDate(dtFechaI.Text)))
            parametros.Add(New ReportParameter("fechaf", CDate(dtFechaF.Text)))
            parametros.Add(New ReportParameter("producto", CStr(cmbProducto.SelectedValue)))
            parametros.Add(New ReportParameter("tipo", tipoinventario))

            rpt.ServerReport.SetParameters(parametros)
            rpt.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

#End Region
    Private clproductos As New clProductos
    Private clsolicitud As New clSolicitudMateriales
    Private tipoinventario As String = ""

    Private Sub RptIngresoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTipoInventario()
        cargarProductos(Nothing)
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 100
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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbProducto.SelectedValue <> "0" Then
                mostrarReporte()
            Else
                MsgBox("Seleccione producto", MsgBoxStyle.Exclamation, "Error de operacion")
                cmbProducto.Focus()
            End If
        Else
            MsgBox("Fecha final no puede ser menor a fecha inicial", MsgBoxStyle.Exclamation, "Error de operacion")
            dtFechaF.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbProducto_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProducto.MouseWheel
        If cmbProducto.DroppedDown Then
            Exit Sub
        Else
            cmbProducto.SelectedIndex = -1
            lblProducto.Focus()
        End If
    End Sub

    Private Sub cmbTipoInventario_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbTipoInventario.MouseWheel
        If cmbTipoInventario.DroppedDown Then
            Exit Sub
        Else
            cmbTipoInventario.SelectedIndex = -1
            lblTipo.Focus()
        End If
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cmbProducto.SelectedIndex > 0 Then
            tipoinventario = clproductos.tipoInventarioPorProducto(CStr(cmbProducto.SelectedValue))
        End If
    End Sub

    Private Sub dtFechaI_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFechaI.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.SendWait("{RIGHT}")
        End If
    End Sub

    Private Sub dtFechaF_KeyDown(sender As Object, e As KeyEventArgs) Handles dtFechaF.KeyDown
        If e.KeyValue = Keys.Enter Then
            SendKeys.SendWait("{RIGHT}")
        End If
    End Sub
End Class