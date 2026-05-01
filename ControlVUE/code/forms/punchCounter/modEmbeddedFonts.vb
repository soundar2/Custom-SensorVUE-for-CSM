Option Compare Text
Imports System
Module modEmbeddedFonts
    Private Declare Auto Function AddFontMemResourceEx Lib "Gdi32.dll" _
            (ByVal pbFont As IntPtr, ByVal cbFont As Integer, _
            ByVal pdv As Integer, ByRef pcFonts As Integer) As IntPtr
    Public Function GetFont(ByVal pattern As String) As Drawing.Text.PrivateFontCollection

        Dim FntStrm As IO.Stream
        Dim FntFC As New Drawing.Text.PrivateFontCollection()
        Dim fontResourceName As String = String.Empty

        'locate the font resource based on the name
        For Each name As String In Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames
            'Debug.Print(name)
            If name Like "*" & pattern & "*" Then

                fontResourceName = name
            End If
        Next
        If fontResourceName = String.Empty Then
            Return Nothing
        End If

        'Get the resource stream area where the font is located

        FntStrm = _
    Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(fontResourceName)

        'Load the font off the stream into a byte array
        Dim ByteStrm(CType(FntStrm.Length, Integer)) As Byte
        FntStrm.Read(ByteStrm, 0, Int(CType(FntStrm.Length, Integer)))

        'Allocate some memory on the global heap
        Dim FntPtr As IntPtr = _
            Runtime.InteropServices.Marshal.AllocHGlobal( _
            Runtime.InteropServices.Marshal.SizeOf(GetType(Byte)) * _
                ByteStrm.Length)

        'Copy the byte array holding the font into the allocated memory.
        Runtime.InteropServices.Marshal.Copy(ByteStrm, 0, _
            FntPtr, ByteStrm.Length)

        'Add the font to the PrivateFontCollection
        FntFC.AddMemoryFont(FntPtr, ByteStrm.Length)
        Dim pcFonts As Int32
        pcFonts = 1
        AddFontMemResourceEx(FntPtr, ByteStrm.Length, 0, pcFonts)
        'Free the memory
        Runtime.InteropServices.Marshal.FreeHGlobal(FntPtr)
        Return FntFC
    End Function
End Module
