Public Class Login
    Public usuarios As New clsUsuarios
    Public empresas As New clsEmpresas
    Public fincas As New clsFincas
    Private clconfigreports As New clConfigReportServer

    Public Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vPrograma As String = "PROYECTOMATERIALES"
        Text = "INICIO - " & vPrograma & " - V." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        ''Verifica si hay la ruta en el registro esta creada
        If My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\ROSBANA\" & vPrograma, True) Is Nothing Then
            MsgBox("No esta configurado el acceso a la base de datos", MsgBoxStyle.Information, "Aviso")
        Else
            ''Lee los valores del registro y los pone en los textbox
            vBaseDatos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & vPrograma & "\Config", "BD", Nothing)
            vServer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ROSBANA\" & vPrograma & "\Config", "SERVER", Nothing)
            Conexion = "Data Source = " & vServer & "; Initial Catalog = " & vBaseDatos & "; Integrated Security = True"

            If vServer = "ERICKCORTEZ-PC" Then
                txtUsuario.Text = "admin"
                txtContra.Text = "adminit"
            End If

        End If
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim menuUsuarios As New Menu
        If txtUsuario.Text <> "" Then
            If txtContra.Text <> "" Then
                If cmbEmpresa.SelectedValue > 0 Then
                    If usuarios.login(txtUsuario.Text, txtContra.Text) Then
                        empresa = cmbEmpresa.Text
                        empresaid = cmbEmpresa.SelectedValue
                        clconfigreports.consultarReportServer()
                        With menuUsuarios
                            .Text = "USUARIO: " + txtUsuario.Text + " EMPRESA: " + empresa
                            If .dibujaMenu(txtUsuario.Text, txtContra.Text) Then
                                .Show()
                            Else
                                MsgBox("No cuenta con permiso, para esta empresa")
                                Exit Sub
                            End If
                        End With
                        Me.Close()
                    Else
                        MsgBox("Usuario no existe o no tiene acceso a esta aplicacion")
                    End If
                Else
                    MsgBox("Seleccione empresa")
                    cmbEmpresa.Focus()
                End If
            Else
                MsgBox("Ingrese contraseña")
                txtContra.Focus()
            End If
        Else
            MsgBox("Ingrese nombre de usuario")
            txtUsuario.Focus()
        End If
    End Sub

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs) Handles btnConfigurar.Click
        Dim f As New Acceso
        f.Show()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim menuUsuarios As New Menu
            If txtUsuario.Text <> "" Then
                If txtContra.Text <> "" Then
                    If cmbEmpresa.SelectedValue > 0 Then
                        If usuarios.login(txtUsuario.Text, txtContra.Text) Then
                            empresa = cmbEmpresa.Text
                            empresaid = cmbEmpresa.SelectedValue
                            clconfigreports.consultarReportServer()
                            With menuUsuarios
                                .Text = "USUARIO: " + txtUsuario.Text + " EMPRESA: " + empresa
                                If .dibujaMenu(txtUsuario.Text, txtContra.Text) Then
                                    .Show()
                                Else
                                    MsgBox("No cuenta con permiso, para esta empresa")
                                    Exit Sub
                                End If
                            End With
                            Me.Close()
                        Else
                            MsgBox("Usuario no existe o no tiene acceso a esta aplicacion")
                        End If
                    Else
                        MsgBox("Seleccione empresa")
                        cmbEmpresa.Focus()
                    End If
                Else
                    MsgBox("Ingrese contraseña")
                    txtContra.Focus()
                End If
            Else
                MsgBox("Ingrese nombre de usuario")
                txtUsuario.Focus()
            End If
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim menuUsuarios As New Menu
            If txtUsuario.Text <> "" Then
                If txtContra.Text <> "" Then
                    If cmbEmpresa.SelectedValue > 0 Then
                        If usuarios.login(txtUsuario.Text, txtContra.Text) Then
                            empresa = cmbEmpresa.Text
                            empresaid = cmbEmpresa.SelectedValue
                            clconfigreports.consultarReportServer()
                            With menuUsuarios
                                .Text = "USUARIO: " + txtUsuario.Text + " EMPRESA: " + empresa
                                If .dibujaMenu(txtUsuario.Text, txtContra.Text) Then
                                    .Show()
                                Else
                                    MsgBox("No cuenta con permiso, para esta empresa")
                                    Exit Sub
                                End If
                            End With
                            Me.Close()
                        Else
                            MsgBox("Usuario no existe o no tiene acceso a esta aplicacion")
                        End If
                    Else
                        MsgBox("Seleccione empresa")
                        cmbEmpresa.Focus()
                    End If
                Else
                    MsgBox("Ingrese contraseña")
                    txtContra.Focus()
                End If
            Else
                MsgBox("Ingrese nombre de usuario")
                txtUsuario.Focus()
            End If
        End If
    End Sub

    Private Sub txtContra_TextChanged(sender As Object, e As EventArgs) Handles txtContra.TextChanged
        If usuarios.login(txtUsuario.Text, txtContra.Text) Then
            If tipousuariolog <> 1 Then
                cmbEmpresa.Enabled = False
                With cmbEmpresa
                    .DataSource = empresas.consultaEmpresasCombo()
                    .ValueMember = "EmpresaID"
                    .DisplayMember = "Empresa"
                    .SelectedValue = empresaid
                End With
            Else
                cmbEmpresa.Enabled = True
                With cmbEmpresa
                    .DataSource = empresas.consultaEmpresasCombo()
                    .ValueMember = "EmpresaID"
                    .DisplayMember = "Empresa"
                End With
            End If
        End If
    End Sub

    Private Sub cmbEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEmpresa.KeyDown
        If e.KeyValue = Keys.Enter Then
            Dim menuUsuarios As New Menu
            If txtUsuario.Text <> "" Then
                If txtContra.Text <> "" Then
                    If cmbEmpresa.SelectedValue > 0 Then
                        If usuarios.login(txtUsuario.Text, txtContra.Text) Then
                            empresa = cmbEmpresa.Text
                            empresaid = cmbEmpresa.SelectedValue
                            clconfigreports.consultarReportServer()
                            With menuUsuarios
                                .Text = "USUARIO: " + txtUsuario.Text + " EMPRESA: " + empresa
                                If .dibujaMenu(txtUsuario.Text, txtContra.Text) Then
                                    .Show()
                                Else
                                    MsgBox("No cuenta con permiso, para esta empresa")
                                    Exit Sub
                                End If
                            End With
                            Me.Close()
                        Else
                            MsgBox("Usuario no existe o no tiene acceso a esta aplicacion")
                        End If
                    Else
                        MsgBox("Seleccione empresa")
                        cmbEmpresa.Focus()
                    End If
                Else
                    MsgBox("Ingrese contraseña")
                    txtContra.Focus()
                End If
            Else
                MsgBox("Ingrese nombre de usuario")
                txtUsuario.Focus()
            End If
        End If
    End Sub
End Class