Imports com.loadstar.utility
Friend Class frmOverlayGraphs
    Private _blackBackground As Boolean = False
    Private Sub frmOverlayGraphs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = False
        Hourglass.Show()
        Me.CtlQcOverlayTimeGraphs1.Initialize(_blackBackground)
        Me.WindowState = FormWindowState.Maximized
        Hourglass.Release()
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Dim od As New OpenFileDialog
        od.Filter = "Log Files (*.csv)|*.csv"
        od.Multiselect = True
        If od.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each sFile As String In od.FileNames
                'CtlQcOverlayTimeGraphs1.AddSeriesFromFile(sFile)
                Try
                    Dim ovl As New OverlayFile(sFile)
                    For i = 0 To ovl.SeriesCount - 1
                        CtlQcOverlayTimeGraphs1.AddSeries(ovl.SS1(i), ovl.X, ovl.Y(i))
                    Next
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

    Public Sub New(ByVal blackBackground As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _blackBackground = blackBackground
    End Sub
End Class
