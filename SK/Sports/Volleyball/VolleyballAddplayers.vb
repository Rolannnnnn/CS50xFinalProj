Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class VollerballAddplayers
    Dim con As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)


    Private Sub numberChecker(sender As Object, e As KeyPressEventArgs) Handles txtHeight.KeyPress, txtJerseyNumber.KeyPress, txtWeight.KeyPress
        Dim textBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub VolleyballAddPlayers_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlkk As String = "SELECT [Name], [Address] From [Youth] WHERE [YouthID] > 0;"
        Dim playerNames As New List(Of String)

        Using connection As New SQLiteConnection(conkk)
            connection.Open()
            Using cmd As New SQLiteCommand(sqlkk, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                While reader.Read
                    Dim name As String = reader.GetString(0)
                    Dim address As String = reader.GetString(1)
                    Dim display As String = $"{name} - {address}"
                    PlayerNameCB.Items.Add(display)
                    playerNames.Add(name)
                End While
            End Using
        End Using
        PlayerNameCB.Tag = playerNames
        DisplayData()

        Dim sqlteams As String = "SELECT TeamName FROM Team WHERE [TeamID] > 0;"
        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sqlteams, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cmbTeam.Items.Add(reader.GetString(0))
                End While
            End Using
        End Using

    End Sub


    Private Async Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim con As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
        Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim displayName As String = PlayerNameCB.Text
        Dim playerName As String = ""
        Dim playerNames As List(Of String) = CType(PlayerNameCB.Tag, List(Of String))
        For Each item As String In PlayerNameCB.Items
            If item = displayName Then
                playerName = playerNames(PlayerNameCB.Items.IndexOf(item))
                Exit For
            End If
        Next
        Dim playerJersey As String = txtJerseyNumber.Text
        Dim playerPosition As String = cmbPosition.SelectedItem
        Dim playerDivision As String = cmbDivison.SelectedItem
        Dim playerHeight As String = txtHeight.Text
        Dim playerWeight As String = txtWeight.Text
        Dim playerTeam As String = cmbTeam.SelectedItem

        If playerName = "" Or playerJersey = "" Or playerPosition = "" Or playerDivision = "" Or playerHeight = "" Or playerWeight = "" Or playerTeam = "" Then
            FeedBackLbl.Text = "Please fill in all fields!"
            FeedBackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedBackLbl)
            Return
        End If

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
            Dim memberId As Integer
            Dim sqlGetMaxId As String = "SELECT COALESCE(MAX(PlayerID), 0) FROM [Players];"
            Dim sqlInsert As String = "INSERT INTO [Players] ([PlayerID], [Name], [YouthID], [TeamName], [JerseyNum], [Position], [Division], [Height], [Weight]) VALUES (@playerid, @pname, @youthid, @teamname, @jerseyno, @position, @division, @height, @weight);"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Using cmd As New SQLiteCommand(sqlGetMaxId, connection)
                    memberId = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                End Using


                Using cmd As New SQLiteCommand(sqlInsert, connection)
                    cmd.Parameters.AddWithValue("@playerid", memberId)
                    cmd.Parameters.AddWithValue("@pname", playerName)
                    cmd.Parameters.AddWithValue("@youthid", youthID)
                    cmd.Parameters.AddWithValue("@teamname", playerTeam)
                    cmd.Parameters.AddWithValue("@jerseyno", playerJersey)
                    cmd.Parameters.AddWithValue("@position", playerPosition)
                    cmd.Parameters.AddWithValue("@division", playerDivision)
                    cmd.Parameters.AddWithValue("@height", playerHeight)
                    cmd.Parameters.AddWithValue("@weight", playerWeight)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            'Security
            Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer
            Dim t As String = "PlayerId: " & memberId & " | Name: " & playerName & " | YouthID: " & youthID & " | JerseyNum: " & playerJersey & " | Position: " & playerPosition & " | TeamName: " & playerTeam & " | Division: " & playerDivision & " | Height: " & playerHeight & " | Weight: " & playerWeight
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsVolleyball")
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            FeedBackLbl.Text = "Player registered successfully!"
            FeedBackLbl.ForeColor = Color.Green
            StringStorage.ShowLabelsForThreeSeconds(FeedBackLbl)
            txtHeight.Text = Nothing
            txtWeight.Text = Nothing
            txtJerseyNumber.Text = Nothing
            cmbDivison.Text = Nothing
            cmbPosition.Text = Nothing
            cmbTeam.Text = Nothing
            Await Task.Delay(3000)
            DisplayData()

        Else
            FeedBackLbl.Text = "Player name not found in profiling database!"
            FeedBackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedBackLbl)
        End If
    End Sub

    Public Sub DisplayData()
        Using connection As New SQLiteConnection(con)
            connection.Open()
            Dim sql As String = "SELECT * FROM [Players] WHERE [PlayerID] > 0;"
            Using command As New SQLiteCommand(sql, connection)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.fill(dt)
                    Grid1.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        VolleyballMainForm.Show()
        Me.Close()

    End Sub




End Class