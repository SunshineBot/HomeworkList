﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pierceItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Opacity2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem70 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem85 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.hideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.createServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtLabel = New System.Windows.Forms.Label()
        Me.pierceCheck = New System.Windows.Forms.CheckBox()
        Me.opacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.createStartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteStartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Tag = "Form1"
        Me.NotifyIcon1.Text = "HomeworkList App"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pierceItem, Me.Opacity2ToolStripMenuItem, Me.hideToolStripMenuItem, Me.ToolStripSeparator1, Me.createStartupToolStripMenuItem, Me.deleteStartupToolStripMenuItem, Me.ToolStripSeparator3, Me.createServiceToolStripMenuItem, Me.deleteServiceToolStripMenuItem, Me.ToolStripSeparator2, Me.closeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 220)
        '
        'pierceItem
        '
        Me.pierceItem.BackColor = System.Drawing.SystemColors.Control
        Me.pierceItem.Name = "pierceItem"
        Me.pierceItem.Size = New System.Drawing.Size(184, 22)
        Me.pierceItem.Text = "鼠标穿透"
        '
        'Opacity2ToolStripMenuItem
        '
        Me.Opacity2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem25, Me.ToolStripMenuItem50, Me.ToolStripMenuItem70, Me.ToolStripMenuItem85, Me.ToolStripMenuItem100})
        Me.Opacity2ToolStripMenuItem.Name = "Opacity2ToolStripMenuItem"
        Me.Opacity2ToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.Opacity2ToolStripMenuItem.Text = "透明度"
        '
        'ToolStripMenuItem25
        '
        Me.ToolStripMenuItem25.Name = "ToolStripMenuItem25"
        Me.ToolStripMenuItem25.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem25.Text = "25%"
        '
        'ToolStripMenuItem50
        '
        Me.ToolStripMenuItem50.Name = "ToolStripMenuItem50"
        Me.ToolStripMenuItem50.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem50.Text = "50%"
        '
        'ToolStripMenuItem70
        '
        Me.ToolStripMenuItem70.Name = "ToolStripMenuItem70"
        Me.ToolStripMenuItem70.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem70.Text = "70%"
        '
        'ToolStripMenuItem85
        '
        Me.ToolStripMenuItem85.Name = "ToolStripMenuItem85"
        Me.ToolStripMenuItem85.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem85.Text = "85%"
        '
        'ToolStripMenuItem100
        '
        Me.ToolStripMenuItem100.Name = "ToolStripMenuItem100"
        Me.ToolStripMenuItem100.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem100.Text = "100%"
        '
        'hideToolStripMenuItem
        '
        Me.hideToolStripMenuItem.Name = "hideToolStripMenuItem"
        Me.hideToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.hideToolStripMenuItem.Text = "隐藏到托盘"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        'createServiceToolStripMenuItem
        '
        Me.createServiceToolStripMenuItem.Name = "createServiceToolStripMenuItem"
        Me.createServiceToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.createServiceToolStripMenuItem.Text = "注册自启动服务"
        '
        'deleteServiceToolStripMenuItem
        '
        Me.deleteServiceToolStripMenuItem.Name = "deleteServiceToolStripMenuItem"
        Me.deleteServiceToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.deleteServiceToolStripMenuItem.Text = "注销服务"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'closeToolStripMenuItem
        '
        Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
        Me.closeToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.closeToolStripMenuItem.Text = "关闭程序"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(100, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "这个便笺叫做狂拽酷炫吊炸天便笺"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(1, 58)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(63, 21)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "可编辑"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(62, 15)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(226, 141)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Visible = False
        '
        'txtLabel
        '
        Me.txtLabel.AutoSize = True
        Me.txtLabel.BackColor = System.Drawing.Color.Transparent
        Me.txtLabel.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLabel.Location = New System.Drawing.Point(64, 17)
        Me.txtLabel.MaximumSize = New System.Drawing.Size(240, 150)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(230, 38)
        Me.txtLabel.TabIndex = 4
        Me.txtLabel.Text = "点击输入便笺内容。看系统托盘图标！右键有惊喜~"
        '
        'pierceCheck
        '
        Me.pierceCheck.AutoSize = True
        Me.pierceCheck.BackColor = System.Drawing.Color.Transparent
        Me.pierceCheck.Location = New System.Drawing.Point(1, 98)
        Me.pierceCheck.Name = "pierceCheck"
        Me.pierceCheck.Size = New System.Drawing.Size(48, 16)
        Me.pierceCheck.TabIndex = 3
        Me.pierceCheck.Text = "穿透"
        Me.pierceCheck.UseVisualStyleBackColor = False
        '
        'opacityToolStripMenuItem
        '
        Me.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem"
        Me.opacityToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.opacityToolStripMenuItem.Text = "透明度"
        '
        'createStartupToolStripMenuItem
        '
        Me.createStartupToolStripMenuItem.Name = "createStartupToolStripMenuItem"
        Me.createStartupToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.createStartupToolStripMenuItem.Text = "创建开始菜单启动项"
        '
        'deleteStartupToolStripMenuItem
        '
        Me.deleteStartupToolStripMenuItem.Name = "deleteStartupToolStripMenuItem"
        Me.deleteStartupToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.deleteStartupToolStripMenuItem.Text = "删除开始菜单启动项"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(181, 6)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.HomeworkList.My.Resources.Resources.background_2_p
        Me.ClientSize = New System.Drawing.Size(300, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.pierceCheck)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Opacity = 0.7R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TopMost = True
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLabel As System.Windows.Forms.Label
    Friend WithEvents pierceCheck As System.Windows.Forms.CheckBox
    Friend WithEvents pierceItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents opacityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Opacity2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem70 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem85 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents hideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents createServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents deleteServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents createStartupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents deleteStartupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
