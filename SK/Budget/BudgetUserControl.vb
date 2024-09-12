Imports System.Data.SQLite

Public Class BudgetUserControl
    Dim amount As Decimal
    Dim itemsource As String
    Dim dt As DateTime
    Dim isExpense As Boolean
    Dim id As Integer
    Dim eventName As String

    Public Sub SetValuesExp(a As Decimal, b As String, c As DateTime, e As Integer, f As String)
        amount = a
        itemsource = b
        dt = c
        isExpense = True
        id = e
        eventName = f
    End Sub

    Public Sub SetValuesInf(a As Decimal, b As String, c As DateTime, e As Integer)
        amount = a
        itemsource = b
        dt = c
        isExpense = False
        id = e
    End Sub

    Private Sub BudgetUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AmountLbl.Text = "P" & amount
        DateLbl.Text = dt.ToString("MM/d/yyyy")

        If isExpense Then
            AmountLbl.ForeColor = Color.FromArgb(255, 49, 49)
            Dim temp As String = "-P" & amount
            AmountLbl.Text = temp
            ItemSourceLbl.Text = itemsource & " (" & eventName & ")"
        Else
            AmountLbl.ForeColor = Color.FromArgb(192, 255, 192)
            ItemSourceLbl.Text = itemsource
        End If
    End Sub

    Private Sub MoreLbl_Click(sender As Object, e As EventArgs) Handles MoreLbl.Click
        ContextMenuStrip1.Show(Cursor.Position)
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim mode As String
        If isExpense Then
            mode = "Expense"
        Else
            mode = "Inflow"
        End If

        Dim edit As New BudgetEdit(mode, id)
        edit.Show()
        BudgetMainForm.Close()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim msgbox As DialogResult = MessageBox.Show("You are about to delete this record. Are you sure?", "Confirmation", MessageBoxButtons.OKCancel)

        If msgbox = DialogResult.OK Then
            Dim sql As String
            Dim table As String
            Dim f As String
            If isExpense Then
                table = "Expense"
                sql = "DELETE FROM [Expense] WHERE [ExpenseID] = @id"
                f = "ID: " & id & " | Amount: " & amount & " | Item: " & itemsource & " | EventName: " & eventName & " | Date: " & dt.ToString("MM/dd/yyyy")
            Else
                table = "Inflow"
                sql = "DELETE FROM [Inflow] WHERE [InflowID] = @id"
                f = "ID: " & id & " | Amount: " & amount & " | Source: " & itemsource & " | Date: " & dt.ToString("MM/dd/yyyy")
            End If

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Dim sql1 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sql2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim maxidlog As Integer

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "Budget")
                    command.Parameters.AddWithValue("@table", table)
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", f)
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
            End Using

            BudgetMainForm.Close()
            BudgetMainForm.Show()
        End If
    End Sub
End Class
