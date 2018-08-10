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
                .Cells(0).Value = i + 1
                .Cells(1).Value = part(i).Label
                .Cells(2).Value = part(i).typeGUID
                .Cells(3).Value = part(i).backupIt
                .Cells(4).Value = part(i).Cleanit
                .Cells(5).Value = part(i).sparsed
                .Cells(6).Value = part(i).start_Sector
                .Cells(7).Value = part(i).end_Sector
                .Cells(8).Value = part(i).bootable
                .Cells(9).Value = part(i).isReadOnly
                .Cells(10).Value = part(i).isRemoved
            End With
        Next
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim i As Int32, j As Int32
        ReDim Preserve part(data_Part.RowCount - 1)
        For i = 0 To UBound(part)
            With data_Part.Rows(i)
                j = Convert.ToInt32(.Cells(0).Value) - 1
                part(j).newLabel = .Cells(1).Value
                part(j).typeGUID = .Cells(2).Value
                part(j).backupIt = .Cells(3).Value
                part(j).CleanIt = .Cells(4).Value
                part(j).sparsed = .Cells(5).Value
                part(j).start_Sector = Convert.ToInt64(.Cells(6).Value)
                part(j).end_Sector = Convert.ToInt64(.Cells(7).Value)
                part(j).bootable = .Cells(8).Value
                part(j).isReadOnly = .Cells(9).Value
                part(j).isRemoved = .Cells(10).Value
            End With
        Next
        Me.Close()
    End Sub

    Private Sub data_Part_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data_Part.CellClick
        Select Case e.ColumnIndex
            Case 0
                lbl_Tip.Text = "分区编号"
            Case 1
                lbl_Tip.Text = "分区卷标,更改它可能导致一些软件无法找到分区"
            Case 2
                lbl_Tip.Text = "以GUID格式表示的分区类型,请谨慎修改"
            Case 3
                lbl_Tip.Text = "标识是否备份这个分区到img文件,并将它包含在线刷包中"
            Case 4
                lbl_Tip.Text = "标识是否擦除这个分区,如果勾选,分区将被强制擦除,并且备份选项将会无效"
            Case 5
                lbl_Tip.Text = "标识是否稀疏化生成的img文件,可以减小占用的空间,但是会增加备份耗时,且仅对ext4分区有效"
            Case 6
                lbl_Tip.Text = "起始扇区,修改时请确保不会超过前一个分区的终止扇区.分区大小计算方法:(终止扇区-起始扇区+1)*扇区大小"
            Case 7
                lbl_Tip.Text = "终止扇区,修改时请确保不会超过后一个分区的起始扇区.分区大小计算方法:(终止扇区-起始扇区+1)*扇区大小"
            Case 8
                lbl_Tip.Text = "标识该分区是否为可引导启动的,相当于PC上的引导分区"
            Case 9
                lbl_Tip.Text = "标识该分区是否为只读的"
            Case 10
                lbl_Tip.Text = "标识是否删除这个分区. 如果勾选,分区将不会包含在生成的分区表中,它占用的空间可以被其他分区使用"
        End Select
    End Sub

    Private Sub btn_AddPart_Click(sender As Object, e As EventArgs) Handles btn_AddPart.Click
        Dim i As Int64 = data_Part.RowCount
        data_Part.Rows.Add()
        With data_Part.Rows(i)
            .Cells(0).Value = i + 1
            .Cells(1).Value = "NewPart"
            .Cells(2).Value = "EBD0A0A2-B9E5-4433-87C0-68B6B72699C7"
            .Cells(3).Value = False
            .Cells(3).ReadOnly = True
            .Cells(4).Value = False
            .Cells(5).Value = False
            .Cells(5).ReadOnly = True
            .Cells(6).Value = 0
            .Cells(7).Value = 0
            .Cells(8).Value = False
            .Cells(9).Value = False
            .Cells(10).Value = False
        End With
    End Sub
End Class