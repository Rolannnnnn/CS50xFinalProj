Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class ESportsEditGame

    Dim maxid As Integer
    Dim mode As String
    Public getID As Integer
    Private Sub ESportsEditGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fills the DataGridView
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim sql1 As String = "SELECT * FROM [Games] WHERE [GameId] > 0;"
        Dim sql2 As String = "SELECT MAX(TeamId) FROM [Teams];"

        Try
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    Using adapter As New SQLiteDataAdapter(command)
                        Dim datatable As New DataTable()
                        adapter.Fill(datatable)
                        DataGridView1.DataSource = datatable
                    End Using
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    maxid = Integer.Parse(command.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub EditGBttn_Click(sender As Object, e As EventArgs) Handles EditGBttn.Click
        'Checks if the selected row is valid
        Dim index As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            FeedbackLbl.Text = "Invalid row selection"
            FeedbackLbl.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > maxid Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
            Else
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(2).Value)
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(3).Value)
                Dim bttns() As Button = {EditGBttn, EditPBttn, DeleteBttn}
                StringStorage.Visible(bttns, False)
                FeedbackLbl.Text = "You can only edit the date and who won. Click Confirm to Edit"
                DataGridView1.Enabled = False
                Label1.Visible = True
                Label2.Visible = True
                DateTimePicker1.Visible = True
                ComboBox1.Visible = True
                ConfirmBttn.Visible = True

                mode = "Edit"
            End If
        End If
    End Sub

    Private Sub DeleteBttn_Click(sender As Object, e As EventArgs) Handles DeleteBttn.Click
        'Checks if the selected row is valid
        Dim index As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            FeedbackLbl.Text = "Invalid row selection"
            FeedbackLbl.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > maxid Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
            Else
                Dim bttns() As Button = {EditGBttn, EditPBttn, DeleteBttn}
                StringStorage.Visible(bttns, False)
                FeedbackLbl.Text = "All players' records of this game will also be deleted. This action is irreversible. Click Confirm to continue with the Deletion"
                DataGridView1.Enabled = False
                ConfirmBttn.Visible = True

                mode = "Delete"
            End If
        End If
    End Sub

    Private Async Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        'Edit Mode
        If mode.Equals("Edit") Then
            'Checks the date and team won input, if all is good, update
            If DateTimePicker1.Value.Date > Date.Today Then
                FeedbackLbl.Text = "You cannot select a date in the future."
                FeedbackLbl.ForeColor = Color.Red
            ElseIf Not (ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(2).Value) Or ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(3).Value)) Then
                FeedbackLbl.Text = "The Team Won should be one the teams that played."
                FeedbackLbl.ForeColor = Color.Red
            Else
                'Security
                Dim t1 As String = ""
                Dim t2 As String = ""
                Dim tw As String = ""
                Dim gd As DateTime
                Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
                Dim sql1 As String = "SELECT [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [GameId] = @id"
                Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SportsEsportsDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@id", id)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                gd = reader.GetDateTime(0)
                                t1 = reader.GetString(1)
                                t2 = reader.GetString(2)
                                tw = reader.GetString(3)
                                Exit While
                            End While
                        End Using
                    End Using
                End Using
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim f As String = "ID: " & id & " | GameDate: " & gd.ToString("MM/dd/yyyy") & " | Team1: " & t1 & " | Team2: " & t2 & " | TeamWon: " & tw
                    Dim t As String = "ID: " & id & " | GameDate: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy") & " | Team1: " & t1 & " | Team2: " & t2 & " | TeamWon: " & ComboBox1.Text

                    Dim maxidlog As Integer
                    Using command As New SQLiteCommand(sql3, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "SportsESports")
                        command.Parameters.AddWithValue("@table", "Games")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", f)
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Code
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
                Dim sql As String = "UPDATE [Games] SET [GameDate] = @gamedate, [TeamWon] = @twon WHERE [GameId] = @id;"
                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()
                    Using command As New SQLiteCommand(sql, connection)
                        command.Parameters.AddWithValue("@gamedate", DateTimePicker1.Value.Date)
                        command.Parameters.AddWithValue("@twon", ComboBox1.Text)
                        command.Parameters.AddWithValue("@id", id)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                FeedbackLbl.Text = "Game successfully edited! Reverting."
                FeedbackLbl.ForeColor = Color.Green
                Await Task.Delay(3000)
                ESportsMainForm.Show()
                Close()
            End If

            'Delete Mode
        ElseIf mode.Equals("Delete") Then
            Dim t1 As String = ""
            Dim t2 As String = ""
            Dim tw As String = ""
            Dim gd As DateTime
            Dim fs As New List(Of String)
            Dim count = 0
            Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim sql1 As String = "SELECT [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [GameId] = @id"
            Dim sql2 As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists] FROM Records WHERE [GameId] = @id"
            Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SportsEsportsDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            gd = reader.GetDateTime(0)
                            t1 = reader.GetString(1)
                            t2 = reader.GetString(2)
                            tw = reader.GetString(3)
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            count += 1
                            Dim rid As Integer = reader.GetInt64(0)
                            Dim pn As String = reader.GetString(1)
                            Dim pos As String = reader.GetString(2)
                            Dim k As Integer = reader.GetInt64(3)
                            Dim d As Integer = reader.GetInt64(4)
                            Dim a As Integer = reader.GetInt64(5)
                            fs.Add("RecordId = " & rid & " | PlayerName: " & pn & " | Position: " & pos & " | Kills: " & k & " | Deaths: " & d & " | Assists: " & a)
                        End While
                    End Using
                End Using
            End Using
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Dim f As String = "ID: " & id & " | GameDate: " & gd.ToString("MM/dd/yyyy") & " | Team1: " & t1 & " | Team2: " & t2 & " | TeamWon: " & tw
                Dim maxidlog As Integer
                Using command As New SQLiteCommand(sql3, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sql4, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "SportsESports")
                    command.Parameters.AddWithValue("@table", "Games")
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", f)
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using

                For i = 0 To fs.Count - 1
                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 2 + i)
                        command.Parameters.AddWithValue("@db", "SportsESports")
                        command.Parameters.AddWithValue("@table", "Records")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", fs(i))
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                Next
            End Using


            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim sql5 As String = "DELETE FROM [Records] WHERE [GameId] = @id;"
            Dim sql6 As String = "DELETE FROM [Games] WHERE [GameId] = @id;"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql5, connection)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql6, connection)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using
            End Using

            FeedbackLbl.Text = "Game and Records Successfully Deleted! Reverting."
            FeedbackLbl.ForeColor = Color.Green
            Await Task.Delay(3000)
            SportsMainForm.Show()
            Close()
        End If
    End Sub

    Private Sub EditPBttn_Click(sender As Object, e As EventArgs) Handles EditPBttn.Click
        'Checks if the selected row is valid
        Dim index As Integer
        If DataGridView1.SelectedRows.Count <= 0 Then
            FeedbackLbl.Text = "Invalid row selection"
            FeedbackLbl.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > maxid Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
            Else
                getID = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)

                Dim editRecordForm As New ESportsEditRecord()
                editRecordForm.TopLevel = False
                editRecordForm.Dock = DockStyle.Fill
                editRecordForm.FormBorderStyle = FormBorderStyle.None
                editRecordForm.GameID = getID
                ESportsMainForm.Guna2Panel3.Controls.Add(editRecordForm)
                editRecordForm.BringToFront()
                editRecordForm.Show()
                Me.Hide()
            End If
        End If
    End Sub

End Class