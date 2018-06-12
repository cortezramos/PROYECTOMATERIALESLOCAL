<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigRoles
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.lblCrear = New System.Windows.Forms.Label()
        Me.chkCrear = New System.Windows.Forms.CheckBox()
        Me.chkModificar = New System.Windows.Forms.CheckBox()
        Me.chkEliminar = New System.Windows.Forms.CheckBox()
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbPadre = New System.Windows.Forms.ComboBox()
        Me.lblPadre = New System.Windows.Forms.Label()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.gbxPrincipal = New System.Windows.Forms.GroupBox()
        Me.btnCambiar = New System.Windows.Forms.Button()
        Me.cmbMenus = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminarMenu = New System.Windows.Forms.Button()
        Me.dgvRoles = New System.Windows.Forms.DataGridView()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.txtRolID = New System.Windows.Forms.TextBox()
        Me.gbxMenus = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxPrincipal.SuspendLayout()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxMenus.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.ToolStripSeparator1, Me.btnNuevo, Me.ToolStripSeparator2, Me.btnCancelar, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(650, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.PROYECTOMATERIALES.My.Resources.Resources._exit
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(23, 22)
        Me.btnSalir.Text = "Salir"
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
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources._1441853939_undo
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(23, 22)
        Me.btnCancelar.Text = "Cancelar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(17, 20)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario:"
        '
        'cmbUsuario
        '
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(20, 36)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(209, 21)
        Me.cmbUsuario.TabIndex = 1
        '
        'lblCrear
        '
        Me.lblCrear.AutoSize = True
        Me.lblCrear.Location = New System.Drawing.Point(262, 20)
        Me.lblCrear.Name = "lblCrear"
        Me.lblCrear.Size = New System.Drawing.Size(52, 13)
        Me.lblCrear.TabIndex = 2
        Me.lblCrear.Text = "Permisos:"
        '
        'chkCrear
        '
        Me.chkCrear.AutoSize = True
        Me.chkCrear.Location = New System.Drawing.Point(265, 38)
        Me.chkCrear.Name = "chkCrear"
        Me.chkCrear.Size = New System.Drawing.Size(51, 17)
        Me.chkCrear.TabIndex = 3
        Me.chkCrear.Text = "Crear"
        Me.chkCrear.UseVisualStyleBackColor = True
        '
        'chkModificar
        '
        Me.chkModificar.AutoSize = True
        Me.chkModificar.Location = New System.Drawing.Point(322, 38)
        Me.chkModificar.Name = "chkModificar"
        Me.chkModificar.Size = New System.Drawing.Size(69, 17)
        Me.chkModificar.TabIndex = 4
        Me.chkModificar.Text = "Modificar"
        Me.chkModificar.UseVisualStyleBackColor = True
        '
        'chkEliminar
        '
        Me.chkEliminar.AutoSize = True
        Me.chkEliminar.Location = New System.Drawing.Point(397, 38)
        Me.chkEliminar.Name = "chkEliminar"
        Me.chkEliminar.Size = New System.Drawing.Size(62, 17)
        Me.chkEliminar.TabIndex = 5
        Me.chkEliminar.Text = "Eliminar"
        Me.chkEliminar.UseVisualStyleBackColor = True
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(465, 34)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(111, 23)
        Me.btnCrear.TabIndex = 6
        Me.btnCrear.Text = "CREAR PERFIL"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.btnCrear)
        Me.gbxGeneral.Controls.Add(Me.chkEliminar)
        Me.gbxGeneral.Controls.Add(Me.chkModificar)
        Me.gbxGeneral.Controls.Add(Me.chkCrear)
        Me.gbxGeneral.Controls.Add(Me.lblCrear)
        Me.gbxGeneral.Controls.Add(Me.cmbUsuario)
        Me.gbxGeneral.Controls.Add(Me.lblUsuario)
        Me.gbxGeneral.Location = New System.Drawing.Point(23, 30)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(598, 76)
        Me.gbxGeneral.TabIndex = 1
        Me.gbxGeneral.TabStop = False
        Me.gbxGeneral.Text = "Perfil general (PASO 1)"
        '
        'cmbPadre
        '
        Me.cmbPadre.FormattingEnabled = True
        Me.cmbPadre.Location = New System.Drawing.Point(24, 39)
        Me.cmbPadre.Name = "cmbPadre"
        Me.cmbPadre.Size = New System.Drawing.Size(294, 21)
        Me.cmbPadre.TabIndex = 2
        '
        'lblPadre
        '
        Me.lblPadre.AutoSize = True
        Me.lblPadre.Location = New System.Drawing.Point(21, 19)
        Me.lblPadre.Name = "lblPadre"
        Me.lblPadre.Size = New System.Drawing.Size(67, 13)
        Me.lblPadre.TabIndex = 3
        Me.lblPadre.Text = "Menu padre:"
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(325, 37)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(134, 23)
        Me.btnSeleccionar.TabIndex = 4
        Me.btnSeleccionar.Text = "Seleccionar Menu Padre"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'gbxPrincipal
        '
        Me.gbxPrincipal.Controls.Add(Me.btnCambiar)
        Me.gbxPrincipal.Controls.Add(Me.btnSeleccionar)
        Me.gbxPrincipal.Controls.Add(Me.lblPadre)
        Me.gbxPrincipal.Controls.Add(Me.cmbPadre)
        Me.gbxPrincipal.Location = New System.Drawing.Point(23, 112)
        Me.gbxPrincipal.Name = "gbxPrincipal"
        Me.gbxPrincipal.Size = New System.Drawing.Size(598, 76)
        Me.gbxPrincipal.TabIndex = 3
        Me.gbxPrincipal.TabStop = False
        Me.gbxPrincipal.Text = "Menu principal (PASO 2)"
        '
        'btnCambiar
        '
        Me.btnCambiar.Location = New System.Drawing.Point(463, 37)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(127, 23)
        Me.btnCambiar.TabIndex = 5
        Me.btnCambiar.Text = "Cambiar padre"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'cmbMenus
        '
        Me.cmbMenus.FormattingEnabled = True
        Me.cmbMenus.Location = New System.Drawing.Point(24, 40)
        Me.cmbMenus.Name = "cmbMenus"
        Me.cmbMenus.Size = New System.Drawing.Size(290, 21)
        Me.cmbMenus.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(325, 38)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminarMenu
        '
        Me.btnEliminarMenu.Location = New System.Drawing.Point(406, 38)
        Me.btnEliminarMenu.Name = "btnEliminarMenu"
        Me.btnEliminarMenu.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminarMenu.TabIndex = 2
        Me.btnEliminarMenu.Text = "Eliminar"
        Me.btnEliminarMenu.UseVisualStyleBackColor = True
        '
        'dgvRoles
        '
        Me.dgvRoles.AllowUserToAddRows = False
        Me.dgvRoles.AllowUserToDeleteRows = False
        Me.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRoles.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoles.Location = New System.Drawing.Point(24, 67)
        Me.dgvRoles.Name = "dgvRoles"
        Me.dgvRoles.ReadOnly = True
        Me.dgvRoles.Size = New System.Drawing.Size(457, 240)
        Me.dgvRoles.TabIndex = 3
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Location = New System.Drawing.Point(21, 22)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(37, 13)
        Me.lblMenu.TabIndex = 4
        Me.lblMenu.Text = "Menu:"
        '
        'txtRolID
        '
        Me.txtRolID.Location = New System.Drawing.Point(126, 14)
        Me.txtRolID.Name = "txtRolID"
        Me.txtRolID.Size = New System.Drawing.Size(42, 20)
        Me.txtRolID.TabIndex = 5
        Me.txtRolID.Visible = False
        '
        'gbxMenus
        '
        Me.gbxMenus.Controls.Add(Me.txtRolID)
        Me.gbxMenus.Controls.Add(Me.lblMenu)
        Me.gbxMenus.Controls.Add(Me.dgvRoles)
        Me.gbxMenus.Controls.Add(Me.btnEliminarMenu)
        Me.gbxMenus.Controls.Add(Me.btnAgregar)
        Me.gbxMenus.Controls.Add(Me.cmbMenus)
        Me.gbxMenus.Location = New System.Drawing.Point(23, 194)
        Me.gbxMenus.Name = "gbxMenus"
        Me.gbxMenus.Size = New System.Drawing.Size(598, 313)
        Me.gbxMenus.TabIndex = 4
        Me.gbxMenus.TabStop = False
        Me.gbxMenus.Text = "Menus (PASO 3)"
        '
        'FrmConfigRoles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 519)
        Me.Controls.Add(Me.gbxMenus)
        Me.Controls.Add(Me.gbxPrincipal)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmConfigRoles"
        Me.Text = "ROLES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxPrincipal.ResumeLayout(False)
        Me.gbxPrincipal.PerformLayout()
        CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxMenus.ResumeLayout(False)
        Me.gbxMenus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents lblCrear As System.Windows.Forms.Label
    Friend WithEvents chkCrear As System.Windows.Forms.CheckBox
    Friend WithEvents chkModificar As System.Windows.Forms.CheckBox
    Friend WithEvents chkEliminar As System.Windows.Forms.CheckBox
    Friend WithEvents btnCrear As System.Windows.Forms.Button
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPadre As System.Windows.Forms.ComboBox
    Friend WithEvents lblPadre As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents gbxPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMenus As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminarMenu As System.Windows.Forms.Button
    Friend WithEvents dgvRoles As System.Windows.Forms.DataGridView
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents txtRolID As System.Windows.Forms.TextBox
    Friend WithEvents gbxMenus As System.Windows.Forms.GroupBox
    Friend WithEvents btnCambiar As System.Windows.Forms.Button
End Class
