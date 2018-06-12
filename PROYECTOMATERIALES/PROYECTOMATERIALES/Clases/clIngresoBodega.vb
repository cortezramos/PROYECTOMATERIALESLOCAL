Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class clIngresoBodega
    Private respuesta As Integer

    Function consultarOrdenesProductosPendientes(Producto As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "copp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Producto", Producto)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable()
            MsgBox("Error en consultarOrdenesProductosPendientes() " & ex.Message)
        End Try
        Return dt
    End Function

    Function buscarOrdenCompraPorNumero(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bocpn")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable()
            MsgBox("Error en consultarOrdenesProductosPendientes() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosPendientesIngreso(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppi")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable()
            MsgBox("Error en consultarProductosPendientesIngreso()" + ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProductosPendientesVistaPrevia(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppvp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable()
            MsgBox("Error en consultarProductosPendientesIngreso() " & ex.Message)
        End Try
        Return dt
    End Function

    Function ultimoNumeroIngreso(Numero As Integer) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable()
                With cmd.Parameters
                    .AddWithValue("@Opcion", "uni")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
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
            dt = New DataTable()
            MsgBox("Error en ultimoNumeroIngreso() " & ex.Message)
        End Try
        Return respuesta
    End Function

    Function insertarIngresoMaestro(Numero As Integer, Ingreso As Integer, Fecha As Date, Bodega As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iim")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Ingreso", Ingreso)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarIngresoMaestro() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarIngresoDetalle(Numero As Integer, Producto As String, Ingreso As Integer, Descripcion As String,
                                    Cantidad As Decimal, Solicitud As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iid")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Ingreso", Ingreso)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Cantidad", Cantidad)
                .AddWithValue("@Solicitud", Solicitud)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarIngresoDetalle()" + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function ejecutarIngresoCompra(Numero As Integer, Ingreso As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "eic")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Ingreso", Ingreso)
                .AddWithValue("@Empresa", empresaid)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error en ingreso de compra " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en ejecutarIngresoCompra()" & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarIngresoMaestroBodega(FechaI As Date, FechaF As Date, Producto As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cimb")
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
            MsgBox("Error en consultarIngresoMaestroBodega() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarIngresoMaestroPorNumero(Numero As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cimpn")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarIngresoMaestroPorNumero() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarIngresoDetalleBodega(Numero As Integer, Ingreso As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_INGRESO_BODEGA_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cidb")
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Ingreso", Ingreso)
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarIngresoDetalleBodega() " & ex.Message)
        End Try
        Return dt
    End Function
End Class