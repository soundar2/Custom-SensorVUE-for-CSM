Option Compare Text

Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class ctlFilter
    Event NameChanged(ByVal name As String)
    Public Function IsOkToSave() As Boolean
        If txtName.Text.Trim.Length = 0 Then
            FlashControl(txtName)
            Return False
        ElseIf cmbFilterType.Text.ToLower.Contains("median") Then
            Dim v As Integer = udWindowSize.Value
            If v < 3 Or v Mod 2 = 0 Then
                Utility.ShowErrorMessage("For median filter, window size must odd and >= 3")
                Return False
            End If
        End If
        Return True
    End Function
    Public Sub ClearFilterSettings()
        txtName.Text = String.Empty
        udWindowSize.Value = 1
        cmbSensor.SelectedIndex = 0
        cmbFilterType.SelectedIndex = 0
        txtJumpThreshold.Text = 0
    End Sub
    Public Sub LoadFilterSettings(ByVal filt As FilterSensor.FilterSensorSetting)
        ClearFilterSettings()
        With filt
            txtName.Text = .name
            cmbSensor.Text = filt.baseSensorSs1
            Select Case .filterType
                Case FilterSensor.Enum_Filter_Type.average
                    cmbFilterType.SelectedIndex = 0
                Case FilterSensor.Enum_Filter_Type.median
                    cmbFilterType.SelectedIndex = 1
                Case Else
                    cmbFilterType.SelectedIndex = -1
            End Select
            udWindowSize.Maximum = ConfigXml.Instance.maxFilterWindowSize
            udWindowSize.Value = .windowSize
            txtJumpThreshold.Text = .jumpThreshold.ToString("0.000")
        End With
    End Sub
    Public Sub SaveFilterSettings(ByVal filt As FilterSensor.FilterSensorSetting)
        Hourglass.Show()
        With filt
            .name = txtName.Text.Trim
            .baseSensorSs1 = cmbSensor.Text
            Select Case cmbFilterType.SelectedIndex
                Case 1
                    .filterType = FilterSensor.Enum_Filter_Type.median
                Case Else
                    .filterType = FilterSensor.Enum_Filter_Type.average
            End Select
            .jumpThreshold = Val(txtJumpThreshold.Text.Trim)
            .windowSize = udWindowSize.Value
        End With
        Hourglass.Release()
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub InitControls()
        'populate sensors
        For Each s In _gAttachedSensors
            If TryCast(s, RelayChannel) Is Nothing Then
                cmbSensor.Items.Add(s.SS1)
            End If
        Next
        cmbSensor.SelectedIndex = 0
        udWindowSize.Maximum = ConfigXml.Instance.maxFilterWindowSize
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        RaiseEvent NameChanged(txtName.Text)
    End Sub

    Private Sub ctlFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        udWindowSize.Maximum = ConfigXml.Instance.maxFilterWindowSize
    End Sub
End Class
