Module mod_FileIO

    Public Function CheckFile(ByVal strPath As String) As Boolean
        CheckFile = IO.File.Exists(strPath) And strPath.Length > 0
    End Function

    Public Function CutStr(ByVal str As String, ByVal Lefts As String, ByVal Rights As String, Optional ByVal start As Integer = 1) As String
        On Error Resume Next
        Dim startp As Integer, Last As Integer
        startp = start
        startp = InStr(startp, str, Lefts) + Len(Lefts)
        Last = InStr(startp + 1, str, Rights)
        If Rights = "" Or Last = 0 Then Last = Len(str) + 1
        CutStr = Mid(str, startp, Last - startp)
    End Function

    Public Function ReplaceRepeatSpace(ByVal str As String)
        Do While InStr(str, "  ") > 0
            str = str.Replace("  ", " ")
        Loop
        Return str
    End Function

End Module
