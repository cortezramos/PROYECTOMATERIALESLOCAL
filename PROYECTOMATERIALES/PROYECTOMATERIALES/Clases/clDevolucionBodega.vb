Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clDevolucionBodega
    Private res As Integer
    Private resultado As Decimal

    Function ultimoNumeroDevolucion() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "und")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = CInt(dt.Rows(0)(0).ToString()) + 1
                Else
                    res = 1
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en ultimoNumeroDevolucion() " & ex.Message)
        End Try
        Return res
    End Function

    Function insertarMaestro(Numero As Integer, Fecha As Date, Solicitante As String, Bodega As Integer, Observaciones As String,
                            Tipo As Integer, Cliente As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "idm")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Solicitante", Solicitante)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Cliente", Cliente)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarDetalle(Numero As Integer, Producto As String, Descripcion As String, Cantidad As Decimal, CentroCosto As String,
                             DescrCentro As String) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "idd")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Cantidad", Cantidad)
                .AddWithValue("@CentroCosto", CentroCosto)
                .AddWithValue("@DescrCentro", DescrCentro)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarMovimientoMaestro(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "imm")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Tipo", 11)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarMovimientoDetalle(Numero As Integer, Bodega As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "imd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Bodega", Bodega)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function ejecutarPolizaDevolucion(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "epd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Tipo", 11)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en ejecutarPolizaDevolucion() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function busquedaDevolucionesBodega(FechaI As Date, FechaF As Date, Producto As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bdb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@FechaI", FechaI)
                    .AddWithValue("@FechaF", FechaF)
                    .AddWithValue("@Producto", Producto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en busquedaDevolucionesDeBodega()" & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDetalleSalidasDeBodegaDevolver(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdsbd")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Salida", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDetalleDevolucionesDeBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function buscarDevolucionBodegaPorNumero(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bdbpn")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en buscarDevolucionBodegaPorNumero() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarSalidasDeBodega(Bodega As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "csb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Bodega", Bodega)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarSalidasDeBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function verificarCantidadesPendientesDevolucion(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vcpd")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Salida", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en verificarCantidadesPendientesDevolucion() " & ex.Message)
        End Try
        Return dt
    End Function

    Function insertarSalidasMovimientos(Bodega As Integer, Salida As Integer, Devolucion As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "isd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Salida", Salida)
                .AddWithValue("@Numero", Devolucion)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarSalidasMovimientos() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarDetalleDevolucionBodega(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_DEVOLUCION_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cddb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDetalleDevolucionBodega() " & ex.Message)
        End Try
        Return dt
    End Function
End Class