Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports com.loadstar.utility.Utility
#If Mock = True Then
Public Class AttachedSensors
    Implements IEnumerable(Of LsSensor)

    Public Shared RefreshDevices

    Public Shared Event PortScanning(ByVal portName As String, ByVal baudrate As UInteger)

    Public Shared Event SensorDetected(ByVal sensor As LsSensor)

    Public Shared Event PortError(ByVal errorMessage As String)

    Public Shared Event ProgressMessage(ByVal msg As String)

    Public Shared Sub RefreshPortList()
        _gAttachedSensors.Clear()

        _gAttachedSensors.Add(New FcmSensor("DI-1000", "COM100", 9600))
        _gAttachedSensors.Add(New FcmSensor("DI-1000", "COM101", 9600))

    End Sub









    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of LsSensor) Implements System.Collections.Generic.IEnumerable(Of LsSensor).GetEnumerator
        Return _gAttachedSensors.GetEnumerator
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _gAttachedSensors.GetEnumerator
    End Function

    Public Shared Function Contains(ByVal ss1 As String) As Boolean
        Return (From s In _gAttachedSensors Where s.SS1 = ss1 Select s).Any
    End Function

    Public Shared Function Find(ByVal ss1 As String) As LsSensor
        Return (From s In _gAttachedSensors Where s.SS1 = ss1 Select s).SingleOrDefault
    End Function

End Class
#End If

