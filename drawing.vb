Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class drawing

    Public Sub New()
    End Sub

    '畫圓
    Public Function Circle(ByVal imgInput As Bitmap, ByVal x0 As Integer, ByVal y0 As Integer, ByVal radius As Integer, ByVal colorIn As Bgr, Optional ByVal boarder As Integer = 1)

        Dim _imgProc As New Image(Of Bgr, Byte)(imgInput)
        Dim circleDraw As CircleF
        circleDraw = New CircleF(New Point(x0, y0), radius)
        _imgProc.Draw(circleDraw, colorIn, boarder)

        Return (_imgProc.ToBitmap)
    End Function

    '畫直線
    Public Function Line(ByVal imgInput As Bitmap, ByVal p1 As Point, ByVal p2 As Point, ByVal colorIn As Bgr, Optional ByVal boarder As Integer = 1)

        Dim _imgProc As New Image(Of Bgr, Byte)(imgInput)
        Dim LineDraw As LineSegment2D
        LineDraw = New LineSegment2D(p1, p2)
        _imgProc.Draw(LineDraw, colorIn, boarder)

        Return (_imgProc.ToBitmap)
    End Function

    '顏色填充
    Public Function FloodFill(ByVal imgInput As Bitmap, ByVal startPoint As Point, ByVal colorIn As Bgr)

        Dim _imgProc As New Image(Of Bgr, Byte)(imgInput)
        Dim newColor As New MCvScalar(colorIn.Blue, colorIn.Green, colorIn.Red)
        Dim loDiff As New MCvScalar(0, 0, 0)    ' 與 hiDiff 組成誤差範圍，在此範圍內的顏色將被填充
        Dim hiDiff As New MCvScalar(0, 0, 0)
        Dim mo As New MCvConnectedComp

        CvInvoke.cvFloodFill(_imgProc, startPoint, newColor, loDiff, hiDiff, mo, 4, IntPtr.Zero)

        Return (_imgProc.ToBitmap)
    End Function

    '畫十字
    Public Function Cross(ByVal imgInput As Bitmap, ByVal center As Point, ByVal width As Integer, ByVal height As Integer, ByVal colorIn As Bgr, Optional ByVal boarder As Integer = 1)

        Dim _imgProc As New Image(Of Bgr, Byte)(imgInput)
        Dim CrossDraw As Cross2DF
        CrossDraw = New Cross2DF(center, width, height)
        _imgProc.Draw(CrossDraw, colorIn, boarder)

        Return (_imgProc.ToBitmap)
    End Function

    '畫任意角度的橢圓
    Public Function test(ByVal imgInput As Bitmap, ByVal center As Point, ByVal sizeBox As Size, ByVal angleBox As Integer, ByVal colorIn As Bgr, Optional ByVal boarder As Integer = 1)

        Dim _imgProc As New Image(Of Bgr, Byte)(imgInput)
        Dim EllipseDraw As Ellipse
        Dim box2d As MCvBox2D
        box2d = New MCvBox2D(center, sizeBox, angleBox)
        EllipseDraw = New Ellipse(box2d)
        _imgProc.Draw(EllipseDraw, colorIn, boarder)

        Return (_imgProc.ToBitmap)
    End Function

End Class
