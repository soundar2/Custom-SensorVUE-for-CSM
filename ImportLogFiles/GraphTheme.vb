Imports System.Drawing
Friend Class GraphTheme
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
    Public Function FixColor(ByVal colr As Color)
        If colr = Color.FromArgb(0, 0, 0) Then
            If _blackBackground Then Return Color.White
        ElseIf colr = Color.FromArgb(255, 255, 255) Then
            If Not _blackBackground Then Return Color.Black
        End If
        Return colr
    End Function
    Private Shared ColourValues() As String = New String() { _
        "&HFF0000", "&H00FF00", "&H0000FF", "&HFFFF00", "&HFF00FF", "&H00FFFF", "&H000000", _
        "&H800000", "&H008000", "&H000080", "&H808000", "&H800080", "&H008080", "&H808080", _
        "&HC00000", "&H00C000", "&H0000C0", "&HC0C000", "&HC000C0", "&H00C0C0", "&HC0C0C0", _
        "&H400000", "&H004000", "&H000040", "&H404000", "&H400040", "&H004040", "&H404040", _
        "&H200000", "&H002000", "&H000020", "&H202000", "&H200020", "&H002020", "&H202020", _
        "&H600000", "&H006000", "&H000060", "&H606000", "&H600060", "&H006060", "&H606060", _
        "&HA00000", "&H00A000", "&H0000A0", "&HA0A000", "&HA000A0", "&H00A0A0", "&HA0A0A0", _
        "&HE00000", "&H00E000", "&H0000E0", "&HE0E000", "&HE000E0", "&H00E0E0", "&HE0E0E0" _
}

    Public Shared ReadOnly Property ColorNumber(ByVal index As Integer) As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(ColourValues(index))

        End Get
    End Property
End Class
