Imports com.loadstar.utility.Utility
Public Class ctlSensor
    Event Tare_Click(ByVal sender As ctlSensor, ByVal sensorAddress As String)
    Event Poll_Click(ByVal sender As ctlSensor, ByVal sensorAddress As String)
    Private _ss1 As String = String.Empty
    Public Property No() As String
        Get
            Return lblNo.Text
        End Get
        Set(ByVal value As String)
            lblNo.Text = value
        End Set
    End Property
    Public Property SS1() As String
        Get
            Return _ss1
        End Get
        Set(ByVal value As String)
            _ss1 = value
            lblSensorName.Text = _ss1
        End Set
    End Property
    Public WriteOnly Property NameToolTip() As String
        Set(ByVal value As String)
            SetToolTip(lblSensorName, value)
        End Set
    End Property
    Public Overrides Property Text() As String
        Get
            Return txtLoad.Text
        End Get
        Set(ByVal value As String)
            txtLoad.Text = value
        End Set
    End Property
    Public Sub ClearLoad()
        txtLoad.Clear()
    End Sub

    Private Sub ctlSensor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.GroupBox1.Width = Me.Width - 2
    End Sub

    Private Sub mnuTare_Click1(sender As Object, e As EventArgs) Handles mnuTare.Click
        RaiseEvent Tare_Click(Me, _ss1)
    End Sub
End Class
