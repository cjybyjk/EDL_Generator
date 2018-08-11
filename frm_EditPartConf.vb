Imports System.ComponentModel

Public Class frm_EditPartConf
    Private Sub frm_EditPartConf_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        flagPartConf = False
    End Sub

    Private Sub frm_EditPartConf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Int32
        For i = 0 To UBound(part)
            data_Part.Rows.Add()
            With data_Part.Rows(i)
                .Cells(0).Value = part(i).Label
                .Cells(1).Value = part(i).typeGUID
                .Cells(2).Value = part(i).backupIt
                .Cells(3).Value = part(i).bakFile
                .Cells(4).Value = part(i).sparsed
                .Cells(5).Value = part(i).start_Sector
                .Cells(6).Value = part(i).end_Sector
                .Cells(7).Value = part(i).bootable
                .Cells(8).Value = part(i).isReadOnly
            End With
        Next
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim i As Int32
        ReDim part(data_Part.RowCount - 1)
        For i = 0 To UBound(part)
            With data_Part.Rows(i)
                part(i).newLabel = .Cells(0).Value
                part(i).typeGUID = .Cells(1).Value
                part(i).backupIt = .Cells(2).Value
                part(i).bakFile = .Cells(3).Value
                part(i).sparsed = .Cells(4).Value
                part(i).start_Sector = Convert.ToInt64(.Cells(5).Value)
                part(i).end_Sector = Convert.ToInt64(.Cells(6).Value)
                part(i).bootable = .Cells(7).Value
                part(i).isReadOnly = .Cells(8).Value
            End With
        Next
        Me.Close()
    End Sub

    Private Sub data_Part_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data_Part.CellClick
        Select Case e.ColumnIndex
            Case 0
                lbl_Tip.Text = "分区卷标,更改它可能导致一些软件无法找到分区"
            Case 1
                lbl_Tip.Text = "以GUID格式表示的分区类型,请谨慎修改"
            Case 2
                lbl_Tip.Text = "标识是否备份这个分区到img文件,并将它包含在线刷包中"
            Case 3
                lbl_Tip.Text = "分区备份的文件名.如果文件名为空,分区将被强制擦除,并且备份选项将会无效"
            Case 4
                lbl_Tip.Text = "标识是否稀疏化生成的img文件,可以减小占用的空间,但是会增加备份耗时,且仅对ext4分区有效"
            Case 5
                lbl_Tip.Text = "起始扇区,修改时请确保不会超过前一个分区的终止扇区.分区大小计算方法:(终止扇区-起始扇区+1)*扇区大小"
            Case 6
                lbl_Tip.Text = "终止扇区,修改时请确保不会超过后一个分区的起始扇区.分区大小计算方法:(终止扇区-起始扇区+1)*扇区大小"
            Case 7
                lbl_Tip.Text = "标识该分区是否为可引导启动的,相当于PC上的引导分区"
            Case 8
                lbl_Tip.Text = "标识该分区是否为只读的"
        End Select
    End Sub

    Private Sub btn_AddPart_Click(sender As Object, e As EventArgs) Handles btn_AddPart.Click
        Dim i As Int32
        If data_Part.SelectedRows.Count > 0 Then
            i = data_Part.SelectedRows(0).Index + 1
        Else
            i = data_Part.RowCount
        End If
        Dim partLabel As String = InputBox("输入分区的卷标", "新建分区", "NewPart")
        Dim partGUID As String = InputBox("输入分区的类型(GUID)" & vbCrLf & "如果你不知道这是什么，请保持默认", "新建分区", "EBD0A0A2-B9E5-4433-87C0-68B6B72699C7")
        Dim partStartSector As Int64 = 0
        If i > 0 Then partStartSector = Convert.ToInt64(data_Part.Rows(i - 1).Cells(6).Value) + 1
        partStartSector = Convert.ToInt64(InputBox("输入分区的起始扇区" & vbCrLf & "默认值为前一个分区的终止扇区+1", "新建分区", partStartSector))
        Dim partEndSector As Int64 = 0
        If i < data_Part.RowCount - 1 Then partEndSector = Convert.ToInt64(data_Part.Rows(i).Cells(5).Value) - 1
        partEndSector = Convert.ToInt64(InputBox("输入分区的终止扇区" & vbCrLf & "默认值为后一个分区的起始扇区-1", "新建分区", partEndSector))
        Dim partBootable As Boolean = MsgBox("该分区是可引导的吗？", vbYesNo + vbQuestion + vbDefaultButton2 + vbSystemModal, "新建分区") = vbYes
        Dim partReadonly As Boolean = MsgBox("该分区是只读的吗？", vbYesNo + vbQuestion + vbDefaultButton2 + vbSystemModal, "新建分区") = vbYes

        data_Part.Rows.Insert(i, {partLabel, partGUID, False, partLabel & ".img", False, partStartSector, partEndSector, partBootable, partReadonly})
    End Sub

    Private Sub btn_RemovePart_Click(sender As Object, e As EventArgs) Handles btn_RemovePart.Click
        Dim flagMax As Boolean
        If data_Part.SelectedRows.Count > 0 Then
            Dim sRow As DataGridViewRow = data_Part.SelectedRows(0)
            If Not sRow.IsNewRow Then
                flagMax = False
                If MsgBox("删除选中的分区 " & sRow.Cells(0).Value & " 吗？" & vbCrLf &
                          "这个操作不能撤销！",
                          vbYesNo + vbExclamation, "删除分区") = MsgBoxResult.Yes Then
                    If sRow.Index > 0 Then
                        If MsgBox("要扩大前一个分区吗？ " & vbCrLf &
                          "将会把前一个分区的终止扇区设为选中分区的终止扇区",
                          vbYesNo + vbQuestion, "扩大分区") = MsgBoxResult.Yes Then
                            data_Part.Rows(sRow.Index - 1).Cells(6).Value = sRow.Cells(6).Value
                            flagMax = True
                        End If
                    End If
                    If sRow.Index < data_Part.RowCount - 1 And Not flagMax Then
                        If MsgBox("要扩大后一个分区吗？ " & vbCrLf &
                          "将会把后一个分区的起始扇区设为选中分区的起始扇区",
                          vbYesNo + vbQuestion, "扩大分区") = MsgBoxResult.Yes Then
                            data_Part.Rows(sRow.Index + 1).Cells(5).Value = sRow.Cells(5).Value
                            flagMax = True
                        End If
                    End If
                    data_Part.Rows.Remove(sRow)
                End If
            End If
            data_Part.Sort(data_Part.Columns(5), ListSortDirection.Ascending)
        End If
    End Sub
End Class