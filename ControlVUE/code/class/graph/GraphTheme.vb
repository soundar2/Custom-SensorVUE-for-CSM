Imports System.Drawing
Public Class GraphTheme
    Public backgroundColor As Color
    Public textColor As Color
    Public defaultPlotColor As Color
    Public majorGridColor As Color
    Public minorGridColor As Color
    Private _blackBackground As Boolean

    Public Sub New(ByVal blackBackground As Boolean)
        _blackBackground = blackBackground
        If blackBackground Then
            backgroundColor = Color.Black
            textColor = Color.FromArgb(255, 255, 255)
            defaultPlotColor = Color.FromArgb(0, 255, 0)
            majorGridColor = Color.Gray
            minorGridColor = Color.FromArgb(50, 50, 50)
        Else
            backgroundColor = Color.FromArgb(255, 255, 255)
            textColor = Color.Black
            defaultPlotColor = Color.Blue
            majorGridColor = Color.FromArgb(50, 50, 50)
            minorGridColor = Color.Gray
        End If
    End Sub
    Public Function FixColor(ByVal colr As Color) As System.Drawing.Color
        If colr = Color.FromArgb(0, 0, 0) Then
            If _blackBackground Then Return Color.White
        ElseIf colr = Color.FromArgb(255, 255, 255) Then
            If Not _blackBackground Then Return Color.Black
        End If
        Return colr
    End Function
    Public Shared Function GetDefaultColor(ByVal graphIndex As Integer) As System.Drawing.Color

        Static ColorList() As Color = {Color.Blue, Color.DarkGreen, Color.DarkMagenta, Color.Violet, Color.Red, Color.Magenta, Color.Pink, Color.Chocolate, Color.Brown, Color.Orange, Color.LimeGreen, Color.Gold, Color.DarkKhaki, Color.Cyan, Color.Crimson, Color.Pink}
        If graphIndex < ColorList.Count - 1 Then
            Return ColorList(graphIndex)
        Else
            Return Color.Black
        End If
    End Function

End Class
