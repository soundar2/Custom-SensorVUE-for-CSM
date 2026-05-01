Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Text
Public Class RelayScripting
    Public Enum Languages
        VB
        CSharp
    End Enum
    Public Shared Function CompileScript(ByVal vbnetScriptFile As String, ByVal Reference As String) As CompilerResults
        Dim sb As New StringBuilder
        Using sr As New StreamReader(vbnetScriptFile)
            Do
                sb.AppendLine(sr.ReadLine)
            Loop Until sr.EndOfStream
        End Using
        Return CompileScript(sb.ToString, Reference, New Microsoft.VisualBasic.VBCodeProvider())
    End Function
    Public Shared Function CompileScript(ByVal Source As String, ByVal Reference As String, ByVal Language As Languages) As CompilerResults
        Dim provider As CodeDomProvider = Nothing

        Select Case Language
            Case Languages.VB
                provider = New Microsoft.VisualBasic.VBCodeProvider()
            Case Languages.CSharp
                provider = New Microsoft.CSharp.CSharpCodeProvider()
        End Select

        Return CompileScript(Source, Reference, provider)
    End Function

    Public Shared Function CompileScript(ByVal Source As String, ByVal Reference As String, ByVal Provider As CodeDomProvider) As CompilerResults
        Dim params As New CompilerParameters()
        Dim results As CompilerResults

        'Configure parameters
        With params
            .GenerateExecutable = False
            .GenerateInMemory = True
            .IncludeDebugInformation = False
            If Not Reference Is Nothing AndAlso Reference.Length <> 0 Then
                If My.Computer.FileSystem.FileExists(Reference) Then
                    .ReferencedAssemblies.Add(Reference)
                End If
            End If
            .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            .ReferencedAssemblies.Add("System.dll")
        End With

        'Compile
        results = Provider.CompileAssemblyFromSource(params, Source)

        Return results
    End Function

    Public Shared Function FindInterface(ByVal DLL As Reflection.Assembly, ByVal InterfaceName As String) As Object
        Dim t As Type

        'Loop through types looking for one that implements the given interface
        For Each t In DLL.GetTypes()
            If Not (t.GetInterface(InterfaceName, True) Is Nothing) Then
                Return DLL.CreateInstance(t.FullName)
            End If
        Next

        Return Nothing
    End Function
    Public Shared Function VerifyScriptFile(ByVal scriptFile As String) As CompilerResults
        Dim interfaceDllFileName As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "RelayInterface.Dll")
        Dim results As CompilerResults = RelayScripting.CompileScript(scriptFile, interfaceDllFileName)
        Return results
    End Function
End Class
