Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.ComponentModel
Imports Multimedia 'need high frequency, high resolution timer
Imports com.loadstar.utility
Imports com.loadstar.utility.Utility
Public Class frmLogOptions

    Private Sub cmdSelectSensors_Click(sender As Object, e As EventArgs) Handles cmdSelectSensors.Click
        Dim frm As New frmSensorsToLog
        frm.ShowDialog()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        ConfigXml.Instance.doNotLogToScreen = chkDontLog.Checked
        ConfigXml.Instance.graphLoggedReadingsOnly = chkGraphLoggedOnly.Checked
        ConfigXml.Instance.udfFieldName = txtUdf.Text.Trim
        ConfigXml.Instance.WriteConfiguration()
    End Sub

    Private Sub frmLogOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.chkDontLog.Checked = ConfigXml.Instance.doNotLogToScreen
        chkGraphLoggedOnly.Checked = ConfigXml.Instance.graphLoggedReadingsOnly
        txtUdf.Text = ConfigXml.Instance.udfFieldName
    End Sub
End Class