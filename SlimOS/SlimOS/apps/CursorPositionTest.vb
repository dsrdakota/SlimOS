Public Class CursorPositionTest
    Dim key As String
    Dim btn As String
    Dim out As String

    Private Sub CursorPositionTest_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub
    Private Sub CursorPositionTest_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        key = e.KeyCode
        out = key & " - " & btn
        Me.lblBtn.Text = "Key and/or Mouse button: " & out
    End Sub

    Private Sub CursorPositionTest_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        btn = e.Button.ToString()
        out = key & " - " & btn
        Me.lblBtn.Text = "Key and/or Mouse button: " & out
    End Sub

    Private Sub CursorPositionTest_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Me.lblX.Text = "X: " & e.X
        Me.lblY.Text = "Y: " & e.Y
    End Sub

    Private Sub CursorPositionTest_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        btn = e.Button.ToString()
        out = key & " - " & btn
        Me.lblBtn.Text = "Key and/or Mouse button: " & out
    End Sub
End Class
