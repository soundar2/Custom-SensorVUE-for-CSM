Option Infer On
Option Compare Text
Public Class Hourglass
    Private Shared _counter As UInteger = 0
    Public Shared Sub Show()
        _counter += 1
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    End Sub
    Public Shared Sub Release(Optional ByVal forceToDefault As Boolean = False)
        If forceToDefault Then
            _counter = 0
        ElseIf _counter > 0 Then
            _counter -= 1
        End If
        If _counter = 0 Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub
End Class


