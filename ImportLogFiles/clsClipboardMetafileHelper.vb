Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.Globalization
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports com.quinncurtis.chart2dnet
Friend Class clsClipboardMetafileHelper
    Declare Auto Function OpenClipboard Lib "user32.dll" (ByVal hWndNewOwner As IntPtr) As Boolean
    Declare Auto Function CloseClipboard Lib "user32.dll" () As Boolean
    Declare Auto Function EmptyClipboard Lib "user32.dll" () As Boolean
    Declare Auto Function SetClipboardData Lib "user32.dll" (ByVal uFormat As UInt16, ByVal hMem As IntPtr) As IntPtr
    Declare Auto Function CopyEnhMetaFile Lib "gdi32.dll" (ByVal hemfSrc As IntPtr, ByVal hNULL As IntPtr) As IntPtr
    Declare Auto Function DeleteEnhMetaFile Lib "gdi32.dll" (ByVal hemf As IntPtr) As Boolean

    Public Shared Sub CopyChartToClipboardEMF(ByVal hWnd As IntPtr, ByVal component As ChartView)
        Dim g As Graphics = component.CreateGraphics()
        Dim hdc As IntPtr = g.GetHdc()
        Dim mf As Metafile = New Metafile(hdc, EmfType.EmfOnly)
        g.ReleaseHdc(hdc)
        g.Dispose()
        g = Graphics.FromImage(mf)
        If (g IsNot Nothing) Then
            component.ResetPreviousChartObjectList()
            component.RenderingMode = ChartObj.BUFFERED_IMAGE_RENDERING
            component.Draw(g)
            component.RenderingMode = ChartObj.SCREEN_RENDERING
            g.Dispose()
        End If
        PutEnhMetafileOnClipboard(hWnd, mf)
    End Sub
    Private Shared Sub PutEnhMetafileOnClipboard(ByVal hWnd As IntPtr, ByVal mf As Metafile)
        Dim bResult As Boolean = False
        Dim hEMF, hEMF2 As IntPtr
        hEMF = mf.GetHenhmetafile() 'invalidates mf
        If (Not hEMF.Equals(New IntPtr(0))) Then
            hEMF2 = CopyEnhMetaFile(hEMF, New IntPtr(0))
            If (Not hEMF2.Equals(New IntPtr(0))) Then
                If OpenClipboard(hWnd) Then
                    If EmptyClipboard() Then
                        Dim hres As IntPtr = SetClipboardData(14, hEMF2) '/*CF_ENHMETAFILE*/
                        bResult = hres.Equals(hEMF2)
                        CloseClipboard()
                    End If
                End If
            End If
        End If
    End Sub
End Class
