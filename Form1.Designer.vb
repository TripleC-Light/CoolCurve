<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Log_Data = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picEng = New System.Windows.Forms.Button()
        Me.SelectedFile = New System.Windows.Forms.Label()
        Me.Read_File = New System.Windows.Forms.Button()
        Me.Target_Height = New System.Windows.Forms.GroupBox()
        Me.Target_Height_Set = New System.Windows.Forms.TextBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.LaserCut_Speed = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LaserMove_Speed_Scroll = New System.Windows.Forms.HScrollBar()
        Me.LaserCut_Speed_Scroll = New System.Windows.Forms.HScrollBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LaserMove_Speed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LaserCut_Speed_Set = New System.Windows.Forms.TextBox()
        Me.Set_over_Group = New System.Windows.Forms.GroupBox()
        Me.dispGCode = New System.Windows.Forms.CheckBox()
        Me.Set_over = New System.Windows.Forms.Button()
        Me.Data_Log = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picShowLaser = New System.Windows.Forms.PictureBox()
        Me.Move_comment = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.advanced = New System.Windows.Forms.Button()
        Me.OutText = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Target_Height.SuspendLayout()
        Me.LaserCut_Speed.SuspendLayout()
        Me.Set_over_Group.SuspendLayout()
        Me.Data_Log.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picShowLaser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Log_Data
        '
        Me.Log_Data.Location = New System.Drawing.Point(7, 15)
        Me.Log_Data.Multiline = True
        Me.Log_Data.Name = "Log_Data"
        Me.Log_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Log_Data.Size = New System.Drawing.Size(608, 64)
        Me.Log_Data.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(203, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "000 %"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 435)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(186, 25)
        Me.ProgressBar1.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.picEng)
        Me.GroupBox1.Controls.Add(Me.SelectedFile)
        Me.GroupBox1.Controls.Add(Me.Read_File)
        Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 97)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Step 1. 選擇檔案"
        '
        'picEng
        '
        Me.picEng.BackColor = System.Drawing.Color.White
        Me.picEng.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Image_icon
        Me.picEng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picEng.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.picEng.Location = New System.Drawing.Point(55, 19)
        Me.picEng.Name = "picEng"
        Me.picEng.Size = New System.Drawing.Size(55, 55)
        Me.picEng.TabIndex = 2
        Me.picEng.UseVisualStyleBackColor = False
        '
        'SelectedFile
        '
        Me.SelectedFile.AutoSize = True
        Me.SelectedFile.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SelectedFile.ForeColor = System.Drawing.Color.Red
        Me.SelectedFile.Location = New System.Drawing.Point(5, 80)
        Me.SelectedFile.Name = "SelectedFile"
        Me.SelectedFile.Size = New System.Drawing.Size(124, 13)
        Me.SelectedFile.TabIndex = 1
        Me.SelectedFile.Text = "目前檔案：尚未選擇"
        '
        'Read_File
        '
        Me.Read_File.BackColor = System.Drawing.Color.White
        Me.Read_File.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.NC_icon
        Me.Read_File.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Read_File.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Read_File.Location = New System.Drawing.Point(133, 19)
        Me.Read_File.Name = "Read_File"
        Me.Read_File.Size = New System.Drawing.Size(55, 55)
        Me.Read_File.TabIndex = 0
        Me.Read_File.Text = "."
        Me.Read_File.UseVisualStyleBackColor = False
        '
        'Target_Height
        '
        Me.Target_Height.BackColor = System.Drawing.Color.Transparent
        Me.Target_Height.Controls.Add(Me.Target_Height_Set)
        Me.Target_Height.Controls.Add(Me.RadioButton3)
        Me.Target_Height.Controls.Add(Me.RadioButton2)
        Me.Target_Height.Controls.Add(Me.RadioButton1)
        Me.Target_Height.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Target_Height.Location = New System.Drawing.Point(5, 125)
        Me.Target_Height.Name = "Target_Height"
        Me.Target_Height.Size = New System.Drawing.Size(244, 94)
        Me.Target_Height.TabIndex = 10
        Me.Target_Height.TabStop = False
        Me.Target_Height.Text = "Step 2. 設定物件高度"
        '
        'Target_Height_Set
        '
        Me.Target_Height_Set.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Target_Height_Set.Location = New System.Drawing.Point(63, 66)
        Me.Target_Height_Set.Name = "Target_Height_Set"
        Me.Target_Height_Set.Size = New System.Drawing.Size(51, 23)
        Me.Target_Height_Set.TabIndex = 3
        Me.Target_Height_Set.Text = "3"
        Me.Target_Height_Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(6, 70)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(137, 16)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "自訂：　　　　　mm"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(6, 47)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(103, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "瓦楞紙板(5mm)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(7, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(88, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "紙張(0.1mm)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'LaserCut_Speed
        '
        Me.LaserCut_Speed.BackColor = System.Drawing.Color.Transparent
        Me.LaserCut_Speed.Controls.Add(Me.Label5)
        Me.LaserCut_Speed.Controls.Add(Me.Label4)
        Me.LaserCut_Speed.Controls.Add(Me.LaserMove_Speed_Scroll)
        Me.LaserCut_Speed.Controls.Add(Me.LaserCut_Speed_Scroll)
        Me.LaserCut_Speed.Controls.Add(Me.Label3)
        Me.LaserCut_Speed.Controls.Add(Me.LaserMove_Speed)
        Me.LaserCut_Speed.Controls.Add(Me.Label2)
        Me.LaserCut_Speed.Controls.Add(Me.LaserCut_Speed_Set)
        Me.LaserCut_Speed.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LaserCut_Speed.Location = New System.Drawing.Point(5, 235)
        Me.LaserCut_Speed.Name = "LaserCut_Speed"
        Me.LaserCut_Speed.Size = New System.Drawing.Size(244, 85)
        Me.LaserCut_Speed.TabIndex = 11
        Me.LaserCut_Speed.TabStop = False
        Me.LaserCut_Speed.Text = "Step 3. 設定速度"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "移動"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "雕刻"
        '
        'LaserMove_Speed_Scroll
        '
        Me.LaserMove_Speed_Scroll.LargeChange = 1
        Me.LaserMove_Speed_Scroll.Location = New System.Drawing.Point(38, 55)
        Me.LaserMove_Speed_Scroll.Maximum = 6000
        Me.LaserMove_Speed_Scroll.Name = "LaserMove_Speed_Scroll"
        Me.LaserMove_Speed_Scroll.Size = New System.Drawing.Size(113, 20)
        Me.LaserMove_Speed_Scroll.TabIndex = 1
        '
        'LaserCut_Speed_Scroll
        '
        Me.LaserCut_Speed_Scroll.LargeChange = 1
        Me.LaserCut_Speed_Scroll.Location = New System.Drawing.Point(38, 27)
        Me.LaserCut_Speed_Scroll.Maximum = 1000
        Me.LaserCut_Speed_Scroll.Name = "LaserCut_Speed_Scroll"
        Me.LaserCut_Speed_Scroll.Size = New System.Drawing.Size(113, 18)
        Me.LaserCut_Speed_Scroll.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(192, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "mm / min"
        '
        'LaserMove_Speed
        '
        Me.LaserMove_Speed.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LaserMove_Speed.Location = New System.Drawing.Point(154, 54)
        Me.LaserMove_Speed.Name = "LaserMove_Speed"
        Me.LaserMove_Speed.Size = New System.Drawing.Size(37, 23)
        Me.LaserMove_Speed.TabIndex = 2
        Me.LaserMove_Speed.Text = "5000"
        Me.LaserMove_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(192, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "mm / min"
        '
        'LaserCut_Speed_Set
        '
        Me.LaserCut_Speed_Set.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LaserCut_Speed_Set.Location = New System.Drawing.Point(154, 26)
        Me.LaserCut_Speed_Set.Name = "LaserCut_Speed_Set"
        Me.LaserCut_Speed_Set.Size = New System.Drawing.Size(37, 23)
        Me.LaserCut_Speed_Set.TabIndex = 0
        Me.LaserCut_Speed_Set.Text = "200"
        Me.LaserCut_Speed_Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Set_over_Group
        '
        Me.Set_over_Group.BackColor = System.Drawing.Color.Transparent
        Me.Set_over_Group.Controls.Add(Me.dispGCode)
        Me.Set_over_Group.Controls.Add(Me.Set_over)
        Me.Set_over_Group.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Set_over_Group.Location = New System.Drawing.Point(5, 336)
        Me.Set_over_Group.Name = "Set_over_Group"
        Me.Set_over_Group.Size = New System.Drawing.Size(244, 81)
        Me.Set_over_Group.TabIndex = 12
        Me.Set_over_Group.TabStop = False
        Me.Set_over_Group.Text = "Step 4. 完成"
        '
        'dispGCode
        '
        Me.dispGCode.AutoSize = True
        Me.dispGCode.Font = New System.Drawing.Font("新細明體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dispGCode.Location = New System.Drawing.Point(75, 64)
        Me.dispGCode.Name = "dispGCode"
        Me.dispGCode.Size = New System.Drawing.Size(88, 15)
        Me.dispGCode.TabIndex = 17
        Me.dispGCode.Text = "Display GCode"
        Me.dispGCode.UseVisualStyleBackColor = True
        '
        'Set_over
        '
        Me.Set_over.BackColor = System.Drawing.Color.Black
        Me.Set_over.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Gcode_icon
        Me.Set_over.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Set_over.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Set_over.ForeColor = System.Drawing.Color.Red
        Me.Set_over.Location = New System.Drawing.Point(59, 20)
        Me.Set_over.Name = "Set_over"
        Me.Set_over.Size = New System.Drawing.Size(125, 54)
        Me.Set_over.TabIndex = 0
        Me.Set_over.UseVisualStyleBackColor = False
        '
        'Data_Log
        '
        Me.Data_Log.BackColor = System.Drawing.Color.Transparent
        Me.Data_Log.Controls.Add(Me.Log_Data)
        Me.Data_Log.Location = New System.Drawing.Point(5, 468)
        Me.Data_Log.Name = "Data_Log"
        Me.Data_Log.Size = New System.Drawing.Size(623, 85)
        Me.Data_Log.TabIndex = 13
        Me.Data_Log.TabStop = False
        Me.Data_Log.Text = "Data Log"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.picShowLaser)
        Me.GroupBox2.Controls.Add(Me.Move_comment)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(255, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(442, 451)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "預覽圖"
        '
        'picShowLaser
        '
        Me.picShowLaser.Location = New System.Drawing.Point(22, 113)
        Me.picShowLaser.Name = "picShowLaser"
        Me.picShowLaser.Size = New System.Drawing.Size(75, 72)
        Me.picShowLaser.TabIndex = 6
        Me.picShowLaser.TabStop = False
        Me.picShowLaser.Visible = False
        '
        'Move_comment
        '
        Me.Move_comment.AutoSize = True
        Me.Move_comment.BackColor = System.Drawing.Color.PaleGreen
        Me.Move_comment.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Move_comment.ForeColor = System.Drawing.Color.Red
        Me.Move_comment.Location = New System.Drawing.Point(31, 38)
        Me.Move_comment.Name = "Move_comment"
        Me.Move_comment.Size = New System.Drawing.Size(119, 30)
        Me.Move_comment.TabIndex = 5
        Me.Move_comment.Text = "移動完後" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請重新進行分析"
        Me.Move_comment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(22, 31)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 66)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(6, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(430, 430)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'advanced
        '
        Me.advanced.BackColor = System.Drawing.Color.White
        Me.advanced.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.set_icon
        Me.advanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.advanced.Location = New System.Drawing.Point(636, 478)
        Me.advanced.Name = "advanced"
        Me.advanced.Size = New System.Drawing.Size(60, 70)
        Me.advanced.TabIndex = 16
        Me.advanced.Text = "進　階"
        Me.advanced.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.advanced.UseVisualStyleBackColor = False
        '
        'OutText
        '
        Me.OutText.Location = New System.Drawing.Point(703, 12)
        Me.OutText.Multiline = True
        Me.OutText.Name = "OutText"
        Me.OutText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutText.Size = New System.Drawing.Size(247, 541)
        Me.OutText.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.mainBack
        Me.ClientSize = New System.Drawing.Size(958, 560)
        Me.Controls.Add(Me.advanced)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Data_Log)
        Me.Controls.Add(Me.Set_over_Group)
        Me.Controls.Add(Me.LaserCut_Speed)
        Me.Controls.Add(Me.Target_Height)
        Me.Controls.Add(Me.OutText)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PtoG雷射雕刻_Ver5.0.8"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Target_Height.ResumeLayout(False)
        Me.Target_Height.PerformLayout()
        Me.LaserCut_Speed.ResumeLayout(False)
        Me.LaserCut_Speed.PerformLayout()
        Me.Set_over_Group.ResumeLayout(False)
        Me.Set_over_Group.PerformLayout()
        Me.Data_Log.ResumeLayout(False)
        Me.Data_Log.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picShowLaser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Log_Data As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Read_File As System.Windows.Forms.Button
    Friend WithEvents SelectedFile As System.Windows.Forms.Label
    Friend WithEvents Target_Height As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Target_Height_Set As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents LaserCut_Speed As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LaserCut_Speed_Set As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LaserMove_Speed As System.Windows.Forms.TextBox
    Friend WithEvents Set_over_Group As System.Windows.Forms.GroupBox
    Friend WithEvents Set_over As System.Windows.Forms.Button
    Friend WithEvents Data_Log As System.Windows.Forms.GroupBox
    Friend WithEvents LaserCut_Speed_Scroll As System.Windows.Forms.HScrollBar
    Friend WithEvents LaserMove_Speed_Scroll As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Move_comment As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents advanced As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picEng As System.Windows.Forms.Button
    Friend WithEvents picShowLaser As System.Windows.Forms.PictureBox
    Friend WithEvents OutText As System.Windows.Forms.TextBox
    Friend WithEvents dispGCode As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
