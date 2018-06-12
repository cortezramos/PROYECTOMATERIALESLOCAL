<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigEmpresas
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
        Me.txtEmpresaID = New System.Windows.Forms.TextBox()
        Me.lblEmpresaID = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.gbxBuscar = New System.Windows.Forms.GroupBox()
        Me.dgvEmpresa = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxBuscar.SuspendLayout()
        CType(Me.dgvEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbxGeneral.Controls.Add(Me.txtEmpresaID)
        Me.gbxGeneral.Controls.Add(Me.lblEmpresaID)
        Me.gbxGeneral.Controls.Add(Me.txtEmpresa)
        Me.gbxGeneral.Controls.Add(Me.lblEmpresa)
        Me.gbxGeneral.Location = New System.Drawing.Point(12, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(350, 67)
        Me.gbxGeneral.TabIndex = 1
        Me.gbxGeneral.TabStop = False
        '
        'txtEmpresaID
        '
        Me.txtEmpresaID.Location = New System.Drawing.Point(9, 31)
        Me.txtEmpresaID.Name = "txtEmpresaID"
        Me.txtEmpresaID.Size = New System.Drawing.Size(56, 20)
        Me.txtEmpresaID.TabIndex = 11
        Me.txtEmpresaID.Visible = False
        '
        'lblEmpresaID
        '
        Me.lblEmpresaID.AutoSize = True
        Me.lblEmpresaID.Location = New System.Drawing.Point(6, 15)
        Me.lblEmpresaID.Name = "lblEmpresaID"
        Me.lblEmpresaID.Size = New System.Drawing.Size(59, 13)
        Me.lblEmpresaID.TabIndex = 10
        Me.lblEmpresaID.Text = "EmpresaID"
        Me.lblEmpresaID.Visible = False
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(74, 31)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(199, 20)
        Me.txtEmpresa.TabIndex = 9
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(71, 15)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblEmpresa.TabIndex = 8
        Me.lblEmpresa.Text = "Empresa:"
        '
        'gbxBuscar
        '
        Me.gbxBuscar.Controls.Add(Me.dgvEmpresa)
        Me.gbxBuscar.Location = New System.Drawing.Point(12, 97)
        Me.gbxBuscar.Name = "gbxBuscar"
        Me.gbxBuscar.Size = New System.Drawing.Size(350, 233)
        Me.gbxBuscar.TabIndex = 2
        Me.gbxBuscar.TabStop = False
        '
        'dgvEmpresa
        '
        Me.dgvEmpresa.AllowUserToAddRows = False
        Me.dgvEmpresa.AllowUserToDeleteRows = False
        Me.dgvEmpresa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpresa.Location = New System.Drawing.Point(15, 23)
        Me.dgvEmpresa.Name = "dgvEmpresa"
        Me.dgvEmpresa.ReadOnly = True
        Me.dgvEmpresa.Size = New System.Drawing.Size(316, 193)
        Me.dgvEmpresa.TabIndex = 2
        '
        'FrmConfigEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 340)
        Me.Controls.Add(Me.gbxBuscar)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmConfigEmpresas"
        Me.Text = "EMPRESAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxBuscar.ResumeLayout(False)
        CType(Me.dgvEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents dgvEmpresa As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmpresaID As System.Windows.Forms.Label
    Friend WithEvents txtEmpresaID As System.Windows.Forms.TextBox
End Class
