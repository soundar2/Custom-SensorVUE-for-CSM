Public Class VirtualContainer
    Inherits Container
    Implements ISensorContainer

    Public Enum Enum_VirtualType
        peak
        low
        total
        formula
    End Enum

    Private _virtualType As Enum_VirtualType
    Private _children As New List(Of ISensor)
    Public Sub New()
    End Sub
    Public Function AddVirtualSensor(ByVal baseSensor As ISensor, ByVal vType As IVirtualSensor.Enum_VirtualType) As ISensor
        Select Case vType
            Case IVirtualSensor.Enum_VirtualType.peak
                _children.Add(New PeakSensor(Me, _children.Count, baseSensor))
                Return _children.Last
            Case IVirtualSensor.Enum_VirtualType.low
                _children.Add(New LowSensor(Me, _children.Count, baseSensor))
                Return _children.Last
            Case IVirtualSensor.Enum_VirtualType.average
                _children.Add(New AveragingSensor(Me, _children.Count, baseSensor))
                Return _children.Last
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function AddVirtualSensor(ByVal baseSensors As List(Of ISensor), ByVal vType As IVirtualSensor.Enum_VirtualType) As ISensor
        Select Case vType
            Case IVirtualSensor.Enum_VirtualType.total
                _children.Add(New TotalSensor(Me, Children.Count, baseSensors))
                Return _children.Last
        End Select
        Return Nothing
    End Function
    Public Function AddFormulaSensor(ByVal baseSensors As List(Of ISensor), ByVal sFormulaName As String, ByVal sFormula As String, ByVal sFormulaUnits As String) As ISensor
        _children.Add(New FormulaSensor(Me, Children.Count, baseSensors, sFormulaName, sFormula, sFormulaUnits))
        Return _children.Last
    End Function
    Public Function Children() As List(Of ISensor) Implements ISensorContainer.Children
        Return _children
    End Function

    Public ReadOnly Property ConnectionInfoString As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property ConnectionInfoString(sensorIndex As Integer) As String Implements ISensorContainer.ConnectionInfoString
        Get
            Return _children(sensorIndex).container.ConnectionInfoString
        End Get
    End Property

    Public Event ContainerDisconnected(sender As ISensorContainer) Implements ISensorContainer.ContainerDisconnected

    Public Event DebugMessage(c As ISensorContainer, msg As String) Implements ISensorContainer.DebugMessage

    Public ReadOnly Property Guid As Guid Implements ISensorContainer.Guid
        Get
            Return _guid
        End Get
    End Property

    Public ReadOnly Property NoOfChannels As UShort Implements ISensorContainer.NoOfChannels
        Get
            Return 1
        End Get
    End Property

    Public Function PollAll() As Boolean Implements ISensorContainer.PollAll
        Return True
    End Function

    Public ReadOnly Property sensor(sensorIndex As Integer) As Sensor Implements ISensorContainer.sensor
        Get
            Return _children(sensorIndex)
        End Get
    End Property

    Public Sub SetPollingIntervalMilliSeconds(intervalMSec As Integer) Implements ISensorContainer.SetPollingIntervalMSec

    End Sub

    Public Function StartReading() As Boolean Implements ISensorContainer.StartReading
        'no need to read, base sensors are read
        Return True
    End Function

    Public Function StopReading() As Boolean Implements ISensorContainer.StopReading
        'no need to read, base sensors are read
        Return True
    End Function

    Public Function Tare(sensorIndex As UShort) As Boolean Implements ISensorContainer.Tare
        'no need to tare virtual containers
        Return True
    End Function

    Public Function TareAll() As Boolean Implements ISensorContainer.TareAll
        'no need to tare virtual containers
        Return True
    End Function

    Public Function Type() As ISensorContainer.Enum_ContainerType Implements ISensorContainer.Type
        Return ISensorContainer.Enum_ContainerType.virtual
    End Function
    Public Function GetFirmwareVersion1() As String Implements ISensorContainer.GetFirmwareVersion
        Return String.Empty
    End Function
End Class
