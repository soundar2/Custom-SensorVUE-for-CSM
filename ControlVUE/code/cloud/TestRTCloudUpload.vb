Imports RestSharp
Imports System.IO
Module TestRTCloudUpload
    Sub Upload()

        Dim uid As String
        Dim ret = RTCloudUpload.Instance.VerifyUploadCredentials("div@loadstarsensors.com", "loadstar453")
        If ret.Item1 = True Then
            uid = ret.Item2
            ' MsgBox(uid)
        Else
            Return
        End If
        Dim sensorsToUpload As New List(Of LsSensor)
        For Each s In _gAttachedSensors
            sensorsToUpload.Add(s)
        Next
        Dim sessionDesc = "Session xyz"
        If (RTCloudUpload.Instance.UploadSensorMetaData(sensorsToUpload, sessionDesc).Item1 = True) Then
            Dim fileName = "C:\Users\sound_000\Desktop\junk\cloud-upload.CSV"
            Using sr = New StreamReader(fileName)
                Dim buffer As String
                Dim k = 0
                While Not sr.EndOfStream And k < 300
                    Dim lstReadings As New List(Of Double)
                    buffer = sr.ReadLine
                    Dim str = buffer.Split(",")
                    Dim elapsedTime = Val(str(1) / 1000)
                    For i = 0 To sensorsToUpload.Count - 1
                        lstReadings.Add(Val(str(i + 2)))
                    Next
                    RTCloudUpload.Instance.QueueSensorReadingForUpload(elapsedTime, lstReadings)
                    k += 1
                End While
                RTCloudUpload.Instance.QueueUploadCompleted()
            End Using
        End If

    End Sub

End Module
