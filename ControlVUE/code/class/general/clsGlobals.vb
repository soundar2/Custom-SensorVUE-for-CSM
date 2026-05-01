Imports com.loadstar.utility
Public Class clsGlobals
    Public Shared emailTimeFormat As String = "yyyy/MM/dd hh:mm tt"
    Public Shared _gTimeStampStopwatch As Stopwatch
    Public Shared _gStartTime As Date
    Public Const MAX_FORCE_CHANNELS As Byte = 12
    Public Shared _gAutoStart As Boolean = False
    Public Shared Sub RunTeamviewer()
        Dim fileName = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "teamviewer\TeamViewerQS_Loadstar.exe")
        If My.Computer.FileSystem.FileExists(fileName) Then
            System.Diagnostics.Process.Start(fileName)
        Else
            Utility.ShowErrorMessage("File not found: " & fileName)
        End If
    End Sub
    Public Shared Sub RunPutty()
        Dim fileName = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "putty\putty.exe")
        If My.Computer.FileSystem.FileExists(fileName) Then
            System.Diagnostics.Process.Start(fileName)
        Else
            Utility.ShowErrorMessage("File not found: " & fileName)
        End If
    End Sub
    Public Shared Sub RunDeviceManager()
        System.Diagnostics.Process.Start("devmgmt.msc")
    End Sub
    Public Shared Function GetProductNameAndVersion() As String
        Return String.Format("{0} (v{1})", My.Application.Info.ProductName, My.Application.Info.Version.ToString)
    End Function
    Public Shared Function IsRunningLV1000() As Boolean
        Return My.Application.Info.ProductName.ToLower.Contains("lv-100") 'includes LV-1000
    End Function
    Public Shared Function IsRunningLV4000() As Boolean
        Return My.Application.Info.ProductName.ToLower.Contains("lv-400") 'includes LV-4000
    End Function
    Public Shared Function IsRunningSensorVue() As Boolean
        Return My.Application.Info.ProductName.ToLower.Contains("sensorvue")
    End Function
    Public Shared Function IsRunningControlVue() As Boolean
        Return My.Application.Info.ProductName.ToLower.Contains("controlvue")
    End Function
    Public Shared Function IsRunningBoxerTraining() As Boolean
        Return My.Application.Info.ProductName.ToLower.Contains("boxer")
    End Function
End Class
