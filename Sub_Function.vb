Public Class Sub_Function

    Public Shared Sub erdfSizeDisplay(ByVal picIn As PictureBox, ByVal pixelStep As Double)
        Dim edgeBar_Len = 10

        Form4.LineX.X1 = picIn.Location.X
        Form4.LineX.Y1 = picIn.Location.Y - (edgeBar_Len + 5)
        Form4.LineX.X2 = picIn.Width + Form4.LineX.X1
        Form4.LineX.Y2 = Form4.LineX.Y1
        Form4.sizeX.Text = picIn.Width * pixelStep & " mm"
        Form4.sizeX.Location = New Point(((Form4.LineX.X2 - Form4.LineX.X1) - Form4.sizeX.Width) / 2 + Form4.LineX.X1, Form4.LineX.Y1 - (Form4.sizeX.Height / 2))

        Form4.LineXL.X1 = Form4.LineX.X1
        Form4.LineXL.Y1 = Form4.LineX.Y1 - (edgeBar_Len / 2)
        Form4.LineXL.X2 = Form4.LineXL.X1
        Form4.LineXL.Y2 = Form4.LineX.Y1 + (edgeBar_Len / 2)

        Form4.LineXR.X1 = Form4.LineX.X2
        Form4.LineXR.Y1 = Form4.LineX.Y1 - (edgeBar_Len / 2)
        Form4.LineXR.X2 = Form4.LineXR.X1
        Form4.LineXR.Y2 = Form4.LineX.Y1 + (edgeBar_Len / 2)

        Form4.LineY.X1 = picIn.Location.X - (edgeBar_Len + 5)
        Form4.LineY.Y1 = picIn.Location.Y
        Form4.LineY.X2 = Form4.LineY.X1
        Form4.LineY.Y2 = picIn.Height + Form4.LineY.Y1
        Form4.sizeY.Text = picIn.Height * pixelStep & vbCrLf & "mm"
        Form4.sizeY.Location = New Point(Form4.LineY.X1 - (Form4.sizeY.Width / 2), ((Form4.LineY.Y2 - Form4.LineY.Y1) - Form4.sizeX.Height) / 2 + Form4.LineX.Y1)

        Form4.LineYT.X1 = Form4.LineY.X1 - (edgeBar_Len / 2)
        Form4.LineYT.Y1 = Form4.LineY.Y1
        Form4.LineYT.X2 = Form4.LineY.X1 + (edgeBar_Len / 2)
        Form4.LineYT.Y2 = Form4.LineYT.Y1

        Form4.LineYD.X1 = Form4.LineY.X1 - (edgeBar_Len / 2)
        Form4.LineYD.Y1 = Form4.LineY.Y2
        Form4.LineYD.X2 = Form4.LineY.X1 + (edgeBar_Len / 2)
        Form4.LineYD.Y2 = Form4.LineYD.Y1
    End Sub

    Public Shared Function picSizeADJ(ByVal picOrg As PictureBox, ByRef picOut As PictureBox, ByVal sizeMaxLimit As Integer, Optional ByRef Hyposel As Integer = 0)

        Dim picScale As Double
        Dim Hypo As Integer
        Dim resize As Boolean

        If (Hyposel = 0) Then
            If (picOrg.Image.Width > picOrg.Image.Height) Then              ' 如果圖片是橫的
                If (picOrg.Image.Width > sizeMaxLimit) Then                 ' 如果圖片太大，縮圖到 sizeMaxLimit寬
                    resize = True
                    picScale = sizeMaxLimit / picOrg.Image.Width
                    picOut.Width = sizeMaxLimit
                    picOut.Height = Math.Round(picOrg.Image.Height * picScale)
                Else
                    resize = False
                    picOut.Width = picOrg.Image.Width
                    picOut.Height = picOrg.Image.Height
                End If
            Else
                If (picOrg.Image.Height > sizeMaxLimit) Then                ' 如果圖片太大，縮圖到 sizeMaxLimit高
                    resize = True
                    picScale = sizeMaxLimit / picOrg.Image.Height
                    picOut.Height = sizeMaxLimit
                    picOut.Width = Math.Round(picOrg.Image.Width * picScale)
                Else
                    resize = False
                    picOut.Width = picOrg.Image.Width
                    picOut.Height = picOrg.Image.Height
                End If
            End If
        Else
            Hypo = ((picOrg.Image.Width) ^ 2 + (picOrg.Image.Height) ^ 2) ^ (1 / 2)
            If (Hypo > sizeMaxLimit) Then
                resize = True
                picScale = sizeMaxLimit / Hypo
                picOut.Width = Math.Round(picOrg.Image.Width * picScale)
                picOut.Height = Math.Round(picOrg.Image.Height * picScale)
            Else
                resize = False
                picOut.Width = picOrg.Image.Width
                picOut.Height = picOrg.Image.Height
            End If
        End If

        Return resize
    End Function

    Public Shared Function AllpicSizeADJ(ByVal picIn As PictureBox, ByRef PictureBoxOrg As PictureBox, ByRef ErrDiff As PictureBox, ByRef PictureBoxGray As PictureBox, ByRef PictureBoxPreview As PictureBox, ByVal imgWidthLimit As Integer, ByVal imgPreSize As Integer, ByVal imgPreSizeBig As Integer)

        Dim resize As Boolean
        resize = Sub_Function.picSizeADJ(picIn, ErrDiff, imgWidthLimit, 1)   ' 調整 ErrDiff 顯示尺寸

        Sub_Function.picSizeADJ(picIn, PictureBoxOrg, imgPreSize)                ' 調整 預覽原圖 顯示尺寸
        Sub_Function.putInCenter(Form3.picOrgBack, PictureBoxOrg)

        Sub_Function.picSizeADJ(picIn, PictureBoxGray, imgPreSize)               ' 調整 預覽灰階圖 顯示尺寸
        Sub_Function.putInCenter(Form3.picGrayBack, PictureBoxGray)

        PictureBoxPreview.Image = PictureBoxOrg.Image                            ' 調整 大張預覽圖 顯示尺寸
        Sub_Function.picSizeADJ(picIn, PictureBoxPreview, imgPreSizeBig)
        Sub_Function.putInCenter(Form3.picPrevBack, PictureBoxPreview)

        Return resize
    End Function

    Public Shared Sub BitmaptoMem(ByVal picIn As Bitmap, ByRef picMem() As Byte)
        ' Lock the bitmap's bits.  
        Dim rect As New Rectangle(0, 0, picIn.Width, picIn.Height)              ' 圖片大小
        Dim bmpData As System.Drawing.Imaging.BitmapData = picIn.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, picIn.PixelFormat)     ' 建立 BitmapData 元件
        ' Get the address of the first line.
        Dim ptr As IntPtr = bmpData.Scan0                                       ' 建立指向圖片第一行的指標
        ' Declare an array to hold the bytes of the bitmap.
        ' This code is specific to a bitmap with 24 bits per pixels.
        Dim bytes As Integer = 4 * picIn.Width * picIn.Height          ' 計算圖片記憶體大小 [(R+G+B+A)*Width]*Height Bytes 'Stride屬性會輸出單列像素(掃描線)的寬度(R+G+B+A)*Width Bytes
        ''Dim rgbValues(bytes - 1) As Byte                                        ' 建立陣列儲存圖片資訊
        ' Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, picMem, 0, bytes)   ' 複製 ptr指標的值 到rgbValues, 從 ptr+0 開始複製 bytes 筆資料 ' Marshal.Copy(source As IntPtr,destination As Byte(),startIndex As Integer,length As Integer)
        ' Unlock the bits.
        picIn.UnlockBits(bmpData)       ' 解除記憶體鎖定
    End Sub

    Public Shared Sub MemtoBitmap(ByVal picMem() As Byte, ByRef picOut As Bitmap)

        Dim picBuff As New Bitmap(picOut.Width, picOut.Height)
        ' Lock the bitmap's bits.  
        Dim rect As New Rectangle(0, 0, picBuff.Width, picBuff.Height)              ' 圖片大小
        Dim bmpData As System.Drawing.Imaging.BitmapData = picBuff.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, picBuff.PixelFormat)     ' 建立 BitmapData 元件
        ' Get the address of the first line.
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = 4 * picOut.Width * picOut.Height          ' 計算圖片記憶體大小 [(R+G+B+A)*Width]*Height Bytes 'Stride屬性會輸出單列像素(掃描線)的寬度(R+G+B+A)*Width Bytes
        System.Runtime.InteropServices.Marshal.Copy(picMem, 0, ptr, bytes)

        picOut = picBuff
        ' Unlock the bits.
        picBuff.UnlockBits(bmpData)       ' 解除記憶體鎖定

    End Sub

    Public Shared Sub picChangeGrayLevel(ByRef picIn As PictureBox, ByVal grayLevel As Integer)

        Dim grayLevelValue As Integer = 255 / grayLevel
        Dim grayLevelList() As Integer
        ReDim grayLevelList(grayLevel)
        Dim grayLevelListIndex As Integer

        Dim picbuf As New Bitmap(picIn.Image.Width, picIn.Image.Height)
        Dim picMem() As Byte
        ReDim picMem((4 * picbuf.Width * picbuf.Height) - 1)

        For i As Integer = 0 To grayLevel - 1
            If (i = 0) Then
                grayLevelList(i) = 0
            ElseIf (i = grayLevel - 1) Then
                grayLevelList(i) = 255
            Else
                grayLevelList(i) = i * grayLevelValue
            End If
        Next

        Sub_Function.BitmaptoMem(picIn.Image, picMem)
        Dim PW As Integer = picIn.Image.Width

        For yy As Integer = 0 To picIn.Image.Height - 1
            For xx As Integer = 0 To picIn.Image.Width - 1
                grayLevelListIndex = picMem(yy * 4 * PW + xx * 4 + 0) \ grayLevelValue
                picMem(yy * 4 * PW + xx * 4 + 0) = grayLevelList(grayLevelListIndex)
                picMem(yy * 4 * PW + xx * 4 + 1) = grayLevelList(grayLevelListIndex)
                picMem(yy * 4 * PW + xx * 4 + 2) = grayLevelList(grayLevelListIndex)
                picMem(yy * 4 * PW + xx * 4 + 3) = 255
            Next
        Next

        Sub_Function.MemtoBitmap(picMem, picIn.Image)

    End Sub

    Public Shared Function GrayPictoGcode(ByRef imgC(,) As Integer)

        Dim dteStart As DateTime = Now
        Dim gcode_tmp As New System.Text.StringBuilder("")

        Dim preStep As Integer = 2
        Dim step_continue As Integer = 0
        Dim Blackdot As Double = 0
        Dim Whitedot As Double = 0
        Dim firstWhite As Integer = 0
        Dim Y_coordinator As Double = 0
        Dim imgX, imgY As Integer
        Dim imgY_end As Integer
        Dim imgX_start, imgX_end, imgX_step, imgX_tmp As Integer
        Dim Laser_engrav_speed As Integer = Form1.LaserCut_Speed_Set.Text             ' mm/min, pixelStep mm/0.08s
        Dim Laser_engrav_startstopTime As Integer = (60 / (Laser_engrav_speed / Form1.pub_pixelStep)) * 1000     ' ms, 每個pixel所花費的時間
        Dim Laser_move_speed As Integer = Form1.LaserMove_Speed.Text
        Dim X_shiftToCenter As Integer
        Dim Y_shiftToCenter As Integer
        Dim _User_shift_XY As Point = New Point(Form1.User_shift_XY.X / 2, 0 - (Form1.User_shift_XY.Y / 2))

        Dim HeadReader As String                '標頭檔暫存變數
        Dim LastReader As String                '標尾檔暫存變數
        HeadReader = My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\..\Head.txt")  '預設的標頭檔
        LastReader = My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\..\Last.txt")

        Dim GX0 As Double = 0
        Dim GY0 As Double = 0
        Dim GX As Double = 0
        Dim GY As Double = 0
        Dim moveTime As Integer     ' millisecond
        Dim moveTimeShort As Integer     ' millisecond
        Dim restTimes As Integer
        Dim coolTime As Integer = 180  'second

        ''Use to debug
        'PictureBoxOrg.Width = 12
        'PictureBoxOrg.Height = 2
        'ReDim imgA(12, 2)
        'imgA = {{0, 255}, {255, 0}, {0, 255}, {0, 255}, {255, 0}, {255, 0}, {0, 255}, {0, 255}, {0, 255}, {255, 0}, {255, 0}, {255, 0}}
        'pixel_size = 1
        ''Use to debug

        moveTime = 0
        restTimes = 0
        imgX_start = 0
        imgX_end = UBound(imgC, 1) - 1
        imgX_step = 1
        imgX_tmp = 0
        imgY_end = UBound(imgC, 2) - 1
        X_shiftToCenter = -CInt(imgX_end / 2)
        Y_shiftToCenter = CInt(imgY_end / 2)    '因為向第二象限移動，故 X需變小，Y需變大
        Form1.X_max = (imgX_end + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
        Form1.X_min = (0 + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
        Form1.Y_max = (imgY_end + (0 - Y_shiftToCenter)) * Form1.pub_pixelStep + _User_shift_XY.Y
        Form1.Y_min = (0 + (0 - Y_shiftToCenter)) * Form1.pub_pixelStep + _User_shift_XY.Y

        gcode_tmp.Clear()
        gcode_tmp.Append(Head_Comment.Head_comment_set())
        gcode_tmp.Append(HeadReader & vbCrLf)
        gcode_tmp.Append(Head_Comment.Check_position_set())
        gcode_tmp.Append("G0 Z" & Form1.Laser_Height_set & vbCrLf)

        For imgY = 0 To imgY_end
            Application.DoEvents()
            Form1.ProgressBar1.Value = (imgY / imgY_end) * 100
            Form1.Label1.Text = Form1.ProgressBar1.Value & " %"
            'Form1.Label1.Text = imgY & " / " & imgY_end
            For imgX = imgX_start To imgX_end Step imgX_step
                Y_coordinator = 0 - imgY                    ' 配合3D印表座標系統，設定由上往下雕刻
                If (imgC(imgX, imgY) = 0) Then             '黑點
                    Select Case preStep
                        Case 0  '前一點為黑點
                            Blackdot = Blackdot + 1
                        Case 1  '前一點為白點
                            gcode_tmp.Append("M106 S0" & vbCrLf &
                                             "G1 F" & Laser_move_speed & vbCrLf &
                                             "G4 P" & Laser_engrav_startstopTime & vbCrLf)
                            'If (firstWhite = 0) Then               ' 跳過無意義的白色部份，因會有移動誤差，故暫不使用
                            GX = ((imgX - Whitedot * imgX_step) + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                            GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                            GX0 = GX
                            GY0 = GY
                            gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf)

                            GX = ((imgX - 1 * imgX_step) + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                            GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                            gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf & vbCrLf)
                            moveTime += (Sub_Function.culMoveLen(GX0, GY0, GX, GY) / ((Laser_move_speed / 60) / 1000)) + Laser_engrav_startstopTime

                            If (Sub_Function.culMoveLen(GX, GY, 0, 0) > ((Form1.planSize / 2) + 1)) Then
                                Form1.errCode = -1
                            End If
                            'Else
                            'GX = (imgX - 1 * imgX_step) * pixel_size
                            'GY = Y_coordinator * pixel_size
                            'gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf & vbCrLf)
                            'firstWhite = 0
                            'gcode_tmp.Append(vbCrLf)
                            'End If
                            Whitedot = 0
                            Blackdot = 1
                        Case 2  '這是第一點
                            Blackdot = 1
                    End Select
                    If (imgX = imgX_end) Then
                        GX = (((imgX - Blackdot + 1) * imgX_step) + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                        GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                        GX0 = GX
                        GY0 = GY
                        gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf)

                        gcode_tmp.Append("M106 S255" & vbCrLf &
                                         "G1 F" & Laser_engrav_speed & vbCrLf &
                                         "G4 P" & Laser_engrav_startstopTime & vbCrLf)

                        GX = (imgX + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                        GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                        gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf & vbCrLf)

                        moveTime += (Sub_Function.culMoveLen(GX0, GY0, GX, GY) / ((Laser_engrav_speed / 60) / 1000)) + Laser_engrav_startstopTime
                        If (Sub_Function.culMoveLen(GX, GY, 0, 0) > ((Form1.planSize / 2) + 1)) Then
                            Form1.errCode = -1
                        End If
                    End If
                    preStep = 0
                Else                        '白點
                    Select Case preStep
                        Case 0  '前一點為黑點
                            GX = ((imgX - Blackdot * imgX_step) + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                            GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                            GX0 = GX
                            GY0 = GY
                            gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf)

                            gcode_tmp.Append("M106 S255" & vbCrLf &
                                             "G1 F" & Laser_engrav_speed & vbCrLf &
                                             "G4 P" & Laser_engrav_startstopTime & vbCrLf)

                            GX = ((imgX - 1 * imgX_step) + X_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.X
                            GY = (Y_coordinator + Y_shiftToCenter) * Form1.pub_pixelStep + _User_shift_XY.Y
                            gcode_tmp.Append("G0 X" & GX & " Y" & GY & vbCrLf & vbCrLf)

                            moveTime += (Sub_Function.culMoveLen(GX0, GY0, GX, GY) / ((Laser_engrav_speed / 60) / 1000)) + Laser_engrav_startstopTime
                            If (Sub_Function.culMoveLen(GX, GY, 0, 0) > ((Form1.planSize / 2) + 1)) Then
                                Form1.errCode = -1
                            End If

                            Blackdot = 0
                            Whitedot = 1
                        Case 1  '前一點為白點
                            Whitedot = Whitedot + 1
                        Case 2  '這是第一點
                            firstWhite = 1
                            Whitedot = 1
                    End Select
                    preStep = 1
                End If
                If (Form1.errCode = -1) Then
                    Exit For
                End If
            Next imgX

            gcode_tmp.Append("M106 S0" & vbCrLf &
                             "G1 F" & Laser_move_speed & vbCrLf &
                             "G4 P" & Laser_engrav_startstopTime & "　　　;Line:" & imgY & vbCrLf & vbCrLf)
            moveTime += Laser_engrav_startstopTime

            If ((moveTime - moveTimeShort) >= Form1.workTime * 1000) Then
                moveTimeShort = moveTime
                restTimes += 1
                gcode_tmp.Append("M106 S0" & vbCrLf & vbCrLf)
                gcode_tmp.Append("G4 S" & coolTime & "　　　; Cooling for " & coolTime & " minutes，" & restTimes & " Times " & vbCrLf & vbCrLf)
                'Form1.Log_Data.AppendText("冷卻第 " & restTimes & " 次，在 Line:" & imgY & " 。" & vbCrLf)
            End If
            preStep = 2
            Blackdot = 0
            Whitedot = 0
            firstWhite = 0
            'imgX_tmp = imgX_start          '來回移動雕刻功能，因會有移動誤差，故暫不使用
            'imgX_start = imgX_end
            'imgX_end = imgX_tmp
            'imgX_step = 0 - imgX_step
            If (Form1.errCode = -1) Then
                Exit For
            End If
        Next imgY

        gcode_tmp.Append(LastReader & vbCrLf)

        'Form1.Log_Data.Clear()
        If (Form1.errCode = -1) Then
            Form1.Log_Data.AppendText("超出雕刻範圍！建議縮小尺寸或是移動位置！" & vbCrLf)
        Else
            If ((((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60)) > 60) Then   ' 大於1小時
                Form1.Log_Data.AppendText(">>>[ 雕刻時間約為: " & Format((((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60)) / 60, "#####.##") & " 小時 ]<<<" & vbCrLf)
                MsgBox("此檔案預計將會雕刻 " & Format((((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60)) / 60, "#####.##") & " 小時" & vbCrLf &
                       "每" & Form1.workTime / 60 & "分鐘將進行1次強制冷卻，總計 " & restTimes & "次，每次 3分鐘" & vbCrLf &
                       "冷卻時機器將會暫停，時間到後會自動啟動，請不用擔心！", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "強制冷卻通知")
            ElseIf ((((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60)) < 1) Then    ' 小於1分鐘
                Form1.Log_Data.AppendText(">>>[ 雕刻時間約為: " & Format((moveTime / 1000) + (restTimes * coolTime), "#####.##") & " 秒鐘 ]<<<" & vbCrLf)
            Else                                                                        ' 小於1小時
                Form1.Log_Data.AppendText(">>>[ 雕刻時間約為: " & Format(((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60), "#####.##") & " 分鐘 ]<<<" & vbCrLf)
                If (restTimes > 0) Then
                    MsgBox("此檔案預計將會雕刻 " & Format(((moveTime / 1000) / 60) + ((restTimes * coolTime) / 60), "#####.##") & " 分鐘" & vbCrLf &
                           "每" & Form1.workTime / 60 & "分鐘將進行1次強制冷卻，總計 " & restTimes & "次，每次 3分鐘" & vbCrLf &
                           "冷卻時機器將會暫停，時間到後會自動啟動，請不用擔心！", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "強制冷卻通知")
                End If

            End If
        End If

        If (Form1.debugDisplay) Then
            Dim TS As TimeSpan = Now.Subtract(dteStart)
            Form1.Log_Data.AppendText("> 轉換G-Code執行時間: " & TS.TotalMilliseconds / 1000 & " 秒" & vbCrLf)
        End If

        Return gcode_tmp
    End Function

    Public Shared Sub putInCenter(ByVal stcCtrl As Control, ByRef moveCtrl As Control)
        moveCtrl.Location = New Point(stcCtrl.Location.X + ((stcCtrl.Width - moveCtrl.Width) / 2), stcCtrl.Location.Y + ((stcCtrl.Height - moveCtrl.Height) / 2))
    End Sub

    Public Shared Function culMoveLen(ByRef X0 As Double, ByRef Y0 As Double, ByRef X1 As Double, ByRef Y1 As Double)
        Dim Len As Double
        Len = ((X0 - X1) ^ 2 + (Y0 - Y1) ^ 2) ^ 0.5
        Return Len
    End Function

End Class
