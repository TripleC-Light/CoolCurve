Public Class Form2

    Public Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.dpi > 96 Then
            Form1.FT = New System.Drawing.Font("新細明體", Form1.fontSize - 0.75)  'set font size = 7
            Label1.Font = Form1.FT
            Label2.Font = Form1.FT
            Label3.Font = Form1.FT
            Label4.Font = Form1.FT
            Label5.Font = Form1.FT
            Times_set.Font = Form1.FT
            set_Laser_Height.Font = Form1.FT
            Laser_Cut_enabled.Font = Form1.FT
            BacktoDefault.Font = Form1.FT
            OK.Font = Form1.FT
            cancel.Font = Form1.FT
        End If

        '讀取先前設定檔
        Dim IuputData As String = ""
        Dim split As String()
        Dim sr As New System.IO.StreamReader(Environment.CurrentDirectory & "\..\setting.ini")
        Do While Not sr.EndOfStream
            IuputData = sr.ReadLine
            split = IuputData.Split(" ")
            Select Case split(0)
                Case "Laser_Height_Default"
                    Form1.Laser_Height_Default = split(2)
                    set_Laser_Height.Text = split(2)
                Case "Location_Times_set"
                    Form1.Location_Times_set = split(2)
                    Times_set.Text = split(2)
            End Select
        Loop
        sr.Close()

        If (Form1.LaserFunction = 1) Then
            Laser_Cut_enabled.Enabled = False
            Label5.Visible = True
        Else
            Laser_Cut_enabled.Enabled = True
            Label5.Visible = False
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Form1.Set_over.BackgroundImage = Image.FromFile(Application.StartupPath & "\pic\Gcode_icon.png")
        Me.Hide()
        Form1.Location_Times_set = Times_set.Text
        Form1.Laser_Height_Default = set_Laser_Height.Text
        Form1.Location_Times_set = Times_set.Text
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Hide()
        Times_set.Text = Form1.Location_Times_set
        set_Laser_Height.Text = Form1.Laser_Height_Default
        'Form1.Location_Times_set = Location_Times_set_temp
    End Sub

    Private Sub BacktoDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BacktoDefault.Click

        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "此選項將會回復所有設定值，包含校正數值！"   ' Define message.
        style = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.OkCancel
        title = "注意訊息"   ' Define title.
        response = MsgBox(msg, style, title)

        If response = MsgBoxResult.Ok Then   ' User chose Yes.
            Laser_Cut_enabled.Checked = False
            '讀取先前設定檔
            Dim IuputData As String = ""
            Dim split As String()
            Dim sr As New System.IO.StreamReader(Environment.CurrentDirectory & "\..\setting.ini")
            Do While Not sr.EndOfStream
                IuputData = sr.ReadLine
                split = IuputData.Split(" ")
                Select Case split(0)
                    Case "BacktoDefault_Laser_speed"
                        Form1.LaserCut_Speed_Scroll.Value = split(2)
                        Form1.LaserCut_Speed_Set.Text = split(2)
                    Case "BacktoDefault_LaserMove_speed"
                        Form1.LaserMove_Speed_Scroll.Value = split(2)
                        Form1.LaserMove_Speed.Text = split(2)
                    Case "BacktoDefault_Laser_Height_Default"
                        Form1.Laser_Height_Default = split(2)
                        set_Laser_Height.Text = split(2)
                    Case "BacktoDefault_Location_Times_set"
                        Form1.Location_Times_set = split(2)
                        Times_set.Text = split(2)
                    Case "BacktoDefault_Laser_Height_Radio"
                        Form1.Laser_Height_Radio = split(2)
                        Form1.Target_Height_Set.Text = split(3)
                        Form1.RadioButton1.Checked = True
                End Select
            Loop
            sr.Close()
        End If

    End Sub

End Class