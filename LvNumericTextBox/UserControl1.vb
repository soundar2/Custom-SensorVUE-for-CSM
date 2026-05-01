Public Class LvNumericTextBox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LvNumericTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub LvNumericTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If InStr("-.0123456789eE", e.KeyChar) > 0 OrElse Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class
