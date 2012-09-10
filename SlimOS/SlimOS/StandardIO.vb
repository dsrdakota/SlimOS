'Option Strict On
Option Explicit On
Imports System
Imports System.IO
Imports System.IO.Compression

Imports Ionic
Imports Ionic.BZip2
Imports Ionic.Crc
Imports Ionic.Zip
Imports Ionic.Zlib

Namespace Library
    Public Class StandardIO
        'Public Property Filename As String
        Public Function CreateFile(ByVal lpFile As String, Optional lpBuffSize As Integer = 1024) As FileStream
            Return File.Create(lpFile, lpBuffSize)
        End Function
        Public Sub DeleteFile(ByVal lpFile As String, Optional lpPermenately As Boolean = True)
            File.Delete(lpFile)
        End Sub
        Public Function WriteToFile(ByVal lpFile As String, ByVal lpData As String) As Boolean
            File.WriteAllText(lpFile, lpData)
            If File.ReadAllText(lpFile) = lpData Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function ReadFromFile(ByVal lpFile As String) As String
            Return File.ReadAllText(lpFile)
        End Function
        Public Function OpenFile(ByVal lpFile As String, Optional lpCreate As Boolean = True) As FileStream
            Return File.Open(lpFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        End Function
    End Class

    Public Class ZipIO
        Public Enum ZMethod As Integer
            Z_OPEN = 1
            Z_CREATE = 2
        End Enum
        Public Property Filename As String
        Public Property Method As ZMethod

        Dim lFile As New Zip.ZipFile(Filename)

        Public Sub AddToZip(file As String)
            With lFile
                .AddItem(file)
            End With
        End Sub
        Public Sub DelFromZip(file As String)
            With lFile
                .RemoveEntry(file)
            End With
        End Sub
        Public Sub ExtractFile(file As String, out As String)
            With lFile
                .ExtractSelectedEntries(file, "", out)
            End With
        End Sub
        Public Sub ExtractAllFiles(ByVal lpOutput As String, Optional ByVal lpFiles As String = "*.*")
            With lFile
                .ExtractAll(lpOutput)
            End With

        End Sub
        Public Sub Initialize(ByVal lpZipFile As String, ByVal lpMethod As ZMethod)
            If File.Exists(lpZipFile) = True And lpMethod = ZMethod.Z_OPEN Then
                Filename = lpZipFile
                Method = lpMethod
            End If
            If File.Exists(lpZipFile) = False And lpMethod = ZMethod.Z_CREATE Then
                Filename = lpZipFile
                Method = lpMethod
            End If
        End Sub
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    Public Class ConfigIO
#Region "API Calls"
        ' standard API declarations for INI access
        ' changing only "As Long" to "As Int32" (As Integer would work also)
        Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, ByVal lpString As String, _
        ByVal lpFileName As String) As Int32

        Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, ByVal lpDefault As String, _
        ByVal lpReturnedString As String, ByVal nSize As Int32, _
        ByVal lpFileName As String) As Int32
#End Region

        Public Overloads Function INIRead(ByVal INIPath As String, _
        ByVal SectionName As String, ByVal KeyName As String, _
        ByVal DefaultValue As String) As String
            ' primary version of call gets single value given all parameters
            Dim n As Int32
            Dim sData As String
            sData = space$(1024) ' allocate some room 
            n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
            sData, sData.Length, INIPath)
            If n > 0 Then ' return whatever it gave us
                INIRead = sdata.Substring(0, n)
            Else
                iniread = ""
            End If
        End Function

#Region "INIRead Overloads"
        Public Overloads Function INIRead(ByVal INIPath As String, _
        ByVal SectionName As String, ByVal KeyName As String) As String
            ' overload 1 assumes zero-length default
            Return INIRead(inipath, sectionname, KeyName, "")
        End Function

        Public Overloads Function INIRead(ByVal INIPath As String, _
        ByVal SectionName As String) As String
            ' overload 2 returns all keys in a given section of the given file
            Return INIRead(inipath, sectionname, Nothing, "")
        End Function

        Public Overloads Function INIRead(ByVal INIPath As String) As String
            ' overload 3 returns all section names given just path
            Return INIRead(inipath, Nothing, Nothing, "")
        End Function
#End Region

        Public Sub INIWrite(ByVal INIPath As String, ByVal SectionName As String, _
        ByVal KeyName As String, ByVal TheValue As String)
            Call WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
        End Sub

        Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String, _
        ByVal KeyName As String) ' delete single line from section
            Call WritePrivateProfileString(SectionName, KeyName, Nothing, INIPath)
        End Sub

        Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String)
            ' delete section from INI file
            Call WritePrivateProfileString(SectionName, Nothing, Nothing, INIPath)
        End Sub
    End Class
    Public Module IConfig
        Public cfg As New ConfigIO
        Sub ReadAndCheckConfig()

        End Sub
    End Module
    Public Class IniStream

        Private Declare Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileStringA" _
                                (ByVal lpApplicationName As String, _
                                ByVal lpKeyName As String, _
                                ByVal lpString As String, _
                                ByVal lpFileName As String) As Long

        Private Declare Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileStringA" _
                                (ByVal lpApplicationName As String, _
                                ByVal lpKeyName As String, _
                                ByVal lpDefault As String, _
                                ByVal lpReturnedString As String, _
                                ByVal nSize As Long, _
                                ByVal lpFileName As String) As Long

        Public Property Filename As String

        Public Function INIWrite(sSection As String, sKeyName As String, sNewString As String) As Boolean ', sINIFileName As String) As Boolean

            Call WritePrivateProfileString(sSection, sKeyName, sNewString, Filename)
            INIWrite = (Err.Number = 0)
        End Function

        Public Function INIRead(sSection As String, sKeyName As String) As Boolean ' sINIFileName As String) As String
            Dim sRet As String

            sRet = New String(Chr(0), 255)
            INIRead = Left(sRet, GetPrivateProfileString(sSection, sKeyName, "", sRet, Len(sRet), Filename))
        End Function
    End Class
End Namespace
