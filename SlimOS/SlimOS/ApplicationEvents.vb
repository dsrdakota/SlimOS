Imports System
Imports System.IO
Imports System.Security.AccessControl

Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        ''' <summary>
        ''' This method starts at the specified directory, and traverses all subdirectories.
        ''' It returns a List of those directories.
        ''' </summary>
        Public Shared Function GetFilesRecursive(ByVal initial As String, Optional ByVal e As String = "*.*") As List(Of String)
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

        Public Shared Function SetFolderPerms(ByVal lpPath As String, Optional ByVal lpExt As String = "*.*") As Boolean
            Dim lst As New List(Of String)
            lst = GetFilesRecursive(lpPath)
            For Each s As String In lst
                Dim FilePath As String = s
                Dim UserAccount As String = "Everyone"
                Dim FileInfo As IO.FileInfo = New IO.FileInfo(FilePath)
                Dim FileAcl As New FileSecurity
                FileAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, AccessControlType.Allow))
                'FolderAcl.SetAccessRuleProtection(True, False) 'uncomment to remove existing permissions
                FileInfo.SetAccessControl(FileAcl)
            Next s
            Return True
        End Function

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Call SetFolderPerms(My.Application.Info.DirectoryPath)
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            Dim ex As Exception = e.Exception
            'Here's an easy hack but we comment it because we can use Debug.Fail to display it instead.

            Debug.Fail("Error: An unhandled exception has occurred, please contact one of the developers." & vbNewLine & " Details: " & ex.Message & vbCrLf & " Occurred in " & ex.Source & vbCrLf & "Stack: " & ex.StackTrace & vbCrLf & "Data: " & ex.Data.ToString())

            '            Dim ret As MsgBoxResult
            '            GoTo bStart
            'bStart:
            '            ret = MsgBox("Error: An unhandled exception occurred. Details: " & ex.Message & vbCrLf & " Occurred in " & ex.Source & vbCrLf & "Stack: " & ex.StackTrace & vbCrLf & "Data: " & ex.Data.ToString(), MsgBoxStyle.AbortRetryIgnore, "Unhandled Exception")
            '            'MsgBoxStyle.AbortRetryIgnore
            '            Select Case ret
            '                Case MsgBoxResult.Abort
            '                    'Abort and exit
            '                    'My.Application.MainForm.Close()
            '                    e.ExitApplication = True

            '                Case MsgBoxResult.Retry
            '                    'Retry
            '                    GoTo bStart

            '                Case MsgBoxResult.Ignore
            '                    'Continue
            '                    Exit Sub

            '            End Select
        End Sub
    End Class


End Namespace

