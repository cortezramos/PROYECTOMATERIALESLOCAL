Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FrmQuerysMenu

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand(QUERY_LIMPIEZA.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error limpiando objetos en DB")
        End Try
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand(QUERYTB1.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYTB2.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYTB3.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYTB4.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYTB5.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error creando objetos en DB")
        End Try
    End Sub

    Private Sub btnSP_Click(sender As Object, e As EventArgs) Handles btnSP.Click
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand(QUERYSP1.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYSP2.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYSP3.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYSP4.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYSP5.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error creando controladores en DB")
        End Try
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            Using cnx As SqlConnection = MD_ConnectionManager.GetConnection()
                cmd = New SqlCommand(QUERYINSERT1.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYINSERT2.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand(QUERYINSERT3.Text, cnx)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                cnx.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error creando controladores en DB")
        End Try
    End Sub
End Class