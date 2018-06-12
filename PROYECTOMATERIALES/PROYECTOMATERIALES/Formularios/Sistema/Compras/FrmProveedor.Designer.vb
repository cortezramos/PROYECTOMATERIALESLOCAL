<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProveedor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnInactivar = New System.Windows.Forms.ToolStripButton()
        Me.btnActivar = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.lblContacto = New System.Windows.Forms.Label()
        Me.txtLimite = New System.Windows.Forms.TextBox()
        Me.lblLimite = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtTelefono2 = New System.Windows.Forms.TextBox()
        Me.lblTelefono2 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.lblTributario = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cmbImpuesto = New System.Windows.Forms.ComboBox()
        Me.dgvImpuesto = New System.Windows.Forms.DataGridView()
        Me.colImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnNuevo, Me.btnGuardar, Me.btnModificar, Me.btnInactivar, Me.btnActivar, Me.btnBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(551, 25)
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
        'btnInactivar
        '
        Me.btnInactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInactivar.Image = CType(resources.GetObject("btnInactivar.Image"), System.Drawing.Image)
        Me.btnInactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Size = New System.Drawing.Size(23, 22)
        Me.btnInactivar.Text = "Inactivar"
        Me.btnInactivar.Visible = False
        '
        'btnActivar
        '
        Me.btnActivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActivar.Image = CType(resources.GetObject("btnActivar.Image"), System.Drawing.Image)
        Me.btnActivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Size = New System.Drawing.Size(23, 22)
        Me.btnActivar.Text = "Activar"
        Me.btnActivar.Visible = False
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
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.cmbTipo)
        Me.gbxGeneral.Controls.Add(Me.txtEstado)
        Me.gbxGeneral.Controls.Add(Me.lblEstado)
        Me.gbxGeneral.Controls.Add(Me.txtDias)
        Me.gbxGeneral.Controls.Add(Me.lblDias)
        Me.gbxGeneral.Controls.Add(Me.txtContacto)
        Me.gbxGeneral.Controls.Add(Me.lblContacto)
        Me.gbxGeneral.Controls.Add(Me.txtLimite)
        Me.gbxGeneral.Controls.Add(Me.lblLimite)
        Me.gbxGeneral.Controls.Add(Me.txtEmail)
        Me.gbxGeneral.Controls.Add(Me.lblEmail)
        Me.gbxGeneral.Controls.Add(Me.txtTelefono2)
        Me.gbxGeneral.Controls.Add(Me.lblTelefono2)
        Me.gbxGeneral.Controls.Add(Me.txtTelefono)
        Me.gbxGeneral.Controls.Add(Me.lblTelefono)
        Me.gbxGeneral.Controls.Add(Me.txtDireccion)
        Me.gbxGeneral.Controls.Add(Me.lblDireccion)
        Me.gbxGeneral.Controls.Add(Me.txtNombre)
        Me.gbxGeneral.Controls.Add(Me.lblNombre)
        Me.gbxGeneral.Controls.Add(Me.lblTipo)
        Me.gbxGeneral.Controls.Add(Me.txtNit)
        Me.gbxGeneral.Controls.Add(Me.lblTributario)
        Me.gbxGeneral.Controls.Add(Me.txtCodigo)
        Me.gbxGeneral.Controls.Add(Me.lblCodigo)
        Me.gbxGeneral.Location = New System.Drawing.Point(6, 31)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(537, 277)
        Me.gbxGeneral.TabIndex = 1
        Me.gbxGeneral.TabStop = False
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(122, 90)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(399, 21)
        Me.cmbTipo.TabIndex = 7
        '
        'txtEstado
        '
        Me.txtEstado.Enabled = False
        Me.txtEstado.Location = New System.Drawing.Point(379, 19)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(142, 20)
        Me.txtEstado.TabIndex = 3
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(289, 22)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado"
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(379, 243)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(144, 20)
        Me.txtDias.TabIndex = 23
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Location = New System.Drawing.Point(289, 246)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(76, 13)
        Me.lblDias.TabIndex = 22
        Me.lblDias.Text = "Dias Credito"
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(123, 243)
        Me.txtContacto.MaxLength = 50
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(144, 20)
        Me.txtContacto.TabIndex = 21
        '
        'lblContacto
        '
        Me.lblContacto.AutoSize = True
        Me.lblContacto.Location = New System.Drawing.Point(12, 246)
        Me.lblContacto.Name = "lblContacto"
        Me.lblContacto.Size = New System.Drawing.Size(58, 13)
        Me.lblContacto.TabIndex = 20
        Me.lblContacto.Text = "Contacto"
        '
        'txtLimite
        '
        Me.txtLimite.Location = New System.Drawing.Point(378, 212)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(144, 20)
        Me.txtLimite.TabIndex = 19
        '
        'lblLimite
        '
        Me.lblLimite.AutoSize = True
        Me.lblLimite.Location = New System.Drawing.Point(288, 215)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(84, 13)
        Me.lblLimite.TabIndex = 18
        Me.lblLimite.Text = "Limite Credito"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(122, 212)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(144, 20)
        Me.txtEmail.TabIndex = 17
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(11, 215)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(41, 13)
        Me.lblEmail.TabIndex = 16
        Me.lblEmail.Text = "E-mail"
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Location = New System.Drawing.Point(378, 182)
        Me.txtTelefono2.MaxLength = 11
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Size = New System.Drawing.Size(143, 20)
        Me.txtTelefono2.TabIndex = 15
        '
        'lblTelefono2
        '
        Me.lblTelefono2.AutoSize = True
        Me.lblTelefono2.Location = New System.Drawing.Point(288, 185)
        Me.lblTelefono2.Name = "lblTelefono2"
        Me.lblTelefono2.Size = New System.Drawing.Size(68, 13)
        Me.lblTelefono2.TabIndex = 14
        Me.lblTelefono2.Text = "Telefono 2"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(122, 182)
        Me.txtTelefono.MaxLength = 11
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(144, 20)
        Me.txtTelefono.TabIndex = 13
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(11, 185)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(57, 13)
        Me.lblTelefono.TabIndex = 12
        Me.lblTelefono.Text = "Telefono"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(122, 151)
        Me.txtDireccion.MaxLength = 200
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(399, 20)
        Me.txtDireccion.TabIndex = 11
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Location = New System.Drawing.Point(11, 154)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(61, 13)
        Me.lblDireccion.TabIndex = 10
        Me.lblDireccion.Text = "Direccion"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(122, 120)
        Me.txtNombre.MaxLength = 65
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(399, 20)
        Me.txtNombre.TabIndex = 9
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(12, 123)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.Text = "Nombre"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(12, 93)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblTipo.TabIndex = 6
        Me.lblTipo.Text = "Tipo"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(122, 62)
        Me.txtNit.MaxLength = 15
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(172, 20)
        Me.txtNit.TabIndex = 5
        '
        'lblTributario
        '
        Me.lblTributario.AutoSize = True
        Me.lblTributario.Location = New System.Drawing.Point(12, 65)
        Me.lblTributario.Name = "lblTributario"
        Me.lblTributario.Size = New System.Drawing.Size(104, 13)
        Me.lblTributario.TabIndex = 4
        Me.lblTributario.Text = "Codigo Tributario"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(122, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(11, 22)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(46, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.btnCancelar)
        Me.gbxDetalle.Controls.Add(Me.btnEliminar)
        Me.gbxDetalle.Controls.Add(Me.btnAgregar)
        Me.gbxDetalle.Controls.Add(Me.cmbImpuesto)
        Me.gbxDetalle.Controls.Add(Me.dgvImpuesto)
        Me.gbxDetalle.Location = New System.Drawing.Point(6, 314)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(537, 217)
        Me.gbxDetalle.TabIndex = 2
        Me.gbxDetalle.TabStop = False
        Me.gbxDetalle.Text = "Impuesto"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = CType(resources.GetObject("btnCancelar.BackgroundImage"), System.Drawing.Image)
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancelar.Location = New System.Drawing.Point(461, 17)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(31, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(380, 17)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(381, 17)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cmbImpuesto
        '
        Me.cmbImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpuesto.FormattingEnabled = True
        Me.cmbImpuesto.Location = New System.Drawing.Point(27, 19)
        Me.cmbImpuesto.Name = "cmbImpuesto"
        Me.cmbImpuesto.Size = New System.Drawing.Size(349, 21)
        Me.cmbImpuesto.TabIndex = 0
        '
        'dgvImpuesto
        '
        Me.dgvImpuesto.AllowUserToAddRows = False
        Me.dgvImpuesto.AllowUserToDeleteRows = False
        Me.dgvImpuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvImpuesto.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvImpuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImpuesto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colImpuesto, Me.colDescripcion})
        Me.dgvImpuesto.Location = New System.Drawing.Point(6, 46)
        Me.dgvImpuesto.Name = "dgvImpuesto"
        Me.dgvImpuesto.ReadOnly = True
        Me.dgvImpuesto.Size = New System.Drawing.Size(525, 165)
        Me.dgvImpuesto.TabIndex = 3
        '
        'colImpuesto
        '
        Me.colImpuesto.HeaderText = "Impuesto"
        Me.colImpuesto.Name = "colImpuesto"
        Me.colImpuesto.ReadOnly = True
        Me.colImpuesto.Visible = False
        '
        'colDescripcion
        '
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'FrmProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(551, 537)
        Me.Controls.Add(Me.gbxDetalle)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmProveedor"
        Me.Text = "Proveedor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents lblTributario As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono2 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtLimite As System.Windows.Forms.TextBox
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents lblContacto As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnInactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvImpuesto As System.Windows.Forms.DataGridView
    Friend WithEvents cmbImpuesto As System.Windows.Forms.ComboBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents colImpuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
