Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Menu
#Region "Controles"
    Private Function verificarFormularioAbierto() As Boolean
        If Not IsNothing(Me.ActiveMdiChild) Then
            If MessageBox.Show("Solamente una ventana puede estar activa " & Me.ActiveMdiChild.Name & " desea cerrar la actual?", "Formulario abierto!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Me.ActiveMdiChild.Close()
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
#End Region
#Region "Deshabilita boton cerrar"
    Dim _enabledCerrar As Boolean = False
    <System.ComponentModel.DefaultValue(False), System.ComponentModel.Description("Define si se habilita el botón cerrar en el formulario")> _
    Public Property EnabledCerrar() As Boolean
        Get
            Return _enabledCerrar
        End Get
        Set(ByVal Value As Boolean)
            If _enabledCerrar <> Value Then
                _enabledCerrar = Value
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If _enabledCerrar = False Then
                Const CS_NOCLOSE As Integer = &H200
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            End If
            Return cp
        End Get
    End Property
#End Region
    ''Instanciacion de conexion y declaracion de variables de tipo sql
    'Public cmd As SqlCommand
    'Public da As SqlDataAdapter
    'Public dt As DataTable
    Public Formulario As String
    ''Variables de tamaño de pantalla
    Public alto As Double
    Public ancho As Double
    ''Instanciamiento de clases
    Public config As New clsConfig

    Public Function dibujaMenu(usuario As String, contra As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "DM")
                    .AddWithValue("@Usuario", usuario)
                    .AddWithValue("@Contra", contra)
                    .AddWithValue("@EmpresaID", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Return False
                End If
                creaNodos(0, Nothing)
                cnx.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error cargando menu en:" + ex.ToString)
        End Try
        Return True
    End Function

    Private Sub creaNodos(indice As Integer, nodoPadre As TreeNode)
        Dim dvHijos As DataView
        dvHijos = New DataView(dt)

        dvHijos.RowFilter = dt.Columns("PadreID").ColumnName + " = " + indice.ToString()

        For Each drCurrent As DataRowView In dvHijos
            Dim nuevoNodo As New TreeNode

            nuevoNodo.Text = drCurrent("Nombre").ToString().Trim()
            nuevoNodo.Name = drCurrent("FrmAbrir").ToString().Trim()
            nuevoNodo.ImageIndex = drCurrent("FrmImg").ToString().Trim()

            If nodoPadre Is Nothing Then
                tvMenu.Nodes.Add(nuevoNodo)
            Else
                nodoPadre.Nodes.Add(nuevoNodo)
            End If
            creaNodos(Int32.Parse(drCurrent("MenuID").ToString()), nuevoNodo)
        Next drCurrent
    End Sub

    Private Sub tvMenu_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvMenu.NodeMouseDoubleClick
        Formulario = e.Node.Name
        Dim Nombre As String = e.Node.Text
        If Formulario = "Salir" Then
            Me.Close()
        ElseIf Formulario = "SA" Then
            Dim frm As New FrmLogueo
            If frm.ShowDialog() = 1 Then
                If verificarFormularioAbierto() Then
                    config.abrirFormulario(Me, "FrmSuperAdmin", alto, ancho, "Super Admin")
                End If
            Else
                MessageBox.Show("No cuenta con permisos para esta funcion")
            End If
        ElseIf Formulario = "Cambiar sesion" Then
            Dim frm As New Login
            frm.Show()
            Me.Close()
        ElseIf Formulario = Nothing Then
            Exit Sub
        Else
            If verificarFormularioAbierto() Then
                config.abrirFormulario(Me, Formulario, alto, ancho, Nombre)
            End If
        End If
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        alto = Me.Height
        ancho = Me.Width

        altoPantalla = Me.Height
        anchoPantalla = Me.Width

        tvMenu.Height = alto - 40
        tvMenu.Width = 300
    End Sub

    Private Sub tvMenu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tvMenu.KeyPress
        If e.KeyChar = Chr(13) Then
            Formulario = tvMenu.SelectedNode.Name
            Dim Nombre As String = tvMenu.SelectedNode.Text
            If Formulario = "Salir" Then
                Me.Close()
            ElseIf Formulario = "SA" Then
                Dim frm As New FrmLogueo
                If frm.ShowDialog() = 1 Then
                    If verificarFormularioAbierto() Then
                        config.abrirFormulario(Me, "FrmSuperAdmin", alto, ancho, "Super Admin")
                    End If
                Else
                    MessageBox.Show("No cuenta con permisos para esta funcion")
                End If
            ElseIf Formulario = "Cambiar sesion" Then
                Dim frm As New Login
                frm.Show()
                Me.Close()
            ElseIf Formulario = Nothing Then
                Exit Sub
            Else
                If verificarFormularioAbierto() Then
                    config.abrirFormulario(Me, Formulario, alto, ancho, Nombre)
                End If
            End If
        End If
    End Sub
End Class