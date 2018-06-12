<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlantillasNuevas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlantillasNuevas))
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbFinca = New System.Windows.Forms.ComboBox()
        Me.lblFinca = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcionCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxProductos = New System.Windows.Forms.GroupBox()
        Me.btnEliminarDetalle = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblCentroCosto = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxProductos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.cmbFinca)
        Me.gbxGeneral.Controls.Add(Me.lblFinca)
        Me.gbxGeneral.Controls.Add(Me.txtNombre)
        Me.gbxGeneral.Controls.Add(Me.lblNombre)
        Me.gbxGeneral.Location = New System.Drawing.Point(14, 29)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(908, 78)
        Me.gbxGeneral.TabIndex = 0
        Me.gbxGeneral.TabStop = False
        '
        'cmbFinca
        '
        Me.cmbFinca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinca.FormattingEnabled = True
        Me.cmbFinca.Location = New System.Drawing.Point(152, 45)
        Me.cmbFinca.Name = "cmbFinca"
        Me.cmbFinca.Size = New System.Drawing.Size(352, 21)
        Me.cmbFinca.TabIndex = 22
        '
        'lblFinca
        '
        Me.lblFinca.AutoSize = True
        Me.lblFinca.Location = New System.Drawing.Point(30, 48)
        Me.lblFinca.Name = "lblFinca"
        Me.lblFinca.Size = New System.Drawing.Size(97, 13)
        Me.lblFinca.TabIndex = 2
        Me.lblFinca.Text = "Finca destinada"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(152, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(652, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(30, 19)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(117, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre de Plantilla"
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Location = New System.Drawing.Point(14, 181)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(908, 210)
        Me.gbxDetalle.TabIndex = 21
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colCentroCosto, Me.colDescripcionCentroCosto, Me.colObservacion})
        Me.dgvDetalle.Location = New System.Drawing.Point(8, 19)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(892, 185)
        Me.dgvDetalle.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colDescripcion
        '
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colCentroCosto
        '
        Me.colCentroCosto.HeaderText = "Centro Costo"
        Me.colCentroCosto.Name = "colCentroCosto"
        Me.colCentroCosto.ReadOnly = True
        '
        'colDescripcionCentroCosto
        '
        Me.colDescripcionCentroCosto.HeaderText = "Descripcion Centro"
        Me.colDescripcionCentroCosto.Name = "colDescripcionCentroCosto"
        Me.colDescripcionCentroCosto.ReadOnly = True
        '
        'colObservacion
        '
        Me.colObservacion.HeaderText = "Observacion"
        Me.colObservacion.Name = "colObservacion"
        Me.colObservacion.ReadOnly = True
        '
        'gbxProductos
        '
        Me.gbxProductos.Controls.Add(Me.btnEliminarDetalle)
        Me.gbxProductos.Controls.Add(Me.btnAgregar)
        Me.gbxProductos.Controls.Add(Me.lblCentroCosto)
        Me.gbxProductos.Controls.Add(Me.lblProducto)
        Me.gbxProductos.Controls.Add(Me.cmbCentroCosto)
        Me.gbxProductos.Controls.Add(Me.cmbProducto)
        Me.gbxProductos.Location = New System.Drawing.Point(14, 112)
        Me.gbxProductos.Name = "gbxProductos"
        Me.gbxProductos.Size = New System.Drawing.Size(908, 69)
        Me.gbxProductos.TabIndex = 22
        Me.gbxProductos.TabStop = False
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.BackgroundImage = CType(resources.GetObject("btnEliminarDetalle.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(676, 26)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(39, 35)
        Me.btnEliminarDetalle.TabIndex = 21
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = CType(resources.GetObject("btnAgregar.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregar.Location = New System.Drawing.Point(637, 26)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(39, 35)
        Me.btnAgregar.TabIndex = 20
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.Location = New System.Drawing.Point(322, 16)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(98, 13)
        Me.lblCentroCosto.TabIndex = 4
        Me.lblCentroCosto.Text = "Centro de Costo"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(35, 16)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(58, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.Location = New System.Drawing.Point(327, 34)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(283, 21)
        Me.cmbCentroCosto.TabIndex = 1
        '
        'cmbProducto
        '
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(34, 34)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(283, 21)
        Me.cmbProducto.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnNuevo, Me.btnGuardar, Me.btnEliminar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(933, 25)
        Me.ToolStrip1.TabIndex = 23
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
        '
        'btnEliminar
        '
        Me.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.btnEliminar.Text = "Eliminar"
        '
        'FrmPlantillasNuevas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(933, 403)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbxProductos)
        Me.Controls.Add(Me.gbxDetalle)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmPlantillasNuevas"
        Me.Text = "Plantillas nuevas"
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
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents gbxProductos As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblCentroCosto As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents cmbFinca As System.Windows.Forms.ComboBox
    Friend WithEvents lblFinca As System.Windows.Forms.Label
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcionCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
