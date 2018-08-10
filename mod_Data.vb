Module mod_Data
    Public adbExe As String = Application.StartupPath & "\tools\adb.exe"
    Public sparseExe As String = Application.StartupPath & "\tools\img2simg.exe"
    Public pToolExe As String = Application.StartupPath & "\tools\ptool.exe"
    Public flagPartConf As Boolean = False
    Public part() As Partition
    Public strCleanParts() As String = {"fsc", "ssd", "modemst1", "modemst2", "DDR", "fsg",
                                        "sec", "devinfo", "userstore", "misc", "keystore", "config",
                                        "persistent", "dbi", "bk1", "bk2", "bk3", "bk4", "bk5",
                                        "cache", "apps_log"}
    Public strNoBakParts() As String = {"userdata"}
    Public strReadOnly() As String = {"modem", "fsg", "DDR", "sec", "aboot", "abootbak",
                                      "boot", "recovery", "devinfo", "system", "splash"}

    Public Structure Partition
        'Dim number As Int32
        Dim Label As String
        Dim typeGUID As String
        'Dim typeCode As String
        'Dim size As Int64
        Dim sparsed As Boolean
        Dim bootable As Boolean
        Dim isReadOnly As Boolean
        Dim isRemoved As Boolean
        Dim backupIt As Boolean
        Dim CleanIt As Boolean
        Dim newLabel As String
        Dim start_Sector As Int64
        Dim end_Sector As Int64
    End Structure

    Public Function selectBackup(strPartName As String) As Boolean
        Dim i As Int32
        For i = 0 To UBound(strNoBakParts)
            If strPartName = strNoBakParts(i) Then Return False
        Next
        Return True
    End Function

    Public Function selectClean(strPartName As String) As Boolean
        Dim i As Int32
        For i = 0 To UBound(strCleanParts)
            If strPartName = strCleanParts(i) Then Return True
        Next
        Return False
    End Function

    Public Function selectReadOnly(strPartName As String) As Boolean
        Dim i As Int32
        For i = 0 To UBound(strReadOnly)
            If strPartName = strReadOnly(i) Then Return True
        Next
        Return False
    End Function

End Module
