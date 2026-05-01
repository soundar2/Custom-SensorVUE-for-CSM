Imports System.Reflection
Public Class frmSplashImage

    Private Sub frmSplashImage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True
        Me.Text = clsGlobals.GetProductNameAndVersion()
        If clsGlobals.IsRunningControlVue() Then
            picSchematic.Image = My.Resources.controlvue_frontend
        ElseIf clsGlobals.IsRunningLV1000 OrElse clsGlobals.IsRunningLV4000 Then
            picSchematic.Image = My.Resources.loadvue_frontend
        Else
            picSchematic.Image = My.Resources.sensorvue_frontend
        End If
#If Mock = True Then
        Timer1.Interval = 100
#End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class