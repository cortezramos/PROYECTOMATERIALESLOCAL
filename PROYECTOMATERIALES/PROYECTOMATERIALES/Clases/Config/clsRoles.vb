Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class clsRoles
    'Variables para uso de la clase
    Public res As Integer

    Sub ingresarRol(UsuarioID As Integer, MenuID As Integer, Crear As Integer, Modificar As Integer, Eliminar As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "IR")
                    .AddWithValue("@UsuarioID", UsuarioID)
                    .AddWithValue("@MenuID", MenuID)
                    .AddWithValue("@Crear", Crear)
                    .AddWithValue("@Modificar", Modificar)
                    .AddWithValue("@Eliminar", Eliminar)
                    .AddWithValue("@EmpresaID", empresaid)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al insertar nuevo rol: " + ex.ToString())
        End Try
    End Sub

    Function verificarMenuAgregado(Usuario As String, MenuID As Integer) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "VMA")
                    .AddWithValue("@Usuario", Usuario)
                    .AddWithValue("@MenuID", MenuID)
                    .AddWithValue("@EmpresaID", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = CInt(dt.Rows(0)(0).ToString())
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificacion de menus agregados: " + ex.ToString())
        End Try
        Return res
    End Function

    Function consultaMenusPadres() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CMP")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error cargando padres en roles: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function detalleRoles(UsuarioID As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "DR")
                    .AddWithValue("@UsuarioID", UsuarioID)
                    .AddWithValue("@EmpresaID", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Function consultaExistenciaRol(UsuarioID As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CPE")
                    .AddWithValue("@UsuarioID", UsuarioID)
                    .AddWithValue("@EmpresaID", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando existencia de rol: " + ex.ToString())
        End Try
        Return dt
    End Function
    Sub eliminarRol(RolID As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ER")
                    .AddWithValue("@RolID", RolID)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error eliminando rol: " + ex.ToString())
        End Try
    End Sub

    Function verificarIngresoMasivoUsuarios(vUsuario As Integer, vEmpresa As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vim")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarIngresoMasivoUsuarios()")
            Return False
        End Try
        Return True
    End Function

    Sub ingresoPermisosMasivos(vEmpresa As Integer, vUsuarioID As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_ROLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ipm")
                    .AddWithValue("@EmpresaID", vEmpresa)
                    .AddWithValue("@UsuarioID", vUsuarioID)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en ingresoPermisosMasivos()")
        End Try
    End Sub
End Class