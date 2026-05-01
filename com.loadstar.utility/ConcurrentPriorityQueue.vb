Public Class ConcurrentPriorityQueue(Of T)
    Inherits List(Of T)
    Private _lock As New Object
    Public Sub Enqueue(ByVal item As T, Optional ByVal pushToFront As Boolean = False)
        SyncLock _lock
            If pushToFront = True Then
                Me.Insert(0, item)
            Else
                Me.Add(item)
            End If
        End SyncLock
    End Sub
    Public Function Dequeue() As T
        SyncLock _lock
            If Me.Count <> 0 Then
                Dim item As T = Me(0)
                Me.RemoveAt(0)
                Return item
            Else
                Return Nothing
            End If
        End SyncLock
    End Function
    Private Overloads Function Add(ByVal item As T) As T
        MyBase.Add(item)
    End Function
    Public Overloads ReadOnly Property Count() As Integer
        Get
            Return MyBase.Count
        End Get
    End Property
End Class

