﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptKardexCompra
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
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpt
        '
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rpt.Size = New System.Drawing.Size(944, 437)
        Me.rpt.TabIndex = 0
        '
        'RptKardexCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 437)
        Me.Controls.Add(Me.rpt)
        Me.Name = "RptKardexCompra"
        Me.Text = "Kardex"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
End Class
