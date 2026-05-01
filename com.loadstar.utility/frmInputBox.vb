Public Class frmInputBox
    Public answer As String = String.Empty

    Private Sub frmInputBox_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            answer = TextBox1.Text.Trim
        End If
    End Sub
    Private Sub frmInputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.ProductName
    End Sub

    Public Sub New(ByVal prompt As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Label1.Text = prompt
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cmdOK.Enabled = (TextBox1.Text.Trim.Length <> 0)
    End Sub
End Class