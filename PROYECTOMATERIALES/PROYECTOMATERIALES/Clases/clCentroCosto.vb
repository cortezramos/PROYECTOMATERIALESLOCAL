Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clCentroCosto
    Function consultaCentroDeCostoPantallaBusqueda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cccpb")
                    .AddWithValue("@Catalogo", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando consultaProductosPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultaCentroDeCosto() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ccc")
                    .AddWithValue("@Catalogo", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaCentroDeCosto() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function
End Class