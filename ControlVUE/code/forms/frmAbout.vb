Option Compare Text
Option Explicit On
Option Strict Off
Imports System.Reflection
Imports System.Text
Public Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim version As StringBuilder = New StringBuilder("Version: " + My.Application.Info.Version.ToString)


#If BuildRelayControl = 1 Then
        version.Append(".RL")
#End If
        If clsGlobals.MAX_FORCE_CHANNELS = 1 Then
            version.Append(".SCH")
        End If
        lblVersion.Text = version.ToString
        Me.Text = "About " & My.Application.Info.ProductName
    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.loadstarsensors.com")
    End Sub
End Class