Public Class Form4
    Dim mouseState As Integer = 0
    Dim temp_x As Integer = 0
    Dim temp_y As Integer = 0
    Dim pointTemp As New Point()
    Dim orgPoint As New Point()

    Private Sub Form4_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Public Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form1.dpi > 96 Then
            Form1.FT = New System.Drawing.Font("新細明體", Form1.fontSize - 0.75)  'set font size = 7
            sizeX.Font = Form1.FT
            sizeY.Font = Form1.FT

            Form1.FT = New System.Drawing.Font("新細明體", Form1.fontSize + 2.25)  'set font size = 10
            backToCenter.Font = Form1.FT
            pressOK.Font = Form1.FT
        End If

        orgPoint = PictureBoxErrDiff.Location
    End Sub

    Private Sub Form4_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            PictureBoxErrDiff.Top = PictureBoxErrDiff.Top + 10
            Sub_Function.erdfSizeDisplay(PictureBoxErrDiff, Form3.pixelStep)
        Else
            PictureBoxErrDiff.Top = PictureBoxErrDiff.Top - 10
            Sub_Function.erdfSizeDisplay(PictureBoxErrDiff, Form3.pixelStep)
        End If
    End Sub

    Private Sub PictureBoxErrDiff_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxErrDiff.MouseDown
        If e.Button = MouseButtons.Left Then
            mouseState = 1
            temp_x = e.X
            temp_y = e.Y
            Me.Cursor = New Cursor(Application.StartupPath & "\pic\move_il.cur")
        End If
    End Sub

    Private Sub PictureBoxErrDiff_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBoxErrDiff.MouseLeave
        Me.Cursor = New Cursor(Application.StartupPath & "\pic\arrow_m.cur")
    End Sub

    Private Sub PictureBoxErrDiff_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxErrDiff.MouseMove
        If mouseState = 1 And e.Button = MouseButtons.Left Then
            pointTemp.X += (e.X - temp_x)
            pointTemp.Y += (e.Y - temp_y)
            PictureBoxErrDiff.Location = pointTemp
            Sub_Function.erdfSizeDisplay(PictureBoxErrDiff, Form3.pixelStep)
        Else
            Me.Cursor = New Cursor(Application.StartupPath & "\pic\hnwse.cur")
        End If
    End Sub

    Private Sub PictureBoxErrDiff_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxErrDiff.MouseUp
        If e.Button = MouseButtons.Left Then
            mouseState = 0
            temp_x = 0
            temp_y = 0
        End If
    End Sub

    Private Sub pressOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pressOK.Click
        Me.Dispose()
    End Sub

    Private Sub backToCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backToCenter.Click
        PictureBoxErrDiff.Location = orgPoint
        Sub_Function.erdfSizeDisplay(PictureBoxErrDiff, Form3.pixelStep)
    End Sub

End Class