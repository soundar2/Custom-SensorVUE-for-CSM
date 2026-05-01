Option Infer On
Option Compare Text
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Public Class WiFi
    Event ProgressMessage(ByVal msg As String)
    Public Shared Function IsValidIpAddress(ByVal addr As String) As Boolean
        Dim ipRegEx As Regex = New Regex("^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$")
        Return ipRegEx.IsMatch(addr)
    End Function
    Public Shared Function IsValidMacAddress(ByVal addr As String) As Boolean
        '6 x 2 hexadecimals separated by a dash or colon
        If addr = "ff-ff-ff-ff-ff-ff" Then Return False
        Dim macRegEx As Regex = New Regex("^([a-fA-F0-9]{2}(\-|:)){5}[a-fA-F0-9]{2}$")
        Return macRegEx.IsMatch(addr)
    End Function
    Private Shared Function GetARPResult() As String
        Dim p As Process = Nothing
        Dim output As String = String.Empty
        Try
            Dim inf As New ProcessStartInfo()
            inf.FileName = "arp"
            inf.Arguments = "-a"
            inf.CreateNoWindow = True
            inf.RedirectStandardOutput = True
            inf.UseShellExecute = False
            p = Process.Start(inf)
            output = p.StandardOutput.ReadToEnd()
            p.Close()
        Catch ex As Exception
            Throw New Exception("Error retrieving 'arp -a' results")
        Finally
            If p IsNot Nothing Then
                p.Close()
            End If
        End Try
        Return output
    End Function

    Public Shared Function GetAllIpAddressesOnSubnet(ByVal gatewayAddress As String, ByVal startSuffix As UShort, ByVal stopSuffix As UShort) As List(Of String)
        Trace.Assert(startSuffix >= 1 AndAlso stopSuffix <= 254 AndAlso startSuffix <= stopSuffix, "Invalid IP address range for GetAllIpAddressesOnSubnet")
        Dim pingBag As New Concurrent.ConcurrentBag(Of String)
        If My.Computer.Network.IsAvailable Then
            Dim fromParts(0 To 3) As UInt16
            Dim str() As String = gatewayAddress.Split(".")
            If str.Length = 4 Then
                For i = 0 To 3
                    fromParts(i) = Val(str(i))
                Next

                '====== Run tasks in parallel
                Dim thList As New List(Of Thread)
                For i = startSuffix To stopSuffix
                    Dim th = New Thread(Sub(address As String)
                                            If My.Computer.Network.Ping(address) Then
                                                pingBag.Add(address)
                                            End If
                                        End Sub)
                    th.Start(String.Format("{0}.{1}.{2}.{3}", str(0), str(1), str(2), i))
                    thList.Add(th)
                Next
                For Each th In thList
                    th.Join()
                Next
                '======== End parallel

                Return pingBag.ToList()
            End If
        Else
            Utility.ShowErrorMessage("Network connection is not available")
        End If
        Return New List(Of String)
    End Function
    Public Shared Function GetAllMacAndIpAddressesOnSubnet(ByVal gatewayAddress As String, ByVal startSuffix As UShort, ByVal stopSuffix As UShort) As Dictionary(Of String, String)
        Trace.Assert(startSuffix >= 1 AndAlso stopSuffix <= 254 AndAlso startSuffix <= stopSuffix, "Invalid IP address range for GetAllIpAddressesOnSubnet")
        Dim ipList = GetAllIpAddressesOnSubnet(gatewayAddress, startSuffix, stopSuffix)
        Dim dict As New Dictionary(Of String, String)
        If ipList.Count <> 0 Then
            Dim str = GetARPResult().Split(New Char() {vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            For Each arpEntry As String In str
                'is this a valid arp entry
                'it has to be in the format
                ' 192.168.1.74          00-13-e8-f1-48-a7     dynamic
                '
                Dim pieces As String() = arpEntry.Split(New Char() {" "c, vbTab}, StringSplitOptions.RemoveEmptyEntries)
                If pieces.Length = 3 Then
                    Dim macaddress = pieces(1)
                    Dim ipaddress = pieces(0)
                    If IsValidMacAddress(macaddress) AndAlso ipList.Contains(ipaddress) AndAlso Not dict.ContainsKey(macaddress) Then
                        dict.Add(macaddress.ToLower, ipaddress)
                    End If
                End If
            Next
        End If
        Return dict
    End Function
    Public Shared Function GetGatewayIpAddressLlist() As List(Of IPAddress)

        Dim lstAddr As New List(Of IPAddress)

        For Each networkCard As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
            'Debug.Print(networkCard.Name)
            For Each gatewayAddr As GatewayIPAddressInformation In networkCard.GetIPProperties().GatewayAddresses
                If gatewayAddr.Address.ToString <> "0.0.0.0" Then
                    lstAddr.Add(gatewayAddr.Address)
                End If
            Next
        Next
        Return lstAddr
    End Function
End Class
