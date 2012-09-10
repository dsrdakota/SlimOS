Imports System.Runtime.InteropServices
Imports libSlimOS

Public Class frmMain
    'Public Declare Auto Sub Sleep Lib "kernel32.dll" Alias "#1205" (ByVal dwMilliseconds As Long)
    Public Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Int32)
    Public Declare Function SleepEx Lib "kernel32.dll" (ByVal dwMilliseconds As Int32, ByVal bAlertable As Int32) As Int32

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function
    'Dim WithEvents test As SlimOS.SlimOS_Form
    Dim bRunning As Boolean = True
    Private Sub ToolStripContainer1_ContentPanel_Load(sender As System.Object, e As System.EventArgs) Handles ToolStripContainer1.ContentPanel.Load

    End Sub
    Public Sub LoadOS()
        BootSequence()
        lblLoad.Visible = True
        lblLogo.Visible = True
        BeginLoad()

    End Sub
    Public Sub LoadGUI()
        StatusStrip1.Enabled = True
        StatusStrip1.Visible = True
        lstDesktop.Visible = True
    End Sub
    Public Sub BeginScreenLoad()
        Dim scrnBegin As New frmWelcome
        scrnBegin.Show()
        Call SetParent(scrnBegin.Handle, Me.Handle)
        scrnBegin.Focus()
    End Sub
    Public Sub LogonLoad()
        Dim logon As New frmLogin
        logon.Show()
        Call SetParent(logon.Handle, Me.Handle)
        logon.Focus()
        'Application.DoEvents()
    End Sub
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'test = New SlimOS.SlimOS_Form(SlimOS_Form.SlimOS_FormStyle.SOSFS_CLOSEONLY)
        'Me.ToolStripContainer1.ContentPanel.Controls.Add(test)
        'test.Show()
        Me.Text = My.Application.Info.Title
        If bRunning = False Then
            Me.ToolStripContainer1.ContentPanel.Visible = False
            Me.ToolStripContainer1.ContentPanel.Enabled = False
            bRunning = False
            RunToolStripMenuItem.Enabled = True
            StopToolStripMenuItem.Enabled = False
            PauseToolStripMenuItem.Enabled = False
            StatusStrip1.Enabled = False
        Else
            Me.ToolStripContainer1.ContentPanel.Visible = True
            Me.ToolStripContainer1.ContentPanel.Enabled = True
            bRunning = True
            RunToolStripMenuItem.Enabled = False
            StopToolStripMenuItem.Enabled = True
            PauseToolStripMenuItem.Enabled = True
            StatusStrip1.Enabled = True
        End If
        lblLoad.Visible = False
        lblLogo.Visible = False
        StatusStrip1.Visible = False
        Me.lstDesktop.SendToBack()
        LoadOS()
    End Sub

    Private Sub mnuStrip_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuStrip.ItemClicked

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            'frm.DrawUpdate()
        Catch ex As Exception
            Debug.WriteLine("Warning: " + ex.Message)
        End Try

    End Sub

    Sub ShowVersionInfo()
        Dim ver As Version
        ver = My.Application.Info.Version

        Dim f As New SlimOS_Form()
        f.Title = "About SlimOS"
        Dim lblVer As New Label()
        lblVer.Text = "SlimOS v" & ver.Major & "." & ver.Minor & " r" & ver.Revision & " b" & ver.Build
        f.Controls.Add(lblVer)
        lblVer.Top = f.Height / 3
        lblVer.Left = f.Width / 3
        lblVer.Dock = DockStyle.Fill
        lblVer.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        lblVer.TextAlign = ContentAlignment.MiddleCenter
        f.Show()

        Me.ToolStripContainer1.ContentPanel.Controls.Add(f)
    End Sub

    Private Sub AboutSlimOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutSlimOSToolStripMenuItem.Click
        ShowVersionInfo()
    End Sub

    Private Sub PauseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PauseToolStripMenuItem.Click
        If Me.ToolStripContainer1.ContentPanel.Enabled = False Then
            Me.ToolStripContainer1.ContentPanel.Enabled = True
            RunToolStripMenuItem.Enabled = False
            StopToolStripMenuItem.Enabled = True
            PauseToolStripMenuItem.Enabled = True
            StatusStrip1.Enabled = True
            bRunning = True
        Else
            Me.ToolStripContainer1.ContentPanel.Enabled = False
            RunToolStripMenuItem.Enabled = True
            StopToolStripMenuItem.Enabled = True
            PauseToolStripMenuItem.Enabled = False
            StatusStrip1.Enabled = False
            bRunning = False
        End If
    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunToolStripMenuItem.Click
        If bRunning = False Then
            Me.ToolStripContainer1.ContentPanel.Visible = True
            Me.ToolStripContainer1.ContentPanel.Enabled = True
            bRunning = True
            RunToolStripMenuItem.Enabled = False
            StopToolStripMenuItem.Enabled = True
            PauseToolStripMenuItem.Enabled = True
            StatusStrip1.Enabled = True
        Else

        End If
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StopToolStripMenuItem.Click
        If bRunning = True Then
            Me.ToolStripContainer1.ContentPanel.Visible = False
            bRunning = False
            RunToolStripMenuItem.Enabled = True
            StopToolStripMenuItem.Enabled = False
            PauseToolStripMenuItem.Enabled = False
            StatusStrip1.Enabled = True
        Else

        End If
    End Sub
    Public Sub BusyWait(ByVal lpMS As Integer)
        Dim start = Now
        Dim i As Integer = 0
        Do While start.Millisecond < Now.Millisecond - lpMS
            i += 1
        Loop
    End Sub
    Dim _step As Integer
    Dim _count As Integer
    Dim LoadText As New List(Of String)
    Public Sub SetLoading()
        LoadText.Add("Please wait, initializing core components ...")
        LoadText.Add("Please wait, initializing system components ...")
        LoadText.Add("Loading UI logon configuration ...")
        LoadText.Add("Loading the logon UI ...")
        _step = 0
        _count = LoadText.Count

    End Sub
    Public Sub BeginLoader()
        pbLoad.Visible = True
        pbLoad.Enabled = True
        pbLoad.Maximum = _count
        pbLoad.Value = 1
        'Call Sleep(2300)
        'For i As Integer = 0 To _count - 1 Step 1
        '    lblLoad.Text = LoadText.Item(i)
        '    Debug.Print(LoadText.Item(i))
        '    pbLoad.Value = i
        '    Call Sleep(350)
        'Next
        tmrLoad.Start()
        'pbLoad.Maximum = 100
        'pbLoad.Value = 0
        'pbLoad.Style = ProgressBarStyle.Blocks

        'For i As Integer = 1 To pbLoad.Maximum Step 5
        '    lblLoad.Text = "Loading additional components ..."
        '    pbLoad.Value = i
        '    Call Sleep(350)
        'Next

        'lblLogo.Visible = False
        'lblLoad.Visible = False
        'pbLoad.Visible = False
        'pbLoad.Enabled = False

        'BeginScreenLoad()
        'Me.Text = "SlimOS - Press Shift-Alt-L to begin"
    End Sub
    Public Sub BeginLoad()
        SetLoading()
        Sleep(100)
        BeginLoader()

        'Do While _step < _count
        '    'tmrLoad.Start()
        '    lblLoad.Text = LoadText.Item(_step)
        '    My.Application.DoEvents()
        '    Threading.Thread.Sleep(300)
        '    _step += 1
        'Loop

        'tmrLoad.Stop()


    End Sub
    Private Sub tmrLoad_Tick(sender As System.Object, e As System.EventArgs) Handles tmrLoad.Tick
        If _step < _count Then
            lblLoad.Text = LoadText.Item(_step)
            tmrLoad.Stop()

            pbLoad.Value = _step + 1
            'pbLoad.PerformStep()
            _step += 1
            tmrLoad.Start()
        Else

            tmrLoad.Stop()
            pbLoad.Maximum = 100
            pbLoad.Style = ProgressBarStyle.Blocks
            pbLoad.Value = 0
            tmrLoader.Start()
        End If
    End Sub

    Private Sub ShutdowncomputerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShutdowncomputerToolStripMenuItem.Click
        If MsgBox("Shutdown the [virtual] computer?", vbYesNo Or vbInformation, "SlimOS - Shutdown") = MsgBoxResult.Yes Then
            Me.Text = "SlimOS - Please wait, shutting down ..."
            Threading.Thread.Sleep(3400)
            Me.Text = "SlimOS - Quitting ..."
            Threading.Thread.Sleep(1200)
            Me.Close()
        End If
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        If MsgBox("Are you sure you want to log off?", vbYesNo Or MsgBoxStyle.Question, "SlimOS - Log off") = MsgBoxResult.Yes Then
            lblLoad.Visible = True
            lblLogo.Visible = True
            BeginLoad()
            LogonLoad()
            Me.Text = "SlimOS - Login"
        End If
    End Sub

    Sub ShowWebBrowser()
        Dim f As New InternetBrowser(SlimOS_Form.SlimOS_FormStyle.SOSFS_NORMAL)
        f.Title = "SlimOS WebBrowser"
        Me.ToolStripContainer1.ContentPanel.Controls.Add(f)
    End Sub

    Private Sub SlimOSWebBrowserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SlimOSWebBrowserToolStripMenuItem.Click
        ShowWebBrowser()

    End Sub

    Private Sub DiagnoseMouseAndKeyboardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DiagnoseMouseAndKeyboardToolStripMenuItem.Click
        Dim k As New SlimOS_Form
        k.FormStyle = SlimOS_Form.SlimOS_FormStyle.SOSFS_CLOSEONLY
        k.Title = "Diagnose Mouse and Keyboard"
        Me.ToolStripContainer1.ContentPanel.Controls.Add(k)
        k.Controls.Add(New CursorPositionTest())
        k.Controls(0).Dock = DockStyle.Fill
    End Sub

    Private Sub lstDesktop_Enter(sender As Object, e As System.EventArgs) Handles lstDesktop.Enter
        lstDesktop.SendToBack()
        SetZIndex(Me.Controls, lstDesktop, -100)
    End Sub

    Private Sub lstDesktop_Leave(sender As System.Object, e As System.EventArgs) Handles lstDesktop.Leave
        lstDesktop.SendToBack()
        SetZIndex(Me.Controls, lstDesktop, -100)
    End Sub

    Private Sub lstDesktop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstDesktop.SelectedIndexChanged

    End Sub
    Dim h As Integer = 0
    Private Sub tmrLoader_Tick(sender As System.Object, e As System.EventArgs) Handles tmrLoader.Tick

        'For i As Integer = 0 To pbLoad.Maximum Step 5
        '    pbLoad.Value = pbLoad.Value + i
        '    Call Sleep(350)
        'Next
        If h < pbLoad.Maximum Then
            lblLoad.Text = "Loading additional components ..."
            If h + 15 > pbLoad.Maximum Then
                h += pbLoad.Maximum - h
            Else
                h += 15
            End If

            pbLoad.Value = h
            Sleep(100)
            tmrLoader.Stop()
            tmrLoader.Start()
        Else
            tmrLoader.Stop()
            lblLoad.Text = "Finished, launching the logon UI ..."
            Sleep(400)
            lblLogo.Visible = False
            lblLoad.Visible = False
            pbLoad.Visible = False
            pbLoad.Enabled = False

            BeginScreenLoad()
            Me.Text = "SlimOS - Press Shift-Alt-L to begin"
        End If
    End Sub

    Sub RunIntern(ByVal cmd As String)
        Select Case cmd.ToLower()
            Case "about"
                Call ShowVersionInfo()
            Case "ver"
                Call ShowVersionInfo()
            Case "netbrowser"
                Call ShowWebBrowser()
            Case "internet"
                Call ShowWebBrowser()
            Case "webbrowser"
                Call ShowWebBrowser()
            Case "texteditor"
                Call Reg.RunAndShell("notepad.exe", "", My.Application.Info.DirectoryPath, Me.Handle)
            Case "txtedit"
                Call Reg.RunAndShell("notepad.exe", "", My.Application.Info.DirectoryPath, Me.Handle)
            Case "edit"
                Call Reg.RunAndShell("notepad.exe", "", My.Application.Info.DirectoryPath, Me.Handle)
            Case "editor"
                Call Reg.RunAndShell("notepad.exe", "", My.Application.Info.DirectoryPath, Me.Handle)
            Case Else
                Call Reg.RunAndShell(RunBox.Text, "", My.Application.Info.DirectoryPath, Me.Handle)
        End Select

        RunBox.Text = ""
    End Sub

    Private Sub RunBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles RunBox.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            RunIntern(RunBox.Text)
        End If
    End Sub

    'Dim max As Boolean, min As Boolean
    'Dim topm As Boolean
    'Dim border As FormBorderStyle
    'Dim winstate As FormWindowState

    'Dim isFullscreen As Boolean = False
    Dim full As New EasyFullscreen(Me)

    Private Sub ToggleFullscreenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ToggleFullscreenToolStripMenuItem.Click
        'If isFullscreen Then
        '    With Me
        '        .MaximizeBox = max
        '        .MinimizeBox = min
        '        .TopMost = topm
        '        .FormBorderStyle = border
        '        .WindowState = winstate
        '    End With
        '    isFullscreen = False
        'Else
        '    With Me
        '        max = .MaximizeBox
        '        min = .MinimizeBox
        '        topm = .TopMost
        '        border = .FormBorderStyle
        '        winstate = .WindowState

        '        .MaximizeBox = False
        '        .MinimizeBox = False
        '        .TopMost = True
        '        .FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        '        .WindowState = System.Windows.Forms.FormWindowState.Maximized
        '    End With
        '    isFullscreen = True
        'End If
        full.ToggleFullscreen()
    End Sub

    Private Sub RunBox_Click(sender As System.Object, e As System.EventArgs) Handles RunBox.Click

    End Sub
End Class

'''<summary>
''' It will return current resolution parameters. 
''' It can make a form FULLSCREEN ... 
'''</summary> 
'''IPStudents.Info - Its all about creativity and ideas. 
'''Author  : Yash Bharadwaj and Chander Prakash 
'''Copyright :  Free to use.Don't remove this Sticker.
'''Usage: Just call function fullscreen with form name as parameter.
'''It can detect client resolution as width-x and height-y
'''It can maximize form as fullscreen.
'''You can make form Topmost as optional 
'''<author>Yash Bharadwaj</author>
'''<remarks></remarks>

Public Class FullscreenClass
    Public Declare Function GetWindowPlacement Lib "user32.dll" (ByVal hwnd As Int32, ByRef lpwndpl As WINDOWPLACEMENT) As Int32


    <StructLayout(LayoutKind.Sequential)> _
    Public Structure POINTAPI
        Public x As Int32
        Public y As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure WINDOWPLACEMENT
        Public Length As Int32
        Public flags As Int32
        Public showCmd As Int32
        Public ptMinPosition As POINTAPI
        Public ptMaxPosition As POINTAPI
        Public rcNormalPosition As RECT
    End Structure




    Public Declare Function SetWindowPos Lib "user32.dll" Alias "SetWindowPos" (ByVal hWnd As IntPtr, ByVal hWndIntertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean



    'You also need an alias to the API function called GetSystemMetrics, like this : 
    Private Declare Function GetSystemMetrics Lib "user32.dll" Alias "GetSystemMetrics" (ByVal Which As Integer) As Integer


    'Following this you need to declare 4 constants : 
    Private Const SM_CXSCREEN As Integer = 0
    Private Const SM_CYSCREEN As Integer = 1
    Public Shared HWND_TOP As IntPtr = IntPtr.Zero
    Public Const SWP_SHOWWINDOW As Integer = 64


    'Then 2 public properties : 

    Public ReadOnly Property ScreenX() As Integer
        Get
            Return GetSystemMetrics(SM_CXSCREEN)
        End Get
    End Property


    Public ReadOnly Property ScreenY() As Integer
        Get
            Return GetSystemMetrics(SM_CYSCREEN)
        End Get
    End Property

    Public Property WindowForm As Form

    Dim max As Boolean, min As Boolean
    Dim topm As Boolean
    Dim border As FormBorderStyle
    Dim winstate As FormWindowState
    Dim state As Boolean = False
    Dim pos As WINDOWPLACEMENT

    Public Sub ToggleFullScreen(Optional ByVal isTop As Boolean = True)
        If state Then
            With WindowForm

                .WindowState = winstate
                .FormBorderStyle = border
                .TopMost = topm
                .MaximizeBox = max
                .MinimizeBox = min

                SetWindowPos(.Handle, .Handle, pos.rcNormalPosition.Left, pos.rcNormalPosition.Top, pos.rcNormalPosition.Right, pos.rcNormalPosition.Bottom, SWP_SHOWWINDOW)
                'SetWindowPos(WindowForm.Handle, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW)
            End With
            state = False
        Else
            With WindowForm
                max = .MaximizeBox
                min = .MinimizeBox
                topm = .TopMost
                border = .FormBorderStyle
                winstate = .WindowState
                Call GetWindowPlacement(WindowForm.Handle, pos)

                WindowForm.WindowState = FormWindowState.Maximized
                WindowForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                WindowForm.TopMost = isTop

                SetWindowPos(WindowForm.Handle, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW)
            End With
            state = True
        End If


    End Sub

    Public Sub New(ByVal frm As Form)
        WindowForm = frm
    End Sub
End Class

Public Class EasyFullscreen
#Region "API"
    Public Declare Function GetSystemMetrics Lib "user32.dll" (ByVal nIndex As Int32) As Int32
    Public Declare Function SetWindowPos Lib "user32.dll" (ByVal hwnd As Int32, ByVal hWndInsertAfter As Int32, ByVal x As Int32, ByVal y As Int32, ByVal cx As Int32, ByVal cy As Int32, ByVal wFlags As Int32) As Int32

    Public Const HWND_TOP As Int32 = 0
    Public Const HWND_TOPMOST As Int32 = -1
    Public Const SM_CXSCREEN As Int32 = 0
    Public Const SM_CYSCREEN As Int32 = 1
    Public Const SWP_SHOWWINDOW As Int32 = &H40


#End Region

    Dim varScreen As Screen
    Dim intWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim intHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim intTop As Integer = 0
    Dim intLeft As Integer = 0
    Dim intX As Integer = 0
    Dim intY As Integer = 0
    Public Property WindowForm As Form
    Dim lastWidth As Integer, lastHeight As Integer, lastX As Integer, lastY As Integer, lastLeft As Integer, lastTop As Integer
    Dim isFullscreen As Boolean = False
    Dim lastState As FormWindowState
    Dim lastBorder As FormBorderStyle
    Dim topMost As Boolean

    Dim cx As Int32
    Dim cy As Int32
    Dim hwnd As Int32
    Dim lhwnd As Int32

    Sub UncoverTaskbar()
        SetWindowPos(hwnd, lhwnd, 0, 0, lastHeight, lastWidth, SWP_SHOWWINDOW)
    End Sub

    Sub CoverTaskbar()
        cx = GetSystemMetrics(SM_CXSCREEN)
        cy = GetSystemMetrics(SM_CYSCREEN)
        SetWindowPos(hwnd, HWND_TOP, 0, 0, cx, cy, SWP_SHOWWINDOW)
    End Sub

    Sub InitProps()
        hwnd = WindowForm.Handle
        lhwnd = hwnd
    End Sub

    Public Function ToggleFullscreen() As Boolean
        On Error GoTo tErr
        If isFullscreen Then
            With WindowForm
                hwnd = .Handle
                lhwnd = hwnd
                .Top = lastTop
                .Left = lastLeft
                .WindowState = lastState
                .FormBorderStyle = lastBorder
                .Width = lastWidth
                .Height = lastHeight
                .TopMost = topMost
            End With
            UncoverTaskbar()
            isFullscreen = False
        Else
            With WindowForm
                lastTop = .Top
                lastLeft = .Left
                lastWidth = .Width
                lastHeight = .Height
                lastState = .WindowState
                lastBorder = .FormBorderStyle
                topMost = .TopMost

                .Top = intTop
                .Left = intLeft
                .Width = intWidth + 40
                .Height = intHeight
                .FormBorderStyle = FormBorderStyle.None
                .TopMost = True
            End With
            CoverTaskbar()
            isFullscreen = True
        End If
        GoTo tExit

tErr:
        Return False

tExit:
        Return True
    End Function

    Public Sub New(ByVal f As Form)
        WindowForm = f
        InitProps()
    End Sub

End Class