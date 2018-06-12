Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clConfigReportServer
    Private respuesta As Integer

    Sub insertarReportServer(Url As String, Direccion As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIGREPORTSERVER", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "irs")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Url", Url)
                    .AddWithValue("@Path", Direccion)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en insertarReportServer()")
        End Try
    End Sub

    Sub modificarReportServer(Url As String, Direccion As String)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIGREPORTSERVER", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "mrs")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Url", Url)
                    .AddWithValue("@Path", Direccion)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en modificarReportServer()")
        End Try
    End Sub

    Function consultarReportServer() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CONFIGREPORTSERVER", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "crs")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    vUrlReportServer = dt.Rows(0)(0).ToString()
                    vPathReportServer = dt.Rows(0)(1).ToString()
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable()
            MsgBox("Error en consultarReportServer")
        End Try
        Return dt
    End Function
End Class