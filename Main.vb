Imports System.IO
Imports Emgu.CV
Imports Emgu.CV.UI
Imports Emgu.CV.Structure

Public Class Main
    '----- Pic address
    Dim selectImgAddr As String = Application.StartupPath & "\pic\tagSelect.PNG"
    Dim noSelectImgAddr As String = Application.StartupPath & "\pic\tagNoSelect.PNG"
    Dim tagInImgAddr As String = Application.StartupPath & "\pic\tagIn.PNG"
    Dim boardImgAddr As String = Application.StartupPath & "\pic\board.PNG"
    Dim testImgAddr As String = Application.StartupPath & "\pic\XXX.PNG"

    Dim emguCV As imgProc
    Dim tagLIst As New ArrayList
    Dim tagInLIst As New ArrayList

    '----- Board Layout
    Dim cvImgbg As Image(Of Bgr, Byte)
    Dim boardImg As Bitmap
    Dim imgScale As Integer = 1
    Dim mouseStateLeft As Boolean = False
    Dim mouseStateMid As Boolean = False
    Dim keyStateCTRL As Boolean = False
    Dim keyStateShift As Boolean = False
    Dim mouseOriLocation As Point
    '----- Layer manager
    Dim iblayerCut As New ImageBox
    Dim iblayerVec As New ImageBox
    Dim iblayerDiff As New ImageBox

    '----- Tag Layout
    Dim orgSize As Size
    Dim smallSize As Size
    Dim firstTagLocation As Point
    Dim selectImg As Bitmap
    Dim noSelectImg As Bitmap
    Dim tagInImg As Bitmap
    Dim dw As New drawing

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        selectImg = New Bitmap(selectImgAddr)
        noSelectImg = New Bitmap(noSelectImgAddr)
        tagInImg = New Bitmap(tagInImgAddr)
        tagIn.BackgroundImage = tagInImg
        tagLIst.Add(Button1)
        tagLIst.Add(Button2)
        tagLIst.Add(Button3)
        tagLIst.Add(Button4)
        tagLIst.Add(Button5)
        orgSize = New Size(80, 40)
        smallSize = New Size(70, 30)
        firstTagLocation = New Point(12, 70)

        tagInLIst.Add(tagLayout.tagBoardSet)
        tagInLIst.Add(tagLayout.tagGcodeSet)
        tagInLIst.Add(tagLayout.tagSpeed)
        tagInLIst.Add(tagLayout.tagImgProc)
        tagInLIst.Add(tagLayout.tagAdvice)
        For i = 0 To tagInLIst.Count - 1
            tagInLIst(i).Parent = tagIn
            tagInLIst(i).Hide()
            tagInLIst(i).Location = New Point(8, 8)
        Next
        tag_Click(Button1, Nothing)


        cvImgbg = New Image(Of Bgr, Byte)(boardImgAddr)
        boardImg = New Bitmap(cvImgbg.ToBitmap)
        boardImg = dw.Circle(boardImg, 300, 300, 290, New Bgr(0, 0, 0), 2)                                 ' 畫圓
        'boardImg = dw.Line(boardImg, New Point(0, 0), New Point(300, 300), New Bgr(0, 0, 255), 1)    ' 畫直線
        boardImg = dw.FloodFill(boardImg, New Point(10, 30), New Bgr(220, 220, 220))                  ' 顏色填充
        boardImg = dw.Cross(boardImg, New Point(300, 300), 50, 50, New Bgr(0, 0, 255), 1)           ' 畫十字
        'boardImg = dw.test(boardImg, New Point(100, 300), New Size(200, 100), 50, New Bgr(0, 255, 0), 3)           ' 畫任意角度的橢圓
        ibBGboard.FunctionalMode = ImageBox.FunctionalModeOption.Minimum        ' 關閉所有預設功能
        cvImgbg = New Image(Of Bgr, Byte)(boardImg)
        ibBGboard.Image = cvImgbg


        'iblayerCut.Parent = ibBGboard
        'iblayerCut.Location = New Point(0, 0)
        'iblayerCut.Size = New Size(100, 100)
        'iblayerCut.BackColor = Color.Transparent
        'iblayerCut.BorderStyle = BorderStyle.FixedSingle
        'ibBGboard.Controls.Add(iblayerCut)
    End Sub

    Private Sub 圖檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 圖檔ToolStripMenuItem.Click

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim tempImg As Bitmap
            Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)

            '----- 程式物件化--------
            emguCV = New imgProc(OpenFileDialog1.FileName)
            'PictureBox1.Image = emguCV.Canny(emguCV.imgOrig)                   ' 顯示 Canny 演算後的影像
            'PictureBox1.Image = emguCV.Gray(emguCV.imgOrig)                    ' 顯示 灰階 演算後的影像
            sr.Close()

            '----- 增加外圍切割線 ----------------------------------------------------------
            tempImg = emguCV.Reverse(emguCV.addCutEdge(emguCV.imgOrig, 10))
            Dim iblayerCutImg As New Image(Of Bgra, Byte)(tempImg)
            For yy = 0 To iblayerCutImg.Height - 1
                For xx = 0 To iblayerCutImg.Width - 1
                    If (iblayerCutImg.Data(yy, xx, 0) = 255) Then
                        iblayerCutImg.Data(yy, xx, 3) = 0
                    End If
                Next
            Next
            iblayerCut.Image = iblayerCutImg
            iblayerCut.Parent = ibBGboard
            iblayerCut.Size = New Size(iblayerCut.Image.Size.Width + 10, iblayerCut.Image.Size.Height + 10)
            iblayerCut.Location = New Point(ibBGboard.Width / 2 - iblayerCut.Width / 2, ibBGboard.Height / 2 - iblayerCut.Height / 2)
            iblayerCut.SizeMode = PictureBoxSizeMode.CenterImage
            iblayerCut.BackColor = Color.Transparent
            'iblayerCut.BorderStyle = BorderStyle.FixedSingle
            iblayerCut.FunctionalMode = ImageBox.FunctionalModeOption.Minimum        ' 關閉所有預設功能
            ibBGboard.Controls.Add(iblayerCut)

            ''ibOriginal.Image = New Image(Of Bgr, Byte)(emguCV.imgOrig)
            'ibProcessed.Image = New Image(Of Bgr, Byte)(PictureBox1.Image)

            'Dim TS As TimeSpan = Now.Subtract(dteStart)
            'debugT.Text = "執行時間: " & TS.TotalMilliseconds & " 毫秒"

            'Dim saveFileDialog1 As New SaveFileDialog()                             ' 儲存G-Code
            'Dim sw = New StreamWriter(Application.StartupPath & "\test.gcode")
            'sw.Write(emguCV.gcode_Edge)
            'sw.Close()
            'TrackBar1.Maximum = emguCV.gcode_Edge.Length / 7

            'PictureBox1.Image = emguCV.decodeGcode(emguCV.imgEdge)                  ' 解碼G-Code
            'ibProcessed.Image = New Image(Of Gray, Byte)(PictureBox1.Image)
            '------------------------------------------------------------------------------

            '----- 圖案向量雕刻 ------------------------------------------------------------
            tempImg = emguCV.cannyGcode(emguCV.imgOrig)
            tempImg = emguCV.Reverse(tempImg)
            Dim iblayerVecImg As New Image(Of Bgra, Byte)(tempImg)
            For yy = 0 To iblayerVecImg.Height - 1
                For xx = 0 To iblayerVecImg.Width - 1
                    If (iblayerVecImg.Data(yy, xx, 0) = 255) Then
                        iblayerVecImg.Data(yy, xx, 3) = 0
                    End If
                Next
            Next
            iblayerVec.Image = iblayerVecImg
            iblayerVec.Parent = iblayerCut
            iblayerVec.Size = New Size(iblayerVec.Image.Size.Width + 10, iblayerVec.Image.Size.Height + 10)
            iblayerVec.Location = New Point(iblayerCut.Width / 2 - iblayerVec.Width / 2, iblayerCut.Height / 2 - iblayerVec.Height / 2)
            iblayerVec.SizeMode = PictureBoxSizeMode.CenterImage
            iblayerVec.BackColor = Color.Transparent
            iblayerVec.FunctionalMode = ImageBox.FunctionalModeOption.Minimum        ' 關閉所有預設功能
            iblayerCut.Controls.Add(iblayerVec)

            'sr.Close()
            'ibOriginal.Image = New Image(Of Bgr, Byte)(emguCV.imgOrig)
            'ibProcessed.Image = New Image(Of Bgr, Byte)(PictureBox1.Image)

            'Dim saveFileDialog1 As New SaveFileDialog()                                                 '儲存檔案
            'Dim sw = New StreamWriter(Application.StartupPath & "\test.gcode")
            'sw.Write(emguCV.gcode_Canny)
            'sw.Close()
            'TrackBar1.Maximum = emguCV.gcode_Canny.Length / 7

            'PictureBox1.Image = emguCV.decodeGcode(emguCV.imgCanny)
            'ibProcessed.Image = New Image(Of Gray, Byte)(PictureBox1.Image)
            '------------------------------------------------------------------------------

            '----- 誤差擴散 ------------------------------------------------------------
            tempImg = emguCV.errdiffGcode(emguCV.imgOrig)
            tempImg = emguCV.Reverse(tempImg)
            Dim iblayerDiffImg As New Image(Of Bgra, Byte)(tempImg)
            For yy = 0 To iblayerDiffImg.Height - 1
                For xx = 0 To iblayerDiffImg.Width - 1
                    If (iblayerDiffImg.Data(yy, xx, 0) = 255) Then
                        iblayerDiffImg.Data(yy, xx, 3) = 0
                    End If
                Next
            Next
            iblayerDiff.Image = iblayerDiffImg
            iblayerDiff.Parent = iblayerVec
            iblayerDiff.Size = New Size(iblayerDiff.Image.Size.Width + 10, iblayerDiff.Image.Size.Height + 10)
            iblayerDiff.Location = New Point(iblayerVec.Width / 2 - iblayerDiff.Width / 2, iblayerVec.Height / 2 - iblayerDiff.Height / 2)
            iblayerDiff.SizeMode = PictureBoxSizeMode.CenterImage
            iblayerDiff.BackColor = Color.Transparent
            iblayerDiff.FunctionalMode = ImageBox.FunctionalModeOption.Minimum        ' 關閉所有預設功能
            iblayerVec.Controls.Add(iblayerDiff)

            'ibOriginal.Image = New Image(Of Bgr, Byte)(emguCV.imgOrig)
            'sr.Close()

            'Dim saveFileDialog1 As New SaveFileDialog()                                                 '儲存檔案
            'Dim sw = New StreamWriter(Application.StartupPath & "\test.gcode")
            'sw.Write(emguCV.gcode_ErrDiff)
            'sw.Close()
            'TrackBar1.Maximum = emguCV.gcode_ErrDiff.Length / 5

            'PictureBox1.Image = emguCV.Reverse(emguCV.decodeGcode(emguCV.imgErrDiff))
            'ibProcessed.Image = New Image(Of Gray, Byte)(PictureBox1.Image)
            '---------------------------------------------------------------------------

            ''tempImg = emguCV.Reverse(emguCV.gcodeCombine(emguCV.gcode_ErrDiff, emguCV.gcode_Canny, emguCV.imgErrDiff))
            ''cvImgbg = New Image(Of Bgr, Byte)(tempImg)
            ''ibBGboard.Image = cvImgbg
            'ibProcessed.Image = New Image(Of Gray, Byte)(PictureBox1.Image)
        End If
    End Sub

    Private Sub tag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click

        'Button1.Font = New Font(Button1.Font.Name, 10, FontStyle.Bold)

        For i = 0 To tagLIst.Count - 1

            If (sender.name <> tagLIst(i).name) Then
                tagLIst(i).BackgroundImage = noSelectImg
                tagLIst(i).Size = smallSize
                tagLIst(i).Location = New Point(20, tagLIst(i).Location.Y)
                tagInLIst(i).Hide()
            Else
                sender.BackgroundImage = selectImg
                sender.size = orgSize
                sender.Location = New Point(12, sender.Location.Y)
                tagInLIst(i).show()
            End If
        Next

        For i = 0 To tagLIst.Count - 1
            If (i = 0) Then
                tagLIst(i).location = New Point(tagLIst(i).location.X, firstTagLocation.Y)
            Else
                tagLIst(i).location = New Point(tagLIst(i).location.X, tagLIst(i - 1).location.Y + tagLIst(i - 1).height + 3)
            End If
        Next

    End Sub

    Private Sub ibBGboard_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ibBGboard.MouseDown

        Select Case e.Button
            Case MouseButtons.Left
                ibBGboard.Focus()
                mouseStateLeft = True

                Dim newX As Double
                Dim newY As Double
                imgScale = ibBGboard.ZoomScale
                newX = ((e.Location.X + ibBGboard.HorizontalScrollBar.Value * imgScale) / imgScale)
                newY = ((e.Location.Y + ibBGboard.VerticalScrollBar.Value * imgScale) / imgScale)

                cvImgbg(newY, newX) = New Bgr(0, 0, 255)
                ibBGboard.Image = cvImgbg
            Case MouseButtons.Middle
                mouseStateMid = True
                mouseOriLocation = e.Location
        End Select
    End Sub

    Private Sub ibBGboard_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ibBGboard.MouseMove

        Dim newX As Double
        Dim newY As Double
        Select Case e.Button
            Case MouseButtons.Left
                If (mouseStateLeft = True) Then
                    newX = ((e.Location.X + ibBGboard.HorizontalScrollBar.Value * imgScale) / imgScale)
                    newY = ((e.Location.Y + ibBGboard.VerticalScrollBar.Value * imgScale) / imgScale)
                    cvImgbg(newY, newX) = New Bgr(0, 0, 255)
                    ibBGboard.Image = cvImgbg
                End If
        End Select
    End Sub

    Private Sub ibBGboard_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ibBGboard.MouseUp
        Select Case e.Button
            Case MouseButtons.Left
                mouseStateLeft = False
            Case (MouseButtons.Middle)
                mouseStateMid = False
        End Select
    End Sub

    Private Sub ibBGboard_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ibBGboard.MouseWheel
        If (keyStateCTRL) Then
            If e.Delta > 0 Then
                imgScale = imgScale * 2
                If (imgScale > 32) Then
                    imgScale = 32
                End If
            Else
                imgScale = imgScale / 2
                If (imgScale < 1) Then
                    imgScale = 1
                End If
            End If
            ibBGboard.SetZoomScale(imgScale, New Point(e.Location.X, e.Location.Y))

        ElseIf (keyStateShift) Then
            If (imgScale > 1) Then
                Dim hsMAX As Integer = ibBGboard.HorizontalScrollBar.Maximum
                Dim hsMIN As Integer = ibBGboard.HorizontalScrollBar.Minimum
                Dim hsValue As Integer = ibBGboard.HorizontalScrollBar.Value
                If e.Delta > 0 Then
                    hsValue -= 10
                    If (hsValue < hsMIN) Then
                        hsValue = hsMIN
                    End If
                    ibBGboard.HorizontalScrollBar.Value = hsValue
                Else
                    hsValue += 10
                    If (hsValue > hsMAX) Then
                        hsValue = hsMAX
                    End If
                    ibBGboard.HorizontalScrollBar.Value = hsValue
                End If
                ibBGboard.Refresh()
            End If

        Else
            Dim vsMAX As Integer = ibBGboard.VerticalScrollBar.Maximum
            Dim vsMIN As Integer = ibBGboard.VerticalScrollBar.Minimum
            Dim vsValue As Integer = ibBGboard.VerticalScrollBar.Value
            If (imgScale > 1) Then
                If e.Delta > 0 Then
                    vsValue -= 10
                    If (vsValue < vsMIN) Then
                        vsValue = vsMIN
                    End If
                    ibBGboard.VerticalScrollBar.Value = vsValue
                Else
                    vsValue += 10
                    If (vsValue > vsMAX) Then
                        vsValue = vsMAX
                    End If
                    ibBGboard.VerticalScrollBar.Value = vsValue
                End If
                ibBGboard.Refresh()
            End If
        End If
    End Sub

    Private Sub ibBGboard_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ibBGboard.KeyDown
        Select Case e.KeyCode
            Case Keys.ControlKey
                keyStateCTRL = True
            Case Keys.ShiftKey
                keyStateShift = True
        End Select
    End Sub

    Private Sub ibBGboard_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ibBGboard.KeyUp
        Select Case e.KeyCode
            Case Keys.ControlKey
                keyStateCTRL = False
            Case Keys.ShiftKey
                keyStateShift = False
        End Select
    End Sub

    Private Sub Button14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button14.Click
        ibBGboard.Focus()
        imgScale = 1
        ibBGboard.SetZoomScale(imgScale, New Point(0, 0))
    End Sub
End Class

Public Class drawBackGround

    Public imgBG As Bitmap
    Public alpha As Double = 1

    Private _imgBG As Image(Of Bgr, Byte)

    Public Sub New()
    End Sub

    Public Sub New(ByVal FileName As String)
        Me.setBG(FileName)
    End Sub

    Public Sub New(ByVal imgInput As Bitmap)
        Me.setBG(imgInput)
    End Sub

    Public Sub setBG(ByVal imgInput As Bitmap)
        imgBG = imgInput
        _imgBG = New Image(Of Bgr, Byte)(imgInput)
    End Sub

    Public Sub setBG(ByVal FileName As String)
        _imgBG = New Image(Of Bgr, Byte)(FileName)
        imgBG = _imgBG.ToBitmap
    End Sub

    Public Function addObj(ByVal imgObj As Bitmap, ByVal X As Integer, ByVal Y As Integer)
        Dim yy, xx As Integer
        Dim _imgObj As New Image(Of Bgr, Byte)(imgObj)
        Dim alphaH As Double = 0.5

        For yy = 0 To (_imgObj.Height - 1)
            For xx = 0 To (_imgObj.Width - 1)
                If (_imgObj.Data(yy, xx, 0) > 190 And _imgObj.Data(yy, xx, 1) > 190 And _imgObj.Data(yy, xx, 2) > 190) Then
                    _imgBG.Data(yy + Y, xx + X, 0) = _imgObj.Data(yy, xx, 0) * (1 - alpha) + _imgBG.Data(yy + Y, xx + X, 0) * alpha
                    _imgBG.Data(yy + Y, xx + X, 1) = _imgObj.Data(yy, xx, 1) * (1 - alpha) + _imgBG.Data(yy + Y, xx + X, 1) * alpha
                    _imgBG.Data(yy + Y, xx + X, 2) = _imgObj.Data(yy, xx, 2) * (1 - alpha) + _imgBG.Data(yy + Y, xx + X, 2) * alpha

                ElseIf (_imgObj.Data(yy, xx, 0) = 0 And _imgObj.Data(yy, xx, 1) = 0 And _imgObj.Data(yy, xx, 2) = 0) Then
                    _imgObj.Data(yy, xx, 0) = 255
                    _imgObj.Data(yy, xx, 1) = 0
                    _imgObj.Data(yy, xx, 2) = 0

                    _imgBG.Data(yy + Y, xx + X, 0) = _imgObj.Data(yy, xx, 0) * (1 - alphaH) + _imgBG.Data(yy + Y, xx + X, 0) * alphaH
                    _imgBG.Data(yy + Y, xx + X, 1) = _imgObj.Data(yy, xx, 1) * (1 - alphaH) + _imgBG.Data(yy + Y, xx + X, 1) * alphaH
                    _imgBG.Data(yy + Y, xx + X, 2) = _imgObj.Data(yy, xx, 2) * (1 - alphaH) + _imgBG.Data(yy + Y, xx + X, 2) * alphaH

                Else
                    _imgBG.Data(yy + Y, xx + X, 0) = _imgObj.Data(yy, xx, 0)
                    _imgBG.Data(yy + Y, xx + X, 1) = _imgObj.Data(yy, xx, 1)
                    _imgBG.Data(yy + Y, xx + X, 2) = _imgObj.Data(yy, xx, 2)
                End If

            Next xx
        Next yy

        Return (_imgBG.ToBitmap)
    End Function

    Public Function clearBG()
        _imgBG = New Image(Of Bgr, Byte)(imgBG)
        Return (imgBG)
    End Function

End Class

