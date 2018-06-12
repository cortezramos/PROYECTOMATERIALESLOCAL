Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clSolicitante
    Private respuesta As Integer
    Function insertarSolicitante(Codigo As Integer, Nombre As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "is")
                    .AddWithValue("@Codigo", Codigo)
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en insertarSolicitante() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarSolicitantes() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cs")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarSolicitantes() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function buscarSolicitantes(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bs")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en buscarSolicitantes() " & ex.Message)
            dt = New DataTable()
        End Try
        Return dt
    End Function

    Function ultimoCodigo() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ucs")
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

    Function eliminarSolicitante(Codigo As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "es")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en eliminarSolicitante() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarNombreSolicitante() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITANTES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cns")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarNombreSolicitante() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function
End Class