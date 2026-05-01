Imports System.Xml.Serialization
Friend Class OverlayGraphOptions
    Private _title As String = String.Empty
    Public xAxisOptions As New XAxisOptions
    Public y1AxisOptions As New YAxisOptions
    Public y2AxisOptions As New YAxisOptions
    Public showLegend As Boolean = True
    Public showTitle As Boolean = False
    Public showGrid As Boolean = True
    Public showMinorGrid As Boolean = True
    Public cumulativeMode As Boolean = False
    Public graphLoggedReadingsOnly As Boolean = False
    '<XmlIgnore()> Public Shared blackBackground As Boolean = False
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private Shared _graphRefreshMSec As UShort
    Public Shared Property GraphRefreshMSec() As UShort
        Get
            Return _graphRefreshMSec
        End Get
        Set(ByVal value As UShort)
            _graphRefreshMSec = value
        End Set
    End Property


    Private _defaultTitle As String = String.Empty
    Public Property DefaultTitle() As String
        Get
            Return _defaultTitle
        End Get
        Set(ByVal value As String)
            _defaultTitle = value
        End Set
    End Property
    Public Sub New()
    End Sub
End Class
