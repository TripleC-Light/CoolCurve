'   _______________              __         _______
'  /              / __          / /        / _____ \
' /_____   ______/ /_/         / /        / /    /_/
'      / / _____  __ _____    / / ___    / /
'     / / / ___/ / / / __ \  / / / _ \  / /    __  __
'    / / / /    / / / /_/ / / / /  __/ / /____/ / / / __
'   /_/ /_/    /_/ / ____/ /_/  \___/  \_______/ /_/ /_/ // 
'                 / /
'                /_/
Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class imgProc
    '----- 外部提取的影像資料
    Public imgOrig As Bitmap
    Public imgGray As Bitmap
    Public imgCanny As Bitmap
    Public imgEdge As Bitmap
    Public imgErrDiff As Bitmap
    '----- 外部提取的Gcode資料
    Public gcode_tmp As New System.Text.StringBuilder("")
    Public gcode_ErrDiff As System.Text.StringBuilder
    Public gcode_Edge As System.Text.StringBuilder
    Public gcode_Canny As System.Text.StringBuilder

    '----- 外部設定變數
    Public thresCannyLow As Integer = 100
    Public thresCannyHigh As Integer = 200

    '----- 內部運算用的影像暫存
    Private _imgIn As Image(Of Bgr, Byte)
    Private _imgGray As Image(Of Gray, Byte)
    Private _imgCanny As Image(Of Gray, Byte)
    Private _imgTempGray As Image(Of Gray, Byte)
    Private _imgEdge As Image(Of Gray, Byte)
    Private _imgErrDiff As Image(Of Gray, Byte)
    Private linkFlag(,) As Boolean
    Private whiteDot As Byte = 255
    Private blackDot As Byte = 0
    Private vectorCnt As Byte = 0
    Private vectorLen As Byte = 0
    Private testFlag As Boolean = False
    Private gcode_last As String
    Private stackCount As Integer = 0
    Private stackLimit As Integer = 2000
    Private stackTemp(2) As Integer
    Private linkFinish As Boolean = False

    ' 建構子函數
    ' 說明- 建立物件 並初始化 imgOrig,_imgIn
    ' 輸入- FileName:檔案路徑
    Public Sub New(ByVal FileName As String)
        _imgIn = New Image(Of Bgr, Byte)(FileName)
        imgOrig = _imgIn.ToBitmap
    End Sub

    ' 建構子函數
    ' 說明- 建立物件 並初始化 imgOrig,_imgIn
    ' 輸入- Bitmap 格式影像
    Public Sub New(ByVal imgInput As Bitmap)
        _imgIn = New Image(Of Bgr, Byte)(imgInput)
        imgOrig = imgInput
    End Sub

    ' 影像灰階化
    ' 說明- 將輸入影像灰階化 並存入 imgGray,_imgGray
    ' 輸入- Bitmap 格式影像
    ' 輸出- Bitmap 格式影像
    Public Function Gray(ByVal imgInput As Bitmap)
        _imgGray = New Image(Of Gray, Byte)(imgInput)
        imgGray = _imgGray.ToBitmap
        Return (imgGray)
    End Function

    ' 灰階影像顏色反轉
    ' 說明- 將輸入影像顏色反轉 並存入 _imgTempGray 此函示會將影像轉為灰階顯示
    ' 輸入- Bitmap 格式影像
    ' 輸出- Bitmap 格式影像
    Public Function Reverse(ByVal imgInput As Bitmap)
        Dim xx, yy As Integer
        _imgTempGray = New Image(Of Gray, Byte)(imgInput)

        _imgTempGray = _imgTempGray.Not()
        'For yy = 0 To (_imgTempGray.Height - 1)
        '    For xx = 0 To (_imgTempGray.Width - 1)
        '        _imgTempGray.Data(yy, xx, 0) = 255 - _imgTempGray.Data(yy, xx, 0)
        '    Next xx
        'Next yy

        Return (_imgTempGray.ToBitmap)
    End Function

    ' Canny 尋邊演算法
    ' 說明- 尋找影像邊緣 並存入 imgCanny,_imgCanny
    ' 　　  可透過變數 thresCannyLow,thresCannyHigh 設定演算法高低閥值
    ' 輸入- imgInput: Bitmap 格式影像
    ' 輸出- Bitmap 格式影像
    Public Function Canny(ByVal imgInput As Bitmap)
        Me.Gray(imgInput)
        _imgCanny = _imgGray.Canny(thresCannyLow, thresCannyHigh)
        imgCanny = _imgCanny.ToBitmap
        Return (imgCanny)
    End Function

    Public Function errDiff(ByVal imgInput As Bitmap)
        Dim xx, yy As Integer
        Dim imgErr As Integer
        Dim _imgTemp(,) As Integer
        Dim errdiff_PARM() As Double = {7 / 16, 3 / 16, 5 / 16, 1 / 16}

        Me.Gray(imgInput)
        _imgErrDiff = New Image(Of Gray, Byte)(imgInput)

        ReDim _imgTemp(_imgErrDiff.Height, _imgErrDiff.Width)
        fillColor(_imgErrDiff, whiteDot)

        For yy = 0 To (_imgErrDiff.Height - 1)
            For xx = 0 To (_imgErrDiff.Width - 1)
                _imgTemp(yy, xx) = _imgGray.Data(yy, xx, 0)
            Next
        Next

        For yy = 0 To (_imgErrDiff.Height - 1)
            For xx = 0 To (_imgErrDiff.Width - 1)
                If (_imgTemp(yy, xx) < 128) Then
                    imgErr = _imgTemp(yy, xx)
                    _imgErrDiff.Data(yy, xx, 0) = blackDot
                Else
                    imgErr = _imgTemp(yy, xx) - 255
                    _imgErrDiff.Data(yy, xx, 0) = whiteDot
                End If
                If ((yy - 1) >= 0 And (yy + 1) <= _imgErrDiff.Height - 1) Then
                    If ((xx - 1) >= 0 And (xx + 1) <= _imgErrDiff.Width - 1) Then
                        _imgTemp(yy, xx + 1) = _imgTemp(yy, xx + 1) + (imgErr * errdiff_PARM(0))
                        _imgTemp(yy + 1, xx - 1) = _imgTemp(yy + 1, xx - 1) + (imgErr * errdiff_PARM(1))
                        _imgTemp(yy + 1, xx) = _imgTemp(yy + 1, xx) + (imgErr * errdiff_PARM(2))
                        _imgTemp(yy + 1, xx + 1) = _imgTemp(yy + 1, xx + 1) + (imgErr * errdiff_PARM(3))
                    End If
                End If
            Next xx
        Next yy

        imgErrDiff = _imgErrDiff.ToBitmap
        imgErrDiff = Me.Reverse(imgErrDiff)
        _imgErrDiff = New Image(Of Gray, Byte)(imgErrDiff)
        Return (imgErrDiff)
    End Function

    Public Function errdiffGcode(ByVal imgInput As Bitmap)
        Dim startX As Integer = 0
        Me.errDiff(imgInput)
        gcode_tmp.Clear()
        gcode_last = "OFF"

        For yy = 0 To (_imgErrDiff.Height - 1)
            For xx = 0 To (_imgErrDiff.Width - 1)
                If (_imgErrDiff.Data(yy, xx, 0) = whiteDot) Then
                    If (gcode_last = "OFF") Then
                        gcode_tmp.Append(xx & " " & yy & vbCrLf)
                        gcode_last = "XY"
                        startX = xx
                    ElseIf (xx = (_imgErrDiff.Width - 1)) Then
                        gcode_tmp.Append(xx & " " & yy & vbCrLf)
                    End If
                Else
                    If (gcode_last <> "OFF") Then
                        If ((xx - 1) <> startX) Then
                            gcode_tmp.Append(xx - 1 & " " & yy & vbCrLf)
                        End If
                        gcode_tmp.Append("OFF" & vbCrLf)
                        gcode_last = "OFF"
                    End If
                End If
            Next xx
            If (gcode_last <> "OFF") Then
                gcode_tmp.Append("OFF" & vbCrLf)
                gcode_last = "OFF"
            End If
        Next yy

        gcode_ErrDiff = New System.Text.StringBuilder(gcode_tmp.ToString)
        gcode_tmp.Clear()
        Return (imgErrDiff)

    End Function

    Public Function cannyGcode(ByVal imgInput As Bitmap)
        Me.Canny(imgInput)
        _imgTempGray = New Image(Of Gray, Byte)(imgInput.Width, imgInput.Height)

        ReDim linkFlag(_imgCanny.Height, _imgCanny.Width)
        For yy = 0 To (_imgCanny.Height - 1)
            For xx = 0 To (_imgCanny.Width - 1)
                linkFlag(yy, xx) = False
            Next xx
        Next yy
        Me.fillColor(_imgTempGray, blackDot)
        gcode_tmp.Clear()

        stackCount = 0
        For yy = 0 To (_imgCanny.Height - 1)
            For xx = 0 To (_imgCanny.Width - 1)
                If (_imgCanny.Data(yy, xx, 0) = whiteDot And linkFlag(yy, xx) = False) Then
                    linkLine(yy, xx, _imgCanny, 3)
                    If (stackCount > stackLimit) Then
                        stackCount = 0
                    End If
                End If
            Next xx
        Next yy

        gcode_Canny = New System.Text.StringBuilder(gcode_tmp.ToString)
        gcode_tmp.Clear()
        Return (_imgCanny.ToBitmap)
    End Function

    Public Function addCutEdge(ByVal imgInput As Bitmap, ByVal DilateLevel As Integer)

        Me.Canny(imgInput)
        _imgEdge = New Image(Of Gray, Byte)(imgInput.Width + (DilateLevel * 4), imgInput.Height + (DilateLevel * 4))
        _imgTempGray = New Image(Of Gray, Byte)(imgInput.Width + (DilateLevel * 4), imgInput.Height + (DilateLevel * 4))
        '置中影像
        Dim shiftPixel As Integer = DilateLevel * 2
        For yy = 0 To (imgInput.Height - 1)
            For xx = 0 To (imgInput.Width - 1)
                _imgEdge.Data(yy + shiftPixel, xx + shiftPixel, 0) = _imgCanny.Data(yy, xx, 0)
            Next xx
        Next yy
        '擴張線條來得到邊框線
        _imgEdge = _imgEdge.Dilate(DilateLevel)
        '將擴張後的線條取邊緣來得到1pixel邊框線
        _imgEdge = _imgEdge.Canny(10, 20)

        '將邊框線1pixel化
        ReDim linkFlag(_imgEdge.Height, _imgEdge.Width)
        For yy = 0 To (_imgEdge.Height - 1)
            For xx = 0 To (_imgEdge.Width - 1)
                linkLine(yy, xx, _imgEdge)
                stackCount = 0
            Next xx
        Next yy
        _imgEdge = New Image(Of Gray, Byte)(_imgTempGray.ToBitmap)         '儲存邊框線計算資料
        'Form1.ibOriginal.Image = New Image(Of Gray, Byte)(_imgTempGray.ToBitmap)

        '只取最外緣的邊框線
        ReDim linkFlag(_imgEdge.Height, _imgEdge.Width)
        For yy = 0 To (_imgEdge.Height - 1)
            For xx = 0 To (_imgEdge.Width - 1)
                linkFlag(yy, xx) = False
            Next xx
        Next yy
        Me.fillColor(_imgTempGray, blackDot)

        linkFinish = False
        stackCount = 0
        For yy = 0 To (_imgEdge.Height - 1)
            For xx = 0 To (_imgEdge.Width - 1)
                If (_imgEdge.Data(yy, xx, 0) = whiteDot And linkFinish = False) Then
                    gcode_tmp.Append(xx & " " & yy & vbCrLf)
                    linkLine(yy, xx, _imgEdge, 5)
                    If (stackCount > stackLimit) Then
                        stackCount = 0
                        linkLine(stackTemp(1), stackTemp(0), _imgEdge, 5)
                    Else
                        linkFinish = True
                    End If
                End If
            Next xx
        Next yy
        _imgEdge = _imgTempGray         '儲存邊框線計算資料

        '封閉曲線
        '尋找線段端點,並將其連接為封閉曲線
        '效果不明確且計算時間長，使用侵蝕擴張效果較好
        'findEndPoint(_imgEdge)

        gcode_Edge = New System.Text.StringBuilder(gcode_tmp.ToString)
        gcode_tmp.Clear()
        imgEdge = _imgEdge.ToBitmap
        'Return (and2Pic(imgCanny, imgEdge, DilateLevel))
        Return (imgEdge)

    End Function

    Private Function and2Pic(ByVal imgA As Bitmap, ByVal imgB As Bitmap, ByVal DilateLevel As Integer)
        Dim _imgA As Image(Of Gray, Byte) = New Image(Of Gray, Byte)(imgA)
        Dim _imgB As Image(Of Gray, Byte) = New Image(Of Gray, Byte)(imgB)
        DilateLevel *= 2

        For yy = 0 To (_imgA.Height - 1)
            For xx = 0 To (_imgA.Width - 1)
                If (_imgA.Data(yy, xx, 0) = whiteDot) Then
                    _imgB.Data(yy + DilateLevel, xx + DilateLevel, 0) = whiteDot
                End If
            Next xx
        Next yy

        Return (_imgB.ToBitmap)
    End Function

    '尋邊
    Private Sub linkLine(ByVal nY As Integer, ByVal nX As Integer, ByVal img As Image(Of Gray, Byte), ByVal maskSize As Integer)

        If (stackCount > stackLimit) Then
            stackTemp(0) = nX
            stackTemp(1) = nY
        Else
            stackCount += 1
            Dim sX As Integer = 0
            Dim sY As Integer = 1
            Dim i As Integer
            Dim ShiftMask(,) As Integer = {{-1, -1}, {0, -1}, {1, -1}, {-1, 0}, {1, 0}, {-1, 1}, {0, 1}, {1, 1},
                                           {-2, -2}, {-1, -2}, {0, -2}, {1, -2}, {2, -2},
                                           {-2, -1}, {2, -1}, {-2, 0}, {2, 0}, {-2, 1},
                                           {2, 1}, {-2, 2}, {-1, 2}, {0, 2}, {1, 2}, {2, 2}}
            If (img.Data(nY, nX, 0) = whiteDot And linkFlag(nY, nX) = False) Then
                linkFlag(nY, nX) = True
                _imgTempGray.Data(nY, nX, 0) = whiteDot
                If (vectorCnt < vectorLen) Then
                    vectorCnt += 1
                Else
                    vectorCnt = 0
                    gcode_tmp.Append(nX & " " & nY & vbCrLf)
                    gcode_last = "XY"
                End If

                For i = 0 To ((maskSize ^ 2) - 1 - 1)
                    If ((nY + ShiftMask(i, sY)) >= 0 And (nY + ShiftMask(i, sY)) <= img.Height - 1) Then
                        If ((nX + ShiftMask(i, sX)) >= 0 And (nX + ShiftMask(i, sX)) <= img.Width - 1) Then

                            If (img.Data(nY + ShiftMask(i, sY), nX + ShiftMask(i, sX), 0) = whiteDot And linkFlag(nY + ShiftMask(i, sY), nX + ShiftMask(i, sX)) = False) Then
                                linkLine(nY + ShiftMask(i, sY), nX + ShiftMask(i, sX), img, maskSize)
                            End If

                        End If
                    End If
                Next
                If (gcode_last <> "OFF") Then
                    gcode_tmp.Append("OFF" & vbCrLf)
                    gcode_last = "OFF"
                End If
            End If
        End If
    End Sub

    '尋邊細線化為1pixel
    Private Sub linkLine(ByVal nY As Integer, ByVal nX As Integer, ByVal img As Image(Of Gray, Byte))

        If (stackCount > stackLimit) Then
            stackTemp(0) = nX
            stackTemp(1) = nY
        Else
            stackCount += 1
            Dim i As Integer
            Dim j As Integer
            Dim connectCnt As Integer = 0
            If (img.Data(nY, nX, 0) = whiteDot And linkFlag(nY, nX) = False) Then
                linkFlag(nY, nX) = True
                _imgTempGray.Data(nY, nX, 0) = whiteDot
                For j = 0 To 2
                    If ((nY + (j - 1)) >= 0 And (nY + (j - 1)) <= img.Height - 1) Then
                        For i = 0 To 2
                            If ((nX + (i - 1)) >= 0 And (nX + (i - 1)) <= img.Width - 1) Then
                                If (j = 1 And i = 1) Then
                                Else
                                    If (img.Data(nY + (j - 1), nX + (i - 1), 0) = whiteDot And linkFlag(nY + (j - 1), nX + (i - 1)) = False) Then
                                        connectCnt += 1
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                If (testFlag) Then
                    If (connectCnt >= 2) Then
                        img.Data(nY + 1, nX, 0) = blackDot
                        img.Data(nY - 1, nX, 0) = blackDot
                        img.Data(nY, nX + 1, 0) = blackDot
                        img.Data(nY, nX - 1, 0) = blackDot
                    End If
                Else
                    testFlag = True
                End If
                connectCnt = 0

                For j = 0 To 2
                    If ((nY + (j - 1)) >= 0 And (nY + (j - 1)) <= img.Height - 1) Then
                        For i = 0 To 2
                            If ((nX + (i - 1)) >= 0 And (nX + (i - 1)) <= img.Width - 1) Then
                                If (j = 1 And i = 1) Then
                                Else
                                    If (img.Data(nY + (j - 1), nX + (i - 1), 0) = whiteDot And linkFlag(nY + (j - 1), nX + (i - 1)) = False) Then
                                        linkLine(nY + (j - 1), nX + (i - 1), img)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub fillColor(ByRef img As Image(Of Gray, Byte), ByVal color As Byte)
        For yy = 0 To (img.Height - 1)
            For xx = 0 To (img.Width - 1)
                img.Data(yy, xx, 0) = color
            Next xx
        Next yy
    End Sub

    '尋找線段端點
    Private Function findEndPoint(ByRef img As Image(Of Gray, Byte))
        Dim endPointList As New List(Of Point)
        Dim connDot As Integer = 0

        '將所有線段端點存入endPointList
        For yy = 0 To (img.Height - 1)
            For xx = 0 To (img.Width - 1)
                If (img.Data(yy, xx, 0) = 0) Then
                    For j = 0 To 2
                        If ((yy + (j - 1)) >= 0 And (yy + (j - 1)) < img.Height - 1) Then
                            For i = 0 To 2
                                If ((xx + (i - 1)) >= 0 And (xx + (i - 1)) < img.Width - 1) Then
                                    If (j = 1 And i = 1) Then
                                    Else
                                        If (img.Data(yy + (j - 1), xx + (i - 1), 0) = 0) Then
                                            connDot += 1
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Next
                    If (connDot = 1) Then
                        endPointList.Add(New Point(xx, yy))
                    End If
                    connDot = 0
                End If
            Next xx
        Next yy

        If (endPointList.Count > 1) Then
            '將2端點間的所有連線長度及所對應的2端點座標存入distList
            Dim ind As Integer = 0
            Dim lineNum As Integer = ((endPointList.Count - 1) * endPointList.Count) / 2
            Dim distList(,) As Object
            ReDim distList(lineNum - 1, 2)
            For yy = 0 To (endPointList.Count - 1)
                For xx = yy + 1 To (endPointList.Count - 1)
                    distList(ind, 0) = endPointList(yy)
                    distList(ind, 1) = endPointList(xx)
                    distList(ind, 2) = dist2point(endPointList(yy), endPointList(xx))
                    ind += 1
                Next
            Next

            '將線段長度由短到長排序
            Dim swapTemp(1, 2) As Object
            For xx = 0 To (lineNum - 1)
                For yy = 0 To (lineNum - 2)
                    If (distList(yy, 2) > distList(yy + 1, 2)) Then
                        swapTemp(0, 0) = distList(yy, 0)
                        swapTemp(0, 1) = distList(yy, 1)
                        swapTemp(0, 2) = distList(yy, 2)

                        distList(yy, 0) = distList(yy + 1, 0)
                        distList(yy, 1) = distList(yy + 1, 1)
                        distList(yy, 2) = distList(yy + 1, 2)

                        distList(yy + 1, 0) = swapTemp(0, 0)
                        distList(yy + 1, 1) = swapTemp(0, 1)
                        distList(yy + 1, 2) = swapTemp(0, 2)
                    End If
                Next
            Next

            '將前50%短的線段連接
            For xx = 0 To (Math.Ceiling(lineNum / 2) - 1)
                If (distList(xx, 2) < 10) Then
                    line(distList(xx, 0).X, distList(xx, 0).Y, distList(xx, 1).X, distList(xx, 1).Y, img, blackDot)
                End If
            Next
        End If
        Return True

    End Function

    '計算2點長度
    Private Function dist2point(ByVal p1 As Point, ByVal p2 As Point)
        Return (((p1.X - p2.X) ^ 2) + ((p1.Y - p2.Y) ^ 2)) ^ 0.5
    End Function

    '計算2點長度
    Private Function dist2point(ByVal X0 As Integer, ByVal Y0 As Integer, ByVal X1 As Integer, ByVal Y1 As Integer)
        Return (((X0 - X1) ^ 2) + ((Y0 - Y1) ^ 2)) ^ 0.5
    End Function

    '畫直線
    Private Sub line(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByRef img As Image(Of Gray, Byte), ByVal color As Integer)
        Dim steep As Boolean
        If (Math.Abs(y1 - y0) > Math.Abs(x1 - x0)) Then
            steep = True
        Else
            steep = False
        End If

        If (steep) Then
            Swap(Of Integer)(x0, y0)
            Swap(Of Integer)(x1, y1)
        End If

        If (x0 > x1) Then
            Swap(Of Integer)(x0, x1)
            Swap(Of Integer)(y0, y1)
        End If

        Dim deltax As Integer = (x1 - x0)
        Dim deltay As Integer = Math.Abs(y1 - y0)
        Dim errorr As Integer = deltax / 2
        Dim ystep As Integer
        Dim y As Integer = y0

        If (y0 < y1) Then
            ystep = 1
        Else
            ystep = -1
        End If
        For x = x0 To x1
            If (steep) Then
                img.Data(x, y, 0) = color
            Else
                img.Data(y, x, 0) = color
            End If
            errorr = errorr - deltay
            If (errorr < 0) Then
                y = y + ystep
                errorr = errorr + deltax
            End If
        Next

    End Sub

    Private Sub Swap(Of T)(ByRef d1 As T, ByRef d2 As T)
        Dim d = d2
        d2 = d1
        d1 = d
    End Sub

    Public Function decodeGcode(ByVal imgInput As Bitmap, Optional ByVal stepN As Integer = 0)
        Dim _img As Image(Of Gray, Byte) = New Image(Of Gray, Byte)(imgInput.Width, imgInput.Height)
        Dim IuputData As String = ""
        Dim split As String()
        Dim pointFlag As Boolean = False
        Dim X0, Y0, X1, Y1 As Integer
        Dim i As Integer = 0
        Dim sr As New System.IO.StreamReader(Application.StartupPath & "\test.gcode")
        Do While Not sr.EndOfStream
            IuputData = sr.ReadLine
            split = IuputData.Split(" ")
            If (pointFlag = True) Then
                If (split(0) = "OFF") Then
                    pointFlag = False
                Else
                    X1 = split(0)
                    Y1 = split(1)
                    line(X0, Y0, X1, Y1, _img, whiteDot)
                    X0 = X1
                    Y0 = Y1
                End If
            Else
                If (split(0) = "OFF") Then
                Else
                    pointFlag = True
                    X0 = split(0)
                    Y0 = split(1)
                    _img.Data(Y0, X0, 0) = whiteDot
                End If
            End If
            If (stepN <> 0) Then
                If i > stepN Then
                    Exit Do
                Else
                    i += 1
                End If
            End If
        Loop
        sr.Close()

        '_img = _img.Dilate(1)   '擴張
        'Return (and2Pic(imgCanny, _img.ToBitmap, 10))
        Return (_img.ToBitmap)
    End Function

    Public Function gcodeCombine(ByVal gcodeA As System.Text.StringBuilder, ByVal gcodeB As System.Text.StringBuilder, ByVal imgInput As Bitmap)
        Dim _img As Image(Of Gray, Byte) = New Image(Of Gray, Byte)(imgInput.Width, imgInput.Height)
        Dim gcodeTemp(2) As String
        Dim IuputData As String = ""
        Dim gcodeSperate() As String
        Dim Split() As String
        Dim pointFlag As Boolean = False
        Dim X0, Y0, X1, Y1 As Integer
        Dim i, j As Integer

        gcodeTemp(0) = gcodeA.ToString
        gcodeTemp(1) = gcodeB.ToString
        For j = 0 To 1
            gcodeTemp(j) = gcodeTemp(j).Replace(vbCrLf, ",")
            gcodeSperate = gcodeTemp(j).Split(",")
            For i = 0 To gcodeSperate.Length - 1
                IuputData = gcodeSperate(i)
                Split = IuputData.Split(" ")
                If (pointFlag = True) Then
                    If (Split(0) = "OFF") Then
                        pointFlag = False
                    ElseIf (Split(0) = "") Then
                    Else
                        X1 = Split(0)
                        Y1 = Split(1)
                        line(X0, Y0, X1, Y1, _img, whiteDot)
                        X0 = X1
                        Y0 = Y1
                    End If
                Else
                    If (Split(0) = "OFF") Then
                    ElseIf (Split(0) = "") Then
                    Else
                        pointFlag = True
                        X0 = Split(0)
                        Y0 = Split(1)
                        _img.Data(Y0, X0, 0) = whiteDot
                    End If
                End If
                'If (stepN <> 0) Then
                '    If i > stepN Then
                '        Exit Do
                '    Else
                '        i += 1
                '    End If
                'End If
            Next
        Next

        '_img = _img.Dilate(1)   '擴張
        'Return (and2Pic(imgCanny, _img.ToBitmap, 10))
        Return (_img.ToBitmap)

    End Function


    Private Function drawCircle(ByVal imgInput As Bitmap, ByVal x0 As Integer, ByVal y0 As Integer, ByVal radius As Integer)
        Dim _img As Image(Of Bgr, Byte)
        Dim x As Integer = radius - 1
        Dim y As Integer = 0
        Dim dx As Integer = 1
        Dim dy As Integer = 1
        Dim Err As Integer = dx - (radius << 1)

        _img = New Image(Of Bgr, Byte)(imgInput)

        While (x >= y)
            For i = 0 To 2
                _img.Data(y0 + y, x0 + x, i) = 0
                _img.Data(y0 + x, x0 + y, i) = 0
                _img.Data(y0 + x, x0 - y, i) = 0
                _img.Data(y0 + y, x0 - x, i) = 0
                _img.Data(y0 - y, x0 - x, i) = 0
                _img.Data(y0 - x, x0 - y, i) = 0
                _img.Data(y0 - x, x0 + y, i) = 0
                _img.Data(y0 - y, x0 + x, i) = 0
            Next
            If (Err <= 0) Then
                y = y + 1
                Err += dy
                dy += 2
            End If
            If (Err > 0) Then
                x = x - 1
                dx += 2
                Err += (-radius << 1) + dx
            End If

        End While

        Return (_img.ToBitmap)
    End Function
End Class
