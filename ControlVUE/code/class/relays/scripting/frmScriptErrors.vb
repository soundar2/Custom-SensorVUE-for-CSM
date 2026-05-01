Imports System.Text
Public Class frmScriptErrors

    Public Sub New(ByVal sbErrors As StringBuilder)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextBox1.Text = sbErrors.ToString
    End Sub
End Class