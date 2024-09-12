Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Threading

Public Class ESportsRegisterTeam
    Private Sub RegisterBttn_Click(sender As Object, e As EventArgs) Handles RegisterBttn.Click
        Dim TeamName As String = TextBox1.Text
        Dim StringCheck As String = StringStorage.CheckString(TeamName, 50)

        If Not StringCheck.Equals("") Then
            FeedbackLbl.Text = StringCheck
            FeedbackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        Else
            'Connecting / Checking if Team Name already exists
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim sql = "SELECT TeamName FROM [Teams] WHERE TeamName = @Value;"
            Dim exists As Boolean = False
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@Value", TeamName)
                    Dim tempresult As Object = command.ExecuteScalar()
                    If tempresult IsNot Nothing Then
                        exists = True
                    End If
                End Using
            End Using
            If exists Then
                FeedbackLbl.Text = "The team name already exists!"
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)

                'If the team name is available, execute
            Else
                Dim maxid As Integer
                Dim sql1 As String = "SELECT MAX(TeamId) FROM [Teams];"
                Dim sql2 As String = "INSERT INTO [Teams] (TeamId, TeamName, NumberofPlayers) VALUES (@id, @name, @nop);"
                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    'Fetches the latest id
                    Using command As New SQLiteCommand(sql1, connection)
                        maxid = Integer.Parse(command.ExecuteScalar())
                    End Using

                    'Inserts new team
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxid + 1)
                        command.Parameters.AddWithValue("@name", TeamName)
                        command.Parameters.AddWithValue("@nop", 0)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Security
                Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim maxidlog As Integer
                Dim t As String = "ID: " & maxid + 1 & " | TeamName: " & TeamName & " | NumberofPlayers: 0"

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()

                    Using command As New SQLiteCommand(sqls1, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using

                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "SportsEsports")
                        command.Parameters.AddWithValue("@table", "Teams")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                FeedbackLbl.Text = "Team is Successfully Created!"
                FeedbackLbl.ForeColor = Color.Green
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
                Dim tb() As TextBox = {TextBox1}
                StringStorage.ClearFields(tb)
            End If
        End If
    End Sub

    Private Sub BackBttn_Click(sender As Object, e As EventArgs) 
        ESportsMainForm.Show()
        Close()
    End Sub
End Class