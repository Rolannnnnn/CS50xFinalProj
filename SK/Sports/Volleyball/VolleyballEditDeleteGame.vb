
Imports System.ComponentModel
Imports System.Data.SQLite


Public Class VolleyballEditDeleteGame
    Dim countID As Integer
    Dim choice As String
    Public chosenID As Integer

    Private Sub VolleyballEditDeleteGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase
                                                    )
        Dim sql1 As String = "SELECT * FROM [Games] WHERE [GameID];"
        Dim sql2 As String = "SELECT MAX(TeamID) FROM [Team];"

        Try
            Using connection As New SQLiteConnection(con)
                connection.Open()
                Using cmd As New SQLiteCommand(sql1, connection)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        Dim dTable As New DataTable()
                        adapter.Fill(dTable)
                        DataGridView1.DataSource = dTable
                    End Using
                End Using
                Using cmd As New SQLiteCommand(sql2, connection)
                    countID = Integer.Parse(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Dltbtn_Click(sender As Object, e As EventArgs) Handles Dltbtn.Click
        Dim index As Integer = -1

        If DataGridView1.SelectedRows.Count <= 0 Then
            MessageBox.Show("Not a valid option")
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > countID Then
                MessageBox.Show("Not a valid option")
            Else
                Dim btn() As Button = {Idetbtn, Dltbtn, Statsbtn}
                StringStorage.Visible(btn, False)
                DateTimePicker1.Visible = False
                ComboBox1.Visible = False
                Label3.Visible = False
                Label1.Visible = False
                Label2.Visible = True
                Label2.Text = "Players and Game Records will be deleted. Press the CONFIRM button to continue!"
                DataGridView1.Enabled = False
                Cnfrmbtn.Visible = True
                choice = "Delete"
            End If
        End If
    End Sub

    Private Async Sub Cnfrmbtn_Click(sender As Object, e As EventArgs) Handles Cnfrmbtn.Click
        If choice IsNot Nothing Then
            If choice.Equals("Delete") Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
                    If DataGridView1.SelectedRows(0).Cells.Count > 0 Then
                        Dim id As Integer
                        If Integer.TryParse(DataGridView1.SelectedRows(0).Cells(0).Value.ToString(), id) Then
                            Dim sql1 As String = "DELETE FROM [Records] WHERE [recordID] = @recordid;"
                            Dim sql2 As String = "DELETE FROM [Games] WHERE [gameID] = @gameid;"

                            'Security
                            Dim fg As String = ""
                            Dim sqlsg As String = "SELECT [GameID], [Team1], [Team2], [Date], [TeamWon] FROM [Games] WHERE [GameID] = @id"
                            Dim fr As New List(Of String)
                            Dim sqlsr As String = "SELECT [RecordID], [PlayerName], [Position], [Points], [Blocks], [Digs], [GameID] FROM [Records] WHERE [GameID] = @id"

                            Using connection As New SQLiteConnection(connectionString)
                                connection.Open()

                                Using command2 As New SQLiteCommand(sqlsr, connection)
                                    command2.Parameters.AddWithValue("@id", id)
                                    Using reader As SQLiteDataReader = command2.ExecuteReader
                                        While reader.Read
                                            fr.Add("RecordID: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Points: " & reader.GetInt32(3) & " | Blocks: " & reader.GetInt32(4) & " | Digs: " & reader.GetInt32(5) & " | GameID: " & reader.GetInt32(6))
                                        End While
                                    End Using
                                End Using

                                Using command As New SQLiteCommand(sqlsg, connection)
                                    command.Parameters.AddWithValue("@id", id)
                                    Using reader As SQLiteDataReader = command.ExecuteReader
                                        If reader.Read Then
                                            fg = "ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4)
                                        End If
                                    End Using
                                End Using

                                Using command As New SQLiteCommand(sql1, connection)
                                    command.Parameters.AddWithValue("@recordid", id)
                                    command.ExecuteNonQuery()
                                End Using

                                Using command As New SQLiteCommand(sql2, connection)
                                    command.Parameters.AddWithValue("@gameid", id)
                                    command.ExecuteNonQuery()
                                End Using
                            End Using

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
                                    command.Parameters.AddWithValue("@table", "Games")
                                    command.Parameters.AddWithValue("@act", "Delete")
                                    command.Parameters.AddWithValue("@f", fg)
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

                            MessageBox.Show("Records and Games successfully deleted!")
                            Await Task.Delay(3000)
                            Label2.Visible = False
                            VolleyballMainForm.Show()
                            Close()
                        Else
                            MessageBox.Show("Invalid ID format.")
                        End If
                    Else
                        MessageBox.Show("No data in the selected row.")
                    End If
                Else
                    MessageBox.Show("No row selected.")
                End If

            ElseIf choice.Equals("Edit") Then
                If DateTimePicker1.Value.Date > Date.Today Then
                    Label2.Text = "Cannot select a date in the future."
                    Label2.ForeColor = Color.Red
                ElseIf DataGridView1.SelectedRows.Count > 0 AndAlso DataGridView1.SelectedRows(0).Cells.Count > 0 Then
                    Dim id As Integer
                    If Integer.TryParse(DataGridView1.SelectedRows(0).Cells(0).Value.ToString(), id) Then
                        If Not (ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(1).Value) Or ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(2).Value)) Then
                            Label2.Text = "The team that won should only be on the selected Team you're editing!"
                            Label2.ForeColor = Color.Red
                        Else
                            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
                            Dim sql As String = "UPDATE [Games] SET [Date] = @gamedate, [TeamWon] = @twon WHERE [GameID] = @id;"

                            'Security
                            Dim fg As String = ""
                            Dim tg As String = ""
                            Dim sqlsg As String = "SELECT [GameID], [Team1], [Team2], [Date], [TeamWon] FROM [Games] WHERE [GameID] = @id"

                            Using connection As New SQLiteConnection(connectionString)
                                connection.Open()

                                Using command As New SQLiteCommand(sqlsg, connection)
                                    command.Parameters.AddWithValue("@id", id)
                                    Using reader As SQLiteDataReader = command.ExecuteReader
                                        If reader.Read Then
                                            fg = "ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4)
                                        End If
                                    End Using
                                End Using

                                Using command As New SQLiteCommand(sql, connection)
                                    command.Parameters.AddWithValue("@gamedate", DateTimePicker1.Value.Date)
                                    command.Parameters.AddWithValue("@twon", ComboBox1.Text)
                                    command.Parameters.AddWithValue("@id", id)
                                    command.ExecuteNonQuery()
                                End Using

                                Using command As New SQLiteCommand(sqlsg, connection)
                                    command.Parameters.AddWithValue("@id", id)
                                    Using reader As SQLiteDataReader = command.ExecuteReader
                                        If reader.Read Then
                                            tg = "ID: " & reader.GetInt32(0) & " | Team1: " & reader.GetString(1) & " | Team2: " & reader.GetString(2) & " | GameDate: " & reader.GetDateTime(3).ToString("MM/dd/yyyy") & " | TeamWon: " & reader.GetString(4)
                                        End If
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
                                    command.Parameters.AddWithValue("@table", "Games")
                                    command.Parameters.AddWithValue("@act", "Update")
                                    command.Parameters.AddWithValue("@f", fg)
                                    command.Parameters.AddWithValue("@t", tg)
                                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                                    command.Parameters.AddWithValue("@user", Login.logged)
                                    command.ExecuteNonQuery()
                                End Using
                            End Using

                            Label2.Text = "Game successfully edited!"
                            Label2.ForeColor = Color.Green
                            Await Task.Delay(3000)
                            VolleyballMainForm.Show()
                            Close()
                        End If
                    Else
                        MessageBox.Show("Invalid ID format.")
                    End If
                Else
                    MessageBox.Show("No data in the selected row.")
                End If
            End If
        Else
            MessageBox.Show("Choice is not initialized.")
        End If
    End Sub



    Private Sub idetbtn_Click(sender As Object, e As EventArgs) Handles Idetbtn.Click
        Dim btns() As Button = {Idetbtn, Dltbtn, Statsbtn}
        Dim lbls() As Label = {Label2, Label3}
        StringStorage.Visible(btns, False)
        StringStorage.Visible(lbls, True)
        Cnfrmbtn.Visible = True
        ComboBox1.Visible = True
        DateTimePicker1.Visible = True
        Label1.Visible = False

        If DataGridView1.SelectedRows.Count <= 0 Then
            Label2.Text = "Not a valid option"
            Label2.ForeColor = Color.Red
            Label1.Visible = True
            Label2.Visible = True
            DateTimePicker1.Visible = True
            ComboBox1.Visible = True
            Cnfrmbtn.Visible = True
            Idetbtn.Visible = True
            Dltbtn.Visible = True
            Console.WriteLine("Not a valid option")
        Else
            Dim index As Integer = DataGridView1.SelectedRows(0).Index
            If index < 0 Or index > countID Then
                Label2.Text = "Not a valid option"
                Label2.ForeColor = Color.Red
                Label2.Visible = True
                DateTimePicker1.Visible = True
                ComboBox1.Visible = True
                Cnfrmbtn.Visible = True
                Console.WriteLine("Not a valid option")
            Else
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(1).Value)
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(2).Value)
                Label2.Text = "You can only edit the date and winner. Click Confirm to proceed."
                DataGridView1.Enabled = False
                Label2.Visible = True
                DateTimePicker1.Visible = True
                ComboBox1.Visible = True
                Cnfrmbtn.Visible = True
                choice = "Edit"
            End If
        End If
    End Sub


    Private Sub Statsbtn_Click(sender As Object, e As EventArgs) Handles Statsbtn.Click
        Dim counter As Integer
        If DataGridView1.SelectedRows.Count <= 0 Then
            Label2.Text = "Not a valid option"
            Label2.ForeColor = Color.Red
        Else
            counter = DataGridView1.SelectedRows(0).Index
        End If

        If Not counter = -1 Then
            If counter < 0 Or counter > countID Then
                Label2.Text = "Not a valid option"
                Label2.ForeColor = Color.Red
            Else
                chosenID = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
                Dim editStats As New VolleyballEditStats()
                editStats.TopLevel = False
                editStats.Dock = DockStyle.Fill
                editStats.FormBorderStyle = FormBorderStyle.None
                editStats.getID = chosenID
                VolleyballMainForm.Guna2Panel4.Controls.Add(editStats)
                editStats.BringToFront()
                editStats.Show()
                Me.Hide()
            End If
        End If
    End Sub
End Class