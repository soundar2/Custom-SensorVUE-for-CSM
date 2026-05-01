Public Class XBeeChecksum
    Private _sumBytes As Integer = 0
    Public Sub AddByte(ByVal b As Byte)
        _sumBytes += b
    End Sub
    Public Sub AddBytes(ByVal bytes() As Byte)
        For Each b In bytes
            AddByte(b)
        Next
    End Sub
    Public Function ComputeChecksum() As Byte
        Dim checkSum As Integer = 0
        checkSum = &HFF And _sumBytes
        checkSum = &HFF - checkSum
        Return CType(checkSum, Byte)
    End Function
    Public Function ComputeChecksum(ByVal bytes() As Byte, ByVal packetSize As Integer) As Byte
        '
        'To calculate: Not including frame delimiters and length, add all bytes keeping only the lowest 8
        'bits of the result and subtract from 0xFF
        '
        For i = 0 To packetSize - 1
            AddByte(bytes(i))
        Next
        Return ComputeChecksum()
    End Function
    Public Function Verify(ByVal bytes() As Byte, ByVal packetSize As Integer, ByVal checksum As Byte) As Boolean
        '
        'To verify: Add all bytes (include checksum, but not the delimiter and length). If the checksum is
        'correct, the sum will equal 0xFF.
        '
        _sumBytes = 0
        For i = 0 To packetSize - 1
            _sumBytes += bytes(i)
        Next
        _sumBytes += checksum
        Return ((&HFF And _sumBytes) = &HFF)
    End Function
End Class
