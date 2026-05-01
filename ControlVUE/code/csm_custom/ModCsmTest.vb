Imports System.IO
Imports System.Text.Json
Imports System.Windows.Controls
Imports Ardalis.GuardClauses
Imports Json.More
Imports Json.Schema
Namespace csm
    Module ModCsmTest
        Public Function LoadTargetCurves() As List(Of TargetCurve)
            Dim json = My.Computer.FileSystem.ReadAllText($"{My.Application.Info.DirectoryPath}\data\csm_custom\target-curves.json")
            Return JsonSerializer.Deserialize(Of List(Of TargetCurve))(json)
        End Function
        Public Function LoadTargetCurveForPart(ByVal partName As String) As TargetCurve
            Dim targetCurve = (From item In LoadTargetCurves() Where item.PartName = partName).SingleOrDefault()
            Guard.Against.Null(targetCurve, $"No target curve found for part {partName}")
            Return targetCurve
        End Function
        Public Function GetAllPartNames() As List(Of String)
            Return (From item In LoadTargetCurves() Select item.PartName Where PartName IsNot Nothing Order By PartName).ToList()
        End Function
    End Module
End Namespace