Option Compare Text
Imports System.IO
Imports System.Xml.Serialization
Imports com.loadstar.utility.Utility
Imports com.loadstar.utility
Public Class frmFormulaSensors
    Private _formulaDict As New Dictionary(Of String, Formula)
    Private Shared _xmlFile As String = _gConfigFolder & "\formula.xml"
    Private _inNewFormula As Boolean = False
    Private _isApplied As Boolean = False
    Private Sub frmFormulaSensors_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If tvFormula.SelectedNode IsNot Nothing Then
                If IsOkToSave() Then
                    SaveThisFormula()
                Else
                    e.Cancel = True
                    Return
                End If
            End If
            If _formulaDict.Any Then
                SaveFormulasToXmlFile()
            Else
                My.Computer.FileSystem.DeleteFile(_xmlFile)
            End If
            ShowInfoMessage("Program will be restarted for the settings to take effect.")
            ConfigXml.RestartApplication = True
        End If
    End Sub
    Private Sub frmFormulaSensors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hourglass.Show()
        Dim sensorList = (From s In _gAttachedSensors Where Not (s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Relay OrElse s.DeviceUnitType = LsDevice.Enum_Device_Unit_Type.Formula) Select s.SS1).ToList
        For i = 0 To sensorList.Count - 1
            dgvSensors.Rows.Add()
            dgvSensors.Rows(i).Cells("symbol").Value = "S" & i
            dgvSensors.Rows(i).Cells("sensor").Value = sensorList(i)
        Next
        'load formulas
        _formulaDict = ReadFormulasFromXmlFile()
        If _formulaDict.Any Then
            For Each item In _formulaDict
                tvFormula.Nodes.Add(item.Key)
            Next
            tvFormula.SelectedNode = tvFormula.Nodes(0)
        Else
            cmdNew.PerformClick()
        End If
        Hourglass.Release()
        SetControlStates()
    End Sub

    Private Sub txtFormula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFormula.TextChanged
        picFormulaVerify.Image = IIf(FormulaWithNames(txtFormula.Text.Trim.ToLower).Length <> 0, My.Resources.formula_ok, My.Resources.formula_error)
        SetControlStates()
    End Sub
    Private Sub tvFormula_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvFormula.AfterSelect
        If _inNewFormula Then
            txtName.Clear()
            txtFormula.Clear()
        Else
            LoadThisFormula()
        End If
        SetControlStates()
    End Sub
    Private Function IsOkToSave() As Boolean
        If txtName.Text.Trim.Length = 0 Then
            ShowInfoMessage("Enter a name for this formula")
            Return False
        ElseIf FormulaWithNames(txtFormula.Text).Length = 0 Then
            ShowErrorMessage("Invalid formula.")
        Else
            Return True
        End If
    End Function
    Private Sub LoadThisFormula()
        Dim key = tvFormula.SelectedNode.Text
        txtName.Text = key
        Try
            txtFormula.Text = FormulaWithSymbols(_formulaDict(key).rhs)
            txtUnits.Text = _formulaDict(key).units
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SaveThisFormula()
        Hourglass.Show()
        Dim key = txtName.Text.Trim
        If key.Length = 0 Then Return
        Dim value = FormulaWithNames(txtFormula.Text.Trim)
        Try
            _formulaDict.Remove(key)
            _formulaDict.Add(key, New Formula With {.rhs = value, .units = txtUnits.Text.Trim})
        Catch ex As Exception
        End Try
        tvFormula.SelectedNode.Text = key
        If _inNewFormula Then
            _inNewFormula = False
        End If
        Hourglass.Release()
    End Sub
    Public Shared Function ReadFormulasFromXmlFile() As Dictionary(Of String, Formula)
        Try
            If My.Computer.FileSystem.FileExists(_xmlFile) Then
                Using sr As New StreamReader(_xmlFile)
                    Dim formulas As New List(Of String)
                    Dim x As New XmlSerializer(formulas.GetType)
                    formulas = x.Deserialize(sr)
                    If formulas.Count > 0 Then
                        Dim dict As New Dictionary(Of String, Formula)
                        For Each item In formulas
                            Dim str = item.Split("||".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
                            If FormulaSensor.VerifyFormula(str(1)) Then
                                dict.Add(str(0), New Formula With {.rhs = str(1), .units = str(2)})
                            End If
                        Next
                        Return dict
                    End If
                End Using
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        Finally
        End Try
        Return New Dictionary(Of String, Formula)
    End Function
    Private Sub SaveFormulasToXmlFile()
        Dim formulas As New List(Of String)
        For Each item In _formulaDict
            formulas.Add(item.Key & "||" & item.Value.rhs & "||" & item.Value.units)
        Next

        Using sw = New StreamWriter(_xmlFile)
            Dim st As New XmlSerializer(formulas.GetType)
            st.Serialize(sw, formulas)
        End Using

    End Sub
    Private Function FormulaWithNames(ByVal rhs As String) As String
        If rhs.Trim.Length = 0 Then Return String.Empty
        rhs = rhs.ToLower()
        For i = dgvSensors.Rows.Count - 1 To 0 Step -1
            rhs = rhs.Replace("s" & i, "{" & dgvSensors.Rows(i).Cells("sensor").Value & "}")
        Next
        If FormulaSensor.VerifyFormula(rhs) Then
            Return rhs
        Else
            Return String.Empty
        End If
    End Function
    Private Function FormulaWithSymbols(ByVal rhs As String) As String
        For i = dgvSensors.Rows.Count - 1 To 0 Step -1
            rhs = rhs.Replace("{" & dgvSensors.Rows(i).Cells("sensor").Value & "}", "S" & i)
        Next
        Return rhs
    End Function

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        _inNewFormula = True
        tvFormula.Nodes.Add("<New>")
        tvFormula.SelectedNode = tvFormula.Nodes(tvFormula.Nodes.Count - 1)
        txtName.Clear()
        txtFormula.Clear()
        SetControlStates()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        Dim fName = txtName.Text.Trim
        If fName.Length > 0 Then
            tvFormula.SelectedNode.Text = fName
        End If
        SetControlStates()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        With tvFormula
            If MsgBox("Ok to delete?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                Dim key = tvFormula.SelectedNode.Text.Trim
                If key.Length <> 0 Then
                    _formulaDict.Remove(key)
                End If
                tvFormula.Nodes.Remove(tvFormula.SelectedNode)
            End If
        End With
        SetControlStates()
    End Sub
    Private Sub SetControlStates()
        txtName.Enabled = (tvFormula.SelectedNode IsNot Nothing)
        txtFormula.Enabled = txtName.Text.Trim.Length <> 0
        cmdDelete.Enabled = tvFormula.SelectedNode IsNot Nothing
    End Sub


    Private Sub tvFormula_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvFormula.BeforeSelect
        If tvFormula.SelectedNode Is Nothing Then Return
        If cmdOK.Enabled Then
            If Not IsOkToSave() Then
                e.Cancel = True
            Else
                SaveThisFormula()
            End If
        End If
    End Sub
End Class