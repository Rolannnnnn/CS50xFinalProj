Imports System.Data.SQLite

Public Class BasketballEditStats

    Private chosenID As Integer
    Private mainForm As BasketballMainForm

    Public Sub New(chosenID As Integer)
        InitializeComponent()
        Me.chosenID = chosenID
        Me.mainForm = mainForm
    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PointsTB.KeyPress, AssistsTB.KeyPress, ReboundsTB.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BasketballEditStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index As Integer = Me.chosenID
        Errorlbl.Text = "Records List with Game ID: " & Index
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
        Dim sql1 As String = "SELECT [RecordID], [Player Name], [Points], [Assists], [Rebounds], [GameID] FROM [Records] WHERE [GameID] = @id;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@id", Index)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub

    Private Sub SelectBtn_Click(sender As Object, e As EventArgs) Handles SelectBtn.Click
        Dim mark As Integer = -1
        If DataGridView1.SelectedRows.Count <= 0 Then
            Errorlbl.Text = "Invalid Selection"
            Errorlbl.ForeColor = Color.Red
        Else
            mark = DataGridView1.SelectedRows(0).Index
        End If

        If Not mark = -1 Then
            If mark < 0 Or mark > 10 Then
                Errorlbl.Text = "Invalid Selection"
                Errorlbl.ForeColor = Color.Red
            Else
                Label3.Visible = True
                Label2.Visible = True
                Label4.Visible = True
                PointsTB.Visible = True
                AssistsTB.Visible = True
                ReboundsTB.Visible = True
                SelectBtn.Visible = False
                ConfirmBtn.Visible = True
                DataGridView1.Enabled = False
                Errorlbl.Text = "Enter the new stats"
                Errorlbl.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Async Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If Not (StringStorage.CheckString(PointsTB.Text, 50).Equals("") And StringStorage.CheckString(AssistsTB.Text, 50).Equals("") And StringStorage.CheckString(ReboundsTB.Text, 50).Equals("")) Then
            Errorlbl.Text = "Some fields are empty."
            Errorlbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(Errorlbl)
        ElseIf Not (StringStorage.IsNumber(PointsTB.Text) And StringStorage.IsNumber(AssistsTB.Text) And StringStorage.IsNumber(ReboundsTB.Text)) Then
            Errorlbl.Text = "Fiels should only contain numbers!."
            Errorlbl.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(Errorlbl)
        Else
            Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
            Dim sql As String = "UPDATE [Records] SET [Points] = @pts, [Assists] = @ast, [Rebounds] = @reb WHERE [RecordID] = @id;"

            'Security
            Dim fr As String = ""
            Dim tr As String = ""
            Dim sqlsr As String = "SELECT [RecordID], [Player Name], [Points], [Assists], [Rebounds], [Position], [GameID] FROM [Records] WHERE [RecordID] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        While reader.Read
                            fr = "RecordID: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | Points: " & reader.GetInt32(2) & " | Assists: " & reader.GetInt32(3) & " | Rebounds: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | GameID: " & reader.GetInt32(6)
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@pts", PointsTB.Text)
                    command.Parameters.AddWithValue("@ast", AssistsTB.Text)
                    command.Parameters.AddWithValue("@reb", ReboundsTB.Text)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        While reader.Read
                            tr = "RecordID: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | Points: " & reader.GetInt32(2) & " | Assists: " & reader.GetInt32(3) & " | Rebounds: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | GameID: " & reader.GetInt32(6)
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
                    command.Parameters.AddWithValue("@table", "Records")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", fr)
                    command.Parameters.AddWithValue("@t", tr)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Errorlbl.Text = "Changes successfully updated!"
            Errorlbl.ForeColor = Color.Green
            Await Task.Delay(3000)
            BasketballMainForm.Show()
            Close()
        End If
    End Sub

    Private Sub Errorlbl_Click(sender As Object, e As EventArgs) Handles Errorlbl.Click

    End Sub
End Class