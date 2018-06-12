Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clProveedor
    Private res As Integer
    Private respuesta As String

    Function codigoProveedor() As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cpp")
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
            res = 1
            MsgBox("Error en codigoProveedor() " & ex.Message)
        End Try
        Return res
    End Function

    Function consultaExisteNit(Nit As String) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cen")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@IdTributario", Nit)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If CInt(dt.Rows(0)(0).ToString) > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultaExisteNit() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function consultarImpuestoProveedor() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cip")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarImpuestoProveedor() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarImpuestoPorProveedor(Codigo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cipp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarImpuestoPorProveedor() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarTipoProveedor() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ctp")
                    .AddWithValue("@Catalogo", catalogolog)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarTipoProveedor() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarProveedorPorCodigo(Codigo As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "cppc")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en consultarProveedorPorCodigo() " & ex.Message)
        End Try
        Return dt
    End Function

    Function cambiarEstadoProveedor(Codigo As Integer, Estatus As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_PROVEEDORES", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "cep")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Estatus", Estatus)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en cambiarEstadoProveedor() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function modificarProveedor(Codigo As Integer, Estatus As Integer, Dias As Integer, Tipo As Integer, Limite As Decimal,
                                Contancto As String, Email As String, Telefono As String, Telefono2 As String,
                                Direccion As String, IdTributario As String, Nombre As String) As Boolean
        Try
            cmd = New SqlCommand("SP_PROVEEDORES", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "mp")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Estatus", Estatus)
                .AddWithValue("@Dias", Dias)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Limite", Limite)
                .AddWithValue("@Contacto", Contancto)
                .AddWithValue("@Email", Email)
                .AddWithValue("@Telefono", Telefono)
                .AddWithValue("@Telefono2", Telefono2)
                .AddWithValue("@Direccion", Direccion)
                .AddWithValue("@IdTributario", IdTributario)
                .AddWithValue("@Nombre", Nombre)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en modificarProveedor() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarProveedor(Codigo As Integer, Estatus As Integer, Dias As Integer, Tipo As Integer, Limite As Decimal,
                                Contacto As String, Email As String, Telefono As String, Telefono2 As String,
                                Direccion As String, IdTributario As String, Nombre As String) As Boolean
        Try
            cmd = New SqlCommand("SP_PROVEEDORES", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "ipn")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Estatus", Estatus)
                .AddWithValue("@Dias", Dias)
                .AddWithValue("@Tipo", Tipo)
                .AddWithValue("@Limite", Limite)
                .AddWithValue("@Saldo", 0)
                .AddWithValue("@Contacto", Contacto)
                .AddWithValue("@Email", Email)
                .AddWithValue("@Telefono", Telefono)
                .AddWithValue("@Telefono2", Telefono2)
                .AddWithValue("@Direccion", Direccion)
                .AddWithValue("@IdTributario", IdTributario)
                .AddWithValue("@Nombre", Nombre)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarProveedor() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function insertarImpuestoPorProveedor(Codigo As Integer, Impuesto As Integer, Descripcion As String) As Boolean
        Try
            cmd = New SqlCommand("SP_PROVEEDORES", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "iipp")
                .AddWithValue("@Codigo", Codigo)
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Impuesto", Impuesto)
                .AddWithValue("@Descripcion", Descripcion)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en insertarImpuestoPorProveedor() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function eliminarProveedorImpuesto(Codigo As Integer) As Boolean
        Try
            cmd = New SqlCommand("SP_PROVEEDORES", pConnection, pTransaction)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Opcion", "epi")
                .AddWithValue("@Empresa", empresaid)
                .AddWithValue("@Codigo", Codigo)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Dim tamano As Integer = ex.Message.IndexOf("!")
            MsgBox("Error " & vbCrLf & ex.Message.Substring(0, tamano))
            Return False
        Catch ex As Exception
            MsgBox("Error en eliminarProveedorImpuesto() " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Function busquedaProveedor(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "bp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            dt = New DataTable
            MsgBox("Error en busquedaProveedor() " & ex.Message)
        End Try
        Return dt
    End Function

    Function consultarExisteOrdenParaProveedor(Codigo As Integer) As Boolean
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_PROVEEDORES", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "ceopp")
                    .AddWithValue("@Empresa", empresaid)
                    .AddWithValue("@Codigo", Codigo)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return False
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consultarExisteOrdenParaProveedor() " & ex.Message)
            Return False
        End Try
            Return True
    End Function
End Class