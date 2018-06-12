Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clProductos
    Private resultado As Integer
    Private codigoResultado As String

    Function consultaProductosPantallaBusqueda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppb")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaProductosPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function busquedaProductosPantallaBusqueda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bppb")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en busquedaProductosPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarInformacionPantallaBusqueda(CodigoProducto As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cipb")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@CodigoProducto", CodigoProducto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarInformacionPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarMedidaProductos() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cmp")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarMedidaProductos() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarTipoInventario() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cti")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTipoInventario() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarTipoMoneda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ctm")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTipoMoneda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarSugerenciasNombresProductos(Descripcion As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "csnp")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Descripcion", Descripcion)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarSugerenciasNombresProductos() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarUltimoCodigoProducto(TipoInventario As Integer) As String
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cucp")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@TipoInventario", TipoInventario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
                If dt.Rows.Count > 0 Then
                    codigoResultado = dt.Rows(0)(0).ToString()
                Else
                    codigoResultado = "0"
                End If
            End Using
        Catch ex As Exception
            codigoResultado = "0"
            MsgBox("Error en consultarUltimoCodigoProducto() " & ex.Message)
        End Try
        Return codigoResultado
    End Function

    Function verificarNombreProductoNoExista(Descripcion As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cucp")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Descripcion", Descripcion)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarNombreProductoNoExista() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarProducto(Codigo As String, Descripcion As String, TipoInventario As Integer, Observaciones As String, Maximo As Integer,
                            Minimo As Integer, Existencia As Integer, Moneda As Integer, TipoVenta As Integer, Medida As Integer, Precio As Decimal) As Boolean
        Try
            cmd = New SqlCommand("SP_PRODUCTOS_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "ip")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@TipoInventario", TipoInventario)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Maximo", Maximo)
                .AddWithValue("@Minimo", Minimo)
                .AddWithValue("@AfectaExistencia", Existencia)
                .AddWithValue("@Moneda", Moneda)
                .AddWithValue("@Catalogo", catalogolog)
                .AddWithValue("@TipoVenta", TipoVenta)
                .AddWithValue("@Medida", Medida)
                .AddWithValue("@Precio", Precio)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarTodosProductos(Estado As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ctp")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Estado", Estado)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTodosProductos() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosEstadoYNombre(Descripcion As String, Estado As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppen")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Descripcion", Descripcion)
                    .AddWithValue("@Estado", Estado)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProductosEstadoYNombre() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosEstadoYNombreYTipo(Descripcion As String, Estado As String, TipoInventario As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppent")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Descripcion", Descripcion)
                    .AddWithValue("@Estado", Estado)
                    .AddWithValue("@TipoInventario", TipoInventario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProductosEstadoYNombreYTipo() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosPorTipoInventario(Estado As String, TipoInventario As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppti")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Estado", Estado)
                    .AddWithValue("@TipoInventario", TipoInventario)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProductosPorTipoInventario() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarYSeleccionarProducto(Codigo As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cysp")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarYSeleccionarProducto() " & ex.Message)
        End Try
        Return dt
    End Function

    Function cambiarEstadoProducto(Estado As String, Codigo As String) As Boolean
        Try
            cmd = New SqlCommand("SP_PRODUCTOS_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "cep")
                .AddWithValue("@Estado", Estado)
                .AddWithValue("@Catalogo", catalogolog)
                .AddWithValue("@Codigo", Codigo)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en cambiarEstadoProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function verificarExistenciaProducto(Codigo As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vep")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If CDec(dt.Rows(0)(0).ToString()) > 0 Then
                        Return False
                    End If
                End If
                cnx.Close()
            End Using
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en verificarExistenciaProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function eliminarEInsertarProductoUnidad(Codigo As String, Medida As Integer, Precio As Decimal) As Boolean
        Try
            cmd = New SqlCommand("SP_PRODUCTOS_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "eipu")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Medida", Medida)
                .AddWithValue("@Precio", Precio)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en eliminarEInsertarProductoUnidad() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function modificarProducto(Codigo As String, Descripcion As String, TipoInventario As Integer, Observaciones As String, Maximo As Integer,
                            Minimo As Integer, Existencia As Integer, Moneda As Integer, TipoVenta As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_PRODUCTOS_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "mp")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Catalogo", catalogolog)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@TipoInventario", TipoInventario)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Maximo", Maximo)
                .AddWithValue("@Minimo", Minimo)
                .AddWithValue("@AfectaExistencia", Existencia)
                .AddWithValue("@Moneda", Moneda)
                .AddWithValue("@TipoVenta", TipoVenta)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en modificarProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function verificarInventarioEnTransito(Codigo As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vitp")
                    .AddWithValue("@Codigo", Codigo)
                    .AddWithValue("@Empresa", empresaid)
                End With
                cnx.Close()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarInventarioEnTransito() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function seleccionarClienteReporteria() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "scr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en seleccionarClienteReporteria() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarFincasReporteria() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cfr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarFincasReporteria() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarCentroCostoReporteria() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cccr")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarCentroCostoReporteria() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarTipoEnvioReporteria() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cter")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTipoEnvioReporteria()  " & ex.Message)
        End Try
        Return dt
    End Function

    Function tipoInventarioPorProducto(Codigo As String) As String
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_PRODUCTOS_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ctipp")
                    .AddWithValue("@Codigo", Codigo)
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    codigoResultado = dt.Rows(0)(0).ToString()
                Else
                    codigoResultado = "%%"
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            codigoResultado = "%%"
        End Try
        Return codigoResultado
    End Function
End Class