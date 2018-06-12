Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class clsConfig
    Public ResizeFrm As New clsResizeForm
    'Public frmMenu As New Menu
    Sub abrirFormulario(MenuF As Form, nombreFormulario As String, alto As Double, ancho As Double, Nombre As String)
        Dim Proyecto As String
        Dim carga As Boolean = False
        Try
            Proyecto = Application.ProductName
            Dim Formulario As Form = DirectCast(Activator.CreateInstance(Type.GetType(Proyecto + "." + nombreFormulario)), Form)

            For Each FrmAbierto As Form In MenuF.MdiChildren
                If FrmAbierto.Text = Formulario.Text Then
                    carga = True
                    Exit For
                End If
            Next
            If carga = False Then
                With Formulario
                    .AutoSize = False
                    .ControlBox = False
                    .StartPosition = FormStartPosition.Manual
                    .Location = New Point(302, 2)
                    '.Height = alto - 80
                    '.Width = ancho - 350
                    .MdiParent = MenuF
                    .ShowIcon = False
                    .Text = Nombre
                    .Focus()
                    .Show()
                End With
            Else
                Formulario.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error abriendo formulario: " + ex.ToString())
        End Try
    End Sub
End Class