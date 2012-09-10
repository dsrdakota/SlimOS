Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Dim Reg_Height As Integer = 158
    Dim Exp_Height As Integer = 187

    Sub HideOpts()
        Me.Height = Reg_Height
    End Sub

    Sub ShowOpts()
        Me.Height = Exp_Height
    End Sub

    Function CheckLogin(ByVal lpU As String, ByVal lpP As String) As Boolean
        Call UpdateUserList()
        Dim _user As String = "", _pwd As String = ""
        Dim ret As Boolean
        For i = 0 To USERS.Count() - 1
            If USERS(i) = lpU Then
                _user = USERS(i)
                _pwd = PASSWORDS(i)
                Debug.Print("User: '{0}' Password: '{1}'", _user, _pwd)
                If lpP = _pwd Then
                    ret = True
                    Exit For
                Else
                    ret = False
                End If

            End If
            If i >= USERS.Count() Then
                ret = False
            End If
        Next
        'If lpU = _user And lpP = _pwd Then
        '    Return True
        'Else
        '    Return False
        'End If
        Return ret
    End Function

    Sub ShowError()
        MsgBox("Error: Invalid username and/or password.", vbCritical, "Error")
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If CheckLogin(Me.UsernameTextBox.Text, Me.PasswordTextBox.Text) = True Then
            S_USER = Me.UsernameTextBox.Text
            S_PASSWORD = Me.PasswordTextBox.Text
            If My.Computer.FileSystem.DirectoryExists(My.Settings.UsersPath & "\" & S_USER) = False Then

            End If
            Call frmMain.LoadGUI()
            frmMain.Text = "SlimOS - Logged on as '" & S_USER & "'"
            Me.Close()
        Else
            ShowError()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        frmWelcome.Show()
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Height = Reg_Height
        Me.Left = frmMain.Width / 3
        Me.Top = frmMain.Height / 3
        Me.Focus()
        Me.UsernameTextBox.Focus()
    End Sub

    Private Sub btnOptions_Click(sender As System.Object, e As System.EventArgs) Handles btnOptions.Click
        If Me.Height = Reg_Height Then
            btnOptions.Text = "Options <<<"
            ShowOpts()
        Else
            btnOptions.Text = "Options >>>"
            HideOpts()
        End If
    End Sub

    Private Sub btnShutdown_Click(sender As System.Object, e As System.EventArgs) Handles btnShutdown.Click
        If MsgBox("Shutdown the [virtual] computer?", vbYesNo Or vbInformation, "SlimOS - Shutdown") = MsgBoxResult.Yes Then
            frmMain.Text = "SlimOS - Please wait, shutting down ..."
            Threading.Thread.Sleep(3400)
            frmMain.Text = "SlimOS - Quitting ..."
            Threading.Thread.Sleep(1200)
            frmMain.Close()
        End If
    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click
        Dim f As New frmRegister
        f.ShowDialog()
        Call frmMain.SetParent(f.Handle, frmMain.Handle)
        f.Focus()
    End Sub

    Private Sub frmLogin_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.UsernameTextBox.Focus()
        Me.UsernameTextBox.BringToFront()

    End Sub
End Class
