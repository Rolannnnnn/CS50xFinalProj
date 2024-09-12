Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.Layout
Imports System.IO

Public Class ESportsView

    Private Sub ESportsViewTeams_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionStringSports As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)
        Dim connectionStringKK As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)
        Dim sqlTeams As String = "SELECT * FROM [Teams] WHERE TeamId > 0;"
        Dim sqlPlayers As String = "SELECT * FROM [Players] WHERE PlayerId > 0"
        Dim sqlGames As String = "SELECT * FROM [Games] WHERE GameId > 0"
        Dim sqlRecords As String = "SELECT [RecordId], [PlayerName], [Position], [Kills], [Deaths], [Assists], [GameId] FROM [Records] WHERE RecordId > 0"

        Using connectionSports As New SQLiteConnection(connectionStringSports),
          connectionKK As New SQLiteConnection(connectionStringKK)
            connectionSports.Open()
            connectionKK.Open()

            Using commandTeams As New SQLiteCommand(sqlTeams, connectionSports),
              adapterTeams As New SQLiteDataAdapter(commandTeams)
                Dim dataTableTeams As New DataTable()
                adapterTeams.Fill(dataTableTeams)
                DataGridView1.DataSource = dataTableTeams
            End Using

            Using commandTeams As New SQLiteCommand(sqlPlayers, connectionSports),
              adapterTeams As New SQLiteDataAdapter(commandTeams)
                Dim dataTableTeams As New DataTable()
                adapterTeams.Fill(dataTableTeams)
                DataGridView2.DataSource = dataTableTeams
            End Using

            Using commandTeams As New SQLiteCommand(sqlGames, connectionSports),
              adapterTeams As New SQLiteDataAdapter(commandTeams)
                Dim dataTableTeams As New DataTable()
                adapterTeams.Fill(dataTableTeams)
                DataGridView3.DataSource = dataTableTeams
            End Using

            Using commandTeams As New SQLiteCommand(sqlRecords, connectionSports),
              adapterTeams As New SQLiteDataAdapter(commandTeams)
                Dim dataTableTeams As New DataTable()
                adapterTeams.Fill(dataTableTeams)
                DataGridView4.DataSource = dataTableTeams
            End Using

        End Using

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
        Dim dgvList As New List(Of Tuple(Of String, DataGridView)) From {
        Tuple.Create("Teams - Esports League", DataGridView1),
        Tuple.Create("Players - Esports League", DataGridView2),
        Tuple.Create("Games - Esports League", DataGridView3),
        Tuple.Create("Player Stats - Esports League", DataGridView4)
    }

        For Each dgvInfo In dgvList
            Dim fileName As String = Path.Combine(folderPath, $"{dgvInfo.Item1}.pdf")
            ExportToPDF(dgvInfo.Item1, dgvInfo.Item2, fileName)
        Next

        MessageBox.Show("Successfully exported 4 PDFs!")
    End Sub

    Private Sub ExportToPDF(title As String, dgv As DataGridView, filePath As String)
        Try
            Dim writer As New PdfWriter(filePath)
            Dim pdf As New PdfDocument(writer)
            Dim document As New Document(pdf)
            Dim table As New Table(dgv.Columns.Count)

            table.SetWidth(UnitValue.CreatePercentValue(100))

            ' Add headers
            For Each column As DataGridViewColumn In dgv.Columns
                Dim headerCell As New Cell()
                headerCell.Add(New Paragraph(column.HeaderText))
                headerCell.SetBold()
                table.AddHeaderCell(headerCell)
            Next

            ' Add data rows
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

            ' Add title
            Dim titleFont As PdfFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)
            document.Add(New Paragraph(title).SetFont(titleFont).SetFontSize(20))
            document.Add(New Paragraph(" "))
            document.Add(New Paragraph("Extracted on: " & DateTime.Now.ToString("MM/dd/yyyy; HH:mm:ss")).SetFontSize(10))
            document.Add(table)
            document.Close()
        Catch ex As Exception
            MessageBox.Show($"Error exporting {title} to PDF: {ex.Message}")
        End Try
    End Sub
End Class
