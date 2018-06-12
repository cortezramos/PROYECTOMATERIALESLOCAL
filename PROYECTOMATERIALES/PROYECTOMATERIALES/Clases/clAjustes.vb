Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clAjustes
    Private respuesta As Integer
    Private res As Decimal

    Function consultarNumeroPorTipo(Tipo As Integer) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cnpt")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Tipo", Tipo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                respuesta = CInt(dt.Rows(0)(0).ToString()) + 1
                cnx.Close()
            End Using
        Catch ex As Exception
            respuesta = 0
            MsgBox("Error en consultarNumeroPorTipo() " & ex.Message)
        End Try
        Return respuesta
    End Function


    Function insertarMovimientoMaestro(Numero As Integer, Tipo As Integer, Fecha As Date, Bodega As Integer, Observaciones As String) As Boolean
        Try
            cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "imm")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Observaciones", Observaciones)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoMaestro()" + ex.Message())
            Return False
        End Try
        Return True
    End Function

    Function insertarMovimientoDetalle(Numero As Integer, Producto As String, Tipo As Integer, Descripcion As String,
                                       Cantidad As Decimal, Bodega As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "imd")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Producto", Producto)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Cantidad", Cantidad)
                .AddWithValue("@Bodega", Bodega)
                .AddWithValue("@Usuario", usuariolog)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error en insertarMovimientoDetalle()" + ex.Message())
            Return False
        End Try
        Return True
    End Function

    Function numeroPoliza() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "np")
                    .AddWithValue("@Empresa", empresaid)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                respuesta = CInt(dt.Rows(0)(0).ToString()) + 1
                cnx.Close()
            End Using
        Catch ex As Exception
            respuesta = 0
            MsgBox("Error en consultarNumeroPoliza() " & ex.Message)
        End Try
        Return respuesta
    End Function

    Function guardarPoliza(Numero As Integer, Fecha As Date, Descripcion As String, Referencia As Integer, Tipo As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "gp")
                .AddWithValue("@TipoPoliza", "IN")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Fecha", Fecha)
                .AddWithValue("@Descripcion", Descripcion)
                .AddWithValue("@Referencia", Referencia)
                .AddWithValue("@Tipo", Tipo)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en guardarPoliza() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function guardarPolizaDetalle(Numero As Integer, Cuenta As String, Centro As String, Cargo As Decimal, Abono As Decimal, Nota As String) As Boolean
        Try
            cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "gpd")
                .AddWithValue("@TipoPoliza", "IN")
                .AddWithValue("@Numero", Numero)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Cuenta", Cuenta)
                .AddWithValue("@Centro", Centro)
                .AddWithValue("@Cargo", Cargo)
                .AddWithValue("@Abono", Abono)
                .AddWithValue("@Catalogo", catalogolog)
                .AddWithValue("@Nota", Nota)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en guardarPolizaDetalle()" + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function busquedaDeAjustes(FechaI As Date, FechaF As Date, Producto As String, Tipo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ba")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@FechaI", FechaI)
                    .AddWithValue("@FechaF", FechaF)
                    .AddWithValue("@Producto", Producto)
                    .AddWithValue("@Tipo", Tipo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en busquedaDeAjustes() " & ex.Message)
        End Try
        Return dt
    End Function

    Function busquedaDeAjustesPorNumero(Numero As Integer, Tipo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bapn")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Tipo", Tipo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en busquedaDeAjustesPorNumero() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarDetalleDeAjustes(Numero As Integer, Tipo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_AJUSTES_MATERIALES_IT", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cda")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Numero", Numero)
                    .AddWithValue("@Tipo", Tipo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarDetalleDeAjustes() " & ex.Message)
        End Try
        Return dt
    End Function
End Class