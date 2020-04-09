Public Class Head_Comment

    Public Shared Function Head_comment_set()   '標頭註解設定
        Dim Head_Comment As String
        Head_Comment =
        "; *** Laser Cutting Transfer Software ***" & vbCrLf &
        "; Version 5.0" & vbCrLf &
        "; " & vbCrLf &
        "; *** Laser Settings ***" & vbCrLf &
        "; File Name : " & Form1.OpenFileDialog1.FileName & vbCrLf &
        "; Saved Time : " & Now() & vbCrLf &
        "; Laser Head Height : " & (Form1.Laser_Height_set) & " mm" & vbCrLf &
        "; Laser Speed : " & Form1.LaserCut_Speed_Set.Text & " mm/min" & vbCrLf &
        "; Move_Speed : " & Form1.LaserMove_Speed.Text & " mm/min" & vbCrLf &
        "; E-mail : TripleC.Light@gmail.com" & vbCrLf &
        "; " & vbCrLf & vbCrLf

        Return Head_Comment
    End Function

    Public Shared Function Check_position_set()   '自動對位設定 '定位鐳射光點功率 120/255
        Dim Check_position As String
        Dim Check_position_temp As String

        Check_position_temp = ""

        For i = 0 To (Form1.Location_Times_set - 1)
            Check_position_temp &=
            "G0 Z" & (Form1.Laser_Height_set + 10) & vbCrLf &
            "G0 X" & Form1.X_min & " Y" & Form1.Y_max & vbCrLf &
            "M106 S120" & vbCrLf &
            "M109 S100" & vbCrLf &
            "G0 X" & Form1.X_max & " Y" & Form1.Y_max & vbCrLf &
            "G0 X" & Form1.X_max & " Y" & Form1.Y_min & vbCrLf &
            "G0 X" & Form1.X_min & " Y" & Form1.Y_min & vbCrLf &
            "G0 X" & Form1.X_min & " Y" & Form1.Y_max & vbCrLf & vbCrLf
        Next

        Check_position_temp &=
            "M109 S100" & vbCrLf &
            "M104 S0    ;turn off temperature" & vbCrLf &
            "M106 S0" & vbCrLf

        Check_position =
        "; *** Check Position " & Form1.Location_Times_set & "Times ***" & vbCrLf &
        Check_position_temp &
        "; *** Check Position ***" & vbCrLf & vbCrLf

        Return Check_position
    End Function
End Class
