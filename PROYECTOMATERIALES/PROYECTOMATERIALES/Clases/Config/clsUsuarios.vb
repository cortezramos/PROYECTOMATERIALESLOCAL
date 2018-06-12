Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class clsUsuarios
    'Variable para respuestas de clase usuarios en las funciones
    Public res As Integer
    Public vEmpresaid As Integer
    Public vUsuarioid As Integer
    Public vUsuariolog As String
    Public vTipousuariolog As Integer
    Public vCatalogolog As Integer
    Public vSucursallog As Integer
    Public vAltoPantalla As Decimal
    Public vAnchoPantalla As Decimal
    Public vServerUrl As String
    Public vServerPath As String
    Public vModificarlog As Integer
    Public vEliminarlog As Integer

    Function configAccesoExterno() As Boolean
        Dim vPrograma As String = "PROYECTOMATERIALES"
        Try
            ''Verifica si hay la ruta en el registro esta creada
            If My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\ROSBANA\" & vPrograma, True) Is Nothing Then
                'MsgBox("No esta configurado el acceso a la base de datos", MsgBoxStyle.Information, "Aviso")
                If MessageBox.Show("No esta configurado el acceso a la base de datos, desea crearlo", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Dim f As New Acceso
                    f.Show()
                    Return False
                Else
                    Return False
                End If
            Else
                ''Lee los valores del registro y los pone en los textbox
                vBaseDatos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & vPrograma & "\Config", "BD", Nothing)
                vServer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & vPrograma & "\Config", "SERVER", Nothing)
                Conexion = "Data Source = " & vServer & "; Initial Catalog = " & vBaseDatos & "; Integrated Security = True"
                If String.IsNullOrEmpty(vBaseDatos) Or vBaseDatos = "Ingrese Valor" Then
                    Dim f As New Acceso
                    f.Show()
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Sub loginExterno()
        empresaid = vEmpresaid
        usuarioid = vUsuarioid
        usuariolog = vUsuariolog
        tipousuariolog = vTipousuariolog
        catalogolog = vCatalogolog
        sucursallog = vSucursallog
        altoPantalla = vAltoPantalla
        anchoPantalla = vAnchoPantalla
        modificarlog = vModificarlog
        eliminarlog = vEliminarlog
        vUrlReportServer = vServerUrl
        vPathReportServer = vServerPath
        configAccesoExterno()
    End Sub

    Function login(Usuario As String, Contra As String) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "L")
                    .AddWithValue("@Usuario", Usuario)
                    .AddWithValue("@Contra", Contra)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = 1
                    usuarioid = CInt(dt.Rows(0)(0).ToString())
                    usuariolog = dt.Rows(0)(1).ToString()
                    contralog = dt.Rows(0)(2).ToString()
                    crearlog = CInt(dt.Rows(0)(5).ToString())
                    eliminarlog = CInt(dt.Rows(0)(6).ToString())
                    modificarlog = CInt(dt.Rows(0)(7).ToString())
                    tipousuariolog = CInt(dt.Rows(0)(8).ToString())
                    If tipousuariolog <> 1 Then
                        empresaid = CInt(dt.Rows(0)(9).ToString())
                        empresa = dt.Rows(0)(10).ToString()
                        ' = CInt(dt.Rows(0)(11).ToString())
                        'finca = dt.Rows(0)(12).ToString()
                    End If
                    catalogolog = CInt(dt.Rows(0)(13).ToString())
                    sucursallog = CInt(dt.Rows(0)(14).ToString())
                Else
                    res = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en login: " + ex.ToString())
        End Try
        Return res
    End Function

    Sub ingresarUsuario(Usuario As String, Contra As String, EmpresaID As Integer, FincaID As Integer, Tipo As Integer, Sucursal As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "IU")
                    .AddWithValue("@Usuario", Usuario)
                    .AddWithValue("@Contra", Contra)
                    .AddWithValue("@Estado", 1)
                    .AddWithValue("@EmpresaID", EmpresaID)
                    .AddWithValue("@FincaID", FincaID)
                    .AddWithValue("@Tipo", Tipo)
                    .AddWithValue("@Sucursal", Sucursal)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al ingresar usuario: " + ex.ToString())
        End Try
    End Sub

    Function consultarUsuarios() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CU")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando los usuarios e ID's: " + ex.ToString())
        End Try
        Return dt
    End Function

    Sub modificarUsuario(UsuarioID As Integer, Contra As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "MU")
                    .AddWithValue("@UsuarioID", UsuarioID)
                    .AddWithValue("@Contra", Contra)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error modificando usuario: " + ex.ToString())
        End Try
    End Sub

    Sub eliminarUsuario(UsuarioID As Integer)
        ''Solo le cambia de estado en la base de datos
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "EU")
                    .AddWithValue("@UsuarioID", UsuarioID)
                    .AddWithValue("@Estado", 0)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error eliminando usuario: " + ex.ToString())
        End Try
    End Sub

    Function consultaTodosUsuarios() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CTU")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al consultar usuarios: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function buscaTodosUsuarios(Usuario As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "BTU")
                    .AddWithValue("@Usuario", Usuario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al buscar usuarios: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function verificaUsuario(Usuario As String, Sucursal As Integer, Empresa As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "VU")
                    .AddWithValue("@Usuario", Usuario)
                    .AddWithValue("@Sucursal", Sucursal)
                    .AddWithValue("@EmpresaID", Empresa)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al buscar usuarios: " + ex.ToString())
        End Try
        Return True
    End Function

    Function seleccionSucursalParaUsuario(vEmpresa) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ssu")
                    .AddWithValue("@EmpresaID", vEmpresa)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en seleccionSucursalParaUsuario()")
        End Try
        Return dt
    End Function

    Function seleccionSucursalSistema(vEmpresa As Integer, vUsuario As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "sss")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en seleccionSucursalParaUsuario()")
        End Try
        Return dt
    End Function

    Function consultarListaUsuarios() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "clu")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarListaUsuarios()")
        End Try
        Return dt
    End Function

    Function consultarSucursalesParaUsuario(vEmpresa As Integer, vUsuario As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "csu")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarSucursalesParaUsuario()")
        End Try
        Return dt
    End Function

    Sub asignarSucursalesPorUsuario(vUsuario As Integer, vEmpresa As Integer, vSucursal As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "asu")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuario)
                    .AddWithValue("@Sucursal", vSucursal)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarSucursalesParaUsuario()")
        End Try
    End Sub

    Function verificarExisteSucursal(vUsuario As Integer, vEmpresa As Integer, vSucursal As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_USUARIOS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ves")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuario)
                    .AddWithValue("@Sucursal", vSucursal)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarExisteSucursal()")
            Return False
        End Try
        Return True
    End Function
End Class