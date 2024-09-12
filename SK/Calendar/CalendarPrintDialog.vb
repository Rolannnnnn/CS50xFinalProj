Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.Layout
Imports System.IO

Public Class CalendarPrintDialog
    Dim d1 As DateTime
    Dim d2 As DateTime

    Private Sub PrintBttn_Click(sender As Object, e As EventArgs) Handles PrintBttn.Click
        d1 = DateTimePicker1.Value.Date
        d2 = DateTimePicker2.Value.Date

        If d1 > d2 Then
            FeedbackLbl.Text = "The second Date-Picker should be later than the first."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        Else
            Dim sql1 As String = "SELECT [EventID], [Name], [Description], [Date], [Time], [Venue], [NumberofParticipants] FROM [Events] WHERE strftime('%Y-%m-%d %H:%M:%S', [Date]) BETWEEN @date1 AND @date2 AND [EventID] > 0"

            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.EventHandlerDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@date1", d1)
                    command.Parameters.AddWithValue("@date2", d2.AddDays(1).AddSeconds(-1))
                    Using adapter As New SQLiteDataAdapter(command)
                        Dim datatable As New DataTable()
                        adapter.Fill(datatable)
                        DataGridView1.DataSource = datatable
                    End Using
                End Using
            End Using

            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Select a folder to save PDF files"

            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath
                ExportAllDataGridViews(folderPath)
            End If
        End If
    End Sub

    Private Sub ExportAllDataGridViews(folderPath As String)
        Dim dgvList As New List(Of Tuple(Of String, DataGridView)) From {
        Tuple.Create("Events - " & d1.ToString("MM-dd-yyyy") & " to " & d2.ToString("MM-dd-yyyy"), DataGridView1)
        }

        For Each dgvInfo In dgvList
            Dim fileName As String = Path.Combine(folderPath, $"{dgvInfo.Item1}.pdf")
            ExportToPDF(dgvInfo.Item1, dgvInfo.Item2, fileName)
        Next

        MessageBox.Show("Successfully exported 1 PDF!")
        Close()
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

    Private Sub CloseBttn_Click(sender As Object, e As EventArgs) Handles CloseBttn.Click
        Close()
    End Sub
End Class