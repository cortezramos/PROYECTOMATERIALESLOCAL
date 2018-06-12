Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clOrdenesCompra
    Private res As Integer
    Private respuesta As Decimal

    Function consultarProveedoresPantallaBusqueda() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppb")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProveedoresPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function buscarProveedoresPantallaBusqueda(Nombre) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bppb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en buscarProveedoresPantallaBusqueda() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProveedoresParaCombo() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppc")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProveedoresParaCombo() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarOrdenesPendientesCompras() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cspc")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("error en consultarOrdenesPendientesCompras() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDetalleProductosDeSolicitud(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdps")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("error en consultarDetalleProductosDeSolicitud() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarUltimoNumeroOrdenCompra() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cunoc")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = CInt(dt.Rows(0)(0).ToString()) + 1
                Else
                    res = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarUltimoNumeroOrdenCompra() " & ex.Message)
            res = 0
        End Try
        Return res
    End Function

    Function insertarOrdenMaestro(Numero As Integer, Fecha As Date, Entidad As Integer, Atencion As String, Observaciones As String,
                                  Moneda As Integer, TipoCambio As Decimal, Solicitud As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iom")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Sucursal", sucursallog)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Entidad", Entidad)
                .AddWithValue("@Atencion", Atencion)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Estatus", "G")
                .AddWithValue("@Moneda", Moneda)
                .AddWithValue("@TipoCambio", TipoCambio)
                .AddWithValue("@Solicitud", Solicitud)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarOrdenMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function modificarOrdenMaestro(Numero As Integer, Entidad As Integer, Atencion As String, Observaciones As String,
                                  Moneda As Integer, TipoCambio As Decimal) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "mom")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Sucursal", sucursallog)
                .AddWithValue("@Entidad", Entidad)
                .AddWithValue("@Atencion", Atencion)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Moneda", Moneda)
                .AddWithValue("@TipoCambio", TipoCambio)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en modificarOrdenMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function


    Function insertarOrdenDetalle(Numero As Integer, Producto As String, Descripcion As String, Cantidad As Decimal,
                                  Precio As Decimal, Solicitud As Integer, Observaciones As String) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iod")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Sucursal", sucursallog)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Cantidad", Cantidad)
                .AddWithValue("@Precio", Precio)
                .AddWithValue("@Solicitud", Solicitud)
                .AddWithValue("@Observaciones", Observaciones)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarOrdenDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function verificarCantidadPorProductoSolicitado(Producto As String, Solicitud As Integer) As Decimal
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vcps")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Producto", Producto)
                    .AddWithValue("@Numero", Solicitud)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    respuesta = CDec(dt.Rows(0)(0).ToString())
                Else
                    respuesta = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarCantidadPorProductoSolicitado() " & ex.Message)
            respuesta = 0
        End Try
        Return respuesta
    End Function

    Sub eliminarOrdenMaestro(Numero As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "eom")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en eliminarOrdenMaestro() " & ex.Message)
        End Try
    End Sub

    Function consultarOrdenesCompra() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "coc")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarOrdenesCompra() " & ex.Message)
        End Try
        Return dt
    End Function

    Function buscarOrdenesCompra(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "boc")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarOrdenesCompra() " & ex.Message)
        End Try
        Return dt
    End Function

    Function buscarOrdenesCompraPendientes() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bocp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Estatus", "G")
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en buscarOrdenesCompraPendientes() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultaOrdenCompraBuscada(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cocb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("error en consultaOrdenCompraBuscada() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultaOrdenDetalleCompraBuscada(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "codcb")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Sucursal", sucursallog)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("error en consultaOrdenDetalleCompraBuscada() " & ex.Message)
        End Try
        Return dt
    End Function

    Function eliminarOrdenDetalle(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "eod")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en eliminarOrdenDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function verificarCantidadPorProductoSolicitadoModificar(Producto As String, Solicitud As Integer, Numero As Integer) As Decimal
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vcpsm")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Producto", Producto)
                    .AddWithValue("@Numero", Solicitud)
                    .AddWithValue("@Auxiliar", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    respuesta = CDec(dt.Rows(0)(0).ToString())
                Else
                    respuesta = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarCantidadPorProductoSolicitadoModificar() " & ex.Message)
            respuesta = 0
        End Try
        Return respuesta
    End Function

    Function anularOrdenCompra(Numero As Integer, Estatus As String, Fecha As Date) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "aoc")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Sucursal", sucursallog)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Estatus", Estatus)
                .AddWithValue("@Fecha", Fecha)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en anularOrdenCompra() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarOrdenesCompraPendientesAprobar() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cocpa")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarOrdenesCompraPendientesAprobar() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDetalleOrdenesCompraPendientesAprobar(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdocpa")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Sucursal", sucursallog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDetalleOrdenesCompraPendientesAprobar() " & ex.Message)
        End Try
        Return dt
    End Function

    Function aprobarOrdenesDeCompra(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "aodc")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en aprobarOrdenesDeCompra()" + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function seleccionBodegaConsultaKardex() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "sbpck")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en seleccionBodegaConsultaKardex() " & ex.Message)
        End Try
        Return dt
    End Function

    Function confirmarExisteIngresoOrdenCompra(Numero As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ceioc")
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
            MsgBox("Error en confirmarExisteIngresoOrdenCompra() " & ex.Message)
            Return True
        End Try
        Return True
    End Function

    Function productosPendientesDeCompra() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ppc")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en productosPendientesDeCompra() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosParcialesEnSolicitud(Numero As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cpps")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Sucursal", sucursallog)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                respuesta = CDec(dt.Rows(0)(0).ToString())
                If respuesta <> 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaProductosParcialesEnSolicitud() " & ex.Message)
        End Try
        Return True
    End Function

    Function consultarFechasParametros(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cfp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Sucursal", sucursallog)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarFechasParametros() " & ex.Message)
        End Try
        Return dt
    End Function

    Function verificarProductoEnTransitoTerminar(Solicitud As Integer, Producto As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vptt")
                    .AddWithValue("@Solicitud", Solicitud)
                    .AddWithValue("@Producto", Producto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarProductoEnTransitoTerminar() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function anularProductoIngreso(Numero As Integer, Producto As String, Solicitud As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "api")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Usuario", usuariolog)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Solicitud", Solicitud)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en anularProductoIngreso() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function verificarCantidadProductoTerminar(Numero As Integer, Producto As String, Solicitud As Integer) As Decimal
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vcpt")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Solicitud", Solicitud)
                    .AddWithValue("@Producto", Producto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    respuesta = CDec(dt.Rows(0)(0).ToString())
                Else
                    respuesta = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            respuesta = 0
            MsgBox("Error en verificarCantidadProductoTerminar() " & ex.Message)
        End Try
        Return respuesta
    End Function

    Function verificarExisteProductoNoIngresado(Numero As Integer, Producto As String, Solicitud As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "vepni")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Solicitud", Solicitud)
                    .AddWithValue("@Producto", Producto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    MsgBox("Este producto ya esta terminado, en orden  de compra", MsgBoxStyle.Exclamation, "Aviso")
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en verificarExisteProductoNoIngresado() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function ejecutarPolizaPorProducto(Numero As Integer, Producto As String, Fecha As Date) As Boolean
        Try
            cmd = New SqlCommand("SP_ORDENES_COMPRA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "eprpp")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Fecha", Fecha)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano), MsgBoxStyle.Exclamation, "Aviso")
            Return False
        Catch ex As Exception
            MsgBox("Error en ejecutarPolizaPorProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class