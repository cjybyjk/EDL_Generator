Module mod_Data
    Public adbExe As String = Application.StartupPath & "\tools\adb.exe"
    Public sparseExe As String = Application.StartupPath & "\tools\img2simg.exe"
    Public pToolExe As String = Application.StartupPath & "\tools\ptool.exe"
    Public sgdiskBin As String = Application.StartupPath & "\tools\sgdisk"
    Public flagPartConf As Boolean = False
    Public part() As Partition
    Public strPartNames(,) As String = {
        {"fsc", ""}, {"ssd", ""}, {"modemst#", ""}, {"bk#", ""}, {"bk##", ""}, {"DDR", ""}, {"fsg", ""},
        {"sec", ""}, {"devinfo", ""}, {"userstore", ""}, {"misc", ""}, {"keystore", ""}, {"config", ""},
        {"persistent", ""}, {"dbi", ""}, {"cache", ""}, {"apps_log", ""}, {"dpo", ""}, {"apdp", ""},
        {"msadp", ""}, {"mdtpsecapp", ""}, {"toolsfv", ""}, {"dip", ""}, {"sti", ""}, {"mdtp", ""},
        {"last_parti", ""}, {"sbl1", "sbl1.mbn"}, {"rpm", "rpm.mbn"}, {"tz", "tz.mbn"}, {"modem", "NON-HLOS.bin"}, {"hyp", "hyp.mbn"},
        {"aboot", "emmc_appsboot.mbn"}, {"logfs", "logfs_ufs.bin"}, {"xbl", "xbl.elf"}, {"devcfg", "devcfg.mbn"}, {"pmic", "pmic.elf"}, {"keymaster", "keymaster.mbn"},
        {"cmnlib", "cmnlib.bin"}, {"cmnlib64", "cmnlib64.mbn"}, {"storsec", "storsec.mbn"}, {"bluetooth", "BTFM.bin"}, {"dsp", "adspso.bin"}, {"limits", "dummy.img"}
    }

    Public strNoBakParts() As String = {"userdata"}
    Public strBootable() As String = {"sbl1"}
    Public strNoReadOnly() As String = {
        "switch", "ssd", "keystore", "frp", "misc", "logfs",
        "oops", "persist", "recovery", "cache", "userdata", "fsc",
        "modemst#", "bk#", "bk##", "sbl#", "rpm", "hyp",
        "userstore", "cache", "config", "oem", "persistent", "countrycode"}
    Public sectorSize As Int64

    Public Structure Partition
        Dim Label As String
        Dim typeGUID As String
        Dim sparsed As Boolean
        Dim bootable As Boolean
        Dim isReadOnly As Boolean
        Dim bakFile As String
        Dim backupIt As Boolean
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

    Public Function selectBackupName(strPartName As String) As String
        Dim i As Int32
        For i = 0 To UBound(strPartNames, 1)
            If strPartName Like strPartNames(i, 0) Or strPartName Like strPartNames(i, 0) & "bak" Then Return strPartNames(i, 1)
        Next
        Return strPartName & ".img"
    End Function

    Public Function selectReadOnly(strPartName As String) As Boolean
        Dim i As Int32
        For i = 0 To UBound(strNoReadOnly)
            If strPartName Like strNoReadOnly(i) Or strPartName Like strNoReadOnly(i) & "bak" Then Return False
        Next
        Return True
    End Function

    Public Function selectBootable(strPartName As String) As Boolean
        Dim i As Int32
        For i = 0 To UBound(strBootable)
            If strPartName Like strBootable(i) Then Return True
        Next
        Return False
    End Function

End Module
