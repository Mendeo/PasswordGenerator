Option Explicit On
Option Strict On

Public Class PasSimbols
    Implements IComparable

    Public Property Simbols As String
    Public Property Probability As Double

    Sub New(p As Double, ByVal s As String)
        Simbols = s
        Probability = p
    End Sub

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Dim ps As PasSimbols = CType(obj, PasSimbols)
        If Probability < ps.Probability Then Return -1
        If Probability > ps.Probability Then Return 1
        Return 0
    End Function
End Class