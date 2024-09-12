Imports System.Data.SQLite

Public Class BasketballAddPlayers
    Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)


    Private Sub BasketballAddPlayers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlkk As String = "SELECT [Name], [Address] From [Youth] WHERE [YouthID] > 0;"
        Dim playerNames As New List(Of String)

        Using connection As New SQLiteConnection(conkk)
            connection.Open()
            Using cmd As New SQLiteCommand(sqlkk, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                Dim skip As Boolean = False
                While reader.Read
                    If Not skip Then
                        skip = True
                    Else
                        Dim name As String = reader.GetString(0)
                        Dim address As String = reader.GetString(1)
                        Dim display As String = $"{name} - {address}"
                        PlayerNameCBox.Items.Add(display)
                        playerNames.Add(name)
                    End If
                End While
            End Using
        End Using
        PlayerNameCBox.Tag = playerNames

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



    Private Sub numberChecker(sender As Object, e As KeyPressEventArgs) Handles JerseyNumberTBox.KeyPress, HeightTBox.KeyPress, WeightTBox.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RegisterPlayerBtn_Click(sender As Object, e As EventArgs) Handles RegisterPlayerBtn.Click
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim displayName As String = PlayerNameCBox.Text
        Dim playerName As String = ""
        Dim playerNames As List(Of String) = CType(PlayerNameCBox.Tag, List(Of String))
        For Each item As String In PlayerNameCBox.Items
            If item = displayName Then
                playerName = playerNames(PlayerNameCBox.Items.IndexOf(item))
                Exit For
            End If
        Next
        Dim playerJersey As String = JerseyNumberTBox.Text
        Dim playerPosition As String = PositionCBox.SelectedItem
        Dim playerDivision As String = DivisionCBox.SelectedItem
        Dim playerHeight As String = HeightTBox.Text
        Dim playerWeight As String = WeightTBox.Text
        Dim playerTeam As String = TeamCBox.SelectedItem

        If playerName = "" Or playerJersey = "" Or playerPosition = "" Or playerDivision = "" Or playerHeight = "" Or playerWeight = "" Or playerTeam = "" Then
            FeedBLbl.Text = "Please fill in all fields!"
            FeedBLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedBLbl)
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
            Dim sqlGetMaxId As String = "SELECT COALESCE(MAX(MemberID), 0) FROM [Members];"
            Dim sqlInsert As String = "INSERT INTO [Members] ([MemberID], [Player Name], [YouthID], [Team Name], [Jersey Number], [Position], [Division], [Height], [Weight]) VALUES (@memberid, @pname, @youthid, @teamname, @jerseyno, @position, @division, @height, @weight);"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Using cmd As New SQLiteCommand(sqlGetMaxId, connection)
                    memberId = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                End Using

                Using cmd As New SQLiteCommand(sqlInsert, connection)
                    cmd.Parameters.AddWithValue("@memberid", memberId)
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
            Dim t As String = "MemberId: " & memberId & " | Player Name: " & playerName & " | YouthID: " & youthID & " | Team Name: " & playerTeam & " | Jersey Number: " & playerJersey & " | Position: " & playerPosition & " | Division: " & playerDivision & " | Height: " & playerHeight & " | Weight: " & playerWeight
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sqls1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
                    command.Parameters.AddWithValue("@table", "Players")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            FeedBLbl.Text = "Player registered successfully!"
            FeedBLbl.ForeColor = Color.Green
            StringStorage.ShowLabelsForThreeSeconds(FeedBLbl)
            Dim cleartb() As TextBox = {JerseyNumberTBox, HeightTBox, WeightTBox}
            Dim clearcb() As ComboBox = {PositionCBox, DivisionCBox, TeamCBox, PlayerNameCBox}
            StringStorage.ClearFields(clearcb)
            StringStorage.ClearFields(cleartb)
        Else
            FeedBLbl.Text = "Player name not found in profiling database!"
            FeedBLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedBLbl)
        End If
    End Sub


End Class