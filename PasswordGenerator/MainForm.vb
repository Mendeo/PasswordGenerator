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
	
Option Strict On
Option Explicit On

Public Class MainForm
    Const DIR_NAME As String = "Simbols"
    Const CONFIG_FILE As String = "config.txt"
    Const MAX_PASSWORD_LENGTH As UShort = 256
    Private mRnd As Random
    Private mSimbols As New List(Of PasSimbols)
    Private mFiles As String()
    Private mFirstSelectedIndex As Integer
    Private mFirstPLen As String

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mRnd = New Random(My.Computer.Clock.TickCount - MousePosition.X - MousePosition.Y)
        Dim selectedIndex As Integer
        Try
            Using sr As New IO.StreamReader(IO.Path.Combine(My.Application.Info.DirectoryPath, CONFIG_FILE))
                mFirstPLen = sr.ReadLine()
                pLen_MTB.Text = mFirstPLen.ToString
                mFirstSelectedIndex = Integer.Parse(sr.ReadLine())
                selectedIndex = mFirstSelectedIndex
                sr.Close()
            End Using
        Catch ex As Exception
            MsgBox("Ошибка чтения из файла " & CONFIG_FILE & "!", MsgBoxStyle.Critical)
            Application.Exit()
            Return
        End Try
        Try
            mFiles = IO.Directory.GetFiles(IO.Path.Combine(My.Application.Info.DirectoryPath, DIR_NAME))
            If mFiles.Length <= 0 Then Throw New Exception
        Catch ex As Exception
            MsgBox("Невозможно открыть файл с символами!", MsgBoxStyle.Critical)
            Application.Exit()
            Return
        End Try
        For i As Integer = 0 To mFiles.Length - 1
            simbolFiles_CB.Items.Add(IO.Path.GetFileNameWithoutExtension(mFiles(i)))
        Next
        If selectedIndex >= mFiles.Length Then selectedIndex = 0
        simbolFiles_CB.SelectedIndex = selectedIndex
    End Sub

    Private Sub simbolFiles_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles simbolFiles_CB.SelectedIndexChanged
        password_TB.Clear()
        Try
            Dim auxPasSimbols As PasSimbols
            Dim auxStrArr As String()
            Dim p As Double
            Dim s As String
            Dim sum As Double = 0D
            mSimbols.Clear()
            Using sr As New IO.StreamReader(mFiles(simbolFiles_CB.SelectedIndex))
                Do Until sr.EndOfStream
                    auxStrArr = sr.ReadLine.Split(" "c)
                    p = convertStringToDouble(auxStrArr(0))
                    If Double.IsNaN(p) Then Throw New Exception("Ошибка преобразования в число.")
                    sum = sum + p
                    s = auxStrArr(1)
                    auxPasSimbols = New PasSimbols(p, s)
                    mSimbols.Add(auxPasSimbols)
                Loop
                sr.Close()
            End Using
            If sum < 1D Then Throw New Exception("Неверно заданы вероятности")
        Catch ex As Exception
            MsgBox("Ошибка чтения из файла " & mFiles(simbolFiles_CB.SelectedIndex) & "! " & ex.Message, MsgBoxStyle.Critical)
            Application.Exit()
            Return
        End Try
        'Сортируем по вероятности
        mSimbols.Sort()
        writeNewPassword()
    End Sub

    Private Sub genPass_BT_Click(sender As Object, e As EventArgs) Handles genPass_BT.Click
        writeNewPassword()
    End Sub

    Private Sub writeNewPassword()
        Dim pasLen As UShort
        If UShort.TryParse(pLen_MTB.Text, pasLen) AndAlso pasLen <= MAX_PASSWORD_LENGTH Then
            password_TB.Text = generatePassword(pasLen)
        Else
            MsgBox("Ошибка ввода! Максимальная длина пароля " & MAX_PASSWORD_LENGTH.ToString & ".", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function generatePassword(ByVal lenght As UShort) As String
        Dim n As Integer
        Dim rnd As Double
        Dim j As Integer
        Dim sum As Double
        Dim builder As New Text.StringBuilder()
        For i As UShort = 1 To lenght
            rnd = mRnd.NextDouble
            j = 0
            sum = mSimbols.Item(j).Probability
            Do Until rnd < sum
                j = j + 1
                sum = sum + mSimbols(j).Probability
            Loop
            n = mRnd.Next(mSimbols.Item(j).Simbols.Length)
            builder.Append(mSimbols.Item(j).Simbols.Substring(n, 1))
        Next
        Return builder.ToString
    End Function

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If mFirstSelectedIndex <> simbolFiles_CB.SelectedIndex OrElse Not pLen_MTB.Text.Equals(mFirstPLen) Then
            Dim sw As IO.StreamWriter = Nothing
            Try
                sw = New IO.StreamWriter(IO.Path.Combine(My.Application.Info.DirectoryPath, CONFIG_FILE))
                UShort.Parse(pLen_MTB.Text)
                sw.WriteLine(pLen_MTB.Text)
                sw.WriteLine(simbolFiles_CB.SelectedIndex.ToString)
                sw.Flush()
            Catch ex As Exception
                MsgBox("Невозможно сохранить кофигурационный файл!", MsgBoxStyle.Exclamation)
            Finally
                If sw IsNot Nothing Then sw.Close()
            End Try
        End If
    End Sub

    Public Shared Function convertStringToDouble(ByVal str As String) As Double
        If str IsNot Nothing AndAlso str <> "" Then
            Dim out As Double
            Dim Sp As String = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
            If Double.TryParse(System.Text.RegularExpressions.Regex.Replace(str.Trim, ",|\.", Sp), System.Globalization.NumberStyles.Any, System.Threading.Thread.CurrentThread.CurrentCulture, out) Then
                Return out
            Else
                Return Double.NaN
            End If
        Else
            Return Double.NaN
        End If
    End Function
End Class
