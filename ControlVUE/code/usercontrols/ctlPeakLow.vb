Imports com.loadstar.utility.Utility
Public Class ctlPeakLow
    Event ResetPeakLow_Click()
    Public Sub Reset()
        txtPeakLoad.Clear()
        txtLowLoad.Clear()
    End Sub

    Private Sub ctlPeakLow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetToolTip(cmdResetPeakLow, "Reset Peak/Low")
        Reset()
    End Sub
    Public WriteOnly Property PeakText() As String
        Set(ByVal value As String)
            txtPeakLoad.Text = value
        End Set
    End Property
    Public WriteOnly Property LowText() As String
        Set(ByVal value As String)
            txtLowLoad.Text = value
        End Set
    End Property
    Private Sub cmdResetPeakLow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdResetPeakLow.Click
        Reset()
        RaiseEvent ResetPeakLow_Click()
    End Sub
End Class
