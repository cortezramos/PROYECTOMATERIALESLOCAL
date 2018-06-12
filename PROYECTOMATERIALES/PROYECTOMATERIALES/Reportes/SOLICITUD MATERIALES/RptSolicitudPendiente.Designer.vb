<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptSolicitudPendiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptSolicitudPendiente))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbxParametros = New System.Windows.Forms.GroupBox()
        Me.dtFechaF = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaI = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaF = New System.Windows.Forms.Label()
        Me.lblFechaI = New System.Windows.Forms.Label()
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbxParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalir, Me.btnConsultar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxParametros)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rpt)
        Me.SplitContainer1.Size = New System.Drawing.Size(1004, 457)
        Me.SplitContainer1.SplitterDistance = 74
        Me.SplitContainer1.TabIndex = 1
        '
        'gbxParametros
        '
        Me.gbxParametros.Controls.Add(Me.dtFechaF)
        Me.gbxParametros.Controls.Add(Me.dtFechaI)
        Me.gbxParametros.Controls.Add(Me.lblFechaF)
        Me.gbxParametros.Controls.Add(Me.lblFechaI)
        Me.gbxParametros.Location = New System.Drawing.Point(7, 3)
        Me.gbxParametros.Name = "gbxParametros"
        Me.gbxParametros.Size = New System.Drawing.Size(991, 62)
        Me.gbxParametros.TabIndex = 4
        Me.gbxParametros.TabStop = False
        '
        'dtFechaF
        '
        Me.dtFechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaF.Location = New System.Drawing.Point(392, 23)
        Me.dtFechaF.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtFechaF.MinDate = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.dtFechaF.Name = "dtFechaF"
        Me.dtFechaF.Size = New System.Drawing.Size(138, 20)
        Me.dtFechaF.TabIndex = 3
        '
        'dtFechaI
        '
        Me.dtFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaI.Location = New System.Drawing.Point(149, 24)
        Me.dtFechaI.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.dtFechaI.MinDate = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.dtFechaI.Name = "dtFechaI"
        Me.dtFechaI.Size = New System.Drawing.Size(138, 20)
        Me.dtFechaI.TabIndex = 2
        '
        'lblFechaF
        '
        Me.lblFechaF.AutoSize = True
        Me.lblFechaF.Location = New System.Drawing.Point(312, 30)
        Me.lblFechaF.Name = "lblFechaF"
        Me.lblFechaF.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaF.TabIndex = 1
        Me.lblFechaF.Text = "Fecha final:"
        '
        'lblFechaI
        '
        Me.lblFechaI.AutoSize = True
        Me.lblFechaI.Location = New System.Drawing.Point(60, 30)
        Me.lblFechaI.Name = "lblFechaI"
        Me.lblFechaI.Size = New System.Drawing.Size(83, 13)
        Me.lblFechaI.TabIndex = 0
        Me.lblFechaI.Text = "Fecha inicial:"
        '
        'rpt
        '
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.Size = New System.Drawing.Size(1004, 379)
        Me.rpt.TabIndex = 0
        '
        'RptSolicitudPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1004, 482)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "RptSolicitudPendiente"
        Me.Text = "Solicitud pendiente"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbxParametros.ResumeLayout(False)
        Me.gbxParametros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents gbxParametros As System.Windows.Forms.GroupBox
    Friend WithEvents dtFechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaF As System.Windows.Forms.Label
    Friend WithEvents lblFechaI As System.Windows.Forms.Label
End Class
