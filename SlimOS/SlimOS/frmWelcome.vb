Imports System.Windows.Forms

Public Class frmWelcome

    Private Sub frmWelcome_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Dim bShift, bAlt, bCtrl As Boolean
        bShift = My.Computer.Keyboard.ShiftKeyDown
        bAlt = My.Computer.Keyboard.AltKeyDown
        bCtrl = My.Computer.Keyboard.CtrlKeyDown

        If bShift = True And bAlt = True And bCtrl = False And e.KeyCode = Keys.L Then
            Me.Close()
            frmMain.Text = "SlimOS - Please logon"
            Call frmMain.LogonLoad()
        End If
    End Sub

    Private Sub frmWelcome_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = frmMain.Width / 3
        Me.Top = frmMain.Height / 3
        Me.Focus()
    End Sub
End Class
