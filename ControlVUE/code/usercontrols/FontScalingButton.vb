Public Class FontScalingButton
    Const MAX_FONT_SIZE = 100
    Shadows Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Property SizingText() As String
        Get
            Return lblHidden.Text.Trim
        End Get
        Set(ByVal value As String)
            lblHidden.Text = " " & value & " "
        End Set
    End Property

    Private Sub FontScalingButton_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        btnDisplay.BackColor = Me.BackColor
    End Sub
    Private Sub FontScalingButton_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        lblHidden.Font = CType(sender, UserControl).Font
        btnDisplay.Font = CType(sender, UserControl).Font
    End Sub

    Private Sub FontScalingButton_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        btnDisplay.ForeColor = Me.ForeColor
    End Sub

    Private Sub FontScalingButton_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoScaleFont()
    End Sub

    Private Sub FontScalingButton_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        AutoScaleFont()
    End Sub
    Private Sub DecreaseFontSize()
        Try
            With lblHidden
                Do
                    .Font = New Font(lblHidden.Font.FontFamily, lblHidden.Font.Size - 0.5)
                Loop Until .Width < 0.95 * Me.ClientSize.Width AndAlso .Height < 0.95 * Me.ClientSize.Height
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub IncreaseFontSize()
        Try
            With lblHidden
                Do
                    .Font = New Font(lblHidden.Font.FontFamily, lblHidden.Font.Size + 0.5)
                Loop Until .Width > Me.ClientSize.Width OrElse .Height > Me.ClientSize.Height
            End With
        Catch ex As Exception

        End Try

        DecreaseFontSize()
    End Sub



    Public Property ButtonText() As String
        Get
            Return btnDisplay.Text
        End Get
        Set(ByVal value As String)
            btnDisplay.Text = value
        End Set
    End Property

    Public Property TextAlign() As System.Drawing.ContentAlignment
        Get
            Return btnDisplay.TextAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            btnDisplay.TextAlign = value
        End Set
    End Property

    Public Sub AutoScaleFont()
        With lblHidden
            If .Width > Me.ClientSize.Width OrElse .Height > Me.ClientSize.Height Then
                DecreaseFontSize()
            ElseIf .Width < Me.ClientSize.Width AndAlso .Height < Me.ClientSize.Height Then
                IncreaseFontSize()
            End If
        End With
        btnDisplay.Font = New Font(btnDisplay.Font.FontFamily, lblHidden.Font.Size, btnDisplay.Font.Style)
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        RaiseEvent Click(Me, e)
    End Sub
End Class
