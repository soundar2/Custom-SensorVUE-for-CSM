Public Class frmPartDetails
    Private Sub frmPartDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item As String In csm.GetAllPartNames()
            cmbPartNames.Items.Add(item)
        Next
    End Sub
End Class