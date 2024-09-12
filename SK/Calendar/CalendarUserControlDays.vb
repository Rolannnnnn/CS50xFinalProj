Imports System.Data.SQLite

Public Class CalendarUserControlDays
    Public Shared pday As Integer

    Public Sub days(numday As Integer)
        DaysLbl.Text = numday
    End Sub

    Private Sub clicked()
        pday = DaysLbl.Text
        Dim tobesent As DateTime = New DateTime(CalendarMainForm.pyear, CalendarMainForm.pmonth, Convert.ToInt32(DaysLbl.Text))

        Dim events As Integer
        Dim connectionString = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
        Dim sql As String = "SELECT COUNT(*) FROM [Events] WHERE [Date] = @date"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@date", tobesent)
                events = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using


        Dim cem As New CalendarEventMain(tobesent, events, 1)
        cem.Show()
    End Sub

    Private Sub CalendarUserControlDays_Click(sender As Object, e As MouseEventArgs) Handles Me.Click
        clicked()
    End Sub

    Private Sub CalendarUserControlDays_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisdate As DateTime = New DateTime(CalendarMainForm.pyear, CalendarMainForm.pmonth, Convert.ToInt32(DaysLbl.Text))
        Dim sql1 As String = "SELECT [Name], [Venue] FROM [Events] WHERE [Date] = @date AND [EventID] > 0"
        Dim count As Integer = 0
        Dim eventName As String = ""
        Dim venue As String = ""
        Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
        Using connection As New SQLiteConnection(connectionString)
            Using command As New SQLiteCommand(sql1, connection)
                connection.Open()
                command.Parameters.AddWithValue("@date", thisdate)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read
                        count += 1
                        If count = 1 Then
                            eventName = reader.GetString(0)
                            venue = reader.GetString(1)
                        ElseIf count = 2 Then
                            Exit While
                        End If
                    End While
                End Using
            End Using
        End Using

        If count >= 1 Then
            Label1.Text = eventName
            Label1.Visible = True
            DaysLbl.ForeColor = Color.FromArgb(241, 241, 241)
            Me.BackColor = Color.FromArgb(195, 0, 16)
        End If
        If count = 2 Then
            Label2.Text = "more..."
            Label2.Visible = True
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        clicked()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        clicked()
    End Sub
End Class
