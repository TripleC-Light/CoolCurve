Imports System.Math
Imports System.IO

Public Class Form1
    Public advanced_form As New Form2        '定義advanced_form為From2物件類別的全專案變數

    Enum GCode
        Head = 0
        G0
    End Enum
    'Public debugDisplay As Boolean = True
    Public debugDisplay As Boolean = False

    Dim OutputData As String = ""           '輸出字串
    Dim X_now As Double = 0                 '現在X坐標
    Dim Y_now As Double = 0                 '現在Y坐標
    Dim X_now_shift As Double = 0           'X坐標 位移後輸出值
    Dim Y_now_shift As Double = 0           'Y坐標 位移後輸出值
    Dim Laser_ctrl As Int16 = 0
    Dim Debug_OutputData As String = ""     'Debug 輸出字串

    Dim Laser_Speed As String = "G1 F250"       '設定雷射切割速度
    Dim Move_Speed As String = "G1 F3000"       '設定移動速度
    Dim Laser_Height As String = "G0 Z15"       '設定雷射高度，用於GCode中
    Public Laser_Height_Default As Integer = 15 '預設雷射高度
    Public Laser_Height_set As Double = 0       '設定雷射高度，用於計算
    Public Laser_Height_Radio As Integer           '雷射預設高度選項
    Dim Laser_Height_Radio_value As Double      '雷射預設高度選項為自定時的值
    Dim Laser_Delay As String = "G4 P150"   '設定雷射發射後的預熱時間，以ms為單位

    Dim IuputData As String = ""            '讀檔暫存
    Dim file_counter_total As Integer = 0   '全檔案大小
    Dim file_counter As Integer = 0         '已讀取到的檔案行數

    Dim isDrag As Boolean = False
    Public Shared X_max As Double = 0
    Public Shared X_min As Double = 0
    Public Shared Y_max As Double = 0
    Public Shared Y_min As Double = 0
    Dim User_shift_X As Double = 0
    Dim User_shift_Y As Double = 0
    Dim User_shift_Left_old As Integer
    Dim User_shift_Top_old As Integer
    Dim User_Moved As Boolean = False
    Dim User_Moved_step As Integer = 0
    Dim User_shift_X_old As Double = 0
    Dim User_shift_Y_old As Double = 0
    Dim size_Error As Integer = 0
    Dim Move_Len As Integer = 0
    Dim Cut_Len As Integer = 0

    Public planSize As Integer = 210                       ' 底座直徑，Delta型專用
    Public Bed_size_X As Integer = 215                 '底座長，因為是畫橢圓形，所以需定X,Y，X,Y是半徑
    Public Bed_size_Y As Integer = 215                 '底座寬
    Dim Center_shift_X As Double = 0
    Dim Center_shift_Y As Double = 0

    Dim Bed_size_X_Rectangle As Integer = 150       '圓底內接正方形長，只有圓底才會用到
    Dim Bed_size_Y_Rectangle As Integer = 150       '圓底內接正方形寬，只有圓底才會用到

    Dim g As Graphics
    Dim p As New Pen(Color.Red)
    Dim Bed_frame As New Pen(Color.Black, 5)

    Dim bgimage As Bitmap                           '將這個點陣圖關連到圖片框的Image屬性 
    Dim bggriphic As Graphics                       '以後繪圖時，只需要在這個點陣圖上繪製即可，圖片框會自動重繪

    Public Location_Times_set As Integer = 1            '設定雷射定位次數

    Public picOrg_buf As PictureBox
    Public imgPreSize As Double = 90
    Public imgPreSizeBig As Double = 435
    Public initPicOrgLocation() As Integer
    Public initPicGrayLocation() As Integer
    Public initPicPrevLocation() As Integer
    Public LaserFunction As Integer

    Dim mouseState As Integer = 0
    Dim temp_x As Integer = 0
    Dim temp_y As Integer = 0
    Dim pointTemp As New Point()
    Public imgG(,) As Integer
    Public nowFile As String
    Public User_shift_XY As Point
    Public User_shift_XY_old As Point
    Public pub_pixelStep As Double
    Public errCode As Integer = 0
    Public workTime As Integer = 20 * 60           ' 持續工作 20分鐘需休息
    Dim coolTime As Integer = 180           ' 休息180秒

    Public fontSize As Double = 7.75        ' 針對Windows設定為大字體的使用者
    Public dpi As Integer                   ' 使用者螢幕dpi
    Public FT As Font

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        g = PictureBox1.CreateGraphics
        bgimage = New Bitmap(PictureBox1.Width, PictureBox1.Height) '創建相同大小的記憶體點陣圖
        g = Graphics.FromImage(bgimage)
        PictureBox1.Image = bgimage

        dpi = CType(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop\WindowMetrics").GetValue("AppliedDPI"), Integer)
        '如果 DPI > 96(一般字型)，將表單上所有控制項字型的大小 -2
        'Log_Data.Text = dpi
        If dpi > 96 Then
            FT = New System.Drawing.Font("新細明體", fontSize)  'set font size = 7.75
            GroupBox1.Font = FT
            Target_Height.Font = FT
            LaserCut_Speed.Font = FT
            Set_over_Group.Font = FT
            SelectedFile.Font = FT
            Target_Height_Set.Font = FT
            LaserCut_Speed_Set.Font = FT
            LaserMove_Speed.Font = FT

            FT = New System.Drawing.Font("新細明體", fontSize - 0.75)  'set font size = 7
            RadioButton1.Font = FT
            RadioButton2.Font = FT
            RadioButton3.Font = FT
            Label2.Font = FT
            Label3.Font = FT
            Label4.Font = FT
            Label5.Font = FT
            Label1.Font = FT
            Data_Log.Font = FT
            Log_Data.Font = FT
            advanced.Font = FT
            OutText.Font = FT

            FT = New System.Drawing.Font("新細明體", fontSize - 1.5)  'set font size = 6.25
            dispGCode.Font = FT

            FT = New System.Drawing.Font("新細明體", fontSize + 1.5)  'set font size = 9.25
            Move_comment.Font = FT

            FT = New System.Drawing.Font("新細明體", fontSize + 2.25)  'set font size = 9.25
            GroupBox2.Font = FT
        End If

        Clear_Bed()

        'Set_over.ForeColor = Color.Gray
        Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode-after_icon.png")

        LaserCut_Speed_Scroll.Maximum = 1000
        LaserCut_Speed_Scroll.Minimum = 0
        LaserMove_Speed_Scroll.Maximum = 6000
        LaserMove_Speed_Scroll.Minimum = 0

        LaserCut_Speed_Scroll.Value = LaserCut_Speed_Set.Text
        LaserMove_Speed_Scroll.Value = LaserMove_Speed.Text

        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Parent = PictureBox1
        PictureBox2.Visible = False
        PictureBox2.BorderStyle = 0
        Move_comment.Visible = False
        picShowLaser.Visible = False
        dispGCode.Visible = False

        '工程模式
        If (debugDisplay) Then
            OutText.Visible = True
            Me.Width = 968
            dispGCode.Visible = True
        Else
            OutText.Visible = False
            Me.Width = 715
            dispGCode.Visible = False
        End If

        '讀取先前設定檔並載入
        IuputData = ""
        Dim split As String()
        Dim sr As New System.IO.StreamReader(Environment.CurrentDirectory & "\..\setting.ini")
        Do While Not sr.EndOfStream
            IuputData = sr.ReadLine
            Split = IuputData.Split(" ")
            Select Case split(0)
                Case "Laser_speed"
                    LaserCut_Speed_Scroll.Value = split(2)
                    LaserCut_Speed_Set.Text = split(2)
                Case "LaserMove_speed"
                    LaserMove_Speed_Scroll.Value = split(2)
                    LaserMove_Speed.Text = split(2)
                Case "Laser_Height_Default"
                    Laser_Height_Default = split(2)
                    Form2.set_Laser_Height.Text = split(2)
                Case "Location_Times_set"
                    Location_Times_set = split(2)
                    Form2.Times_set.Text = split(2)
                Case "Laser_Height_Radio"
                    Select Case split(2)
                        Case 1
                            RadioButton1.Checked = True
                        Case 2
                            RadioButton2.Checked = True
                        Case 99
                            RadioButton3.Checked = True
                            Target_Height_Set.Text = split(3)
                    End Select
            End Select
        Loop
        sr.Close()

        Timer1.Enabled = True
    End Sub

    Sub Gcode_G02G03(ByVal G02G03 As String, ByVal X As Double, ByVal Y As Double, ByVal I As Double, ByVal J As Double)
        Dim Circle_center_X As Double
        Dim Circle_center_Y As Double
        Dim shift_X_now As Double
        Dim shift_Y_now As Double
        Dim after_shift_X_now As Double
        Dim after_shift_Y_now As Double
        Dim Rotate_angle As Double
        Dim Rotate_cos As Double
        Dim Rotate_sin As Double
        Dim Last_Len As Double = 1
        Dim Loop_enable As Double = 1
        Dim Last_Len_distance_now As Double = 0
        Dim Last_Len_distance As Double = 5000

        If (I = 255 Or J = 255) Then
            Update_XY_now(X, Y)
            OutputData &= "G1 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf
        Else
            If (G02G03 = "G02") Then
                Rotate_angle = -0.5
            Else
                Rotate_angle = 0.5
            End If

            '簡化旋轉矩陣為常數
            Rotate_cos = Cos(Rotate_angle * (PI / 180))
            Rotate_sin = Sin(Rotate_angle * (PI / 180))
            '計算圓心
            Circle_center_X = X_now + I
            Circle_center_Y = Y_now + J
            '計算以圓心為中心時的偏移座標
            shift_X_now = 0 - I
            shift_Y_now = 0 - J

            Do While Loop_enable = 1
                '計算以圓心為中心時旋轉Rotate_angl角度後的座標
                after_shift_X_now = (shift_X_now * Rotate_cos) - (shift_Y_now * Rotate_sin)
                after_shift_Y_now = (shift_X_now * Rotate_sin) + (shift_Y_now * Rotate_cos)

                '計算不以圓心為中心時的偏移座標，Laser頭需移動到的座標
                Update_XY_now((after_shift_X_now + Circle_center_X), (after_shift_Y_now + Circle_center_Y))
                OutputData &= "G1 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf

                '更新移動後的座標
                shift_X_now = after_shift_X_now
                shift_Y_now = after_shift_Y_now

                Last_Len_distance_now = (((X_now - X) ^ 2 + (Y_now - Y) ^ 2) ^ 0.5)
                If (Last_Len_distance_now <= Last_Len) Then
                    Update_XY_now(X, Y)
                    OutputData &= "G1 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf
                    Loop_enable = 0
                Else
                    If (Last_Len_distance >= Last_Len_distance_now) Then
                        Last_Len_distance = Last_Len_distance_now
                    Else
                        Update_XY_now(X, Y)
                        OutputData &= "G1 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf
                        Loop_enable = 0
                    End If
                End If
            Loop
        End If

    End Sub

    Function Find_Coordinate(ByVal input_str As String, ByVal which_Coordinate As String)
        Dim split As String()
        Dim i As Int16
        Dim pass As Int16 = 0
        Dim Coordinate_Value As String = ""

        split = input_str.Split(" ")
        For i = 1 To UBound(split)
            If ((Strings.Left(split(i), 1)) = which_Coordinate) Then
                Coordinate_Value = Mid(split(i), 2, Len(split(i)))
                Coordinate_Value = CDbl(Coordinate_Value)
                Select Case which_Coordinate
                    Case "X"
                        Coordinate_Value = Coordinate_Value + User_shift_X + Center_shift_X
                    Case "Y"
                        Coordinate_Value = Coordinate_Value + User_shift_Y + Center_shift_Y
                End Select
                If (Coordinate_Value > Bed_size_X Or Coordinate_Value < -(Bed_size_X)) Then
                    Debug_OutputData &= "第 " & file_counter & "行[" & IuputData & "]，原始檔坐標超過雕刻範圍，已修正" & vbCrLf
                    Return (255)                            '數值有問題，回傳錯誤碼255
                Else
                    Coordinate_Value = CStr(Coordinate_Value)
                    Return Coordinate_Value
                End If
                pass = 1
            ElseIf ((Strings.Left(split(i), 1)) = "R") Then
                Debug_OutputData &= "第 " & file_counter & "行，找到未定義功能 G Code [R]" & vbCrLf
                Return (255)                                '找到未定義功能"R"，回傳錯誤碼255
            End If
        Next

        Return 0

    End Function

    Sub Update_XY_now(ByVal X As Double, ByVal Y As Double)

        If (Laser_ctrl = 0) Then
            p.Color = Color.Blue
        Else
            p.Color = Color.Red
        End If

        If ((((X ^ 2) + (Y ^ 2)) ^ 0.5) > (Bed_size_X / 2)) Then      '判斷距離是否超過圓底半徑
            p.Color = Color.Yellow
            Debug_OutputData &= "第 " & file_counter & "行[" & IuputData & "]，超過雕刻範圍，請更改原圖" & vbCrLf
            size_Error = 1
        End If

        g.DrawLine(p, (CInt(X_now + (Bed_size_X_Rectangle / 2)) * 2) + 65, (Bed_size_X * 2) - (CInt(Y_now + (Bed_size_X_Rectangle / 2)) * 2) - 65, (CInt(X + (Bed_size_X_Rectangle / 2)) * 2) + 65, (Bed_size_Y * 2) - (CInt(Y + (Bed_size_X_Rectangle / 2)) * 2) - 65)
        'If (Laser_ctrl = 1) Then
        '    g.DrawLine(p, (CInt(X_now + (Bed_size_X_Rectangle / 2)) * 2) + 65, (Bed_size_X * 2) - (CInt(Y_now + (Bed_size_X_Rectangle / 2)) * 2) - 65, (CInt(X + (Bed_size_X_Rectangle / 2)) * 2) + 65, (Bed_size_Y * 2) - (CInt(Y + (Bed_size_X_Rectangle / 2)) * 2) - 65)
        'End If

        If (Laser_ctrl = 0) Then
            Move_Len += (((X - X_now) ^ 2) + ((Y - Y_now) ^ 2)) ^ 0.5
        Else
            Cut_Len += (((X - X_now) ^ 2) + ((Y - Y_now) ^ 2)) ^ 0.5
        End If

        X_now = X
        Y_now = Y

        X_now_shift = X_now
        Y_now_shift = Y_now
        X_now_shift = Math.Round(X_now_shift, 4, MidpointRounding.AwayFromZero)
        Y_now_shift = Math.Round(Y_now_shift, 4, MidpointRounding.AwayFromZero)

        If (Laser_ctrl = 1) Then
            If (X_now_shift > X_max) Then
                'X_max = Format(X_now_shift, "####.####")
                X_max = X_now_shift
            ElseIf (X_now_shift < X_min) Then
                'X_min = Format(X_now_shift, "####.####")
                X_min = X_now_shift
            End If

            If (Y_now_shift > Y_max) Then
                'Y_max = Format(Y_now_shift, "####.####")
                Y_max = Y_now_shift
            ElseIf (Y_now_shift < Y_min) Then
                'Y_min = Format(Y_now_shift, "####.####")
                Y_min = Y_now_shift
            End If
        End If

    End Sub

    Private Sub Read_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Read_File.Click

        Dim myStream As System.IO.Stream        '建立讀檔物件
        Dim split As String()

        picShowLaser.Visible = False
        '初始化變數
        LaserFunction = 0
        IuputData = ""
        OutputData = ""
        Debug_OutputData = ""
        X_now = 0
        Y_now = 0
        X_max = 0
        X_min = 10000
        Y_max = 0
        Y_min = 10000
        X_now_shift = 0
        Y_now_shift = 0
        'Label1.Text = "0000 / 0000"
        Label1.Text = "000 %"
        User_shift_X = 0
        User_shift_Y = 0
        Center_shift_X = 0
        Center_shift_Y = 0
        User_Moved = False
        Clear_Bed()
        PictureBox2.BorderStyle = 0
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Visible = False
        Move_comment.Visible = False
        size_Error = 0

        'OpenFileDialog1.InitialDirectory = "C:\output\"
        OpenFileDialog1.Filter = "txt files (*.nc)|*.nc|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            file_counter_total = 0

            split = OpenFileDialog1.FileName.Split("\")
            nowFile = split(UBound(split))
            SelectedFile.Text = "目前檔案：" & nowFile
            SelectedFile.ForeColor = Color.White
            'Set_over.ForeColor = Color.Red
            Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")

            myStream = OpenFileDialog1.OpenFile()
            If Not (myStream Is Nothing) Then
                Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
                Do While Not sr.EndOfStream
                    IuputData = sr.ReadLine
                    IuputData = IuputData.Replace("F", " F")
                    IuputData = IuputData.Replace(";", " ;")
                    If Not (InStr(IuputData, ";") = 1) Then
                        If (InStr(IuputData, "G0") > 0 Or InStr(IuputData, "G1") > 0 Or InStr(IuputData, "G02") > 0 Or InStr(IuputData, "G03") > 0) Then
                            If (InStr(IuputData, "X") > 0) Then
                                split = IuputData.Split(" ")
                                For i = 1 To UBound(split)
                                    If ((Strings.Left(split(i), 1)) = "X") Then
                                        X_now = Mid(split(i), 2, Len(split(i)))
                                    End If
                                    If ((Strings.Left(split(i), 1)) = "Y") Then
                                        Y_now = Mid(split(i), 2, Len(split(i)))
                                    End If
                                Next
                                If Not (X_now = 0 And Y_now = 0) Then
                                    If (X_now > X_max) Then
                                        X_max = X_now
                                    ElseIf (X_now < X_min) Then
                                        X_min = X_now
                                    End If

                                    If (Y_now > Y_max) Then
                                        Y_max = Y_now
                                    ElseIf (Y_now < Y_min) Then
                                        Y_min = Y_now
                                    End If
                                End If
                            End If
                        End If
                    End If
                    file_counter_total += 1
                Loop

                Center_shift_X = -((X_max + X_min) / 2)
                Center_shift_Y = -((Y_max + Y_min) / 2)
                IuputData = ""
                Log_Data.Text = "檔　　案：" & OpenFileDialog1.FileName & vbCrLf
                Log_Data.Text &= "檔案行數：" & file_counter_total & " 行" & vbCrLf
                'Label1.Text = "0000 / " & file_counter_total
                sr.Close()
            End If
        Else
            OpenFileDialog1.InitialDirectory = ""
        End If
        PictureBox1.Refresh()                   '清除畫面

    End Sub

    Private Sub Set_over_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Set_over.Click

        Clear_Bed()
        Label1.Text = "000 %"
        If (LaserFunction = 0) Then
            If ((advanced_form.Laser_Cut_enabled.Checked = True) And (Target_Height_Set.Text > 15)) Then
                MsgBox("切割物件高度超過 15mm，將會碰撞到雷射頭!" & vbCrLf & "建議 取消切割功能 或是 變更物件高度", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "碰撞警告")
            Else
                If ((advanced_form.Laser_Cut_enabled.Checked = True) And (Target_Height_Set.Text > 2)) Then
                    MsgBox("切割物件高度超過 2mm，如果您有安裝雷射保護蓋，" & vbCrLf & "建議先將保護蓋拿起，避免保護蓋碰撞物件。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "碰撞警告")
                End If
                Dim myStream As System.IO.Stream        '建立讀檔物件
                Dim CompareStr As Int16                 '判斷讀取關鍵字位置
                Dim GCode_Analysis As Int16 = 0         'GCode分析用變數
                Dim HeadReader As String                '標頭檔暫存變數
                Dim LastReader As String                '標尾檔暫存變數
                Dim Laser_Cut_loop As Integer           '雷射切割次數
                Dim X As String                         'GCode X 坐標
                Dim Y As String                         'GCode Y 坐標
                Dim I As String                         'GCode I 坐標
                Dim J As String                         'GCode J 坐標
                Dim Display_time As Double
                Dim Display_time_old As Double
                Dim restTimes As Integer = 0
                Dim coolEnable As Integer = 0

                '↓初始化變數
                OutputData = ""
                Debug_OutputData = ""
                X_now = 0
                Y_now = 0
                X_now_shift = 0
                Y_now_shift = 0
                'Label1.Text = "0000 / 0000"
                file_counter = 0

                X_max = -Bed_size_X
                X_min = Bed_size_X
                Y_max = -Bed_size_Y
                Y_min = Bed_size_Y

                PictureBox2.BorderStyle = 0
                PictureBox2.BackColor = Color.Transparent
                PictureBox2.Visible = False
                Move_comment.Visible = False
                size_Error = 0
                Move_Len = 0
                Cut_Len = 0
                Display_time_old = 0
                restTimes = 0
                coolEnable = 0
                '↑初始化變數

                'Laser_Height = "G0 Z" & (15 + Target_Height_Set.Text)

                Laser_Speed = "G1 F" & LaserCut_Speed_Set.Text
                Move_Speed = "G1 F" & LaserMove_Speed.Text

                Log_Data.Text = ""
                Log_Data.Text = "檔　　案：" & OpenFileDialog1.FileName & vbCrLf
                Log_Data.Text &= "檔案行數：" & file_counter_total & " 行" & vbCrLf

                If Not (nowFile = "") Then
                    myStream = OpenFileDialog1.OpenFile()
                    If Not (myStream Is Nothing) Then

                        Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
                        Do While Not sr.EndOfStream                                                 '開始讀取NC檔

                            Application.DoEvents()
                            file_counter += 1
                            ProgressBar1.Value = (file_counter / file_counter_total) * 100
                            Label1.Text = ProgressBar1.Value & " %"

                            Select Case [GCode_Analysis]
                                Case GCode.Head                                                     'Head
                                    IuputData = sr.ReadLine                                         '讀取單行
                                    CompareStr = InStr(IuputData, "G0")                             '以第一次讀取到G0 判斷插入標頭(Head)的位置
                                    If (CompareStr > 0) Then
                                        Update_XY_now(Find_Coordinate(IuputData, "X"), Find_Coordinate(IuputData, "Y"))                 '抓出 X Y 初始值
                                        OutputData = "G0 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf

                                        CompareStr = 0
                                        GCode_Analysis += 1
                                    End If
                                Case 1                                                              'Main
                                    IuputData = sr.ReadLine                                         '讀取單行
                                    IuputData = IuputData.Replace("F", " F")
                                    IuputData = IuputData.Replace(";", " ;")
                                    If (InStr(IuputData, ";") = 1 Or InStr(IuputData, " ;") = 1) Then
                                        OutputData &= IuputData & vbCrLf

                                    ElseIf (InStr(IuputData, "G02") > 0) Then
                                        X = Find_Coordinate(IuputData, "X")                         '抓出 X值
                                        Y = Find_Coordinate(IuputData, "Y")                         '抓出 Y值
                                        I = Find_Coordinate(IuputData, "I")                         '抓出 I值
                                        J = Find_Coordinate(IuputData, "J")                         '抓出 J值
                                        Gcode_G02G03("G02", CDbl(X), CDbl(Y), CDbl(I), CDbl(J))
                                        CompareStr = 0

                                    ElseIf (InStr(IuputData, "G03") > 0) Then
                                        X = Find_Coordinate(IuputData, "X")                         '抓出 X值
                                        Y = Find_Coordinate(IuputData, "Y")                         '抓出 Y值
                                        I = Find_Coordinate(IuputData, "I")                         '抓出 I值
                                        J = Find_Coordinate(IuputData, "J")                         '抓出 J值
                                        Gcode_G02G03("G03", CDbl(X), CDbl(Y), CDbl(I), CDbl(J))
                                        CompareStr = 0

                                    ElseIf (InStr(IuputData, "G1") > 0 Or InStr(IuputData, "G01") > 0) Then
                                        If (InStr(IuputData, "X") > 0) Then
                                            Update_XY_now(Find_Coordinate(IuputData, "X"), Find_Coordinate(IuputData, "Y")) '抓出 X Y 值
                                            OutputData &= "G1 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf
                                        ElseIf (InStr(IuputData, "F") > 0) Then
                                            OutputData &= Laser_Speed & vbCrLf
                                        Else
                                            OutputData &= IuputData & vbCrLf
                                        End If

                                    ElseIf (InStr(IuputData, "G0") > 0) Then
                                        If (((file_counter_total - file_counter) > 5)) Then
                                            If (InStr(IuputData, "X") > 0) Then
                                                Update_XY_now(Find_Coordinate(IuputData, "X"), Find_Coordinate(IuputData, "Y")) '抓出 X Y 值
                                                OutputData &= "G0 X" & Format(X_now_shift, "####.####") & " Y" & Format(Y_now_shift, "####.####") & vbCrLf
                                            Else
                                                OutputData &= IuputData & vbCrLf
                                            End If
                                        Else
                                            If (Find_Coordinate(IuputData, "X") = 0 And Find_Coordinate(IuputData, "Y") = 0) Then
                                                OutputData &= IuputData & vbCrLf
                                            End If
                                        End If

                                    ElseIf (InStr(IuputData, "M03") > 0) Then
                                        OutputData &= "M106 S255" & vbCrLf
                                        OutputData &= Laser_Speed & vbCrLf
                                        OutputData &= Laser_Delay & vbCrLf
                                        Laser_ctrl = 1

                                    ElseIf (InStr(IuputData, "M05") > 0) Then
                                        OutputData &= "M106 S0" & vbCrLf
                                        OutputData &= Move_Speed & vbCrLf
                                        Laser_ctrl = 0

                                    ElseIf (InStr(IuputData, "M02") > 0) Then
                                        LastReader = My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\..\Last.txt")
                                        Laser_Cut_loop = 0
                                        If (advanced_form.Laser_Cut_enabled.Checked <> True) Then
                                            OutputData &= LastReader & vbCrLf
                                        Else
                                            Dim k As Integer
                                            Dim Laser_Height_cut As Double
                                            Dim OutputData_temp As String
                                            OutputData_temp = OutputData
                                            Laser_Height_cut = Laser_Height_set
                                            Laser_Cut_loop = CInt((Laser_Height_set - Laser_Height_Default) / 0.2)
                                            For k = 1 To Laser_Cut_loop + 2
                                                If (k < Laser_Cut_loop) Then
                                                    Laser_Height_cut = Laser_Height_cut - 0.2
                                                Else
                                                    Laser_Height_cut = Laser_Height_Default
                                                End If
                                                OutputData &= vbCrLf & "G0 Z" & Laser_Height_cut & "　　　　; Laser Cutting " & k + 1 & " Times " & vbCrLf & OutputData_temp

                                                If (coolEnable = 0) Then
                                                    If (((Display_time * (k + 1)) - Display_time_old) > workTime) Then
                                                        Display_time_old = Display_time * (k + 1)
                                                        restTimes += 1
                                                        OutputData &= vbCrLf & "M106 S0" & vbCrLf
                                                        'OutputData &= vbCrLf & "G01 X0 Y100" & vbCrLf
                                                        OutputData &= "G4 S" & coolTime & "　　　; Cooling for " & coolTime & " minutes，" & restTimes & " Times " & vbCrLf
                                                    End If
                                                End If
                                            Next
                                            OutputData &= LastReader & vbCrLf

                                            If (coolEnable <> 0) Then
                                                restTimes = restTimes * k
                                            End If
                                            Display_time = Display_time * k
                                        End If

                                        Exit Do

                                    Else
                                        OutputData &= IuputData & vbCrLf
                                        CompareStr = 0
                                    End If
                            End Select

                            Display_time = ((Move_Len / (LaserMove_Speed.Text / 60)) + (Cut_Len / (LaserCut_Speed_Set.Text / 60)))
                            If ((Display_time - Display_time_old) > workTime) Then
                                coolEnable = 1
                                restTimes += 1
                                Display_time_old = Display_time
                                OutputData &= vbCrLf & "M106 S0" & vbCrLf
                                'OutputData &= vbCrLf & "G01 X0 Y100" & vbCrLf
                                OutputData &= "G4 S" & coolTime & "　　　; Cooling for " & coolTime & " minutes，" & restTimes & " Times " & vbCrLf & vbCrLf
                            End If
                        Loop

                        sr.Close()

                        Display_time += (coolTime * restTimes)

                        HeadReader = My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\..\Head.txt")  '預設的標頭檔

                        OutputData = "G0 Z" & Laser_Height_set & vbCrLf & OutputData
                        OutputData = Head_Comment.Check_position_set() & vbCrLf & OutputData
                        OutputData = HeadReader & vbCrLf & OutputData                                                   '插入標頭至OutputData
                        OutputData = Head_Comment.Head_comment_set() & OutputData

                        OutText.Text = OutputData
                        Log_Data.Text &= Debug_OutputData

                        If (size_Error = 1) Then
                            MsgBox("超過雕刻範圍，請移動圖片或是修改原圖!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "尺寸警告")
                        Else
                            If (restTimes <> 0) Then
                                MsgBox("此檔案預計將會雕刻 " & Format((Display_time / 60) + 1, "#####.##") & " 分鐘" & vbCrLf &
                                       "每" & workTime / 60 & "分鐘將進行1次強制冷卻，總計 " & restTimes & "次，每次 3分鐘" & vbCrLf &
                                       "冷卻時機器將會暫停，時間到後會自動啟動，請不用擔心！", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "強制冷卻通知")
                            End If
                            Dim saveFileDialog1 As New SaveFileDialog()                                                 '儲存檔案
                            saveFileDialog1.FileName = Replace(OpenFileDialog1.FileName, ".nc", ".gcode")
                            saveFileDialog1.Filter = "gcode files (*.gcode)|*.gcode"
                            saveFileDialog1.FilterIndex = 2
                            saveFileDialog1.RestoreDirectory = True
                            If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
                                Dim sw = New StreamWriter(saveFileDialog1.FileName)
                                sw.Write(OutputData)
                                sw.Close()
                            End If
                        End If

                        PictureBox1.Refresh()
                    End If

                    PictureBox2.Width = (X_max - X_min) * 2
                    PictureBox2.Height = (Y_max - Y_min) * 2
                    PictureBox2.Left = (X_min + (Bed_size_X_Rectangle / 2)) * 2 + 65
                    PictureBox2.Top = (Bed_size_X * 2) - (Y_max + (Bed_size_Y_Rectangle / 2)) * 2 - 65
                    PictureBox2.BorderStyle = 0
                    PictureBox2.BackColor = Color.Transparent
                    PictureBox2.Visible = True

                    If (User_Moved = False) Then
                        User_shift_Left_old = PictureBox2.Left
                        User_shift_Top_old = PictureBox2.Top
                    End If

                    '加1分鐘平面校正時間
                    Dim ii As Integer
                    Dim Display_str As String
                    Dim Display_len As Integer
                    Display_time = Format((Display_time / 60) + 1, "###,##")
                    'Display_time = Format(1.1016, "###,##")
                    Display_len = Len(CStr(Display_time))
                    Display_str = ""
                    For ii = 1 To Math.Ceiling(Display_len / 2)
                        Display_str &= "─"
                    Next
                    Log_Data.Text &= "┌─────────" & Display_str & "┐" & vbCrLf
                    Log_Data.Text &= "　預估雕刻時間：" & Display_time & " 分鐘 " & vbCrLf
                    Log_Data.Text &= "└─────────" & Display_str & "┘" & vbCrLf
                    Log_Data.SelectionStart = Log_Data.Text.Length
                    Log_Data.ScrollToCaret()
                    'Set_over.ForeColor = Color.Gray
                    Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode-after_icon.png")
                    ProgressBar1.Value = 0
                    Label1.Text = "000 %"
                Else
                    MsgBox("請先選擇檔案!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "無檔案")
                End If
                End If
        Else
                If (nowFile <> "") Then
                    PictureBox2.Visible = False
                    Move_comment.Visible = False
                    Dim gcode_tmp As New System.Text.StringBuilder("")
                    Dim Split() As String
                    gcode_tmp = Sub_Function.GrayPictoGcode(imgG)
                    If (dispGCode.Checked = True) Then
                        OutText.Text = gcode_tmp.ToString()        ' 此行會執行很久，請謹慎使用
                    End If

                    If (errCode = 0) Then
                        Dim saveFileDialog1 As New SaveFileDialog()                                                 '儲存檔案
                        Split = nowFile.Split(".")
                        saveFileDialog1.FileName = Split(0) & ".gcode"
                        saveFileDialog1.Filter = "gcode files (*.gcode)|*.gcode"
                        saveFileDialog1.FilterIndex = 2
                        saveFileDialog1.RestoreDirectory = True
                        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
                            Dim sw = New StreamWriter(saveFileDialog1.FileName)
                            sw.Write(gcode_tmp)
                            sw.Close()
                        End If
                    Else
                        errCode = 0
                        MsgBox("超過雕刻範圍！建議縮小尺寸或是移動圖片！", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "尺寸警告")
                    End If

                    'Set_over.ForeColor = Color.Gray
                    Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode-after_icon.png")
                    ProgressBar1.Value = 0
                    Label1.Text = "000 %"
                Else
                    MsgBox("請先選擇檔案!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "無檔案")
                End If
        End If

    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles LaserCut_Speed_Scroll.Scroll, LaserMove_Speed_Scroll.Scroll
        LaserCut_Speed_Set.Text = LaserCut_Speed_Scroll.Value
        LaserMove_Speed.Text = LaserMove_Speed_Scroll.Value
        'Set_over.ForeColor = Color.Red
        Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")
    End Sub

    Private Sub LaserCut_Speed_Set_TextKeyUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaserCut_Speed_Set.KeyUp, LaserMove_Speed.KeyUp

        If (LaserCut_Speed_Set.Text < LaserCut_Speed_Scroll.Minimum) Then
            LaserCut_Speed_Scroll.Value = LaserCut_Speed_Scroll.Minimum
            LaserCut_Speed_Set.Text = LaserCut_Speed_Scroll.Minimum
        ElseIf (CInt(LaserCut_Speed_Set.Text) > LaserCut_Speed_Scroll.Maximum) Then
            LaserCut_Speed_Scroll.Value = LaserCut_Speed_Scroll.Maximum
            LaserCut_Speed_Set.Text = LaserCut_Speed_Scroll.Maximum
        Else
            LaserCut_Speed_Scroll.Value = LaserCut_Speed_Set.Text
        End If

        If (LaserMove_Speed.Text < LaserMove_Speed_Scroll.Minimum) Then
            LaserMove_Speed_Scroll.Value = LaserMove_Speed_Scroll.Minimum
            LaserMove_Speed.Text = LaserMove_Speed_Scroll.Minimum
        ElseIf (CInt(LaserMove_Speed.Text) > LaserMove_Speed_Scroll.Maximum) Then
            LaserMove_Speed_Scroll.Value = LaserMove_Speed_Scroll.Maximum
            LaserMove_Speed.Text = LaserMove_Speed_Scroll.Maximum
        Else
            LaserMove_Speed_Scroll.Value = LaserMove_Speed.Text
        End If
    End Sub
    Private Sub LaserCut_Speed_Set_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LaserCut_Speed_Set.KeyPress, LaserMove_Speed.KeyPress, Target_Height_Set.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = "." Then
            If e.KeyChar = "." And InStr(LaserCut_Speed_Set.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
            'Set_over.ForeColor = Color.Red
            Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.NoMove2D
        isDrag = True
        User_Moved = True
        Clear_Bed()                   '清除畫面
        PictureBox1.Refresh()
        PictureBox2.BorderStyle = 1
        PictureBox2.BackColor = Color.PaleGreen
        Move_comment.BackColor = PictureBox2.BackColor
        Move_comment.Visible = True
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        isDrag = False
        PictureBox2.BackColor = Color.PaleGreen
        Move_comment.BackColor = PictureBox2.BackColor
    End Sub

    Private Sub Picturebox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove

        If isDrag = True Then

            PictureBox2.BackColor = Color.Gainsboro
            PictureBox2.Left = PictureBox2.Left + e.X - (PictureBox2.Width \ 2)
            PictureBox2.Top = PictureBox2.Top + e.Y - (PictureBox2.Height \ 2)

            User_shift_X = (PictureBox2.Left - User_shift_Left_old) / 2
            User_shift_Y = -(PictureBox2.Top - User_shift_Top_old) / 2

            Move_comment.BackColor = PictureBox2.BackColor
            Move_comment.Left = PictureBox2.Left + (Abs(Move_comment.Width - PictureBox2.Width) \ 2) + 10
            Move_comment.Top = PictureBox2.Top + 20
            Log_Data.Text = "移動完後，請重新進行分析!"
            'Log_Data.Text = User_shift_X & "," & User_shift_Y
        End If
    End Sub

    Sub Clear_Bed()
        g.Clear(Color.Transparent)
        g.FillEllipse(Brushes.WhiteSmoke, 3, 3, (Bed_size_X * 2 - 6), (Bed_size_Y * 2 - 6))
        g.DrawEllipse(Bed_frame, 3, 3, (Bed_size_X * 2 - 6), (Bed_size_Y * 2 - 6))
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If RadioButton1.Checked Then
            Laser_Height_set = Laser_Height_Default + 0.1
            Laser_Height = "G0 Z" & Laser_Height_set    'A4白紙
            Laser_Height_Radio = 1
        ElseIf RadioButton2.Checked Then
            Laser_Height_set = Laser_Height_Default + 5
            Laser_Height = "G0 Z" & Laser_Height_set    '瓦楞紙
            Laser_Height_Radio = 2
        ElseIf RadioButton3.Checked Then
            Laser_Height_set = Laser_Height_Default + Target_Height_Set.Text
            Laser_Height = "G0 Z" & Laser_Height_set    '自訂
            Laser_Height_Radio = 99
            Laser_Height_Radio_value = Target_Height_Set.Text
        End If
    End Sub

    Private Sub advanced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles advanced.Click
        advanced_form.Form2_Load(Nothing, Nothing)
        advanced_form.Show()
        Sub_Function.putInCenter(Me, advanced_form)
    End Sub

    Private Sub Form1_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        '關閉程式時儲存設定檔
        Dim setting_save As String

        '讀取先前設定檔
        IuputData = ""
        setting_save = ""
        Dim split As String()
        Dim sr As New System.IO.StreamReader(Environment.CurrentDirectory & "\..\setting.ini")
        Do While Not sr.EndOfStream
            IuputData = sr.ReadLine
            split = IuputData.Split(" ")
            Select Case split(0)
                Case "Laser_speed"
                    setting_save &= "Laser_speed = " & LaserCut_Speed_Set.Text & vbCrLf
                Case "LaserMove_speed"
                    setting_save &= "LaserMove_speed = " & LaserMove_Speed.Text & vbCrLf
                Case "Laser_Height_Default"
                    setting_save &= "Laser_Height_Default = " & Laser_Height_Default & vbCrLf
                Case "Location_Times_set"
                    setting_save &= "Location_Times_set = " & Location_Times_set & vbCrLf
                Case "Laser_Height_Radio"
                    setting_save &= "Laser_Height_Radio = " & Laser_Height_Radio & " " & Laser_Height_Radio_value & vbCrLf
                Case Else
                    setting_save &= IuputData & vbCrLf
            End Select
        Loop
        sr.Close()

        Dim saveFileDialog1 As New SaveFileDialog()                                                 '關閉程式時儲存設定檔
        Dim sw = New StreamWriter(Environment.CurrentDirectory & "\..\setting.ini")
        sw.Write(setting_save)
        sw.Close()

    End Sub

    Private Sub picEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEng.Click

        Log_Data.Text = ""
        PictureBox2.Visible = False
        Move_comment.Visible = False
        picShowLaser.Visible = False
        User_shift_XY = New Point(0, 0)
        nowFile = ""
        LaserFunction = 1
        Form3.Show()

    End Sub

    Private Sub picShowLaser_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picShowLaser.MouseDown
        If e.Button = MouseButtons.Left Then
            mouseState = 1
            temp_x = e.X
            temp_y = e.Y
        End If
    End Sub

    Private Sub picShowLaser_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles picShowLaser.MouseHover
        picShowLaser.BorderStyle = 1
    End Sub

    Private Sub picShowLaser_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picShowLaser.MouseLeave
        picShowLaser.BorderStyle = 0
    End Sub

    Private Sub picShowLaser_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picShowLaser.MouseMove
        If mouseState = 1 And e.Button = MouseButtons.Left Then
            pointTemp.X += (e.X - temp_x)
            pointTemp.Y += (e.Y - temp_y)
            picShowLaser.Location = pointTemp
        End If
    End Sub

    Private Sub picShowLaser_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picShowLaser.MouseUp
        If e.Button = MouseButtons.Left Then
            mouseState = 0
            temp_x = 0
            temp_y = 0
            User_shift_XY = New Point(picShowLaser.Location.X - User_shift_XY_old.X, picShowLaser.Location.Y - User_shift_XY_old.Y)
            Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        'Set_over.ForeColor = Color.Red
        Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")
    End Sub

End Class
