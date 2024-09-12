Imports System.Data.SQLite

Public Class ESportsEditPlayer
    Dim mode As String
    Dim maxid As Integer
    Private Sub ESportsEditPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim con As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)

        Dim sql As String = "SELECT YouthID FROM Players WHERE [YouthID] > 0;"

        TeamNamesCB.Items.Clear()
        Try
            Using connectionSports As New SQLiteConnection(con)
                connectionSports.Open()
                Using cmdSports As New SQLiteCommand(sql, connectionSports)
                    Using readerSports As SQLiteDataReader = cmdSports.ExecuteReader()
                        Dim youthIDs As New List(Of Integer)()

                        While readerSports.Read()
                            Dim youthID As Integer
                            If Integer.TryParse(readerSports("YouthID").ToString(), youthID) Then
                                youthIDs.Add(youthID)
                            End If
                        End While
                        Dim youthIDsString As String = String.Join(",", youthIDs)
                        Dim sqlKKProfiling As String = $"SELECT YouthID, Name FROM Youth WHERE YouthID IN ({youthIDsString});"

                        Using connectionKKProfiling As New SQLiteConnection(conkk)
                            connectionKKProfiling.Open()
                            Using cmdKKProfiling As New SQLiteCommand(sqlKKProfiling, connectionKKProfiling)
                                Using readerKKProfiling As SQLiteDataReader = cmdKKProfiling.ExecuteReader()

                                    While readerKKProfiling.Read()
                                        Dim playerId As Integer = readerKKProfiling.GetInt32(0)
                                        Dim playerName As String = readerKKProfiling.GetString(1)
                                        TeamNamesCB.Items.Add(New KeyValuePair(Of Integer, String)(playerId, playerName))
                                    End While
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Fills DataGridView, fetches maxid
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim sql1 As String = "SELECT PlayerId, YouthID, Position, TeamName FROM [Players] WHERE [PlayerId] > 0;"
        Dim sql2 As String = "SELECT MAX(PlayerId) FROM [Players];"

        Dim membersTable As New DataTable()
        Dim membersConnectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)

        Using connection As New SQLiteConnection(membersConnectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                Using adapter As New SQLiteDataAdapter(command)
                    adapter.Fill(membersTable)
                End Using
            End Using
        End Using

        Dim youthConnectionString As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim playerNameColumn As New DataColumn("Player Name", GetType(String))
        membersTable.Columns.Add(playerNameColumn)
        membersTable.Columns("Player Name").SetOrdinal(1)
        Using connection As New SQLiteConnection(youthConnectionString)
            connection.Open()
            For Each row As DataRow In membersTable.Rows
                Dim youthID As String = row("YouthID").ToString()
                Dim nameQuery As String = "SELECT Name FROM Youth WHERE YouthID = @YouthID"
                Using command As New SQLiteCommand(nameQuery, connection)
                    command.Parameters.AddWithValue("@YouthID", youthID)
                    Dim playerName As Object = command.ExecuteScalar()
                    If playerName IsNot Nothing Then
                        row("Player Name") = playerName.ToString()
                    Else
                        row("Player Name") = "Unknown"
                    End If
                End Using
            Next
        End Using

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql2, connection)
                maxid = Integer.Parse(command.ExecuteScalar())
            End Using
        End Using
        DataGridView1.DataSource = membersTable
    End Sub

    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        ESportsMainForm.Show()
        Close()
    End Sub

    Private Sub EditBttn_Click(sender As Object, e As EventArgs) Handles EditBttn.Click
        'Checks if the selected row is valid
        Dim index As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            FeedbackLbl.Text = "Invalid row selection"
            FeedbackLbl.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > maxid Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
            Else
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
                Dim sql1 As String = "SELECT [TeamName] FROM [Teams];"
                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
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
                FeedbackLbl.Text = "The records will also be edited. Write the edited texts in the fields."
                PositionCB.Visible = True
                TeamNameCB.Visible = True
                TeamNamesCB.Visible = True
                Dim lbl() As Label = {Label2, Label3, Label4}
                StringStorage.Visible(lbl, True)
                EditBttn.Visible = False
                DeleteBttn.Visible = False
                ConfirmBttn.Visible = True
                DataGridView1.Enabled = False

                mode = "Edit"
            End If
        End If
    End Sub

    Private Sub DeleteBttn_Click(sender As Object, e As EventArgs) Handles DeleteBttn.Click
        Label2.Visible = True
        TeamNamesCB.Visible = True
        ConfirmBttn.Visible = True
        mode = "Delete"
    End Sub

    Private Async Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        If mode.Equals("Edit") Then
            If Not (StringStorage.CheckString(TeamNamesCB.Text, 50).Equals("") And StringStorage.CheckString(PositionCB.Text, 50).Equals("") And StringStorage.CheckString(TeamNameCB.Text, 50).Equals("")) Then
                FeedbackLbl.Text = "Some fields are either empty or too long."
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                'Edits Players and Records Table, then If it changes Teams, edit the Player Number
                Dim selectedPlayer As KeyValuePair(Of Integer, String) = DirectCast(TeamNamesCB.SelectedItem, KeyValuePair(Of Integer, String))
                Dim selectedPlayerId As Integer = selectedPlayer.Key
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
                Dim sql1 As String = "UPDATE [Players] SET [Position] = @pos, [TeamName] = @tname WHERE [YouthID] = @id;"
                Dim sql2 As String = "UPDATE [Records] SET [Position] = @pos WHERE [YouthID] = @yid;"

                'Security
                Dim name As String = ""
                Dim fp As String = ""
                Dim f As New List(Of String)
                Dim tp As String = ""
                Dim t As New List(Of String)
                Dim sqlsf1 As String = "SELECT [PlayerId], [PlayerName], [YouthID], [Position], [TeamName] FROM Players WHERE [YouthID] = @id"
                Dim sqlsf2 As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists], [GameId] FROM Records WHERE [PlayerName] = @pn"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()

                    Using command As New SQLiteCommand(sqlsf1, connection)
                        command.Parameters.AddWithValue("@id", selectedPlayerId)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                fp = "PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4)
                                name = reader.GetString(1)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsf2, connection)
                        command.Parameters.AddWithValue("@pn", name)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                f.Add("RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId" & reader.GetInt32(6))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@pname", TeamNamesCB.Text)
                        command.Parameters.AddWithValue("@pos", PositionCB.Text)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        command.Parameters.AddWithValue("@id", selectedPlayerId)
                        Try
                            Dim rowsAffected As Integer = command.ExecuteNonQuery()

                            If PositionCB.Text = "" Or TeamNameCB.Text = "" Then
                                MessageBox.Show("Some fields are empty.")
                            ElseIf rowsAffected > 0 Then
                                MessageBox.Show("Changes saved successfully!")
                                PositionCB.Text = Nothing
                                TeamNameCB.Text = Nothing
                            Else
                                MessageBox.Show("No changes were made.")
                            End If
                        Catch ex As Exception
                            MessageBox.Show($"Error updating player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using

                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@pos", PositionCB.Text)
                        command.Parameters.AddWithValue("@yid", selectedPlayerId)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sqlsf1, connection)
                        command.Parameters.AddWithValue("@id", selectedPlayerId)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                tp = "PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4)
                                name = reader.GetString(1)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsf2, connection)
                        command.Parameters.AddWithValue("@pn", name)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                t.Add("RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId" & reader.GetInt32(6))
                            End While
                        End Using
                    End Using

                    If Not DataGridView1.SelectedRows(0).Cells(3).Value.Equals(TeamNameCB.Text) Then
                        Dim sql3 As String = "UPDATE [Teams] SET [NumberofPlayers] = [NumberofPlayers] - 1 WHERE [TeamName] = @tname;"
                        Dim sql4 As String = "UPDATE [Teams] SET [NumberofPlayers] = [NumberofPlayers] + 1 WHERE [TeamName] = @tname;"

                        Using command As New SQLiteCommand(sql3, connection)
                            command.Parameters.AddWithValue("@tname", DataGridView1.SelectedRows(0).Cells(4).Value)
                            command.ExecuteNonQuery()
                        End Using

                        Using command As New SQLiteCommand(sql4, connection)
                            command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                            command.ExecuteNonQuery()
                        End Using
                    End If
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
                        command.Parameters.AddWithValue("@table", "Players")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", fp)
                        command.Parameters.AddWithValue("@t", tp)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using

                    For i = 0 To f.Count - 1
                        Using command As New SQLiteCommand(sqls2, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + i + 2)
                            command.Parameters.AddWithValue("@db", "SportsEsports")
                            command.Parameters.AddWithValue("@table", "Records")
                            command.Parameters.AddWithValue("@act", "Update")
                            command.Parameters.AddWithValue("@f", f(i))
                            command.Parameters.AddWithValue("@t", t(i))
                            command.Parameters.AddWithValue("@dt", DateTime.Now)
                            command.Parameters.AddWithValue("@user", Login.logged)
                            command.ExecuteNonQuery()
                        End Using
                    Next

                End Using

                FeedbackLbl.Text = "Successfully edited! Reverting."
                FeedbackLbl.ForeColor = Color.Green
                Await Task.Delay(3000)
                ESportsMainForm.Show()
                Close()
            End If

        ElseIf mode.Equals("Delete") Then
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim kvp As KeyValuePair(Of Integer, String) = DirectCast(TeamNamesCB.SelectedItem, KeyValuePair(Of Integer, String))
            Dim youthID As Integer = kvp.Key
            Dim playerName As String = kvp.Value
            Dim sql1 As String = "DELETE FROM [Players] WHERE [YouthID] = @pname;"
            Dim sql2 As String = "DELETE FROM [Records] WHERE [PlayerName] = @pname;"
            Dim sql3 As String = "UPDATE [Teams] SET [NumberofPlayers] = [NumberofPlayers] - 1 WHERE [TeamName] = @tname;"

            'Security
            Dim tp As String = ""
            Dim t As New List(Of String)
            Dim name As String = ""
            Dim sqlsf1 As String = "SELECT [PlayerId], [PlayerName], [YouthID], [Position], [TeamName] FROM Players WHERE [YouthID] = @id"
            Dim sqlsf2 As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists], [GameId] FROM Records WHERE [PlayerName] = @pn"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command As New SQLiteCommand(sqlsf1, connection)
                    command.Parameters.AddWithValue("@id", youthID)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            tp = "PlayerId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Position: " & reader.GetString(3) & " | TeamName: " & reader.GetString(4)
                            name = reader.GetString(1)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsf2, connection)
                    command.Parameters.AddWithValue("@pn", name)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            t.Add("RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId" & reader.GetInt32(6))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@pname", youthID)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@pname", name)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql3, connection)
                    command.Parameters.AddWithValue("@tname", DataGridView1.SelectedRows(0).Cells(3).Value)
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
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", tp)
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using

                For i = 0 To t.Count - 1
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + i + 2)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Records")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", t(i))
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next

            End Using

            MessageBox.Show("Deleted player '" & playerName & "' Successfully!")
            FeedbackLbl.Text = "Reverting."
            FeedbackLbl.ForeColor = Color.Green
            Await Task.Delay(3000)
            ESportsMainForm.Show()
            Close()
        End If
    End Sub
End Class