﻿Option Explicit On
Imports System.IO
Imports System.Runtime.InteropServices
Imports WindowsServiceInvest.ConfigureTest
Imports System.ServiceProcess
Imports System.Diagnostics


Public Class Form1
    Private opa As Double = 0.7

    Private loading As Boolean
    Private admin As Boolean

    '用于单独调整窗体透明度（不调整控件透明度）
    Private Declare Function SetLayeredWindowAttributes Lib "user32" (ByVal hwnd As Integer, ByVal crKey As Integer, ByVal bAlpha As Byte, ByVal dwFlags As Integer) As Integer
    Private Const LWA_ALPHA = &H2
    Private Const LWA_COLORKEY = &H1

    '用于窗体鼠标穿透
    Const GWL_EXSTYLE As Integer = (-20)
    Const WS_EX_LAYERED As Integer = &H80000
    Const WS_EX_TRANSPARENT As Long = &H20
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer

    Dim editing As Boolean = False
    Private oOriginalRegion As Region = Nothing
    ' 用于窗体移动
    Private bFormDragging As Boolean = False
    Private oPointClicked As Point

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '设置窗体单独透明
        'Dim rtn As Long, ctrol As Control
        'rtn = GetWindowLong(Me.Handle, GWL_EXSTYLE)
        'rtn = rtn Or WS_EX_TRANSPARENT
        'SetWindowLong(Me.Handle, GWL_EXSTYLE, rtn)
        'Me.Show()


        loading = True
        Dim fileDir As String
        fileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\HwList.txt"
        If File.Exists(fileDir) Then
            Dim readStream As New StreamReader(fileDir)
            TextBox2.Text = readStream.ReadToEnd
            txtLabel.Text = TextBox2.Text
            readStream.Close()
        End If
        readSettings()
        loading = False
        If My.Application.CommandLineArgs.Count > 0 Then
            admin = True
            For Each str As String In My.Application.CommandLineArgs
                Select Case str
                    Case "createService"
                        callCreateService()
                    Case "deleteService"
                        callDeleteService()
                    Case "createStartup"
                        createStartup()
                    Case "deleteStartup"
                        deleteStartup()
                End Select
            Next
        End If

        'SetLayeredWindowAttributes(Me.Handle, 0, 100, LWA_ALPHA)   '100值可调，0-255之间，越小透明度越高
        'For Each ctrol In Me.Controls
        '    ctrol.Refresh()
        'Next
        'SetLayeredWindowAttributes(CheckBox1.Handle, 0, 255, LWA_ALPHA)
        'SetLayeredWindowAttributes(txtLabel.Handle, 0, 255, LWA_ALPHA)
        'SetLayeredWindowAttributes(Me.Handle, RGB(0, 0, 0), 0, LWA_COLORKEY)    '将窗体上的黑颜色去掉

    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        hideTextBox()
    End Sub
    '******************************************
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Me.bFormDragging = True
        Me.oPointClicked = New Point(e.X, e.Y)
    End Sub
    '******************************************
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        Me.bFormDragging = False
    End Sub
    '******************************************
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If Me.bFormDragging Then
            Dim oMoveToPoint As Point
            ' 以当前鼠标位置为基础，找出目标位置
            oMoveToPoint = Me.PointToScreen(New Point(e.X, e.Y))
            ' 根据开始位置作出调整
            oMoveToPoint.Offset(Me.oPointClicked.X * -1, Me.oPointClicked.Y * -1)
            ' 移动窗体
            Me.Location = oMoveToPoint
            saveSettings()
        End If
    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Opacity = 0 Then
            Me.Opacity = opa
            hideToolStripMenuItem.Checked = False
        Else
            If pierceCheck.Checked Then
                pierceCheck.Checked = False
            Else
                Me.Opacity = 0
                hideToolStripMenuItem.Checked = True
            End If
        End If
        saveSettings()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.ReadOnly = False
            If Not loading Then showTextBox()
        Else
            TextBox2.ReadOnly = True
        End If
        If Not loading Then saveSettings()
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        hideTextBox()
    End Sub

    Private Sub txtLabel_Click(sender As Object, e As EventArgs) Handles txtLabel.Click
        If CheckBox1.Checked Then
            showTextBox()
        End If
    End Sub


    Private Sub showTextBox()
        txtLabel.Visible = False
        TextBox2.Visible = True
        TextBox2.Focus()
        editing = True
    End Sub

    Private Sub hideTextBox()
        TextBox2.Visible = False
        txtLabel.Visible = True
        txtLabel.Text = TextBox2.Text
        If editing = True Then
            saveText()
        End If
    End Sub

    Private Sub saveText()
        Dim fileDir As String
        fileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\HwList.txt"
        Dim stream As New StreamWriter(fileDir)
        stream.Write(TextBox2.Text)
        stream.Close()
        editing = False
    End Sub

    Private Sub readSettings()
        Dim fileDir As String
        Dim s As String
        Dim index As Integer
        Dim strs(6) As String
        Dim setTable As New Hashtable()

        fileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\HwSettings.txt"
        If File.Exists(fileDir) Then
            Dim readStream As New StreamReader(fileDir)
            While (Not readStream.EndOfStream())
                s = readStream.ReadLine()
                index = s.IndexOf("=")
                Dim s1 As String = s.Substring(0, index)
                Dim s2 As String = s.Substring(index + 1, s.Count() - index - 1)
                setTable.Add(s1, s2)
                'Select Case s1
                '    Case "x"
                '        Me.Left = Int(s2)
                '    Case "y"
                '        Me.Top = Int(s2)
                '    Case "opacity"
                '        Me.Opacity = CDbl(s2)
                '    Case "opa"
                '        Me.opa = CDbl(s2)
                '    Case "pierce"
                '        If (s2 = "False") Then
                '            pierceCheck.Checked = False
                '        Else
                '            pierceCheck.Checked = True
                '        End If
                'End Select
            End While
            readStream.Close()
            Me.Left = Int(setTable("x"))
            Me.Top = Int(setTable("y"))
            Me.Opacity = CDbl(setTable("opacity"))
            Me.opa = CDbl(setTable("opa"))
            If setTable("pierce") = "False" Then
                pierceCheck.Checked = False
            Else
                pierceCheck.Checked = True
            End If
            If setTable("editable") = "False" Then
                CheckBox1.Checked = False
            Else
                CheckBox1.Checked = True
            End If
        Else
            Dim welcome As String = "欢迎使用狂拽酷炫吊炸天便笺!" + vbCrLf + "这儿提供了透明度调整，鼠标穿透，自启动等核心功能，配置和便笺内容都是热保存的，不必担心丢失=。=" + vbCrLf + "自启动建议使用开始菜单启动项，创建服务功能在一些系统上好像有点问题0.0" + vbCrLf + "目前仅知道Win10系统可以支持，不知道win8/8.1/7/Vista/XP的支持情况咋样，欢迎反馈= =有空就改改=_=" + vbCrLf + "配置文件在我的文档->文档里面" + vbCrLf + vbCrLf + "希望用的愉快~" + vbCrLf + vbCrLf + "by SunshineBot."
            MsgBox(welcome, vbInformation + vbOKOnly, "欢迎使用")
        End If
    End Sub

    Private Sub saveSettings()
        If loading Then
            Return
        End If
        Dim s As String = ""
        s += "x=" + Str(Me.Location.X) + vbCrLf
        s += "y=" + Str(Me.Location.Y) + vbCrLf
        s += "opacity=" + Str(Me.Opacity) + vbCrLf
        s += "opa=" + Str(opa) + vbCrLf
        s += "pierce=" + Str(pierceCheck.Checked) + vbCrLf
        s += "editable=" + Str(CheckBox1.Checked)
        Dim fileDir As String
        fileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\HwSettings.txt"
        Dim stream As New StreamWriter(fileDir)
        stream.Write(s)
        stream.Close()
    End Sub

    Private Sub pierceCheck_CheckedChanged(sender As Object, e As EventArgs) Handles pierceCheck.CheckedChanged
        If pierceCheck.Checked Then
            SetWindowLong(Me.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT Or WS_EX_LAYERED)
        Else
            SetWindowLong(Me.Handle, GWL_EXSTYLE, WS_EX_LAYERED)
        End If
        'Me.Opacity = 0.5
        pierceItem.Checked = pierceCheck.Checked
        saveSettings()
    End Sub

    Private Sub pierceItem_Click(sender As Object, e As EventArgs) Handles pierceItem.Click
        If pierceCheck.Checked Then
            pierceCheck.Checked = False
        Else
            pierceCheck.Checked = True
        End If
    End Sub

    Private Sub txtLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles txtLabel.MouseDown
        Form1_MouseDown(sender, e)
    End Sub

    Private Sub txtLabel_MouseUp(sender As Object, e As MouseEventArgs) Handles txtLabel.MouseUp
        Form1_MouseUp(sender, e)
    End Sub

    Private Sub txtLabel_MouseMove(sender As Object, e As MouseEventArgs) Handles txtLabel.MouseMove
        Form1_MouseMove(sender, e)
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        updateOpacity(0.25)
    End Sub

    Private Sub ToolStripMenuItem50_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem50.Click
        updateOpacity(0.5)
    End Sub

    Private Sub ToolStripMenuItem70_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem70.Click
        updateOpacity(0.7)
    End Sub

    Private Sub ToolStripMenuItem85_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem85.Click
        updateOpacity(0.85)
    End Sub

    Private Sub ToolStripMenuItem100_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem100.Click
        updateOpacity(1)
    End Sub

    Private Sub closeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles closeToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub updateOpacity(o As Double)
        opa = o
        Me.Opacity = opa
        saveSettings()
    End Sub

    Private Sub hideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles hideToolStripMenuItem.Click
        If Me.Opacity = 0 Then
            Me.Opacity = opa
            hideToolStripMenuItem.Checked = False
        Else
            Me.Opacity = 0
            hideToolStripMenuItem.Checked = True
        End If
        saveSettings()
    End Sub

    Private Sub createServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles createServiceToolStripMenuItem.Click
        callCreateService()
    End Sub

    Private Sub callCreateService()
        If checkDll() Then
            createService()
        Else
            MsgBox("serviceControllerLibrary.dll不存在！", vbExclamation + vbOKOnly, "警告")
        End If
    End Sub

    Private Sub runAsAdmin(arg As String)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = Application.ExecutablePath()
        startInfo.Arguments = arg
        startInfo.Verb = "runas"
        Process.Start(startInfo)
        Application.Exit()
    End Sub

    Private Sub createService()
        Try
            Dim ctrl As ServiceController = ServiceControllerExtension.CreateService(
            "HwList",
            "hwlist便笺的自启动服务，喵~",
            Application.ExecutablePath(),
            False)
            MsgBox("自启动服务注册成功！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
        Catch ex As SystemException
            If ex.Message = "拒绝访问。" Then
                If Not admin Then
                    runAsAdmin("createService")
                Else
                    MsgBox("服务已存在或者是发生了一些奇怪的事情导致服务注册失败。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                End If
            Else
                MsgBox("服务已存在或者是发生了一些奇怪的事情导致服务注册失败。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            End If

        End Try
    End Sub

    Private Sub deleteServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteServiceToolStripMenuItem.Click
        callDeleteService()
    End Sub

    Private Sub callDeleteService()
        If checkDll() Then
            deleteService()
        Else
            MsgBox("serviceControllerLibrary.dll不存在！", vbExclamation + vbOKOnly, "警告")
        End If
    End Sub

    Private Sub deleteService()
        Try
            Dim ctrl As Boolean = ServiceControllerExtension.DeleteService("HwList")
            If ctrl Then
                MsgBox("注销服务成功！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Else
                MsgBox("注销服务失败，请关闭服务控制窗口或者其它相关窗口后重试！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            End If
        Catch ex As Exception
            If ex.Message = "拒绝访问。" Then
                If Not admin Then
                    runAsAdmin("deleteService")
                Else
                    MsgBox("服务已经被注销或者发生了一些奇怪的事情导致服务注销失败。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                End If
            Else
                MsgBox("服务已经被注销或者发生了一些奇怪的事情导致服务注销失败。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            End If
        End Try
    End Sub

    Private Function checkDll() As Boolean
        Return File.Exists("serviceControllerLibrary.dll")
    End Function

    Private Sub createStartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles createStartupToolStripMenuItem.Click
        createStartup()
    End Sub

    Private Sub createStartup()
        Try
            ' 直接调用COM对象
            Dim wsh As Object = CreateObject("WScript.Shell")
            Dim startup As String = wsh.SpecialFolders("AllUsersStartup")
            Dim lnk As Object = wsh.CreateShortcut(startup & "\便笺.lnk")

            With lnk
                '.Arguments = "/?" '传递参数
                .Description = "我是直接调用COM创建的非托管对象创建的快捷方式！"
                '.Ic '调用dll资源内的图标，索引在第23个图标，问号帮助
                .TargetPath = Application.ExecutablePath()
                .WindowStyle = vbNormalNoFocus '打开窗体的风格，正常无焦点
                .WorkingDirectory = Application.StartupPath '工作路径

                .Save() '保存快捷方式
            End With

            MsgBox("创建开始菜单启动项成功！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
        Catch ex As Exception
            If Not admin Then
                runAsAdmin("createStartup")
            Else
                MsgBox("创建开始菜单启动项失败。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            End If
        End Try
    End Sub

    Private Sub deleteStartup()
        Try
            ' 直接调用COM对象
            Dim wsh As Object = CreateObject("WScript.Shell")
            Dim startup As String = wsh.SpecialFolders("AllUsersStartup")
            Kill(startup & "\便笺.lnk")
            MsgBox("删除开始菜单启动项成功。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
        Catch ex As Exception
            If Not admin Then
                runAsAdmin("deleteStartup")
            Else
                MsgBox("删除开始菜单启动项失败，请自行删除。", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            End If
        End Try
    End Sub

    Private Sub deleteStartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles deleteStartupToolStripMenuItem.Click
        deleteStartup()
    End Sub
End Class
