Imports System.Data.Entity.Migrations
Imports System.Data.SQLite
Imports iText.StyledXmlParser.Jsoup.Select.Evaluator

Public Class VolleyballRegisterGame
    Dim con As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Dim idCount As Integer
    Dim confirmed As Boolean = False


    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If Not StringStorage.CheckString(Team1ComboBox.Text, 50) = "" Or Not StringStorage.CheckString(Team2ComboBox.Text, 50) = "" Then
            MessageBox.Show("Team Names Invalid!!")
        ElseIf Team1ComboBox.Text.Equals(Team2ComboBox.Text) Then
            MessageBox.Show("This team cannot fight themselves")
        ElseIf Not Team1WonCheckBox.Checked Xor Team2WonCheckBox.Checked Then
            MessageBox.Show("Select which team won!!")
        ElseIf DateTimePicker1.Value.Date > Date.Today Then
            MessageBox.Show("Cannot select a date in the future!!")
        Else
            Dim lbls() As Label = {Label4, Label5, Label6, Label7, Label8, Label9, Label10}
            Dim cbox() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Name11CB, Name12CB, Position11CB, Position12CB, Position10CB, Position2CB, Position3CB, Position4CB, Position5CB, Position6CB, Position7CB, Position8CB, Position9CB, Position1CB}
            Dim tbox() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Points11TB, Points12TB, Assist11TB, Assist12TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB, Rebound11TB, Rebound12TB}
            SubmitBtn.Visible = True
            StringStorage.Visible(lbls, True)
            StringStorage.Visible(cbox, True)
            StringStorage.Visible(tbox, True)

            Dim sql3 As String = "SELECT [Name] FROM [Players] WHERE [TeamName] = @tname;"

            Using connection As New SQLiteConnection(con)
                connection.Open()



                Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name11CB}
                Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Name12CB}

                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", Team1ComboBox.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read
                            For Each i In names1
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", Team2ComboBox.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read
                            For Each i In names2
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using

            End Using

            Dim cb() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Name11CB, Name12CB}
            Dim txtb() As TextBox = {Points11TB, Points12TB, Assist11TB, Assist12TB, Rebound11TB, Rebound12TB, Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Assist1TB, Rebound1TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}
            StringStorage.Visible(cb, True)
            StringStorage.Visible(txtb, True)
            ConfirmBtn.Visible = False
            DateTimePicker1.Enabled = False
            Team1ComboBox.Enabled = False
            Team2ComboBox.Enabled = False
            Team1WonCheckBox.Enabled = False
            Team2WonCheckBox.Enabled = False
            confirmed = True
            MessageBox.Show("Input all stats of the game.")
        End If
    End Sub

    Private Sub VolleyballRegisterGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT [TeamName] FROM [Team];"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                Dim skip As Boolean = False
                While reader.Read
                    If Not skip Then
                        skip = True
                    Else
                        Team1ComboBox.Items.Add(reader.GetString(0))
                        Team2ComboBox.Items.Add(reader.GetString(0))
                    End If
                End While
            End Using
        End Using
    End Sub

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Dim sqlRecord As String = "SELECT MAX(GameID) FROM [Games];"
        Dim sqlInsert As String = "INSERT INTO [Games] (GameID, Date, Team1, Team2, TeamWon) VALUES (@gameId, @gameDate, @team1, @team2, @teamWon);"
        Dim idCount As Integer

        Dim teamwon As String = ""
        Dim t(12) As String
        Dim tg As String = ""

        Using connection As New SQLiteConnection(con)
            connection.Open()

            ' Retrieve the current max GameID
            Using cmd As New SQLiteCommand(sqlRecord, connection)
                idCount = Integer.Parse(cmd.ExecuteScalar)
            End Using

            ' Use a transaction for data integrity
            Using transaction = connection.BeginTransaction()
                Using cmd As New SQLiteCommand(sqlInsert, connection, transaction)
                    cmd.Parameters.AddWithValue("@gameId", idCount + 1)
                    cmd.Parameters.AddWithValue("@gameDate", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@team1", Team1ComboBox.Text)
                    cmd.Parameters.AddWithValue("@team2", Team2ComboBox.Text)
                    If (Team1WonCheckBox.Checked) Then
                        cmd.Parameters.AddWithValue("@teamWon", Team1ComboBox.Text)
                        teamwon = Team1ComboBox.Text
                    Else
                        cmd.Parameters.AddWithValue("@teamWon", Team2ComboBox.Text)
                        teamwon = Team1ComboBox.Text
                    End If
                    Try
                        cmd.ExecuteNonQuery()
                        tg = "ID: " & idCount + 1 & " | Team1: " & Team1ComboBox.Text & " | Team2: " & Team2ComboBox.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | TeamWon: " & teamwon
                        transaction.Commit()
                    Catch ex As SQLiteException
                        transaction.Rollback()
                        Throw ' Re-throw the exception to handle it higher up
                    End Try
                End Using
            End Using
        End Using

        ' Validation part
        Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name11CB}
        Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Name12CB}
        Dim pos1() As ComboBox = {Position1CB, Position2CB, Position3CB, Position4CB, Position5CB, Position11CB}
        Dim pos2() As ComboBox = {Position6CB, Position7CB, Position8CB, Position9CB, Position10CB, Position12CB}
        Dim stats() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Points11TB, Points12TB, Assist1TB, Assist11TB, Assist12TB, Rebound11TB, Rebound12TB, Rebound1TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}

        Dim n1() As Integer = {0, 1, 2, 3, 4, 10}
        Dim n2() As Integer = {5, 6, 7, 8, 9, 11}

        Dim empty As Boolean = False
        For i = 0 To 5
            If Not (StringStorage.CheckString(names1(i).Text, 50).Equals("") And StringStorage.CheckString(names2(i).Text, 50).Equals("") And StringStorage.CheckString(pos1(i).Text, 50).Equals("") And StringStorage.CheckString(pos2(i).Text, 50).Equals("")) Then
                empty = True
                Exit For
            End If
        Next
        For Each i In stats
            If Not StringStorage.CheckString(i.Text, 50).Equals("") Then
                empty = True
                Exit For
            End If
        Next

        Dim nonum As Boolean = False
        For Each i In stats
            If Not StringStorage.IsNumber(i.Text) Then
                nonum = True
                Exit For
            End If
        Next

        Dim same As Boolean = False
        If StringStorage.Similar(names1) Or StringStorage.Similar(names2) Or StringStorage.Similar(pos1) Or StringStorage.Similar(pos2) Then
            same = True
        End If

        If empty Then
            MessageBox.Show("Some fields are empty!")
        ElseIf nonum Then
            MessageBox.Show("Some stats contain a non-numeric character!")
        ElseIf same Then
            MessageBox.Show("Some names or positions from the same team are similar")
        Else
            SubmitBtn.Visible = True

            Dim idrecord As Integer
            Dim sql1 As String = "SELECT MAX(RecordID) FROM [Records];"
            Dim sql2 As String = "INSERT INTO [Records] (RecordID, [PlayerName], Points, Blocks, Digs, Position, GameID) VALUES (@recordId, @pName, @pts, @ast, @reb, @pos, @gid);"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                ' Retrieve the current max RecordID
                Using cmd As New SQLiteCommand(sql1, connection)
                    Dim result = cmd.ExecuteScalar()
                    idrecord = Integer.Parse(result)
                End Using

                ' Use a transaction for data integrity
                Using transaction = connection.BeginTransaction()
                    Try
                        ' Insert player records
                        For i As Integer = 0 To names1.Length - 1
                            Using cmd As New SQLiteCommand(sql2, connection, transaction)
                                cmd.Parameters.AddWithValue("@recordId", idrecord + 1 + i)
                                cmd.Parameters.AddWithValue("@pName", names1(i).Text)
                                cmd.Parameters.AddWithValue("@pos", pos1(i).Text)
                                cmd.Parameters.AddWithValue("@pts", Integer.Parse(stats(i * 3).Text))
                                cmd.Parameters.AddWithValue("@ast", Integer.Parse(stats(i * 3 + 1).Text))
                                cmd.Parameters.AddWithValue("@reb", Integer.Parse(stats(i * 3 + 2).Text))
                                cmd.Parameters.AddWithValue("@gid", idCount + 1)
                                cmd.ExecuteNonQuery()
                            End Using

                            t(n1(i)) = "RecordID: " & idrecord + i & " | PlayerName: " & names1(i).Text & " | Position: " & pos1(i).Text & " | Points: " & Integer.Parse(stats(i * 3).Text) & " | Blocks: " & Integer.Parse(stats(i * 3 + 1).Text) & " | Digs: " & Integer.Parse(stats(i * 3 + 2).Text) & " | GameID: " & idCount + 1
                        Next

                        ' Repeat the same for the second set of player records
                        For i As Integer = 0 To names2.Length - 1
                            Using cmd As New SQLiteCommand(sql2, connection, transaction)
                                cmd.Parameters.AddWithValue("@recordId", idrecord + 1 + names1.Length + i)
                                cmd.Parameters.AddWithValue("@pName", names2(i).Text)
                                cmd.Parameters.AddWithValue("@pos", pos2(i).Text)
                                cmd.Parameters.AddWithValue("@pts", Integer.Parse(stats((names1.Length + i) * 3).Text))
                                cmd.Parameters.AddWithValue("@ast", Integer.Parse(stats((names1.Length + i) * 3 + 1).Text))
                                cmd.Parameters.AddWithValue("@reb", Integer.Parse(stats((names1.Length + i) * 3 + 2).Text))
                                cmd.Parameters.AddWithValue("@gid", idCount + 1)
                                cmd.ExecuteNonQuery()
                            End Using

                            t(n2(i)) = "RecordID: " & idrecord + i & " | PlayerName: " & names2(i).Text & " | Position: " & pos2(i).Text & " | Points: " & Integer.Parse(stats((names1.Length + i) * 3).Text) & " | Blocks: " & Integer.Parse(stats((names1.Length + i) * 3 + 1).Text) & " | Digs: " & Integer.Parse(stats((names1.Length + i) * 3 + 2).Text) & " | GameID: " & idCount + 1
                        Next

                        transaction.Commit()
                    Catch ex As SQLiteException
                        transaction.Rollback()
                        Throw ' Re-throw the exception to handle it higher up
                    End Try
                End Using
            End Using

            'Security
            Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                maxidlog += 1

                For i = 0 To 11
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + i)
                        command.Parameters.AddWithValue("@db", "SportsVolleyball")
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
                    command.Parameters.AddWithValue("@id", maxidlog + 12)
                    command.Parameters.AddWithValue("@db", "SportsVolleyball")
                    command.Parameters.AddWithValue("@table", "Games")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", tg)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            confirmed = False
            MessageBox.Show("Game successfully registered!")
            BasketballMainForm.Show()
            Close()
        End If
    End Sub

End Class