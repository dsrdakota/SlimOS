Option Strict On
Imports System
Imports System.IO
Imports System.IO.Compression

Imports CON = System.Console

Imports System.Net
Imports System.Net.Sockets

Imports Ionic
Imports Ionic.BZip2
Imports Ionic.Crc
Imports Ionic.Zip
Imports Ionic.Zlib

Module wget
    Public Property DownloadFilename As String
    Public Property Filename As String
    Public Property FileSize As Integer
    Public Property DownloadedSize As Integer
    Public Property BufferSize As Integer = 1024 '1KB Buffers

    Dim lpSocket As New System.Net.Sockets.Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.IP)

    'Public wReq
    Sub Init()
        'My.Computer.Network.DownloadFile(DownloadFilename, Filename, "", "", False, 30 Or 100, False)
    End Sub

    Public Sub Main()
        Dim inta As Integer
        Dim strc() As String
        inta = My.Application.CommandLineArgs.Count
        ReDim Preserve strc(inta)
        strc = My.Application.CommandLineArgs.ToArray
        Call _main(inta, strc)
    End Sub

    Public Sub _main(ByVal argc As Integer, ByVal argv() As String) 'This is C/C++ Style ;)

    End Sub

End Module
