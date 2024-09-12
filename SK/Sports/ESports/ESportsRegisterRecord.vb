Imports System.Data.SQLite

Public Class ESportsRegisterRecord
    Dim maxidgame As Integer
    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        ESportsMainForm.Show()
        Close()
    End Sub

    Private Sub ESportsRegisterRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Puts team name on ComboBox
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim sql As String = "SELECT [TeamName] FROM [Teams];"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    Dim skip As Boolean = False
                    While reader.Read
                        If Not skip Then
                            skip = True
                        Else
                            Team1CB.Items.Add(reader.GetString(0))
                            Team2CB.Items.Add(reader.GetString(0))
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        'Checks the team names
        If Not StringStorage.CheckString(Team1CB.Text, 50) = "" Or Not StringStorage.CheckString(Team2CB.Text, 50) = "" Then
            Feedback1.Text = "Team Names are invalid, or too long."
            StringStorage.ShowLabelsForThreeSeconds(Feedback1)
        ElseIf Team1CB.Text.Equals(Team2CB.Text) Then
            Feedback1.Text = "The team cannot fight themselves."
            StringStorage.ShowLabelsForThreeSeconds(Feedback1)
            'Checks the checkboxes
        ElseIf Not CheckBox1.Checked Xor CheckBox2.Checked Then
            Feedback1.Text = "Select the team that won the match."
            StringStorage.ShowLabelsForThreeSeconds(Feedback1)
            'Checks the datepicker
        ElseIf DateTimePicker1.Value.Date > Date.Today Then
            Feedback1.Text = "You cannot select a date in the future."
            StringStorage.ShowLabelsForThreeSeconds(Feedback1)
        Else
            'Records on the Game Table
            Dim sql3 As String = "SELECT [PlayerName] FROM [Players] WHERE [TeamName] = @tname;"
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB}
                Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB}
                'Fills the Player Names with appropriate names based on team name
                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", Team1CB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read
                            For Each i In names1
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", Team2CB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read
                            For Each i In names2
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using
            End Using

            'Sets visibility
            Dim cb() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Position1CB, Position2CB, Position3CB, Position4CB, Position5CB, Position6CB, Position7CB, Position8CB, Position9CB, Position10CB}
            Dim txtbx() As TextBox = {Kills1TB, Kills2TB, Kills3TB, Kills4TB, Kills5TB, Kills6TB, Kills7TB, Kills8TB, Kills9TB, Kills10TB, Deaths1TB, Deaths2TB, Deaths3TB, Deaths4TB, Deaths5TB, Deaths6TB, Deaths7TB, Deaths8TB, Deaths9TB, Deaths10TB, Assists1TB, Assists2TB, Assists3TB, Assists4TB, Assists5TB, Assists6TB, Assists7TB, Assists8TB, Assists9TB, Assists10TB}
            Dim lbl() As Label = {Label5, Label6, Label7, Label8, Label9, Feedback2, Team1Lbl, Team2Lbl}
            StringStorage.Visible(cb, True)
            StringStorage.Visible(txtbx, True)
            StringStorage.Visible(lbl, True)
            Feedback2.Text = "Encode the appropriate stats."
            ConfirmBttn.Visible = False
            SubmitBttn.Visible = True
            DateTimePicker1.Enabled = False
            Team1CB.Enabled = False
            Team2CB.Enabled = False
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox2.Checked = Not CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        CheckBox1.Checked = Not CheckBox2.Checked
    End Sub

    Private Async Sub SubmitBttn_Click(sender As Object, e As EventArgs) Handles SubmitBttn.Click
        Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB}
        Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB}
        Dim pos1() As ComboBox = {Position1CB, Position2CB, Position3CB, Position4CB, Position5CB}
        Dim pos2() As ComboBox = {Position6CB, Position7CB, Position8CB, Position9CB, Position10CB}
        Dim kda() As TextBox = {Kills1TB, Kills2TB, Kills3TB, Kills4TB, Kills5TB, Kills6TB, Kills7TB, Kills8TB, Kills9TB, Kills10TB, Deaths1TB, Deaths2TB, Deaths3TB, Deaths4TB, Deaths5TB, Deaths6TB, Deaths7TB, Deaths8TB, Deaths9TB, Deaths10TB, Assists1TB, Assists2TB, Assists3TB, Assists4TB, Assists5TB, Assists6TB, Assists7TB, Assists8TB, Assists9TB, Assists10TB}

        Dim hasblank As Boolean = False
        For i = 0 To 4
            If Not (StringStorage.CheckString(names1(i).Text, 50).Equals("") And StringStorage.CheckString(names2(i).Text, 50).Equals("") And StringStorage.CheckString(pos1(i).Text, 50).Equals("") And StringStorage.CheckString(pos2(i).Text, 50).Equals("")) Then
                hasblank = True
                Exit For
            End If
        Next
        For Each i In kda
            If Not StringStorage.CheckString(i.Text, 50).Equals("") Then
                hasblank = True
                Exit For
            End If
        Next

        'Checks if kda is numbers
        Dim hasnonnumber As Boolean = False
        For Each i In kda
            If Not StringStorage.IsNumber(i.Text) Then
                hasnonnumber = True
                Exit For
            End If
        Next

        'Checks for same name and position
        Dim hassimilar As Boolean = False
        If StringStorage.Similar(names1) Or StringStorage.Similar(names2) Or StringStorage.Similar(pos1) Or StringStorage.Similar(pos2) Then
            hassimilar = True
        End If

        If hasblank Then
            Feedback2.ForeColor = Color.Red
            Feedback2.Text = "Some fields are empty"
            StringStorage.ShowLabelsForThreeSeconds(Feedback2)
        ElseIf hasnonnumber Then
            Feedback2.ForeColor = Color.Red
            Feedback2.Text = "Some fields of the KDA contains a non-number character"
            StringStorage.ShowLabelsForThreeSeconds(Feedback2)
        ElseIf hassimilar Then
            Feedback2.ForeColor = Color.Red
            Feedback2.Text = "Some names or position from the same team is similar."
            StringStorage.ShowLabelsForThreeSeconds(Feedback2)
        Else
            Dim sqlg1 As String = "SELECT MAX(GameId) FROM [Games];"
            Dim sqlg2 As String = "INSERT INTO [Games] (GameId, GameDate, Team1, Team2, TeamWon) VALUES (@id, @date, @t1, @t2, @tw);"

            'Inserts records
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim recordid As Integer
            Dim sql1 As String = "SELECT MAX(RecordId) FROM [Records];"
            Dim sql2 As String = "INSERT INTO [Records] (RecordId, PlayerName, Position, Kills, Deaths, Assists, GameId) VALUES (@rid, @pname, @pos, @k, @d, @a, @gid);"
            Dim pname() As String = {Name1CB.Text, Name2CB.Text, Name3CB.Text, Name4CB.Text, Name5CB.Text, Name6CB.Text, Name7CB.Text, Name8CB.Text, Name9CB.Text, Name10CB.Text}
            Dim pos() As String = {Position1CB.Text, Position2CB.Text, Position3CB.Text, Position4CB.Text, Position5CB.Text, Position6CB.Text, Position7CB.Text, Position8CB.Text, Position9CB.Text, Position10CB.Text}
            Dim k() As Integer = {Integer.Parse(Kills1TB.Text), Integer.Parse(Kills2TB.Text), Integer.Parse(Kills3TB.Text), Integer.Parse(Kills4TB.Text), Integer.Parse(Kills5TB.Text), Integer.Parse(Kills6TB.Text), Integer.Parse(Kills7TB.Text), Integer.Parse(Kills8TB.Text), Integer.Parse(Kills9TB.Text), Integer.Parse(Kills10TB.Text)}
            Dim d() As Integer = {Integer.Parse(Deaths1TB.Text), Integer.Parse(Deaths2TB.Text), Integer.Parse(Deaths3TB.Text), Integer.Parse(Deaths4TB.Text), Integer.Parse(Deaths5TB.Text), Integer.Parse(Deaths6TB.Text), Integer.Parse(Deaths7TB.Text), Integer.Parse(Deaths8TB.Text), Integer.Parse(Deaths9TB.Text), Integer.Parse(Deaths10TB.Text)}
            Dim a() As Integer = {Integer.Parse(Assists1TB.Text), Integer.Parse(Assists2TB.Text), Integer.Parse(Assists3TB.Text), Integer.Parse(Assists4TB.Text), Integer.Parse(Assists5TB.Text), Integer.Parse(Assists6TB.Text), Integer.Parse(Assists7TB.Text), Integer.Parse(Assists8TB.Text), Integer.Parse(Assists9TB.Text), Integer.Parse(Assists10TB.Text)}
            Dim teamwon As String = ""
            If CheckBox1.Checked Then
                teamwon = Team1CB.Text
            Else
                teamwon = Team2CB.Text
            End If

            Dim t(10) As String

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    recordid = Integer.Parse(command.ExecuteScalar())
                End Using
                recordid += 1

                'Fetches the latest id
                Using command As New SQLiteCommand(sqlg1, connection)
                    maxidgame = Integer.Parse(command.ExecuteScalar())
                End Using

                For i = 0 To 9
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@rid", recordid + i)
                        command.Parameters.AddWithValue("@pname", pname(i))
                        command.Parameters.AddWithValue("@pos", pos(i))
                        command.Parameters.AddWithValue("@k", k(i))
                        command.Parameters.AddWithValue("@d", d(i))
                        command.Parameters.AddWithValue("@a", a(i))
                        command.Parameters.AddWithValue("@gid", maxidgame + 1)
                        command.ExecuteNonQuery()
                    End Using
                    t(i) = "RecordId: " & recordid + i & " | PlayerName: " & pname(i) & " | Position: " & pos(i) & " | Kills: " & k(i) & " | Deaths: " & d(i) & " | Assists: " & a(i) & " | GameId: " & maxidgame
                Next

                'Inserts new team
                Using command As New SQLiteCommand(sqlg2, connection)
                    command.Parameters.AddWithValue("@id", maxidgame + 1)
                    command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@t1", Team1CB.Text)
                    command.Parameters.AddWithValue("@t2", Team2CB.Text)
                    command.Parameters.AddWithValue("@tw", teamwon)
                    command.ExecuteNonQuery()
                End Using
            End Using

            'Security
            Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim tg As String = "ID: " & maxidgame + 1 & " | GameDate: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Team1: " & Team1CB.Text & " | Team2: " & Team2CB.Text & " | TeamWon: " & teamwon
            Dim maxidlog As Integer

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                maxidlog += 1

                For i = 0 To 9
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + i)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Records")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t(i))
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 10)
                    command.Parameters.AddWithValue("@db", "SportsEsports")
                    command.Parameters.AddWithValue("@table", "Games")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", tg)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Feedback2.Text = "Game successfully registered! Reverting."
            Feedback2.ForeColor = Color.Green
            Feedback2.Visible = True
            Await Task.Delay(3000)
            ESportsMainForm.Show()
            Close()
        End If
    End Sub
End Class