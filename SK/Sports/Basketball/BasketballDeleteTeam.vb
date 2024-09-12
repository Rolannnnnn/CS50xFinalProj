Imports System.Data.SQLite

Public Class BasketballDeleteTeam


    Private Sub BasketballDeleteTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql As String = "SELECT [Team Name] FROM [Teams] WHERE [ID] > 0;"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                While reader.Read
                    TeamCBox.Items.Add(reader.GetString(0))
                End While
            End Using
        End Using
    End Sub

    Private Sub DeleteTeamBtn_Click(sender As Object, e As EventArgs) Handles DeleteTeamBtn.Click
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql1 As String = "DELETE FROM [Teams] WHERE [Team Name] = @tname;"
        Dim sql2 As String = "DELETE FROM [Members] WHERE [Team Name] = @tname;"
        Dim sql3 As String = "SELECT [GameID] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname OR [TeamWon] = @tname;"
        Dim sql5 As String = "DELETE FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname OR [TeamWon] = @tname;"
        Dim selectedTeam As String = TeamCBox.SelectedItem.ToString()

        'Security
        Dim ft As String = ""
        Dim sqlst As String = "SELECT [ID], [Team Name], [Team Coach], [Division] FROM [Teams] WHERE [Team Name] = @tname"
        Dim fp As New List(Of String)
        Dim sqlsp As String = "SELECT [MemberId], [Player Name], [YouthID], [Team Name], [Jersey Number], [Position], [Division], [Height], [Weight] FROM [Members] WHERE [Team Name] = @tname"
        Dim fg As New List(Of String)
        Dim sqlsg As String = "SELECT [GameID], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"
        Dim fr As New List(Of String)
        Dim sqlsr As String = "SELECT [RecordID], [Player Name], [Points], [Assists], [Rebounds], [Position], [GameID] FROM [Records] WHERE [GameID] = @id"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Dim gamesID As New List(Of Integer)()

            Using cmd As New SQLiteCommand(sql3, connection)
                cmd.Parameters.AddWithValue("@tname", selectedTeam)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id As Integer = Convert.ToInt32(reader("GameID"))
                        gamesID.Add(id)
                    End While
                End Using
            End Using

            For Each id In gamesID
                Dim sql4 As String = "DELETE FROM [Records] WHERE [GameID] = @id;"

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        While reader.Read
                            fr.Add("RecordID: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | Points: " & reader.GetInt32(2) & " | Assists: " & reader.GetInt32(3) & " | Rebounds: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | GameID: " & reader.GetInt32(6))
                        End While
                    End Using
                End Using

                Using command2 As New SQLiteCommand(sql4, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    command2.ExecuteNonQuery()
                End Using
            Next

            Using command As New SQLiteCommand(sqlst, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        ft = "ID: " & reader.GetInt32(0) & " | Team Name: " & reader.GetString(1) & " | Team Coach: " & reader.GetString(2) & " | Division: " & reader.GetString(3)
                    End If
                End Using
            End Using

            Using command As New SQLiteCommand(sqlsp, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        fp.Add("MemberId: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Team Name: " & reader.GetString(3) & " | Jersey Number: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetInt32(7) & " | Weight: " & reader.GetFloat(8))
                    End While
                End Using
            End Using

            Using command As New SQLiteCommand(sqlsg, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        fg.Add("ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4))
                    End While
                End Using
            End Using

            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql2, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql5, connection)
                command.Parameters.AddWithValue("@tname", selectedTeam)
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
                command.Parameters.AddWithValue("@db", "SportsBasketball")
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
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


        MessageBox.Show($"Team successfully deleted!")
        BasketballMainForm.Show()
        Close()
    End Sub


End Class