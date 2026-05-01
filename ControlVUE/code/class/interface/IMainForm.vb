Imports System.Windows.Forms
Public Interface IMainForm
    ReadOnly Property lblLogging As ToolStripLabel
    ReadOnly Property lblLogFileSize As ToolStripLabel
    ReadOnly Property mnuRelaySettings As ToolStripMenuItem
    ReadOnly Property mnuRelaySettings2 As ToolStripMenuItem
    ReadOnly Property mnuGraphOptions As ToolStripMenuItem
    ReadOnly Property cmdZoom As ToolStripButton
    ReadOnly Property cmdStart As ToolStripButton
    ReadOnly Property cmdStop As ToolStripButton
    ReadOnly Property cmdTare As ToolStripButton
End Interface
