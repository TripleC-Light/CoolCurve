<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.set_Laser_Height = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BacktoDefault = New System.Windows.Forms.Button()
        Me.Laser_Cut_enabled = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Times_set = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(29, 171)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(89, 37)
        Me.OK.TabIndex = 0
        Me.OK.Text = "確　定"
        Me.OK.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(134, 172)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(89, 37)
        Me.cancel.TabIndex = 1
        Me.cancel.Text = "取　消"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "雷射頭預設高度："
        '
        'set_Laser_Height
        '
        Me.set_Laser_Height.Location = New System.Drawing.Point(122, 46)
        Me.set_Laser_Height.Name = "set_Laser_Height"
        Me.set_Laser_Height.Size = New System.Drawing.Size(48, 22)
        Me.set_Laser_Height.TabIndex = 6
        Me.set_Laser_Height.Text = "15"
        Me.set_Laser_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "mm"
        '
        'BacktoDefault
        '
        Me.BacktoDefault.Location = New System.Drawing.Point(74, 127)
        Me.BacktoDefault.Name = "BacktoDefault"
        Me.BacktoDefault.Size = New System.Drawing.Size(99, 38)
        Me.BacktoDefault.TabIndex = 8
        Me.BacktoDefault.Text = "全部恢復預設值"
        Me.BacktoDefault.UseVisualStyleBackColor = True
        '
        'Laser_Cut_enabled
        '
        Me.Laser_Cut_enabled.AutoSize = True
        Me.Laser_Cut_enabled.Location = New System.Drawing.Point(26, 85)
        Me.Laser_Cut_enabled.Name = "Laser_Cut_enabled"
        Me.Laser_Cut_enabled.Size = New System.Drawing.Size(215, 28)
        Me.Laser_Cut_enabled.TabIndex = 9
        Me.Laser_Cut_enabled.Text = "開啟軟切割功能" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(多次雕刻，每雕刻1次會下降0.2mm)"
        Me.Laser_Cut_enabled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "雷射定位次數："
        '
        'Times_set
        '
        Me.Times_set.Location = New System.Drawing.Point(129, 16)
        Me.Times_set.Name = "Times_set"
        Me.Times_set.Size = New System.Drawing.Size(32, 22)
        Me.Times_set.TabIndex = 3
        Me.Times_set.Text = "1"
        Me.Times_set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "次"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(42, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "※進行圖片雕刻時，無法開啟切割功能"
        '
        'Form2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(258, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Laser_Cut_enabled)
        Me.Controls.Add(Me.BacktoDefault)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.set_Laser_Height)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Times_set)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.OK)
        Me.Name = "Form2"
        Me.Text = "進階設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents set_Laser_Height As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BacktoDefault As System.Windows.Forms.Button
    Friend WithEvents Laser_Cut_enabled As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Times_set As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
