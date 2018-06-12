Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clCuentaContable
    Function consultaCuentaContablePantallaBusqueda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ccpb")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando consultaCuentaContablePantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultaCuentaContable() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cc")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaCuentaContable() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function
End Class
