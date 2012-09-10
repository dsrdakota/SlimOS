Imports System
Imports Ionic
Imports SlimOS
Imports Microsoft
Imports Microsoft.Win32
Imports Microsoft.Win32.SafeHandles
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports libSlimOS
Imports System.Xml

'Public Interface IProgram
'    Property WindowState As SlimOS_Form.SWindowState
'    Property APP_TITLE As String
'    ReadOnly Property APP_PATH As String
'    ReadOnly Property APP_NAME As String
'    ReadOnly Property APP_VERSION As String
'    ReadOnly Property WindowStyle As SlimOS_Form.SlimOS_FormStyle
'    Event OnAppInit(ByVal lpTitle As String, ByVal lpPath As String)
'    Event OnAppLoaded(ByVal lpAppArguments As String())
'    Event OnAppUnloaded()
'    Event OnAppResize(ByVal WindowState As SlimOS_Form.SWindowState)
'    Sub Main()
'End Interface

' ''' <summary>
' ''' Usage:
' ''' Dim withevents frm as new program("Title","path","v1.0")
' ''' </summary>
' ''' <remarks></remarks>
'Public Class Program
'    Inherits _Program
'    'Dim WithEvents frm As SlimOS_Form
'    'Public Property AppWindow() As SlimOS_Form
'    '    Get
'    '        Return frm
'    '    End Get
'    '    Set(value As SlimOS_Form)
'    '        frm = value
'    '    End Set
'    'End Property
'    Public Shadows Event OnAppInit(lpTitle As String, lpPath As String, lpVer As String)

'    Public Shadows Event OnAppLoaded(Arguments() As String)

'    Public Shadows Event OnAppResized(WindowState As SlimOS_Form.SWindowState)

'    Public Shadows Event OnAppUnloaded(bCancelIt As Boolean)

'    Public Sub New(ByVal lpTitle As String, ByVal lpPath As String, ByVal lpVersion As String)
'        'MyBase.New(lpTitle, lpPath, lpVersion)
'        'frm = New SlimOS_Form(Me.FormStyle, lpTitle)
'        'Me.APP_TITLE = lpTitle
'        MyBase.New(lpTitle, lpPath, lpVersion)

'    End Sub

'    Private Sub Program_OnAppInit(lpTitle As String, lpPath As String, lpVer As String) Handles Me.OnAppInit
'        RaiseEvent OnAppInit(lpTitle, lpPath, lpVer)
'    End Sub

'    Private Sub Program_OnAppLoaded(Arguments() As String) Handles Me.OnAppLoaded
'        RaiseEvent OnAppLoaded(Arguments)
'    End Sub

'    Private Sub Program_OnAppResized(WindowState As SlimOS_Form.SWindowState) Handles Me.OnAppResized
'        RaiseEvent OnAppResized(WindowState)
'    End Sub

'    Private Sub Program_OnAppUnloaded(bCancelIt As Boolean) Handles Me.OnAppUnloaded
'        RaiseEvent OnAppUnloaded(bCancelIt)
'    End Sub
'End Class
'Public Class _Program
'    Inherits SlimOS_Form

'    Private mID As Integer
'    Private mVer, mPath, mTitle As String
'    Private mState As SlimOS_Form.SWindowState
'    Private mStyle As SlimOS_Form.SlimOS_FormStyle

'    Public ReadOnly Property APP_VER As String
'        Get
'            Return mVer
'        End Get
'    End Property

'    Public ReadOnly Property APP_PATH As String
'        Get
'            Return mTitle
'        End Get
'    End Property

'    Public Property APP_TITLE As String
'        Get
'            Return mTitle
'        End Get
'        Set(value As String)
'            mTitle = value
'        End Set
'    End Property

'    Public ReadOnly Property AppID As Integer
'        Get
'            Return mID
'        End Get
'    End Property

'    Public Event OnAppInit(lpTitle As String, lpPath As String, lpVer As String)

'    Public Event OnAppLoaded(Arguments() As String)

'    Public Event OnAppResized(WindowState As SlimOS_Form.SWindowState)

'    Public Event OnAppUnloaded(bCancelIt As Boolean)

'    Public Sub New(ByVal lpTitle As String, ByVal lpPath As String, ByVal lpVersion As String)
'        Me.mPath = lpPath
'        Me.mTitle = lpTitle
'        Me.mVer = lpVersion
'        Me.mID = ID_COUNT
'        ID_COUNT += 1
'        RaiseEvent OnAppInit(lpTitle, lpPath, lpVersion)
'    End Sub

'    Private Sub _Program_OnLoad() Handles Me.OnLoad
'        RaiseEvent OnAppLoaded(My.Application.CommandLineArgs.ToArray())
'    End Sub

'    Private Sub _Program_OnResize(lWindowState As SlimOS_Form.SWindowState) Handles Me.OnResize
'        RaiseEvent OnAppResized(Me.WindowState)
'    End Sub

'    Private Sub _Program_OnUnload(bCancel As Boolean) Handles Me.OnUnload
'        RaiseEvent OnAppUnloaded(bCancel)
'    End Sub
'End Class
'Public Sub OnAppInit(lpTitle As String, lpPath As String) Implements modRegistry.IProgram.OnAppInit

'End Sub

'Public Sub OnAppLoaded(lpAppArguments() As String) Implements modRegistry.IProgram.OnAppLoaded

'End Sub

'Public Sub OnAppResize(WindowState As SlimOS_Form.SWindowState) Implements modRegistry.IProgram.OnAppResize

'End Sub

'Public Sub OnAppUnloaded() Implements modRegistry.IProgram.OnAppUnloaded

'End Sub
Public Class Registry
    Private m_Programs As New List(Of Program)
    Public Property Programs As List(Of Program)
        Get
            Return m_Programs
        End Get
        Set(value As List(Of Program))
            m_Programs = value
        End Set
    End Property
    Public Function AddApp(ByVal App As Program) As Boolean
        Me.Programs.Add(App)
        If MyClass.Programs.Contains(App) = True Then
            Debug.Print("App successfully added to the programs list.")
            Return True
        Else
            Debug.Print("App unsuccessfully added to the programs list.")
            Return False
        End If
    End Function
    Private Function GetPriorityClass(ByVal proc As Process) As String

        Select Case proc.PriorityClass
            Case ProcessPriorityClass.AboveNormal
                Return "Above Normal"

            Case ProcessPriorityClass.BelowNormal
                Return "Below Normal"

            Case ProcessPriorityClass.High
                Return "High"

            Case ProcessPriorityClass.Idle
                Return "Idle"

            Case ProcessPriorityClass.Normal
                Return "Normal"

            Case ProcessPriorityClass.RealTime
                Return "Real Time"

            Case Else
                Return "Error"
        End Select
    End Function
    Public Function RunAndShell(ByVal lpPath As String, Optional ByVal lpArgs As String = "", Optional ByVal lpWorkDir As String = "", Optional ByVal lpParent As IntPtr = Nothing) As Boolean
        If lpWorkDir = "" Then
            lpWorkDir = CurDir()
        End If
        If IsNothing(lpParent) Then
            lpParent = frmMain.Handle
        End If
        'Dim hwnd As Int32
        'hwnd = ShellExecute(0, "open", lpPath, "", CurDir, SW_NORMAL)
        'Debug.Print("Result: {0}", SetParent(hwnd, frmMain.Handle.ToInt32))
        Dim ch As IntPtr
        Dim res As IntPtr
        Dim proc As New Process
        With proc.StartInfo
            .Arguments = lpArgs
            .ErrorDialog = False
            .FileName = lpPath
            .WindowStyle = ProcessWindowStyle.Normal
            .WorkingDirectory = lpWorkDir
        End With
        proc.Start()

        Dim exec As Boolean = False
        Threading.Thread.Sleep(3000)
        If exec = False Then
            ch = proc.MainWindowHandle
            res = SetParent(ch, lpParent)
            Debug.Print("MainWindowHandle={0}\nHandle={1}\nTitle={2}", proc.MainWindowHandle, proc.Handle, proc.MainWindowTitle)
            exec = True
        End If
        'While proc.HasExited = False
        '    Debug.Print("Priority: {0}", GetPriorityClass(proc))
        '    Threading.Thread.Sleep(1000)
        'End While
        Debug.Print("Priority: {0}", GetPriorityClass(proc))
        Debug.Print("Child Handle: {0}\nResult Handle: {1}", ch, res)
        'Return True
        Return ch = res
    End Function

    Public Sub UpdateApps()
        Dim path As String = ""
        path = My.Application.Info.DirectoryPath & "\programs"
        Dim folder As DirectoryInfo
        folder = New DirectoryInfo(path)
        path = folder.FullName
        Dim lst As New List(Of String)
        lst = GetFilesRecursive(path, "*.dll")
        For Each s As String In lst
            Dim asm As Assembly = Assembly.LoadFrom(path)
            'Dim myType As System.Type = asm.GetType(asm.GetName.Name + ".Plugin")
            Dim myType As System.Type = asm.GetType(asm.GetName.Name + ".Plugin") '.Plugin is the implemented Class's name
            Dim implementsIPlugin As Boolean = GetType(IProgram).IsAssignableFrom(myType)
            If implementsIPlugin Then
                Debug.WriteLine(asm.GetName.Name + " is a valid plugin!")

                Dim plugin As IProgram = CType(Activator.CreateInstance(myType), IProgram)
                Debug.WriteLine("{0}: {1}", plugin.APP_NAME, plugin.APP_VERSION)
                plugin.Main()
                If AddApp(New Program(plugin.APP_TITLE, plugin.APP_PATH, plugin.APP_VERSION)) Then
                    Debug.WriteLine("New app added to the Registry.")
                Else
                    Debug.WriteLine("Unable to add app to the Registry.")
                End If
            Else
                Debug.Print("Warning: Not a plugin.")
            End If
        Next s
    End Sub
End Class
Public Module modRegistry

    Public ID_COUNT As Integer = 0
#Region "WINDOWS API CALLS"
    Public Declare Function SysAllocString Lib "oleaut32.dll" (ByRef pOlechar As Byte) As String
    Public Declare Sub SysAllocStringByteLen Lib "oleaut32.dll" (ByVal m_pBase As String, ByRef FunctionCall As Int32)
    Public Declare Function SysAllocStringLen Lib "oleaut32.dll" (ByRef pOlechar As Byte, ByVal uint As Int32) As String
    Public Declare Sub SysFreeString Lib "oleaut32.dll" (ByVal bstr As String)
    Public Declare Function SysReAllocString Lib "oleaut32.dll" (ByVal pBstr As Int32, ByRef pOlechar As Byte) As Int32
    Public Declare Function SysReAllocStringLen Lib "oleaut32.dll" (ByVal pBstr As Int32, ByRef pOlechar As Byte, ByVal uint As Int32) As Int32
    Public Declare Function SysStringByteLen Lib "oleaut32.dll" (ByRef bstr As String) As Int32
    Public Declare Function SysStringLen Lib "oleaut32.dll" (ByRef bstr As String) As Int32
    Public Declare Function TransmitFile Lib "mswsock.dll" (ByVal hSocket As Int32, ByVal hFile As Int32, ByVal nNumberOfBytesToWrite As Int32, ByVal nNumberOfBytesPerSend As Int32, ByRef lpOverlapped As OVERLAPPED, ByRef lpTransmitBuffers As TRANSMIT_FILE_BUFFERS, ByVal dwReserved As Int32) As Int32
    Public Declare Sub URLDownloadToCacheFile Lib "URLMON.dll" (ByVal lpunknown As Int32, ByVal lpcstr As String, ByVal lptstr As String, ByVal dword As Int32, ByVal dword As Int32, ByRef TLPBINDSTATUSCALLBACK As Object)
    Public Declare Sub URLDownloadToFile Lib "URLMON.dll" (ByVal lpunknown As Int32, ByVal lpcstr As String, ByVal lpcstr As String, ByVal dword As Int32, ByRef TLPBINDSTATUSCALLBACK As Object)
    Public Declare Function UuidCompare Lib "rpcrt4.dll" (ByVal Uuid1 As Int32, ByVal Uuid2 As Int32, ByRef Status As Int32) As Int32
    Public Declare Function UuidCreate Lib "rpcrt4.dll" (ByVal Uuid As Int32) As Int32
    Public Declare Function UuidCreateNil Lib "rpcrt4.dll" (ByVal NilUuid As Int32) As Int32
    Public Declare Function UuidCreateSequential Lib "RPCRT4.dll" (ByVal Uuid As Int32) As Int32
    Public Declare Function UuidEqual Lib "rpcrt4.dll" (ByVal Uuid1 As Int32, ByVal Uuid2 As Int32, ByRef Status As Int32) As Int32
    Public Declare Function UuidFromString Lib "rpcrt4.dll" Alias "UuidFromStringA" (ByVal StringUuid As String, ByVal Uuid As Int32) As Int32
    Public Declare Function UuidHash Lib "rpcrt4.dll" (ByVal Uuid As Int32, ByRef Status As Int32) As Short
    Public Declare Function UuidIsNil Lib "rpcrt4.dll" (ByVal Uuid As Int32, ByRef Status As Int32) As Int32
    Public Declare Function UuidToString Lib "rpcrt4.dll" Alias "UuidToStringA" (ByVal Uuid As Int32, ByVal StringUuid As String) As Int32

    'Public Declare Function GetParent Lib "user32.dll" (ByVal hwnd As Int32) As Int32
    'Public Declare Function SetParent Lib "user32.dll" (ByVal hWndChild As Int32, ByVal hWndNewParent As Int32) As Int32
    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Int32, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Int32) As Int32
    Public Declare Function WinExec Lib "kernel32.dll" (ByVal lpCmdLine As String, ByVal nCmdShow As Int32) As Int32
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Public Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    Public Const SW_HIDE As Int32 = 0
    Public Const SW_MAXIMIZE As Int32 = 3
    Public Const SW_MINIMIZE As Int32 = 6
    Public Const SW_NORMAL As Int32 = 1
    Public Const SW_SHOW As Int32 = 5


    <StructLayout(LayoutKind.Sequential)> _
    Public Structure TRANSMIT_FILE_BUFFERS
        Dim Head As String
        Dim HeadLength As Int32
        Dim Tail As String
        Dim TailLength As Int32
    End Structure
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure OVERLAPPED
        Public ternal As Int32
        Public ternalHigh As Int32
        Public offset As Int32
        Public OffsetHigh As Int32
        Public hEvent As Int32
    End Structure
    Public Enum tagBINDINFOF
        BINDINFOF_URLENCODESTGMEDDATA
        BINDINFOF_URLENCODEDEXTRAINFO
    End Enum
    Public Enum BINDVERB
        BINDVERB_GET = 0
        BINDVERB_POST = 1
        BINDVERB_PUT = 2
        BINDVERB_CUSTOM = 3
        BINDVERB_RESERVED1 = 4
    End Enum
    Public Enum BINDINFO_OPTIONS
        BINDINFO_OPTIONS_WININETFLAG = 10000
        BINDINFO_OPTIONS_ENABLE_UTF8 = 20000
        BINDINFO_OPTIONS_DISABLE_UTF8 = 40000
        BINDINFO_OPTIONS_USE_IE_ENCODING = 80000
        BINDINFO_OPTIONS_BINDTOOBJECT = 100000
        BINDINFO_OPTIONS_SECURITYOPTOUT = 200000
        BINDINFO_OPTIONS_IGNOREMIMETEXTPLAIN = 400000
        BINDINFO_OPTIONS_USEBINDSTRINGCREDS = 800000
        BINDINFO_OPTIONS_IGNOREHTTPHTTPSREDIRECTS = 1000000
        BINDINFO_OPTIONS_IGNORE_SSLERRORS_ONCE = 2000000
        BINDINFO_WPC_DOWNLOADBLOCKED = 8000000
        BINDINFO_WPC_LOGGING_ENABLED = 10000000
        BINDINFO_OPTIONS_DISABLEAUTOREDIRECTS = 40000000
        BINDINFO_OPTIONS_SHDOCVW_NAVIGATE = 80000000
        BINDINFO_OPTIONS_ALLOWCONNECTDATA = 20000000
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SECURITY_ATTRIBUTES
        Public nLength As Int32
        Public lpSecurityDescriptor As Int32
        Public bInheritHandle As Int32
    End Structure
    Public Enum CODE_PAGE
        CP_ACP
        CP_MACCP
        CP_OEMCP
        CP_SYMBOL
        CP_THREAD_ACP
        CP_UTF7
        CP_UTF8
    End Enum
    Public Enum BINDF
        BINDF_ASYNCHRONOUS = 1
        BINDF_ASYNCSTORAGE = 2
        BINDF_NOPROGRESSIVERENDERING = 4
        BINDF_OFFLINEOPERATION = 8
        BINDF_GETNEWESTVERSION = 10
        BINDF_NOWRITECACHE = 20
        BINDF_NEEDFILE = 40
        BINDF_PULLDATA = 80
        BINDF_IGNORESECURITYPROBLEM = 100
        BINDF_RESYNCHRONIZE = 200
        BINDF_HYPERLINK = 400
        BINDF_NO_UI = 800
        BINDF_SILENTOPERATION = 1000
        BINDF_PRAGMA_NO_CACHE = 2000
        BINDF_GETCLASSOBJECT = 4000
        BINDF_RESERVED_1 = 8000
        BINDF_FREE_THREADED = 10000
        BINDF_DIRECT_READ = 20000
        BINDF_FORMS_SUBMIT = 40000
        BINDF_GETFROMCACHE_IF_NET_FAIL = 80000
        BINDF_FROMURLMON = 100000
        BINDF_FWD_BACK = 200000
        BINDF_PREFERDEFAULTHANDLER = 400000
        BINDF_ENFORCERESTRICTED = 800000
    End Enum
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure BINDINFO
        Dim cbSize As Long
        Dim szExtraInfo As String
        Dim stgmedData As String 'STGMEDIUM stgmedData
        Dim grfBindInfoF As tagBINDINFOF
        Dim dwBindVerb As BINDVERB
        Dim szCustomVerb As String
        Dim cbStgmedData As Int32
        Dim dwOptions As BINDINFO_OPTIONS
        Dim dwOptionsFlags As Int32
        Dim dwCodePage As CODE_PAGE
        Dim securityAttributes As SECURITY_ATTRIBUTES
        Dim iid As Int32 'IID iid
        Dim pUnk As IUnknown
        Shared dwReserved As Long = 0
    End Structure
    Public Enum BSCF
        BSCF_FIRSTDATANOTIFICATION = 1
        BSCF_INTERMEDIATEDATANOTIFICATION = 2
        BSCF_LASTDATANOTIFICATION = 4
        BSCF_DATAFULLYAVAILABLE = 8
        BSCF_AVAILABLEDATASIZEUNKNOWN = 10
        BSCF_SKIPDRAINDATAFORFILEURLS = 20
        BSCF_64BITLENGTHDOWNLOAD = 40
    End Enum
    Public Interface IUnknown
        Function AddRef() As Long
        Function QueryInterface(ByVal riid As Int32, ByVal ppvObject As Object) As Int32
        Function Release() As Long
    End Interface
    Public Interface IBindStatusCallback
        Function GetBindInfo(ByVal grfBINDF As BINDF, ByVal pbindinfo As BINDINFO) As Int32
        Function GetPriority(ByVal pnPriority As Long) As Int32
        Function OnDataAvailable(ByVal grfBSCF As BSCF, ByVal dwSize As Long, Optional pformatetc As Long = Nothing, Optional pstgmed As Long = Nothing) As Int32

    End Interface
#End Region
    'dim result as int32 = URLDownloadToFile(NULL, URL, File, 0, NULL)
    'select case (result)
    '
    'case S_OK
    ' downloaded = true
    ' break
    'case E_OUTOFMEMORY
    ' debug.print("Out of memory error")
    ' break
    'case INET_E_DOWNLOAD_FAILURE
    'debug.print("Cannot access server data")
    ' break
    'case else
    'debug.print("Unknown error")
    ' break
    '
    Public Reg As New Registry
    Public USERS As New StringList()
    Public PASSWORDS As New StringList()
    Public S_USER As String, S_PASSWORD As String
    'Public userINI, sysINI, bootINI, configINI, programINI As IniStream
    Public userINI, sysINI, bootINI, configINI, programINI As UserSettings
    Public Interface ISettings

    End Interface
    'Public Interface IProgram
    '    ReadOnly Property APP_VER As String
    '    Property WindowState As SlimOS_Form.SWindowState
    '    Property APP_TITLE As String
    '    ReadOnly Property APP_PATH As String
    '    ReadOnly Property WindowStyle As SlimOS_Form.SlimOS_FormStyle
    '    ReadOnly Property AppID As Integer
    '    'Sub OnAppInit(ByVal lpTitle As String, ByVal lpPath As String)
    '    'Sub OnAppLoaded(ByVal lpAppArguments As String())
    '    'Sub OnAppUnloaded()
    '    'Sub OnAppResize(ByVal WindowState As SlimOS_Form.SWindowState)
    '    Event OnAppInit(ByVal lpTitle As String, ByVal lpPath As String, ByVal lpVer As String)
    '    Event OnAppLoaded(ByVal Arguments As String())
    '    Event OnAppUnloaded()
    '    Event OnAppResized(ByVal WindowState As SlimOS_Form.SWindowState)
    'End Interface

    Public Function DownloadFileAPI(ByVal lpURL As String, ByVal lpPath As String) As Integer
        URLDownloadToFile(Nothing, lpURL, lpPath, 0, Nothing)
        Return 1
    End Function
    Public Function DownloadFile(ByVal lpURL As String, ByVal lpPath As String, Optional ByVal lpUser As String = "", Optional ByVal lpPassword As String = "", Optional ByVal lpShowUI As Boolean = False) As Boolean
        My.Computer.Network.DownloadFile(lpURL, lpPath, lpUser, lpPassword, lpShowUI, 100, False)
        Return My.Computer.FileSystem.FileExists(lpPath)
    End Function
    Public Function UploadFile(ByVal lpPath As String, ByVal lpURL As String, Optional ByVal lpUser As String = "", Optional ByVal lpPassword As String = "", Optional ByVal lpShowUI As Boolean = False) As Boolean
        My.Computer.Network.UploadFile(lpPath, lpURL, lpUser, lpPassword, lpShowUI, 100)
        Return My.Computer.FileSystem.FileExists(lpURL)
    End Function

    ''' <summary>
    ''' Get the IniStream Class from a filename.
    ''' </summary>
    ''' <param name="lpPath"></param>
    ''' <returns>A new IniStream Class using the specified filename/path.</returns>
    ''' <remarks></remarks>
    Public Function GetINIStream(ByVal lpPath As String) As IniStream
        Return New IniStream(lpPath)
    End Function

    ''' <summary>
    ''' Converts a String to a Byte Array.
    ''' </summary>
    ''' <param name="lpStr">The String to convert.</param>
    ''' <returns>The converted Byte Array.</returns>
    ''' <remarks></remarks>
    Public Function Str2ByteArray(ByVal lpStr As String) As [Byte]()
        Dim enc As New ASCIIEncoding()
        Return enc.GetBytes(lpStr.ToCharArray())
    End Function

    ''' <summary>
    ''' Converts a byte array to a string.
    ''' </summary>
    ''' <param name="lpByte">The byte array to convert.</param>
    ''' <returns>The converted string.</returns>
    ''' <remarks></remarks>
    Public Function ByteArray2Str(ByVal lpByte As [Byte]()) As String
        Dim enc As New ASCIIEncoding()
        Return enc.GetString(lpByte)
    End Function

    ''' <summary>
    ''' Encodes a string into a base64-encoded string.
    ''' </summary>
    ''' <param name="lpStr">The string to encode.</param>
    ''' <returns>The encoded base64 string.</returns>
    ''' <remarks></remarks>
    Public Function Str2B64(ByVal lpStr As String) As String
        Return Convert.ToBase64String(Str2ByteArray(lpStr), Base64FormattingOptions.None)
    End Function

    ''' <summary>
    ''' Decodes a base64-String into a String.
    ''' </summary>
    ''' <param name="lpStr">The encoded String to decode.</param>
    ''' <returns>The decoded base64 string.</returns>
    ''' <remarks></remarks>
    Public Function B642Str(ByVal lpStr As String) As String
        Return ByteArray2Str(Convert.FromBase64String(lpStr))
    End Function

    ''' <summary>
    ''' This method starts at the specified directory, and traverses all subdirectories.
    ''' It returns a List of those directories.
    ''' </summary>
    Public Function GetFilesRecursive(ByVal initial As String, Optional ByVal e As String = "*.*") As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, e))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop

        ' Return the list
        Return result
    End Function

    Public Sub initProgramsFolder()
        'Reg.UpdateApps()
    End Sub
    Public Sub initProgramsINI()
        'initProgramsFolder()
    End Sub
    Public Sub initUsersINI()
        Debug.Print(My.Settings.UsersAndGroupFile)
        If Not My.Computer.FileSystem.FileExists(My.Settings.UsersAndGroupFile) = True Then
            Dim f As New FileInfo(My.Settings.UsersAndGroupFile)
            Dim w As TextWriter = f.CreateText()
            Dim s As String = My.Resources.users
            With w
                '.WriteLine("[Users]")
                '.WriteLine("Default=Administrator")
                '.WriteLine("Users=Administrator|Guest")
                '.WriteLine("Count=2")
                '.WriteLine()
                '.WriteLine("[Administrator]")
                '.WriteLine("Username=Administrator")
                '.WriteLine("Password=" & Str2B64("admin"))
                '.WriteLine()
                '.WriteLine("[Guest]")
                '.WriteLine("Username=Guest")
                '.WriteLine("Password=")
                .WriteLine(s)
                .Close()
            End With

        End If
        userINI = New UserSettings(My.Settings.UsersAndGroupFile)
    End Sub
    Public Sub initSystemINI()
        Debug.Print(My.Settings.SystemFile)
        If Not My.Computer.FileSystem.FileExists(My.Settings.SystemFile) = True Then
            Dim f As New FileInfo(My.Settings.SystemFile)
            Dim w As TextWriter = f.CreateText()
            Dim s As String = My.Resources.system
            With w
                '.WriteLine("[System]")
                '.WriteLine("ShowLogonExtendedOptions=False")
                '.WriteLine("ErrorLevel=1")
                '.WriteLine()
                .WriteLine(s)
                .Close()
            End With

        End If
        sysINI = New UserSettings(My.Settings.SystemFile)
    End Sub
    Public Sub initBootINI()
        Debug.Print(My.Settings.BootFile)
        If Not My.Computer.FileSystem.FileExists(My.Settings.BootFile) = True Then
            Dim f As New FileInfo(My.Settings.BootFile)
            Dim w As TextWriter = f.CreateText()
            Dim s As String = My.Resources.boot
            With w
                '.WriteLine("[OperatingSystems]")
                '.WriteLine("Default=SlimOS")
                '.WriteLine("Timeout=0")
                '.WriteLine()
                '.WriteLine("[SlimOS]")
                '.WriteLine("DisplayName=SlimOS")
                '.WriteLine("BootOptions=None")
                '.WriteLine("BootPath=./")
                '.WriteLine()
                .WriteLine(s)
                .Close()
            End With

        End If
        bootINI = New UserSettings(My.Settings.BootFile)
    End Sub
    Public Sub initConfigINI()
        Debug.Print(My.Settings.ConfigFile)
        If Not My.Computer.FileSystem.FileExists(My.Settings.ConfigFile) = True Then
            Dim f As New FileInfo(My.Settings.ConfigFile)
            Dim w As TextWriter = f.CreateText()
            Dim s As String = My.Resources.config
            With w
                '.WriteLine("[Settings]")
                '.WriteLine("DefaultUser=Administrator")
                '.WriteLine("GuestAccountEnabled=False")
                '.WriteLine("AutoDimDisplay=5")
                '.WriteLine("AutoOffDisplay=10")
                '.WriteLine("AutoStandby=15")
                '.WriteLine("AutoTurnOff=-1")
                '.WriteLine("ScreensaverTimeout=3")
                '.WriteLine("RequirePasswordOnResume=False")
                .WriteLine(s)
                .Close()
            End With

        End If
        configINI = New UserSettings(My.Settings.ConfigFile)
    End Sub
    Public Const NewLn As String = vbNewLine
    Public Sub BootSequence()
        With My.Settings
            .UsersPath = CurDir() & "\users"
            .ProgramFiles = CurDir() & "\programs"
            .SystemRoot = CurDir() & "\SlimOS"
            .SystemFile = .SystemRoot & "\system.xml"
            .UsersAndGroupFile = .SystemRoot & "\users.xml"
            .ConfigFile = .SystemRoot & "\config.xml"
            .BootFile = .SystemRoot & "\boot.xml"
            .ProgramsFile = .SystemRoot & "\programs.xml"
            .Save()
            If My.Computer.FileSystem.DirectoryExists(.SystemRoot) = False Then
                My.Computer.FileSystem.CreateDirectory(.SystemRoot)
            End If
            If My.Computer.FileSystem.FileExists(.SystemFile) = False Then
                MsgBox("Info: The following file(s) and/or folder(s) were created: " &
                    NewLn & "boot.xml: " & .BootFile &
                    NewLn & "system.xml: " & .SystemFile &
                    NewLn & "users.xml: " & .UsersAndGroupFile &
                    NewLn & "SlimOS: " & .SystemRoot &
                    NewLn & "in the current folder: " & CurDir() & ".", vbInformation, "Info")
                Call initConfigINI()
                Call initSystemINI()
                Call initUsersINI()
                Call initBootINI()
                Call initProgramsINI()
            End If
            If My.Computer.FileSystem.DirectoryExists(.UsersPath) = False Then
                My.Computer.FileSystem.CreateDirectory(.UsersPath)                
            End If
            If My.Computer.FileSystem.DirectoryExists(.ProgramFiles) = False Then
                My.Computer.FileSystem.CreateDirectory(.ProgramFiles)
            End If

        End With
        Call RefreshINIs(False)
    End Sub

    ''' <summary>
    ''' Refreshes the INI configuration files.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshINIs(Optional lpUpdate As Boolean = True)
        With My.Settings
            bootINI = Nothing
            sysINI = Nothing
            userINI = Nothing
            'programINI = Nothing

            bootINI = New UserSettings(.BootFile)
            sysINI = New UserSettings(.SystemFile)
            userINI = New UserSettings(.UsersAndGroupFile)
            'programINI = New UserSettings(.ProgramsFile)

        End With
        initProgramsFolder()
        If lpUpdate = True Then
            Call UpdateUsers()
        End If
        Call My.MyApplication.SetFolderPerms(My.Application.Info.DirectoryPath)
    End Sub

    ''' <summary>
    ''' Updates the USERS list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateUsers()
        Call RefreshINIs(False)
        'userINI.GetString("Users", "Users", "")
        'Dim u As String() = usrs.Split("|")
        'USERS.Clear()
        'For i As Integer = 0 To u.Count() - 1
        '    USERS.Add(u(i))
        'Next
        userINI.Reload()
        USERS.Clear()
        USERS = userINI.FindSettings("user")
    End Sub
    ''' <summary>
    ''' Updates the PASSWORD list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdatePasswords()
        Call RefreshINIs()
        'Dim usrs As String = userINI.GetString("Users", "Users", "")
        'Dim u As String() = usrs.Split("|")
        'USERS.Clear()
        'PASSWORDS.Clear()
        'Dim tmp As New StringList()
        'For i As Integer = 0 To u.Count() - 1
        '    tmp.Add(u(i))
        'Next
        'USERS = tmp
        'For i As Integer = 0 To tmp.Count() - 1
        '    PASSWORDS.Add(B642Str(userINI.GetString(tmp.Item(i), "Password", "")))
        'Next
        userINI.Reload()
        USERS.Clear()
        USERS = userINI.FindSettings("user")

        PASSWORDS.Clear()
        PASSWORDS = userINI.FindSettings("password")
    End Sub
    ''' <summary>
    ''' Updates the USERS and the PASSWORDS list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateUserList()
        Call UpdateUsers()
        Call UpdatePasswords()
    End Sub

    ''' <summary>
    ''' Adds a user to the system.
    ''' </summary>
    ''' <param name="lpUsername">The user's name</param>
    ''' <param name="lpPassword">The user's password</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' TODO:
    ''' - Check if the system allows a new user to be created w/out logging on
    ''' </remarks>
    ''' 
    Public Function AddUser(ByVal lpUsername As String, ByVal lpPassword As String) As Boolean
        Debug.Print(USERS.ToString())
        Call UpdateUserList()
        Debug.Print(USERS.ToString())

        For Each s As String In USERS
            Debug.Print("User: " & s)
        Next s

        If USERS.ContainsString(lpUsername) = False Then
            'userINI.WriteString("Users", "Users", USERS.Join("|"))
            userINI.AddSetting("user", lpUsername)
            userINI.AddSetting("password", lpPassword)
            userINI.Save()
            Call UpdateUserList()
            'If Not userINI.GetString("Users", "Users", "") = "" Then
            If USERS.Contains(lpUsername) And PASSWORDS.Contains(lpPassword) Then
                For Each s As String In USERS
                    Debug.Print("User: " & s)
                Next s

                'userINI.WriteString(lpUsername, "Username", lpUsername)
                'userINI.WriteString(lpUsername, "Password", Str2B64(lpPassword))
                'userINI.WriteString("Users", "Users", USERS.Join("|"))
                'userINI.WriteString("Users", "Users", USERS.Join("|"))
                'userINI.WriteString("Users", "Count", USERS.Count())
                Call UpdateUserList()
                For Each s As String In USERS
                    Debug.Print("User: " & s)
                Next s
                Return True
            Else
                For Each s As String In USERS
                    Debug.Print("User: " & s)
                Next s
                Call UpdateUserList()
                For Each s As String In USERS
                    Debug.Print("User: " & s)
                Next s

                Return False

            End If
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Removes a user from the system.
    ''' </summary>
    ''' <param name="lpUsername">The user's name.</param>
    ''' <param name="lpPassword">The user's password.</param>
    ''' <returns>True if removed, False if username and password don't match or if the USERS and PASSWORDS structure wasn't updated correctly.</returns>
    ''' <remarks></remarks>
    Public Function RemoveUser(ByVal lpUsername As String, ByVal lpPassword As String) As Boolean
        Call UpdateUserList()
        If USERS.ContainsString(lpUsername) = True And PASSWORDS.ContainsString(lpPassword) = True Then
            Debug.Print(userINI.RemoveSetting("user", lpUsername))
            Debug.Print(userINI.RemoveSetting("password", lpPassword))
            'USERS.Remove(lpUsername)
            'PASSWORDS.Remove(lpPassword)
            userINI.Save()
            Call UpdateUserList()

            If Not USERS.Contains(lpUsername) = lpUsername And PASSWORDS.Contains(lpPassword) Then
                Call UpdateUserList()
                Return True
            Else
                Call UpdateUserList()
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Function ListToArray(ByVal l As List(Of String)) As String()

    End Function

    ''' <summary>
    ''' Gets a control's ZOrder/ZIndex.
    ''' </summary>
    ''' <param name="lpColl">The control collection</param>
    ''' <param name="lpCtrl">The control</param>
    ''' <returns>The ZOrder/ZIndex of the control.</returns>
    ''' <remarks></remarks>
    Public Function GetZIndex(ByVal lpColl As Control.ControlCollection, ByVal lpCtrl As Control) As Integer
        Dim ret As Integer = Nothing
        For i As Integer = 0 To lpColl.Count - 1
            If lpColl.Item(i).Handle = lpCtrl.Handle Then
                ret = lpColl.GetChildIndex(lpColl.Item(i))
                Exit For
            End If
        Next
        If Not ret = Nothing Then
            Return ret
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Sets a control's ZOrder/ZIndex in a control collection.
    ''' </summary>
    ''' <param name="lpColl">The control collection</param>
    ''' <param name="lpCtrl">The control</param>
    ''' <param name="lpZ">The new ZOrder/ZIndex</param>
    ''' <returns>Returns true if successfull, else false on fail.</returns>
    ''' <remarks></remarks>
    Public Function SetZIndex(ByVal lpColl As Control.ControlCollection, ByVal lpCtrl As Control, ByVal lpZ As Integer) As Boolean
        Dim exists As Integer = GetZIndex(lpColl, lpCtrl)
        If Not exists = Nothing Then
            lpColl.SetChildIndex(lpCtrl, lpZ)
            Dim ret As Integer = GetZIndex(lpColl, lpCtrl)
            If ret = lpZ Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Function GetProgramInterface() As IProgram
        Throw New NotImplementedException
    End Function

End Module


'INI Call for VB.NET
'Version 1.1
Public Class IniFile

    Private Enum KeyData
        KeyName = 0
        KeyValue = 1
    End Enum

    Private Const SplitChar As String = "€"
    Private Const AssignChar As String = "="
    Private Const SelectionStart As String = "["
    Private Const SelectionEnd As String = "]"

    Private mFilename As String
    Private IniData As List(Of String)

    Public Sub ReadSection(ByVal Selection As String, ByVal Strings As List(Of String))
        If (Not IniData Is Nothing) Then
            'Return a list of key names from a selection.
            For Each sLine In IniData
                'Check if selections match.
                If IsMatch(GetSelection(sLine), Selection) Then
                    'Get key name
                    Dim sPos As Integer = sLine.IndexOf(SplitChar)
                    sLine = sLine.Substring(sPos + 1)
                    'Check for selection.
                    If Not IsSelection(sLine) Then
                        'Add keyname to list
                        Call Strings.Add(GetKeyData(sLine, KeyData.KeyName))
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub ReadSections(ByVal Strings As List(Of String))
        Dim selName As String
        If (Not IniData Is Nothing) Then
            For Each sLine In IniData
                selName = GetSelection(sLine)
                'Check if selection is already found.
                If Not Strings.Contains(selName) Then
                    'Selection not found in list add it.
                    Call Strings.Add(selName)
                End If
            Next
        End If
    End Sub

    Property Filename As String
        'Get filename.
        Get
            Filename = mFilename
        End Get
        'Set filename.
        Set(ByVal value As String)
            mFilename = value
        End Set
    End Property

    Public Function ReadBool(ByVal Selection As String, ByVal Key As String, Optional ByVal iDefault As Boolean = False) As Boolean
        Dim src As String = ReadString(Selection, Key, iDefault).ToLower()

        If (src = "yes") Or (src = "on") Then
            ReadBool = True
        Else
            ReadBool = CBool(src)
        End If

    End Function

    Public Function ReadString(ByVal Selection As String, ByVal Key As String, Optional ByVal iDefault As String = "") As String
        'Returns a keys data.
        Dim Ret As String = vbNullChar

        If (Not IniData Is Nothing) Then
            'Loop though the lines in the list collection.
            For Each sLine In IniData
                Dim sPos As Integer = sLine.IndexOf(SplitChar)
                'Check for splitchar chr 128 position.
                If (sPos > 0) Then
                    'Check for selection match.
                    If IsMatch(sLine.Substring(0, sPos), Selection) Then
                        'Get line.
                        Dim Temp As String = sLine.Substring(sPos + 1, sLine.Length - sPos - 1)
                        'Check that key name is found.
                        If IsMatch(GetKeyData(Temp, KeyData.KeyName), Key) Then
                            'Store return value.
                            Ret = GetKeyData(sLine, KeyData.KeyValue)
                        End If
                    End If
                End If
            Next
        End If

        If (Ret = vbNullChar) Then
            'Return default value.
            ReadString = iDefault
        Else
            'Return returned value.
            ReadString = Ret
        End If
    End Function

    Function SectionExists(ByVal Selection As String) As Boolean
        'Returns true or false if a selection exists.
        Dim bFound As Boolean = False

        If (Not IniData Is Nothing) Then
            For Each sLine In IniData
                Dim selName As String = GetSelection(sLine)
                'Check if selection is found.
                If IsMatch(selName, Selection) Then
                    bFound = True
                    Exit For
                End If
            Next
        End If
        'Return result.
        SectionExists = bFound

    End Function

    Public Function LoadFromFile() As Boolean
        Dim sLine As String
        Dim mSelection As String = ""
        Dim sr As StreamReader

        'Check that file is found
        If Not File.Exists(Filename) Then
            LoadFromFile = False
            Exit Function
        End If

        IniData = New List(Of String)
        'Create new string builder object

        sr = New StreamReader(Filename)
        'Read each line of the ini filename.
        While Not sr.EndOfStream
            'Get current line
            sLine = sr.ReadLine().Trim()

            'Check line length and if we have a selection.
            If (sLine.Length) And IsSelection(sLine) Then
                mSelection = RemoveBrackets(sLine)
            End If

            'Get value names.
            If sLine.Length Then
                'Add to list.
                Call IniData.Add(mSelection.ToUpper() + SplitChar + sLine)
            End If

        End While
        'Close open file stream.
        Call sr.Close()
        'Looks ok to me lets return good result.
        LoadFromFile = True
    End Function

    'INI TOOLS
    Private Function GetKeyData(ByVal TempLine As String, ByVal RetType As KeyData) As String
        Dim Ret As String = vbNullChar
        'Check for assign position.
        Dim aPos As Integer = TempLine.IndexOf(AssignChar)

        'Return key name.
        If (RetType = KeyData.KeyName) Then
            If (aPos <> -1) Then
                'Remove assign char and return key name.
                Ret = TempLine.Substring(0, aPos).TrimEnd()
            End If
        End If

        'Return key value.
        If (RetType = KeyData.KeyValue) Then
            'Check for assignment psoition.
            If (aPos <> -1) Then
                Ret = TempLine.Substring(aPos + 1)
            End If
        End If
        GetKeyData = Ret

    End Function

    Private Function GetSelection(ByVal TmpLine As String) As String
        Dim sPos As Integer = TmpLine.IndexOf(SplitChar)

        If (sPos = 0) Then
            GetSelection = ""
        Else
            GetSelection = TmpLine.Substring(0, sPos)
        End If
    End Function

    Private Function IsMatch(ByVal Source As String, ByVal FindStr As String) As Boolean
        'Return true if source is the same as findstr.
        IsMatch = StrComp(Source, FindStr, CompareMethod.Text) = 0
    End Function

    Private Function IsSelection(ByVal TempLine As String) As Boolean
        'Checks that string is selection by checking start and end chars.
        IsSelection = (TempLine.StartsWith(SelectionStart)) And (TempLine.EndsWith(SelectionEnd))
    End Function

    Private Function RemoveBrackets(ByVal TempLine As String) As String
        'Remove braces and return selection name.
        RemoveBrackets = TempLine.Substring(1, TempLine.Length - 2)
    End Function

End Class

Public NotInheritable Class StringList
    Inherits System.Collections.Generic.List(Of String)

    ''' <summary>
    ''' Joins all elements into a string array.
    ''' </summary>
    ''' <param name="lpSep">The seperator.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Join(ByVal lpSep As String) As String
        Dim ret As String = ""
        For i As Integer = 0 To MyClass.Count() - 1
            If i = MyClass.Count() Then
                ret += MyClass.Item(i)
            Else
                ret += MyClass.Item(i) & lpSep
            End If
        Next
        Return ret
    End Function

    ''' <summary>
    ''' Concats all elements into an array string.
    ''' </summary>
    ''' <param name="lpSep">The seperator.</param>
    ''' <returns>The list.</returns>
    ''' <remarks></remarks>
    Public Overloads Function Concat(ByVal lpList As String, ByVal lpSep As String) As List(Of String)
        Dim ret As New List(Of String)
        Dim r As String() = lpList.Split(lpSep)
        For i As Integer = 0 To r.Count() - 1
            ret.Add(r(i))
        Next
        Return ret
    End Function

    ''' <summary>
    ''' Determines whether a string exists.
    ''' </summary>
    ''' <param name="lpString">The string to determine.</param>
    ''' <returns>True if it exists, False if it doesn't.</returns>
    ''' <remarks>Also the same as Contains(String)</remarks>
    Public Function ContainsString(ByVal lpString As String) As Boolean
        Return Me.Contains(lpString)
    End Function
    ''' <summary>
    ''' Determines whether an index exists.
    ''' </summary>
    ''' <param name="lpIndex">The index to determine.</param>
    ''' <returns>True if exists, False if it doesn't exist.</returns>
    ''' <remarks></remarks>
    Public Function ContainsIndex(ByVal lpIndex As Integer) As Boolean
        Return IsNothing(MyClass.Item(lpIndex)) = False
    End Function
End Class

Public Class UserSettings
    Dim WithEvents xml As XmlDocument
    Dim mFile As String

    Public Enum XMLValueType As Integer
        XVT_INNERTEXT = 0
        XVT_VALUE = 1
        XVT_DEFAULT = XVT_INNERTEXT
    End Enum

    Public ReadOnly Property Filename As String
        Get
            Return mFile
        End Get
    End Property

    Public Sub New(ByVal lpFilename As String)
        If Not File.Exists(lpFilename) Then
            Debug.Fail("Fatal Error: The specified filename doesn't exist.")
            'Throw New InvalidDataException("Error: The specified filename doesn't exist.")
            Throw New FileNotFoundException("Error: The specified filename doesn't exist.", lpFilename)
            Exit Sub
            Stop
        End If
        xml = New XmlDocument()
        xml.Load(lpFilename)
        Me.mFile = lpFilename
    End Sub

    Public Function GetSetting(ByVal lpName As String, Optional ByVal lpSection As String = "setting") As XmlNode()
        Dim contain As XmlNodeList
        With xml
            contain = .GetElementsByTagName(lpName)
        End With
        Dim n As XmlNode
        Dim ret As New List(Of XmlNode)
        Dim i As Integer = 0
        For i = 0 To contain.Count() - 1
            n = contain.Item(i)
            ret.Add(n)
        Next
        'For Each n As XmlNode In contain
        '    Debug.Print(n.Name)
        '    Debug.Print(n.Item(lpSection).Item(lpName).Name)

        '    If n.Name = "settings" Then
        '        If n.Item(lpSection).Item(lpName).Name = lpName Then
        '            Return n.Item(lpSection).Item(lpName)
        '        End If
        '        'Return n.Attributes.GetNamedItem(lpName).Value
        '    End If
        'Next n
        'Return Nothing
        Return ret.ToArray()
    End Function

    Public Function GetSettingValue(ByVal lpName As String, Optional ByVal lpSection As String = "setting", Optional ByVal ValueType As XMLValueType = XMLValueType.XVT_INNERTEXT) As String
        Dim contain As XmlNodeList
        With xml
            contain = .GetElementsByTagName("settings")
        End With
        For Each n As XmlNode In contain
            Debug.Print(n.Name)
            Debug.Print(n.Item(lpSection).Item(lpName).Name)

            If n.Name = "settings" Then
                If n.Item(lpSection).Item(lpName).Name = lpName Then
                    If ValueType = XMLValueType.XVT_INNERTEXT Then
                        Return n.Item(lpSection).Item(lpName).InnerText
                    ElseIf ValueType = XMLValueType.XVT_VALUE Then
                        Return n.Item(lpSection).Item(lpName).Value
                    Else
                        Return n.Item(lpSection).Item(lpName).InnerText
                    End If
                End If
                'Return n.Attributes.GetNamedItem(lpName).Value
            End If
        Next n
        Return Nothing
    End Function

    Public Function GetSection(Optional ByVal lpSection As String = "setting") As XmlNode
        Dim contain As XmlNodeList
        With xml
            contain = .GetElementsByTagName("settings")
        End With
        For Each n As XmlNode In contain
            Debug.Print(n.Name)
            Debug.Print(n.Item(lpSection).Name)

            If n.Item(lpSection).Name = lpSection Then
                Return n.Item(lpSection)
                'If n.Item(lpSection).Name = lpSection Then
                '    Return n.Item(lpSection)
                'End If
            End If
        Next n
        Return Nothing
    End Function

    Public Function SetSetting(ByVal lpName As String, ByVal lpValue As String, Optional ByVal lpSection As String = "setting", Optional ByVal ValueType As XMLValueType = XMLValueType.XVT_INNERTEXT) As Boolean
        Dim p As XmlNode = GetSection(lpSection)
        Dim n As XmlNode = p.Item(lpName)
        Select Case ValueType
            Case XMLValueType.XVT_INNERTEXT
                n.InnerText = lpValue
                Return n.InnerText = lpValue
            Case XMLValueType.XVT_VALUE
                n.Value = lpValue
                Return n.Value = lpValue
            Case Else
                n.InnerText = lpValue
                Return n.InnerText = lpValue
        End Select
        Return Nothing
    End Function

    Public Function AddSetting(ByVal lpName As String, ByVal lpValue As String, Optional ByVal lpSection As String = "setting", Optional ByVal ValueType As XMLValueType = XMLValueType.XVT_INNERTEXT) As Boolean
        Dim p As XmlNode = GetSection(lpSection)
        Dim c As XmlNode = xml.CreateNode(XmlNodeType.Element, lpName, p.NamespaceURI)

        Select Case ValueType
            Case XMLValueType.XVT_INNERTEXT
                c.InnerText = lpValue
            Case XMLValueType.XVT_VALUE
                c.Value = lpValue
            Case Else
                c.InnerText = lpValue
        End Select
        Return p.AppendChild(c).Equals(c)
    End Function

    Public Function FindSettings(ByVal lpName As String) As StringList
        Dim ret As New StringList
        Dim p() As XmlNode = GetSetting(lpName)
        For Each n As XmlNode In p
            ret.Add(n.InnerText)
        Next
        Return ret
    End Function

    Public Function RemoveSetting(ByVal lpName As String, ByVal lpValue As String, Optional ByVal lpSection As String = "setting") As Boolean
        Dim n() As XmlNode = GetSetting(lpName, lpSection)
        For Each c As XmlNode In n
            If c.Value = lpValue Or c.InnerText = lpValue Then
                c.ParentNode.RemoveChild(c)
                Return True
            End If
        Next c
        Return False
    End Function

    Private Sub xml_NodeChanged(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeChanged

    End Sub

    Private Sub xml_NodeChanging(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeChanging

    End Sub

    Private Sub xml_NodeInserted(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeInserted

    End Sub

    Private Sub xml_NodeInserting(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeInserting

    End Sub

    Private Sub xml_NodeRemoved(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeRemoved

    End Sub

    Private Sub xml_NodeRemoving(sender As Object, e As System.Xml.XmlNodeChangedEventArgs) Handles Xml.NodeRemoving

    End Sub

    Public Sub Reload()
        Call Me.Load(Me.Filename)
    End Sub

    Public Sub Resave()
        Call Me.Save()
        Call Me.Reload()
    End Sub

    Public Sub Load(ByVal lpFilename As String)
        Me.mFile = lpFilename
        With xml
            .Load(Me.Filename)
        End With
    End Sub

    Public Sub Save()
        With xml
            .Save(Me.Filename)
        End With
    End Sub
End Class
