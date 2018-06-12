<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobarSolicitudes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAprobarSolicitudes))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnDerecha = New System.Windows.Forms.Button()
        Me.btnDerechaTodo = New System.Windows.Forms.Button()
        Me.btnIzquierda = New System.Windows.Forms.Button()
        Me.btnIzquierdaTodo = New System.Windows.Forms.Button()
        Me.dgvSolicitudes = New System.Windows.Forms.DataGridView()
        Me.colNumeroS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolicitanteS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservacionesS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAprobadas = New System.Windows.Forms.DataGridView()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblSolicitudes = New System.Windows.Forms.Label()
        Me.lblAprobadas = New System.Windows.Forms.Label()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
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
        Me.menuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnularItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAprobadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxGeneral.SuspendLayout()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnGuardar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1042, 25)
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
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnDerecha
        '
        Me.btnDerecha.Location = New System.Drawing.Point(482, 76)
        Me.btnDerecha.Name = "btnDerecha"
        Me.btnDerecha.Size = New System.Drawing.Size(44, 31)
        Me.btnDerecha.TabIndex = 3
        Me.btnDerecha.Text = ">"
        Me.btnDerecha.UseVisualStyleBackColor = True
        '
        'btnDerechaTodo
        '
        Me.btnDerechaTodo.Location = New System.Drawing.Point(482, 39)
        Me.btnDerechaTodo.Name = "btnDerechaTodo"
        Me.btnDerechaTodo.Size = New System.Drawing.Size(44, 31)
        Me.btnDerechaTodo.TabIndex = 4
        Me.btnDerechaTodo.Text = ">>"
        Me.btnDerechaTodo.UseVisualStyleBackColor = True
        '
        'btnIzquierda
        '
        Me.btnIzquierda.Location = New System.Drawing.Point(482, 113)
        Me.btnIzquierda.Name = "btnIzquierda"
        Me.btnIzquierda.Size = New System.Drawing.Size(44, 31)
        Me.btnIzquierda.TabIndex = 5
        Me.btnIzquierda.Text = "<"
        Me.btnIzquierda.UseVisualStyleBackColor = True
        '
        'btnIzquierdaTodo
        '
        Me.btnIzquierdaTodo.Location = New System.Drawing.Point(482, 150)
        Me.btnIzquierdaTodo.Name = "btnIzquierdaTodo"
        Me.btnIzquierdaTodo.Size = New System.Drawing.Size(44, 31)
        Me.btnIzquierdaTodo.TabIndex = 6
        Me.btnIzquierdaTodo.Text = "<<"
        Me.btnIzquierdaTodo.UseVisualStyleBackColor = True
        '
        'dgvSolicitudes
        '
        Me.dgvSolicitudes.AllowUserToAddRows = False
        Me.dgvSolicitudes.AllowUserToDeleteRows = False
        Me.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSolicitudes.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSolicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumeroS, Me.colSolicitanteS, Me.colObservacionesS})
        Me.dgvSolicitudes.Location = New System.Drawing.Point(19, 19)
        Me.dgvSolicitudes.Name = "dgvSolicitudes"
        Me.dgvSolicitudes.ReadOnly = True
        Me.dgvSolicitudes.Size = New System.Drawing.Size(457, 174)
        Me.dgvSolicitudes.TabIndex = 7
        '
        'colNumeroS
        '
        Me.colNumeroS.HeaderText = "Numero"
        Me.colNumeroS.Name = "colNumeroS"
        Me.colNumeroS.ReadOnly = True
        '
        'colSolicitanteS
        '
        Me.colSolicitanteS.HeaderText = "Solicitante"
        Me.colSolicitanteS.Name = "colSolicitanteS"
        Me.colSolicitanteS.ReadOnly = True
        '
        'colObservacionesS
        '
        Me.colObservacionesS.HeaderText = "Observaciones"
        Me.colObservacionesS.Name = "colObservacionesS"
        Me.colObservacionesS.ReadOnly = True
        '
        'dgvAprobadas
        '
        Me.dgvAprobadas.AllowUserToAddRows = False
        Me.dgvAprobadas.AllowUserToDeleteRows = False
        Me.dgvAprobadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAprobadas.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvAprobadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAprobadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumero, Me.colSolicitante, Me.colObservaciones})
        Me.dgvAprobadas.Location = New System.Drawing.Point(532, 19)
        Me.dgvAprobadas.Name = "dgvAprobadas"
        Me.dgvAprobadas.ReadOnly = True
        Me.dgvAprobadas.Size = New System.Drawing.Size(457, 174)
        Me.dgvAprobadas.TabIndex = 8
        '
        'colNumero
        '
        Me.colNumero.HeaderText = "Numero"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        '
        'colSolicitante
        '
        Me.colSolicitante.HeaderText = "Solicitante"
        Me.colSolicitante.Name = "colSolicitante"
        Me.colSolicitante.ReadOnly = True
        '
        'colObservaciones
        '
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.Name = "colObservaciones"
        Me.colObservaciones.ReadOnly = True
        '
        'lblSolicitudes
        '
        Me.lblSolicitudes.AutoSize = True
        Me.lblSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitudes.Location = New System.Drawing.Point(10, 0)
        Me.lblSolicitudes.Name = "lblSolicitudes"
        Me.lblSolicitudes.Size = New System.Drawing.Size(154, 15)
        Me.lblSolicitudes.TabIndex = 9
        Me.lblSolicitudes.Text = "Solicitudes Pendientes"
        '
        'lblAprobadas
        '
        Me.lblAprobadas.AutoSize = True
        Me.lblAprobadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAprobadas.Location = New System.Drawing.Point(572, -3)
        Me.lblAprobadas.Name = "lblAprobadas"
        Me.lblAprobadas.Size = New System.Drawing.Size(150, 15)
        Me.lblAprobadas.TabIndex = 10
        Me.lblAprobadas.Text = "Solicitudes Aprobadas"
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.dgvAprobadas)
        Me.gbxGeneral.Controls.Add(Me.lblAprobadas)
        Me.gbxGeneral.Controls.Add(Me.btnDerecha)
        Me.gbxGeneral.Controls.Add(Me.lblSolicitudes)
        Me.gbxGeneral.Controls.Add(Me.btnDerechaTodo)
        Me.gbxGeneral.Controls.Add(Me.btnIzquierda)
        Me.gbxGeneral.Controls.Add(Me.dgvSolicitudes)
        Me.gbxGeneral.Controls.Add(Me.btnIzquierdaTodo)
        Me.gbxGeneral.Location = New System.Drawing.Point(23, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(1007, 202)
        Me.gbxGeneral.TabIndex = 11
        Me.gbxGeneral.TabStop = False
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Location = New System.Drawing.Point(12, 236)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(1018, 275)
        Me.gbxDetalle.TabIndex = 12
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colCantidad, Me.colSaldo, Me.colCentroCosto, Me.colDescripcionCentro, Me.colObservacion, Me.colSolicita})
        Me.dgvDetalle.Location = New System.Drawing.Point(7, 19)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(1005, 250)
        Me.dgvDetalle.TabIndex = 2
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
        'colCantidad
        '
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        '
        'colSaldo
        '
        Me.colSaldo.HeaderText = "Saldo Actual"
        Me.colSaldo.Name = "colSaldo"
        Me.colSaldo.ReadOnly = True
        '
        'colCentroCosto
        '
        Me.colCentroCosto.HeaderText = "Centro Costo"
        Me.colCentroCosto.Name = "colCentroCosto"
        Me.colCentroCosto.ReadOnly = True
        '
        'colDescripcionCentro
        '
        Me.colDescripcionCentro.HeaderText = "Descripcion Centro"
        Me.colDescripcionCentro.Name = "colDescripcionCentro"
        Me.colDescripcionCentro.ReadOnly = True
        '
        'colObservacion
        '
        Me.colObservacion.HeaderText = "Observacion"
        Me.colObservacion.Name = "colObservacion"
        Me.colObservacion.ReadOnly = True
        '
        'colSolicita
        '
        Me.colSolicita.DropDownWidth = 5
        Me.colSolicita.HeaderText = "Solicita"
        Me.colSolicita.Name = "colSolicita"
        Me.colSolicita.ReadOnly = True
        Me.colSolicita.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSolicita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'menuContext
        '
        Me.menuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularItemToolStripMenuItem})
        Me.menuContext.Name = "menuContext"
        Me.menuContext.Size = New System.Drawing.Size(137, 26)
        '
        'AnularItemToolStripMenuItem
        '
        Me.AnularItemToolStripMenuItem.Name = "AnularItemToolStripMenuItem"
        Me.AnularItemToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AnularItemToolStripMenuItem.Text = "Anular Item"
        '
        'FrmAprobarSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1042, 523)
        Me.Controls.Add(Me.gbxDetalle)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmAprobarSolicitudes"
        Me.Text = "Aprobar solicitudes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAprobadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDerecha As System.Windows.Forms.Button
    Friend WithEvents btnDerechaTodo As System.Windows.Forms.Button
    Friend WithEvents btnIzquierda As System.Windows.Forms.Button
    Friend WithEvents btnIzquierdaTodo As System.Windows.Forms.Button
    Friend WithEvents dgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAprobadas As System.Windows.Forms.DataGridView
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblSolicitudes As System.Windows.Forms.Label
    Friend WithEvents lblAprobadas As System.Windows.Forms.Label
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcionCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicita As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents menuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnularItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents colNumeroS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicitanteS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacionesS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
