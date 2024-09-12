Imports System.Data.SQLite

Public Class BasketballAddGame
    Private Sub BasketballAddGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lbls() As Label = {Label4, Label5, Label6, Label7, Label8, Label9, Label10}
        Dim cbox() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Position10CB, Position2CB, Position3CB, Position4CB, Position5CB, Position6CB, Position7CB, Position8CB, Position9CB, Position1CB}
        Dim tbox() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Assist10TB, Assist1TB, Rebound1TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}

        StringStorage.Visible(lbls, False)
        StringStorage.Visible(cbox, False)
        StringStorage.Visible(tbox, False)

        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql As String = "SELECT [Team Name] FROM [Teams] WHERE [ID] > 0;"

        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                While reader.Read
                    Team1ComboBox.Items.Add(reader.GetString(0))
                    Team2ComboBox.Items.Add(reader.GetString(0))
                End While
            End Using
        End Using
    End Sub

    Private Sub Team1ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Team1ComboBox.SelectedIndexChanged
        Dim selectedItem As String = Team1ComboBox.SelectedItem.ToString()

        If Team1ComboBox.Items.Contains(selectedItem) Then
            Team2ComboBox.Items.Remove(selectedItem)
        End If
    End Sub

    Private Sub Team2ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Team2ComboBox.SelectedIndexChanged
        Dim selectedItem As String = Team2ComboBox.SelectedItem.ToString()

        If Team2ComboBox.Items.Contains(selectedItem) Then
            Team1ComboBox.Items.Remove(selectedItem)
        End If
    End Sub

    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        BasketballMainForm.Show()
        Close()
    End Sub

    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If Not StringStorage.CheckString(Team1ComboBox.Text, 50) = "" Or Not StringStorage.CheckString(Team2ComboBox.Text, 50) = "" Then
            MessageBox.Show("Team Names Invalid!!")
        ElseIf Team1ComboBox.Text.Equals(Team2ComboBox.Text) Then
            MessageBox.Show("This team cannot fight themselves")
        ElseIf Not Team1WonCheckBox.Checked Xor Team2WonCheckBox.Checked Then
            MessageBox.Show("Select which team won!!")
        ElseIf DateTimePicker1.Value.Date > Date.Today Then
            MessageBox.Show("Cannot select a date in the future!!")
        Else
            Dim lbls() As Label = {Label4, Label5, Label6, Label7, Label8, Label9, Label10}
            Dim cbox() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB, Position10CB, Position2CB, Position3CB, Position4CB, Position5CB, Position6CB, Position7CB, Position8CB, Position9CB, Position1CB}
            Dim tbox() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}

            Team1ComboBox.Enabled = False
            Team2ComboBox.Enabled = False
            Team1WonCheckBox.Enabled = False
            Team2WonCheckBox.Enabled = False
            SubmitBtn.Visible = True
            StringStorage.Visible(lbls, True)
            StringStorage.Visible(cbox, True)
            StringStorage.Visible(tbox, True)

            Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
            Dim sql3 As String = "SELECT [Player Name] FROM [Members] WHERE [Team Name] = @tname;"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB}
                Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB}

                Using cmd As New SQLiteCommand(sql3, connection)
                    cmd.Parameters.AddWithValue("@tname", Team2ComboBox.Text)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read
                            For Each i In names2
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using

                Using cmd As New SQLiteCommand(sql3, connection)
                    cmd.Parameters.AddWithValue("@tname", Team1ComboBox.Text)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read
                            For Each i In names1
                                i.Items.Add(reader.GetString(0))
                            Next
                        End While
                    End Using
                End Using
            End Using

            Dim cb() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB, Name6CB, Name7CB, Name8CB, Name9CB, Name10CB}
            Dim txtb() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Assist1TB, Rebound1TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}
            StringStorage.Visible(cb, True)
            StringStorage.Visible(txtb, True)
            MessageBox.Show("Input all stats of the game.")
            ConfirmBtn.Visible = False
            DateTimePicker1.Enabled = False
        End If
    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Points1TB.KeyPress, Points2TB.KeyPress, Points3TB.KeyPress, Points4TB.KeyPress, Points5TB.KeyPress, Points6TB.KeyPress, Points7TB.KeyPress, Points8TB.KeyPress, Points9TB.KeyPress, Points10TB.KeyPress, Assist1TB.KeyPress, Rebound1TB.KeyPress, Assist10TB.KeyPress, Assist2TB.KeyPress, Assist3TB.KeyPress, Assist4TB.KeyPress, Assist5TB.KeyPress, Assist6TB.KeyPress, Assist7TB.KeyPress, Assist8TB.KeyPress, Assist9TB.KeyPress, Assist10TB.KeyPress, Rebound10TB.KeyPress, Rebound2TB.KeyPress, Rebound3TB.KeyPress, Rebound4TB.KeyPress, Rebound5TB.KeyPress, Rebound6TB.KeyPress, Rebound7TB.KeyPress, Rebound8TB.KeyPress, Rebound9TB.KeyPress, Rebound10TB.KeyPress

        Dim textBox As TextBox = CType(sender, TextBox)

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then

            e.Handled = True

        End If

    End Sub

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Dim names1() As ComboBox = {Name1CB, Name2CB, Name3CB, Name4CB, Name5CB}
        Dim names2() As ComboBox = {Name6CB, Name7CB, Name8CB, Name9CB, Name10CB}
        Dim pos1() As ComboBox = {Position1CB, Position2CB, Position3CB, Position4CB, Position5CB}
        Dim pos2() As ComboBox = {Position6CB, Position7CB, Position8CB, Position9CB, Position10CB}
        Dim stats() As TextBox = {Points1TB, Points2TB, Points3TB, Points4TB, Points5TB, Points6TB, Points7TB, Points8TB, Points9TB, Points10TB, Assist1TB, Rebound1TB, Assist10TB, Assist2TB, Assist3TB, Assist4TB, Assist5TB, Assist6TB, Assist7TB, Assist8TB, Assist9TB, Assist10TB, Rebound10TB, Rebound2TB, Rebound3TB, Rebound4TB, Rebound5TB, Rebound6TB, Rebound7TB, Rebound8TB, Rebound9TB, Rebound10TB}

        Dim empty As Boolean = False
        For i = 0 To 4
            If Not (StringStorage.CheckString(names1(i).Text, 50).Equals("") And StringStorage.CheckString(names2(i).Text, 50).Equals("") And StringStorage.CheckString(pos1(i).Text, 50).Equals("") And StringStorage.CheckString(pos2(i).Text, 50).Equals("")) Then
                empty = True
                Exit For
            End If
        Next
        For Each i In stats
            If Not StringStorage.CheckString(i.Text, 50).Equals("") Then
                empty = True
                Exit For
            End If
        Next

        Dim nonum As Boolean = False
        For Each i In stats
            If Not StringStorage.IsNumber(i.Text) Then
                nonum = True
                Exit For
            End If
        Next

        Dim same As Boolean = False
        If StringStorage.Similar(names1) Or StringStorage.Similar(names2) Or StringStorage.Similar(pos1) Or StringStorage.Similar(pos2) Then
            same = True
        End If

        If empty Then
            MessageBox.Show("Some fields are empty!")
        ElseIf nonum Then
            MessageBox.Show("Some stats contains a non-numeric character!")
        ElseIf same Then
            MessageBox.Show("Some name or position from the same team are similar")
        Else
            Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
            Dim idrecord As Integer
            Dim idg As Integer
            Dim tg As String = ""
            Dim t(10) As String
            Dim teamwon As String = ""
            Dim sql1 As String = "SELECT MAX(RecordID) FROM [Records];"
            Dim sql2 As String = "INSERT INTO [Records] (RecordID, [Player Name], Points, Assists, Rebounds, Position, GameID) VALUES (@recordId, @pName, @pts, @ast, @reb, @pos, @gid);"
            Dim sqlg1 As String = "SELECT MAX (GameID) FROM [Games];"
            Dim sqlg2 As String = "INSERT INTO [Games] (GameID, GameDate, Team1, Team2, TeamWon) VALUES (@gameId, @gameDate, @team1, @team2, @teamWon);"

            Using connection As New SQLiteConnection(con)
                connection.Open()

                Using cmd As New SQLiteCommand(sqlg1, connection)
                    idg = Integer.Parse(cmd.ExecuteScalar)
                End Using

                idg += 1

                Using cmd As New SQLiteCommand(sqlg2, connection)
                    cmd.Parameters.AddWithValue("@gameId", idg)
                    cmd.Parameters.AddWithValue("@gameDate", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@team1", Team1ComboBox.Text)
                    cmd.Parameters.AddWithValue("@team2", Team2ComboBox.Text)
                    If (Team1WonCheckBox.Checked) Then
                        cmd.Parameters.AddWithValue("@teamWon", Team1ComboBox.Text)
                        teamwon = Team1ComboBox.Text
                    Else
                        cmd.Parameters.AddWithValue("@teamWon", Team2ComboBox.Text)
                        teamwon = Team2ComboBox.Text
                    End If
                    cmd.ExecuteNonQuery()
                End Using
                tg = "ID: " & idg & " | GameDate: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Team1: " & Team1ComboBox.Text & " | Team2: " & Team2ComboBox.Text & " | TeamWon: " & teamwon

                Using cmd As New SQLiteCommand(sql1, connection)
                    idrecord = Integer.Parse(cmd.ExecuteScalar())
                End Using
                idrecord += 1

                Dim name() As String = {Name1CB.Text, Name2CB.Text, Name3CB.Text, Name4CB.Text, Name5CB.Text, Name6CB.Text, Name7CB.Text, Name8CB.Text, Name9CB.Text, Name10CB.Text}
                Dim position() As String = {Position1CB.Text, Position2CB.Text, Position3CB.Text, Position4CB.Text, Position5CB.Text, Position6CB.Text, Position7CB.Text, Position8CB.Text, Position9CB.Text, Position10CB.Text}
                Dim points() As String = {Points1TB.Text, Points2TB.Text, Points3TB.Text, Points4TB.Text, Points5TB.Text, Points6TB.Text, Points7TB.Text, Points8TB.Text, Points9TB.Text, Points10TB.Text}
                Dim assist() As String = {Assist1TB.Text, Assist2TB.Text, Assist3TB.Text, Assist4TB.Text, Assist5TB.Text, Assist6TB.Text, Assist7TB.Text, Assist8TB.Text, Assist9TB.Text, Assist10TB.Text}
                Dim rebound() As String = {Rebound1TB.Text, Rebound2TB.Text, Rebound3TB.Text, Rebound4TB.Text, Rebound5TB.Text, Rebound6TB.Text, Rebound7TB.Text, Rebound8TB.Text, Rebound9TB.Text, Rebound10TB.Text}

                For i = 0 To 9
                    Using cmd As New SQLiteCommand(sql2, connection)
                        cmd.Parameters.AddWithValue("@recordId", idrecord + i)
                        cmd.Parameters.AddWithValue("@pName", name(i))
                        cmd.Parameters.AddWithValue("@pos", position(i))
                        cmd.Parameters.AddWithValue("@pts", points(i))
                        cmd.Parameters.AddWithValue("@ast", assist(i))
                        cmd.Parameters.AddWithValue("@reb", rebound(i))
                        cmd.Parameters.AddWithValue("@gid", idg)
                        cmd.ExecuteNonQuery()
                    End Using

                    t(i) = "RecordID: " & idrecord + i & " | Player Name: " & name(i) & " | Points: " & points(i) & " | Assists: " & assist(i) & " | Rebound: " & rebound(i) & " | Position: " & position(i) & " | GameID: " & idg
                Next
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
                maxidlog += 1

                For i = 0 To 9
                    Using command As New SQLiteCommand(sqls2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + i)
                        command.Parameters.AddWithValue("@db", "SportsBasketball")
                        command.Parameters.AddWithValue("@table", "Records")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t(i))
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next

                Using command As New SQLiteCommand(sqls2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 10)
                    command.Parameters.AddWithValue("@db", "SportsBasketball")
                    command.Parameters.AddWithValue("@table", "Games")
                    command.Parameters.AddWithValue("@act", "Insert")
                    command.Parameters.AddWithValue("@f", "-")
                    command.Parameters.AddWithValue("@t", tg)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Game successfully registered!")
            BasketballMainForm.Show()
            Close()
        End If
    End Sub

End Class