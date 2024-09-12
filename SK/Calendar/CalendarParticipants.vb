Imports System.Data.SQLite

Public Class CalendarParticipants

    Dim eventid As Integer
    Dim youthids As New List(Of Integer)()
    Dim mode As String
    Dim maxid As Integer

    Public Sub New(i As Integer)
        InitializeComponent()
        eventid = i
    End Sub

    Private Sub reloaddgv()
        Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
        Dim sql As String = "SELECT [ParticipantID], [Name], [YouthID] FROM [Participants] WHERE [EventID] = @id;"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@id", eventid)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub

    Private Sub CalendarParticipants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reloaddgv()
        Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
        Dim sql1 As String = "SELECT [YouthID] FROM [Participants] WHERE [EventID] = @id"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@id", eventid)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read
                        youthids.Add(reader.GetInt32(0))
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub CloseBttn_Click(sender As Object, e As EventArgs) Handles CloseBttn.Click
        Close()
    End Sub

    Private Sub InsertBttn_Click(sender As Object, e As EventArgs) Handles InsertBttn.Click
        Dim bttns() As Button = {InsertBttn, DeleteBttn}
        StringStorage.Visible(bttns, False)
        ConfirmBttn.Visible = True
        Label1.Visible = True
        ComboBox1.Visible = True

        Dim connectionString As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim sql As String = "SELECT [Name] FROM [Youth] WHERE [YouthID] > 0;"
        Dim sql1 As String = "SELECT [Name] FROM [Youth] WHERE [YouthID] = @i"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        ComboBox1.Items.Add(reader.GetString(0))
                    End While
                End Using
            End Using

            For Each i In youthids
                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@i", i)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            ComboBox1.Items.Remove(reader.GetString(0))
                        End While
                    End Using
                End Using
            Next
        End Using
        mode = "Insert"
    End Sub

    Private Sub DeleteBttn_Click(sender As Object, e As EventArgs) Handles DeleteBttn.Click
        Dim bttns() As Button = {InsertBttn, DeleteBttn}
        StringStorage.Visible(bttns, False)
        ConfirmBttn.Visible = True
        mode = "Delete"
    End Sub

    Private Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        Dim n As String
        Dim d As String
        Dim dt As DateTime
        Dim nop As Integer
        Dim sql As String = "SELECT [Name], [Description], [Date], [NumberofParticipants] FROM [Events] WHERE [EventID] = @eid"
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.EventHandlerDatabase))
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@eid", eventid)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        n = reader.GetString(0)
                        d = reader.GetString(1)
                        dt = reader.GetDateTime(2)
                        nop = reader.GetInt32(3)
                    End If
                End Using
            End Using
        End Using

        If mode.Equals("Insert") Then
            If Not StringStorage.CheckString(ComboBox1.Text, 99).Equals("") Then
                FeedbackLbl.Text = "The field is empty."
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                Dim connectionString1 As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
                Dim sql1 As String = "SELECT [YouthID] FROM [Youth] WHERE [Name] = @name;"
                Dim youthid As Integer
                Dim maxida As Integer
                Dim connectionString2 As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
                Dim sql2 As String = "SELECT MAX(ParticipantID) FROM [Participants]"
                Dim sql3 As String = "INSERT INTO [Participants] VALUES (@pid, @name, @eid, @yid);"
                Dim sql4 As String = "UPDATE [Events] SET [NumberofParticipants] = [NumberofParticipants] + 1 WHERE [EventID] = @eid"

                Using connection As New SQLiteConnection(connectionString1)
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@name", ComboBox1.Text)
                        youthid = Convert.ToInt32(command.ExecuteScalar())
                    End Using
                End Using

                Using connection As New SQLiteConnection(connectionString2)
                    connection.Open()
                    Using command As New SQLiteCommand(sql2, connection)
                        maxida = Convert.ToInt32(command.ExecuteScalar())
                    End Using

                    Using command As New SQLiteCommand(sql3, connection)
                        command.Parameters.AddWithValue("@pid", maxida + 1)
                        command.Parameters.AddWithValue("@name", ComboBox1.Text)
                        command.Parameters.AddWithValue("@eid", eventid)
                        command.Parameters.AddWithValue("@yid", youthid)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@eid", eventid)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Security
                Dim sql5 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql6 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t As String = "ParticipantID: " & maxida + 1 & " | Name: " & ComboBox1.Text & " | EventID: " & eventid & " | YouthID: " & youthid
                    Using command As New SQLiteCommand(sql5, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql6, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "EventHandler")
                        command.Parameters.AddWithValue("@table", "Participants")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using

                    t = "ID: " & eventid & " | Name: " & n & " | Description: " & d & " | Date: " & dt.ToString("MM/dd/yyyy") & " | NumberofParticipants: " & nop + 1
                    Dim f As String = "ID: " & eventid & " | Name: " & n & " | Description: " & d & " | Date: " & dt.ToString("MM/dd/yyyy") & " | NumberofParticipants: " & nop

                    Using command As New SQLiteCommand(sql6, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 2)
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


                ComboBox1.Items.Remove(ComboBox1.Text)
                reloaddgv()
                FeedbackLbl.Text = "Successfully added!"
                FeedbackLbl.ForeColor = Color.Green
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            End If

        ElseIf mode.Equals("Delete") Then
            'Checks if the selected row is valid
            Dim index As Integer = -1
            If DataGridView1.SelectedRows.Count <= 0 Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                index = DataGridView1.SelectedRows(0).Index
            End If

            If Not index = -1 Then
                If index < 0 Or index > maxid Then
                    FeedbackLbl.Text = "Invalid row selection"
                    FeedbackLbl.ForeColor = Color.Red
                Else
                    'Code
                    Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
                    Dim sql1 As String = "DELETE FROM [Participants] WHERE [ParticipantID] = @pid"
                    Dim sql2 As String = "UPDATE [Events] SET [NumberofParticipants] = [NumberofParticipants] - 1 WHERE [EventID] = @eid"

                    Using connection As New SQLiteConnection(connectionString)
                        connection.Open()
                        Using command As New SQLiteCommand(sql1, connection)
                            command.Parameters.AddWithValue("@pid", DataGridView1.SelectedRows(0).Cells(0).Value)
                            command.ExecuteNonQuery()
                        End Using

                        Using command As New SQLiteCommand(sql2, connection)
                            command.Parameters.AddWithValue("@eid", eventid)
                            command.ExecuteNonQuery()
                        End Using
                    End Using


                    'Security
                    Dim sql5 As String = "SELECT MAX(LogID) FROM Logs"
                    Dim sql6 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                    Dim maxidlog As Integer
                    Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                        connection.Open()
                        Dim f As String = "ParticipantID: " & DataGridView1.SelectedRows(0).Cells(0).Value & " | Name: " & DataGridView1.SelectedRows(0).Cells(1).Value & " | EventID: " & eventid & " | YouthID: " & DataGridView1.SelectedRows(0).Cells(2).Value
                        Using command As New SQLiteCommand(sql5, connection)
                            maxidlog = Integer.Parse(command.ExecuteScalar)
                        End Using
                        Using command As New SQLiteCommand(sql6, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + 1)
                            command.Parameters.AddWithValue("@db", "EventHandler")
                            command.Parameters.AddWithValue("@table", "Participants")
                            command.Parameters.AddWithValue("@act", "Delete")
                            command.Parameters.AddWithValue("@f", f)
                            command.Parameters.AddWithValue("@t", "-")
                            command.Parameters.AddWithValue("@dt", DateTime.Now)
                            command.Parameters.AddWithValue("@user", Login.logged)
                            command.ExecuteNonQuery()
                        End Using

                        Dim t As String = "ID: " & eventid & " | Name: " & n & " | Description: " & d & " | Date: " & dt.ToString("MM/dd/yyyy") & " | NumberofParticipants: " & nop - 1
                        f = "ID: " & eventid & " | Name: " & n & " | Description: " & d & " | Date: " & dt.ToString("MM/dd/yyyy") & " | NumberofParticipants: " & nop

                        Using command As New SQLiteCommand(sql6, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + 2)
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

                    ComboBox1.Items.Add(ComboBox1.Text)
                    reloaddgv()
                    FeedbackLbl.Text = "Successfully removed!"
                    FeedbackLbl.ForeColor = Color.Green
                    StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
                    Dim bttns() As Button = {InsertBttn, DeleteBttn}
                    StringStorage.Visible(bttns, True)
                    ConfirmBttn.Visible = False
                    mode = ""
                End If
            End If
        End If
    End Sub
End Class