Option Compare Text
Imports Eval3
Public Class FormulaSensor
    Inherits LsSensor
    Implements IFilterable
    Implements IAlarmable

    Private _sFormula As String = String.Empty
    Private _sFormulaUnits As String = String.Empty
    Private _lstBaseSensor As New List(Of LsSensor)
    Public Overrides Sub StartReading()
        ResetPeakLow()
    End Sub

    Public Overrides Sub StopReading()

    End Sub

    Public Overrides Sub Tare()

    End Sub

    Public Sub New(ByVal ss1 As String, ByVal sFormula As String, ByVal sFormulaUnits As String)
        'this derived sensor needs a name
        'for example stress,energy etc
        IsVirtualDevice = True
        Me.SS1 = ss1
        If Not VerifyFormula(sFormula) Then
            Throw New Exception("Invalid formula")
        Else
            _sFormula = sFormula
            _sFormulaUnits = sFormulaUnits
        End If
        DeviceUnitType = Enum_Device_Unit_Type.Formula
        Me.Units = New Units(LoadVUE.Units.Enum_UNIT_TYPE.none)

        'get a list of sensors used in this formula
        'replace their names by S0,S1 etc
        _lstBaseSensor.Clear()
        For Each s In _gAttachedSensors
            Dim tag As String = "{" & s.SS1 & "}"
            If sFormula.Contains(tag) Then
                _lstBaseSensor.Add(s)
                sFormula = sFormula.Replace(tag, "{" & _lstBaseSensor.Count - 1 & "}")
                sFormula = sFormula.Replace(",", ".")
                AddHandler s.SensorDataReceived, AddressOf BaseSensorDataReceived
            End If
        Next
        '
        'if the formula is just a number say 5 or a numeric expression without any base sensor
        ' for example 5+1 then we still need to fire an event so the formula can be computed
        'in this case we will just base it on the first sensor's data received event
        '
        If _lstBaseSensor.Count = 0 Then
            AddHandler _gAttachedSensors(0).SensorDataReceived, AddressOf BaseSensorDataReceived
        End If

        _sFormula = sFormula

    End Sub
    Private Sub BaseSensorDataReceived(ByVal seqNo As UShort)
        ComputeReading(seqNo)
    End Sub
    Private Sub ComputeReading(seqNo)
        Static ev As New Eval3.Evaluator
        'I myself has to raise an event, so peak and low can be computed on totals for ex
        'and graphs can be drawn
        Dim formula As String = _sFormula
        For i = 0 To _lstBaseSensor.Count - 1
            formula = formula.Replace("{" & i & "}", _lstBaseSensor(i).CurrentReading.ToString())
            formula = formula.Replace(",", ".")
        Next
        If (_lstBaseSensor.Count = 0 OrElse seqNo = _lstBaseSensor.Last.SequenceNo) Then
            CurrentReading = ev.Parse(formula).value
        End If
    End Sub
    Public Sub ResetPeakLow()
    End Sub
    Public Shared Function VerifyFormula(ByVal sFormula As String) As Boolean
        '
        'each sensor in the formula is represented by <X1234>
        '
        sFormula = sFormula.ToLower
        Dim buffer As String = sFormula
        For Each s In _gAttachedSensors
            buffer = buffer.Replace("{" & s.SS1.ToLower & "}", "S" & s.SequenceNo)
        Next
        If buffer.Contains("{") Then
            'some sensor in the formula is missing
            Return False
        Else
            'only connected sensors are in the formula
            'now check if the formula is a valid mathematical formula
            'by replacing the sensors by random values
            Dim r As New Random
            For Each s In _gAttachedSensors
                sFormula = sFormula.Replace("{" & s.SS1.ToLower & "}", "(" & (r.NextDouble * 10).ToString("0.0") & ")")
                sFormula = sFormula.Replace(",", ".")
            Next
            Try
                Dim ev As New Eval3.Evaluator
                Dim ret As Double = ev.Parse(sFormula).value
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Public ReadOnly Property FormulaUnits() As String
        Get
            Return _sFormulaUnits
        End Get
    End Property

End Class
