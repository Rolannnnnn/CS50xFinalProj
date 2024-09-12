Imports System.Data.SQLite

Public Class ESportsEditTeam
    Private Sub ESportsEditTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                            TeamNameCB.Items.Add(reader.GetString(0))
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub


    Dim mode As String
    Private Async Sub EditBttn_Click(sender As Object, e As EventArgs) Handles EditBttn.Click
        Dim feedback As String = StringStorage.CheckString(TeamNameCB.Text, 50)
        Dim def As String = "Select the Team that will be Edited or Deleted"
        'Check if the selected team is valid
        If Not (feedback.Equals("")) Then
            FeedbackLbl.Text = feedback
            FeedbackLbl.ForeColor = Color.Red
            Await Task.Delay(3000)
            FeedbackLbl.Text = def
            FeedbackLbl.ForeColor = Color.Black
        Else
            'Sets the mode as edit
            TeamNameCB.Enabled = False
            DeleteBttn.Visible = False
            EditBttn.Visible = False
            NewTeamLbl.Visible = True
            NewTeamTxtBox.Visible = True
            ConfirmBttn.Visible = True
            FeedbackLbl.Text = "Type new Team Name"
            mode = "Edit"
        End If
    End Sub

    Private Async Sub DeleteBttn_Click(sender As Object, e As EventArgs) Handles DeleteBttn.Click
        Dim feedback As String = StringStorage.CheckString(TeamNameCB.Text, 50)
        Dim def As String = "Select the Team that will be Edited or Deleted"
        'Check if the selected team is valid
        If Not (feedback.Equals("")) Then
            FeedbackLbl.Text = feedback
            FeedbackLbl.ForeColor = Color.Red
            Await Task.Delay(3000)
            FeedbackLbl.Text = def
            FeedbackLbl.ForeColor = Color.Black
        Else
            'Sets the mode as delete
            TeamNameCB.Enabled = False
            DeleteBttn.Visible = False
            EditBttn.Visible = False
            ConfirmBttn.Visible = True
            ConfirmBttn.Visible = True
            FeedbackLbl.Text = "You are about to Delete this Team, along with its Players, records and Games."
            FeedbackLbl.ForeColor = Color.Red
            mode = "Delete"
        End If
    End Sub

    Private Async Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        'In edit, edit all players' teams too
        If mode.Equals("Edit") Then
            Dim feedback As String = StringStorage.CheckString(NewTeamTxtBox.Text, 50)
            If Not feedback.Equals("") Then
                FeedbackLbl.Text = feedback
                FeedbackLbl.ForeColor = Color.Red
                Await Task.Delay(3000)
                FeedbackLbl.ForeColor = Color.Black
            Else
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
                Dim sql1 As String = "UPDATE [Teams] SET [TeamName] = @ntname WHERE [TeamName] = @otname;"
                Dim sql2 As String = "UPDATE [Players] SET [TeamName] = @ntname WHERE [TeamName] = @otname;"
                Dim sql3 As String = "UPDATE [Games] SET [Team1] = @ntname WHERE [Team1] = @otname;"
                Dim sql4 As String = "UPDATE [Games] SET [Team2] = @ntname WHERE [Team2] = @otname;"
                Dim sql5 As String = "UPDATE [Games] SET [TeamWon] = @ntname WHERE [TeamWon] = @otname;"

                'Security
                Dim ft As String = ""
                Dim tt As String = ""
                Dim sqlst As String = "SELECT [TeamId], [TeamName], [NumberofPlayers] FROM [Teams] WHERE [TeamName] = @tname"
                Dim fp As New List(Of String)
                Dim tp As New List(Of String)
                Dim sqlsp As String = "SELECT [PlayerId], [PlayerName], [YouthID], [Position], [TeamName] FROM [Players] WHERE [TeamName] = @tname"
                Dim fg As New List(Of String)
                Dim tg As New List(Of String)
                Dim sqlsg As String = "SELECT [GameId], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    Using command As New SQLiteCommand(sqlst, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                ft = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | NumberofPlayers: " & reader.GetInt32(2)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsp, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                fp.Add("PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsg, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                fg.Add("ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@ntname", NewTeamTxtBox.Text)
                        command.Parameters.AddWithValue("@otname", TeamNameCB.Text)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@ntname", NewTeamTxtBox.Text)
                        command.Parameters.AddWithValue("@otname", TeamNameCB.Text)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql3, connection)
                        command.Parameters.AddWithValue("@ntname", NewTeamTxtBox.Text)
                        command.Parameters.AddWithValue("@otname", TeamNameCB.Text)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@ntname", NewTeamTxtBox.Text)
                        command.Parameters.AddWithValue("@otname", TeamNameCB.Text)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql5, connection)
                        command.Parameters.AddWithValue("@ntname", NewTeamTxtBox.Text)
                        command.Parameters.AddWithValue("@otname", TeamNameCB.Text)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sqlst, connection)
                        command.Parameters.AddWithValue("@tname", NewTeamTxtBox.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                tt = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | NumberofPlayers: " & reader.GetInt32(2)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsp, connection)
                        command.Parameters.AddWithValue("@tname", NewTeamTxtBox.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                tp.Add("PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsg, connection)
                        command.Parameters.AddWithValue("@tname", NewTeamTxtBox.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                tg.Add("ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4))
                            End While
                        End Using
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

                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Teams")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", ft)
                        command.Parameters.AddWithValue("@t", tt)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using

                    For i = 0 To fp.Count - 1
                        Using command As New SQLiteCommand(sqls2, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + 2 + i)
                            command.Parameters.AddWithValue("@db", "SportsEsports")
                            command.Parameters.AddWithValue("@table", "Players")
                            command.Parameters.AddWithValue("@act", "Update")
                            command.Parameters.AddWithValue("@f", fp(i))
                            command.Parameters.AddWithValue("@t", tp(i))
                            command.Parameters.AddWithValue("@dt", DateTime.Now)
                            command.Parameters.AddWithValue("@user", Login.logged)
                            command.ExecuteNonQuery()
                        End Using
                    Next

                    Using command As New SQLiteCommand(sqls1, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using

                    For i = 0 To fg.Count - 1
                        Using command As New SQLiteCommand(sqls2, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + 1 + i)
                            command.Parameters.AddWithValue("@db", "SportsEsports")
                            command.Parameters.AddWithValue("@table", "Games")
                            command.Parameters.AddWithValue("@act", "Update")
                            command.Parameters.AddWithValue("@f", fg(i))
                            command.Parameters.AddWithValue("@t", tg(i))
                            command.Parameters.AddWithValue("@dt", DateTime.Now)
                            command.Parameters.AddWithValue("@user", Login.logged)
                            command.ExecuteNonQuery()
                        End Using
                    Next
                End Using


                FeedbackLbl.Text = "Successfully edited team! Reverting."
                FeedbackLbl.ForeColor = Color.Green
                Await Task.Delay(3000)
                ESportsMainForm.Show()
                Close()
            End If

            'For Delete
        ElseIf mode.Equals("Delete") Then
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim sql1 As String = "DELETE FROM [Teams] WHERE [TeamName] = @tname;"
            Dim sql2 As String = "DELETE FROM [Players] WHERE [TeamName] = @tname;"
            Dim sql3 As String = "SELECT [GameId] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname OR [TeamWon] = @tname;"
            Dim sql5 As String = "DELETE FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname OR [TeamWon] = @tname;"

            'Security
            Dim ft As String = ""
            Dim sqlst As String = "SELECT [TeamId], [TeamName], [NumberofPlayers] FROM [Teams] WHERE [TeamName] = @tname"
            Dim fp As New List(Of String)
            Dim sqlsp As String = "SELECT [PlayerId], [PlayerName], [YouthID], [Position], [TeamName] FROM [Players] WHERE [TeamName] = @tname"
            Dim fg As New List(Of String)
            Dim sqlsg As String = "SELECT [GameId], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"
            Dim fr As New List(Of String)
            Dim sqlsr As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists], [GameId] FROM [Records] WHERE [GameId] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim gameIds As New List(Of Integer)()

                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim id As Integer = Convert.ToInt32(reader("GameId"))
                            gameIds.Add(id)
                        End While
                    End Using
                End Using

                For Each id In gameIds
                    Dim sql4 As String = "DELETE FROM [Records] WHERE [GameId] = @id;"

                    Using command2 As New SQLiteCommand(sqlsr, connection)
                        command2.Parameters.AddWithValue("@id", id)
                        Using reader As SQLiteDataReader = command2.ExecuteReader
                            While reader.Read
                                fr.Add("RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId: " & reader.GetInt32(6))
                            End While
                        End Using
                    End Using

                    Using command2 As New SQLiteCommand(sql4, connection)
                        command2.Parameters.AddWithValue("@id", id)
                        command2.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqlst, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            ft = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | NumberofPlayers: " & reader.GetInt32(2)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsp, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            fp.Add("PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsg, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            fg.Add("ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql5, connection)
                    command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                    command.ExecuteNonQuery()
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

                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsEsports")
                    command.Parameters.AddWithValue("@table", "Teams")
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", ft)
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using

                For i = 0 To fp.Count - 1
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 2 + i)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Players")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", fp(i))
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using

                For i = 0 To fg.Count - 1
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1 + i)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Games")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", fg(i))
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using

                For i = 0 To fr.Count - 1
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1 + i)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Records")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", fr(i))
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next
            End Using

            FeedbackLbl.Text = "Successfully deleted Team, Players, and its Records. Reverting."
            FeedbackLbl.ForeColor = Color.Green
            Await Task.Delay(3000)
            ESportsMainForm.Show()
            Close()
        End If
    End Sub
End Class