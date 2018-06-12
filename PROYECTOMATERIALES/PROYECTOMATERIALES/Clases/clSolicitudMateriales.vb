Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clSolicitudMateriales
    Private resultado As Integer

    Function insertarSolicitudMaestro(Numero As Integer, Fecha As Date, Solicitante As Integer, Observaciones As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "ism")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Solicitante", Solicitante)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error al insertarSolicitudMaestro()" + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarSolicitudDetalle(Numero As Integer, Producto As String, Descripcion As String, Cantidad As Decimal, Observaciones As String,
                                      Fecha As Date, Solicitante As Integer, CentroCosto As String, DescrCentro As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "isd")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Cantidad", Cantidad)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@FechaD", Fecha)
                .AddWithValue("@Solicitante", Solicitante)
                .AddWithValue("@CentroCosto", CentroCosto)
                .AddWithValue("@DescrCentro", DescrCentro)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error al insertarSolicitudDetalle()" + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function eliminarSolicitudMaestro(Numero As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "esm")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en eliminarSolicitudMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function eliminarSolicitudDetalle(Numero As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "esd")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en eliminarSolicitudMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultaProductos() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cp")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaProductos() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function consultaProductosReporteria() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cpr")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaProductos() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function consultaProductosFiltrados(Descripcion As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bpf")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Descripcion", Descripcion)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaProductosFiltrados() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function ultimoNumeroSolicitud() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
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
                    resultado = CInt(dt.Rows(0)(0).ToString()) + 1
                Else
                    resultado = 1
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en ultimoNumeroSolicitud() " & ex.Message)
            dt = New DataTable
        End Try
        Return resultado
    End Function

    Function consultarInformacionCentroCosto(Cuenta As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cicc")
                    .AddWithValue("@Catalogo", empresaid)
                    .AddWithValue("@Cuenta", Cuenta)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando consultarInformacionCentroCosto() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function consultarInformacionCuentaContable(Cuenta As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "icc")
                    .AddWithValue("@Catalogo", catalogolog)
                    .AddWithValue("@Cuenta", Cuenta)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando consultarInformacionCuentaContable() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function consultarSolicitudMateriales() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "csm")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarSolicitudMateriales() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function buscarSolicitudMateriales(Observaciones As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bsm")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Observaciones", Observaciones)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en buscarSolicitudMateriales() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function consultarSolicitudMaterialesPendientes() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "csmp")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarSolicitudMateriales() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function seleccionSolicitudMaestro(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ssm")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en seleccionSolicitudMaestro() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function seleccionSolicitudDetalle(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ssd")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en seleccionSolicitudDetalle() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function cambiarEstadoSolicitudMaestro(Numero As Integer, Estatus As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "cesm")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Estatus", Estatus)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en cambiarEstadoSolicitudMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function cambiarEstadoSolicitudDetalle(Numero As Integer, Estatus As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "cesd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Estatus", Estatus)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en cambiarEstadoSolicitudDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function cambiarEstadoSolicitudDetallePorProducto(Numero As Integer, Estatus As String, Producto As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "cesdp")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Estatus", Estatus)
                .AddWithValue("@Producto", Producto)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en cambiarEstadoSolicitudDetallePorProducto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarBitacoraProductosTerminados(Numero As Integer, Fecha As Date, Producto As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "ibpt")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarBitacoraProductosTerminados() " & ex.Message)
            Return False
        End Try
        Return True
    End Function


    Function consultarSolicitudesPendientesAprobacion() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cspa")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarSolicitudesPendientesAprobacion() " & ex.Message)
            dt = New DataTable
        End Try
        Return dt
    End Function

    Function modificarDetalleEstadoPendiente(Estatus As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "mdep")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Estatus", Estatus)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en modificarDetalleEstadoPendiente() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function confirmarAprobacionDeSolicitudDetalle(Numero As Integer, Estatus As String) As Boolean
        Try
            cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "casd")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Estatus", Estatus)
                .AddWithValue("@Numero", Numero)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en confirmarAprobacionDeSolicitudDetalle() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function anulacionSolicitudDetalleConfirmada(Numero As Integer, Estatus As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "asdc")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Estatus", Estatus)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en anulacionSolicitudDetalleConfirmada() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarDetalleProductosPendientes(Numero As Integer) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand("SP_SOLICITUD_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cdpp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    resultado = 1
                Else
                    resultado = 0
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarDetalleProductosPendientes" + ex.Message)
            resultado = 1
        End Try
        Return resultado
    End Function
End Class