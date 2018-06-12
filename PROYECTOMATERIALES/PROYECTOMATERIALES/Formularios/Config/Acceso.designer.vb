<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Acceso
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
        Me.TServer = New System.Windows.Forms.TextBox
        Me.TBD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BActualiza = New System.Windows.Forms.Button
        Me.BSalir = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TPrograma = New System.Windows.Forms.TextBox
        Me.TClave = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BCrear = New System.Windows.Forms.Button
        Me.BBorra = New System.Windows.Forms.Button
        Me.BElimina = New System.Windows.Forms.Button
        Me.btnSP = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TServer
        '
        Me.TServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TServer.Location = New System.Drawing.Point(141, 72)
        Me.TServer.Name = "TServer"
        Me.TServer.Size = New System.Drawing.Size(292, 23)
        Me.TServer.TabIndex = 2
        '
        'TBD
        '
        Me.TBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBD.Location = New System.Drawing.Point(141, 113)
        Me.TBD.Name = "TBD"
        Me.TBD.Size = New System.Drawing.Size(292, 23)
        Me.TBD.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Base de Datos"
        '
        'BActualiza
        '
        Me.BActualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BActualiza.Location = New System.Drawing.Point(141, 164)
        Me.BActualiza.Name = "BActualiza"
        Me.BActualiza.Size = New System.Drawing.Size(91, 33)
        Me.BActualiza.TabIndex = 4
        Me.BActualiza.Text = "Actualizar"
        Me.BActualiza.UseVisualStyleBackColor = True
        '
        'BSalir
        '
        Me.BSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSalir.Location = New System.Drawing.Point(342, 164)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(91, 33)
        Me.BSalir.TabIndex = 6
        Me.BSalir.Text = "Salir"
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Programa"
        '
        'TPrograma
        '
        Me.TPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPrograma.Location = New System.Drawing.Point(141, 30)
        Me.TPrograma.Name = "TPrograma"
        Me.TPrograma.ReadOnly = True
        Me.TPrograma.Size = New System.Drawing.Size(292, 23)
        Me.TPrograma.TabIndex = 1
        Me.TPrograma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TClave
        '
        Me.TClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TClave.Location = New System.Drawing.Point(141, 84)
        Me.TClave.Name = "TClave"
        Me.TClave.Size = New System.Drawing.Size(118, 23)
        Me.TClave.TabIndex = 8
        Me.TClave.UseSystemPasswordChar = True
        Me.TClave.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Ingrese Clave"
        Me.Label4.Visible = False
        '
        'BCrear
        '
        Me.BCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCrear.Location = New System.Drawing.Point(245, 164)
        Me.BCrear.Name = "BCrear"
        Me.BCrear.Size = New System.Drawing.Size(91, 33)
        Me.BCrear.TabIndex = 10
        Me.BCrear.Text = "Crear"
        Me.BCrear.UseVisualStyleBackColor = True
        Me.BCrear.Visible = False
        '
        'BBorra
        '
        Me.BBorra.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BBorra.Location = New System.Drawing.Point(3, 197)
        Me.BBorra.Name = "BBorra"
        Me.BBorra.Size = New System.Drawing.Size(16, 23)
        Me.BBorra.TabIndex = 11
        Me.BBorra.TabStop = False
        Me.BBorra.Text = "B"
        Me.BBorra.UseVisualStyleBackColor = True
        '
        'BElimina
        '
        Me.BElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BElimina.Location = New System.Drawing.Point(342, 79)
        Me.BElimina.Name = "BElimina"
        Me.BElimina.Size = New System.Drawing.Size(91, 33)
        Me.BElimina.TabIndex = 12
        Me.BElimina.Text = "Eliminar"
        Me.BElimina.UseVisualStyleBackColor = True
        Me.BElimina.Visible = False
        '
        'btnSP
        '
        Me.btnSP.Location = New System.Drawing.Point(3, 169)
        Me.btnSP.Name = "btnSP"
        Me.btnSP.Size = New System.Drawing.Size(30, 23)
        Me.btnSP.TabIndex = 13
        Me.btnSP.Text = "SP"
        Me.btnSP.UseVisualStyleBackColor = True
        '
        'Acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSP)
        Me.Controls.Add(Me.BElimina)
        Me.Controls.Add(Me.BBorra)
        Me.Controls.Add(Me.BCrear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TClave)
        Me.Controls.Add(Me.TPrograma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BSalir)
        Me.Controls.Add(Me.BActualiza)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBD)
        Me.Controls.Add(Me.TServer)
        Me.Name = "Acceso"
        Me.Text = "Configuracion Accesos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TServer As System.Windows.Forms.TextBox
    Friend WithEvents TBD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BActualiza As System.Windows.Forms.Button
    Friend WithEvents BSalir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TPrograma As System.Windows.Forms.TextBox
    Friend WithEvents TClave As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BCrear As System.Windows.Forms.Button
    Friend WithEvents BBorra As System.Windows.Forms.Button
    Friend WithEvents BElimina As System.Windows.Forms.Button
    Friend WithEvents btnSP As System.Windows.Forms.Button
End Class
