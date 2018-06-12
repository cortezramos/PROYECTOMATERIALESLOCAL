Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clCentroCostoReferencia
    Private respuesta As Integer
    Function insertarReferencia(Codigo As Integer, Nombre As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ir")
                    .AddWithValue("@Codigo", Codigo)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en insertarReferencia() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarReferencias() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cr")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarReferencias() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function buscarReferencias(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "br")
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en buscarReferencias() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function ultimoCodigo() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ucr")
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

    Function eliminarReferencia(Codigo As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "er")
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

    Function consultarNombreReferencia() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_CENTRO_COSTOS_REFERENCIA", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cnr")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarNombreReferencia() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function
End Class
