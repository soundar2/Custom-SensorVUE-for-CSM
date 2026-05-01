Public Class frmUploadToCloud
    Private _fileName As String
    Public Sub New(ByVal fileName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _fileName = fileName
    End Sub

    Private Sub frmUploadToCloud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFileName.Text = _fileName
        lblFileSize.Text = (My.Computer.FileSystem.GetFileInfo(_fileName).Length / 1000).ToString(0.0)
        LinkLabel1.Text = ConfigXml.Instance.cloudBrowserUrl
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If CloudUpload.UploadFile(_fileName, txtDescription.Text.Trim) Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdCredentials_Click(sender As Object, e As EventArgs) Handles cmdCredentials.Click
        Dim frm As New frmSetupCloudAccount()
        frm.ShowDialog()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        cmdOK.Enabled = txtDescription.Text.Length <> 0
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(ConfigXml.Instance.cloudBrowserUrl)
    End Sub
End Class