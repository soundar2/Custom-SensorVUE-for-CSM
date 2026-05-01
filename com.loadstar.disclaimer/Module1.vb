Module Module1
    Sub main()
        Dim agr As New LicenseAgreement("LV-4000", True)
        MsgBox(agr.AgreeToLicense())
    End Sub
End Module
