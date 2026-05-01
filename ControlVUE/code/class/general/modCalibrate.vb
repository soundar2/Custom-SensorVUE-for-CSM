Module modCalibrate
    Public Sub CalibrateLoadCell(ByVal frmParemt As Form)
        'we need to know of the sensor is resistive or capacitive
        Dim exeFile As String = String.Empty
        If TryCast(_gAttachedSensors(0), FcmSensor) IsNot Nothing Then
            exeFile = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "calibrate/calibratefcm.exe")
        Else
            exeFile = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "calibrate/calibrateiload.exe")
        End If

        Try
            If My.Computer.FileSystem.FileExists(exeFile) Then

                MsgBox("Restart LoadVUE after calibration.", MsgBoxStyle.Information)
                frmParemt.Close()
                System.Diagnostics.Process.Start(exeFile, "/UseEnum")
            Else
                MsgBox("Cannot find the calibration program:" & vbCrLf & exeFile, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Module
