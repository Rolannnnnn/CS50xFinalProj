Imports System.Data.SQLite

Public Class SecurityLogs
    Private Sub SecurityLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Dim connectionString As String = StringStorage.Addresser(StringStorage.SecurityDatabase)
        Dim sql As String = "SELECT * FROM Logs WHERE [LogID] > 0"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub





    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        MainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        SecurityPrintDialog.Show()
    End Sub
End Class