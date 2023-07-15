Namespace Geometry
    Public Structure Point
        Public X As Integer
        Public Y As Integer

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.X = x
            Me.Y = y
        End Sub
    End Structure
End Namespace

Namespace Geometry
    Public Class Line
        Public Property StartPoint As Point
        Public Property EndPoint As Point

        Public Sub New(ByVal startPoint As Point, ByVal endPoint As Point)
            Me.StartPoint = startPoint
            Me.EndPoint = endPoint
        End Sub
    End Class
End Namespace