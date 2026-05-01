Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Text
Public Class Form1
    Dim box As SC1200Container
    Dim di100 As iLoadContainer
    Private WithEvents _dongle As XbeeApiDongle
    Private _dongleResponse As String = String.Empty
    Private _readDone As New ManualResetEventSlim(False)
    Private WithEvents _con As IConnection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim con As New SerialConnection("COM30", 230400)
        'box = New Di1000Container(con)
#If 1 Then
        Dim con As New SerialConnection("COM15", 9600)
        box = New SC1200Container(con, 23)

        ' AddHandler di100.sensor(0).SensorDataReceived, AddressOf SensorDataReceived

        For i = 0 To 11
            AddHandler box.sensor(i).SensorDataReceived, AddressOf SensorDataReceived
            '  Debug.Print(box.sensor(i).ID)
        Next

        ' box.sensor(0).Units.OutputUnits = "g"
        box.StartReading()
#End If
#If 0 Then
        Dim con As New SerialConnection("COM3", 9600)
        di100 = New Di1000Container(con)
        Debug.Print(di100.sensor(0).ID)
        AddHandler di100.sensor(0).SensorDataReceived, AddressOf SensorDataReceived
        di100.StartReading()
#End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'box.StopReading()
        box.StopReading()
    End Sub

    Private Sub SensorDataReceived(ByVal sender As ISensor, ByVal reading As Double)
        Debug.Print(reading)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        _dongle = New XbeeApiDongle("COM16", 9600)
        If Not _dongle.TryOpen() Then Return
        _dongle.Flush(0)
        If Not _dongle.IsApiDongle() Then Return
        _dongle.DiscardInput = True
        _dongle.BroadcastVbCrs()
        _dongle.DiscardInput = False
        '  _dongle.ScanForDevices()
        _dongle.DiscoverNodes()
        Dim midindex = 24
        For Each addr In _dongle.GetSlaveDeviceAddresses
            Dim con As New XbeeApiConnection(_dongle, addr)
            Dim cmd As New SensorCommand("MODEL" & vbCr, SensorCommand.Enum_ResponseType.oneline)
            _dongleResponse = con.GetCommandResponse(cmd)
            If _dongleResponse Like "FCM*" Then

            Else
                cmd.commandText = "MID" & vbCr
                _dongleResponse = con.GetCommandResponse(cmd)
                If _dongleResponse Like "ATT M##*" Then
                    midindex += 1
                    AddHandler con.SensorStringDataReceived, AddressOf _con_SensorStringDataReceived
                    box = New SC1200Container(con, midindex)
                    For i = 0 To 11
                        Debug.Print(i & "--" & box.sensor(i).ID)
                    Next
                    ' box.StartReading()
                End If
            End If
        Next
        '  _dongle.TryClose()
    End Sub

    Private Sub _dongle_DataReceived(sourceAddr As UShort, str As String) Handles _dongle.DataReceived
        _dongleResponse = str
        _readDone.Set()
        ' Debug.Print(str)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If _dongle IsNot Nothing Then
            box.StopReading()
            _dongle.TryClose()
        End If
    End Sub

    Private Sub cmdTare_Click(sender As Object, e As EventArgs) Handles cmdTare.Click
        For i = 0 To 11
            box.Tare(i)
        Next
    End Sub
    Private Sub DataReceived(ByVal con As IConnection, ByVal s As String)
        Debug.Print(s)
    End Sub

    Private Sub _con_SensorStringDataReceived(sender As IConnection, data As String) Handles _con.SensorStringDataReceived
        If Not data.Contains("999") Then
            Debug.Print(data)
        End If
    End Sub
End Class