Imports System.Data.SQLite

Public Class BudgetAdd

    Dim mode As String = ""

    Public Sub New(_mode As String)
        InitializeComponent()
        mode = _mode
    End Sub

    Private Sub BudgetAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If mode = "Expense" Then
            Dim events As New List(Of String) From {"No Event Associated"}
            Dim sql1 As String = "SELECT [Name] FROM [Events] WHERE [EventID] > 0 ORDER BY [EventID] DESC"

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.EventHandlerDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            events.Add(reader.GetString(0).ToString())
                        End While
                    End Using
                End Using
            End Using
            ComboBox1.DataSource = events

        ElseIf mode = "Inflow" Then
            EventLbl.Visible = False
            EventSubLbl.Visible = False
            ComboBox1.Visible = False
            ItemSourceLbl.Text = "Source:"
            ItemSourceSubLbl.Text = "Source of the Inflow"
            DateSubLbl.Text = "Date of the Inflow"
            TitleLbl.Text = "Add Inflow"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If mode = "Expense" Then
            If Not StringStorage.IsDecimal(AmountTxtBox.Text) Then
                FeedbackLbl.Text = "Amount is the wrong format"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf Decimal.Parse(AmountTxtBox.Text) < 0 Then
                FeedbackLbl.Text = "Amount cannot be negative"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf StringStorage.CheckString(ItemSourceTxtBox.Text, 100) <> "" Then
                FeedbackLbl.Text = "Item is either empty or too long"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                Dim sql1 As String = "SELECT MAX(ExpenseID) FROM Expense"
                Dim sql2 As String = "INSERT INTO Expense VALUES (@id, @am, @item, @event, @date)"
                Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim maxid As Integer
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        maxid = Integer.Parse(command.ExecuteScalar())
                    End Using
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxid + 1)
                        command.Parameters.AddWithValue("@am", AmountTxtBox.Text)
                        command.Parameters.AddWithValue("@item", ItemSourceTxtBox.Text)
                        command.Parameters.AddWithValue("@event", ComboBox1.Text)
                        command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t As String = "ID: " & maxid + 1 & " | Amount: " & AmountTxtBox.Text & " | Item: " & ItemSourceTxtBox.Text & " | EventName: " & ComboBox1.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                    Using command As New SQLiteCommand(sql3, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "Budget")
                        command.Parameters.AddWithValue("@table", "Expense")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                BudgetMainForm.Show()
                Close()
            End If
        ElseIf mode = "Inflow" Then
            If Not StringStorage.IsDecimal(AmountTxtBox.Text) Then
                FeedbackLbl.Text = "Amount is the wrong format"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf Integer.Parse(AmountTxtBox.Text) < 0 Then
                FeedbackLbl.Text = "Amount cannot be negative"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf StringStorage.CheckString(ItemSourceTxtBox.Text, 100) <> "" Then
                FeedbackLbl.Text = "Source is either empty or too long"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                Dim sql1 As String = "SELECT MAX(InflowID) FROM Inflow"
                Dim sql2 As String = "INSERT INTO Inflow VALUES (@id, @am, @source, @date)"
                Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim maxid As Integer
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        maxid = Integer.Parse(command.ExecuteScalar())
                    End Using
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxid + 1)
                        command.Parameters.AddWithValue("@am", AmountTxtBox.Text)
                        command.Parameters.AddWithValue("@source", ItemSourceTxtBox.Text)
                        command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t As String = "ID: " & maxid + 1 & " | Amount: " & AmountTxtBox.Text & " | Source: " & ItemSourceTxtBox.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                    Using command As New SQLiteCommand(sql3, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "Budget")
                        command.Parameters.AddWithValue("@table", "Inflow")
                        command.Parameters.AddWithValue("@act", "Insert")
                        command.Parameters.AddWithValue("@f", "-")
                        command.Parameters.AddWithValue("@t", t)
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                BudgetMainForm.Show()
                Close()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BudgetMainForm.Show()
        Close()
    End Sub
End Class