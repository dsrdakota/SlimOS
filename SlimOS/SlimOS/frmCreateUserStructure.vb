Imports System.Windows.Forms
Imports System.Text

Public Class frmCreateUserStructure
    Dim str As New StringBuilder
    Dim curStep As Integer = 0
    Dim maxStep As Integer = 2
    Dim steps As String() = {
        "Click Next to begin.",
        "Click Next to finalize.",
        "Click Finish to exit the wizard."
    }
    Dim msgs As String() = {
        "The wizard has successfully created your personal folders.",
        "The wizard was unable to create your personal folders.",
        "You have clicked Cancel, the wizard didn't finish setting up. To rerun the wizard, reboot SlimOS."
    }
    Sub AddTexts()
        With str
            .AppendLine("This wizard will help create the necessary steps to setup your user account for the first time.")
            .AppendLine("Please wait, the wizard is creating your folders ...")
            .AppendLine("The wizard has finished.")
        End With
    End Sub
    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
    '    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    'Me.Close()
    'End Sub

    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    'Me.Close()
    'End Sub

    Private Sub frmCreateUserStructure_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddTexts()
        Me.lblTop.Text = steps.GetValue(0)

    End Sub

    Private Sub btnNextFinish_Click(sender As System.Object, e As System.EventArgs) Handles btnNextFinish.Click
        If curStep <= maxStep Then

        End If
    End Sub
End Class
