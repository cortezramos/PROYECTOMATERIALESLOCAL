<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptKardexSinCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptKardexSinCosto))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbxGeneral = New System.Windows.Forms.GroupBox()
        Me.cmbBodega = New System.Windows.Forms.ComboBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.dtFechaF = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaI = New System.Windows.Forms.DateTimePicker()
        Me.lblBodega = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.lblFechaF = New System.Windows.Forms.Label()
        Me.lblFechaI = New System.Windows.Forms.Label()
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbxGeneral.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxGeneral)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rpt)
        Me.SplitContainer1.Size = New System.Drawing.Size(880, 585)
        Me.SplitContainer1.SplitterDistance = 162
        Me.SplitContainer1.TabIndex = 0
        '
        'gbxGeneral
        '
        Me.gbxGeneral.Controls.Add(Me.cmbBodega)
        Me.gbxGeneral.Controls.Add(Me.cmbProducto)
        Me.gbxGeneral.Controls.Add(Me.txtFiltro)
        Me.gbxGeneral.Controls.Add(Me.dtFechaF)
        Me.gbxGeneral.Controls.Add(Me.dtFechaI)
        Me.gbxGeneral.Controls.Add(Me.lblBodega)
        Me.gbxGeneral.Controls.Add(Me.lblProducto)
        Me.gbxGeneral.Controls.Add(Me.lblFiltro)
        Me.gbxGeneral.Controls.Add(Me.lblFechaF)
        Me.gbxGeneral.Controls.Add(Me.lblFechaI)
        Me.gbxGeneral.Location = New System.Drawing.Point(12, 28)
        Me.gbxGeneral.Name = "gbxGeneral"
        Me.gbxGeneral.Size = New System.Drawing.Size(850, 123)
        Me.gbxGeneral.TabIndex = 0
        Me.gbxGeneral.TabStop = False
        '
        'cmbBodega
        '
        Me.cmbBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.DropDownWidth = 400
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(118, 84)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(310, 21)
        Me.cmbBodega.TabIndex = 9
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducto.DropDownWidth = 400
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(446, 53)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(317, 21)
        Me.cmbProducto.TabIndex = 7
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(118, 53)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(228, 20)
        Me.txtFiltro.TabIndex = 5
        '
        'dtFechaF
        '
        Me.dtFechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaF.Location = New System.Drawing.Point(446, 20)
        Me.dtFechaF.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtFechaF.MinDate = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.dtFechaF.Name = "dtFechaF"
        Me.dtFechaF.Size = New System.Drawing.Size(229, 20)
        Me.dtFechaF.TabIndex = 3
        '
        'dtFechaI
        '
        Me.dtFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaI.Location = New System.Drawing.Point(118, 20)
        Me.dtFechaI.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtFechaI.MinDate = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.dtFechaI.Name = "dtFechaI"
        Me.dtFechaI.Size = New System.Drawing.Size(228, 20)
        Me.dtFechaI.TabIndex = 1
        '
        'lblBodega
        '
        Me.lblBodega.AutoSize = True
        Me.lblBodega.Location = New System.Drawing.Point(33, 87)
        Me.lblBodega.Name = "lblBodega"
        Me.lblBodega.Size = New System.Drawing.Size(50, 13)
        Me.lblBodega.TabIndex = 8
        Me.lblBodega.Text = "Bodega"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(370, 56)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(58, 13)
        Me.lblProducto.TabIndex = 6
        Me.lblProducto.Text = "Producto"
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Location = New System.Drawing.Point(33, 56)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(35, 13)
        Me.lblFiltro.TabIndex = 4
        Me.lblFiltro.Text = "Filtro"
        '
        'lblFechaF
        '
        Me.lblFechaF.AutoSize = True
        Me.lblFechaF.Location = New System.Drawing.Point(370, 26)
        Me.lblFechaF.Name = "lblFechaF"
        Me.lblFechaF.Size = New System.Drawing.Size(70, 13)
        Me.lblFechaF.TabIndex = 2
        Me.lblFechaF.Text = "Fecha final"
        '
        'lblFechaI
        '
        Me.lblFechaI.AutoSize = True
        Me.lblFechaI.Location = New System.Drawing.Point(33, 26)
        Me.lblFechaI.Name = "lblFechaI"
        Me.lblFechaI.Size = New System.Drawing.Size(79, 13)
        Me.lblFechaI.TabIndex = 0
        Me.lblFechaI.Text = "Fecha inicial"
        '
        'rpt
        '
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.Size = New System.Drawing.Size(880, 419)
        Me.rpt.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnConsultar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(880, 25)
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
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(23, 22)
        Me.btnConsultar.Text = "Consultar"
        '
        'RptKardexSinCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(880, 585)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "RptKardexSinCosto"
        Me.Text = "Kardex"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbxGeneral.ResumeLayout(False)
        Me.gbxGeneral.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gbxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaF As System.Windows.Forms.Label
    Friend WithEvents lblFechaI As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblFiltro As System.Windows.Forms.Label
    Friend WithEvents lblBodega As System.Windows.Forms.Label
    Friend WithEvents dtFechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
End Class
