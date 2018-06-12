<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigUsuario
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
        Me.gbxUsuario = New System.Windows.Forms.GroupBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.chkAdmin = New System.Windows.Forms.CheckBox()
        Me.cmbFinca = New System.Windows.Forms.ComboBox()
        Me.lblFinca = New System.Windows.Forms.Label()
        Me.cmbEmpresas = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtUsuarioID = New System.Windows.Forms.TextBox()
        Me.lblUsuarioID = New System.Windows.Forms.Label()
        Me.txtConfirmar = New System.Windows.Forms.TextBox()
        Me.lblConfirmarContra = New System.Windows.Forms.Label()
        Me.txtContra = New System.Windows.Forms.TextBox()
        Me.lblContra = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.gbxConsultaUsuarios = New System.Windows.Forms.GroupBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.toolMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.gbxUsuario.SuspendLayout()
        Me.gbxConsultaUsuarios.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxUsuario
        '
        Me.gbxUsuario.Controls.Add(Me.cmbSucursal)
        Me.gbxUsuario.Controls.Add(Me.lblSucursal)
        Me.gbxUsuario.Controls.Add(Me.chkAdmin)
        Me.gbxUsuario.Controls.Add(Me.cmbFinca)
        Me.gbxUsuario.Controls.Add(Me.lblFinca)
        Me.gbxUsuario.Controls.Add(Me.cmbEmpresas)
        Me.gbxUsuario.Controls.Add(Me.lblEmpresa)
        Me.gbxUsuario.Controls.Add(Me.txtUsuarioID)
        Me.gbxUsuario.Controls.Add(Me.lblUsuarioID)
        Me.gbxUsuario.Controls.Add(Me.txtConfirmar)
        Me.gbxUsuario.Controls.Add(Me.lblConfirmarContra)
        Me.gbxUsuario.Controls.Add(Me.txtContra)
        Me.gbxUsuario.Controls.Add(Me.lblContra)
        Me.gbxUsuario.Controls.Add(Me.txtUsuario)
        Me.gbxUsuario.Controls.Add(Me.lblUsuario)
        Me.gbxUsuario.Location = New System.Drawing.Point(21, 77)
        Me.gbxUsuario.Name = "gbxUsuario"
        Me.gbxUsuario.Size = New System.Drawing.Size(288, 361)
        Me.gbxUsuario.TabIndex = 1
        Me.gbxUsuario.TabStop = False
        Me.gbxUsuario.Text = "Usuario"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Items.AddRange(New Object() {"--Seleccione Sucursal", "Oficinas Centrales", "Finca"})
        Me.cmbSucursal.Location = New System.Drawing.Point(23, 322)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(213, 21)
        Me.cmbSucursal.TabIndex = 14
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Location = New System.Drawing.Point(24, 306)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 13
        Me.lblSucursal.Text = "Sucursal"
        '
        'chkAdmin
        '
        Me.chkAdmin.AutoSize = True
        Me.chkAdmin.Location = New System.Drawing.Point(165, 24)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(89, 17)
        Me.chkAdmin.TabIndex = 2
        Me.chkAdmin.Text = "Administrador"
        Me.chkAdmin.UseVisualStyleBackColor = True
        '
        'cmbFinca
        '
        Me.cmbFinca.FormattingEnabled = True
        Me.cmbFinca.Location = New System.Drawing.Point(23, 168)
        Me.cmbFinca.Name = "cmbFinca"
        Me.cmbFinca.Size = New System.Drawing.Size(213, 21)
        Me.cmbFinca.TabIndex = 8
        '
        'lblFinca
        '
        Me.lblFinca.AutoSize = True
        Me.lblFinca.Location = New System.Drawing.Point(24, 152)
        Me.lblFinca.Name = "lblFinca"
        Me.lblFinca.Size = New System.Drawing.Size(33, 13)
        Me.lblFinca.TabIndex = 7
        Me.lblFinca.Text = "Finca"
        '
        'cmbEmpresas
        '
        Me.cmbEmpresas.FormattingEnabled = True
        Me.cmbEmpresas.Location = New System.Drawing.Point(23, 119)
        Me.cmbEmpresas.Name = "cmbEmpresas"
        Me.cmbEmpresas.Size = New System.Drawing.Size(213, 21)
        Me.cmbEmpresas.TabIndex = 6
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(24, 103)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 5
        Me.lblEmpresa.Text = "Empresa"
        '
        'txtUsuarioID
        '
        Me.txtUsuarioID.Location = New System.Drawing.Point(84, 22)
        Me.txtUsuarioID.Name = "txtUsuarioID"
        Me.txtUsuarioID.Size = New System.Drawing.Size(46, 20)
        Me.txtUsuarioID.TabIndex = 1
        Me.txtUsuarioID.Visible = False
        '
        'lblUsuarioID
        '
        Me.lblUsuarioID.AutoSize = True
        Me.lblUsuarioID.Location = New System.Drawing.Point(24, 25)
        Me.lblUsuarioID.Name = "lblUsuarioID"
        Me.lblUsuarioID.Size = New System.Drawing.Size(54, 13)
        Me.lblUsuarioID.TabIndex = 0
        Me.lblUsuarioID.Text = "UsuarioID"
        Me.lblUsuarioID.Visible = False
        '
        'txtConfirmar
        '
        Me.txtConfirmar.Location = New System.Drawing.Point(27, 277)
        Me.txtConfirmar.Name = "txtConfirmar"
        Me.txtConfirmar.Size = New System.Drawing.Size(209, 20)
        Me.txtConfirmar.TabIndex = 12
        Me.txtConfirmar.UseSystemPasswordChar = True
        '
        'lblConfirmarContra
        '
        Me.lblConfirmarContra.AutoSize = True
        Me.lblConfirmarContra.Location = New System.Drawing.Point(24, 259)
        Me.lblConfirmarContra.Name = "lblConfirmarContra"
        Me.lblConfirmarContra.Size = New System.Drawing.Size(110, 13)
        Me.lblConfirmarContra.TabIndex = 11
        Me.lblConfirmarContra.Text = "Confirmar contraseña:"
        '
        'txtContra
        '
        Me.txtContra.Location = New System.Drawing.Point(27, 219)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(209, 20)
        Me.txtContra.TabIndex = 10
        Me.txtContra.UseSystemPasswordChar = True
        '
        'lblContra
        '
        Me.lblContra.AutoSize = True
        Me.lblContra.Location = New System.Drawing.Point(24, 202)
        Me.lblContra.Name = "lblContra"
        Me.lblContra.Size = New System.Drawing.Size(64, 13)
        Me.lblContra.TabIndex = 9
        Me.lblContra.Text = "Contraseña:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(23, 63)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(213, 20)
        Me.txtUsuario.TabIndex = 4
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(20, 47)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 3
        Me.lblUsuario.Text = "Usuario"
        '
        'gbxConsultaUsuarios
        '
        Me.gbxConsultaUsuarios.Controls.Add(Me.dgvUsuarios)
        Me.gbxConsultaUsuarios.Location = New System.Drawing.Point(326, 77)
        Me.gbxConsultaUsuarios.Name = "gbxConsultaUsuarios"
        Me.gbxConsultaUsuarios.Size = New System.Drawing.Size(329, 361)
        Me.gbxConsultaUsuarios.TabIndex = 4
        Me.gbxConsultaUsuarios.TabStop = False
        Me.gbxConsultaUsuarios.Text = "Consulta usuarios"
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Location = New System.Drawing.Point(18, 31)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.Size = New System.Drawing.Size(289, 312)
        Me.dgvUsuarios.TabIndex = 0
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(347, 51)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(85, 13)
        Me.lblBuscar.TabIndex = 2
        Me.lblBuscar.Text = "Buscar usuarios:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(454, 48)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(175, 20)
        Me.txtBuscar.TabIndex = 3
        '
        'toolMenu
        '
        Me.toolMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.ToolStripSeparator1, Me.btnNuevo, Me.ToolStripSeparator2, Me.btnGuardar, Me.ToolStripSeparator4, Me.btnEditar, Me.ToolStripSeparator3, Me.btnModificar, Me.ToolStripSeparator5, Me.btnEliminar, Me.ToolStripSeparator6, Me.btnCancelar})
        Me.toolMenu.Location = New System.Drawing.Point(0, 0)
        Me.toolMenu.Name = "toolMenu"
        Me.toolMenu.Size = New System.Drawing.Size(682, 25)
        Me.toolMenu.TabIndex = 0
        Me.toolMenu.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.PROYECTOMATERIALES.My.Resources.Resources._exit
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(23, 22)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.blue_rounded_cross_sign_27138
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.btnNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.save
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.edit_256
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(23, 22)
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.edit
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(23, 22)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnEliminar
        '
        Me.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.remove_256
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources._1441853939_undo
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(23, 22)
        Me.btnCancelar.Text = "Cancelar"
        '
        'FrmConfigUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.toolMenu)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.gbxConsultaUsuarios)
        Me.Controls.Add(Me.gbxUsuario)
        Me.Name = "FrmConfigUsuario"
        Me.Text = "USUARIOS"
        Me.gbxUsuario.ResumeLayout(False)
        Me.gbxUsuario.PerformLayout()
        Me.gbxConsultaUsuarios.ResumeLayout(False)
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolMenu.ResumeLayout(False)
        Me.toolMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents txtContra As System.Windows.Forms.TextBox
    Friend WithEvents lblContra As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmarContra As System.Windows.Forms.Label
    Friend WithEvents gbxConsultaUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents toolMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUsuarioID As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioID As System.Windows.Forms.TextBox
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbFinca As System.Windows.Forms.ComboBox
    Friend WithEvents lblFinca As System.Windows.Forms.Label
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
End Class
