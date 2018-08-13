<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_EditPartConf
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
        Me.lbl_Warn = New System.Windows.Forms.Label()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.data_Part = New System.Windows.Forms.DataGridView()
        Me.colLabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBak = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSparse = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSecStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSecEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBootable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colReadonly = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lbl_Tip = New System.Windows.Forms.Label()
        Me.btn_AddPart = New System.Windows.Forms.Button()
        Me.btn_RemovePart = New System.Windows.Forms.Button()
        Me.btn_Resize = New System.Windows.Forms.Button()
        CType(Me.data_Part, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Warn
        '
        Me.lbl_Warn.AutoSize = True
        Me.lbl_Warn.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_Warn.Location = New System.Drawing.Point(8, 12)
        Me.lbl_Warn.Name = "lbl_Warn"
        Me.lbl_Warn.Size = New System.Drawing.Size(323, 12)
        Me.lbl_Warn.TabIndex = 0
        Me.lbl_Warn.Text = "警告: 错误地编辑分区可能会使生成的线刷包无法正常使用!"
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(266, 337)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(97, 22)
        Me.btn_Save.TabIndex = 2
        Me.btn_Save.Text = "保存"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'data_Part
        '
        Me.data_Part.AllowUserToAddRows = False
        Me.data_Part.AllowUserToDeleteRows = False
        Me.data_Part.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.data_Part.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLabel, Me.colGUID, Me.colBak, Me.col_File, Me.colSparse, Me.colSecStart, Me.colSecEnd, Me.colBootable, Me.colReadonly})
        Me.data_Part.Location = New System.Drawing.Point(12, 51)
        Me.data_Part.MultiSelect = False
        Me.data_Part.Name = "data_Part"
        Me.data_Part.RowHeadersWidth = 20
        Me.data_Part.RowTemplate.Height = 23
        Me.data_Part.Size = New System.Drawing.Size(605, 280)
        Me.data_Part.TabIndex = 3
        '
        'colLabel
        '
        Me.colLabel.HeaderText = "卷标"
        Me.colLabel.Name = "colLabel"
        Me.colLabel.Width = 70
        '
        'colGUID
        '
        Me.colGUID.HeaderText = "类型(GUID)"
        Me.colGUID.Name = "colGUID"
        Me.colGUID.Width = 140
        '
        'colBak
        '
        Me.colBak.HeaderText = "备份"
        Me.colBak.Name = "colBak"
        Me.colBak.Width = 40
        '
        'col_File
        '
        Me.col_File.HeaderText = "文件名"
        Me.col_File.Name = "col_File"
        Me.col_File.Width = 80
        '
        'colSparse
        '
        Me.colSparse.HeaderText = "稀疏化"
        Me.colSparse.Name = "colSparse"
        Me.colSparse.Width = 50
        '
        'colSecStart
        '
        Me.colSecStart.HeaderText = "起始扇区"
        Me.colSecStart.Name = "colSecStart"
        Me.colSecStart.Width = 80
        '
        'colSecEnd
        '
        Me.colSecEnd.HeaderText = "终止扇区"
        Me.colSecEnd.Name = "colSecEnd"
        Me.colSecEnd.Width = 80
        '
        'colBootable
        '
        Me.colBootable.HeaderText = "启动"
        Me.colBootable.Name = "colBootable"
        Me.colBootable.Width = 40
        '
        'colReadonly
        '
        Me.colReadonly.HeaderText = "只读"
        Me.colReadonly.Name = "colReadonly"
        Me.colReadonly.Width = 40
        '
        'lbl_Tip
        '
        Me.lbl_Tip.AutoSize = True
        Me.lbl_Tip.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Tip.Location = New System.Drawing.Point(8, 30)
        Me.lbl_Tip.Name = "lbl_Tip"
        Me.lbl_Tip.Size = New System.Drawing.Size(149, 12)
        Me.lbl_Tip.TabIndex = 4
        Me.lbl_Tip.Text = "点击列表项以查看详细说明"
        '
        'btn_AddPart
        '
        Me.btn_AddPart.Location = New System.Drawing.Point(401, 337)
        Me.btn_AddPart.Name = "btn_AddPart"
        Me.btn_AddPart.Size = New System.Drawing.Size(68, 22)
        Me.btn_AddPart.TabIndex = 5
        Me.btn_AddPart.Text = "新建分区"
        Me.btn_AddPart.UseVisualStyleBackColor = True
        '
        'btn_RemovePart
        '
        Me.btn_RemovePart.Location = New System.Drawing.Point(549, 337)
        Me.btn_RemovePart.Name = "btn_RemovePart"
        Me.btn_RemovePart.Size = New System.Drawing.Size(68, 22)
        Me.btn_RemovePart.TabIndex = 6
        Me.btn_RemovePart.Text = "删除分区"
        Me.btn_RemovePart.UseVisualStyleBackColor = True
        '
        'btn_Resize
        '
        Me.btn_Resize.Location = New System.Drawing.Point(475, 337)
        Me.btn_Resize.Name = "btn_Resize"
        Me.btn_Resize.Size = New System.Drawing.Size(68, 22)
        Me.btn_Resize.TabIndex = 7
        Me.btn_Resize.Text = "调整大小"
        Me.btn_Resize.UseVisualStyleBackColor = True
        '
        'frm_EditPartConf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 371)
        Me.Controls.Add(Me.btn_Resize)
        Me.Controls.Add(Me.btn_RemovePart)
        Me.Controls.Add(Me.btn_AddPart)
        Me.Controls.Add(Me.lbl_Tip)
        Me.Controls.Add(Me.data_Part)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.lbl_Warn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_EditPartConf"
        Me.Text = "配置分区"
        CType(Me.data_Part, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Warn As Label
    Friend WithEvents btn_Save As Button
    Friend WithEvents data_Part As DataGridView
    Friend WithEvents lbl_Tip As Label
    Friend WithEvents btn_AddPart As Button
    Friend WithEvents btn_RemovePart As Button
    Friend WithEvents colLabel As DataGridViewTextBoxColumn
    Friend WithEvents colGUID As DataGridViewTextBoxColumn
    Friend WithEvents colBak As DataGridViewCheckBoxColumn
    Friend WithEvents col_File As DataGridViewTextBoxColumn
    Friend WithEvents colSparse As DataGridViewCheckBoxColumn
    Friend WithEvents colSecStart As DataGridViewTextBoxColumn
    Friend WithEvents colSecEnd As DataGridViewTextBoxColumn
    Friend WithEvents colBootable As DataGridViewCheckBoxColumn
    Friend WithEvents colReadonly As DataGridViewCheckBoxColumn
    Friend WithEvents btn_Resize As Button
End Class
