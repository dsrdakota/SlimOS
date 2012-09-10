Imports System.Runtime.InteropServices
Public Class IniStream
#Region " API "
    <DllImport("kernel32", CharSet:=CharSet.Ansi)> _
    Private Shared Function GetPrivateProfileString( _
                                                        ByVal lpApplicationName As String, _
                                                        ByVal lpKeyName As String, ByVal lpDefault As String, _
                                                        ByVal lpReturnedString As System.Text.StringBuilder, _
                                                        ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32", CharSet:=CharSet.Ansi)> _
    Private Shared Function WritePrivateProfileString( _
                                                        ByVal lpApplicationName As String, _
                                                        ByVal lpKeyName As String, ByVal lpString As String, _
                                                        ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32", CharSet:=CharSet.Ansi)> _
    Private Shared Function GetPrivateProfileInt( _
                                                        ByVal lpApplicationName As String, _
                                                        ByVal lpKeyName As String, ByVal nDefault As Integer, _
                                                        ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32", CharSet:=CharSet.Ansi)> _
    Private Shared Function FlushPrivateProfileString( _
                                                        ByVal lpApplicationName As Integer, _
                                                        ByVal lpKeyName As Integer, ByVal lpString As Integer, _
                                                        ByVal lpFileName As String) As Integer
    End Function
#End Region

#Region " MEMBER VARIABLES "
    Dim m_fileName As String
#End Region

#Region " CONSTRUCTORS "
    Public Sub New(ByVal FileName As String)
        m_fileName = FileName
    End Sub
#End Region

#Region " PROPERTIES "
    ReadOnly Property FileName() As String
        Get
            Return m_fileName
        End Get
    End Property
#End Region

#Region " PUBLIC FUNCTIONS "
    ''' <summary>
    ''' Return a string value from a key in the ini file
    ''' </summary>
    ''' <param name="Section">The section that the key resides in</param>
    ''' <param name="Key">The key of the value</param>
    ''' <param name="Default">The default value if the key is not present</param>
    ''' <returns>The value of the specified key in the specified section. 
    ''' If the key is not present, the default value is returned.</returns>
    ''' <remarks></remarks>
    Public Function GetString(ByVal Section As String, ByVal Key As String, ByVal [Default] As String) As String
        Dim charCount As Integer
        Dim result As New System.Text.StringBuilder(256)
        charCount = GetPrivateProfileString(Section, Key, [Default], result, result.Capacity, m_fileName)
        If charCount > 0 Then
            GetString = Left(result.ToString, charCount)
        Else
            GetString = ""
        End If
    End Function

    ''' <summary>
    ''' Return a string value from a key in the ini file
    ''' </summary>
    ''' <param name="Section">The section that the key resides in</param>
    ''' <param name="Key">The key of the value</param>
    ''' <param name="Default">The default value if the key is not present</param>
    ''' <returns>The value of the specified key in the specified section. 
    ''' If the key is not present, the default value is returned.</returns>
    ''' <remarks></remarks>
    Public Function GetInteger(ByVal Section As String, ByVal Key As String, ByVal [Default] As Integer) As Integer
        Return GetPrivateProfileInt(Section, Key, [Default], m_fileName)
    End Function

    ''' <summary>
    ''' Return a boolean value from a key in the ini file
    ''' </summary>
    ''' <param name="Section">The section that the key resides in</param>
    ''' <param name="Key">The key of the value</param>
    ''' <param name="Default">The default value if the key is not present</param>
    ''' <returns>The value of the specified key in the specified section. 
    ''' If the key is not present, the default value is returned.</returns>
    ''' <remarks></remarks>
    Public Function GetBoolean(ByVal Section As String, ByVal Key As String, ByVal [Default] As Boolean) As Boolean
        Return CBool(GetPrivateProfileInt(Section, Key, CInt([Default]), m_fileName) = 1)
    End Function

    ''' <summary>
    ''' Writes a string value to the specified key in the specified section
    ''' </summary>
    ''' <param name="Section">The section to write the key to</param>
    ''' <param name="Key">The key to write the value to</param>
    ''' <param name="Value">The string value</param>
    ''' <remarks></remarks>
    Public Sub WriteString(ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, m_fileName)
        Flush()
    End Sub

    ''' <summary>
    ''' Writes a integer value to the specified key in the specified section
    ''' </summary>
    ''' <param name="Section">The section to write the key to</param>
    ''' <param name="Key">The key to write the value to</param>
    ''' <param name="Value">The integer value</param>
    ''' <remarks></remarks>
    Public Sub WriteInteger(ByVal Section As String, ByVal Key As String, ByVal Value As Integer)
        WriteString(Section, Key, CStr(Value))
        Flush()
    End Sub

    ''' <summary>
    ''' Writes a boolean value to the specified key in the specified section
    ''' </summary>
    ''' <param name="Section">The section to write the key to</param>
    ''' <param name="Key">The key to write the value to</param>
    ''' <param name="Value">The boolean value</param>
    ''' <remarks></remarks>
    Public Sub WriteBoolean(ByVal Section As String, ByVal Key As String, ByVal Value As Boolean)
        WriteString(Section, Key, CStr(CInt(Value)))
        Flush()
    End Sub

    ''' <summary>
    ''' Determines whether a Name or Value exists.
    ''' </summary>
    ''' <param name="Name">
    ''' </param>
    ''' <param name="Section">
    ''' </param>
    ''' <returns>True if the Name/Value Exists, False otherwise.</returns>
    ''' <remarks></remarks>
    Public Function NameExists(ByVal Section As String, ByVal Name As Object) As Boolean
        Dim n As String = CType(Name, String)
        If GetString(Section, n, "") = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Deletes a section.
    ''' </summary>
    ''' <param name="Section">The section name to remove.</param>
    ''' <remarks></remarks>
    Public Sub DeleteSection(ByVal Section As String)
        'vbNullString
        'WritePrivateProfileString "theName", Null, Null, "filePath"
        WritePrivateProfileString(Section, CType(vbNullString, String), CType(vbNullString, String), m_fileName)
        Flush()
    End Sub
    ''' <summary>
    ''' Deletes a key fro mthe specified section.
    ''' </summary>
    ''' <param name="Section">The section name.</param>
    ''' <param name="Key">The key to remove.</param>
    ''' <remarks></remarks>
    Public Sub DeleteKey(ByVal Section As String, ByVal Key As String)
        WritePrivateProfileString(Section, Key, CType(vbNullString, String), m_fileName)
        Flush()
    End Sub
    ''' <summary>
    ''' Flushes the ini file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Flush()
        'FlushPrivateProfileString(0, 0, 0, m_fileName)
    End Sub
#End Region
End Class
