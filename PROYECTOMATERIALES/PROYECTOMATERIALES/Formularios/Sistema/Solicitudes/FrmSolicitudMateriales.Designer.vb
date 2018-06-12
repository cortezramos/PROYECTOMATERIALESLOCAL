<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudMateriales
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitudMateriales))
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cmbSolicitante = New System.Windows.Forms.ComboBox()
        Me.lblSolicitante = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcionCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolicita = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFechaD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxProductos = New System.Windows.Forms.GroupBox()
        Me.dtFechaD = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminarDetalle = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblCentroCosto = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cmbCentroCosto = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnSalirConsulta = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAnular = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.toolMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbxGeneral.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxProductos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.lblEstatus)
        Me.gbxGeneral.Controls.Add(Me.txtObservaciones)
        Me.gbxGeneral.Controls.Add(Me.lblObservaciones)
        Me.gbxGeneral.Controls.Add(Me.cmbSolicitante)
        Me.gbxGeneral.Controls.Add(Me.lblSolicitante)
        Me.gbxGeneral.Controls.Add(Me.dtFecha)
        Me.gbxGeneral.Controls.Add(Me.txtNumero)
        Me.gbxGeneral.Controls.Add(Me.lblFecha)
        Me.gbxGeneral.Controls.Add(Me.lblNumero)
        Me.gbxGeneral.Location = New System.Drawing.Point(8, 31)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(959, 123)
        Me.gbxGeneral.TabIndex = 2
        Me.gbxGeneral.TabStop = False
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.Location = New System.Drawing.Point(716, 50)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(0, 31)
        Me.lblEstatus.TabIndex = 6
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(111, 72)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(543, 40)
        Me.txtObservaciones.TabIndex = 8
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(14, 75)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(91, 13)
        Me.lblObservaciones.TabIndex = 7
        Me.lblObservaciones.Text = "Observaciones"
        '
        'cmbSolicitante
        '
        Me.cmbSolicitante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbSolicitante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolicitante.FormattingEnabled = True
        Me.cmbSolicitante.Location = New System.Drawing.Point(111, 45)
        Me.cmbSolicitante.Name = "cmbSolicitante"
        Me.cmbSolicitante.Size = New System.Drawing.Size(543, 21)
        Me.cmbSolicitante.TabIndex = 5
        '
        'lblSolicitante
        '
        Me.lblSolicitante.AutoSize = True
        Me.lblSolicitante.Location = New System.Drawing.Point(14, 48)
        Me.lblSolicitante.Name = "lblSolicitante"
        Me.lblSolicitante.Size = New System.Drawing.Size(67, 13)
        Me.lblSolicitante.TabIndex = 4
        Me.lblSolicitante.Text = "Solicitante"
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(531, 18)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(123, 20)
        Me.dtFecha.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(111, 18)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(135, 20)
        Me.txtNumero.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(475, 21)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(14, 21)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 13)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "Numero"
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Location = New System.Drawing.Point(8, 232)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(1017, 283)
        Me.gbxDetalle.TabIndex = 0
        Me.gbxDetalle.TabStop = False
        Me.gbxDetalle.Text = "Detalle"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colCantidad, Me.colSaldo, Me.colCentroCosto, Me.colDescripcionCentro, Me.colObservacion, Me.colSolicita, Me.colFechaD})
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 19)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(1005, 258)
        Me.dgvDetalle.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        '
        'colDescripcion
        '
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        '
        'colCantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        '
        'colSaldo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSaldo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSaldo.HeaderText = "Saldo Actual"
        Me.colSaldo.Name = "colSaldo"
        '
        'colCentroCosto
        '
        Me.colCentroCosto.HeaderText = "Centro Costo"
        Me.colCentroCosto.Name = "colCentroCosto"
        '
        'colDescripcionCentro
        '
        Me.colDescripcionCentro.HeaderText = "Descripcion Centro"
        Me.colDescripcionCentro.Name = "colDescripcionCentro"
        '
        'colObservacion
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colObservacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.colObservacion.HeaderText = "Observacion"
        Me.colObservacion.Name = "colObservacion"
        '
        'colSolicita
        '
        Me.colSolicita.DropDownWidth = 5
        Me.colSolicita.HeaderText = "Solicita"
        Me.colSolicita.Name = "colSolicita"
        Me.colSolicita.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSolicita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colFechaD
        '
        Me.colFechaD.HeaderText = "Fecha"
        Me.colFechaD.Name = "colFechaD"
        '
        'gbxProductos
        '
        Me.gbxProductos.Controls.Add(Me.dtFechaD)
        Me.gbxProductos.Controls.Add(Me.lblFechaD)
        Me.gbxProductos.Controls.Add(Me.btnCancelar)
        Me.gbxProductos.Controls.Add(Me.btnEliminarDetalle)
        Me.gbxProductos.Controls.Add(Me.btnAgregar)
        Me.gbxProductos.Controls.Add(Me.lblCantidad)
        Me.gbxProductos.Controls.Add(Me.lblCentroCosto)
        Me.gbxProductos.Controls.Add(Me.lblProducto)
        Me.gbxProductos.Controls.Add(Me.txtCantidad)
        Me.gbxProductos.Controls.Add(Me.cmbCentroCosto)
        Me.gbxProductos.Controls.Add(Me.cmbProducto)
        Me.gbxProductos.Location = New System.Drawing.Point(8, 154)
        Me.gbxProductos.Name = "gbxProductos"
        Me.gbxProductos.Size = New System.Drawing.Size(1017, 69)
        Me.gbxProductos.TabIndex = 3
        Me.gbxProductos.TabStop = False
        '
        'dtFechaD
        '
        Me.dtFechaD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaD.Location = New System.Drawing.Point(662, 35)
        Me.dtFechaD.Name = "dtFechaD"
        Me.dtFechaD.Size = New System.Drawing.Size(121, 20)
        Me.dtFechaD.TabIndex = 7
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.Location = New System.Drawing.Point(659, 16)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(102, 13)
        Me.lblFechaD.TabIndex = 3
        Me.lblFechaD.Text = "Fecha recepcion"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.PROYECTOMATERIALES.My.Resources.Resources._1441853939_undo
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.Location = New System.Drawing.Point(955, 30)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(26, 24)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarDetalle.Enabled = False
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(881, 30)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(68, 24)
        Me.btnEliminarDetalle.TabIndex = 9
        Me.btnEliminarDetalle.Text = "Eliminar"
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregar.Location = New System.Drawing.Point(807, 30)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(68, 24)
        Me.btnAgregar.TabIndex = 8
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(527, 16)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 2
        Me.lblCantidad.Text = "Cantidad"
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.Location = New System.Drawing.Point(276, 16)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(98, 13)
        Me.lblCentroCosto.TabIndex = 1
        Me.lblCentroCosto.Text = "Centro de Costo"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(30, 16)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(58, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(531, 34)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(116, 20)
        Me.txtCantidad.TabIndex = 6
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCentroCosto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.DropDownWidth = 400
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.Location = New System.Drawing.Point(280, 34)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(243, 21)
        Me.cmbCentroCosto.TabIndex = 5
        Me.toolMensaje.SetToolTip(Me.cmbCentroCosto, "Presione F7 para buscar")
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.DropDownWidth = 400
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(29, 34)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(243, 21)
        Me.cmbProducto.TabIndex = 4
        Me.toolMensaje.SetToolTip(Me.cmbProducto, "Presione F7 para buscar")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnSalirConsulta, Me.btnNuevo, Me.btnAnular, Me.btnGuardar, Me.btnModificar, Me.btnImprimir, Me.btnBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1034, 25)
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
        'btnSalirConsulta
        '
        Me.btnSalirConsulta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalirConsulta.Image = CType(resources.GetObject("btnSalirConsulta.Image"), System.Drawing.Image)
        Me.btnSalirConsulta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalirConsulta.Name = "btnSalirConsulta"
        Me.btnSalirConsulta.Size = New System.Drawing.Size(23, 22)
        Me.btnSalirConsulta.Text = "Salir"
        Me.btnSalirConsulta.Visible = False
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
        'btnAnular
        '
        Me.btnAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(23, 22)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.Visible = False
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
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(23, 22)
        Me.btnModificar.Text = "Guardar"
        Me.btnModificar.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(23, 22)
        Me.btnImprimir.Text = "Imprimir"
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
        'FrmSolicitudMateriales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1034, 521)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbxProductos)
        Me.Controls.Add(Me.gbxDetalle)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmSolicitudMateriales"
        Me.Text = "Solicitud de materiales"
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxProductos.ResumeLayout(False)
        Me.gbxProductos.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents cmbSolicitante As System.Windows.Forms.ComboBox
    Friend WithEvents lblSolicitante As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents gbxProductos As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblCentroCosto As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents cmbCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnSalirConsulta As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents toolMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtFechaD As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcionCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicita As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFechaD As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
