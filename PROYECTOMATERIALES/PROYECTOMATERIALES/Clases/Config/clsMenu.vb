Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clsMenu
    Public res As Integer
    Function consultaMenu() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CM")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consulta de menus: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function buscaMenu(Nombre As String) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "BM")
                    .AddWithValue("@Nombre", Nombre)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error en consulta de menus: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function consultaPadres() As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CP")
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando menus hijos: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function consultaMenusHijos(PadreID As Integer) As DataTable
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CH")
                    .AddWithValue("@PadreID", PadreID)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando menus hijos: " + ex.ToString())
        End Try
        Return dt
    End Function

    Function consultaHijos(PadreID As Integer) As Integer
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                da = New SqlDataAdapter(cmd)
                dt = New DataTable
                With cmd.Parameters
                    .AddWithValue("@Opcion", "CSH")
                    .AddWithValue("@PadreID", PadreID)
                End With
                cmd.ExecuteNonQuery()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    res = 1 'Tiene hijos
                Else
                    res = 0 'No tiene hijos
                End If
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error consultando menus hijos: " + ex.ToString())
        End Try
        Return res
    End Function

    Sub ingresaMenu(Nombe As String, PadreID As Integer, Formulario As String, Imagen As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "IM")
                    .AddWithValue("@Nombre", Nombe)
                    .AddWithValue("@PadreID", PadreID)
                    .AddWithValue("@FrmAbrir", Formulario)
                    .AddWithValue("@FrmImg", Imagen)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error al insertar nuevo menu: " + ex.ToString())
        End Try
    End Sub

    Sub modificaMenu(MenuID As Integer, Nombre As String, PadreID As Integer, Formulario As String, Imagen As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "MM")
                    .AddWithValue("@Nombre", Nombre)
                    .AddWithValue("@PadreID", PadreID)
                    .AddWithValue("@FrmAbrir", Formulario)
                    .AddWithValue("@FrmImg", Imagen)
                    .AddWithValue("@MenuID", MenuID)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error modificando menu: " + ex.ToString())
        End Try
    End Sub

    Sub eliminarMenu(MenuID As Integer)
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
                cmd = New SqlCommand("SP_CONFIG_MENU", cnx)
                cmd.CommandType = CommandType.StoredProcedure
                With cmd.Parameters
                    .AddWithValue("@Opcion", "EM")
                    .AddWithValue("@MenuID", MenuID)
                End With
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error eliminando menu: " + ex.ToString())
        End Try
    End Sub
End Class