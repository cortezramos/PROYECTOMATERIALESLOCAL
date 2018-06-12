Imports Microsoft.ReportingServices
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Net

Public Class RptFacturadoProveedor
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

    Sub mostrarReporte()
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
        ServicePointManager.Expect100Continue = False

        rpt.ProcessingMode = ProcessingMode.Remote
        rpt.ServerReport.ReportServerUrl = New Uri(vUrlReportServer)
        rpt.ServerReport.ReportPath = "/" & vPathReportServer & "/FACTURADO PROVEEDOR"

        rpt.Visible = True
        rpt.ShowParameterPrompts = False
        rpt.ShowCredentialPrompts = True

        Dim parametros As List(Of ReportParameter) = New List(Of ReportParameter)()
        parametros.Add(New ReportParameter("empresa", empresaid))
        parametros.Add(New ReportParameter("proveedor", proveedores))
        parametros.Add(New ReportParameter("fechai", dtFechaI.Text))
        parametros.Add(New ReportParameter("fechaf", dtFechaF.Text))
        parametros.Add(New ReportParameter("moneda", CInt(cmbMoneda.SelectedValue)))

        rpt.ServerReport.SetParameters(parametros)
        rpt.RefreshReport()
    End Sub
#End Region
    Private clordenes As New clOrdenesCompra
    Private clproductos As New clProductos
    Private proveedores As String

    Private Sub RptFacturadoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = anchoPantalla - 350
        Height = altoPantalla - 75
        SplitContainer1.SplitterDistance = 150
        cargarProveedores(Nothing)
        cargarMoneda(Nothing)
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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        proveedores = cmbProveedor.Text
        If CDate(dtFechaI.Text) <= CDate(dtFechaF.Text) Then
            If cmbProveedor.SelectedValue = 0 Then
                If MessageBox.Show("Se consultaran todos los proveedores?", "Seleccion de proveedores!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    proveedores = "%%"
                    mostrarReporte()
                Else
                    MsgBox("Seleccione proveedor", MsgBoxStyle.Exclamation, "Error de ingreso")
                    cmbProveedor.Focus()
                End If
            Else
                mostrarReporte()
            End If
        Else
            MsgBox("Fecha final no puede ser menor a fecha inicial", MsgBoxStyle.Exclamation, "Error de operacion")
            dtFechaF.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbProveedor_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbProveedor.MouseWheel
        If cmbProveedor.DroppedDown Then
            Exit Sub
        Else
            cmbProveedor.SelectedIndex = -1
            lblProveedor.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_MouseWheel(sender As Object, e As MouseEventArgs) Handles cmbMoneda.MouseWheel
        If cmbMoneda.DroppedDown Then
            Exit Sub
        Else
            cmbMoneda.SelectedIndex = -1
            lblMoneda.Focus()
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