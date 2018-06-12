Public Class Acceso
    Dim vclave As String = "8412421"

    Private Sub prueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TPrograma.Text = "PROYECTOMATERIALES"

        Me.TClave.Visible = False
        Me.Label4.Visible = False
        Me.BCrear.Visible = False

        ''Verifica si hay la ruta en el registro esta creada
        If My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\ROSBANA\" & Me.TPrograma.Text, True) Is Nothing Then

            If MsgBox("El regristro no esta configurado, Desea crearlo???", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'deshabilita los campos de configuracion y abilita los de crear registro
                Me.TBD.Visible = False
                Me.TServer.Visible = False
                Me.BActualiza.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False
                Me.BBorra.Visible = False

                Me.TClave.Visible = True
                Me.Label4.Visible = True
                Me.BCrear.Visible = True
            Else
                'deshabilita los campos
                Me.TBD.Visible = False
                Me.TServer.Visible = False
                Me.BActualiza.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False
                Me.BBorra.Visible = False
            End If
        Else
            ''Lee los valores del registro y los pone en los textbox
            TBD.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "BD", Nothing)
            TServer.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "SERVER", Nothing)

        End If
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
    End Sub

    Private Sub BActualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualiza.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "BD", TBD.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "SERVER", TServer.Text)
        MsgBox("la informacion fue grabada en el registro", MsgBoxStyle.Information, "Aviso")
        Me.Close()
    End Sub

    Private Sub BCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCrear.Click
        If Me.TClave.Text = vclave Then
            'crear un registro
            My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config")

            ''Agregar los valores dentro del registro
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "BD", "Ingrese Valor")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config", "SERVER", "Ingrese Valor")

            MsgBox("El registro fue creado..", MsgBoxStyle.Information, "Aviso")
            Me.Close()
        Else
            MsgBox("Clave incorrecta, intentelo de nuevo", MsgBoxStyle.Critical, "Aviso")
            Me.TClave.Focus()

        End If

    End Sub

    Private Sub BBorra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorra.Click
        If MsgBox("Desea Borrar el registro de la computadora?  no podra accesar al programa despues de esto", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.TBD.Visible = False
            Me.TServer.Visible = False
            Me.BActualiza.Visible = False
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.BCrear.Visible = False

            Me.TClave.Visible = True
            Me.Label4.Visible = True
            BElimina.Visible = True

        End If
    End Sub

    Private Sub BElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BElimina.Click
        If Me.TClave.Text = vclave Then
            ''PARA BORRAR UN REGISTRO debe hacerse en cascada
            My.Computer.Registry.CurrentUser.DeleteSubKey("SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "\Config")
            My.Computer.Registry.CurrentUser.DeleteSubKey("SOFTWARE\ROSBANA\" & Me.TPrograma.Text & "")
            MsgBox("El registro fue Eliminado..", MsgBoxStyle.Information, "Aviso")
            Me.Close()
        Else
            MsgBox("Clave incorrecta, intentelo de nuevo", MsgBoxStyle.Critical, "Aviso")
            Me.TClave.Focus()
        End If
    End Sub

    Private Sub btnSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSP.Click
        BeginTransaction()
        Dim f As New FrmQuerysMenu
        f.Show()
        CommitTransaction()
    End Sub
End Class