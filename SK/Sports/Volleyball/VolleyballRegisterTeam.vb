Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class VolleyballRegisterTeam
    Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Private Sub VolleyballRegisterTeam_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayData()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim unique As Boolean = True

        Dim sql1 As String = "SELECT [TeamName] FROM [Team] WHERE [TeamName] = @tname"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@tname", txtTeamName.Text)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read Then
                        unique = False
                    End If
                End Using
            End Using
        End Using

        If Not unique Then
            MessageBox.Show("Team Name already exists!")
        ElseIf Not CheckString(txtTeamName.Text, 99).Equals("") OrElse Not CheckString(txtCoach.Text, 99).Equals("") OrElse Not CheckString(cmbDivision.Text, 99).Equals("") Then
            MessageBox.Show("Some fields are empty or too long.")
        Else
            Dim sqlid As String = "SELECT MAX(TeamID) FROM [Team]"
            Dim sql As String = "INSERT INTO Team (TeamID, TeamName, Division, Coach) VALUES (@id, @TeamName, @Division, @Coach)"
            Dim idCount As Integer
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using commandd As New SQLiteCommand(sqlid, connection)
                    idCount = Integer.Parse(commandd.ExecuteScalar)
                End Using

                Using cmd As New SQLiteCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@id", idCount + 1)
                    cmd.Parameters.AddWithValue("@TeamName", txtTeamName.Text)
                    cmd.Parameters.AddWithValue("@Division", cmbDivision.Text)
                    cmd.Parameters.AddWithValue("@Coach", txtCoach.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            'Security
            Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer
            Dim t As String = "ID: " & idCount + 1 & " | TeamName: " & txtTeamName.Text & " | Division: " & cmbDivision.Text & " | Team Coach: " & txtCoach.Text

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()

                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using

                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsVolleyball")
                    command.Parameters.AddWithValue("@table", "Teams")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Record inserted")
            DisplayData()
        End If
        txtCoach.Clear()
        txtTeamName.Clear()
        cmbDivision.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        VollerballAddplayers.Show()
        Me.Hide()
    End Sub

    Public Sub DisplayData()

        Dim sql As String = "SELECT * FROM [Team] WHERE [TeamID] > 0;"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Using adapter As New SQLiteDataAdapter(cmd)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    GridTeam.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub

End Class