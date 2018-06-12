Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clResponsable
    Private respuesta As Integer
    Function insertarResponsable(Codigo As Integer, Nombre As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ir")
                    .AddWithValue("@Codigo", Codigo)
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en insertarResponsable() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarResponsables() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarResponsables() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function buscarResponsables(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "br")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en buscarResponsables() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function ultimoCodigo() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ucr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    respuesta = CInt(dt.Rows(0)(0).ToString()) + 1
                Else
                    respuesta = 1
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en ultimoCodigo() " & ex.Message)
            respuesta = 0
        End Try
        Return respuesta
    End Function

    Function eliminarResponsable(Codigo As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "er")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en eliminarResponsable() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarNombreResponsable() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_RESPONSABLES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cnr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarNombreResponsable() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function
End Class