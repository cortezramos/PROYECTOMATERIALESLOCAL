<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnAlta = New System.Windows.Forms.ToolStripButton()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.cmbTipoInventario = New System.Windows.Forms.ComboBox()
        Me.lblTipoInventario = New System.Windows.Forms.Label()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.chkAfectaExistencia = New System.Windows.Forms.CheckBox()
        Me.chkMaterialVenta = New System.Windows.Forms.CheckBox()
        Me.lblMaximo = New System.Windows.Forms.Label()
        Me.txtMaximo = New System.Windows.Forms.TextBox()
        Me.lblMinimo = New System.Windows.Forms.Label()
        Me.txtMinimo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.gbxSugerencia = New System.Windows.Forms.GroupBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.gbxMedida = New System.Windows.Forms.GroupBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblMedida = New System.Windows.Forms.Label()
        Me.cmbMedida = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxSugerencia.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxMedida.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnNuevo, Me.btnBuscar, Me.btnGuardar, Me.btnEliminar, Me.btnAlta, Me.btnEditar, Me.btnModificar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(999, 25)
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
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(23, 22)
        Me.btnBuscar.Text = "Buscar"
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
        'btnEliminar
        '
        Me.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.btnEliminar.Text = "Inactivar"
        Me.btnEliminar.Visible = False
        '
        'btnAlta
        '
        Me.btnAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAlta.Image = CType(resources.GetObject("btnAlta.Image"), System.Drawing.Image)
        Me.btnAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(23, 22)
        Me.btnAlta.Text = "Activar"
        Me.btnAlta.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(23, 22)
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(23, 22)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.Visible = False
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.txtEstado)
        Me.gbxGeneral.Controls.Add(Me.cmbTipoInventario)
        Me.gbxGeneral.Controls.Add(Me.lblTipoInventario)
        Me.gbxGeneral.Controls.Add(Me.cmbMoneda)
        Me.gbxGeneral.Controls.Add(Me.lblMoneda)
        Me.gbxGeneral.Controls.Add(Me.chkAfectaExistencia)
        Me.gbxGeneral.Controls.Add(Me.chkMaterialVenta)
        Me.gbxGeneral.Controls.Add(Me.lblMaximo)
        Me.gbxGeneral.Controls.Add(Me.txtMaximo)
        Me.gbxGeneral.Controls.Add(Me.lblMinimo)
        Me.gbxGeneral.Controls.Add(Me.txtMinimo)
        Me.gbxGeneral.Controls.Add(Me.txtDescripcion)
        Me.gbxGeneral.Controls.Add(Me.lblDescripcion)
        Me.gbxGeneral.Controls.Add(Me.txtObservaciones)
        Me.gbxGeneral.Controls.Add(Me.lblObservaciones)
        Me.gbxGeneral.Controls.Add(Me.lblEstado)
        Me.gbxGeneral.Controls.Add(Me.txtCodigo)
        Me.gbxGeneral.Controls.Add(Me.lblCodigo)
        Me.gbxGeneral.Location = New System.Drawing.Point(12, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(596, 265)
        Me.gbxGeneral.TabIndex = 1
        Me.gbxGeneral.TabStop = False
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(396, 22)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(185, 20)
        Me.txtEstado.TabIndex = 3
        '
        'cmbTipoInventario
        '
        Me.cmbTipoInventario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoInventario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoInventario.FormattingEnabled = True
        Me.cmbTipoInventario.Location = New System.Drawing.Point(115, 51)
        Me.cmbTipoInventario.Name = "cmbTipoInventario"
        Me.cmbTipoInventario.Size = New System.Drawing.Size(466, 21)
        Me.cmbTipoInventario.TabIndex = 5
        '
        'lblTipoInventario
        '
        Me.lblTipoInventario.AutoSize = True
        Me.lblTipoInventario.Location = New System.Drawing.Point(14, 54)
        Me.lblTipoInventario.Name = "lblTipoInventario"
        Me.lblTipoInventario.Size = New System.Drawing.Size(93, 13)
        Me.lblTipoInventario.TabIndex = 4
        Me.lblTipoInventario.Text = "Tipo Inventario"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(115, 230)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(466, 21)
        Me.cmbMoneda.TabIndex = 17
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(14, 233)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(98, 13)
        Me.lblMoneda.TabIndex = 16
        Me.lblMoneda.Text = "Moneda Precios"
        '
        'chkAfectaExistencia
        '
        Me.chkAfectaExistencia.AutoSize = True
        Me.chkAfectaExistencia.Location = New System.Drawing.Point(307, 157)
        Me.chkAfectaExistencia.Name = "chkAfectaExistencia"
        Me.chkAfectaExistencia.Size = New System.Drawing.Size(125, 17)
        Me.chkAfectaExistencia.TabIndex = 13
        Me.chkAfectaExistencia.Text = "Afecta Existencia"
        Me.chkAfectaExistencia.UseVisualStyleBackColor = True
        '
        'chkMaterialVenta
        '
        Me.chkMaterialVenta.AutoSize = True
        Me.chkMaterialVenta.Location = New System.Drawing.Point(145, 157)
        Me.chkMaterialVenta.Name = "chkMaterialVenta"
        Me.chkMaterialVenta.Size = New System.Drawing.Size(126, 17)
        Me.chkMaterialVenta.TabIndex = 12
        Me.chkMaterialVenta.Text = "Material en Venta"
        Me.chkMaterialVenta.UseVisualStyleBackColor = True
        '
        'lblMaximo
        '
        Me.lblMaximo.AutoSize = True
        Me.lblMaximo.Location = New System.Drawing.Point(280, 133)
        Me.lblMaximo.Name = "lblMaximo"
        Me.lblMaximo.Size = New System.Drawing.Size(49, 13)
        Me.lblMaximo.TabIndex = 10
        Me.lblMaximo.Text = "Maximo"
        '
        'txtMaximo
        '
        Me.txtMaximo.Location = New System.Drawing.Point(332, 130)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Size = New System.Drawing.Size(100, 20)
        Me.txtMaximo.TabIndex = 11
        Me.txtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMinimo
        '
        Me.lblMinimo.AutoSize = True
        Me.lblMinimo.Location = New System.Drawing.Point(119, 133)
        Me.lblMinimo.Name = "lblMinimo"
        Me.lblMinimo.Size = New System.Drawing.Size(46, 13)
        Me.lblMinimo.TabIndex = 8
        Me.lblMinimo.Text = "Minimo"
        '
        'txtMinimo
        '
        Me.txtMinimo.Location = New System.Drawing.Point(171, 130)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtMinimo.TabIndex = 9
        Me.txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 81)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(466, 40)
        Me.txtDescripcion.TabIndex = 7
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(14, 84)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(74, 13)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripcion"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(115, 184)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(466, 40)
        Me.txtObservaciones.TabIndex = 15
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(14, 187)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(92, 13)
        Me.lblObservaciones.TabIndex = 14
        Me.lblObservaciones.Text = "Descr. General"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(344, 25)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(115, 25)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(135, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(14, 25)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(46, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'gbxSugerencia
        '
        Me.gbxSugerencia.Controls.Add(Me.dgvDatos)
        Me.gbxSugerencia.Location = New System.Drawing.Point(614, 28)
        Me.gbxSugerencia.Name = "gbxSugerencia"
        Me.gbxSugerencia.Size = New System.Drawing.Size(373, 338)
        Me.gbxSugerencia.TabIndex = 3
        Me.gbxSugerencia.TabStop = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(6, 12)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(361, 320)
        Me.dgvDatos.TabIndex = 0
        '
        'gbxMedida
        '
        Me.gbxMedida.Controls.Add(Me.txtPrecio)
        Me.gbxMedida.Controls.Add(Me.lblPrecio)
        Me.gbxMedida.Controls.Add(Me.lblMedida)
        Me.gbxMedida.Controls.Add(Me.cmbMedida)
        Me.gbxMedida.Location = New System.Drawing.Point(12, 299)
        Me.gbxMedida.Name = "gbxMedida"
        Me.gbxMedida.Size = New System.Drawing.Size(596, 67)
        Me.gbxMedida.TabIndex = 2
        Me.gbxMedida.TabStop = False
        Me.gbxMedida.Text = "Unidad Medida"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(481, 29)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio.TabIndex = 3
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(425, 32)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(43, 13)
        Me.lblPrecio.TabIndex = 2
        Me.lblPrecio.Text = "Precio"
        '
        'lblMedida
        '
        Me.lblMedida.AutoSize = True
        Me.lblMedida.Location = New System.Drawing.Point(25, 32)
        Me.lblMedida.Name = "lblMedida"
        Me.lblMedida.Size = New System.Drawing.Size(47, 13)
        Me.lblMedida.TabIndex = 0
        Me.lblMedida.Text = "Unidad"
        '
        'cmbMedida
        '
        Me.cmbMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedida.FormattingEnabled = True
        Me.cmbMedida.Location = New System.Drawing.Point(78, 29)
        Me.cmbMedida.Name = "cmbMedida"
        Me.cmbMedida.Size = New System.Drawing.Size(312, 21)
        Me.cmbMedida.TabIndex = 1
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(999, 378)
        Me.Controls.Add(Me.gbxMedida)
        Me.Controls.Add(Me.gbxSugerencia)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmProductos"
        Me.ShowIcon = False
        Me.Text = "Productos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxSugerencia.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxMedida.ResumeLayout(False)
        Me.gbxMedida.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoInventario As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoInventario As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents chkAfectaExistencia As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaterialVenta As System.Windows.Forms.CheckBox
    Friend WithEvents lblMaximo As System.Windows.Forms.Label
    Friend WithEvents txtMaximo As System.Windows.Forms.TextBox
    Friend WithEvents lblMinimo As System.Windows.Forms.Label
    Friend WithEvents txtMinimo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents gbxSugerencia As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents gbxMedida As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblMedida As System.Windows.Forms.Label
    Friend WithEvents cmbMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAlta As System.Windows.Forms.ToolStripButton
End Class
