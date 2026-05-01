Public Class ctRelayCommands
    Const MAX_RELAY_COMMANDS = 50
    Private _ctlCommands(0 To MAX_RELAY_COMMANDS - 1) As ctlRelayCommand
    Private _lstCommand As New List(Of RelayCommand)
    Private _relayChannelIndex As UShort = 0
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        For i = 0 To MAX_RELAY_COMMANDS - 1
            If i = 0 Then
                _ctlCommands(0) = CtlRelayCommand0
                _ctlCommands(i).CommandEnabled = True
            Else
                _ctlCommands(i) = New ctlRelayCommand
                _ctlCommands(i).Left = CtlRelayCommand0.Left
                _ctlCommands(i).Size = CtlRelayCommand0.Size
                _ctlCommands(i).Top = _ctlCommands(i - 1).Bottom
                _ctlCommands(i).Visible = True
                _ctlCommands(i).CommandEnabled = False
                Me.Controls.Add(_ctlCommands(i))
            End If
            _ctlCommands(i).Initialize(i)
        Next
    End Sub

    Public WriteOnly Property Units() As String
        Set(ByVal value As String)
            If Not Me.DesignMode Then
                For Each ctl As ctlRelayCommand In _ctlCommands
                    If ctl IsNot Nothing Then
                        ctl.Units = value
                    End If
                Next
            End If
        End Set
    End Property


    Public Property CommandList() As List(Of RelayCommand)
        Get
            If Not Me.DesignMode Then
                Dim lst As New List(Of RelayCommand)
                For i = 0 To MAX_RELAY_COMMANDS - 1
                    If _ctlCommands(i).CommandEnabled Then
                        lst.Add(_ctlCommands(i).ReadSetting())
                    Else
                        Exit For
                    End If
                Next
                Return lst
            End If
            Return Nothing
        End Get
        Set(ByVal lst As List(Of RelayCommand))
            If Not Me.DesignMode Then
                Me.ScrollToControl(_ctlCommands(0))
                For i = 0 To _ctlCommands.Count - 1
                    _ctlCommands(i).Clear()
                    _ctlCommands(i).CommandEnabled = False
                Next
                If lst IsNot Nothing Then
                    For i = 0 To lst.Count - 1
                        _ctlCommands(i).WriteSetting(lst(i))
                        _ctlCommands(i).CommandEnabled = True
                    Next
                End If
            End If
        End Set
    End Property
    Public ReadOnly Property CommandEnabled(ByVal index As UShort)
        Get
            If Not Me.DesignMode Then
                Return _ctlCommands(index).CommandEnabled
            Else
                Return False
            End If
        End Get
    End Property
    Public Sub Clear()
        For i = 0 To _ctlCommands.Count - 1
            _ctlCommands(i).Clear()
        Next
    End Sub
    Private Function ReadSetting(ByVal cmdIndex As UShort) As RelayCommand
        Return _ctlCommands(cmdIndex).ReadSetting
    End Function
    Private Sub WriteSetting(ByVal cmdIndex As UShort, ByVal cmd As RelayCommand)
        _ctlCommands(cmdIndex).WriteSetting(cmd)
    End Sub
End Class
