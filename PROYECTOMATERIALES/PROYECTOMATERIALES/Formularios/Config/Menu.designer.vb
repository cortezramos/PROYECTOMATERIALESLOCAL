<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.tvMenu = New System.Windows.Forms.TreeView()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'tvMenu
        '
        Me.tvMenu.BackColor = System.Drawing.SystemColors.Menu
        Me.tvMenu.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMenu.ImageIndex = 2
        Me.tvMenu.ImageList = Me.imgLista
        Me.tvMenu.Location = New System.Drawing.Point(1, 1)
        Me.tvMenu.Name = "tvMenu"
        Me.tvMenu.SelectedImageIndex = 3
        Me.tvMenu.Size = New System.Drawing.Size(216, 455)
        Me.tvMenu.TabIndex = 0
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "Menu.png")
        Me.imgLista.Images.SetKeyName(1, "SubMenu.png")
        Me.imgLista.Images.SetKeyName(2, "Lista.png")
        Me.imgLista.Images.SetKeyName(3, "EstaAca.png")
        Me.imgLista.Images.SetKeyName(4, "Configuraciones.jpeg")
        Me.imgLista.Images.SetKeyName(5, "CambiarSalir.png")
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1083, 457)
        Me.Controls.Add(Me.tvMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Public WithEvents tvMenu As System.Windows.Forms.TreeView
End Class
