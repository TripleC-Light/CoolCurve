Public Class Form3

    Public pixelStep As Double = 0.2
    Public imgWidthLimit As Integer = Form1.planSize / pixelStep   ' 210mm/0.2mm = 1050 pixel
    Public imgScale As Double = 100
    Dim picContrast As Double = 0
    Dim picWHscale As Double = 0
    Dim sizesetFocus As Integer
    Dim picPreviewIs As Integer
    Dim picSelectIs As Integer = 0
    Dim picResize As New PictureBox
    Dim DontMove As Boolean = False
    Dim picBuff As New PictureBox
    Dim picsizeChanged As Integer = 0
    Public picSizeMAX() As Integer             ' 0:width, 1:height
    Dim grayLevel As Integer

    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Enabled = True
        Form4.Hide()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form1.dpi > 96 Then
            Form1.FT = New System.Drawing.Font("新細明體", Form1.fontSize)  'set font size = 7.75
            GroupBox1.Font = Form1.FT
            Label1.Font = Form1.FT
            Label2.Font = Form1.FT
            Label3.Font = Form1.FT
            Label4.Font = Form1.FT
            Label5.Font = Form1.FT
            Label6.Font = Form1.FT
            picWidth.Font = Form1.FT
            pixelSize.Font = Form1.FT
            sizesetX.Font = Form1.FT
            sizesetY.Font = Form1.FT
            grayLevelSelect.Font = Form1.FT
            Data_log.Font = Form1.FT

            Form1.FT = New System.Drawing.Font("新細明體", Form1.fontSize + 2.25)  'set font size = 10
            preErrDiff.Font = Form1.FT

        End If

        Dim resize As Boolean
        If (Form1.debugDisplay) Then
            Data_log.Visible = True
            Me.Height = 585
        Else
            Me.Height = 500
        End If

        Dim split As String()
        ReDim picSizeMAX(2)
        ReDim Form1.initPicOrgLocation(2)
        ReDim Form1.initPicGrayLocation(2)
        ReDim Form1.initPicPrevLocation(2)

        Form1.Clear_Bed()
        OpenPic.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*"
        OpenPic.FilterIndex = 1
        OpenPic.RestoreDirectory = True

        If OpenPic.ShowDialog() = DialogResult.OK Then

            Form1.Enabled = False
            Form1.picShowLaser.Visible = False

            split = OpenPic.FileName.Split("\")
            Form1.nowFile = split(UBound(split))
            Form1.SelectedFile.Text = "目前檔案：" & Form1.nowFile
            Form1.SelectedFile.ForeColor = Color.White
            'Form1.Set_over.ForeColor = Color.Red
            Form1.Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")


            PictureBoxOrg.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBoxGray.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage
            Form4.PictureBoxErrDiff.SizeMode = PictureBoxSizeMode.StretchImage

            PictureBoxOrg.Image = Image.FromFile(OpenPic.FileName)
            Form1.picOrg_buf = PictureBoxOrg

            Form1.initPicOrgLocation(0) = PictureBoxOrg.Location.X
            Form1.initPicOrgLocation(1) = PictureBoxOrg.Location.Y
            Form1.initPicGrayLocation(0) = PictureBoxGray.Location.X
            Form1.initPicGrayLocation(1) = PictureBoxGray.Location.Y
            Form1.initPicPrevLocation(0) = PictureBoxPreview.Location.X
            Form1.initPicPrevLocation(1) = PictureBoxPreview.Location.Y
            resize = Sub_Function.AllpicSizeADJ(Form1.picOrg_buf, PictureBoxOrg, Form4.PictureBoxErrDiff, PictureBoxGray, PictureBoxPreview, imgWidthLimit, Form1.imgPreSize, Form1.imgPreSizeBig)

            picSizeMAX(0) = Form4.PictureBoxErrDiff.Width
            picSizeMAX(1) = Form4.PictureBoxErrDiff.Height

            picWidth.Text = Form4.PictureBoxErrDiff.Width & " * " & Form4.PictureBoxErrDiff.Height & " pixel"
            picWHscale = Form4.PictureBoxErrDiff.Width / Form4.PictureBoxErrDiff.Height
            sizesetX.Text = Form4.PictureBoxErrDiff.Width * pixelStep
            sizesetY.Text = Form4.PictureBoxErrDiff.Height * pixelStep
            pixelSize.Text = pixelStep

            Dim img As New Bitmap(Form4.PictureBoxErrDiff.Width, Form4.PictureBoxErrDiff.Height)        'ReDraw 縮圖
            Dim a As Graphics
            a = Graphics.FromImage(img)
            a.DrawImage(PictureBoxOrg.Image, 0, 0, Form4.PictureBoxErrDiff.Width, Form4.PictureBoxErrDiff.Height)
            picResize.Image = img
            picBuff.Image = picResize.Image
            DontMove = True

            picContrast = 0
            grayLevelSelect_SelectedIndexChanged(Nothing, Nothing)
            PicContrast_ADJ_Scroll(Nothing, Nothing)
            Sub_Function.putInCenter(Form1, Me)

            If (resize) Then
                MsgBox("圖片超過雕刻大小，已經自動進行縮圖。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "尺寸警告")
                Data_log.Text = "圖片超過雕刻大小，已經自動進行縮圖。" & vbCrLf
                Form1.Log_Data.Text &= "圖片超過雕刻大小，已經自動進行縮圖。" & vbCrLf
            End If
        Else
            Form1.Enabled = True
            Me.Dispose()
        End If

    End Sub

    Sub imageProcess(ByVal picOrg As PictureBox, ByRef picERDF As PictureBox, ByVal imgA(,) As Integer)

        Dim dteStart As DateTime = Now
        Dim errimg As New Bitmap(picERDF.Width, picERDF.Height)

        ReDim Form1.imgG(errimg.Width, errimg.Height)
        GraytoErrDiff(imgA, errimg, Form1.imgG)

        picERDF.Image = errimg
        picERDF.Location = New Point(30, 60)
        Form4.Width = picERDF.Width + picERDF.Location.X * 2
        Form4.Height = picERDF.Height + (picERDF.Location.X * 2 + 50)
        Form4.Show()

        Sub_Function.erdfSizeDisplay(picERDF, pixelStep)


        If (Form1.debugDisplay) Then
            Dim TS As TimeSpan = Now.Subtract(dteStart)
            Data_log.AppendText("> 執行時間: " & TS.TotalMilliseconds / 1000 & " 秒" & vbCrLf)
        End If

    End Sub

    Private Sub preErrDiff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preErrDiff.Click

        imgWidthLimit = (((sizesetX.Text ^ 2) + (sizesetY.Text ^ 2)) ^ 0.5) / pixelStep
        Sub_Function.AllpicSizeADJ(Form1.picOrg_buf, PictureBoxOrg, Form4.PictureBoxErrDiff, PictureBoxGray, PictureBoxPreview, imgWidthLimit, Form1.imgPreSize, Form1.imgPreSizeBig)
        Dim img As New Bitmap(Form4.PictureBoxErrDiff.Width, Form4.PictureBoxErrDiff.Height)        '繪製灰階圖
        Dim a As Graphics
        a = Graphics.FromImage(img)
        a.DrawImage(PictureBoxOrg.Image, 0, 0, Form4.PictureBoxErrDiff.Width, Form4.PictureBoxErrDiff.Height)
        picResize.Image = img
        picBuff.Image = picResize.Image

        Dim imgA(,) As Integer      ' 儲存亮度資料
        ReDim imgA(picResize.Image.Width + 2, picResize.Image.Height + 2)
        grayLevelSelect_SelectedIndexChanged(Nothing, Nothing)
        imgA = PicContrast_ADJ_Scroll(Nothing, Nothing)

        imageProcess(PictureBoxOrg, Form4.PictureBoxErrDiff, imgA)

        Select Case picPreviewIs
            Case 0
                PictureBoxPreview.Image = PictureBoxOrg.Image
            Case 1
                PictureBoxPreview.Image = PictureBoxGray.Image
        End Select

        Form4.Button1.Width = Form4.Width - 10
        Form4.Button1.Height = 30
        Form4.Button1.Location = New Point(0, 0)
        Form4.backToCenter.Location = New Point((Form4.Button1.Width - (Form4.backToCenter.Width + Form4.pressOK.Width + 5)) / 2, 0)
        Form4.pressOK.Location = New Point(Form4.backToCenter.Location.X + Form4.backToCenter.Width + 5, Form4.backToCenter.Location.Y)
        Form4.BringToFront()
        picsizeChanged = 0

        Sub_Function.putInCenter(Me, Form4)
        If (Form4.Top < 0) Then
            Form4.Top = 5
        End If

        preErrDiff.ForeColor = Color.DimGray

    End Sub

    Private Function PicContrast_ADJ_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles contrastADJ.Scroll

        'picContrast = contrastADJ.Value

        Dim imgA(,) As Integer      ' 儲存亮度資料
        ReDim imgA(picResize.Image.Width + 2, picResize.Image.Height + 2)
        RGBtoGray(picResize.Image, PictureBoxGray, imgA, contrastADJ.Value)
        If (picPreviewIs = 1) Then
            PictureBoxPreview.Image = PictureBoxGray.Image
        End If

        preErrDiff.ForeColor = Color.Blue
        'Data_log.Text = picContrast
        Return imgA

    End Function

    Sub RGBtoGray(ByVal picIn As Bitmap, ByRef picOut As PictureBox, ByRef imgA(,) As Integer, ByVal picContrast As Double)

        Dim colorY As Integer                                                   ' 亮度資訊

        Dim picMem((4 * picIn.Width * picIn.Height) - 1) As Byte

        Sub_Function.BitmaptoMem(picIn, picMem)
        'Data_log.Text = (1 + (picContrast / 5))
        Dim arowDatas As Integer = 4 * picIn.Width                     ' 定義 arowDatas 為圖片的每列資料筆數
        For yy = 0 To (picIn.Height - 1)                                        ' 計算亮度, 顏色順序為 B-G-R-A
            For xx = 0 To (arowDatas - 1) Step 4
                colorY = 0.299 * picMem((arowDatas * yy) + (xx + 2)) + 0.587 * picMem((arowDatas * yy) + (xx + 1)) + 0.114 * picMem((arowDatas * yy) + (xx + 0))   '轉灰階公式

                colorY = (1 + (picContrast / 5)) * colorY       '調整對比
                If (colorY > 255) Then
                    colorY = 255
                End If

                picMem((arowDatas * yy) + (xx + 0)) = colorY         'B
                picMem((arowDatas * yy) + (xx + 1)) = colorY         'G
                picMem((arowDatas * yy) + (xx + 2)) = colorY         'R
                picMem((arowDatas * yy) + (xx + 3)) = 255            'A
                imgA((xx / 4) + 1, yy + 1) = colorY
            Next xx
        Next yy

        Sub_Function.MemtoBitmap(picMem, picIn)

        picOut.Image = picIn

    End Sub

    Sub GraytoErrDiff(ByVal imgA(,) As Integer, ByRef errimg As Bitmap, ByRef imgC(,) As Integer)

        Dim xx, yy As Integer
        Dim imgErr As Integer
        Dim imgB(,) As Integer
        ReDim imgB(errimg.Width + 2, errimg.Height + 2)

        Dim picMem() As Byte
        ReDim picMem((4 * errimg.Width * errimg.Height) - 1)
        Sub_Function.BitmaptoMem(errimg, picMem)

        For yy = 1 To (errimg.Height)
            Application.DoEvents()
            imgProcessValue.Value = (yy / errimg.Height) * 100

            For xx = 1 To (errimg.Width)
                If imgA(xx, yy) < 128 Then
                    imgB(xx, yy) = 0
                    imgErr = imgA(xx, yy)
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 0) = 0
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 1) = 0
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 2) = 0
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 3) = 255
                    imgC(xx - 1, yy - 1) = 0
                Else
                    imgB(xx, yy) = 255
                    imgErr = imgA(xx, yy) - 255
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 0) = 245
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 1) = 245
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 2) = 245
                    picMem((yy - 1) * 4 * errimg.Width + (xx - 1) * 4 + 3) = 255
                    imgC(xx - 1, yy - 1) = 255
                End If
                imgA(xx + 1, yy) = imgA(xx + 1, yy) + (imgErr * 7 / 16)
                imgA(xx - 1, yy + 1) = imgA(xx - 1, yy + 1) + (imgErr * 3 / 16)
                imgA(xx, yy + 1) = imgA(xx, yy + 1) + (imgErr * 5 / 16)
                imgA(xx + 1, yy + 1) = imgA(xx + 1, yy + 1) + (imgErr * 1 / 16)
            Next xx
        Next yy
        Sub_Function.MemtoBitmap(picMem, errimg)

        imgProcessValue.Value = 0

    End Sub

    Private Sub sizesetX_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles sizesetX.MouseDown, sizesetY.MouseDown, pixelSize.MouseDown
        Select Case sender.Name
            Case "sizesetX"
                sizesetFocus = 0
            Case "sizesetY"
                sizesetFocus = 1
            Case "pixelSize"
                sizesetFocus = 2
        End Select
    End Sub

    Private Sub sizesetXY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sizesetX.TextChanged, sizesetY.TextChanged, pixelSize.TextChanged

        ' 不明原因，程式一跑就會先執行此動作，但由於 picResize尚未建立所以會出錯，
        ' 因而增加 DontMove變數，待 Load完成後令 DontMove=true，來避免一開始執行的錯誤
        If (DontMove) Then
            If (sizesetX.Text <> "" Or sizesetY.Text <> "" Or contrastADJ.Text <> "") Then
                Select Case sender.Name
                    Case "sizesetX"
                        If (sizesetFocus = 0) Then
                            If (Math.Round(sizesetX.Text / pixelStep) > picSizeMAX(0)) Then
                                sizesetX.Text = Format((picSizeMAX(1) * pixelStep) * picWHscale, "####.#")
                                Data_log.Text &= "> 您設定的尺寸太大囉(會超過雕刻直徑：" & Form1.planSize & "mm)，已經自動設為最大值！" & vbCrLf
                                Form1.Log_Data.Text &= "您設定的尺寸太大囉(會超過雕刻直徑：" & Form1.planSize & "mm)，已經自動設為最大值！" & vbCrLf
                            End If
                            sizesetY.Text = Format(sizesetX.Text / picWHscale, "####.#")
                            picWidth.Text = Math.Round(sizesetX.Text / pixelStep) & " * " & Math.Round(sizesetY.Text / pixelStep) & " pixel"
                            picsizeChanged = 1
                        End If
                    Case "sizesetY"
                        If (sizesetFocus = 1) Then
                            If (Math.Round(sizesetY.Text / pixelStep) > picSizeMAX(1)) Then
                                sizesetY.Text = Format((picSizeMAX(0) * pixelStep) / picWHscale, "####.#")
                                Data_log.Text &= "> 您設定的尺寸太大囉(會超過雕刻直徑：" & Form1.planSize & "mm)，已經自動設為最大值！" & vbCrLf
                                Form1.Log_Data.Text = "您設定的尺寸太大囉(會超過雕刻直徑：" & Form1.planSize & "mm)，已經自動設為最大值！" & vbCrLf
                            End If
                            sizesetX.Text = Format(sizesetY.Text * picWHscale, "####.#")
                            picWidth.Text = Math.Round(sizesetX.Text / pixelStep) & " * " & Math.Round(sizesetY.Text / pixelStep) & " pixel"
                            picsizeChanged = 1
                        End If
                    Case "pixelSize"
                        If (pixelSize.Text <> 0) Then
                            pixelStep = pixelSize.Text
                            imgWidthLimit = Form1.planSize / pixelStep
                            sizesetX.Text = picSizeMAX(0) * pixelStep
                            sizesetY.Text = picSizeMAX(1) * pixelStep
                            picsizeChanged = 1
                        End If
                    Case Else
                End Select
                If (picsizeChanged = 1) Then
                    preErrDiff.ForeColor = Color.Blue
                End If
            End If
        End If
    End Sub

    Private Sub PictureBoxSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOrg.Click, PictureBoxGray.Click
        Select Case sender.Name
            Case "PictureBoxOrg"
                picPreviewIs = 0
                PictureBoxPreview.Image = PictureBoxOrg.Image
                'picOrgBack.BackColor = Color.FromArgb(255, 255, 192)
                'picGrayBack.BackColor = Color.White
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_noselect.png")
                imgArrow.Location = New Point(picOrgBack.Location.X + picOrgBack.Width, (picOrgBack.Width - imgArrow.Width) / 2 + picOrgBack.Location.Y)
            Case "PictureBoxGray"
                picPreviewIs = 1
                PictureBoxPreview.Image = PictureBoxGray.Image
                'picOrgBack.BackColor = Color.White
                'picGrayBack.BackColor = Color.FromArgb(255, 255, 192)
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_noselect.png")
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
                imgArrow.Location = New Point(picGrayBack.Location.X + picGrayBack.Width, (picGrayBack.Width - imgArrow.Width) / 2 + picGrayBack.Location.Y)
        End Select
    End Sub

    Private Sub grayLevelSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grayLevelSelect.SelectedIndexChanged

        Dim dteStart As DateTime = Now
        Dim grayLevelTable() As Integer = {256, 16, 8, 4, 2}

        ' 不明原因，程式一跑就會先執行此動作，但由於 picResize尚未建立所以會出錯，
        ' 因而增加 DontMove變數，待 Load完成後令 DontMove=true，來避免一開始執行的錯誤
        If (DontMove) Then
            grayLevel = grayLevelTable(grayLevelSelect.SelectedIndex)
            picResize.Image = picBuff.Image     '存回備份原圖 
            Dim imgA(,) As Integer      ' 儲存亮度資料
            ReDim imgA(picResize.Image.Width + 2, picResize.Image.Height + 2)
            RGBtoGray(picResize.Image, PictureBoxGray, imgA, contrastADJ.Value)
            Sub_Function.picChangeGrayLevel(PictureBoxGray, grayLevel)
            picResize.Image = PictureBoxGray.Image
            'PicContrast_ADJ_Scroll(Nothing, Nothing)
            If (picPreviewIs = 1) Then
                PictureBoxPreview.Image = PictureBoxGray.Image
            End If
            preErrDiff.ForeColor = Color.Blue
        End If

        If (Form1.debugDisplay) Then
            Dim TS As TimeSpan = Now.Subtract(dteStart)
            Data_log.AppendText("> 變更灰階執行時間: " & TS.TotalMilliseconds / 1000 & " 秒" & vbCrLf)
        End If
    End Sub

    Private Sub picGrayBack_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picOrgBack.MouseLeave, picGrayBack.MouseLeave, PictureBoxOrg.MouseLeave, PictureBoxGray.MouseLeave
        Select Case sender.Name
            Case "picOrgBack", "PictureBoxOrg"
                'picOrgBack.BackColor = Color.White
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_noselect.png")
            Case "picGrayBack", "PictureBoxGray"
                'picGrayBack.BackColor = Color.White
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_noselect.png")
        End Select
        Select Case picPreviewIs
            Case 0
                'picOrgBack.BackColor = Color.FromArgb(255, 255, 192)
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
            Case 1
                'picGrayBack.BackColor = Color.FromArgb(255, 255, 192)
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
        End Select
    End Sub

    Private Sub picPrev_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picOrgBack.MouseMove, picGrayBack.MouseMove, PictureBoxOrg.MouseMove, PictureBoxGray.MouseMove
        Select Case sender.Name
            Case "picOrgBack", "PictureBoxOrg"
                'picOrgBack.BackColor = Color.LightGray
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_move.png")
            Case "picGrayBack", "PictureBoxGray"
                'picGrayBack.BackColor = Color.LightGray
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_move.png")
        End Select
        Select Case picPreviewIs
            Case 0
                'picOrgBack.BackColor = Color.FromArgb(255, 255, 192)
                picOrgBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
            Case 1
                'picGrayBack.BackColor = Color.FromArgb(255, 255, 192)
                picGrayBack.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\prevBack_select.png")
        End Select
    End Sub

    Private Sub setOKimg_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles setOKimg.MouseDown
        setOKimg.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\imgOK_OK.png")
    End Sub

    Private Sub setOKimg_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles setOKimg.MouseLeave
        setOKimg.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\imgOK.png")
    End Sub

    Private Sub setOKimg_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles setOKimg.MouseMove
        setOKimg.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\imgOK_move.png")
    End Sub

    Private Sub setOKimg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setOKimg.Click

        If (preErrDiff.ForeColor = Color.Blue) Then
            preErrDiff_Click(Nothing, Nothing)
        End If


        Form1.Log_Data.Text &= "圖片尺寸：" & picResize.Image.Width * pixelStep & "mm X " & picResize.Image.Height * pixelStep & "mm" & vbCrLf
        '---------------- 以下程式目的為重繪一張清楚的縮圖在底板上------------------
        Form1.Enabled = True
        Form1.picShowLaser.SizeMode = PictureBoxSizeMode.StretchImage
        imgWidthLimit = ((picResize.Image.Width * pixelStep * 2) ^ 2 + (picResize.Image.Height * pixelStep * 2) ^ 2) ^ 0.5

        Sub_Function.picSizeADJ(PictureBoxOrg, Form1.picShowLaser, imgWidthLimit, 1)
        Dim imgG As New Bitmap(Form1.picShowLaser.Width, Form1.picShowLaser.Height)        '重繪縮圖
        Dim G As Graphics
        G = Graphics.FromImage(imgG)
        G.DrawImage(PictureBoxOrg.Image, 0, 0, Form1.picShowLaser.Width, Form1.picShowLaser.Height)
        picResize.Image = imgG
        picBuff.Image = picResize.Image
        Dim imgY(,) As Integer      ' 儲存亮度資料
        ReDim imgY(imgG.Width + 2, imgG.Height + 2)

        RGBtoGray(imgG, Form1.picShowLaser, imgY, contrastADJ.Value)
        Sub_Function.picChangeGrayLevel(Form1.picShowLaser, grayLevel)
        RGBtoGray(Form1.picShowLaser.Image, Form1.picShowLaser, imgY, contrastADJ.Value)

        Dim imgE As New Bitmap(imgG.Width, imgG.Height)
        Dim imgT(,) As Integer
        ReDim imgT(imgG.Width, imgG.Height)

        GraytoErrDiff(imgY, imgE, imgT)

        Form1.picShowLaser.Image = imgE
        Form1.picShowLaser.Location = New Point(6 + ((Form1.Bed_size_X * 2 - Form1.picShowLaser.Width) / 2), 15 + ((Form1.Bed_size_Y * 2 - Form1.picShowLaser.Height) / 2))
        Form1.picShowLaser.Visible = True
        '----------------------------------------------------------------
        Form1.User_shift_XY_old = Form1.picShowLaser.Location
        Form1.pub_pixelStep = pixelStep

        Form4.Hide()
        Me.Dispose()

    End Sub

End Class
