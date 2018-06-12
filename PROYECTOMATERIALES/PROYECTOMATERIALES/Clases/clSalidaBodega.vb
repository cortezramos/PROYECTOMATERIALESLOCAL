Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clSalidaBodega
    Private res As Integer
    Private resultado As Decimal

    Function ultimoNumeroSalida() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "uns")
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
            MsgBox("Error en ultimoNumeroSalida() " & ex.Message)
        End Try
        Return res
    End Function

    Function consultarTipoEnvio() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cte")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTipoEnvio() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarParametrosTipoSalida(Codigo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cpts")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarParametrosTipoSalida() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDatosProducto(Producto As String, Bodega As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Producto", Producto)
                    .AddWithValue("@Bodega", Bodega)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDatosProducto() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDiaEnServidor() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                cmd.Parameters.AddWithValue("@Opcion", "cdes")
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = CInt(dt.Rows(0)(0).ToString)
                Else
                    res = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            res = 0
            MsgBox("Error en consultarDiaEnServidor() " & ex.Message)
        End Try
        Return res
    End Function

    Function consultarExistenciaProductoPorBodega(Producto As String, Bodega As Integer) As Decimal
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ceppb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Producto", Producto)
                    .AddWithValue("@Bodega", Bodega)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    resultado = CDec(dt.Rows(0)(0).ToString)
                Else
                    resultado = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            resultado = 0
            MsgBox("Error en consultarExistenciaProductoPorBodega() " & ex.Message)
        End Try
        Return resultado
    End Function

    Function insertarMaestro(Numero As Integer, Fecha As Date, Solicitante As String, Bodega As Integer, Observaciones As String,
                            Tipo As Integer, Cliente As Integer, Responsable As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iem")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Solicitante", Solicitante)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Cliente", Cliente)
                .AddWithValue("@Usuario", usuariolog)
                .AddWithValue("@Responsable", Responsable)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error en guardar envio maestro" & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
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
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "ied")
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
            MsgBox("Error al guardar envio detalle " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarDetalle() " + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarMovimientoMaestro(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "imm")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Tipo", 16)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error al guardar movimiento maestro " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarMovimientoDetalle(Numero As Integer, Bodega As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
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
            MsgBox("Error en insertar movimiento detalle " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function ejecutarPolizaSalida(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "eps")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Tipo", 16)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error en Poliza Salida()" & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en ejecuarPolizaSalida() ", ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function ejecuarPolizaAnulaSalida(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "epas")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Tipo", 16)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error en poliza anula salida " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en ejecuarPolizaAnulaSalida()" & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function actualizarExistenciaAnulacionSalida(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "aeas")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en actualizarExistenciaAnulacionSalida() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function busquedaSalidasBodega(FechaI As Date, FechaF As Date, Producto As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bsb")
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
            MsgBox("Error en busquedaSalidasBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDetalleSalidaBodega(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdsb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDetalleSalidaBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarFechasSalidaBodega(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cfsb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarFechasSalidaBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function anularEnvioYMovimientoMaestro(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "aemm")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en anularEnvioYMovimientoMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function anularEnvioYMovimientoDetalle(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "aemd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en anularEnvioYMovimientoDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function buscarSalidaBodegaPorNumero(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bsbpn")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en buscarSalidaBodegaPorNumero() " & ex.Message)
        End Try
        Return dt
    End Function

    Function verificarExisteDevolucionSalida(Numero As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_SALIDA_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "veds")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarExisteDevolucionSalida() " & ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class