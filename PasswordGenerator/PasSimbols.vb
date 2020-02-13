'    Copyright © 2020 Aleksandr Menyaylo (Александр Меняйло)
'
'    This file is part of "Password Generator".
'
'    "Password Generator" is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    "Password Generator" is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with "Password Generator". If not, see <https://www.gnu.org/licenses/>.

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