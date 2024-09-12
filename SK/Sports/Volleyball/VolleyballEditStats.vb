Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class VolleyballEditStats
    Public Property getID As Integer
    Private Sub VolleyballEditStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = "Records List with Game ID: " & getID
        Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
        Dim sql1 As String = "SELECT [recordID], [PlayerName], [Points], [Blocks], [Digs], [gameID] FROM [Records] WHERE [gameID] = @id;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@id", getID)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub

    Private Async Sub cnfrmbtn_Click(sender As Object, e As EventArgs) Handles cnfrmbtn.Click
        If Not (StringStorage.CheckString(PtsTB.Text, 50).Equals("") And StringStorage.CheckString(BlksTB.Text, 50).Equals("") And StringStorage.CheckString(Dgstb.Text, 50).Equals("")) Then
            Label4.Text = "Some fields are empty."
            Label4.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        ElseIf Not (StringStorage.IsNumber(PtsTB.Text) And StringStorage.IsNumber(BlksTB.Text) And StringStorage.IsNumber(Dgstb.Text)) Then
            Label4.Text = "Field should only contain numbers!."
            Label4.ForeColor = Color.Red
            StringStorage.ShowLabelsForThreeSeconds(Label4)
        Else
            Dim id As Integer = Integer.Parse(DataGridView1.SelectedRows(0).Cells(0).Value)
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
            Dim sql As String = "UPDATE [Records] SET [Points] = @pts, [Blocks] = @blks, [Digs] = @dgs WHERE [RecordID] = @id;"

            'Security
            Dim fr As String = ""
            Dim tr As String = ""
            Dim sqlsr As String = "SELECT [RecordID], [PlayerName], [Position], [Points], [Blocks], [Digs], [GameID] FROM [Records] WHERE [RecordID] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        If reader.Read Then
                            fr = "RecordID: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Points: " & reader.GetInt32(3) & " | Blocks: " & reader.GetInt32(4) & " | Digs: " & reader.GetInt32(5) & " | GameID: " & reader.GetInt32(6)
                        End If
                    End Using
                End Using

                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@pts", PtsTB.Text)
                    command.Parameters.AddWithValue("@blks", BlksTB.Text)
                    command.Parameters.AddWithValue("@dgs", Dgstb.Text)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using

                Using command2 As New SQLiteCommand(sqlsr, connection)
                    command2.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command2.ExecuteReader
                        If reader.Read Then
                            tr = "RecordID: " & reader.GetInt32(0) & " | PlayerName: " & reader.GetString(1) & " | Position: " & reader.GetString(2) & " | Points: " & reader.GetInt32(3) & " | Blocks: " & reader.GetInt32(4) & " | Digs: " & reader.GetInt32(5) & " | GameID: " & reader.GetInt32(6)
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
                    command.Parameters.AddWithValue("@table", "Records")
                    command.Parameters.AddWithValue("@act", "Update")
                    command.Parameters.AddWithValue("@f", fr)
                    command.Parameters.AddWithValue("@t", tr)
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Successfully Edited!")
            Label4.ForeColor = Color.Green
            Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VolleyballEditDeleteGame.Close()
        VolleyballMainForm.Show()
        Close()
    End Sub
End Class