Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class SelectUnitsControl
    Private _units As Units
    Event UnitsChanged(ByVal unitString As String)
    Const CONFIG_PREFIX = "Units-"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub InitUnits(ByVal value As Units)
        _units = value
        mnuUnits.Items.Clear()
        For Each x As String In _units.GetUnitList
            mnuUnits.Items.Add(x)
        Next

        lblUnits.Text = mnuUnits.Items(0).Text
        'read the current units and overwrite
        Dim iniFile As New LvIniFile()
        Try
            lblUnits.Text = iniFile.GetString(value.UnitType.ToString, mnuUnits.Items(0).Text)
        Catch ex As Exception
            lblUnits.Text = mnuUnits.Items(0).Text
        End Try
        RaiseEvent UnitsChanged(lblUnits.Text)
    End Sub
    Public ReadOnly Property SelectedUnits() As String
        Get
            Return lblUnits.Text
        End Get
    End Property

    Private Sub SelectUnitsControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetToolTip(lblUnits, "Change units.")
    End Sub

    Private Sub lblUnits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUnits.Click
        If mnuUnits.Items.Count > 1 Then
            mnuUnits.Show(lblUnits, New System.Drawing.Point(0, 0))
        End If
    End Sub
    Private Sub mnuUnits_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuUnits.ItemClicked
        If lblUnits.Text <> e.ClickedItem.Text Then
            'are there any relays enabled
            Dim relays As List(Of RelayChannel) = (From item In _gAttachedSensors Where item.Units.UnitType = Units.Enum_UNIT_TYPE.relay Select CType(item, RelayChannel)).ToList
            If relays.Any Then
                For Each relay In relays
                    If relay.setting.controlType <> RelaySetting.Enum_Relay_Control_Type.manual Then
                        ShowWarningMessage("If relays are being controlled by these sensors, you must change the relay settings appropriately.")
                        Exit For 'no need to check for other relays
                    End If
                Next
            End If
            lblUnits.Text = e.ClickedItem.Text
            RaiseEvent UnitsChanged(lblUnits.Text)
            Dim iniFile As New LvIniFile()
            iniFile.WriteString(_units.UnitType.ToString, lblUnits.Text)
        End If
    End Sub
    Private _configurationTag As String
End Class
