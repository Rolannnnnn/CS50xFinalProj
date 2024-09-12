Imports System.Data.SQLite
Imports System.Net

Public Class BasketballEditDeleteGame

    Dim countID As Integer
    Dim choice As String
    Public chosenID As Integer = -1

    Private mainForm As BasketballMainForm

    Public Sub New(mainForm As BasketballMainForm)
        InitializeComponent()
        Me.mainForm = mainForm
    End Sub

    Private Sub BasketballEditDeleteGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql1 As String = "SELECT * FROM [Games] WHERE [GameID] > 0;"
        Dim sql2 As String = "SELECT MAX(ID) FROM [Teams];"

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

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim index As Integer = -1

        If DataGridView1.SelectedRows.Count <= 0 Then
            MessageBox.Show("Invalid selection")
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > countID Then
                MessageBox.Show("Invalid selection")
            Else
                Dim btn() As Button = {EditBtn, DeleteBtn}
                StringStorage.Visible(btn, False)
                DateTimePicker1.Visible = False
                ComboBox1.Visible = False
                Label3.Visible = False
                Label2.Text = "Players and Game Records will be deleted. Press the CONFIRM button to continue!"
                DataGridView1.Enabled = False
                ConfirmBtn.Visible = True
                choice = "Delete"
            End If
        End If
    End Sub

    Private Async Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If choice.Equals("Delete") Then
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
            Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim sql1 As String = "DELETE FROM [Records] WHERE [GameID] = @gameid;"
            Dim sql2 As String = "DELETE FROM [Games] WHERE [GameID] = @gameid;"

            'Security
            Dim fg As String = ""
            Dim sqlsg As String = "SELECT [GameID], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [GameID] = @id"
            Dim fr As New List(Of String)
            Dim sqlsr As String = "SELECT [RecordID], [Player Name], [Points], [Assists], [Rebounds], [Position], [GameID] FROM [Records] WHERE [GameID] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        While reader.Read
                            fr.Add("RecordID: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | Points: " & reader.GetInt32(2) & " | Assists: " & reader.GetInt32(3) & " | Rebounds: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | GameID: " & reader.GetInt32(6))
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sqlsg, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            fg = "ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@gameid", id)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@gameid", id)
                    command.ExecuteNonQuery()
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
                        command.Parameters.AddWithValue("@db", "SportsBasketball")
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
            BasketballMainForm.Show()
            Close()


        ElseIf choice.Equals("Edit") Then
            If DateTimePicker1.Value.Date > Date.Today Then
                Label2.Text = "Cannot select a date in the future."
                Label2.ForeColor = Color.Red
            ElseIf Not (ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(2).Value) Or ComboBox1.Text.Equals(DataGridView1.SelectedRows(0).Cells(3).Value)) Then
                Label2.Text = "The team that won should only be on the selected Team you're editing!"
                Label2.ForeColor = Color.Red
            Else
                Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
                Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
                Dim sql As String = "UPDATE [Games] SET [GameDate] = @gamedate, [TeamWon] = @twon WHERE [GameID] = @id"

                'Security
                Dim fg As String = ""
                Dim tg As String = ""
                Dim sqlsg As String = "SELECT [GameID], [GameDate], [Team1], [Team2], [TeamWon] FROM [Games] WHERE [GameID] = @id"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()

                    Using command As New SQLiteCommand(sqlsg, connection)
                        command.Parameters.AddWithValue("@id", id)
                        Using reader As SQLiteDataReader = command.ExecuteReader
                            While reader.Read
                                fg = "ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4)
                            End While
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
                            While reader.Read
                                tg = "ID: " & reader.GetInt32(0) & " | GameDate: " & reader.GetDateTime(1).ToString("MM/dd/yyyy") & " | Team1: " & reader.GetString(2) & " | Team2: " & reader.GetString(3) & " | TeamWon: " & reader.GetString(4)
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
                BasketballMainForm.Show()
                Close()
            End If
        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        Dim btns() As Button = {EditBtn, DeleteBtn}
        StringStorage.Visible(btns, False)

        Dim index As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            Label2.Text = "Invalid Selection!"
            Label2.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > countID Then
                Label2.Text = "Invalid row selection"
                Label2.ForeColor = Color.Red
            Else
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(2).Value)
                ComboBox1.Items.Add(DataGridView1.SelectedRows(0).Cells(3).Value)
                Label2.Text = "You can only edit the date and who won. Click Confirm to Edit"
                DataGridView1.Enabled = False
                Label1.Visible = False
                EditStats.Visible = False
                Label2.Visible = True
                Label3.Visible = True
                DateTimePicker1.Visible = True
                ComboBox1.Visible = True
                ConfirmBtn.Visible = True
                choice = "Edit"
            End If
        End If
    End Sub

    Private Sub EditStats_Click(sender As Object, e As EventArgs) Handles EditStats.Click
        Dim counter As Integer
        If DataGridView1.SelectedRows.Count <= 0 Then
            Label2.Text = "Invalid Selection"
            Label2.ForeColor = Color.Red
        Else
            counter = DataGridView1.SelectedRows(0).Index
        End If

        If Not counter = -1 Then
            If counter < 0 Or counter > countID Then
                Label2.Text = "Invalid row selection"
                Label2.ForeColor = Color.Red
            Else
                Try
                    chosenID = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
                    mainForm.OpenChildFormInPanel(New BasketballEditStats(chosenID))
                    Close()
                Catch ex As Exception
                    MessageBox.Show("Please select a row!")
                    Return
                End Try
            End If
        End If
    End Sub
End Class