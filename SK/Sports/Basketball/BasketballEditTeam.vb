Imports System.Data.Entity.Migrations
Imports System.Data.SQLite

Public Class BasketballEditTeam

    Private Sub BasketballEditTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql As String = "SELECT [Team Name] FROM [Teams] WHERE [ID] > 0;"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read
                    TeamCBox.Items.Add(reader.GetString(0))
                End While
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim selectedTeam As String = TeamCBox.SelectedItem
        Dim sql As String = "UPDATE [Teams] SET [Team Coach] = @teamcoach, [Division] = @division, [Team Name] = @tname WHERE [Team Name] = @selectedTeam;"
        Dim sql2 As String = "UPDATE [Members] SET [Team Name] = @ntname, Division = @div WHERE [Team Name] = @otname;"
        Dim sql3 As String = "UPDATE [Games] SET [Team1] = @ntname WHERE [Team1] = @otname;"
        Dim sql4 As String = "UPDATE [Games] SET [Team2] = @ntname WHERE [Team2] = @otname;"
        Dim sql5 As String = "UPDATE [Games] SET [TeamWon] = @ntname WHERE [TeamWon] = @otname;"

        'Security
        Dim ft As String = ""
        Dim tt As String = ""
        Dim sqlst As String = "SELECT [ID], [Team Name], [Team Coach], [Division] FROM [Teams] WHERE [Team Name] = @tname"
        Dim fp As New List(Of String)
        Dim tp As New List(Of String)
        Dim sqlsp As String = "SELECT [MemberId], [Player Name], [YouthID], [Team Name], [Jersey Number], [Position], [Division], [Height], [Weight] FROM [Members] WHERE [Team Name] = @tname"
        Dim fg As New List(Of String)
        Dim tg As New List(Of String)
        Dim sqlsg As String = "SELECT [GameID], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [Team1] = @tname OR [Team2] = @tname"
        Using connection As New SQLiteConnection(con)
            connection.Open()

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

            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@teamcoach", TeamCoachTBox.Text)
                command.Parameters.AddWithValue("@division", DivisionTBox.Text)
                command.Parameters.AddWithValue("@tname", TeamNameTB.Text)
                command.Parameters.AddWithValue("@selectedTeam", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql2, connection)
                command.Parameters.AddWithValue("@ntname", TeamNameTB.Text)
                command.Parameters.AddWithValue("@div", DivisionTBox.Text)
                command.Parameters.AddWithValue("@otname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql3, connection)
                command.Parameters.AddWithValue("@ntname", TeamNameTB.Text)
                command.Parameters.AddWithValue("@otname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql4, connection)
                command.Parameters.AddWithValue("@ntname", TeamNameTB.Text)
                command.Parameters.AddWithValue("@otname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql5, connection)
                command.Parameters.AddWithValue("@ntname", TeamNameTB.Text)
                command.Parameters.AddWithValue("@otname", selectedTeam)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sqlst, connection)
                command.Parameters.AddWithValue("@tname", TeamNameTB.Text)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        tt = "ID: " & reader.GetInt32(0) & " | Team Name: " & reader.GetString(1) & " | Team Coach: " & reader.GetString(2) & " | Division: " & reader.GetString(3)
                    End If
                End Using
            End Using

            Using command As New SQLiteCommand(sqlsp, connection)
                command.Parameters.AddWithValue("@tname", TeamNameTB.Text)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        tp.Add("MemberId: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Team Name: " & reader.GetString(3) & " | Jersey Number: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetInt32(7) & " | Weight: " & reader.GetFloat(8))
                    End While
                End Using
            End Using

            Using command As New SQLiteCommand(sqlsg, connection)
                command.Parameters.AddWithValue("@tname", TeamNameTB.Text)
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
                command.Parameters.AddWithValue("@db", "SportsBasketball")
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
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
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
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

        MessageBox.Show("Team successfully edited team!")
        BasketballMainForm.Show()
        Close()
    End Sub

    Private Sub TeamCBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamCBox.SelectedIndexChanged
        Dim selectedTeamName As String = TeamCBox.SelectedItem.ToString()
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)

        Using connection As New SQLiteConnection(con)
            Dim sql As String = "SELECT [Team Name], [Team Coach], [Division] FROM [Teams] WHERE [Team Name] = @tname;"

            Try
                connection.Open()
                Dim cmd As New SQLiteCommand(sql, connection)
                cmd.Parameters.AddWithValue("@tname", selectedTeamName)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    TeamCoachTBox.Text = reader("Team Coach").ToString()
                    DivisionTBox.Text = reader("Division").ToString()
                    TeamNameTB.Text = reader("Team Name").ToString()
                End If
                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error:" & ex.Message)
            End Try

        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.Visible = False
        TeamCBox.Visible = False
        Button2.Visible = False
        Dim lbl() As Label = {Label3, Label4, Label5}
        Dim tb() As TextBox = {TeamCoachTBox, TeamNameTB}

        DivisionTBox.Visible = True
        StringStorage.Visible(lbl, True)
        StringStorage.Visible(tb, True)
        Button1.Visible = True

    End Sub
End Class