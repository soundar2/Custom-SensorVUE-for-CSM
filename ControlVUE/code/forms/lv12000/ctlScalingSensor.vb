'Imports com.loadstar.utility.Utility
Public Class ctlScalingSensor

    Friend No As String

    Event Tare_Click(ByVal sender As ctlScalingSensor, ByVal sensorAddress As String)
    Event Poll_Click(ByVal sender As ctlScalingSensor, ByVal sensorAddress As String)
    Private _ss1 As String = String.Empty
    Public Property SS1() As String
        Get
            Return _ss1
        End Get
        Set(ByVal value As String)
            _ss1 = value
            lblSensorName.Text = _ss1
        End Set
    End Property

    Public Property Units() As String
        Get
            Return lblUnits.Text
        End Get
        Set(ByVal value As String)
            lblUnits.Text = value
        End Set
    End Property
    Public WriteOnly Property Reading() As String
        Set(ByVal value As String)
            txtLoad.Text = value
        End Set
    End Property

    Public WriteOnly Property NameToolTip() As String
        Set(ByVal value As String)
            ' SetToolTip(lblSensorName, value) TBD
        End Set
    End Property

    Private Sub ctlScalingSensor_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ctlSensor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' Me.GroupBox1.Width = Me.Width - 2 TBD
    End Sub

    Private Sub mnuTare_Click1(sender As Object, e As EventArgs) Handles mnuTare.Click
        RaiseEvent Tare_Click(Me, _ss1)
    End Sub

    Private _sensor As LsSensor
    Public Property Sensor() As LsSensor
        Get
            Return _sensor
        End Get
        Set(ByVal value As LsSensor)
            _sensor = value
        End Set
    End Property

    Private _textColor As System.Drawing.Color
    Public Property TextColor() As System.Drawing.Color
        Get
            Return _textColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _textColor = value
            txtLoad.ForeColorTextBox = _textColor
            lblSensorName.ForeColor = _textColor
            lblUnits.ForeColor = _textColor
        End Set
    End Property

    Private _backgroundColor As System.Drawing.Color
    Public Property BackgroundColor() As System.Drawing.Color
        Get
            Return _backgroundColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _backgroundColor = value
            txtLoad.BackColorTextBox = value
            txtLoad.BackColor = value
            lblUnits.BackColor = value
            lblSensorName.BackColor = value
            Me.BackColor = value
        End Set
    End Property
    Public WriteOnly Property TextAlign() As Windows.Forms.HorizontalAlignment
        Set(value As Windows.Forms.HorizontalAlignment)
            txtLoad.TextAlign = value
        End Set
    End Property




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtLoad.SizingText = ConfigXml.Instance.totalSizingText
    End Sub
    Public Sub ResizeMe(ByVal opt As String)

        If opt = "hide" Then

            With TableLayoutPanel2
                .SuspendLayout()
                .ColumnStyles(0).Width = 0
                .ColumnStyles(1).Width = 87
                .ColumnStyles(2).Width = 13
                .ResumeLayout()
            End With
        Else

            With TableLayoutPanel2
                .SuspendLayout()
                .ColumnStyles(0).Width = 25
                .ColumnStyles(1).Width = 62
                .ColumnStyles(2).Width = 13
                .ResumeLayout()
            End With
        End If
    End Sub
End Class
