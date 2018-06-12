<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigFincas
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
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.txtFinca = New System.Windows.Forms.TextBox()
        Me.lblFinca = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.txtFincaID = New System.Windows.Forms.TextBox()
        Me.lblFincaID = New System.Windows.Forms.Label()
        Me.gbxBuscar = New System.Windows.Forms.GroupBox()
        Me.dgvFincas = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxBuscar.SuspendLayout()
        CType(Me.dgvFincas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnNuevo, Me.btnGuardar, Me.btnEditar, Me.btnModificar, Me.btnEliminar, Me.btnCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(468, 25)
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
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.blue_rounded_cross_sign_27138
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.btnNuevo.Text = "Nuevo"
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
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.save
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(23, 22)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminar.Image = Global.PROYECTOMATERIALES.My.Resources.Resources._1455063788_thumb_down
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
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
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.txtFinca)
        Me.gbxGeneral.Controls.Add(Me.lblFinca)
        Me.gbxGeneral.Controls.Add(Me.cmbEmpresa)
        Me.gbxGeneral.Controls.Add(Me.lblEmpresa)
        Me.gbxGeneral.Controls.Add(Me.txtFincaID)
        Me.gbxGeneral.Controls.Add(Me.lblFincaID)
        Me.gbxGeneral.Location = New System.Drawing.Point(12, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(442, 106)
        Me.gbxGeneral.TabIndex = 1
        Me.gbxGeneral.TabStop = False
        '
        'txtFinca
        '
        Me.txtFinca.Location = New System.Drawing.Point(220, 73)
        Me.txtFinca.Name = "txtFinca"
        Me.txtFinca.Size = New System.Drawing.Size(199, 20)
        Me.txtFinca.TabIndex = 9
        '
        'lblFinca
        '
        Me.lblFinca.AutoSize = True
        Me.lblFinca.Location = New System.Drawing.Point(217, 57)
        Me.lblFinca.Name = "lblFinca"
        Me.lblFinca.Size = New System.Drawing.Size(36, 13)
        Me.lblFinca.TabIndex = 8
        Me.lblFinca.Text = "Finca:"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 73)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(199, 21)
        Me.cmbEmpresa.TabIndex = 7
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(9, 57)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 6
        Me.lblEmpresa.Text = "Empresa:"
        '
        'txtFincaID
        '
        Me.txtFincaID.Location = New System.Drawing.Point(13, 32)
        Me.txtFincaID.Name = "txtFincaID"
        Me.txtFincaID.Size = New System.Drawing.Size(59, 20)
        Me.txtFincaID.TabIndex = 1
        '
        'lblFincaID
        '
        Me.lblFincaID.AutoSize = True
        Me.lblFincaID.Location = New System.Drawing.Point(10, 13)
        Me.lblFincaID.Name = "lblFincaID"
        Me.lblFincaID.Size = New System.Drawing.Size(47, 13)
        Me.lblFincaID.TabIndex = 0
        Me.lblFincaID.Text = "Planta #"
        '
        'gbxBuscar
        '
        Me.gbxBuscar.Controls.Add(Me.dgvFincas)
        Me.gbxBuscar.Location = New System.Drawing.Point(12, 140)
        Me.gbxBuscar.Name = "gbxBuscar"
        Me.gbxBuscar.Size = New System.Drawing.Size(442, 230)
        Me.gbxBuscar.TabIndex = 2
        Me.gbxBuscar.TabStop = False
        '
        'dgvFincas
        '
        Me.dgvFincas.AllowUserToAddRows = False
        Me.dgvFincas.AllowUserToDeleteRows = False
        Me.dgvFincas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFincas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFincas.Location = New System.Drawing.Point(19, 19)
        Me.dgvFincas.Name = "dgvFincas"
        Me.dgvFincas.ReadOnly = True
        Me.dgvFincas.Size = New System.Drawing.Size(400, 193)
        Me.dgvFincas.TabIndex = 2
        '
        'FrmConfigFincas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 382)
        Me.Controls.Add(Me.gbxBuscar)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmConfigFincas"
        Me.Text = "FINCAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxBuscar.ResumeLayout(False)
        CType(Me.dgvFincas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents gbxBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtFincaID As System.Windows.Forms.TextBox
    Friend WithEvents lblFincaID As System.Windows.Forms.Label
    Friend WithEvents txtFinca As System.Windows.Forms.TextBox
    Friend WithEvents lblFinca As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents dgvFincas As System.Windows.Forms.DataGridView
End Class
