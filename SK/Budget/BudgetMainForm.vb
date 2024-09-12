Imports System.Data.SQLite
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class BudgetMainForm
    Private Sub BudgetMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UserControl
        Dim con As String = StringStorage.Addresser(StringStorage.BudgetDatabase)
        Dim amounts As New Dictionary(Of Integer, Decimal)()
        Dim itemsources As New Dictionary(Of Integer, String)()
        Dim dates As New Dictionary(Of Integer, DateTime)()
        Dim ids As New Dictionary(Of Integer, Integer)()
        Dim events As New Dictionary(Of Integer, String)()

        Dim key As Integer = 0

        Dim sql3 As String = "SELECT [Amount], [Item], [Date], [ExpenseID], [EventName] FROM [Expense] WHERE ExpenseID > 0 ORDER BY [Date] DESC"
        Dim sql4 As String = "SELECT [Amount], [Source], [Date], [InflowID] FROM [Inflow] WHERE InflowID > 0 ORDER BY [Date] DESC"
        Using connection As New SQLiteConnection(con)
            connection.Open()
            Using command As New SQLiteCommand(sql3, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        amounts.Add(key, reader.GetDecimal(0))
                        itemsources.Add(key, reader.GetString(1))
                        dates.Add(key, reader.GetDateTime(2))
                        ids.Add(key, reader.GetInt32(3))
                        events.Add(key, reader.GetString(4))
                        key += 1
                    End While
                End Using
            End Using

            Using command As New SQLiteCommand(sql4, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        amounts.Add(key, reader.GetDecimal(0))
                        itemsources.Add(key, reader.GetString(1))
                        dates.Add(key, reader.GetDateTime(2))
                        ids.Add(key, reader.GetInt32(3))
                        key += 1
                    End While
                End Using
            End Using
        End Using

        Dim sortedDates = dates.OrderByDescending(Function(x) x.Value)

        For Each pair In sortedDates
            Dim i As Integer = pair.Key
            Dim uc As New BudgetUserControl

            If events.ContainsKey(i) Then
                uc.SetValuesExp(amounts(i), itemsources(i), dates(i), ids(i), events(i))
            Else
                uc.SetValuesInf(amounts(i), itemsources(i), dates(i), ids(i))
            End If
            BudgetPanel.Controls.Add(uc)
        Next


        'Chart
        Chart()
    End Sub

    Private Sub Chart()
        Dim totalsExp As New Dictionary(Of Integer, Double)
        Dim totalsInf As New Dictionary(Of Integer, Double)

        Dim year As Integer = DateTime.Now.Year
        Dim month As Integer = DateTime.Now.Month
        Dim sql As String = "SELECT Amount FROM Expense WHERE strftime('%m', [Date]) = @m AND strftime('%Y', [Date]) = @y"
        Dim sql2 As String = "SELECT Amount FROM Inflow WHERE strftime('%m', [Date]) = @m AND strftime('%Y', [Date]) = @y"
        For i As Integer = 1 To 12
            totalsExp.Add(i, 0)
            totalsInf.Add(i, 0)
        Next

        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.BudgetDatabase))
            connection.Open()
            For i As Integer = 1 To 12
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@m", i.ToString("00"))
                    command.Parameters.AddWithValue("@y", year.ToString)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            totalsExp(i) += reader.GetDouble(0)
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@m", i.ToString("00"))
                    command.Parameters.AddWithValue("@y", year.ToString)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            totalsInf(i) += reader.GetDouble(0)
                        End While
                    End Using
                End Using
            Next
        End Using

        Dim exp As New Series("Expenses")
        exp.Color = Color.Red
        exp.BorderWidth = 3
        exp.ChartType = SeriesChartType.Line
        For i = 1 To month
            Dim dtfi As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat
            exp.Points.AddXY(dtfi.GetAbbreviatedMonthName(i), totalsExp(i))
        Next

        Dim inf As New Series("Inflow")
        inf.Color = Color.Green
        inf.BorderWidth = 3
        inf.ChartType = SeriesChartType.Line
        For i = 1 To month
            Dim dtfi As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat
            inf.Points.AddXY(dtfi.GetAbbreviatedMonthName(i), totalsInf(i))
        Next

        Chart1.Series.Add(exp)
        Chart1.Series.Add(inf)
        Dim area As New ChartArea("MainArea")
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(area)

        Chart1.Titles.Clear()
        Chart1.Titles.Add("Budget for Year " & year)
        Chart1.ChartAreas(0).AxisX.Title = "Month"
        Chart1.ChartAreas(0).AxisY.Title = "Amount"
    End Sub




    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim exp As New BudgetAdd("Inflow")
        exp.Show()
        Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim exp As New BudgetAdd("Expense")
        exp.Show()
        Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        MainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        BudgetPrintDialog.Show()
    End Sub
End Class