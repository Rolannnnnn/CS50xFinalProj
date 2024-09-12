Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports System.IO

Public Class BasketBallView
    Dim team As String = ""
    Dim member As String = ""
    Dim game As String = ""


    Private Sub ViewTeams_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "DataSource=SportsBasketballDatabase.db;Version=3;"
        Dim connectionKK As String = "DataSource=Information.db;Version=3;"
        Dim sql1 As String = "SELECT * FROM [Teams] LIMIT 100000 OFFSET 1;"
        Dim sql2 As String = "SELECT MemberId, YouthID, [Team Name], [Jersey Number], Position, Division, Height, Weight FROM [Members] LIMIT 100000 OFFSET 1;"
        Dim sql3 As String = "SELECT * FROM [Games] LIMIT 100000 OFFSET 1;"
        Dim sql4 As String = "SELECT * FROM [Records] LIMIT 100000 OFFSET 1;"

        LoadDataGridView(sql1, connectionString, DataGridView1)
        LoadWithNames(sql2, connectionString, connectionKK, DataGridView2)
        LoadDataGridView(sql3, connectionString, DataGridView3)
        LoadDataGridView(sql4, connectionString, DataGridView4)
    End Sub

    Private Sub LoadDataGridView(query As String, connectionString As String, gridView As DataGridView)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(query, connection)
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    gridView.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub

    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        BasketballMainForm.Show()
        Close()
    End Sub

    Private Sub LoadWithNames(membersQuery As String, membersConnectionString As String, youthConnectionString As String, gridView As DataGridView)
        Dim membersTable As New DataTable()

        Using connection As New SQLiteConnection(membersConnectionString)
            connection.Open()
            Using command As New SQLiteCommand(membersQuery, connection)
                Using adapter As New SQLiteDataAdapter(command)
                    adapter.Fill(membersTable)
                End Using
            End Using
        End Using


        Dim playerNameColumn As New DataColumn("PlayerName", GetType(String))
        membersTable.Columns.Add(playerNameColumn)
        membersTable.Columns("PlayerName").SetOrdinal(1)
        Using connection As New SQLiteConnection(youthConnectionString)
            connection.Open()
            For Each row As DataRow In membersTable.Rows
                Dim youthID As String = row("YouthID").ToString()
                Dim nameQuery As String = "SELECT Name FROM Youth WHERE YouthID = @YouthID"
                Using command As New SQLiteCommand(nameQuery, connection)
                    command.Parameters.AddWithValue("@YouthID", youthID)
                    Dim playerName As Object = command.ExecuteScalar()
                    If playerName IsNot Nothing Then
                        row("PlayerName") = playerName.ToString()
                    Else
                        row("PlayerName") = "Unknown"
                    End If
                End Using
            Next
        End Using
        gridView.DataSource = membersTable
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim folderBrowserDialog As New FolderBrowserDialog()
        folderBrowserDialog.Description = "Select a folder to save PDF files"

        If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = folderBrowserDialog.SelectedPath
            ExportAllDataGridViews(folderPath)
        End If
    End Sub

    Private Sub ExportAllDataGridViews(folderPath As String)
        ' Define the DataGridViews and their respective titles
        Dim dgvList As New List(Of Tuple(Of String, DataGridView)) From {
        Tuple.Create("Teams - Basketball League", DataGridView1),
        Tuple.Create("Players - Basketball League", DataGridView2),
        Tuple.Create("Games - Basketball League", DataGridView3),
        Tuple.Create("Player Stats - Basketball League", DataGridView4)
    }

        For Each dgvInfo In dgvList
            Dim fileName As String = Path.Combine(folderPath, $"{dgvInfo.Item1}.pdf")
            Export(dgvInfo.Item1, dgvInfo.Item2, fileName)
        Next

        MessageBox.Show("Successfully exported 4 PDFs!")
    End Sub

    Private Sub Export(text As String, dgv As DataGridView, filepath As String)
        Dim writer As New PdfWriter(filepath)
        Dim pdf As New PdfDocument(writer)
        Dim document As New Document(pdf)
        Dim table As New Table(dgv.Columns.Count)
        table.SetWidth(UnitValue.CreatePercentValue(100))
        For Each column As DataGridViewColumn In dgv.Columns
            Dim headerCell As New Cell()
            headerCell.Add(New Paragraph(column.HeaderText))
            headerCell.SetBold()
            table.AddHeaderCell(headerCell)
        Next
        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                For Each cell As DataGridViewCell In row.Cells
                    Dim cellValue As String = ""
                    If cell.Value IsNot Nothing AndAlso TypeOf cell.Value Is DateTime Then
                        ' Format the DateTime value to only include the date
                        cellValue = CType(cell.Value, DateTime).ToString("MM/dd/yyyy")
                    ElseIf cell.Value IsNot Nothing Then
                        ' Handle other types of values if needed
                        cellValue = cell.Value.ToString()
                    End If
                    table.AddCell(New Cell().Add(New Paragraph(cellValue)))
                Next
            End If
        Next

        Dim titleFont As PdfFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)
        document.Add(New Paragraph(text).SetFont(titleFont).SetFontSize(20))
        document.Add(New Paragraph(" "))
        document.Add(New Paragraph("Extracted on: " & DateTime.Now.ToString("MM/dd/yyyy; HH:mm:ss")).SetFontSize(10))
        document.Add(table)
        document.Close()
    End Sub
End Class
