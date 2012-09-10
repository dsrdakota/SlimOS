Imports Microsoft.VisualBasic.ApplicationServices

Public Interface IProgram
    Property WindowState As SlimOS_Form.SWindowState
    Property APP_TITLE As String
    ReadOnly Property APP_PATH As String
    ReadOnly Property APP_NAME As String
    ReadOnly Property APP_VERSION As String
    ReadOnly Property WindowStyle As SlimOS_Form.SlimOS_FormStyle
    Event OnAppInit(ByVal lpTitle As String, ByVal lpPath As String)
    Event OnAppLoaded(ByVal lpAppArguments As String())
    Event OnAppUnloaded()
    Event OnAppResize(ByVal WindowState As SlimOS_Form.SWindowState)
    Sub Main()
End Interface

''' <summary>
''' Usage:
''' Dim withevents frm as new program("Title","path","v1.0")
''' </summary>
''' <remarks></remarks>
Public Class Program
    Inherits _Program
    'Dim WithEvents frm As SlimOS_Form
    'Public Property AppWindow() As SlimOS_Form
    '    Get
    '        Return frm
    '    End Get
    '    Set(value As SlimOS_Form)
    '        frm = value
    '    End Set
    'End Property
    Public Shadows Event OnAppInit(lpTitle As String, lpPath As String, lpVer As String)

    Public Shadows Event OnAppLoaded(Arguments() As String)

    Public Shadows Event OnAppResized(WindowState As SlimOS_Form.SWindowState)

    Public Shadows Event OnAppUnloaded(bCancelIt As Boolean)

    ''' <summary>
    ''' Creates a new program from the constructor's parameters.
    ''' </summary>
    ''' <param name="lpTitle">The app's title.</param>
    ''' <param name="lpPath">The app's path.</param>
    ''' <param name="lpVersion">The app's version.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal lpTitle As String, ByVal lpPath As String, ByVal lpVersion As String)
        'MyBase.New(lpTitle, lpPath, lpVersion)
        'frm = New SlimOS_Form(Me.FormStyle, lpTitle)
        'Me.APP_TITLE = lpTitle
        'MyBase.New(lpTitle, lpPath, lpVersion)
        MyBase.New(lpTitle, lpPath, lpVersion)
    End Sub

    Private Sub Program_OnAppInit(lpTitle As String, lpPath As String, lpVer As String) Handles Me.OnAppInit
        RaiseEvent OnAppInit(lpTitle, lpPath, lpVer)
    End Sub

    Private Sub Program_OnAppLoaded(Arguments() As String) Handles Me.OnAppLoaded
        RaiseEvent OnAppLoaded(Arguments)
    End Sub

    Private Sub Program_OnAppResized(WindowState As SlimOS_Form.SWindowState) Handles Me.OnAppResized
        RaiseEvent OnAppResized(WindowState)
    End Sub

    Private Sub Program_OnAppUnloaded(bCancelIt As Boolean) Handles Me.OnAppUnloaded
        RaiseEvent OnAppUnloaded(bCancelIt)
    End Sub
End Class

Public Class _Program
    Inherits SlimOS_Form

    Private ID_COUNT As Integer = 0
    Private mID As Integer
    Private mVer, mPath, mTitle As String
    Private mState As SlimOS_Form.SWindowState
    Private mStyle As SlimOS_Form.SlimOS_FormStyle

    Public ReadOnly Property APP_VER As String
        Get
            Return mVer
        End Get
    End Property

    Public ReadOnly Property APP_PATH As String
        Get
            Return mTitle
        End Get
    End Property

    Public Property APP_TITLE As String
        Get
            Return mTitle
        End Get
        Set(value As String)
            mTitle = value
        End Set
    End Property

    Public ReadOnly Property AppID As Integer
        Get
            Return mID
        End Get
    End Property

    Public Event OnAppInit(lpTitle As String, lpPath As String, lpVer As String)

    Public Event OnAppLoaded(Arguments() As String)

    Public Event OnAppResized(WindowState As SlimOS_Form.SWindowState)

    Public Event OnAppUnloaded(bCancelIt As Boolean)

    ''' <summary>
    ''' Creates a new Program
    ''' </summary>
    ''' <param name="lpTitle">App title</param>
    ''' <param name="lpPath">App path</param>
    ''' <param name="lpVersion">App version</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal lpTitle As String, ByVal lpPath As String, ByVal lpVersion As String)
        Me.mPath = lpPath
        Me.mTitle = lpTitle
        Me.mVer = lpVersion
        Me.mID = ID_COUNT
        ID_COUNT += 1
        RaiseEvent OnAppInit(lpTitle, lpPath, lpVersion)
    End Sub
    'consoleapplicationbase
    Private Sub _Program_OnLoad() Handles Me.OnLoad
        RaiseEvent OnAppLoaded(Split(Command(), " "))
    End Sub

    Private Sub _Program_OnResize(lWindowState As SlimOS_Form.SWindowState) Handles Me.OnResize
        RaiseEvent OnAppResized(Me.WindowState)
    End Sub

    Private Sub _Program_OnUnload(bCancel As Boolean) Handles Me.OnUnload
        RaiseEvent OnAppUnloaded(bCancel)
    End Sub
End Class