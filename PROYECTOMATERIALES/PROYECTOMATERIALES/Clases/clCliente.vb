Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clCliente
    Private res As Integer

    Function consultarClientes() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CLIENTE", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cc")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarClientes() " & ex.Message)
        End Try
        Return dt
    End Function
End Class