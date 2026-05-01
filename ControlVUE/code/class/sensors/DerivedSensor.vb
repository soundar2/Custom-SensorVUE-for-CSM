Public Class DerivedSensor
    Inherits LsSensor
    Implements IDerivedSensor
    Implements IFilterable
    Implements IAlarmable

    Public Enum Enum_Derived_Type
        total
        peak
        low
    End Enum
    Private _derivedType As Enum_Derived_Type
    Private _lstBaseSensors As New List(Of LsSensor)
    Private _peak As Double = Integer.MinValue
    Private _low As Double = Integer.MaxValue
    Public Overrides Sub StartReading()
        ResetPeakLow()
    End Sub

    Public Overrides Sub StopReading()

    End Sub

    Public Overrides Sub Tare()

    End Sub

    Public Sub New(ByVal lstSensor As List(Of LsSensor), ByVal derivedUnitType As Units.Enum_UNIT_TYPE, ByVal derivedType As Enum_Derived_Type)
        IsVirtualDevice = True
        _derivedType = derivedType
        For Each s In lstSensor
            _lstBaseSensors.Add(s)
            AddHandler _lstBaseSensors.Last.SensorDataReceived, AddressOf BaseSensorDataReceived
            AddHandler _lstBaseSensors.Last.Units.OutputUnitsChanged, AddressOf BaseSensorOutputUnitsChanged
            AddHandler _lstBaseSensors.Last.DisplayFormatChanged, AddressOf BaseSensorDisplayFormatChanged
        Next
        Me.Units = New Units(derivedUnitType)
    End Sub
    Public Sub New(ByVal baseSensor As LsSensor, ByVal derivedUnitType As Units.Enum_UNIT_TYPE, ByVal derivedType As Enum_Derived_Type)
        IsVirtualDevice = True
        _derivedType = derivedType
        _lstBaseSensors.Add(baseSensor)
        AddHandler baseSensor.SensorDataReceived, AddressOf BaseSensorDataReceived
        AddHandler baseSensor.Units.OutputUnitsChanged, AddressOf BaseSensorOutputUnitsChanged
        AddHandler baseSensor.DisplayFormatChanged, AddressOf BaseSensorDisplayFormatChanged
        Me.Units = New Units(derivedUnitType)
        ResetPeakLow()
    End Sub
    Private Sub BaseSensorDataReceived(ByVal seqNo As UShort)
        ComputeReading(seqNo)
    End Sub
    Private Sub BaseSensorOutputUnitsChanged(ByVal newOutputUnits As String)
        Select Case _derivedType
            Case Enum_Derived_Type.low, Enum_Derived_Type.peak, Enum_Derived_Type.total
                Me.Units.OutputUnits = newOutputUnits
        End Select
    End Sub
    Private Sub BaseSensorDisplayFormatChanged(ByVal sDisplayFormat As String)
        Me.sDisplayFormat = sDisplayFormat
    End Sub
    Private Sub ComputeReading(ByVal seqNo As Integer)
        Static lock As New Object
        Select Case _derivedType
            Case Enum_Derived_Type.peak
                _peak = Math.Max(_peak, _lstBaseSensors(0).CurrentReading)
                If _peak <> Integer.MinValue Then
                    CurrentReading = _peak
                End If
            Case Enum_Derived_Type.low
                _low = Math.Min(_low, _lstBaseSensors(0).CurrentReading)
                If _low <> Integer.MaxValue Then
                    CurrentReading = _low
                End If
            Case Enum_Derived_Type.total
                'multiple sensors can be accessing this
                SyncLock lock
                    Dim sum As Double = 0
                    For Each s In _lstBaseSensors
                        sum += s.CurrentReading
                    Next
                    If seqNo = _lstBaseSensors.Last.SequenceNo Then
                        CurrentReading = sum
                    End If
                End SyncLock
        End Select
    End Sub
    Public Sub ResetPeakLow() Implements IDerivedSensor.ResetPeakLow
        If _derivedType = Enum_Derived_Type.Peak Then
            _peak = Integer.MinValue
        ElseIf _derivedType = Enum_Derived_Type.low Then
            _low = Integer.MaxValue
        End If
    End Sub

    Public ReadOnly Property DerivedType() As Enum_Derived_Type
        Get
            Return _derivedType
        End Get
    End Property

End Class
