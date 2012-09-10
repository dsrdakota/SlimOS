Public Class frmRegister

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If AddUser(Me.txtUser.Text, Me.txtPassword.Text) = True Then
            MsgBox("Welcome " & txtUser.Text & ", you may now login.", vbInformation, "User Added")
            Me.Close()
        Else
            MsgBox("Error: User already exists or an I/O error occurred.", vbCritical, "Error")
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub frmRegister_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = frmMain.Width / 3
        Me.Top = frmMain.Height / 3
        Me.txtUser.Focus()
    End Sub
End Class
