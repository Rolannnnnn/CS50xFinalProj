Imports System.Data.Entity.Migrations
Imports System.Data.SQLite

Public Class VolleyballEditPlayers
    Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
    Private Sub VolleyballEditPlayers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT YouthID FROM Players WHERE [PlayerID] > 0;"

        PlayerNameCB.Items.Clear()
        Try
            Using connectionSports As New SQLiteConnection(connectionString)
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
                                        PlayerNameCB.Items.Add(New KeyValuePair(Of Integer, String)(playerId, playerName))
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

        Dim sqlTeam As String = "SELECT TeamName FROM Team WHERE [TeamID] > 0;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sqlTeam, connection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read
                        Dim teamnames As String = reader.GetString(0)
                        TeamCB.Items.Add(teamnames)
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click

        Dim tb() As TextBox = {HeightTB, JNumTB, WeightTB}
        Dim cb() As ComboBox = {DivisionCB, Position1CB, TeamCB, PlayerNameCB}
        Dim num() As TextBox = {HeightTB, JNumTB, WeightTB}

        If Not StringStorage.CheckString(tb, cb, 99).Equals("") Then
            FeedbackLbl.Text = "Some fields are empty or too long."
            FeedbackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        ElseIf Not StringStorage.IsDecimal(num) Then
            FeedbackLbl.Text = "Some numerical fields are in incorrect format"
            FeedbackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        Else
            Dim selectedPlayer As KeyValuePair(Of Integer, String) = DirectCast(PlayerNameCB.SelectedItem, KeyValuePair(Of Integer, String))
            Dim selectedPlayerId As Integer = selectedPlayer.Key
            Dim newJerseyNum As String = JNumTB.Text
            Dim newPos As String = Position1CB.Text
            Dim newDiv As String = DivisionCB.Text
            Dim newHeight As Double = Double.Parse(HeightTB.Text)
            Dim newWeight As Double = Double.Parse(WeightTB.Text)
            Dim newTeam As String = TeamCB.Text
            Dim Sql As String = "UPDATE [Players] SET [JerseyNum] = @newJersey, Position = @newPos, TeamName = @tName, Division = @newDiv, Height = @newHeight, Weight = @newWeight WHERE [YouthID] = @selectedPlayerId;"

            'Security
            Dim fp As String = ""
            Dim tp As String = ""
            Dim sqlsp As String = "SELECT [PlayerID], [Name], [YouthID], [JerseyNum], [Position], [TeamName], [Division], [Height], [Weight] FROM [Players] WHERE [YouthID] = @yid"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command As New SQLiteCommand(sqlsp, connection)
                    command.Parameters.AddWithValue("@yid", selectedPlayerId)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            fp = "PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8)
                        End If
                    End Using
                End Using

                Using cmd As New SQLiteCommand(Sql, connection)
                    cmd.Parameters.AddWithValue("@newJersey", newJerseyNum)
                    cmd.Parameters.AddWithValue("@newPos", newPos)
                    cmd.Parameters.AddWithValue("@newDiv", newDiv)
                    cmd.Parameters.AddWithValue("@newHeight", newHeight)
                    cmd.Parameters.AddWithValue("@newWeight", newWeight)
                    cmd.Parameters.AddWithValue("@tName", newTeam)
                    cmd.Parameters.AddWithValue("@selectedPlayerId", selectedPlayerId)

                    Try
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If PlayerNameCB.Text = "" Or JNumTB.Text = "" Or Position1CB.Text = "" Or DivisionCB.Text = "" Or HeightTB.Text = "" Or WeightTB.Text = "" Or TeamCB.Text = "" Then
                            MessageBox.Show("Some fields are empty.")
                        ElseIf rowsAffected > 0 Then
                            MessageBox.Show("Changes saved successfully!")
                            DivisionCB.Text = Nothing
                            PlayerNameCB.Text = Nothing
                            Position1CB.Text = Nothing
                            JNumTB.Text = ""
                            TeamCB.Text = Nothing
                            DivisionCB.Text = ""
                            HeightTB.Text = ""
                            WeightTB.Text = ""
                            DivisionCB.Text = ""
                        Else
                            MessageBox.Show("No changes were made.")

                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using

                Using command As New SQLiteCommand(sqlsp, connection)
                    command.Parameters.AddWithValue("@yid", selectedPlayerId)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            tp = "PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8)
                        End If
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
                    command.Parameters.AddWithValue("@db", "SportsVolleyball")
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", fp)
                    command.Parameters.AddWithValue("@t", tp)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub

    Private Sub PlayerNameCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlayerNameCB.SelectedIndexChanged
        If PlayerNameCB.SelectedItem IsNot Nothing Then
            Dim selectedPlayer As KeyValuePair(Of Integer, String) = DirectCast(PlayerNameCB.SelectedItem, KeyValuePair(Of Integer, String))
            Dim selectedPlayerId As Integer = selectedPlayer.Key

            Dim sql As String = "SELECT JerseyNum, Position, Division, Height, Weight, TeamName FROM [Players] WHERE [YouthID] = @youthID;"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using cmd As New SQLiteCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@youthID", selectedPlayerId)

                    Try
                        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                        If reader.Read() Then
                            If Not reader.IsDBNull(0) Then
                                JNumTB.Text = reader.GetInt32(0).ToString()
                            End If
                            If Not reader.IsDBNull(1) Then
                                Position1CB.Text = reader.GetString(1)
                            End If
                            If Not reader.IsDBNull(2) Then
                                DivisionCB.Text = reader.GetString(2)
                            End If
                            If Not reader.IsDBNull(3) Then
                                HeightTB.Text = reader.GetFloat(3).ToString()
                            End If
                            If Not reader.IsDBNull(4) Then
                                WeightTB.Text = reader.GetFloat(4).ToString()
                            End If
                            If Not reader.IsDBNull(5) Then
                                TeamCB.Text = reader.GetString(5)
                            End If
                        Else
                            JNumTB.Text = ""
                            Position1CB.Text = ""
                            DivisionCB.Text = ""
                            HeightTB.Text = ""
                            WeightTB.Text = ""
                            TeamCB.Text = ""
                        End If
                        reader.Close()
                    Catch ex As Exception
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        End If

    End Sub
End Class