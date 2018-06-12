Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Friend NotInheritable Class MD_ConnectionManager
    Public Shared Function GetConnection() As SqlConnection
        Dim connectionString As String = Conexion
        Dim connection As New SqlConnection(connectionString)
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()
        Catch ex As Exception
            MessageBox.Show("Error en conexion: " + ex.ToString())
        End Try
        Return connection
    End Function

  End Class
