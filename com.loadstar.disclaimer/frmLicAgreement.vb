Imports System.IO

Public Class frmLicAgreement
    Public showLicense As Boolean = False
    Private Sub frmLicAgreement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fileName = Path.Combine(My.Application.Info.DirectoryPath, "license\licAgreement.txt")
        If My.Computer.FileSystem.FileExists(fileName) Then
            Using sr = New StreamReader(fileName)
                txtLicense.Text = sr.ReadToEnd()
            End Using
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Me.showLicense = Not CheckBox1.Checked
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
