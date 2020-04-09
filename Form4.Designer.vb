<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.PictureBoxErrDiff = New System.Windows.Forms.PictureBox()
        Me.sizeX = New System.Windows.Forms.Label()
        Me.sizeY = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineYD = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineYT = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineXR = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineXL = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineY = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineX = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.backToCenter = New System.Windows.Forms.Button()
        Me.pressOK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBoxErrDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxErrDiff
        '
        Me.PictureBoxErrDiff.BackColor = System.Drawing.Color.White
        Me.PictureBoxErrDiff.Location = New System.Drawing.Point(64, 85)
        Me.PictureBoxErrDiff.Name = "PictureBoxErrDiff"
        Me.PictureBoxErrDiff.Size = New System.Drawing.Size(190, 234)
        Me.PictureBoxErrDiff.TabIndex = 9
        Me.PictureBoxErrDiff.TabStop = False
        '
        'sizeX
        '
        Me.sizeX.AutoSize = True
        Me.sizeX.BackColor = System.Drawing.Color.Transparent
        Me.sizeX.ForeColor = System.Drawing.Color.White
        Me.sizeX.Location = New System.Drawing.Point(136, 52)
        Me.sizeX.Name = "sizeX"
        Me.sizeX.Size = New System.Drawing.Size(37, 12)
        Me.sizeX.TabIndex = 11
        Me.sizeX.Text = "Label1"
        '
        'sizeY
        '
        Me.sizeY.AutoSize = True
        Me.sizeY.BackColor = System.Drawing.Color.Transparent
        Me.sizeY.ForeColor = System.Drawing.Color.White
        Me.sizeY.Location = New System.Drawing.Point(24, 179)
        Me.sizeY.Name = "sizeY"
        Me.sizeY.Size = New System.Drawing.Size(37, 12)
        Me.sizeY.TabIndex = 12
        Me.sizeY.Text = "Label1"
        Me.sizeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineYD, Me.LineYT, Me.LineXR, Me.LineXL, Me.LineY, Me.LineX})
        Me.ShapeContainer1.Size = New System.Drawing.Size(614, 408)
        Me.ShapeContainer1.TabIndex = 10
        Me.ShapeContainer1.TabStop = False
        '
        'LineYD
        '
        Me.LineYD.BorderColor = System.Drawing.Color.White
        Me.LineYD.Name = "LineYD"
        Me.LineYD.X1 = 39
        Me.LineYD.X2 = 54
        Me.LineYD.Y1 = 307
        Me.LineYD.Y2 = 307
        '
        'LineYT
        '
        Me.LineYT.BorderColor = System.Drawing.Color.White
        Me.LineYT.Name = "LineYT"
        Me.LineYT.X1 = 42
        Me.LineYT.X2 = 57
        Me.LineYT.Y1 = 73
        Me.LineYT.Y2 = 73
        '
        'LineXR
        '
        Me.LineXR.BorderColor = System.Drawing.Color.White
        Me.LineXR.Name = "LineXR"
        Me.LineXR.X1 = 248
        Me.LineXR.X2 = 248
        Me.LineXR.Y1 = 52
        Me.LineXR.Y2 = 73
        '
        'LineXL
        '
        Me.LineXL.BorderColor = System.Drawing.Color.White
        Me.LineXL.Name = "LineXL"
        Me.LineXL.X1 = 60
        Me.LineXL.X2 = 60
        Me.LineXL.Y1 = 52
        Me.LineXL.Y2 = 73
        '
        'LineY
        '
        Me.LineY.BorderColor = System.Drawing.Color.White
        Me.LineY.Name = "LineY"
        Me.LineY.X1 = 46
        Me.LineY.X2 = 46
        Me.LineY.Y1 = 75
        Me.LineY.Y2 = 307
        '
        'LineX
        '
        Me.LineX.BorderColor = System.Drawing.Color.White
        Me.LineX.Name = "LineX"
        Me.LineX.X1 = 60
        Me.LineX.X2 = 248
        Me.LineX.Y1 = 63
        Me.LineX.Y2 = 63
        '
        'backToCenter
        '
        Me.backToCenter.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.backToCenter.ForeColor = System.Drawing.Color.Red
        Me.backToCenter.Location = New System.Drawing.Point(217, 0)
        Me.backToCenter.Name = "backToCenter"
        Me.backToCenter.Size = New System.Drawing.Size(75, 30)
        Me.backToCenter.TabIndex = 13
        Me.backToCenter.Text = "置　中"
        Me.backToCenter.UseVisualStyleBackColor = True
        '
        'pressOK
        '
        Me.pressOK.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.pressOK.ForeColor = System.Drawing.Color.Red
        Me.pressOK.Location = New System.Drawing.Point(312, 0)
        Me.pressOK.Name = "pressOK"
        Me.pressOK.Size = New System.Drawing.Size(75, 30)
        Me.pressOK.TabIndex = 14
        Me.pressOK.Text = "確　定"
        Me.pressOK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(614, 30)
        Me.Button1.TabIndex = 15
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form4
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.Back
        Me.ClientSize = New System.Drawing.Size(614, 408)
        Me.Controls.Add(Me.pressOK)
        Me.Controls.Add(Me.backToCenter)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.sizeY)
        Me.Controls.Add(Me.sizeX)
        Me.Controls.Add(Me.PictureBoxErrDiff)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.Text = "雷射雕刻圖片預覽"
        CType(Me.PictureBoxErrDiff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBoxErrDiff As System.Windows.Forms.PictureBox
    Friend WithEvents sizeX As System.Windows.Forms.Label
    Friend WithEvents sizeY As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineYD As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineYT As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineXR As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineXL As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineY As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineX As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents backToCenter As System.Windows.Forms.Button
    Friend WithEvents pressOK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
