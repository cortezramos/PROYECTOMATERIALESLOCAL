<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobarCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAprobarCompras))
        Me.gbxDetalle = New System.Windows.Forms.GroupBox()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExistencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.dgvAprobadas = New System.Windows.Forms.DataGridView()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblAprobadas = New System.Windows.Forms.Label()
        Me.btnDerecha = New System.Windows.Forms.Button()
        Me.lblSolicitudes = New System.Windows.Forms.Label()
        Me.btnDerechaTodo = New System.Windows.Forms.Button()
        Me.btnIzquierda = New System.Windows.Forms.Button()
        Me.dgvOrdenes = New System.Windows.Forms.DataGridView()
        Me.colNumeroS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolicitanteS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObservacionesS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnIzquierdaTodo = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.gbxDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        CType(Me.dgvAprobadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxDetalle
        '
        Me.gbxDetalle.Controls.Add(Me.dgvDetalle)
        Me.gbxDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDetalle.Location = New System.Drawing.Point(14, 236)
        Me.gbxDetalle.Name = "gbxDetalle"
        Me.gbxDetalle.Size = New System.Drawing.Size(1007, 240)
        Me.gbxDetalle.TabIndex = 2
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colMedida, Me.colCantidad, Me.colExistencia, Me.colPrecio, Me.colCosto})
        Me.dgvDetalle.Location = New System.Drawing.Point(7, 19)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(994, 215)
        Me.dgvDetalle.TabIndex = 1
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
        'colMedida
        '
        Me.colMedida.HeaderText = "Medida"
        Me.colMedida.Name = "colMedida"
        Me.colMedida.ReadOnly = True
        '
        'colCantidad
        '
        Me.colCantidad.HeaderText = "Cantidad de Comprar"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        '
        'colExistencia
        '
        Me.colExistencia.HeaderText = "Existencia"
        Me.colExistencia.Name = "colExistencia"
        Me.colExistencia.ReadOnly = True
        '
        'colPrecio
        '
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.ReadOnly = True
        '
        'colCosto
        '
        Me.colCosto.HeaderText = "Costo"
        Me.colCosto.Name = "colCosto"
        Me.colCosto.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnGuardar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1029, 25)
        Me.ToolStrip1.TabIndex = 25
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
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.dgvAprobadas)
        Me.gbxGeneral.Controls.Add(Me.lblAprobadas)
        Me.gbxGeneral.Controls.Add(Me.btnDerecha)
        Me.gbxGeneral.Controls.Add(Me.lblSolicitudes)
        Me.gbxGeneral.Controls.Add(Me.btnDerechaTodo)
        Me.gbxGeneral.Controls.Add(Me.btnIzquierda)
        Me.gbxGeneral.Controls.Add(Me.dgvOrdenes)
        Me.gbxGeneral.Controls.Add(Me.btnIzquierdaTodo)
        Me.gbxGeneral.Location = New System.Drawing.Point(14, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(1007, 202)
        Me.gbxGeneral.TabIndex = 26
        Me.gbxGeneral.TabStop = False
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
        Me.colSolicitante.HeaderText = "Proveedor"
        Me.colSolicitante.Name = "colSolicitante"
        Me.colSolicitante.ReadOnly = True
        '
        'colObservaciones
        '
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.Name = "colObservaciones"
        Me.colObservaciones.ReadOnly = True
        '
        'lblAprobadas
        '
        Me.lblAprobadas.AutoSize = True
        Me.lblAprobadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAprobadas.Location = New System.Drawing.Point(572, -3)
        Me.lblAprobadas.Name = "lblAprobadas"
        Me.lblAprobadas.Size = New System.Drawing.Size(133, 15)
        Me.lblAprobadas.TabIndex = 10
        Me.lblAprobadas.Text = "Ordenes Aprobadas"
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
        'lblSolicitudes
        '
        Me.lblSolicitudes.AutoSize = True
        Me.lblSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitudes.Location = New System.Drawing.Point(10, 0)
        Me.lblSolicitudes.Name = "lblSolicitudes"
        Me.lblSolicitudes.Size = New System.Drawing.Size(137, 15)
        Me.lblSolicitudes.TabIndex = 9
        Me.lblSolicitudes.Text = "Ordenes Pendientes"
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
        'dgvOrdenes
        '
        Me.dgvOrdenes.AllowUserToAddRows = False
        Me.dgvOrdenes.AllowUserToDeleteRows = False
        Me.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrdenes.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumeroS, Me.colSolicitanteS, Me.colObservacionesS})
        Me.dgvOrdenes.Location = New System.Drawing.Point(19, 19)
        Me.dgvOrdenes.Name = "dgvOrdenes"
        Me.dgvOrdenes.ReadOnly = True
        Me.dgvOrdenes.Size = New System.Drawing.Size(457, 174)
        Me.dgvOrdenes.TabIndex = 7
        '
        'colNumeroS
        '
        Me.colNumeroS.HeaderText = "Numero"
        Me.colNumeroS.Name = "colNumeroS"
        Me.colNumeroS.ReadOnly = True
        '
        'colSolicitanteS
        '
        Me.colSolicitanteS.HeaderText = "Proveedor"
        Me.colSolicitanteS.Name = "colSolicitanteS"
        Me.colSolicitanteS.ReadOnly = True
        '
        'colObservacionesS
        '
        Me.colObservacionesS.HeaderText = "Observaciones"
        Me.colObservacionesS.Name = "colObservacionesS"
        Me.colObservacionesS.ReadOnly = True
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
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(810, 488)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(40, 13)
        Me.lblTotal.TabIndex = 27
        Me.lblTotal.Text = "Total:"
        '
        'txtTotal
        '
        Me.txtTotal.ForeColor = System.Drawing.Color.Maroon
        Me.txtTotal.Location = New System.Drawing.Point(867, 482)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtTotal.TabIndex = 28
        '
        'FrmAprobarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1029, 512)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.gbxGeneral)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbxDetalle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "FrmAprobarCompras"
        Me.Text = "Aprobar compras"
        Me.gbxDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        CType(Me.dgvAprobadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAprobadas As System.Windows.Forms.DataGridView
    Friend WithEvents lblAprobadas As System.Windows.Forms.Label
    Friend WithEvents btnDerecha As System.Windows.Forms.Button
    Friend WithEvents lblSolicitudes As System.Windows.Forms.Label
    Friend WithEvents btnDerechaTodo As System.Windows.Forms.Button
    Friend WithEvents btnIzquierda As System.Windows.Forms.Button
    Friend WithEvents dgvOrdenes As System.Windows.Forms.DataGridView
    Friend WithEvents btnIzquierdaTodo As System.Windows.Forms.Button
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMedida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExistencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumeroS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicitanteS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservacionesS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
End Class
