<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjustes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustes))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnContabilidad = New System.Windows.Forms.ToolStripButton()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabAjuste = New System.Windows.Forms.TabPage()
        Me.gbxProductos = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbTipoAjuste = New System.Windows.Forms.ComboBox()
        Me.lblTipoAjuste = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cmbBodega = New System.Windows.Forms.ComboBox()
        Me.lblBodega = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.tabPoliza = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalAbono = New System.Windows.Forms.TextBox()
        Me.lblTotales = New System.Windows.Forms.Label()
        Me.dgvPoliza = New System.Windows.Forms.DataGridView()
        Me.colCentroPoliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescrCentroPoliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCuentaPoliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescrCuentaPoliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalCargo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.btnCancelaPoliza = New System.Windows.Forms.Button()
        Me.btnEliminaPoliza = New System.Windows.Forms.Button()
        Me.btnAgregaPoliza = New System.Windows.Forms.Button()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.txtAbono = New System.Windows.Forms.TextBox()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblCuentaPoliza = New System.Windows.Forms.Label()
        Me.lblCentroPoliza = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.cmbCuentaPoliza = New System.Windows.Forms.ComboBox()
        Me.cmbCentroPoliza = New System.Windows.Forms.ComboBox()
        Me.gbxPoliza = New System.Windows.Forms.GroupBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescrPoliza = New System.Windows.Forms.Label()
        Me.txtNumeroPoliza = New System.Windows.Forms.TextBox()
        Me.lblNumeroPoliza = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabAjuste.SuspendLayout()
        Me.gbxProductos.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxGeneral.SuspendLayout()
        Me.tabPoliza.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPoliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbxPoliza.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnNuevo, Me.btnGuardar, Me.btnContabilidad, Me.btnLimpiar, Me.btnBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(926, 25)
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
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.btnNuevo.Text = "Nuevo"
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
        'btnContabilidad
        '
        Me.btnContabilidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContabilidad.Image = CType(resources.GetObject("btnContabilidad.Image"), System.Drawing.Image)
        Me.btnContabilidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContabilidad.Name = "btnContabilidad"
        Me.btnContabilidad.Size = New System.Drawing.Size(23, 22)
        Me.btnContabilidad.Text = "Contabilidad"
        Me.btnContabilidad.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(23, 22)
        Me.btnLimpiar.Text = "Cancelar"
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabAjuste)
        Me.tabControl.Controls.Add(Me.tabPoliza)
        Me.tabControl.Location = New System.Drawing.Point(6, 28)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(916, 516)
        Me.tabControl.TabIndex = 0
        '
        'tabAjuste
        '
        Me.tabAjuste.Controls.Add(Me.gbxProductos)
        Me.tabAjuste.Controls.Add(Me.gbxDetalle)
        Me.tabAjuste.Controls.Add(Me.gbxGeneral)
        Me.tabAjuste.Location = New System.Drawing.Point(4, 22)
        Me.tabAjuste.Name = "tabAjuste"
        Me.tabAjuste.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAjuste.Size = New System.Drawing.Size(908, 490)
        Me.tabAjuste.TabIndex = 0
        Me.tabAjuste.Text = "Ajuste"
        Me.tabAjuste.UseVisualStyleBackColor = True
        '
        'gbxProductos
        '
        Me.gbxProductos.Controls.Add(Me.btnCancelar)
        Me.gbxProductos.Controls.Add(Me.btnEliminar)
        Me.gbxProductos.Controls.Add(Me.btnAgregar)
        Me.gbxProductos.Controls.Add(Me.lblCantidad)
        Me.gbxProductos.Controls.Add(Me.lblProducto)
        Me.gbxProductos.Controls.Add(Me.txtCantidad)
        Me.gbxProductos.Controls.Add(Me.cmbProducto)
        Me.gbxProductos.Location = New System.Drawing.Point(10, 150)
        Me.gbxProductos.Name = "gbxProductos"
        Me.gbxProductos.Size = New System.Drawing.Size(769, 46)
        Me.gbxProductos.TabIndex = 1
        Me.gbxProductos.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.PROYECTOMATERIALES.My.Resources.Resources._1441853939_undo
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.Location = New System.Drawing.Point(730, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(26, 24)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Location = New System.Drawing.Point(656, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(68, 24)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregar.Location = New System.Drawing.Point(582, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 24)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(397, 16)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 4
        Me.lblCantidad.Text = "Cantidad"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(26, 16)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(58, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(460, 13)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(116, 20)
        Me.txtCantidad.TabIndex = 5
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.DropDownWidth = 400
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(90, 13)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(301, 21)
        Me.cmbProducto.TabIndex = 1
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Location = New System.Drawing.Point(10, 202)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(769, 283)
        Me.gbxDetalle.TabIndex = 2
        Me.gbxDetalle.TabStop = False
        Me.gbxDetalle.Text = "Detalle"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(3, 16)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(763, 264)
        Me.dgvDetalle.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 101.5228!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 80.5266!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.FillWeight = 85.88966!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 132.0609!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Medida"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.cmbTipoAjuste)
        Me.gbxGeneral.Controls.Add(Me.lblTipoAjuste)
        Me.gbxGeneral.Controls.Add(Me.txtObservaciones)
        Me.gbxGeneral.Controls.Add(Me.lblObservaciones)
        Me.gbxGeneral.Controls.Add(Me.cmbBodega)
        Me.gbxGeneral.Controls.Add(Me.lblBodega)
        Me.gbxGeneral.Controls.Add(Me.dtFecha)
        Me.gbxGeneral.Controls.Add(Me.txtNumero)
        Me.gbxGeneral.Controls.Add(Me.lblFecha)
        Me.gbxGeneral.Controls.Add(Me.lblNumero)
        Me.gbxGeneral.Location = New System.Drawing.Point(10, 6)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(769, 144)
        Me.gbxGeneral.TabIndex = 0
        Me.gbxGeneral.TabStop = False
        '
        'cmbTipoAjuste
        '
        Me.cmbTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoAjuste.FormattingEnabled = True
        Me.cmbTipoAjuste.Items.AddRange(New Object() {"--Seleccione tipo de ajuste", "Ajuste positivo", "Ajuste negativo"})
        Me.cmbTipoAjuste.Location = New System.Drawing.Point(138, 69)
        Me.cmbTipoAjuste.Name = "cmbTipoAjuste"
        Me.cmbTipoAjuste.Size = New System.Drawing.Size(560, 21)
        Me.cmbTipoAjuste.TabIndex = 7
        '
        'lblTipoAjuste
        '
        Me.lblTipoAjuste.AutoSize = True
        Me.lblTipoAjuste.Location = New System.Drawing.Point(26, 72)
        Me.lblTipoAjuste.Name = "lblTipoAjuste"
        Me.lblTipoAjuste.Size = New System.Drawing.Size(71, 13)
        Me.lblTipoAjuste.TabIndex = 6
        Me.lblTipoAjuste.Text = "Tipo Ajuste"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(138, 98)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(560, 40)
        Me.txtObservaciones.TabIndex = 9
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(26, 101)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(91, 13)
        Me.lblObservaciones.TabIndex = 8
        Me.lblObservaciones.Text = "Observaciones"
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(138, 42)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(560, 21)
        Me.cmbBodega.TabIndex = 5
        '
        'lblBodega
        '
        Me.lblBodega.AutoSize = True
        Me.lblBodega.Location = New System.Drawing.Point(26, 45)
        Me.lblBodega.Name = "lblBodega"
        Me.lblBodega.Size = New System.Drawing.Size(50, 13)
        Me.lblBodega.TabIndex = 4
        Me.lblBodega.Text = "Bodega"
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(575, 16)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(123, 20)
        Me.dtFecha.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(138, 16)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(135, 20)
        Me.txtNumero.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(519, 19)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(26, 19)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 13)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "Numero"
        '
        'tabPoliza
        '
        Me.tabPoliza.Controls.Add(Me.GroupBox1)
        Me.tabPoliza.Controls.Add(Me.GroupBox2)
        Me.tabPoliza.Controls.Add(Me.gbxPoliza)
        Me.tabPoliza.Location = New System.Drawing.Point(4, 22)
        Me.tabPoliza.Name = "tabPoliza"
        Me.tabPoliza.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPoliza.Size = New System.Drawing.Size(908, 490)
        Me.tabPoliza.TabIndex = 1
        Me.tabPoliza.Text = "Poliza"
        Me.tabPoliza.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalAbono)
        Me.GroupBox1.Controls.Add(Me.lblTotales)
        Me.GroupBox1.Controls.Add(Me.dgvPoliza)
        Me.GroupBox1.Controls.Add(Me.txtTotalCargo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(896, 318)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'txtTotalAbono
        '
        Me.txtTotalAbono.Location = New System.Drawing.Point(604, 291)
        Me.txtTotalAbono.Name = "txtTotalAbono"
        Me.txtTotalAbono.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalAbono.TabIndex = 3
        '
        'lblTotales
        '
        Me.lblTotales.AutoSize = True
        Me.lblTotales.Location = New System.Drawing.Point(450, 294)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(49, 13)
        Me.lblTotales.TabIndex = 1
        Me.lblTotales.Text = "Totales"
        '
        'dgvPoliza
        '
        Me.dgvPoliza.AllowUserToAddRows = False
        Me.dgvPoliza.AllowUserToDeleteRows = False
        Me.dgvPoliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPoliza.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvPoliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPoliza.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCentroPoliza, Me.colDescrCentroPoliza, Me.colCuentaPoliza, Me.colDescrCuentaPoliza, Me.colCargo, Me.colAbono, Me.colNota})
        Me.dgvPoliza.Location = New System.Drawing.Point(7, 19)
        Me.dgvPoliza.Name = "dgvPoliza"
        Me.dgvPoliza.ReadOnly = True
        Me.dgvPoliza.RowHeadersVisible = False
        Me.dgvPoliza.Size = New System.Drawing.Size(883, 266)
        Me.dgvPoliza.TabIndex = 0
        '
        'colCentroPoliza
        '
        Me.colCentroPoliza.HeaderText = "Centro"
        Me.colCentroPoliza.Name = "colCentroPoliza"
        Me.colCentroPoliza.ReadOnly = True
        '
        'colDescrCentroPoliza
        '
        Me.colDescrCentroPoliza.HeaderText = "Descripcion Centro"
        Me.colDescrCentroPoliza.Name = "colDescrCentroPoliza"
        Me.colDescrCentroPoliza.ReadOnly = True
        '
        'colCuentaPoliza
        '
        Me.colCuentaPoliza.HeaderText = "Cuenta"
        Me.colCuentaPoliza.Name = "colCuentaPoliza"
        Me.colCuentaPoliza.ReadOnly = True
        '
        'colDescrCuentaPoliza
        '
        Me.colDescrCuentaPoliza.HeaderText = "Descripcion Cuenta"
        Me.colDescrCuentaPoliza.Name = "colDescrCuentaPoliza"
        Me.colDescrCuentaPoliza.ReadOnly = True
        '
        'colCargo
        '
        Me.colCargo.HeaderText = "Cargo"
        Me.colCargo.Name = "colCargo"
        Me.colCargo.ReadOnly = True
        '
        'colAbono
        '
        Me.colAbono.HeaderText = "Abono"
        Me.colAbono.Name = "colAbono"
        Me.colAbono.ReadOnly = True
        '
        'colNota
        '
        Me.colNota.HeaderText = "Nota"
        Me.colNota.Name = "colNota"
        Me.colNota.ReadOnly = True
        '
        'txtTotalCargo
        '
        Me.txtTotalCargo.Location = New System.Drawing.Point(505, 291)
        Me.txtTotalCargo.Name = "txtTotalCargo"
        Me.txtTotalCargo.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalCargo.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNota)
        Me.GroupBox2.Controls.Add(Me.txtNota)
        Me.GroupBox2.Controls.Add(Me.btnCancelaPoliza)
        Me.GroupBox2.Controls.Add(Me.btnEliminaPoliza)
        Me.GroupBox2.Controls.Add(Me.btnAgregaPoliza)
        Me.GroupBox2.Controls.Add(Me.lblAbono)
        Me.GroupBox2.Controls.Add(Me.txtAbono)
        Me.GroupBox2.Controls.Add(Me.lblCargo)
        Me.GroupBox2.Controls.Add(Me.lblCuentaPoliza)
        Me.GroupBox2.Controls.Add(Me.lblCentroPoliza)
        Me.GroupBox2.Controls.Add(Me.txtCargo)
        Me.GroupBox2.Controls.Add(Me.cmbCuentaPoliza)
        Me.GroupBox2.Controls.Add(Me.cmbCentroPoliza)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 59)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblNota
        '
        Me.lblNota.AutoSize = True
        Me.lblNota.Location = New System.Drawing.Point(600, 14)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(34, 13)
        Me.lblNota.TabIndex = 8
        Me.lblNota.Text = "Nota"
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(604, 32)
        Me.txtNota.MaxLength = 40
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(101, 20)
        Me.txtNota.TabIndex = 9
        '
        'btnCancelaPoliza
        '
        Me.btnCancelaPoliza.BackgroundImage = Global.PROYECTOMATERIALES.My.Resources.Resources._1441853939_undo
        Me.btnCancelaPoliza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelaPoliza.Location = New System.Drawing.Point(859, 29)
        Me.btnCancelaPoliza.Name = "btnCancelaPoliza"
        Me.btnCancelaPoliza.Size = New System.Drawing.Size(26, 24)
        Me.btnCancelaPoliza.TabIndex = 12
        Me.btnCancelaPoliza.UseVisualStyleBackColor = True
        '
        'btnEliminaPoliza
        '
        Me.btnEliminaPoliza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminaPoliza.Enabled = False
        Me.btnEliminaPoliza.Location = New System.Drawing.Point(785, 29)
        Me.btnEliminaPoliza.Name = "btnEliminaPoliza"
        Me.btnEliminaPoliza.Size = New System.Drawing.Size(68, 24)
        Me.btnEliminaPoliza.TabIndex = 11
        Me.btnEliminaPoliza.Text = "Eliminar"
        Me.btnEliminaPoliza.UseVisualStyleBackColor = True
        '
        'btnAgregaPoliza
        '
        Me.btnAgregaPoliza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregaPoliza.Location = New System.Drawing.Point(711, 29)
        Me.btnAgregaPoliza.Name = "btnAgregaPoliza"
        Me.btnAgregaPoliza.Size = New System.Drawing.Size(68, 24)
        Me.btnAgregaPoliza.TabIndex = 10
        Me.btnAgregaPoliza.Text = "Agregar"
        Me.btnAgregaPoliza.UseVisualStyleBackColor = True
        '
        'lblAbono
        '
        Me.lblAbono.AutoSize = True
        Me.lblAbono.Location = New System.Drawing.Point(519, 14)
        Me.lblAbono.Name = "lblAbono"
        Me.lblAbono.Size = New System.Drawing.Size(43, 13)
        Me.lblAbono.TabIndex = 6
        Me.lblAbono.Text = "Abono"
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(523, 32)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(75, 20)
        Me.txtAbono.TabIndex = 7
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Location = New System.Drawing.Point(438, 14)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(40, 13)
        Me.lblCargo.TabIndex = 4
        Me.lblCargo.Text = "Cargo"
        '
        'lblCuentaPoliza
        '
        Me.lblCuentaPoliza.AutoSize = True
        Me.lblCuentaPoliza.Location = New System.Drawing.Point(222, 14)
        Me.lblCuentaPoliza.Name = "lblCuentaPoliza"
        Me.lblCuentaPoliza.Size = New System.Drawing.Size(101, 13)
        Me.lblCuentaPoliza.TabIndex = 2
        Me.lblCuentaPoliza.Text = "Cuenta Contable"
        '
        'lblCentroPoliza
        '
        Me.lblCentroPoliza.AutoSize = True
        Me.lblCentroPoliza.Location = New System.Drawing.Point(10, 14)
        Me.lblCentroPoliza.Name = "lblCentroPoliza"
        Me.lblCentroPoliza.Size = New System.Drawing.Size(98, 13)
        Me.lblCentroPoliza.TabIndex = 0
        Me.lblCentroPoliza.Text = "Centro de Costo"
        '
        'txtCargo
        '
        Me.txtCargo.Location = New System.Drawing.Point(442, 32)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(75, 20)
        Me.txtCargo.TabIndex = 5
        '
        'cmbCuentaPoliza
        '
        Me.cmbCuentaPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaPoliza.DropDownWidth = 400
        Me.cmbCuentaPoliza.FormattingEnabled = True
        Me.cmbCuentaPoliza.Location = New System.Drawing.Point(226, 32)
        Me.cmbCuentaPoliza.Name = "cmbCuentaPoliza"
        Me.cmbCuentaPoliza.Size = New System.Drawing.Size(210, 21)
        Me.cmbCuentaPoliza.TabIndex = 3
        '
        'cmbCentroPoliza
        '
        Me.cmbCentroPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroPoliza.DropDownWidth = 400
        Me.cmbCentroPoliza.FormattingEnabled = True
        Me.cmbCentroPoliza.Location = New System.Drawing.Point(9, 32)
        Me.cmbCentroPoliza.Name = "cmbCentroPoliza"
        Me.cmbCentroPoliza.Size = New System.Drawing.Size(210, 21)
        Me.cmbCentroPoliza.TabIndex = 1
        '
        'gbxPoliza
        '
        Me.gbxPoliza.Controls.Add(Me.txtDescripcion)
        Me.gbxPoliza.Controls.Add(Me.lblDescrPoliza)
        Me.gbxPoliza.Controls.Add(Me.txtNumeroPoliza)
        Me.gbxPoliza.Controls.Add(Me.lblNumeroPoliza)
        Me.gbxPoliza.Location = New System.Drawing.Point(6, 6)
        Me.gbxPoliza.Name = "gbxPoliza"
        Me.gbxPoliza.Size = New System.Drawing.Size(812, 89)
        Me.gbxPoliza.TabIndex = 0
        Me.gbxPoliza.TabStop = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(118, 39)
        Me.txtDescripcion.MaxLength = 150
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(560, 40)
        Me.txtDescripcion.TabIndex = 3
        '
        'lblDescrPoliza
        '
        Me.lblDescrPoliza.AutoSize = True
        Me.lblDescrPoliza.Location = New System.Drawing.Point(6, 42)
        Me.lblDescrPoliza.Name = "lblDescrPoliza"
        Me.lblDescrPoliza.Size = New System.Drawing.Size(74, 13)
        Me.lblDescrPoliza.TabIndex = 2
        Me.lblDescrPoliza.Text = "Descripcion"
        '
        'txtNumeroPoliza
        '
        Me.txtNumeroPoliza.Location = New System.Drawing.Point(118, 13)
        Me.txtNumeroPoliza.Name = "txtNumeroPoliza"
        Me.txtNumeroPoliza.ReadOnly = True
        Me.txtNumeroPoliza.Size = New System.Drawing.Size(121, 20)
        Me.txtNumeroPoliza.TabIndex = 1
        '
        'lblNumeroPoliza
        '
        Me.lblNumeroPoliza.AutoSize = True
        Me.lblNumeroPoliza.Location = New System.Drawing.Point(6, 16)
        Me.lblNumeroPoliza.Name = "lblNumeroPoliza"
        Me.lblNumeroPoliza.Size = New System.Drawing.Size(50, 13)
        Me.lblNumeroPoliza.TabIndex = 0
        Me.lblNumeroPoliza.Text = "Numero"
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
        'FrmAjustes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(926, 551)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmAjustes"
        Me.Text = "Ajustes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabAjuste.ResumeLayout(False)
        Me.gbxProductos.ResumeLayout(False)
        Me.gbxProductos.PerformLayout()
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.tabPoliza.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPoliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbxPoliza.ResumeLayout(False)
        Me.gbxPoliza.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabAjuste As System.Windows.Forms.TabPage
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents lblBodega As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents tabPoliza As System.Windows.Forms.TabPage
    Friend WithEvents gbxPoliza As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumeroPoliza As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroPoliza As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescrPoliza As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPoliza As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents txtAbono As System.Windows.Forms.TextBox
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents lblCuentaPoliza As System.Windows.Forms.Label
    Friend WithEvents lblCentroPoliza As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCuentaPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCentroPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents gbxProductos As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoAjuste As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoAjuste As System.Windows.Forms.Label
    Friend WithEvents btnEliminaPoliza As System.Windows.Forms.Button
    Friend WithEvents btnAgregaPoliza As System.Windows.Forms.Button
    Friend WithEvents btnCancelaPoliza As System.Windows.Forms.Button
    Friend WithEvents txtTotalAbono As System.Windows.Forms.TextBox
    Friend WithEvents lblTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotalCargo As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnContabilidad As System.Windows.Forms.ToolStripButton
    Friend WithEvents colCentroPoliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescrCentroPoliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCuentaPoliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescrCuentaPoliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
End Class
