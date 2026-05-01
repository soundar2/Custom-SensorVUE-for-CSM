Public Class FontScalingLabel
    Const MAX_FONT_SIZE = 100
    Shadows Event Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Property SizingText() As String
        Get
            Return lblHidden.Text
        End Get
        Set(ByVal value As String)
            lblHidden.Text = value
            If lblDisplay.Text.Length <> 0 Then
                AutoScaleFont()
            End If
        End Set
    End Property
    Public Overrides Property Text() As String
        Get
            Return lblDisplay.Text
        End Get
        Set(ByVal value As String)
            lblDisplay.Text = value
        End Set
    End Property
    Public Property LabelText() As String
        Get
            Return lblDisplay.Text
        End Get
        Set(ByVal value As String)
            lblDisplay.Text = value
        End Set
    End Property
    Private Sub FontScalingLabel_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged

        lblHidden.Font = CType(sender, UserControl).Font
        lblDisplay.Font = CType(sender, UserControl).Font
    End Sub

    Private Sub FontScalingLabel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AutoScaleFont()
    End Sub

    Private Sub FontScalingLabel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        AutoScaleFont()
    End Sub
    Private Sub DecreaseFontSize()
        Try
            With lblHidden
                Do
                    .Font = New Font(lblHidden.Font.FontFamily, lblHidden.Font.Size - 0.5)
                Loop Until .Width < Me.ClientSize.Width AndAlso .Height < Me.ClientSize.Height
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
    Public Property TextAlign() As System.Drawing.ContentAlignment
        Get
            Return lblDisplay.TextAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            lblDisplay.TextAlign = value
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
        lblDisplay.Font = New Font(lblDisplay.Font.FontFamily, lblHidden.Font.Size, lblDisplay.Font.Style)
    End Sub

    Private Sub lblDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDisplay.Click
        RaiseEvent Click(Me, e)
    End Sub
End Class
