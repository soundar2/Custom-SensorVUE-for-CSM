Public Class LvNumericTextBox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Private Sub FlashControl(ByVal ctl As System.Windows.Forms.Control)
        Try
            Dim oldColor As System.Drawing.Color
            oldColor = ctl.BackColor
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)

            ctl.BackColor = System.Drawing.Color.Red
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = oldColor
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = System.Drawing.Color.Red
            ctl.Refresh()
            System.Threading.Thread.Sleep(300)

            ctl.BackColor = oldColor
            ctl.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LvNumericTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Dim tb As TextBox = CType(sender, TextBox)
        If tb.Text.Length > 0 AndAlso Not IsNumeric(tb.Text) Then
            FlashControl(tb)
        End If
    End Sub
End Class
