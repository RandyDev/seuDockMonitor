Public Class Utilities
    Public Function GetDateTime() As String
        Dim retstr As String = String.Empty
        Dim now As DateTime = DateTime.Now
        Dim strTod As String = Format(now, "h:mm tt")
        Dim strDow As String = WeekdayName(Weekday(Date.Now))
        Dim numDay As String = now.Day.ToString
        Dim strMonth As String = DateAndTime.MonthName(now.Month, False)
        retstr = (strTod & " - " & strDow & " - " & numDay & " " & strMonth)
        Return retstr
    End Function

    Public Function IsValidGuid(ByVal str As String) As Boolean
        If str = "00000000-0000-0000-0000-000000000000" Then
            Return False
        End If
        Dim retbool As Boolean = Nothing
        Dim myguid As Guid = Nothing
        Try
            myguid = New Guid(str)
            retbool = True
        Catch ex As Exception
            retbool = False
        End Try
        Return retbool
    End Function

    Public Function ZeroGuid() As Guid
        Return New Guid("00000000-0000-0000-0000-000000000000")
    End Function

End Class
