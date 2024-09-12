Imports System.Data.SQLite
Imports Microsoft.SqlServer.Server

Public Class VolleyballEditDeleteTeam

    Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Dim mode = ""


    Private Sub VolleyballEditDeleteTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT TeamName FROM Team;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
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
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        TeamNameCB.Enabled = False
        Dim lbls() As Label = {TNameLbl, Label3, Label4}
        StringStorage.Visible(lbls, True)
        ComboBox1.Visible = True
        TextBox1.Visible = True
        ConfirmBtn.Visible = True
        NewNameTB.Visible = True
        DeleteBtn.Visible = False
        EditBtn.Visible = False
        FeedbackLbl.Text = "Write the new Information"
        FeedbackLbl.Visible = True
        mode = "Edit"
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        TeamNameCB.Enabled = False
        DeleteBtn.Visible = False
        EditBtn.Visible = False
        ConfirmBtn.Visible = True
        FeedbackLbl.Text = "All players, games and records associated with this team will also be deleted!"
        FeedbackLbl.ForeColor = Color.Red
        FeedbackLbl.Visible = True
        mode = "Delete"
    End Sub

    Private Async Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If mode = "Edit" Then
            If Not StringStorage.CheckString(NewNameTB.Text, 99).Equals("") OrElse Not StringStorage.CheckString(TextBox1.Text, 99).Equals("") OrElse Not StringStorage.CheckString(ComboBox1.Text, 99).Equals("") Then
                FeedbackLbl.Text = "New Name, Division or Coach cannot be empty or too long."
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                'Security
                Dim ft As String = ""
                Dim tt As String = ""
                Dim sqlst As String = "SELECT [TeamID], [TeamName], [Division], [Coach] FROM [Team] WHERE [TeamName] = @tname"
                Dim fp As New List(Of String)
                Dim tp As New List(Of String)
                Dim sqlsp As String = "SELECT [PlayerID], [Name], [YouthID], [JerseyNum], [Position], [TeamName], [Division], [Height], [Weight] FROM [Players] WHERE [TeamName] = @tname"
                Dim fg As New List(Of String)
                Dim tg As New List(Of String)
                Dim sqlsg As String = "SELECT [GameID], [Team1], [Team2], [Date], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"

                Dim sql1 As String = "UPDATE [Team] SET [TeamName] = @tName, [Division] = @div, [Coach] = @c WHERE [TeamName] = @NameT;"
                Dim sql3 As String = "UPDATE [Games] SET [Team1] = @tName WHERE [Team1] = @NameT;"
                Dim sql4 As String = "UPDATE [Games] SET [Team2] = @tName WHERE [Team2] = @NameT;"
                Dim sql5 As String = "UPDATE [Games] SET [TeamWon] = @tName WHERE [TeamWon] = @NameT;"
                Dim sql6 As String = "UPDATE [Players] SET [TeamName] = @tName WHERE [TeamName] = @NameT;"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()

                    Using command As New SQLiteCommand(sqlst, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                ft = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | Division: " & reader.GetString(2) & " | Coach: " & reader.GetString(3)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsp, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                fp.Add("PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsg, connection)
                        command.Parameters.AddWithValue("@tname", TeamNameCB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                fg.Add("ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4))
                            End While
                        End Using
                    End Using

                    Using cmd As New SQLiteCommand(sql1, connection)
                        cmd.Parameters.AddWithValue("@tName", NewNameTB.Text)
                        cmd.Parameters.AddWithValue("@div", ComboBox1.Text)
                        cmd.Parameters.AddWithValue("@c", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@NameT", TeamNameCB.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New SQLiteCommand(sql3, connection)
                        cmd.Parameters.AddWithValue("@tName", NewNameTB.Text)
                        cmd.Parameters.AddWithValue("@NameT", TeamNameCB.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New SQLiteCommand(sql4, connection)
                        cmd.Parameters.AddWithValue("@tName", NewNameTB.Text)
                        cmd.Parameters.AddWithValue("@NameT", TeamNameCB.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New SQLiteCommand(sql5, connection)
                        cmd.Parameters.AddWithValue("@tName", NewNameTB.Text)
                        cmd.Parameters.AddWithValue("@NameT", TeamNameCB.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New SQLiteCommand(sql6, connection)
                        cmd.Parameters.AddWithValue("@tName", NewNameTB.Text)
                        cmd.Parameters.AddWithValue("@NameT", TeamNameCB.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using command As New SQLiteCommand(sqlst, connection)
                        command.Parameters.AddWithValue("@tname", NewNameTB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            If reader.Read Then
                                tt = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | Division: " & reader.GetString(2) & " | Coach: " & reader.GetString(3)
                            End If
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsp, connection)
                        command.Parameters.AddWithValue("@tname", NewNameTB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                tp.Add("PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8))
                            End While
                        End Using
                    End Using

                    Using command As New SQLiteCommand(sqlsg, connection)
                        command.Parameters.AddWithValue("@tname", NewNameTB.Text)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                tg.Add("ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4))
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
                        command.Parameters.AddWithValue("@db", "SportsVolleyball")
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
                            command.Parameters.AddWithValue("@db", "SportsVolleyball")
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
                            command.Parameters.AddWithValue("@db", "SportsVolleyball")
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

                FeedbackLbl.Text = "Successfully edited. Reverting."
                FeedbackLbl.ForeColor = Color.Green
                FeedbackLbl.Visible = True
                Await Task.Delay(3000)
                VolleyballMainForm.Show()
                Close()
            End If

        ElseIf mode = "Delete" Then
            Dim sql1 As String = "DELETE FROM [Team] WHERE [TeamName] = @pname;"
            Dim sql3 As String = "DELETE FROM [Games] WHERE [Team1] = @pname OR [Team2] = @pname OR [TeamWon] = @pname;"
            Dim sql4 As String = "DELETE FROM [Players] WHERE [TeamName] = @pname;"
            Dim sql5 As String = "SELECT [GameID] FROM [Games] WHERE [Team1] = @pname OR [Team2] = @pname OR [TeamWon] = @pname;"

            Dim selectedTeam As String = TeamNameCB.SelectedItem.ToString()

            'Security
            Dim ft As String = ""
            Dim sqlst As String = "SELECT [TeamID], [TeamName], [Division], [Coach] FROM [Team] WHERE [TeamName] = @tname"
            Dim fp As New List(Of String)
            Dim sqlsp As String = "SELECT [PlayerID], [Name], [YouthID], [JerseyNum], [Position], [TeamName], [Division], [Height], [Weight] FROM [Players] WHERE [TeamName] = @tname"
            Dim fg As New List(Of String)
            Dim sqlsg As String = "SELECT [GameID], [Team1], [Team2], [Date], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"
            Dim fr As New List(Of String)
            Dim sqlsr As String = "SELECT [RecordID], [PlayerName], [Position], [Points], [Blocks], [Digs], [GameID] FROM [Records] WHERE [GameID] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim gameIds As New List(Of Integer)()
                Using command As New SQLiteCommand(sql5, connection)
                    command.Parameters.AddWithValue("@pname", selectedTeam)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim id As Integer = Convert.ToInt32(reader.GetInt32(0))
                            gameIds.Add(id)
                        End While
                    End Using
                End Using

                For Each id In gameIds
                    Dim sql6 As String = "DELETE FROM [Records] WHERE [GameID] = @id;"

                    Using command2 As New SQLiteCommand(sqlsr, connection)
                        command2.Parameters.AddWithValue("@id", id)
                        Using reader As SQLiteDataReader = command2.ExecuteReader
                            While reader.Read
                                fr.Add("RecordID: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Points: " & reader.GetInt32(3) & " | Blocks: " & reader.GetInt32(4) & " | Digs: " & reader.GetInt32(5) & " | GameID: " & reader.GetInt32(6))
                            End While
                        End Using
                    End Using

                    Using command2 As New SQLiteCommand(sql6, connection)
                        command2.Parameters.AddWithValue("@id", id)
                        command2.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqlst, connection)
                    command.Parameters.AddWithValue("@tname", selectedTeam)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            ft = "ID: " & reader.GetInt32(0) & " | TeamName: " & reader.GetString(1) & " | Division: " & reader.GetString(2) & " | Coach: " & reader.GetString(3)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsp, connection)
                    command.Parameters.AddWithValue("@tname", selectedTeam)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            fp.Add("PlayerID: " & reader.GetInt32(0) & " | Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | JerseyNum: " & reader.GetInt32(3) & " | Position: " & reader.GetString(4) & " | TeamName: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetFloat(7) & " | Weight: " & reader.GetFloat(8))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsg, connection)
                    command.Parameters.AddWithValue("@tname", selectedTeam)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            fg.Add("ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4))
                        End While
                    End Using
                End Using

                Using cmd As New SQLiteCommand(sql1, connection)
                    cmd.Parameters.AddWithValue("@pname", selectedTeam)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SQLiteCommand(sql3, connection)
                    cmd.Parameters.AddWithValue("@pname", selectedTeam)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SQLiteCommand(sql4, connection)
                    cmd.Parameters.AddWithValue("@pname", selectedTeam)
                    cmd.ExecuteNonQuery()
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
                        command.Parameters.AddWithValue("@db", "SportsVolleyball")
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
                        command.Parameters.AddWithValue("@db", "SportsVolleyball")
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

            FeedbackLbl.Text = "Successfully deleted. Reverting."
            FeedbackLbl.ForeColor = Color.Green
            FeedbackLbl.Visible = True
            Await Task.Delay(3000)
            VolleyballMainForm.Show()
            Close()
        End If
    End Sub
End Class