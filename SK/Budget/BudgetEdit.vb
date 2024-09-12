Imports System.Data.Entity.Migrations
Imports System.Data.SQLite

Public Class BudgetEdit

    Dim mode As String = ""
    Dim id As Integer
    Dim f As String

    Public Sub New(_mode As String, _id As Integer)
        InitializeComponent()
        mode = _mode
        id = _id
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

            Dim sql2 As String = "SELECT [Amount], [Item], [EventName], [Date] FROM [Expense] WHERE [ExpenseID] = @id"
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            AmountTxtBox.Text = reader.GetDecimal(0)
                            ItemSourceTxtBox.Text = reader.GetString(1)
                            ComboBox1.Text = reader.GetString(2)
                            DateTimePicker1.Value = reader.GetDateTime(3)
                        End While
                    End Using
                End Using

                f = "ID: " & id & " | Amount: " & AmountTxtBox.Text & " | Item: " & ItemSourceTxtBox.Text & " | EventName: " & ComboBox1.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
            End Using


        ElseIf mode = "Inflow" Then
            EventLbl.Visible = False
            EventSubLbl.Visible = False
            ComboBox1.Visible = False
            ItemSourceLbl.Text = "Source:"
            ItemSourceSubLbl.Text = "Source of the Inflow"
            DateSubLbl.Text = "Date of the Inflow"
            TitleLbl.Text = "Edit Inflow"

            Dim sql As String = "SELECT [Amount], [Source], [Date] FROM [Inflow] WHERE [InflowID] = @id"
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            AmountTxtBox.Text = reader.GetDecimal(0)
                            ItemSourceTxtBox.Text = reader.GetString(1)
                            DateTimePicker1.Value = reader.GetDateTime(2)
                        End While
                    End Using
                End Using
            End Using

            f = "ID: " & id & " | Amount: " & AmountTxtBox.Text & " | Source: " & ItemSourceTxtBox.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
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
                Dim sql1 As String = "UPDATE Expense SET [Amount] = @am, [Item] = @item, [EventName] = @event, [Date] = @date WHERE [ExpenseID] = @id"
                Dim sql2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@id", id)
                        command.Parameters.AddWithValue("@am", AmountTxtBox.Text)
                        command.Parameters.AddWithValue("@item", ItemSourceTxtBox.Text)
                        command.Parameters.AddWithValue("@event", ComboBox1.Text)
                        command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t As String = "ID: " & id & " | Amount: " & AmountTxtBox.Text & " | Item: " & ItemSourceTxtBox.Text & " | EventName: " & ComboBox1.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                    Using command As New SQLiteCommand(sql3, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "Budget")
                        command.Parameters.AddWithValue("@table", "Expense")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", f)
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
                Dim sql As String = "UPDATE Inflow SET [Amount] = @am, [Source] = @source, [Date] = @date WHERE [InflowID] = @id"
                Dim maxidlog As Integer
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql, connection)
                        command.Parameters.AddWithValue("@id", id)
                        command.Parameters.AddWithValue("@am", AmountTxtBox.Text)
                        command.Parameters.AddWithValue("@source", ItemSourceTxtBox.Text)
                        command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                Dim sql1 As String = "SELECT MAX(LogID) FROM Logs"
                Dim sql2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"

                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Dim t As String = "ID: " & id & " | Amount: " & AmountTxtBox.Text & " | Source: " & ItemSourceTxtBox.Text & " | Date: " & DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
                    Using command As New SQLiteCommand(sql1, connection)
                        maxidlog = Integer.Parse(command.ExecuteScalar)
                    End Using
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + 1)
                        command.Parameters.AddWithValue("@db", "Budget")
                        command.Parameters.AddWithValue("@table", "Inflow")
                        command.Parameters.AddWithValue("@act", "Update")
                        command.Parameters.AddWithValue("@f", f)
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