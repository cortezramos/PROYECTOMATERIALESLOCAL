Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptMovimientoInventarioCosto
#Region "Controles"
    Sub cargarTipoInventario()
        With cmbTipoInventario
            .DataSource = clProductos.consultarTipoInventario()
            .DisplayMember = "Descripcion"
            .ValueMember = "Codigo"
        End With
    End Sub

    Sub cargarBodegas()
        With cmbBodega
            .DataSource = clordenes.seleccionBodegaConsultaKardex()
            .ValueMember = "Codigo"
            .DisplayMember = "Descripcion"
        End With
    End Sub

    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False
        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/MOVIMIENTO INVENTARIO COSTO"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("fechai", CDate(dtFechaI.Text)))
        parametros.Add(New ReportParameter("fechaf", CDate(dtFechaF.Text)))
        parametros.Add(New ReportParameter("medida", "0"))
        parametros.Add(New ReportParameter("familia", tipoinventario))
        parametros.Add(New ReportParameter("bodega", CInt(cmbBodega.SelectedValue)))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
#End Region

    Private clproductos As New clProductos
    Private clordenes As New clOrdenesCompra
    Private tipoinventario As String

    Private Sub RptMovimientoInventarioCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTipoInventario()
        cargarBodegas()
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 150
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        tipoinventario = cmbTipoInventario.Text
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbBodega.SelectedValue > 0 Then
                If cmbTipoInventario.SelectedValue = 0 Then
                    If MessageBox.Show("Se consultaran todas las familias de productos?", "Seleccion de familias!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        tipoinventario = "%%"
                        mostrarReporte()
                    Else
                        MsgBox("Seleccione familia", MsgBoxStyle.Exclamation, "Error de ingreso")
                        cmbTipoInventario.Focus()
                    End If
                Else
                    mostrarReporte()
                End If
            Else
                MsgBox("Seleccione bodega", MsgBoxStyle.Exclamation, "Error de ingreso")
                cmbBodega.Focus()
            End If
        Else
            MsgBox("Fecha final debe ser mayor a fecha inicial", MsgBoxStyle.Exclamation, "Error de ingreso")
            dtFechaF.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbBodega_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbBodega.MouseWheel
        If cmbBodega.DroppedDown Then
            Exit Sub
        Else
            cmbBodega.SelectedIndex = -1
            lblBodega.Focus()
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