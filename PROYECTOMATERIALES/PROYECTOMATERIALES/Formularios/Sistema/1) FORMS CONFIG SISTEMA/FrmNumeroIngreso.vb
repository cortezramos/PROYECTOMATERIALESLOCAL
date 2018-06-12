Public Class FrmNumeroIngreso
    Public Numero As Integer
    Public Total As Integer
    
    Private Sub txtIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIngreso.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtIngreso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIngreso.KeyDown
        If e.KeyValue = Keys.Enter Then
            If String.IsNullOrEmpty(txtIngreso.Text) = False Then
                If CInt(txtIngreso.Text) <= Total Then
                    Numero = CInt(txtIngreso.Text)
                    Me.DialogResult = Windows.Forms.DialogResult.Yes
                Else
                    MsgBox("No puede ser un numero mayor a los ingresos que tiene bodega", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("Ingrese el numero de ingreso a bodega", MsgBoxStyle.Exclamation, "Avisto")
            End If
        End If
    End Sub
End Class