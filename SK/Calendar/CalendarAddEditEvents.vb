Imports System.Data.Entity.Migrations
Imports System.Data.SQLite

Public Class CalendarAddEditEvents
    Private Sub BackBttn_Click(sender As Object, e As EventArgs) Handles BackBttn.Click
        Close()
    End Sub

    Dim mode As String
    Dim id As Integer

    Dim f As String
    Dim nop As Integer

    Public Sub New(dt As DateTime, m As String, i As Integer)
        InitializeComponent()
        DateTimePicker1.Value = dt
        mode = m
        id = i

        Dim names As New List(Of String)
        Dim time As New List(Of String)
        Dim venue As New List(Of String)

        Dim sql As String = "SELECT [Name], [Time], [Venue] FROM [Events] WHERE DATE([Date]) = @selectedDate AND [EventID] > 0"
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.EventHandlerDatabase))
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@selectedDate", DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        names.Add(reader.GetString(0))
                        time.Add(reader.GetString(1))
                        venue.Add(reader.GetString(2))
                    End While
                End Using
            End Using
        End Using

        If names.Count > 0 Then
            Dim mess As String = "Make sure to pay attention to the venue/s and time/s to avoid holding multiple events at a time on the same venue. There are events being held at this date: " & vbCrLf
            For i = 0 To names.Count - 1
                mess &= vbCrLf & names(i) & " held at " & venue(i) & "(" & time(i) & ")"
            Next

            MessageBox.Show(mess, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Async Sub AddBttn_Click(sender As Object, e As EventArgs) Handles AddBttn.Click
        Dim valid As Boolean = True
        If Not StringStorage.CheckString(TextBox1.Text, 50).Equals("") OrElse Not StringStorage.CheckString(RichTextBox1.Text, 999).Equals("") OrElse Not StringStorage.CheckString(TimeMinutesTB.Text, 2).Equals("") OrElse Not StringStorage.CheckString(TimeHourTB.Text, 2).Equals("") OrElse Not StringStorage.CheckString(TimeCB.Text, 2).Equals("") OrElse Not StringStorage.CheckString(VenueTB.Text, 99).Equals("") Then
            Label4.Text = "Fields cannot be empty or exceed character limit."
            valid = False
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        ElseIf Not IsNumber(TimeHourTB.Text) OrElse Not IsNumber(TimeMinutesTB.Text) Then
            Label4.Text = "Time must be number values."
            valid = False
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        ElseIf Integer.Parse(TimeHourTB.Text) > 12 OrElse Integer.Parse(TimeHourTB.Text) < 1 OrElse Integer.Parse(TimeMinutesTB.Text) > 59 OrElse Integer.Parse(TimeMinutesTB.Text) < 0 Then
            Label4.Text = "Hours should be 1 - 12, and minutes 00 - 59"
            valid = False
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        ElseIf Not TimeCB.Text.Equals("AM") AndAlso Not TimeCB.Text.Equals("PM") Then
            Label4.Text = "The time must be AM or PM only."
            valid = False
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        Else
            If Integer.Parse(TimeMinutesTB.Text) = 0 Then
                TimeMinutesTB.Text = "00"
            End If

            If Integer.Parse(TimeHourTB.Text) < 10 Then
                TimeHourTB.Text = "0" & Integer.Parse(TimeHourTB.Text)
            End If
        End If

        If valid AndAlso mode.Equals("Add") Then
            Dim sql1 As String = "SELECT MAX(EventId) FROM [Events]"
            Dim sql2 As String = "INSERT INTO Events VALUES (@id, @n, @desc, @date, @time, @venue, @num, @rem)"
            Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
            Dim maxid As Integer
            Dim maxidlog As Integer
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    maxid = Integer.Parse(command.ExecuteScalar())
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@id", maxid + 1)
                    command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@n", TextBox1.Text)
                    command.Parameters.AddWithValue("@desc", RichTextBox1.Text)
                    command.Parameters.AddWithValue("@time", TimeHourTB.Text & ":" & TimeMinutesTB.Text & " " & TimeCB.Text)
                    command.Parameters.AddWithValue("@venue", VenueTB.Text)
                    command.Parameters.AddWithValue("@num", 0)
                    command.Parameters.AddWithValue("@rem", 0)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Dim t As String = "ID: " & maxid + 1 & " | Name: " & TextBox1.Text & " | Description: " & RichTextBox1.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Time: " & TimeHourTB.Text & ":" & TimeMinutesTB.Text & " " & TimeCB.Text & " | Venue: " & VenueTB.Text & " | NumberofParticipants: " & 0
                Using command As New SQLiteCommand(sql3, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sql4, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "EventHandler")
                    command.Parameters.AddWithValue("@table", "Events")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Label4.Text = "Successfully added event!"
            Label4.ForeColor = Color.Green
            Label4.Visible = True
            Await Task.Delay(3000)
            CalendarMainForm.Close()
            CalendarMainForm.Show()
            Close()

        ElseIf valid AndAlso mode.Equals("Edit") Then
            Dim sql As String = "UPDATE [Events] SET [Name] = @n, [Date] = @date, [Description] = @desc, [Time] = @time, [Venue] = @venue WHERE [EventID] = @id"
            Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@n", TextBox1.Text)
                    command.Parameters.AddWithValue("@desc", RichTextBox1.Text)
                    command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@time", TimeHourTB.Text & ":" & TimeMinutesTB.Text & " " & TimeCB.Text)
                    command.Parameters.AddWithValue("@venue", VenueTB.Text)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Dim t As String = "ID: " & id & " | Name: " & TextBox1.Text & " | Description: " & RichTextBox1.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Time: " & TimeHourTB.Text & ":" & TimeMinutesTB.Text & " " & TimeCB.Text & " | Venue: " & VenueTB.Text & " | NumberofParticipants: " & nop
                Using command As New SQLiteCommand(sql3, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sql4, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "EventHandler")
                    command.Parameters.AddWithValue("@table", "Events")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", f)
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Label4.Text = "Successfully edited event!"
            Label4.ForeColor = Color.Green
            Label4.Visible = True
            Await Task.Delay(3000)
            CalendarMainForm.Close()
            CalendarMainForm.Show()
            Close()
        End If
    End Sub

    Private Sub CalendarAddEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If mode.Equals("Edit") Then
            AddBttn.Text = "Edit"
            Dim d As DateTime
            Dim t As String = ""
            Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
            Dim sql As String = "SELECT [Name], [Description], [Date], [NumberofParticipants], [Time], [Venue] FROM [Events] WHERE [EventID] = @id"
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            TextBox1.Text = reader.GetString(0)
                            RichTextBox1.Text = reader.GetString(1)
                            d = reader.GetDateTime(2)
                            nop = reader.GetInt32(3)
                            t = reader.GetString(4)
                            VenueTB.Text = reader.GetString(5)
                            Exit While
                        End While
                    End Using
                End Using
            End Using

            TimeHourTB.Text = t.Substring(0, 2)
            TimeMinutesTB.Text = t.Substring(3, 2)
            TimeCB.Text = t.Substring(6, 2)
            f = "ID: " & id & " | Name: " & TextBox1.Text & " | Description: " & RichTextBox1.Text & " | Date: " & d.ToString("MM/dd/yyyy") & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Time: " & TimeHourTB.Text & ":" & TimeMinutesTB.Text & " " & TimeCB.Text & " | Venue: " & VenueTB.Text & " | NumberofParticipants: " & nop
            Label4.Text = "Replace the fields with new details."
            Label4.Visible = True
        End If
    End Sub
End Class