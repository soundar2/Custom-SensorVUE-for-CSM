Imports com.loadstar.utility.Utility
Public Class DecimalPlacesControl
    Dim _orientation As Enum_Orientation = 1 '0 - Vertical, 1 - Horizontal
    Private _nDecimal As Integer = 2
    Const CONFIG_PREFIX = "Decimals-"
    Public Enum Enum_Orientation
        Horizontal = 0
        Vertical = 1
    End Enum

    Private _configurationTag As String = CONFIG_PREFIX & "Force"
    Event DisplayFormatChanged(ByVal sDisplayFormat As String)
    Public Property ConfigurationTag() As String
        Get
            Return _configurationTag.Replace(CONFIG_PREFIX, "")
        End Get
        Set(ByVal value As String)
            _configurationTag = CONFIG_PREFIX & value
            Dim iniFile As New LvIniFile()
            _nDecimal = iniFile.GetInteger(_configurationTag, _nDecimal)
            RaiseEvent DisplayFormatChanged(DisplayFormat)
        End Set
    End Property

    Public Property NDecimal() As Integer
        Get
            Return _nDecimal
        End Get
        Set(ByVal value As Integer)
            _nDecimal = Math.Max(0, _nDecimal)
        End Set
    End Property
    Public ReadOnly Property DisplayFormat() As String
        Get
            Return "0." & New String("0", _nDecimal)
        End Get
    End Property
    Public Property Orientation() As Enum_Orientation
        Get
            Return _orientation
        End Get
        Set(ByVal value As Enum_Orientation)
            _orientation = value
            If _orientation = Enum_Orientation.Horizontal Then
                cmdDecreaseDecimals.Left = cmdIncreaseDecimals.Right + 1
                cmdDecreaseDecimals.Top = cmdIncreaseDecimals.Top
            Else
                cmdDecreaseDecimals.Left = cmdIncreaseDecimals.Left
                cmdDecreaseDecimals.Top = cmdIncreaseDecimals.Bottom + 1
            End If
        End Set
    End Property

    Private Sub cmdIncreaseDecimals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncreaseDecimals.Click
        If _nDecimal < 8 Then
            _nDecimal += 1
            Dim iniFile As New LvIniFile()
            iniFile.WriteInteger(_configurationTag, _nDecimal)
            RaiseEvent DisplayFormatChanged(DisplayFormat)
        End If
    End Sub

    Private Sub cmdDecreaseDecimals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDecreaseDecimals.Click
        If _nDecimal > 0 Then
            _nDecimal -= 1
            Dim iniFile As New LvIniFile()
            iniFile.WriteInteger(_configurationTag, _nDecimal)
            RaiseEvent DisplayFormatChanged(DisplayFormat)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        com.loadstar.utility.Utility.SetToolTip(Me.cmdIncreaseDecimals, "Increase Decimals")
        SetToolTip(Me.cmdDecreaseDecimals, "Decrease Decimals")
        _nDecimal = 2
    End Sub

End Class
