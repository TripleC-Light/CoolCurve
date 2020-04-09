<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.preErrDiff = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.contrastADJ = New System.Windows.Forms.HScrollBar()
        Me.picWidth = New System.Windows.Forms.Label()
        Me.sizesetX = New System.Windows.Forms.TextBox()
        Me.sizesetY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pixelSize = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grayLevelSelect = New System.Windows.Forms.ComboBox()
        Me.OpenPic = New System.Windows.Forms.OpenFileDialog()
        Me.Data_log = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.imgProcessValue = New System.Windows.Forms.ProgressBar()
        Me.imgArrow = New System.Windows.Forms.PictureBox()
        Me.PictureBoxPreview = New System.Windows.Forms.PictureBox()
        Me.PictureBoxGray = New System.Windows.Forms.PictureBox()
        Me.PictureBoxOrg = New System.Windows.Forms.PictureBox()
        Me.picOrgBack = New System.Windows.Forms.PictureBox()
        Me.picGrayBack = New System.Windows.Forms.PictureBox()
        Me.picPrevBack = New System.Windows.Forms.PictureBox()
        Me.setOKimg = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxGray, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOrgBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGrayBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrevBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.setOKimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'preErrDiff
        '
        Me.preErrDiff.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.preErrDiff.ForeColor = System.Drawing.Color.Blue
        Me.preErrDiff.Location = New System.Drawing.Point(42, 239)
        Me.preErrDiff.Name = "preErrDiff"
        Me.preErrDiff.Size = New System.Drawing.Size(131, 35)
        Me.preErrDiff.TabIndex = 11
        Me.preErrDiff.Text = "預 覽 雕 刻"
        Me.preErrDiff.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "◆ 圖片尺寸："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "◆ 對比度："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "◆ 預估雕刻大小："
        '
        'contrastADJ
        '
        Me.contrastADJ.LargeChange = 1
        Me.contrastADJ.Location = New System.Drawing.Point(88, 166)
        Me.contrastADJ.Maximum = 5
        Me.contrastADJ.Minimum = -5
        Me.contrastADJ.Name = "contrastADJ"
        Me.contrastADJ.Size = New System.Drawing.Size(102, 18)
        Me.contrastADJ.TabIndex = 15
        '
        'picWidth
        '
        Me.picWidth.AutoSize = True
        Me.picWidth.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.picWidth.ForeColor = System.Drawing.Color.Red
        Me.picWidth.Location = New System.Drawing.Point(92, 32)
        Me.picWidth.Name = "picWidth"
        Me.picWidth.Size = New System.Drawing.Size(45, 13)
        Me.picWidth.TabIndex = 16
        Me.picWidth.Text = "Label6"
        '
        'sizesetX
        '
        Me.sizesetX.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.sizesetX.Location = New System.Drawing.Point(42, 121)
        Me.sizesetX.Name = "sizesetX"
        Me.sizesetX.Size = New System.Drawing.Size(37, 23)
        Me.sizesetX.TabIndex = 18
        Me.sizesetX.Text = "000.0"
        Me.sizesetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sizesetY
        '
        Me.sizesetY.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.sizesetY.Location = New System.Drawing.Point(130, 121)
        Me.sizesetY.Name = "sizesetY"
        Me.sizesetY.Size = New System.Drawing.Size(37, 23)
        Me.sizesetY.TabIndex = 19
        Me.sizesetY.Text = "000.0"
        Me.sizesetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "◆ 每個像素間距：　　　　mm"
        '
        'pixelSize
        '
        Me.pixelSize.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.pixelSize.Location = New System.Drawing.Point(124, 61)
        Me.pixelSize.Name = "pixelSize"
        Me.pixelSize.Size = New System.Drawing.Size(37, 23)
        Me.pixelSize.TabIndex = 21
        Me.pixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "◆ 灰階層數："
        '
        'grayLevelSelect
        '
        Me.grayLevelSelect.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.grayLevelSelect.FormattingEnabled = True
        Me.grayLevelSelect.Items.AddRange(New Object() {"256 階", "16 階", "8 階", "4 階", "2 階( 黑 / 白 )"})
        Me.grayLevelSelect.Location = New System.Drawing.Point(95, 203)
        Me.grayLevelSelect.Name = "grayLevelSelect"
        Me.grayLevelSelect.Size = New System.Drawing.Size(95, 21)
        Me.grayLevelSelect.TabIndex = 23
        Me.grayLevelSelect.Text = "256 階"
        '
        'Data_log
        '
        Me.Data_log.Location = New System.Drawing.Point(13, 472)
        Me.Data_log.Multiline = True
        Me.Data_log.Name = "Data_log"
        Me.Data_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Data_log.Size = New System.Drawing.Size(775, 75)
        Me.Data_log.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.subBack
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.picWidth)
        Me.GroupBox1.Controls.Add(Me.preErrDiff)
        Me.GroupBox1.Controls.Add(Me.grayLevelSelect)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.pixelSize)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.contrastADJ)
        Me.GroupBox1.Controls.Add(Me.sizesetY)
        Me.GroupBox1.Controls.Add(Me.sizesetX)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(585, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 285)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "參數設定"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(6, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 16)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "◆"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(6, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "◆"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(6, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "◆"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(6, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 16)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "◆"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(6, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "◆"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(79, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "mm  X 　　　　mm"
        '
        'imgProcessValue
        '
        Me.imgProcessValue.Location = New System.Drawing.Point(585, 441)
        Me.imgProcessValue.Name = "imgProcessValue"
        Me.imgProcessValue.Size = New System.Drawing.Size(200, 22)
        Me.imgProcessValue.TabIndex = 29
        '
        'imgArrow
        '
        Me.imgArrow.BackColor = System.Drawing.Color.Transparent
        Me.imgArrow.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.arrow
        Me.imgArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgArrow.Location = New System.Drawing.Point(113, 53)
        Me.imgArrow.Name = "imgArrow"
        Me.imgArrow.Size = New System.Drawing.Size(17, 20)
        Me.imgArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgArrow.TabIndex = 27
        Me.imgArrow.TabStop = False
        '
        'PictureBoxPreview
        '
        Me.PictureBoxPreview.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.NoPic
        Me.PictureBoxPreview.Location = New System.Drawing.Point(146, 27)
        Me.PictureBoxPreview.Name = "PictureBoxPreview"
        Me.PictureBoxPreview.Size = New System.Drawing.Size(239, 214)
        Me.PictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxPreview.TabIndex = 8
        Me.PictureBoxPreview.TabStop = False
        '
        'PictureBoxGray
        '
        Me.PictureBoxGray.BackColor = System.Drawing.SystemColors.Desktop
        Me.PictureBoxGray.Image = Global.WindowsApplication1.My.Resources.Resources.NoPic
        Me.PictureBoxGray.Location = New System.Drawing.Point(25, 139)
        Me.PictureBoxGray.Name = "PictureBoxGray"
        Me.PictureBoxGray.Size = New System.Drawing.Size(74, 63)
        Me.PictureBoxGray.TabIndex = 7
        Me.PictureBoxGray.TabStop = False
        '
        'PictureBoxOrg
        '
        Me.PictureBoxOrg.BackColor = System.Drawing.SystemColors.Desktop
        Me.PictureBoxOrg.Image = Global.WindowsApplication1.My.Resources.Resources.NoPic
        Me.PictureBoxOrg.Location = New System.Drawing.Point(25, 27)
        Me.PictureBoxOrg.Name = "PictureBoxOrg"
        Me.PictureBoxOrg.Size = New System.Drawing.Size(74, 70)
        Me.PictureBoxOrg.TabIndex = 6
        Me.PictureBoxOrg.TabStop = False
        '
        'picOrgBack
        '
        Me.picOrgBack.BackColor = System.Drawing.Color.Transparent
        Me.picOrgBack.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.prevBack_select
        Me.picOrgBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picOrgBack.Location = New System.Drawing.Point(13, 13)
        Me.picOrgBack.Name = "picOrgBack"
        Me.picOrgBack.Size = New System.Drawing.Size(100, 100)
        Me.picOrgBack.TabIndex = 24
        Me.picOrgBack.TabStop = False
        '
        'picGrayBack
        '
        Me.picGrayBack.BackColor = System.Drawing.Color.Transparent
        Me.picGrayBack.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.prevBack_noselect
        Me.picGrayBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picGrayBack.Location = New System.Drawing.Point(13, 119)
        Me.picGrayBack.Name = "picGrayBack"
        Me.picGrayBack.Size = New System.Drawing.Size(100, 100)
        Me.picGrayBack.TabIndex = 25
        Me.picGrayBack.TabStop = False
        '
        'picPrevBack
        '
        Me.picPrevBack.BackColor = System.Drawing.Color.Transparent
        Me.picPrevBack.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.prevBack_big
        Me.picPrevBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picPrevBack.Location = New System.Drawing.Point(129, 13)
        Me.picPrevBack.Name = "picPrevBack"
        Me.picPrevBack.Size = New System.Drawing.Size(450, 450)
        Me.picPrevBack.TabIndex = 26
        Me.picPrevBack.TabStop = False
        '
        'setOKimg
        '
        Me.setOKimg.BackColor = System.Drawing.Color.Transparent
        Me.setOKimg.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.imgOK
        Me.setOKimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.setOKimg.Location = New System.Drawing.Point(637, 316)
        Me.setOKimg.Name = "setOKimg"
        Me.setOKimg.Size = New System.Drawing.Size(100, 100)
        Me.setOKimg.TabIndex = 30
        Me.setOKimg.TabStop = False
        '
        'Form3
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Back
        Me.ClientSize = New System.Drawing.Size(795, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.setOKimg)
        Me.Controls.Add(Me.imgProcessValue)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.imgArrow)
        Me.Controls.Add(Me.Data_log)
        Me.Controls.Add(Me.PictureBoxPreview)
        Me.Controls.Add(Me.PictureBoxGray)
        Me.Controls.Add(Me.PictureBoxOrg)
        Me.Controls.Add(Me.picOrgBack)
        Me.Controls.Add(Me.picGrayBack)
        Me.Controls.Add(Me.picPrevBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "圖片設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxGray, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOrgBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGrayBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrevBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.setOKimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents preErrDiff As System.Windows.Forms.Button
    Friend WithEvents PictureBoxGray As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOrg As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents contrastADJ As System.Windows.Forms.HScrollBar
    Friend WithEvents picWidth As System.Windows.Forms.Label
    Friend WithEvents PictureBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents sizesetX As System.Windows.Forms.TextBox
    Friend WithEvents sizesetY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pixelSize As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grayLevelSelect As System.Windows.Forms.ComboBox
    Friend WithEvents OpenPic As System.Windows.Forms.OpenFileDialog
    Friend WithEvents picOrgBack As System.Windows.Forms.PictureBox
    Friend WithEvents picGrayBack As System.Windows.Forms.PictureBox
    Friend WithEvents picPrevBack As System.Windows.Forms.PictureBox
    Friend WithEvents Data_log As System.Windows.Forms.TextBox
    Friend WithEvents imgArrow As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents imgProcessValue As System.Windows.Forms.ProgressBar
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents setOKimg As System.Windows.Forms.PictureBox
End Class
