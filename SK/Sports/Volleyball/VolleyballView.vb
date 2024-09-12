Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports System.IO
Imports iText.Layout
Public Class VolleyballView
    Dim connectionString As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)
    Dim team As String = ""
    Dim player As String = ""
    Dim game As String = ""

    Private Sub VolleyballSched_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql1 As String = "SELECT * FROM [Team] WHERE [TeamID] > 0"
        Dim sql2 As String = "SELECT * FROM [Players] WHERE [PlayerID] > 0"
        Dim sql3 As String = "SELECT * FROM [Games] WHERE [GameID] > 0"
        Dim sql4 As String = "SELECT * FROM [Records] WHERE [RecordID] > 0"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql1, connection)
                Using adapter As New SQLiteDataAdapter(cmd)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
            Using cmd As New SQLiteCommand(sql2, connection)
                Using adapter As New SQLiteDataAdapter(cmd)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    DataGridView2.DataSource = datatable
                End Using
            End Using
            Using cmd As New SQLiteCommand(sql3, connection)
                Using adapter As New SQLiteDataAdapter(cmd)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    DataGridView3.DataSource = datatable
                End Using
            End Using
            Using cmd As New SQLiteCommand(sql4, connection)
                Using adapter As New SQLiteDataAdapter(cmd)
                    Dim datatable As New DataTable
                    adapter.Fill(datatable)
                    DataGridView4.DataSource = datatable
                End Using
            End Using
        End Using


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
        Tuple.Create("Teams - Volleyball League", DataGridView1),
        Tuple.Create("Players - Volleyball League", DataGridView2),
        Tuple.Create("Games - Volleyball League", DataGridView3),
        Tuple.Create("Player Stats - Volleyball League", DataGridView4)
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

