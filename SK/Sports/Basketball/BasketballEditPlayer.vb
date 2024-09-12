Imports System.Data.SQLite

Public Class BasketballEditPlayer
    Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)


    Private Sub letterChecker(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub numChecker(sender As Object, e As KeyPressEventArgs) Handles JerseyNumberTB.KeyPress, HeightTB.KeyPress, WeightTB.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BasketballEditPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT YouthID FROM Members WHERE [MemberId] > 0;"

        SelectPlayerCB.Items.Clear()
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
                                        SelectPlayerCB.Items.Add(New KeyValuePair(Of Integer, String)(playerId, playerName))
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

        Dim populateteam As String = "SELECT [Team Name] FROM Teams WHERE [ID] > 0"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(populateteam, connection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader
                    While reader.Read()
                        Dim teamname As String = reader.GetString(0)
                        TeamCB.Items.Add(teamname)
                    End While

                End Using
            End Using
        End Using
    End Sub

    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If SelectPlayerCB.SelectedItem IsNot Nothing Then
            Dim selectedPlayer As KeyValuePair(Of Integer, String) = DirectCast(SelectPlayerCB.SelectedItem, KeyValuePair(Of Integer, String))
            Dim selectedPlayerId As Integer = selectedPlayer.Key

            Dim newJerseyNum As String = JerseyNumberTB.Text
            Dim newPos As String = PositionCB.Text
            Dim newDiv As String = DivisionCB.Text
            Dim newHeight As Integer = Convert.ToInt32(HeightTB.Text)
            Dim newWeight As Double = Convert.ToDouble(WeightTB.Text)
            Dim newTeam As String = TeamCB.Text

            Dim sqlUpdate As String = "UPDATE [Members] SET [Team Name] = @newteam, [Jersey Number] = @newJersey, Position = @newPos, Division = @newDiv, Height = @newHeight, Weight = @newWeight WHERE [YouthID] = @selectedPlayerId;"

            'Security
            Dim fp As String = ""
            Dim tp As String = ""
            Dim sqlsf1 As String = "SELECT [MemberId], [Player Name], [YouthID], [Team Name], [Jersey Number], [Position], [Division], [Height], [Weight] FROM [Members] WHERE [YouthID] = @yid"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Using command As New SQLiteCommand(sqlsf1, connection)
                    command.Parameters.AddWithValue("@yid", selectedPlayerId)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            fp = "MemberId: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Team Name: " & reader.GetString(3) & " | Jersey Number: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetInt32(7) & " | Weight: " & reader.GetFloat(8)
                        End If
                    End Using
                End Using

                Using cmdUpdate As New SQLiteCommand(sqlUpdate, connection)
                    cmdUpdate.Parameters.AddWithValue("@newJersey", newJerseyNum)
                    cmdUpdate.Parameters.AddWithValue("@newPos", newPos)
                    cmdUpdate.Parameters.AddWithValue("@newDiv", newDiv)
                    cmdUpdate.Parameters.AddWithValue("@newHeight", newHeight)
                    cmdUpdate.Parameters.AddWithValue("@newWeight", newWeight)
                    cmdUpdate.Parameters.AddWithValue("@newteam", newTeam)
                    cmdUpdate.Parameters.AddWithValue("@selectedPlayerId", selectedPlayerId)

                    Try
                        Dim rowsAffected As Integer = cmdUpdate.ExecuteNonQuery()

                        If JerseyNumberTB.Text = "" Or PositionCB.Text = "" Or DivisionCB.Text = "" Or HeightTB.Text = "" Or WeightTB.Text = "" Or TeamCB.Text = "" Then
                            MessageBox.Show("Some fields are empty.")
                        ElseIf rowsAffected > 0 Then
                            MessageBox.Show("Changes saved successfully!")
                            JerseyNumberTB.Text = Nothing
                            PositionCB.Text = Nothing
                            DivisionCB.Text = Nothing
                            HeightTB.Text = Nothing
                            WeightTB.Text = Nothing
                            TeamCB.Text = Nothing
                        Else
                            MessageBox.Show("No changes were made.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show($"Error updating player: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using

                Using command As New SQLiteCommand(sqlsf1, connection)
                    command.Parameters.AddWithValue("@yid", selectedPlayerId)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            tp = "MemberId: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Team Name: " & reader.GetString(3) & " | Jersey Number: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetInt32(7) & " | Weight: " & reader.GetFloat(8)
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", fp)
                    command.Parameters.AddWithValue("@t", tp)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Else
            MessageBox.Show("Please select a player.")
        End If
    End Sub


    Private Sub SelectPlayerCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectPlayerCB.SelectedIndexChanged
        If SelectPlayerCB.SelectedItem IsNot Nothing Then
            Dim selectedPlayer As KeyValuePair(Of Integer, String) = DirectCast(SelectPlayerCB.SelectedItem, KeyValuePair(Of Integer, String))
            Dim selectedPlayerId As Integer = selectedPlayer.Key

            Dim sql As String = "SELECT [Jersey Number], Position, Division, Height, Weight, [Team Name] FROM [Members] WHERE [YouthID] = @youthID;"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Using cmd As New SQLiteCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@youthID", selectedPlayerId)

                    Try
                        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                        If reader.Read() Then
                            JerseyNumberTB.Text = reader.GetInt32(0).ToString()
                            PositionCB.Text = reader.GetString(1)
                            DivisionCB.Text = reader.GetString(2)
                            HeightTB.Text = reader.GetInt32(3).ToString()
                            WeightTB.Text = reader.GetFloat(4).ToString()
                            TeamCB.Text = reader.GetString(5)
                        Else
                            JerseyNumberTB.Text = ""
                            PositionCB.Text = ""
                            DivisionCB.Text = ""
                            HeightTB.Text = ""
                            WeightTB.Text = ""
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