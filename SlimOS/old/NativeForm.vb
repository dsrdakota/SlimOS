Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class NativeForm
    Inherits NativeWindow
    Private Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
    Private Declare Function WindowFromDC Lib "user32.dll" (ByVal hdc As Long) As Long

    Private Const WM_ACTIVATE As Long = &H6
    Private Const WM_ACTIVATEAPP As Long = &H1C
    Private Const WM_CLEAR As Long = &H303
    Private Const WM_CLOSE As Long = &H10
    Private Const WM_COPY As Long = &H301
    Private Const WM_CUT As Long = &H300
    Private Const WM_DESTROY As Long = &H2
    Private Const WM_DISPLAYCHANGE As Long = &H7E
    Private Const WM_ENABLE As Long = &HA
    Private Const WM_HELP As Long = &H53
    Private Const WM_KEYDOWN As Long = &H100
    Private Const WM_KEYFIRST As Long = &H100
    Private Const WM_KEYLAST As Long = &H108
    Private Const WM_KEYUP As Long = &H101
    Private Const WM_KILLFOCUS As Long = &H8
    Private Const WM_MOUSEACTIVATE As Long = &H21
    Private Const WM_MOUSEHOVER As Long = &H2A1
    Private Const WM_MOUSELEAVE As Long = &H2A3
    Private Const WM_MOUSEMOVE As Long = &H200
    Private Const WM_MOVE As Long = &H3
    Private Const WM_MOVING As Long = &H216
    Private Const WM_NULL As Long = &H0
    Private Const WM_PAINT As Long = &HF&
    Private Const WM_PASTE As Long = &H302
    Private Const WM_PRINT As Long = &H317
    Private Const WM_QUIT As Long = &H12
    Private Const WM_SETFOCUS As Long = &H7
    Private Const WM_SHOWWINDOW As Long = &H18
    Private Const WM_SIZE As Long = &H5
    Private Const WM_SIZING As Long = &H214
    Private Const WM_TIMER As Long = &H113
    Private Const WM_UNDO As Long = &H304
    Private Const WM_WINDOWPOSCHANGED As Long = &H47
    Private Const WM_WINDOWPOSCHANGING As Long = &H46
    Private Const WM_CREATE As Long = &H1

    Private Const WS_BORDER As Long = &H800000
    Private Const WS_CAPTION As Long = &HC00000
    Private Const WS_ICONIC As Long = WS_MINIMIZE
    Private Const WS_MAXIMIZEBOX As Long = &H10000
    Private Const WS_MINIMIZE As Long = &H20000000
    Private Const WS_MINIMIZEBOX As Long = &H20000
    Private Const WS_OVERLAPPED As Long = &H0&
    Private Const WS_OVERLAPPEDWINDOW As Long = (WS_OVERLAPPED Or WS_CAPTION Or WS_SYSMENU Or WS_THICKFRAME Or WS_MINIMIZEBOX Or WS_MAXIMIZEBOX)
    Private Const WS_POPUP As Long = &H80000000
    Private Const WS_POPUPWINDOW As Long = (WS_POPUP Or WS_BORDER Or WS_SYSMENU)
    Private Const WS_SYSMENU As Long = &H80000
    Private Const WS_THICKFRAME As Long = &H40000
    Private Const WS_VISIBLE As Long = &H10000000

    Dim msg As New Message
    Dim dhWnd As Integer

    Public ReadOnly Property hWnd As IntPtr
        Get
            'Return msg.HWnd
            Return dhWnd
        End Get
    End Property

    'Private windowHandle As Integer

    Public Sub New()

        Dim cp As CreateParams = New CreateParams()

        ' Fill in the CreateParams details.
        cp.Caption = "Hello World!"
        cp.ClassName = "STATIC"

        ' Set the position on the form
        cp.X = 100
        cp.Y = 100
        cp.Height = 100
        cp.Width = 100

        ' Specify the form as the parent.
        cp.Parent = MyBase.Handle    'parent.Handle

        ' Create as a child of the specified parent
        cp.Style = WS_OVERLAPPEDWINDOW    'WS_CHILD Or WS_VISIBLE

        ' Create the actual window
        Me.CreateHandle(cp)
    End Sub

    Public Sub Show()
        Call ShowWindow(Me.msg.HWnd, 1)
    End Sub

    ' Listen to when the handle changes to keep the variable in sync
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub OnHandleChange()
        dhWnd = Me.Handle.ToInt32()
    End Sub

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Listen for operating system messages

        Select Case (m.Msg)
            Case WM_ACTIVATEAPP

                ' Notify the form that this message was received.
                ' Application is activated or deactivated, 
                ' based upon the WParam parameter.
                AppActivate(m.WParam.ToInt32())

            Case WM_DESTROY

            Case WM_QUIT

            Case WM_CREATE
        End Select

        MyBase.WndProc(m)
    End Sub
End Class
