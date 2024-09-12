Imports System.Data.SqlClient
Imports System.Data.SQLite


Public Class ESportsEditRecord
    Public Property GameID As Integer
    Private Sub ESportsEditRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Records List with Game ID: " & GameID
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim sql1 As String = "SELECT [RecordId], [PlayerName], [Kills], [Deaths], [Assists], [GameId] FROM [Records] WHERE [GameId] = @id;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@id", GameID)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub


    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        ESportsEditGame.Show()
        Close()
    End Sub

    Private Sub SelectBttn_Click(sender As Object, e As EventArgs) Handles SelectBttn.Click
        'Checks if the selected row is valid
        Dim index As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            FeedbackLbl.Text = "Invalid row selection"
            FeedbackLbl.ForeColor = Color.Red
        Else
            index = DataGridView1.SelectedRows(0).Index
        End If

        If Not index = -1 Then
            If index < 0 Or index > 10 Then
                FeedbackLbl.Text = "Invalid row selection"
                FeedbackLbl.ForeColor = Color.Red
            Else
                Dim lbl() As Label = {Label1, Label2, Label4}
                Dim txt() As TextBox = {TextBox1, TextBox2, TextBox3}
                StringStorage.Visible(lbl, True)
                StringStorage.Visible(txt, True)
                SelectBttn.Visible = False
                ConfirmBttn.Visible = True
                DataGridView1.Enabled = False
                FeedbackLbl.Text = "Enter the new KDA"
                FeedbackLbl.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Async Sub ConfirmBttn_Click(sender As Object, e As EventArgs) Handles ConfirmBttn.Click
        If Not (StringStorage.CheckString(TextBox1.Text, 50).Equals("") And StringStorage.CheckString(TextBox2.Text, 50).Equals("") And StringStorage.CheckString(TextBox3.Text, 50).Equals("")) Then
            FeedbackLbl.Text = "The fields are either empty or too long."
            FeedbackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        ElseIf Not (StringStorage.IsNumber(TextBox1.Text) And StringStorage.IsNumber(TextBox2.Text) And StringStorage.IsNumber(TextBox3.Text)) Then
            FeedbackLbl.Text = "The fields should only contain numbers."
            FeedbackLbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        Else
            Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
            Dim sqls As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists], [GameId] FROM [Records] WHERE [RecordId] = @id"
            Dim f As String = ""
            Dim t As String = ""
            Dim sql As String = "UPDATE [Records] SET [Kills] = @k, [Deaths] = @d, [Assists] = @a WHERE [RecordId] = @id;"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sqls, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            f = "RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId" & reader.GetInt32(6)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@k", TextBox1.Text)
                    command.Parameters.AddWithValue("@d", TextBox2.Text)
                    command.Parameters.AddWithValue("@a", TextBox3.Text)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using

                Using command As New SQLiteCommand(sqls, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        If reader.Read Then
                            t = "RecordId: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Kills: " & reader.GetInt32(3) & " | Deaths: " & reader.GetInt32(4) & " | Assists: " & reader.GetInt32(5) & " | GameId" & reader.GetInt32(6)
                        End If
                    End Using
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
                    command.Parameters.AddWithValue("@db", "SportsEsports")
                    command.Parameters.AddWithValue("@table", "Records")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", f)
                    command.Parameters.AddWithValue("@t", t)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            FeedbackLbl.Text = "Successfully updated! Reverting."
            FeedbackLbl.ForeColor = Color.Green
            Await Task.Delay(3000)
            ESportsEditGame.Close()
            ESportsMainForm.Show()
            Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ESportsEditGame.Close()
        ESportsMainForm.Show()
        Close()
    End Sub
End Class