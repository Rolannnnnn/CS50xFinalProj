Imports System.Data.SQLite

Public Class BasketballRegisterTeam
    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        BasketballMainForm.Show()
        Close()
    End Sub

    Private Sub RegisterTeamBtn_Click(sender As Object, e As EventArgs) Handles RegisterTeamBtn.Click

        Dim teamName As String = TeamNameTBox.Text.Trim()
        Dim coachName As String = TeamCoachTBox.Text.Trim()
        Dim divisionCBox As String = DivisionCB.SelectedItem

        If teamName = "" Or coachName = "" Or DivisionCB.SelectedItem Is Nothing Then
            ErrorLbl.Text = "Please fill in all fields!"
            ErrorLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(ErrorLbl)
            Return
        End If

        Dim con As String = "DataSource=SportsBasketballDatabase.db;Version=3;"
        Dim sql = "SELECT [Team Name] FROM [Teams] WHERE [Team name] = @tname;"
        Dim exists As Boolean = False

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                cmd.Parameters.AddWithValue("@tname", teamName)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    exists = True
                End If
            End Using
        End Using

        If exists Then
            ErrorLbl.Text = "Team Name or Team Coach salready exists!"
            ErrorLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(ErrorLbl)
        Else
            Dim idCount As Integer
            Dim sql1 As String = "SELECT MAX(ID) FROM Teams;"
            Dim sql2 As String = "INSERT INTO Teams ([ID], [Team Name], [Team Coach], [Division]) VALUES (@id, @teamname, @coachname, @division);"
            Using connection As New SQLiteConnection(con)
                connection.Open()
                Using commandd As New SQLiteCommand(sql1, connection)
                    idCount = Integer.Parse(commandd.ExecuteScalar)
                End Using

                Using cmd As New SQLiteCommand(sql2, connection)
                    cmd.Parameters.AddWithValue("@id", idCount + 1)
                    cmd.Parameters.AddWithValue("@teamname", teamName)
                    cmd.Parameters.AddWithValue("@coachname", coachName)
                    cmd.Parameters.AddWithValue("@division", DivisionCB.SelectedItem)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            'Security
            Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer
            Dim t As String = "ID: " & idCount + 1 & " | Team Name: " & teamName & " | Team Coach: " & coachName & " | Division: " & DivisionCB.SelectedItem

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using

                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
                    command.Parameters.AddWithValue("@table", "Teams")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            ErrorLbl.Text = "Team is Successfully Created!"
            ErrorLbl.ForeColor = Color.Green
            StringStorage.ShowLabelsForThreeSeconds(ErrorLbl)
            Dim clearcb() As ComboBox = {DivisionCB}
            StringStorage.ClearFields(clearcb)

        End If
    End Sub
End Class