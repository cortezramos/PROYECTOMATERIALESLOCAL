Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clsFincas
    Sub insertarFincas(FincaID As Integer, EmpresaID As Integer, Finca As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_FINCAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "IF")
                    .AddWithValue("@FincaID", FincaID)
                    .AddWithValue("@EmpresaID", EmpresaID)
                    .AddWithValue("@Finca", Finca)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error insertando fincas: " + ex.ToString())
        End Try
    End Sub
    Function consultarFincas() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_FINCAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CF")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando fincas: " + ex.ToString())
        End Try
        Return dt
    End Function

    Sub modificarFincas(FincaID As Integer, EmpresaID As Integer, Finca As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_FINCAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "MF")
                    .AddWithValue("@FincaID", FincaID)
                    .AddWithValue("@EmpresaID", EmpresaID)
                    .AddWithValue("@Finca", Finca)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error modificando fincas: " + ex.ToString())
        End Try
    End Sub
    Sub eliminarFinca(FincaID As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIG_FINCAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "EF")
                    .AddWithValue("@FincaID", FincaID)
                    .AddWithValue("@Estado", 0)
                End With
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error eliminando fincas: " + ex.ToString())
        End Try
    End Sub

    Function comboFincas(Empresa As Integer) As DataTable
        Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
            Try
                cmd = New SqlCommand("SP_CONFIG_FINCAS", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CFC")
                    .AddWithValue("@EmpresaID", Empresa)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
            Catch ex As Exception
                MsgBox("Error al cargar fincas: " + ex.ToString())
            End Try
            cnx.Close()
        End Using
        Return dt
    End Function
End Class