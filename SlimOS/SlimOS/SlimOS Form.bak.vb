Public Class SlimOS_Form
    Public Enum SlimOS_FormStyle
        SOSFS_CLOSEONLY = 0
        SOSFS_MAXIMIZEONLY = 1
        SOSFS_MINIMIZEONLY = 2
        SOSFS_NORMAL = (SOSFS_CLOSEONLY Or SOSFS_MAXIMIZEONLY Or SOSFS_MINIMIZEONLY)
        SOSFS_DEFAULT = SOSFS_NORMAL
    End Enum
    Enum SWindowState
        SWS_RESTORE = 4
        SWS_MAXIMIZED = 3
        SWS_MINIMIZED = 2
        SWS_NORMAL = 1
        SWS_CLOSED = 0
    End Enum
    Protected Structure WINPOS
        Dim pX As Long
        Dim pY As Long
        Dim pWidth As Long
        Dim pHeight As Long
    End Structure
    Dim curState As SWindowState = SWindowState.SWS_NORMAL
    ReadOnly Property WindowState As SWindowState
        Get
            Return curState
        End Get
    End Property
    Dim iClose, iMax, iMin, iRestore As Char
    Dim bCancel As Boolean = False
    Shadows Event OnLoad()
    Event OnUnload(ByVal bCancel As Boolean)
    Shadows Event OnResize(ByVal lWindowState As SWindowState)
    Dim lstPOS As New WINPOS
    Dim bMAX As Boolean = True
    Dim bMIN As Boolean = True
    Dim bClose As Boolean = True
    Dim fStyle As SlimOS_FormStyle = SlimOS_FormStyle.SOSFS_DEFAULT

    Property FormStyle As SlimOS_FormStyle
        Get
            Return fStyle
        End Get
        Set(value As SlimOS_FormStyle)
            fStyle = value
            Select Case fStyle
                Case SlimOS_FormStyle.SOSFS_MAXIMIZEONLY
                    bMAX = True
                    bMIN = False
                    bClose = False

                Case SlimOS_FormStyle.SOSFS_MINIMIZEONLY
                    bMAX = False
                    bMIN = True
                    bClose = False

                Case SlimOS_FormStyle.SOSFS_NORMAL
                    bMAX = True
                    bMIN = True
                    bClose = True

                Case SlimOS_FormStyle.SOSFS_CLOSEONLY
                    bMAX = False
                    bMIN = False
                    bClose = True

            End Select
            btnMax.Enabled = bMAX
            btnMin.Enabled = bMIN
            btnClose.Enabled = bClose
        End Set
    End Property

    Private Sub SlimOS_Form_ControlAdded(sender As Object, e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        If e.Control.Parent.Name = Me.Name Then
            Try
                Me.MainContent.Controls.Add(e.Control)
                Me.Controls.Remove(e.Control)
            Catch ex As Exception
                Debug.Print("An exception occurred, details: " & vbNewLine & ex.Message & vbNewLine &
                            "Source: " & ex.Source & vbNewLine &
                            "Data: " & ex.Data.ToString() & ".")
            Finally
                Debug.Print("Control readded to content panel")
            End Try

        End If
    End Sub
    Private Sub SlimOS_Form_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub SlimOS_Form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RaiseEvent OnLoad()
        curState = SWindowState.SWS_NORMAL
        RaiseEvent OnResize(Me.curState)
        iClose = My.Settings.CloseStr
        iMax = My.Settings.MaxStr
        iMin = My.Settings.MinStr
        iRestore = My.Settings.ResStr
        btnMax.Enabled = bMAX
        btnMin.Enabled = bMIN
        btnClose.Enabled = bClose
        If Not Me.curState = SWindowState.SWS_MAXIMIZED Then
            With lstPOS
                .pX = Me.Left
                .pY = Me.Top
                '.pWidth = Me.Size.Width
                '.pHeight = Me.Size.Height
                .pWidth = Me.Width
                .pHeight = Me.Height
            End With
            Debug.Print(".Width: " & Me.Width)
            Debug.Print(".Height: " & Me.Height)
            Debug.Print(".Size.Width: " & Me.Size.Width)
            Debug.Print(".Size.Height: " & Me.Size.Height)

        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        RaiseEvent OnUnload(bCancel)
        Me.curState = SWindowState.SWS_CLOSED
        RaiseEvent OnResize(Me.curState)
        Me.Hide()

    End Sub

    Private Sub btnMax_Click(sender As System.Object, e As System.EventArgs) Handles btnMax.Click
        'If Button1.Text = iMax Then 'Max window
        'btnMax.Enabled = False

        If btnMax.Text = "?" Then 'Max window
            Me.curState = SWindowState.SWS_MAXIMIZED
            RaiseEvent OnResize(Me.curState)
            'Button1.Text = iRestore
            btnMax.Text = "?"
            'MsgBox("?")
            Call DoMax()
        Else 'Restore window
            Me.curState = SWindowState.SWS_RESTORE
            RaiseEvent OnResize(Me.curState)
            'Button1.Text = iMax
            btnMax.Text = "?"
            Call DoRestore()
        End If

    End Sub

    Private Sub btnMin_Click(sender As System.Object, e As System.EventArgs) Handles btnMin.Click
        bCancel = True
        Me.curState = SWindowState.SWS_MINIMIZED
        Me.Hide()
        RaiseEvent OnResize(Me.curState)
    End Sub
    Dim pos As Point
    Dim bIsIn = False

    Private Sub RectangleShape1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles RectangleShape1.MouseDown
        pos = Me.PointToScreen(New Point(e.X, e.Y))
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bIsIn = True
        Else
            bIsIn = False
        End If
    End Sub
    Private Sub RectangleShape1_MouseLeave(sender As Object, e As System.EventArgs) Handles RectangleShape1.MouseLeave
        If bIsIn = True Then
            If pos.Y - 66 - 2 > 0 Then
                Me.Top = pos.Y - 66
            End If
            'OLD: But reuse in case: Me.Left = pos.X - 33
            If pos.X - 33 - 2 > 0 Then
                Me.Left = pos.X - 33
            End If
        Else

        End If
    End Sub

    Private Sub RectangleShape1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles RectangleShape1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bIsIn = True

            pos = Me.PointToScreen(New Point(e.X, e.Y))
            If pos.Y - 66 - 2 > 0 Then
                Me.Top = pos.Y - 66
            End If
            'OLD: But reuse in case: Me.Left = pos.X - 33
            If pos.X - 33 - 2 > 0 Then
                Me.Left = pos.X - 33
            End If
            'pos.X = e.X
            'Debug.Assert(IsNothing(Me.Parent))
            'Debug.Assert(IsNothing(Me.ParentForm))
        Else
            bIsIn = False
        End If
    End Sub
    Private Sub SlimOS_Form_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        If bIsIn = True Then
            If pos.Y - 66 - 2 > 0 Then
                Me.Top = pos.Y - 66
            End If
            'OLD: But reuse in case: Me.Left = pos.X - 33
            If pos.X - 33 - 12 > 0 Then
                Me.Left = pos.X - 33
            End If
        Else

        End If
    End Sub

    Private Sub RectangleShape1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles RectangleShape1.MouseUp
        pos = Me.PointToScreen(New Point(e.X, e.Y))
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bIsIn = False
        Else

        End If
    End Sub

    Private Sub SlimOS_Form_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        RaiseEvent OnResize(Me.curState)
        If Me.curState = SWindowState.SWS_CLOSED Then
            Exit Sub
        End If
        If Me.curState = SWindowState.SWS_MINIMIZED Then
            Exit Sub
        End If
        If Not Me.curState = SWindowState.SWS_MAXIMIZED Then
            With lstPOS
                .pX = Me.Location.X
                .pY = Me.Location.Y
                '.pWidth = Me.Size.Width
                '.pHeight = Me.Size.Height
                .pWidth = Me.Width
                .pHeight = Me.Height
            End With
            Debug.Print(".Width: " & Me.Width)
            Debug.Print(".Height: " & Me.Height)
            Debug.Print(".Size.Width: " & Me.Size.Width)
            Debug.Print(".Size.Height: " & Me.Size.Height)

        End If
        Me.lnTitlebar.Y1 = 33
        Me.lnTitlebar.Y2 = 33
        Me.lnTitlebar.X1 = 1
        Me.lnTitlebar.X2 = Me.Width
        Me.RectangleShape1.Left = 32
        Me.RectangleShape1.Top = -1
        Me.RectangleShape1.Width = Me.Width - 136

        'If Not Me.curState = SWindowState.SWS_MINIMIZED Then
        'Me.lnTitlebar.Y1 = 33
        'Me.lnTitlebar.Y2 = 33
        'Me.lnTitlebar.X1 = 0
        'Me.lnTitlebar.X2 = Me.Parent.Size.Width
        'End If
        iClose = My.Settings.CloseStr
        iMax = My.Settings.MaxStr
        iMin = My.Settings.MinStr
        iRestore = My.Settings.ResStr
        btnMax.Enabled = bMAX
        btnMin.Enabled = bMIN
        btnClose.Enabled = bClose
        'Button1.Enabled = False
    End Sub
    Public Shadows Sub Show()
        Me.Visible = True
    End Sub
    Public Shadows Sub Hide()
        Me.Visible = False
    End Sub
    Public Overloads Sub SetParent(ByVal lpForm As Form)
        Me.Parent = lpForm
    End Sub
    Public Overloads Sub SetParent(ByVal lpControl As Control)
        Me.Parent = lpControl
    End Sub
    Public Overloads Sub GetParent(ByVal lpForm As Form)
        lpForm = Me.Parent
    End Sub
    Public Overloads Sub GetParent(ByVal lpControl As Control)
        lpControl = Me.Parent
    End Sub
    Sub DoMax()

        'Me.Height = Me.Parent.Height
        'Me.Width = Me.Parent.Width
        Dim loc As New Point(0, 0)
        Me.Location = loc
        Me.Dock = DockStyle.Fill
        Me.lnTitlebar.Y1 = 33
        Me.lnTitlebar.Y2 = 33
        Me.lnTitlebar.X1 = 1
        Me.lnTitlebar.X2 = Me.Width
        Me.RectangleShape1.Left = 32
        Me.RectangleShape1.Top = -1
        Me.RectangleShape1.Width = Me.Width - 136
    End Sub
    Sub DoRestore()
        'Me.Width = lstPOS.pWidth
        'Me.Height = lstPOS.pHeight

        Dim loc As New Point(lstPOS.pX, lstPOS.pY)
        Me.Location = loc
        Me.Dock = DockStyle.None
        Me.lnTitlebar.Y1 = 33
        Me.lnTitlebar.Y2 = 33
        Me.lnTitlebar.X1 = 1
        Me.lnTitlebar.X2 = Me.Width
        Me.RectangleShape1.Left = 32
        Me.RectangleShape1.Top = -1
        Me.RectangleShape1.Width = Me.Width - 136
    End Sub
    Sub DoMin()
        'Me.Hide()
        Me.Height = Me.RectangleShape1.Height
        Me.lnTitlebar.Y1 = 33
        Me.lnTitlebar.Y2 = 33
        Me.lnTitlebar.X1 = 1
        Me.lnTitlebar.X2 = Me.Width
        Me.RectangleShape1.Left = 32
        Me.RectangleShape1.Top = -1
        Me.RectangleShape1.Width = Me.Width - 136
    End Sub
    Public Sub DrawUpdate()
        If Me.curState = SWindowState.SWS_MAXIMIZED Then
            DoMax()
        ElseIf Me.curState = SWindowState.SWS_MINIMIZED Then
            DoMin()
        ElseIf Me.curState = SWindowState.SWS_RESTORE Then
            DoRestore()

        End If
    End Sub
    Public Property IsMaxEnabled As Boolean
        Get
            Return bMAX
        End Get
        Set(value As Boolean)
            bMAX = value
            If bMAX = False Then
                btnMax.Text = "?"
                btnMax.Enabled = False
            End If
        End Set
    End Property

    Public Sub New(ByVal lpStyle As SlimOS_FormStyle)
        Select Case lpStyle
            Case SlimOS_FormStyle.SOSFS_MAXIMIZEONLY
                bMAX = True
                bMIN = False
                bClose = False

            Case SlimOS_FormStyle.SOSFS_MINIMIZEONLY
                bMAX = False
                bMIN = True
                bClose = False

            Case SlimOS_FormStyle.SOSFS_NORMAL
                bMAX = True
                bMIN = True
                bClose = True

            Case SlimOS_FormStyle.SOSFS_CLOSEONLY
                bMAX = False
                bMIN = False
                bClose = True

        End Select
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        btnMax.Enabled = bMAX
        btnMin.Enabled = bMIN
        btnClose.Enabled = bClose
        Me.FormStyle = lpStyle
        btnMax.Enabled = bMAX
        btnMin.Enabled = bMIN
        btnClose.Enabled = bClose

    End Sub
End Class
