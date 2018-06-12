<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoBodega
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngresoBodega))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.btnSeleccion = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.tbIngreso = New System.Windows.Forms.TabPage()
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbBodega = New System.Windows.Forms.ComboBox()
        Me.lblBodega = New System.Windows.Forms.Label()
        Me.txtIngreso = New System.Windows.Forms.TextBox()
        Me.lblIngreso = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.tbConsulta = New System.Windows.Forms.TabPage()
        Me.gbxOrdenEnvio = New System.Windows.Forms.GroupBox()
        Me.lblSeleccion = New System.Windows.Forms.Label()
        Me.chkEnvios = New System.Windows.Forms.CheckBox()
        Me.dgvVista = New System.Windows.Forms.DataGridView()
        Me.chkOrdenes = New System.Windows.Forms.CheckBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.dgvPendientes = New System.Windows.Forms.DataGridView()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.tbIngreso.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxGeneral.SuspendLayout()
        Me.tbConsulta.SuspendLayout()
        Me.gbxOrdenEnvio.SuspendLayout()
        CType(Me.dgvVista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnCancelar, Me.btnGuardar, Me.btnConsultar, Me.btnSeleccion, Me.btnBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(838, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(23, 22)
        Me.btnSalir.Text = "Salir"
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(23, 22)
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(23, 22)
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.Visible = False
        '
        'btnSeleccion
        '
        Me.btnSeleccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSeleccion.Image = CType(resources.GetObject("btnSeleccion.Image"), System.Drawing.Image)
        Me.btnSeleccion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSeleccion.Name = "btnSeleccion"
        Me.btnSeleccion.Size = New System.Drawing.Size(23, 22)
        Me.btnSeleccion.Text = "Seleccionar todo"
        Me.btnSeleccion.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(23, 22)
        Me.btnBuscar.Text = "Buscar"
        '
        'tbIngreso
        '
        Me.tbIngreso.Controls.Add(Me.gbxDetalle)
        Me.tbIngreso.Controls.Add(Me.gbxGeneral)
        Me.tbIngreso.Location = New System.Drawing.Point(4, 22)
        Me.tbIngreso.Name = "tbIngreso"
        Me.tbIngreso.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIngreso.Size = New System.Drawing.Size(818, 453)
        Me.tbIngreso.TabIndex = 1
        Me.tbIngreso.Text = "Ingresar a bodega"
        Me.tbIngreso.UseVisualStyleBackColor = True
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Location = New System.Drawing.Point(6, 84)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(806, 364)
        Me.gbxDetalle.TabIndex = 9
        Me.gbxDetalle.TabStop = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 14)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(794, 344)
        Me.dgvDetalle.TabIndex = 0
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.cmbBodega)
        Me.gbxGeneral.Controls.Add(Me.lblBodega)
        Me.gbxGeneral.Controls.Add(Me.txtIngreso)
        Me.gbxGeneral.Controls.Add(Me.lblIngreso)
        Me.gbxGeneral.Controls.Add(Me.dtFecha)
        Me.gbxGeneral.Controls.Add(Me.lblFecha)
        Me.gbxGeneral.Controls.Add(Me.txtNumero)
        Me.gbxGeneral.Controls.Add(Me.lblNumero)
        Me.gbxGeneral.Location = New System.Drawing.Point(6, 6)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(806, 73)
        Me.gbxGeneral.TabIndex = 6
        Me.gbxGeneral.TabStop = False
        '
        'cmbBodega
        '
        Me.cmbBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.Enabled = False
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(112, 42)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(487, 21)
        Me.cmbBodega.TabIndex = 9
        '
        'lblBodega
        '
        Me.lblBodega.AutoSize = True
        Me.lblBodega.Location = New System.Drawing.Point(17, 45)
        Me.lblBodega.Name = "lblBodega"
        Me.lblBodega.Size = New System.Drawing.Size(50, 13)
        Me.lblBodega.TabIndex = 8
        Me.lblBodega.Text = "Bodega"
        '
        'txtIngreso
        '
        Me.txtIngreso.Location = New System.Drawing.Point(349, 17)
        Me.txtIngreso.Name = "txtIngreso"
        Me.txtIngreso.ReadOnly = True
        Me.txtIngreso.Size = New System.Drawing.Size(54, 20)
        Me.txtIngreso.TabIndex = 3
        '
        'lblIngreso
        '
        Me.lblIngreso.AutoSize = True
        Me.lblIngreso.Location = New System.Drawing.Point(270, 20)
        Me.lblIngreso.Name = "lblIngreso"
        Me.lblIngreso.Size = New System.Drawing.Size(73, 13)
        Me.lblIngreso.TabIndex = 2
        Me.lblIngreso.Text = "No. Ingreso"
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(479, 14)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(120, 20)
        Me.dtFecha.TabIndex = 5
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(431, 17)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(112, 17)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(149, 20)
        Me.txtNumero.TabIndex = 1
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(15, 20)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 13)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "Numero"
        '
        'tbConsulta
        '
        Me.tbConsulta.Controls.Add(Me.gbxOrdenEnvio)
        Me.tbConsulta.Location = New System.Drawing.Point(4, 22)
        Me.tbConsulta.Name = "tbConsulta"
        Me.tbConsulta.Padding = New System.Windows.Forms.Padding(3)
        Me.tbConsulta.Size = New System.Drawing.Size(818, 453)
        Me.tbConsulta.TabIndex = 0
        Me.tbConsulta.Text = "Datos de consulta"
        Me.tbConsulta.UseVisualStyleBackColor = True
        '
        'gbxOrdenEnvio
        '
        Me.gbxOrdenEnvio.Controls.Add(Me.lblSeleccion)
        Me.gbxOrdenEnvio.Controls.Add(Me.chkEnvios)
        Me.gbxOrdenEnvio.Controls.Add(Me.dgvVista)
        Me.gbxOrdenEnvio.Controls.Add(Me.chkOrdenes)
        Me.gbxOrdenEnvio.Controls.Add(Me.txtOrden)
        Me.gbxOrdenEnvio.Controls.Add(Me.txtBuscar)
        Me.gbxOrdenEnvio.Controls.Add(Me.lblBuscar)
        Me.gbxOrdenEnvio.Controls.Add(Me.dgvPendientes)
        Me.gbxOrdenEnvio.Location = New System.Drawing.Point(7, 7)
        Me.gbxOrdenEnvio.Name = "gbxOrdenEnvio"
        Me.gbxOrdenEnvio.Size = New System.Drawing.Size(805, 440)
        Me.gbxOrdenEnvio.TabIndex = 0
        Me.gbxOrdenEnvio.TabStop = False
        '
        'lblSeleccion
        '
        Me.lblSeleccion.AutoSize = True
        Me.lblSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccion.Location = New System.Drawing.Point(359, 45)
        Me.lblSeleccion.Name = "lblSeleccion"
        Me.lblSeleccion.Size = New System.Drawing.Size(0, 20)
        Me.lblSeleccion.TabIndex = 7
        '
        'chkEnvios
        '
        Me.chkEnvios.AutoSize = True
        Me.chkEnvios.Enabled = False
        Me.chkEnvios.Location = New System.Drawing.Point(164, 45)
        Me.chkEnvios.Name = "chkEnvios"
        Me.chkEnvios.Size = New System.Drawing.Size(131, 17)
        Me.chkEnvios.TabIndex = 4
        Me.chkEnvios.Text = "Envios Pendientes"
        Me.chkEnvios.UseVisualStyleBackColor = True
        '
        'dgvVista
        '
        Me.dgvVista.AllowUserToAddRows = False
        Me.dgvVista.AllowUserToDeleteRows = False
        Me.dgvVista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVista.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVista.Location = New System.Drawing.Point(352, 72)
        Me.dgvVista.Name = "dgvVista"
        Me.dgvVista.ReadOnly = True
        Me.dgvVista.Size = New System.Drawing.Size(447, 360)
        Me.dgvVista.TabIndex = 6
        '
        'chkOrdenes
        '
        Me.chkOrdenes.AutoSize = True
        Me.chkOrdenes.Enabled = False
        Me.chkOrdenes.Location = New System.Drawing.Point(22, 45)
        Me.chkOrdenes.Name = "chkOrdenes"
        Me.chkOrdenes.Size = New System.Drawing.Size(139, 17)
        Me.chkOrdenes.TabIndex = 3
        Me.chkOrdenes.Text = "Ordenes pendientes"
        Me.chkOrdenes.UseVisualStyleBackColor = True
        '
        'txtOrden
        '
        Me.txtOrden.Enabled = False
        Me.txtOrden.Location = New System.Drawing.Point(771, 16)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(28, 20)
        Me.txtOrden.TabIndex = 0
        Me.txtOrden.Text = "0"
        Me.txtOrden.Visible = False
        '
        'txtBuscar
        '
        Me.txtBuscar.Enabled = False
        Me.txtBuscar.Location = New System.Drawing.Point(63, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(416, 20)
        Me.txtBuscar.TabIndex = 2
        Me.toolTip.SetToolTip(Me.txtBuscar, "Presione F7 para buscar por Producto")
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(11, 19)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(46, 13)
        Me.lblBuscar.TabIndex = 1
        Me.lblBuscar.Text = "Buscar"
        '
        'dgvPendientes
        '
        Me.dgvPendientes.AllowUserToAddRows = False
        Me.dgvPendientes.AllowUserToDeleteRows = False
        Me.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPendientes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendientes.Enabled = False
        Me.dgvPendientes.Location = New System.Drawing.Point(7, 72)
        Me.dgvPendientes.Name = "dgvPendientes"
        Me.dgvPendientes.ReadOnly = True
        Me.dgvPendientes.Size = New System.Drawing.Size(339, 360)
        Me.dgvPendientes.TabIndex = 5
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tbConsulta)
        Me.tabControl.Controls.Add(Me.tbIngreso)
        Me.tabControl.Location = New System.Drawing.Point(5, 27)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(826, 479)
        Me.tabControl.TabIndex = 1
        '
        'FrmIngresoBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(838, 510)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmIngresoBodega"
        Me.Text = "Ingreso a Bodega"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tbIngreso.ResumeLayout(False)
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.tbConsulta.ResumeLayout(False)
        Me.gbxOrdenEnvio.ResumeLayout(False)
        Me.gbxOrdenEnvio.PerformLayout()
        CType(Me.dgvVista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSeleccion As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbIngreso As System.Windows.Forms.TabPage
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents lblBodega As System.Windows.Forms.Label
    Friend WithEvents txtIngreso As System.Windows.Forms.TextBox
    Friend WithEvents lblIngreso As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents tbConsulta As System.Windows.Forms.TabPage
    Friend WithEvents dgvVista As System.Windows.Forms.DataGridView
    Friend WithEvents gbxOrdenEnvio As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnvios As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrdenes As System.Windows.Forms.CheckBox
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents dgvPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSeleccion As System.Windows.Forms.Label
    Friend WithEvents toolTip As System.Windows.Forms.ToolTip
End Class
