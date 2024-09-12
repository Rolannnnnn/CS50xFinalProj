Imports System.Globalization

Public Class CalendarMainForm

    Dim month As Integer
    Dim year As Integer

    Public Shared pmonth, pyear, pday As Integer
    Private Sub CalendarMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        month = Now.Month
        year = Now.Year
        Days()
    End Sub

    Private Sub Days()
        pmonth = Convert.ToInt32(month)
        pyear = Convert.ToInt32(year)
        Dim monthDisplay As String = DateTimeFormatInfo.CurrentInfo.GetMonthName(month)
        MonthYearLbl.Text = monthDisplay & " " & year.ToString
        Dim today As DateTime = DateTime.Now
        Dim firstday As DateTime = New DateTime(year, month, 1)
        Dim days As Integer = DateTime.DaysInMonth(year, month)
        Dim dayofweeks As Integer = Convert.ToInt32(firstday.DayOfWeek.ToString("d"))

        For i As Integer = 1 To dayofweeks - 1
            Dim ucblank As New CalendarUserControlBlank()
            CalendarContainer.Controls.Add(ucblank)
        Next

        For i As Integer = 1 To days
            Dim ucDays As New CalendarUserControlDays()
            ucDays.days(i)
            CalendarContainer.Controls.Add(ucDays)
        Next

    End Sub


    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        MainForm.Show()
        Close()
    End Sub

    Private Sub NextBox_Click_1(sender As Object, e As EventArgs) Handles NextBox.Click
        CalendarContainer.Controls.Clear()
        month += 1
        If month > 12 Then
            month = 1
            year += 1
        End If
        Days()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        CalendarPrintDialog.Show()
    End Sub

    Private Sub PreviousBox_Click_1(sender As Object, e As EventArgs) Handles PreviousBox.Click
        CalendarContainer.Controls.Clear()
        month -= 1
        If month < 1 Then
            month = 12
            year -= 1
        End If
        Days()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        CalendarContainer.Controls.Clear()
        month = Now.Month
        year = Now.Year
        Days()
    End Sub


End Class