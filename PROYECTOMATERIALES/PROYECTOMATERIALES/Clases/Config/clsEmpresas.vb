Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class clsEmpresas
    Sub insertarEmpresa(Empresa As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_EMPRESAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "IE")
                    .AddWithValue("@Empresa", Empresa)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error guardando empresa: " + ex.ToString())
        End Try
    End Sub

    Function consultarEmpresas() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_EMPRESAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CE")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando empresas: " + ex.ToString())
        End Try
        Return dt
    End Function

    Sub modificarEmpresa(EmpresaID As Integer, Empresa As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_EMPRESAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ME")
                    .AddWithValue("@EmpresaID", EmpresaID)
                    .AddWithValue("@Empresa", Empresa)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error modificando empresa: " + ex.ToString())
        End Try
    End Sub

    Sub eliminarEmpresa(EmpresaID As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_EMPRESAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "EE")
                    .AddWithValue("@EmpresaID", EmpresaID)
                    .AddWithValue("@Estado", 0)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error eliminando empresa: " + ex.ToString())
        End Try
    End Sub

    Function consultaEmpresasCombo() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_EMPRESAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CEC")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando empresas: " + ex.ToString())
        End Try
        Return dt
    End Function
End Class