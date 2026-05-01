Option Compare Text
Public Class FormulaSensor
    Inherits Sensor
    Implements ISensor
    Implements IVirtualSensor

    Private _sFormulaWithIds As String = String.Empty
    Private _sFormulaUnits As String = String.Empty
    Private _lstBaseSensor As New List(Of ISensor)
    Public Sub New(ByVal container As ISensorContainer, ByVal sensorIndex As Integer, ByVal baseSensors As List(Of ISensor), ByVal sFormulaName As String, ByVal formulaWithIds As String, ByVal sFormulaUnits As String)

        MyBase.New(container, sensorIndex)
        'there must be at least one base sensor
        If baseSensors.Count = 0 Then
            Throw (New Exception("No base sensors for the formula sensor."))
        End If

        _lstBaseSensor = baseSensors
        AddHandler _lstBaseSensor(0).SensorDataReceived, AddressOf BaseSensorDataReceived

        Me.ID = sFormulaName 'stress, pressure etc

        '
        'in the formula replace each base sensor's ID with its index
        'into the base sensor array
        '
        'formula in ini file: {DIsP-1234}*2
        'convert it to {S0}*2 etc
        Try
            If formulaWithIds.Length <> 0 AndAlso VerifyFormula(_lstBaseSensor, formulaWithIds) Then
                _sFormulaWithIds = formulaWithIds
                _sFormulaUnits = sFormulaUnits
            End If
        Catch ex As Exception
            Throw New Exception("Invalid formula")
        End Try
    End Sub

    Public Overrides WriteOnly Property CurrentReadingInDeviceUnits As Double
        Set(value As Double)

        End Set
    End Property

    Private Sub BaseSensorDataReceived(sender As ISensor, reading As Double)
        Static ev As New Eval3.Evaluator
        Dim formula As String = _sFormulaWithIds
        For Each s In _lstBaseSensor
            formula = formula.Replace("{" & s.ID.ToLower & "}", s.CurrentReading.ToString())
        Next
        CurrentReading = ev.Parse(formula).value
    End Sub

    Public Property VirtualType As IVirtualSensor.Enum_VirtualType Implements IVirtualSensor.VirtualType
        Get
            Return IVirtualSensor.Enum_VirtualType.total
        End Get
        Set(value As IVirtualSensor.Enum_VirtualType)

        End Set
    End Property
    Public Function VerifyFormula(ByVal lstBaseSensors As List(Of ISensor), ByVal formulaWithIds As String) As Boolean
        '
        'each sensor in the formula is represented by <X1234>
        '
        Dim formulaWithSeq As String = FormulaIdsToSequence(formulaWithIds)

        'only connected sensors are in the formula
        'now check if the formula is a valid mathematical formula
        'by replacing the sensors by random values
        Dim r As New Random
        Dim formulaWithNumers As String = formulaWithSeq
        For Each s In lstBaseSensors
            formulaWithNumers = formulaWithNumers.Replace("{" & s.SequenceNo & "}", "(" & (r.NextDouble * 10).ToString("0.0") & ")")
        Next
        Try
            Dim ev As New Eval3.Evaluator
            Dim ret As Double = ev.Parse(formulaWithNumers).value
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function FormulaIdsToIndex(ByVal formulaWithIds As String) As String
        Dim buffer = formulaWithIds.ToLower
        For i = 0 To _lstBaseSensor.Count - 1
            buffer = buffer.Replace(_lstBaseSensor(i).ID.ToLower, "{s" & i & "}")
        Next
        If buffer.Contains("{") Then
            'one or more old sensor is missing
            Return String.Empty
        Else
            Return buffer
        End If
    End Function
    Public Function FormulaIdsToSequence(ByVal formulaWithIds As String) As String
        Dim buffer = formulaWithIds.ToLower
        For Each s In _lstBaseSensor
            buffer = buffer.Replace(s.ID.ToLower, s.SequenceNo)
        Next
        Return buffer
    End Function
End Class
