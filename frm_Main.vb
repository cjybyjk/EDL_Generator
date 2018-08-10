Public Class frm_Main
    Private threadEnd As Boolean = False
    Delegate Sub AddLogD(ByVal strText As String, ByVal InfoLevel As String)
    Delegate Sub SetProgD(ByVal value As Int64)
    Delegate Sub SetProgStyleD(ByVal style As ProgressBarStyle)

    Private Sub LockUnlockCtrl(Optional isUnlock As Boolean = True)
        txt_Disk.Enabled = isUnlock
        txt_firehose.Enabled = isUnlock
        txt_Sector.Enabled = isUnlock
        btn_browseFirehose.Enabled = isUnlock
        btn_Go.Enabled = isUnlock
    End Sub

    Private Sub AddLogInvoke(ByVal strText As String, Optional ByVal InfoLevel As String = "I")
        Me.Invoke(New AddLogD(AddressOf AddLog), strText, InfoLevel)
    End Sub

    Private Sub AddLog(ByVal strText As String, ByVal InfoLevel As String)
        If InfoLevel <> "" Then strText = InfoLevel & " " & strText
        If InfoLevel = "V" And combo_LogLevel.SelectedIndex < 4 Then Exit Sub
        If InfoLevel = "D" And combo_LogLevel.SelectedIndex < 3 Then Exit Sub
        If InfoLevel = "I" And combo_LogLevel.SelectedIndex < 2 Then Exit Sub
        If InfoLevel = "W" And combo_LogLevel.SelectedIndex < 1 Then Exit Sub
        txt_Log.SelectionStart = txt_Log.TextLength
        txt_Log.ScrollToCaret()
        txt_Log.AppendText(strText & vbCrLf)
    End Sub

    Private Sub SetProg(ByVal value As Int64)
        prog.Value = value
    End Sub

    Private Sub SetProgMax(ByVal value As Int64)
        prog.Maximum = value
    End Sub

    Private Sub SetProgStyle(ByVal style As ProgressBarStyle)
        prog.Style = style
    End Sub

    Private Sub RunExec()
        Dim savePath As String = dlg_folder.SelectedPath & "\"
        Dim sectorSize As Int32 = Convert.ToInt32(txt_Sector.Text)
        Dim disk() As String = Split(txt_Disk.Text, ";"), diskNum As Int64
        Dim strRuncmdVerbose As String
        Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Marquee)
        AddLogInvoke("启动adb服务...")
        strRuncmdVerbose = RunCommand(adbExe, "kill-server")
        AddLogInvoke(strRuncmdVerbose, "V")
        strRuncmdVerbose = RunCommand(adbExe, "start-server")
        AddLogInvoke(strRuncmdVerbose, "V")
        Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Blocks)
        If InStr(RunCommand(adbExe, "get-state"), "recovery") <= 0 Then
            AddLogInvoke("请连接上设备并重启到recovery模式后再试", "E")
            GoTo pEnd
        End If
        Dim writer As New Xml.XmlTextWriter(savePath & "partition.xml", System.Text.Encoding.GetEncoding("utf-8"))
        With writer
            .Formatting = Xml.Formatting.Indented
            .WriteRaw("<?xml version=""1.0"" ?>")
            .WriteStartElement("configuration")
            .WriteStartElement("parser_instructions")
            .WriteRaw(vbCrLf &
                      "    WRITE_PROTECT_BOUNDARY_IN_KB = 0" & vbCrLf &
                      "    SECTOR_SIZE_IN_BYTES = " & sectorSize & vbCrLf &
                      "    GROW_LAST_PARTITION_TO_FILL_DISK= true" & vbCrLf)
            .WriteEndElement()
        End With
        For diskNum = 0 To UBound(disk)
            AddLogInvoke("读取分区信息... 从 " & disk(diskNum))
            strRuncmdVerbose = RunCommand(adbExe, "shell sgdisk --print " & disk(diskNum))
            AddLogInvoke(strRuncmdVerbose, "V")
            Dim g_result() As String
            Dim num_gResult As Int32, tmp_g_result() As String, flagStartAdd As Int64 = 0
            ReDim part(0)
            g_result = Split(strRuncmdVerbose, vbCrLf)
            Me.Invoke(New SetProgD(AddressOf SetProgMax), UBound(g_result))
            For num_gResult = 0 To UBound(g_result)
                Me.Invoke(New SetProgD(AddressOf SetProg), num_gResult)
                If InStr(LCase(g_result(num_gResult)), "start (sector)") > 0 Then
                    flagStartAdd = num_gResult + 1
                    ReDim part(UBound(g_result) - flagStartAdd - 2)
                    Continue For
                End If
                If flagStartAdd > 0 And num_gResult <= UBound(g_result) - 2 Then
                    tmp_g_result = Split(ReplaceRepeatSpace(g_result(num_gResult)), " ")
                    With part(num_gResult - flagStartAdd)
                        .start_Sector = Convert.ToInt64(tmp_g_result(2))
                        .end_Sector = Convert.ToInt64(tmp_g_result(3))
                        '.typeCode = tmp_g_result(6)
                        .Label = tmp_g_result(7)
                        .newLabel = tmp_g_result(7)
                        .CleanIt = selectClean(.Label)
                        If .CleanIt Then
                            .backupIt = False
                        Else
                            .backupIt = selectBackup(.Label)
                        End If
                        .sparsed = False
                        If .backupIt And (tmp_g_result(6) = "8300" Or tmp_g_result(6) = "0700") Then .sparsed = True
                        .isReadOnly = selectReadOnly(.Label)
                        strRuncmdVerbose = RunCommand(adbExe, "shell sgdisk --info=" & num_gResult - flagStartAdd + 1 & " " & disk(diskNum))
                        AddLogInvoke(strRuncmdVerbose, "V")
                        .typeGUID = CutStr(strRuncmdVerbose, "Partition GUID code: ", " (")
                    End With
                    AddLogInvoke("读取到: " & tmp_g_result(1) &
                           " ,Label: " & tmp_g_result(7) &
                           " ,type(GUID): " & part(num_gResult - flagStartAdd).typeGUID, "D")
                End If
            Next
            Me.Invoke(New SetProgD(AddressOf SetProg), 0)

            AddLogInvoke("等待分区编辑...")
            Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Marquee)
            flagPartConf = True
            frm_EditPartConf.Show()
            Do While flagPartConf
                My.Application.DoEvents()
                Threading.Thread.Sleep(5)
            Loop

            AddLogInvoke("开始备份分区... 从 " & disk(diskNum))
            Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Blocks)
            Me.Invoke(New SetProgD(AddressOf SetProgMax), UBound(part))
            Dim i As Int64
            For i = 0 To UBound(part)
                If part(i).isRemoved Or Not part(i).backupIt Or part(i).CleanIt Then
                    AddLogInvoke("跳过 " & part(i).Label, "D")
                    GoTo pEnd1
                End If
                AddLogInvoke("备份 " & part(i).Label, "D")
                strRuncmdVerbose = RunCommand(adbExe,
                           "pull /dev/block/bootdevice/by-name/" & part(i).Label & " """ &
                            savePath & part(i).Label & ".img""")
                AddLogInvoke(strRuncmdVerbose, "V")
                If part(i).sparsed Then
                    AddLogInvoke("尝试稀疏化 " & part(i).Label & ".img", "D")
                    strRuncmdVerbose = RunCommand(sparseExe,
                               """" & savePath & "" & part(i).Label & ".img"" """ &
                               savePath & "" & part(i).Label & "_sparse.img""")
                    AddLogInvoke(strRuncmdVerbose, "V")
                    If CheckFile(savePath & "" & part(i).Label & "_sparse.img") Then
                        IO.File.Delete(savePath & "" & part(i).Label & ".img")
                        IO.File.Move(savePath & "" & part(i).Label & "_sparse.img",
                                 savePath & "" & part(i).Label & ".img")
                    Else
                        AddLogInvoke("稀疏化失败 " & part(i).Label & ".img", "W")
                        part(i).sparsed = False
                    End If
                End If
pEnd1:
                Me.Invoke(New SetProgD(AddressOf SetProg), i)
            Next
            Me.Invoke(New SetProgD(AddressOf SetProg), 0)

            AddLogInvoke("写入 partition.xml,磁盘 " & diskNum)
            With writer
                .WriteStartElement("physical_partition")
                For i = 0 To UBound(part)
                    If part(i).isRemoved Then
                        AddLogInvoke("分区" & part(i).Label & "已标记为需要被移除, 跳过", "D")
                        GoTo pEnd2
                    End If
                    .WriteStartElement("partition")
                    If part(i).Label <> part(i).newLabel Then AddLogInvoke("分区" & i + 1 & " " & part(i).Label & " -> " & part(i).newLabel, "D")
                    .WriteAttributeString("label", part(i).newLabel)
                    .WriteAttributeString("size_in_kb", Convert.ToInt64((part(i).end_Sector - part(i).start_Sector + 1) * sectorSize / 1024))
                    .WriteAttributeString("type", part(i).typeGUID)
                    .WriteAttributeString("bootable", LCase(part(i).bootable))
                    .WriteAttributeString("readonly", LCase(part(i).isReadOnly))
                    If part(i).CleanIt Then
                        AddLogInvoke("设置为擦除" & part(i).Label & "分区", "D")
                        .WriteAttributeString("filename", "")
                    Else
                        .WriteAttributeString("filename", part(i).Label & ".img")
                    End If
                    .WriteEndElement()
pEnd2:
                    Me.Invoke(New SetProgD(AddressOf SetProg), i)
                Next
                .WriteEndElement()
            End With
            Me.Invoke(New SetProgD(AddressOf SetProg), 0)
            Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Marquee)
        Next
        With writer
            .WriteFullEndElement()
            .Close()
        End With

        AddLogInvoke("使用高通方案脚本生成需要的文件...")
        Me.Invoke(New SetProgD(AddressOf SetProgMax), UBound(disk))
        Me.Invoke(New SetProgD(AddressOf SetProg), 0)
        For diskNum = 0 To UBound(disk)
            Me.Invoke(New SetProgD(AddressOf SetProg), diskNum)
            strRuncmdVerbose = RunCommand(pToolExe, "-x """ & savePath & "partition.xml"" -p " & diskNum & " -t """ & Strings.Left(savePath, savePath.Length - 1) & """")
            AddLogInvoke(strRuncmdVerbose, "V")
        Next
        Me.Invoke(New SetProgD(AddressOf SetProg), 0)

        AddLogInvoke("复制firehose到输出文件夹...")
        IO.File.Copy(txt_firehose.Text, savePath & IO.Path.GetFileName(txt_firehose.Text), True)

        Me.Invoke(New SetProgStyleD(AddressOf SetProgStyle), ProgressBarStyle.Blocks)
        AddLogInvoke("完成!")
pEnd:

        SyncLock Threading.Thread.CurrentThread
            threadEnd = True
        End SyncLock
    End Sub

    Private Sub btn_Go_Click(sender As Object, e As EventArgs) Handles btn_Go.Click
        If Trim(txt_Disk.Text) = "" Then
            txt_Disk.Text = "/dev/block/mmcblk0"
            AddLog("未指定磁盘路径,使用默认值!" & vbCrLf, "W")
        End If
        If Trim(txt_Sector.Text) = "" Then
            txt_Sector.Text = "512"
            AddLog("未指定Sector size,使用默认值!" & vbCrLf, "W")
        End If
        If CheckFile(txt_firehose.Text) = False Then
            AddLog("找不到firehose,停止!" & vbCrLf, "E")
            MsgBox("找不到firehose!", MessageBoxIcon.Error)
            Exit Sub
        End If
        dlg_folder.ShowDialog()
        If dlg_folder.SelectedPath <> "" Then
            threadEnd = False
            LockUnlockCtrl(False)
            Dim tmpThread As System.Threading.Thread = New System.Threading.Thread(AddressOf RunExec)
            tmpThread.Start()
            Do While Not threadEnd
                My.Application.DoEvents()
                Threading.Thread.Sleep(5)
            Loop
            LockUnlockCtrl()
        End If
        dlg_folder.SelectedPath = ""
    End Sub

    Private Sub btn_browseFirehose_Click(sender As Object, e As EventArgs) Handles btn_browseFirehose.Click
        dlg_open.ShowDialog()
        If dlg_open.FileName <> "" Then txt_firehose.Text = dlg_open.FileName
        dlg_open.FileName = ""
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo_LogLevel.SelectedItem = combo_LogLevel.Items(3)
    End Sub
End Class
