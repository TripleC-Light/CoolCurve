<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟舊檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NC檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.圖檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.離開ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.雕刻機參數ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.幫助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.關於CoolCurveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tagIn = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ibBGboard = New Emgu.CV.UI.ImageBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ibBGboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 637)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1276, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(108, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案ToolStripMenuItem, Me.設定ToolStripMenuItem, Me.幫助ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1276, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '檔案ToolStripMenuItem
        '
        Me.檔案ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開啟舊檔ToolStripMenuItem, Me.離開ToolStripMenuItem})
        Me.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem"
        Me.檔案ToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.檔案ToolStripMenuItem.Text = "檔案"
        '
        '開啟舊檔ToolStripMenuItem
        '
        Me.開啟舊檔ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NC檔ToolStripMenuItem, Me.圖檔ToolStripMenuItem})
        Me.開啟舊檔ToolStripMenuItem.Name = "開啟舊檔ToolStripMenuItem"
        Me.開啟舊檔ToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.開啟舊檔ToolStripMenuItem.Text = "開啟"
        '
        'NC檔ToolStripMenuItem
        '
        Me.NC檔ToolStripMenuItem.Name = "NC檔ToolStripMenuItem"
        Me.NC檔ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.NC檔ToolStripMenuItem.Text = "NC檔"
        '
        '圖檔ToolStripMenuItem
        '
        Me.圖檔ToolStripMenuItem.Name = "圖檔ToolStripMenuItem"
        Me.圖檔ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.圖檔ToolStripMenuItem.Text = "圖檔"
        '
        '離開ToolStripMenuItem
        '
        Me.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem"
        Me.離開ToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.離開ToolStripMenuItem.Text = "離開"
        '
        '設定ToolStripMenuItem
        '
        Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.雕刻機參數ToolStripMenuItem})
        Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        '雕刻機參數ToolStripMenuItem
        '
        Me.雕刻機參數ToolStripMenuItem.Name = "雕刻機參數ToolStripMenuItem"
        Me.雕刻機參數ToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.雕刻機參數ToolStripMenuItem.Text = "雕刻機參數"
        '
        '幫助ToolStripMenuItem
        '
        Me.幫助ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.關於CoolCurveToolStripMenuItem})
        Me.幫助ToolStripMenuItem.Name = "幫助ToolStripMenuItem"
        Me.幫助ToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.幫助ToolStripMenuItem.Text = "說明"
        '
        '關於CoolCurveToolStripMenuItem
        '
        Me.關於CoolCurveToolStripMenuItem.Name = "關於CoolCurveToolStripMenuItem"
        Me.關於CoolCurveToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.關於CoolCurveToolStripMenuItem.Text = "關於Cool Curve"
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button1.Location = New System.Drawing.Point(12, 70)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 40)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "底　板"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(12, 114)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 40)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Gcode自訂"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(12, 160)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 40)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "速度/高度"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(12, 206)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 40)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "影像處理"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(12, 252)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 40)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "進　階"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'tagIn
        '
        Me.tagIn.BackColor = System.Drawing.Color.White
        Me.tagIn.Location = New System.Drawing.Point(90, 70)
        Me.tagIn.Name = "tagIn"
        Me.tagIn.Size = New System.Drawing.Size(210, 560)
        Me.tagIn.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.Button11)
        Me.Panel2.Controls.Add(Me.Button8)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Location = New System.Drawing.Point(911, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(77, 600)
        Me.Panel2.TabIndex = 13
        '
        'Button10
        '
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(39, 78)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(35, 35)
        Me.Button10.TabIndex = 5
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Location = New System.Drawing.Point(3, 78)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(35, 35)
        Me.Button11.TabIndex = 4
        Me.Button11.Text = "Button11"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(39, 41)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(35, 35)
        Me.Button8.TabIndex = 3
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(3, 41)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(35, 35)
        Me.Button9.TabIndex = 2
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(39, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(35, 35)
        Me.Button7.TabIndex = 1
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(3, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(35, 35)
        Me.Button6.TabIndex = 0
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ibBGboard
        '
        Me.ibBGboard.Location = New System.Drawing.Point(306, 27)
        Me.ibBGboard.Name = "ibBGboard"
        Me.ibBGboard.Size = New System.Drawing.Size(600, 600)
        Me.ibBGboard.TabIndex = 2
        Me.ibBGboard.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(991, 27)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(267, 256)
        Me.TextBox1.TabIndex = 14
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(56, 27)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(78, 37)
        Me.Button12.TabIndex = 16
        Me.Button12.Text = "開啟圖檔"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(165, 27)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(82, 37)
        Me.Button13.TabIndex = 17
        Me.Button13.Text = "產生 G-code"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(994, 289)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(67, 30)
        Me.Button14.TabIndex = 18
        Me.Button14.Text = "放 大"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(1067, 289)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(67, 30)
        Me.Button15.TabIndex = 19
        Me.Button15.Text = "縮 小"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1276, 659)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ibBGboard)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tagIn)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main"
        Me.Text = "CoolCurve [beta]"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ibBGboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 檔案ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 開啟舊檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NC檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 圖檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 離開ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 幫助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 設定ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 雕刻機參數ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 關於CoolCurveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents tagIn As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ibBGboard As Emgu.CV.UI.ImageBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
End Class
