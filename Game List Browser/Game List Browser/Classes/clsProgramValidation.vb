Imports System.Management
Public Class clsProgramValidation
    Public Function GetComputerName() As String
        Return System.Net.Dns.GetHostName
    End Function

    Public Function getWindowsVersion() As String
        Return System.Environment.OSVersion.ToString
    End Function

    Public Function getSerialID() As String
        Dim q As New SelectQuery("Win32_bios")
        Dim search As New ManagementObjectSearcher(q)
        Dim info As New ManagementObject

        For Each info In search.Get
            Return info("serialnumber").ToString + ", Bios Version: " & info("version").ToString
        Next
        Return Nothing
    End Function
End Class
