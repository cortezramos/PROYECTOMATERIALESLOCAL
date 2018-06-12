Imports System.Data
Imports System.Data.SqlClient

Module MDvDataOperations
    ' Este módulo contiene funciones respecto a transacciones en sql

    Public pConnection As SqlConnection = Nothing
    Public pTransaction As SqlTransaction = Nothing

    Public Function BeginTransaction() As Boolean
        'Esta funcion Inicializa una transaccion SQL
        Try
            pConnection = MD_ConnectionManager.GetConnection()
            pTransaction = pConnection.BeginTransaction
        Catch ex As Exception
            MsgBox("Error en BeginTransaction()" & vbCrLf & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function CommitTransaction() As Boolean
        Try
            pTransaction.Commit()
            If pConnection IsNot Nothing Then
                pConnection.Close()
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error en CommitTransaction() " & vbCrLf & ex.Message)
            Return False
        End Try
    End Function

    Public Function RollBackTransaction() As Boolean
        Try
            pTransaction.Rollback()
            If pConnection IsNot Nothing Then
                pConnection.Close()
            End If
            Return True
        Catch ex As Exception
            MsgBox("Error en RollBackTransaction()" & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
End Module