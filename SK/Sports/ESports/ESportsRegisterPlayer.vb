
Imports System.Data.SQLite
Imports Guna.UI2.WinForms.Suite

Public Class ESportsRegisterPlayer
    Dim con As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
    Private Sub ESportsRegisterPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Puts team name on Team ComboBox
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim sql As String = "SELECT [TeamName] FROM [Teams] WHERE [TeamId] > 0;"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read
                        TeamNameCB.Items.Add(reader.GetString(0))
                    End While
                End Using
            End Using
        End Using

        Dim sqlKk As String = "SELECT Name, Address From Youth WHERE [YouthID] > 0;"
        Dim playerNames As New List(Of String)
        Using connection As New SQLiteConnection(conkk)
            connection.Open()
            Using cmd As New SQLiteCommand(sqlKk, connection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read
                        Dim name As String = reader.GetString(0)
                        Dim address As String = reader.GetString(1)
                        Dim display As String = $"{name} - {address}"
                        PlayerCBox.Items.Add(display)
                        playerNames.Add(name)
                    End While
                End Using
            End Using
            PlayerCBox.Tag = playerNames
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim displayName As String = PlayerCBox.Text
        Dim playerName As String = ""
        Dim playerNames As List(Of String) = CType(PlayerCBox.Tag, List(Of String))
        For Each item As String In PlayerCBox.Items
            If item = displayName Then
                playerName = playerNames(PlayerCBox.Items.IndexOf(item))
                Exit For
            End If
        Next
        Dim TeamName As String = TeamNameCB.Text
        Dim Position As String = PositionCB.Text
        Dim valid As Boolean = True

        'Checks team name
        If Not (StringStorage.CheckString(TeamName, 50).Equals("")) Then
            valid = False
            FeedbackTeamLbl.Text = StringStorage.CheckString(TeamName, 50)
            StringStorage.ShowLabelsForThreeSeconds(FeedbackTeamLbl)
        End If

        'Checks player name
        If Not (StringStorage.CheckString(playerName, 50).Equals("")) Then
            valid = False
            FeedbackPlayerLbl.Text = StringStorage.CheckString(playerName, 50)
            StringStorage.ShowLabelsForThreeSeconds(FeedbackPlayerLbl)
        End If

        'Checks position
        If Not (StringStorage.CheckString(Position, 50).Equals("")) Then
            valid = False
            FeedbackPositionLbl.Text = StringStorage.CheckString(Position, 50)
            StringStorage.ShowLabelsForThreeSeconds(FeedbackPositionLbl)
        End If

        If (valid) Then
            Dim youthID As Object = Nothing
            Dim sqlCheck As String = "SELECT [YouthID] FROM [Youth] WHERE [Name] = @pname;"
            Using connection As New SQLiteConnection(conkk)
                connection.Open()
                Using cmd As New SQLiteCommand(sqlCheck, connection)
                    cmd.Parameters.AddWithValue("@pname", playerName)
                    youthID = cmd.ExecuteScalar()
                End Using
            End Using

            If youthID IsNot Nothing Then
                'If valid, enter it
                Dim maxid As Integer
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
                Dim sqlGetMaxId As String = "SELECT COALESCE(MAX(PlayerId), 0) FROM [Players];"
                Dim sql2 As String = "INSERT INTO [Players] (PlayerID, YouthID, Position, TeamName, PlayerName) VALUES (@id, @youthid, @pos, @tname, @pname);"
                Dim sql3 As String = "UPDATE [Teams] SET [NumberofPlayers] = [NumberofPlayers] + 1 WHERE [TeamName] = @tname;"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    'Fetches the latest id
                    Using command As New SQLiteCommand(sqlGetMaxId, connection)
                        maxid = Convert.ToInt32(command.ExecuteScalar())
                    End Using

                    'Inserts new team
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxid + 1)
                        command.Parameters.AddWithValue("@youthid", youthID)
                        command.Parameters.AddWithValue("@pos", Position)
                        command.Parameters.AddWithValue("@tname", TeamName)
                        command.Parameters.AddWithValue("@pname", playerName)
                        command.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sql3, connection)
                        command.Parameters.AddWithValue("@tname", TeamName)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Security
                Dim sql6 As String = "SELECT [TeamId], [NumberofPlayers] FROM Teams WHERE [TeamName] = @tname"
                Dim f As String = ""
                Dim t As String = ""
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SportsEsportsDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql6, connection)
                        command.Parameters.AddWithValue("@tname", TeamName)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                f = "ID: " & reader.GetInt64(0).ToString & " | TeamName: " & TeamName & " | NumberofPlayers: " & reader.GetInt64(1).ToString
                                t = "ID: " & reader.GetInt64(0).ToString & " | TeamName: " & TeamName & " | NumberofPlayers: " & (reader.GetInt64(1) + 1).ToString
                            End If
                        End Using
                    End Using
                End Using

                Dim sql4 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql5 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t2 As String = "ID: " & maxid + 1 & " | PlayerName: " & playerName & " | YouthID: " & youthID & " | Position: " & Position & " | TeamName: " & TeamName
                    Using command As New SQLiteCommand(sql4, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql5, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Players")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t2)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                    Using command As New SQLiteCommand(sql5, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 2)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Teams")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", f)
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Gives feedback
                FeedbackLbl.Text = "The Player is successfully registered!"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
                TeamNameCB.Text = Nothing
                PositionCB.Text = Nothing
                PlayerCBox.Text = Nothing
            End If
        End If
    End Sub

    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        ESportsMainForm.Show()
        Close()
    End Sub
End Class