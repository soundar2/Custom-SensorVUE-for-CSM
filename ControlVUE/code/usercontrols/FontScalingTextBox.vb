Public Class FontScalingTextBox
    Private _locked As Boolean = False
    Public Property SizingText() As String
        Get
            Return lblHidden.Text
        End Get
        Set(ByVal value As String)
            lblHidden.Text = value
        End Set
    End Property
    Public Overrides Property Text() As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property
    Public ReadOnly Property TextBoxTop() As Integer
        Get
            Return TextBox1.Top
        End Get
    End Property
    Public ReadOnly Property TextBoxHeight() As Integer
        Get
            Return TextBox1.Height
        End Get
    End Property
    Public Property TextAlign() As System.Windows.Forms.HorizontalAlignment
        Get
            Return TextBox1.TextAlign
        End Get
        Set(ByVal value As System.Windows.Forms.HorizontalAlignment)
            TextBox1.TextAlign = value
        End Set
    End Property
    Public Property BackColorTextBox() As System.Drawing.Color
        Get
            Return TextBox1.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            TextBox1.BackColor = value
        End Set
    End Property
    Public Property ForeColorTextBox() As System.Drawing.Color
        Get
            Return TextBox1.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            TextBox1.ForeColor = value
        End Set
    End Property
    Public Property Locked() As Boolean
        Get
            Return _locked
        End Get
        Set(ByVal value As Boolean)
            _locked = value
            TextBox1.ReadOnly = _locked
        End Set
    End Property
    Private Sub FontScalingTextBox_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged

        lblHidden.Font = CType(sender, UserControl).Font
        TextBox1.Font = CType(sender, UserControl).Font
    End Sub

    Private Sub FontScalingTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.ReadOnly = True
        AutoScaleFont()
    End Sub

    Private Sub FontScalingTextBox_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        AutoScaleFont()
    End Sub
    Private Sub DecreaseFontSize()
        Try
            With lblHidden
                Do
                    .Font = New Font(lblHidden.Font.FontFamily, lblHidden.Font.Size - 0.5)
                Loop Until .Width < Me.ClientSize.Width AndAlso .Height < Me.ClientSize.Height
            End With
        Catch ex As System.ArgumentException
        Catch ex2 As Exception
            MsgBox("An error occurred while decreasing font size: " & ex2.Message)
        End Try

    End Sub
    Private Sub IncreaseFontSize()
        Try
            With lblHidden
                Do
                    .Font = New Font(.Font.FontFamily, .Font.Size + 1, TextBox1.Font.Style)
                Loop Until .Width > Me.ClientSize.Width OrElse .Height > Me.ClientSize.Height
            End With
        Catch ex As Exception

        End Try

        DecreaseFontSize()
    End Sub
    Public Sub AutoScaleFont()
        With lblHidden
            If .Width > Me.ClientSize.Width OrElse .Height > Me.ClientSize.Height Then
                DecreaseFontSize()
            ElseIf .Width < Me.ClientSize.Width AndAlso .Height < Me.ClientSize.Height Then
                IncreaseFontSize()
            End If
        End With
        Try
            TextBox1.Font = New Font(TextBox1.Font.FontFamily, lblHidden.Font.Size, TextBox1.Font.Style)
            With TextBox1
                .Top = (Me.ClientSize.Height - .Height) / 2
                .Width = Me.Width
                .Left = 0
            End With
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox1_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.ReadOnlyChanged
        _locked = TextBox1.ReadOnly
    End Sub
End Class
