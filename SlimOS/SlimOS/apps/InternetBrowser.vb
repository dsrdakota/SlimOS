Imports System
Imports System.Windows.Forms
Imports libSlimOS

Public Class InternetBrowser
    Inherits SlimOS_Form
    Dim WithEvents browser As New WebBrowser
    Dim WithEvents txtURL As New ComboBox
    Dim WithEvents btnGo As New Button

    Private Sub Me_OnLoad() Handles Me.OnLoad
        Me.Controls.Add(btnGo)
        Me.Controls.Add(txtURL)
        Me.Controls.Add(browser)

        btnGo.Width = 100
        btnGo.Text = "Go"


        txtURL.Text = "http://www.google.com"
        txtURL.Top = 0
        txtURL.Left = 0
        txtURL.Width = Me.GetScaleWidth() - btnGo.Width
        btnGo.Left = txtURL.Width + btnGo.Width

        browser.Width = Me.GetScaleWidth()
        browser.Height = Me.GetScaleHeight() - txtURL.Height
        browser.Top = txtURL.Height

        browser.Navigate("http://www.google.com", False)
    End Sub

    Public Sub New(Optional ByVal lpStyle As SlimOS_FormStyle = SlimOS_FormStyle.SOSFS_NORMAL)
        MyBase.New()
        MyBase.FormStyle = lpStyle
        Me.Show()
    End Sub

    Private Sub InternetBrowser_OnResize(lWindowState As SlimOS_Form.SWindowState) Handles Me.OnResize
        'browser.Dock = DockStyle.Fill
        txtURL.Top = 0
        txtURL.Left = 0
        txtURL.Width = Me.GetScaleWidth() - btnGo.Width
        btnGo.Left = txtURL.Width + btnGo.Width

        browser.Width = Me.GetScaleWidth()
        browser.Height = Me.GetScaleHeight() - txtURL.Height
        browser.Top = txtURL.Height
    End Sub

    Private Sub browser_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles browser.DocumentCompleted

    End Sub

    Private Sub browser_LocationChanged(sender As Object, e As System.EventArgs) Handles browser.LocationChanged

    End Sub
End Class
