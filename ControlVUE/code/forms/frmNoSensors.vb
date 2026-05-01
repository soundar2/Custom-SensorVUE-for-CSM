Public Class frmNoSensors

    Private Sub frmNoSensors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        System.Diagnostics.Process.Start("http://www.loadstarsensors.com/assets/manuals/html/trouble-shooting.html")
    End Sub

    Private Sub cmdDeviceManager_Click(sender As Object, e As EventArgs) Handles cmdDeviceManager.Click
        clsGlobals.RunDeviceManager()
    End Sub

    Private Sub cmdPutty_Click(sender As Object, e As EventArgs) Handles cmdPutty.Click
        clsGlobals.RunPutty()
    End Sub

    Private Sub cmdTeamviewer_Click(sender As Object, e As EventArgs) Handles cmdTeamviewer.Click
        clsGlobals.RunTeamviewer()
    End Sub
End Class