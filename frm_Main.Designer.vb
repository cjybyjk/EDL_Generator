<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbl_disk = New System.Windows.Forms.Label()
        Me.txt_Disk = New System.Windows.Forms.TextBox()
        Me.txt_Log = New System.Windows.Forms.TextBox()
        Me.prog = New System.Windows.Forms.ProgressBar()
        Me.btn_Go = New System.Windows.Forms.Button()
        Me.dlg_folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.lbl_firehose = New System.Windows.Forms.Label()
        Me.txt_firehose = New System.Windows.Forms.TextBox()
        Me.btn_browseFirehose = New System.Windows.Forms.Button()
        Me.dlg_open = New System.Windows.Forms.OpenFileDialog()
        Me.txt_Sector = New System.Windows.Forms.TextBox()
        Me.lbl_Sector = New System.Windows.Forms.Label()
        Me.combo_LogLevel = New System.Windows.Forms.ComboBox()
        Me.lbl_Tip = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_disk
        '
        Me.lbl_disk.AutoSize = True
        Me.lbl_disk.Location = New System.Drawing.Point(12, 11)
        Me.lbl_disk.Name = "lbl_disk"
        Me.lbl_disk.Size = New System.Drawing.Size(53, 12)
        Me.lbl_disk.TabIndex = 0
        Me.lbl_disk.Text = "磁盘路径"
        '
        'txt_Disk
        '
        Me.txt_Disk.Location = New System.Drawing.Point(71, 7)
        Me.txt_Disk.Name = "txt_Disk"
        Me.txt_Disk.Size = New System.Drawing.Size(273, 21)
        Me.txt_Disk.TabIndex = 1
        Me.txt_Disk.Text = "/dev/block/mmcblk0"
        '
        'txt_Log
        '
        Me.txt_Log.Location = New System.Drawing.Point(11, 102)
        Me.txt_Log.Multiline = True
        Me.txt_Log.Name = "txt_Log"
        Me.txt_Log.ReadOnly = True
        Me.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Log.Size = New System.Drawing.Size(556, 240)
        Me.txt_Log.TabIndex = 5
        Me.txt_Log.Text = "EDL(9008)线刷包制作工具" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "** 注意：在备份过程中请勿断开连接，关机或重启手机 **" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Author: cjybyjk(cjybyjk@gmai" &
    "l.com) @ coolapk,bilibili,github,tieba,xda-developers" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'prog
        '
        Me.prog.Location = New System.Drawing.Point(12, 60)
        Me.prog.MarqueeAnimationSpeed = 50
        Me.prog.Name = "prog"
        Me.prog.Size = New System.Drawing.Size(486, 18)
        Me.prog.TabIndex = 6
        '
        'btn_Go
        '
        Me.btn_Go.Location = New System.Drawing.Point(504, 58)
        Me.btn_Go.Name = "btn_Go"
        Me.btn_Go.Size = New System.Drawing.Size(64, 21)
        Me.btn_Go.TabIndex = 7
        Me.btn_Go.Text = "GO!"
        Me.btn_Go.UseVisualStyleBackColor = True
        '
        'dlg_folder
        '
        Me.dlg_folder.Description = "选择保存位置"
        '
        'lbl_firehose
        '
        Me.lbl_firehose.AutoSize = True
        Me.lbl_firehose.Location = New System.Drawing.Point(10, 37)
        Me.lbl_firehose.Name = "lbl_firehose"
        Me.lbl_firehose.Size = New System.Drawing.Size(137, 12)
        Me.lbl_firehose.TabIndex = 10
        Me.lbl_firehose.Text = "firehose二进制文件路径"
        '
        'txt_firehose
        '
        Me.txt_firehose.Location = New System.Drawing.Point(153, 34)
        Me.txt_firehose.Name = "txt_firehose"
        Me.txt_firehose.Size = New System.Drawing.Size(345, 21)
        Me.txt_firehose.TabIndex = 11
        '
        'btn_browseFirehose
        '
        Me.btn_browseFirehose.Location = New System.Drawing.Point(504, 33)
        Me.btn_browseFirehose.Name = "btn_browseFirehose"
        Me.btn_browseFirehose.Size = New System.Drawing.Size(64, 21)
        Me.btn_browseFirehose.TabIndex = 12
        Me.btn_browseFirehose.Text = "浏览"
        Me.btn_browseFirehose.UseVisualStyleBackColor = True
        '
        'txt_Sector
        '
        Me.txt_Sector.Location = New System.Drawing.Point(451, 8)
        Me.txt_Sector.Name = "txt_Sector"
        Me.txt_Sector.Size = New System.Drawing.Size(47, 21)
        Me.txt_Sector.TabIndex = 13
        Me.txt_Sector.Text = "512"
        '
        'lbl_Sector
        '
        Me.lbl_Sector.AutoSize = True
        Me.lbl_Sector.Location = New System.Drawing.Point(350, 11)
        Me.lbl_Sector.Name = "lbl_Sector"
        Me.lbl_Sector.Size = New System.Drawing.Size(95, 12)
        Me.lbl_Sector.TabIndex = 14
        Me.lbl_Sector.Text = "扇区大小(Bytes)"
        '
        'combo_LogLevel
        '
        Me.combo_LogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_LogLevel.FormattingEnabled = True
        Me.combo_LogLevel.Items.AddRange(New Object() {"Error", "Warning", "Info", "Debug", "Verbose"})
        Me.combo_LogLevel.Location = New System.Drawing.Point(505, 9)
        Me.combo_LogLevel.Name = "combo_LogLevel"
        Me.combo_LogLevel.Size = New System.Drawing.Size(62, 20)
        Me.combo_LogLevel.TabIndex = 15
        '
        'lbl_Tip
        '
        Me.lbl_Tip.AutoSize = True
        Me.lbl_Tip.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Tip.Location = New System.Drawing.Point(12, 84)
        Me.lbl_Tip.Name = "lbl_Tip"
        Me.lbl_Tip.Size = New System.Drawing.Size(551, 12)
        Me.lbl_Tip.TabIndex = 16
        Me.lbl_Tip.Text = "磁盘路径:使用 ;(半角分号) 分隔. 扇区大小: 对于EMMC,一般是512Bytes ; 对于UFS,一般是4096Bytes"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 354)
        Me.Controls.Add(Me.lbl_Tip)
        Me.Controls.Add(Me.combo_LogLevel)
        Me.Controls.Add(Me.lbl_Sector)
        Me.Controls.Add(Me.txt_Sector)
        Me.Controls.Add(Me.btn_browseFirehose)
        Me.Controls.Add(Me.txt_firehose)
        Me.Controls.Add(Me.lbl_firehose)
        Me.Controls.Add(Me.btn_Go)
        Me.Controls.Add(Me.prog)
        Me.Controls.Add(Me.txt_Log)
        Me.Controls.Add(Me.txt_Disk)
        Me.Controls.Add(Me.lbl_disk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_Main"
        Me.Text = "EDL_Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_disk As Label
    Friend WithEvents txt_Disk As TextBox
    Friend WithEvents txt_Log As TextBox
    Friend WithEvents prog As ProgressBar
    Friend WithEvents btn_Go As Button
    Friend WithEvents dlg_folder As FolderBrowserDialog
    Friend WithEvents lbl_firehose As Label
    Friend WithEvents txt_firehose As TextBox
    Friend WithEvents btn_browseFirehose As Button
    Friend WithEvents dlg_open As OpenFileDialog
    Friend WithEvents txt_Sector As TextBox
    Friend WithEvents lbl_Sector As Label
    Friend WithEvents combo_LogLevel As ComboBox
    Friend WithEvents lbl_Tip As Label
End Class
