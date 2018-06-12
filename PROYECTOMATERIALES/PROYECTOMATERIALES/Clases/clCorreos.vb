Imports System.Data
Imports System.Data.Sql
Imports System.Net.Mail
Imports System.Data.SqlClient

Public Class clCorreos
    Public mail As New MailMessage
    Public smtp As New SmtpClient
    Private vCorreo As String
    Private vContrasena As String
    Private vLista As String
    Private vAsunto As String

    Sub listadosCorreos(Modulo As String)
        Using cnx As SqlConnection = MD_ConnectionManager.GetConnection
            cmd = New SqlCommand("select * from tblConfigCorreos where Empresa=" & empresaid & " and Modulo='" & Modulo & "'", cnx)
            cmd.CommandType = CommandType.Text
            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            cmd.ExecuteNonQuery()
            da.Fill(dt)
            vCorreo = dt.Rows(0)(2).ToString()
            vContrasena = dt.Rows(0)(3).ToString()
            vLista = dt.Rows(0)(4).ToString()
            vAsunto = dt.Rows(0)(5).ToString()
            cnx.Close()
        End Using
    End Sub

    Sub enviarCorreo(Asunto As String, Mensaje As String)
        'Tipo 1 = Contabilidad y Compras
        'Tipo 2 = Compras y Jefes de Oficina
        Try
            listadosCorreos(Asunto)
            mail.From = New MailAddress(vCorreo)

            mail.To.Add(vLista)
            mail.CC.Clear()
            mail.CC.Add("erickcortez@rosbana.com")
            mail.Subject = vAsunto & " de " & Asunto
            mail.IsBodyHtml = True
            mail.Body = "Estimado(a) usuario: <br/>" & Mensaje & " ,Proceso realizado por " & usuariolog.ToUpper()
            smtp.Host = "smtp.1and1.es"
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential(vCorreo, vContrasena)
            smtp.Send(mail)
            mail.To.Clear()
        Catch ex As Exception
            MsgBox("Error en el envio de correo electronico de notificacion automatica " & ex.Message)
        End Try
    End Sub
End Class