Imports System.Data.SQLite
Imports iText.StyledXmlParser.Jsoup.Select.Evaluator

Public Class VolleyballDeletePlayer
    Dim repeated As Boolean = False

    Private Sub VolleyballDeletePlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Name FROM Players WHERE [PlayerID] > 0;"
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                While reader.Read
                    PlayerCBox.Items.Add(reader.GetString(0))
                End While
            End Using
        End Using
    End Sub

    Private Sub PlayerDeleteBtn_Click(sender As Object, e As EventArgs) Handles PlayerDeleteBtn.Click
        Dim valid As Boolean = True

        If Not repeated Then
            repeated = True
            FeedbackLbl.Text = "The records of this player will also be deleted! Press the delete button again to confirm."
            FeedbackLbl.Visible = True
        ElseIf Not StringStorage.CheckString(PlayerCBox.Text, 99).Equals("") Then
            valid = False
            FeedbackLbl.Text = "Cannot be empty or too long."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        ElseIf valid And repeated Then
            Dim sql1 As String = "DELETE FROM [Players] WHERE [Name] = @pname;"
            Dim sql2 As String = "DELETE FROM [Records] WHERE [PlayerName] = @pname"
            Dim selectedPlayer As String = PlayerCBox.SelectedItem.ToString()
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)

            'Security
            Dim fp As String = ""
            Dim fr As New List(Of String)
            Dim sqlsp As String = "SELECT [PlayerID], [Name], [YouthID], [JerseyNum], [Position], [TeamName], [Division], [Height], [Weight] FROM [Players] WHERE [Name] = @pname"
            Dim sqlsr As String = "SELECT [RecordID], [PlayerName], [Position], [Points], [Blocks], [Digs], [GameID] FROM [Records] WHERE [PlayerName] = @pname"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@pname", selectedPlayer)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        While reader.Read
                            fr.Add("RecordID: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Points: " & reader.GetInt32(3) & " | Blocks: " & reader.GetInt32(4) & " | Digs: " & reader.GetInt32(5) & " | GameID: " & reader.GetInt32(6))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsp, connection)
                    command.Parameters.AddWithValue("@pname", selectedPlayer)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            fp = "PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8)
                        End If
                    End Using
                End Using

                Using cmd As New SQLiteCommand(sql1, connection)
                    cmd.Parameters.AddWithValue("@pname", selectedPlayer)
                    cmd.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@pname", selectedPlayer)
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
                    command.Parameters.AddWithValue("@db", "SportsVolleyball")
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", fp)
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using

                For i = 0 To fr.Count - 1
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 2 + i)
                        command.Parameters.AddWithValue("@db", "SportsVolleyball")
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

            MessageBox.Show("Successfully Deleted!")
            VolleyballMainForm.Show()
            Close()
        End If
    End Sub
End Class