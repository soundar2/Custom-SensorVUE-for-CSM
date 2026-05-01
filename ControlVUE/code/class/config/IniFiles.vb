Option Compare Text
Option Explicit On
Option Strict Off
Public Class LvIniFile
    ' API functions
    Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpDefault As String, _
      ByVal lpReturnedString As System.Text.StringBuilder, _
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer
    Private Declare Ansi Function GetPrivateProfileStringRaw _
   Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
   (ByVal lpApplicationName As String, _
   ByVal lpKeyName As String, ByVal lpDefault As String, _
   ByVal lpReturnedString As String, _
   ByVal nSize As Integer, ByVal lpFileName As String) _
   As Integer
    Private Declare Ansi Function WritePrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal lpString As String, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt _
      Lib "kernel32.dll" Alias "GetPrivateProfileIntA" _
      (ByVal lpApplicationName As String, _
      ByVal lpKeyName As String, ByVal nDefault As Integer, _
      ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString _
      Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
      (ByVal lpApplicationName As Integer, _
      ByVal lpKeyName As Integer, ByVal lpString As Integer, _
      ByVal lpFileName As String) As Integer

    Private Declare Ansi Function GetPrivateProfileSection _
    Lib "kernel32" Alias "GetPrivateProfileSectionA" _
    (ByVal lpAppName As String, ByVal lpReturnedString As String, _
    ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Ansi Function GetPrivateProfileSectionNames _
    Lib "kernel32" Alias "GetPrivateProfileSectionNamesA" _
    (ByVal lpReturnBuffer As String, ByVal nSize As Integer, _
    ByVal lpFileName As String) As Integer

    Private iniFile_ As String
    Private section_ As String

    ' Constructor, accepting a filename
    Public Sub New(ByVal Filename As String)
        iniFile_ = Filename
        section_ = "default"
    End Sub
    Public Sub New(ByVal fileName As String, ByVal section As String)
        'use default options
        Me.New()
        'overwrite with user options
        If fileName <> "" Then
            iniFile_ = fileName
        End If
        section_ = section
    End Sub
    Public Sub New()
        With My.Computer.FileSystem
            Dim appDataPath As String = _gConfigFolder
            If Not .DirectoryExists(appDataPath) Then
                .CreateDirectory(appDataPath)
            End If
            iniFile_ = appDataPath & "\config.ini"
        End With
        section_ = "default"
    End Sub
    ' Read-only filename property
    ReadOnly Property FileName() As String
        Get
            Return iniFile_
        End Get
    End Property
    Public Property Section() As String
        Get
            Return section_
        End Get
        Set(ByVal value As String)
            section_ = value
        End Set
    End Property
    Public Function GetString(ByVal Key As String, Optional ByVal defString As String = "") As String
        ' Returns a string from your INI file
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)
        intCharCount = GetPrivateProfileString(section_, Key, _
           defString, objResult, objResult.Capacity, iniFile_)
        If intCharCount > 0 Then
            GetString = _
               Left(objResult.ToString, intCharCount)
        Else
            GetString = defString
        End If
    End Function

    Public Function GetInteger(ByVal Key As String, Optional ByVal [Default] As Integer = 0) As Integer
        ' Returns an integer from your INI file
        Return GetPrivateProfileInt(section_, Key, [Default], iniFile_)
    End Function
    Public Function GetDouble(ByVal Key As String, Optional ByVal [Default] As Double = 0) As Double
        Try
            Return Convert.ToDouble(GetString(Key, CStr([Default])))
        Catch ex As Exception
            Return 0.0
        End Try

    End Function
    Public Function GetBoolean(ByVal Key As String, Optional ByVal [Default] As Boolean = False) As Boolean
        ' Returns a boolean from your INI file
        Return (GetPrivateProfileInt(section_, Key, IIf([Default] = 0, 0, 1), iniFile_) = 1)
    End Function

    Public Sub WriteString(ByVal Key As String, ByVal Value As String)
        ' Writes a string to your INI file
        WritePrivateProfileString(section_, Key, Value, iniFile_)
        Flush()
    End Sub

    Public Sub WriteInteger(ByVal Key As String, ByVal intValue As Integer)
        ' Writes an integer to your INI file
        WriteString(Key, CStr(intValue))
        Flush()
    End Sub

    Public Sub WriteBoolean(ByVal Key As String, ByVal boolValue As Boolean)
        ' Writes a boolean to your INI file
        WriteInteger(Key, IIf(boolValue = True, 1, 0))
        Flush()
    End Sub

    Public Function GetAllSectionNames() As String()
        Dim ret As Integer
        Dim Buffer As String = New String(" ", 128000)
        ret = GetPrivateProfileSectionNames(Buffer, Len(Buffer), iniFile_)
        If ret <> 0 Then
            Return Left(Buffer, ret - 1).Split((vbCrLf & vbNullChar).ToCharArray)
        Else
            Return Nothing
        End If
    End Function
    Public Function GetAllKeys(Optional ByVal defString As String = "") As String()
        ' Returns a string from your INI file
        Dim ret As Integer
        Dim Buffer As String = New String(" ", 128000)
        ret = GetPrivateProfileStringRaw(section_, vbNullString, _
           defString, Buffer, Len(Buffer), iniFile_)
        If ret > 0 Then
            Return Left(Buffer, ret - 1).Split((vbCrLf & vbNullChar).ToCharArray)
        Else
            Return Nothing
        End If
    End Function
    Public Function DeleteSection() As Integer
        Dim ret As Integer
        ret = WritePrivateProfileString(section_, vbNullString, vbNullString, iniFile_)
        Return ret
    End Function
    Private Sub Flush()
        ' Stores all the cached changes to your INI file
        FlushPrivateProfileString(0, 0, 0, iniFile_)
    End Sub
End Class