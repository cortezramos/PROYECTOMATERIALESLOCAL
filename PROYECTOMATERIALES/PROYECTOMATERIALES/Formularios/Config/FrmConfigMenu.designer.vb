<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigMenu
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
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblMenuID = New System.Windows.Forms.Label()
        Me.txtMenuID = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblPadre = New System.Windows.Forms.Label()
        Me.lblFormulario = New System.Windows.Forms.Label()
        Me.lblIndex = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cmbPadre = New System.Windows.Forms.ComboBox()
        Me.txtFormulario = New System.Windows.Forms.TextBox()
        Me.txtImagen = New System.Windows.Forms.TextBox()
        Me.dgvMenu = New System.Windows.Forms.DataGridView()
        Me.gbxImagenes = New System.Windows.Forms.GroupBox()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbl0 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxImagenes.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.ToolStripSeparator1, Me.btnNuevo, Me.ToolStripSeparator2, Me.btnGuardar, Me.ToolStripSeparator3, Me.btnEditar, Me.ToolStripSeparator4, Me.btnModificar, Me.ToolStripSeparator5, Me.btnEliminar, Me.ToolStripSeparator6, Me.btnCancelar, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(879, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'lblMenuID
        '
        Me.lblMenuID.AutoSize = True
        Me.lblMenuID.Location = New System.Drawing.Point(21, 35)
        Me.lblMenuID.Name = "lblMenuID"
        Me.lblMenuID.Size = New System.Drawing.Size(45, 13)
        Me.lblMenuID.TabIndex = 1
        Me.lblMenuID.Text = "MenuID"
        Me.lblMenuID.Visible = False
        '
        'txtMenuID
        '
        Me.txtMenuID.Location = New System.Drawing.Point(24, 51)
        Me.txtMenuID.Name = "txtMenuID"
        Me.txtMenuID.Size = New System.Drawing.Size(76, 20)
        Me.txtMenuID.TabIndex = 2
        Me.txtMenuID.Visible = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(110, 54)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(69, 13)
        Me.lblBuscar.TabIndex = 3
        Me.lblBuscar.Text = "Buscar menu"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(185, 51)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(416, 20)
        Me.txtBuscar.TabIndex = 4
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(21, 90)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(90, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre del menu"
        '
        'lblPadre
        '
        Me.lblPadre.AutoSize = True
        Me.lblPadre.Location = New System.Drawing.Point(213, 90)
        Me.lblPadre.Name = "lblPadre"
        Me.lblPadre.Size = New System.Drawing.Size(64, 13)
        Me.lblPadre.TabIndex = 6
        Me.lblPadre.Text = "Menu padre"
        '
        'lblFormulario
        '
        Me.lblFormulario.AutoSize = True
        Me.lblFormulario.Location = New System.Drawing.Point(395, 90)
        Me.lblFormulario.Name = "lblFormulario"
        Me.lblFormulario.Size = New System.Drawing.Size(105, 13)
        Me.lblFormulario.TabIndex = 7
        Me.lblFormulario.Text = "Formulario a ejecutar"
        '
        'lblIndex
        '
        Me.lblIndex.AutoSize = True
        Me.lblIndex.Location = New System.Drawing.Point(633, 90)
        Me.lblIndex.Name = "lblIndex"
        Me.lblIndex.Size = New System.Drawing.Size(86, 13)
        Me.lblIndex.TabIndex = 8
        Me.lblIndex.Text = "Imagen de menu"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(24, 106)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(185, 20)
        Me.txtNombre.TabIndex = 9
        '
        'cmbPadre
        '
        Me.cmbPadre.FormattingEnabled = True
        Me.cmbPadre.Location = New System.Drawing.Point(216, 106)
        Me.cmbPadre.Name = "cmbPadre"
        Me.cmbPadre.Size = New System.Drawing.Size(176, 21)
        Me.cmbPadre.TabIndex = 10
        '
        'txtFormulario
        '
        Me.txtFormulario.Location = New System.Drawing.Point(398, 106)
        Me.txtFormulario.Name = "txtFormulario"
        Me.txtFormulario.Size = New System.Drawing.Size(231, 20)
        Me.txtFormulario.TabIndex = 11
        '
        'txtImagen
        '
        Me.txtImagen.Location = New System.Drawing.Point(636, 107)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.Size = New System.Drawing.Size(83, 20)
        Me.txtImagen.TabIndex = 12
        '
        'dgvMenu
        '
        Me.dgvMenu.AllowUserToAddRows = False
        Me.dgvMenu.AllowUserToDeleteRows = False
        Me.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.Location = New System.Drawing.Point(24, 144)
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.Size = New System.Drawing.Size(695, 214)
        Me.dgvMenu.TabIndex = 13
        '
        'gbxImagenes
        '
        Me.gbxImagenes.Controls.Add(Me.lbl5)
        Me.gbxImagenes.Controls.Add(Me.PictureBox6)
        Me.gbxImagenes.Controls.Add(Me.lbl4)
        Me.gbxImagenes.Controls.Add(Me.PictureBox5)
        Me.gbxImagenes.Controls.Add(Me.lbl3)
        Me.gbxImagenes.Controls.Add(Me.PictureBox4)
        Me.gbxImagenes.Controls.Add(Me.lbl2)
        Me.gbxImagenes.Controls.Add(Me.PictureBox3)
        Me.gbxImagenes.Controls.Add(Me.lbl1)
        Me.gbxImagenes.Controls.Add(Me.PictureBox2)
        Me.gbxImagenes.Controls.Add(Me.lbl0)
        Me.gbxImagenes.Controls.Add(Me.PictureBox1)
        Me.gbxImagenes.Location = New System.Drawing.Point(736, 106)
        Me.gbxImagenes.Name = "gbxImagenes"
        Me.gbxImagenes.Size = New System.Drawing.Size(122, 242)
        Me.gbxImagenes.TabIndex = 14
        Me.gbxImagenes.TabStop = False
        Me.gbxImagenes.Text = "Imagenes"
        '
        'lbl5
        '
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(20, 202)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(13, 13)
        Me.lbl5.TabIndex = 11
        Me.lbl5.Text = "5"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.power_128
        Me.PictureBox6.Location = New System.Drawing.Point(38, 193)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 10
        Me.PictureBox6.TabStop = False
        '
        'lbl4
        '
        Me.lbl4.AutoSize = True
        Me.lbl4.Location = New System.Drawing.Point(19, 167)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(13, 13)
        Me.lbl4.TabIndex = 9
        Me.lbl4.Text = "4"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.settings_128
        Me.PictureBox5.Location = New System.Drawing.Point(37, 158)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 8
        Me.PictureBox5.TabStop = False
        '
        'lbl3
        '
        Me.lbl3.AutoSize = True
        Me.lbl3.Location = New System.Drawing.Point(20, 132)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(13, 13)
        Me.lbl3.TabIndex = 7
        Me.lbl3.Text = "3"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.computer_128
        Me.PictureBox4.Location = New System.Drawing.Point(38, 123)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(20, 97)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(13, 13)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "2"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.arrow_right_128
        Me.PictureBox3.Location = New System.Drawing.Point(38, 88)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(18, 63)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(13, 13)
        Me.lbl1.TabIndex = 3
        Me.lbl1.Text = "1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.list_128
        Me.PictureBox2.Location = New System.Drawing.Point(37, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'lbl0
        '
        Me.lbl0.AutoSize = True
        Me.lbl0.Location = New System.Drawing.Point(18, 28)
        Me.lbl0.Name = "lbl0"
        Me.lbl0.Size = New System.Drawing.Size(13, 13)
        Me.lbl0.TabIndex = 1
        Me.lbl0.Text = "0"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PROYECTOMATERIALES.My.Resources.Resources.button10_128
        Me.PictureBox1.Location = New System.Drawing.Point(37, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'FrmConfigMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 374)
        Me.Controls.Add(Me.gbxImagenes)
        Me.Controls.Add(Me.dgvMenu)
        Me.Controls.Add(Me.txtImagen)
        Me.Controls.Add(Me.txtFormulario)
        Me.Controls.Add(Me.cmbPadre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblIndex)
        Me.Controls.Add(Me.lblFormulario)
        Me.Controls.Add(Me.lblPadre)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtMenuID)
        Me.Controls.Add(Me.lblMenuID)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmConfigMenu"
        Me.Text = "MENUS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxImagenes.ResumeLayout(False)
        Me.gbxImagenes.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblMenuID As System.Windows.Forms.Label
    Friend WithEvents txtMenuID As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblPadre As System.Windows.Forms.Label
    Friend WithEvents lblFormulario As System.Windows.Forms.Label
    Friend WithEvents lblIndex As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents cmbPadre As System.Windows.Forms.ComboBox
    Friend WithEvents txtFormulario As System.Windows.Forms.TextBox
    Friend WithEvents txtImagen As System.Windows.Forms.TextBox
    Friend WithEvents dgvMenu As System.Windows.Forms.DataGridView
    Friend WithEvents gbxImagenes As System.Windows.Forms.GroupBox
    Friend WithEvents lbl0 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
End Class
