Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.Layout
Imports iText.Kernel.Geom

Public Class SecurityPrintDialog

    Dim min As Integer = 1
    Dim max As Integer

    Private Sub SecurityPrintDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlmax As String = "SELECT MAX(LogID) FROM [Logs]"
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
            connection.Open()
            Using command As New SQLiteCommand(sqlmax, connection)
                max = Integer.Parse(command.ExecuteScalar)
            End Using
        End Using

        FromTxtBox.Text = min
        ToTxtBox.Text = max
    End Sub

    Private Sub PrintBttn_Click(sender As Object, e As EventArgs) Handles PrintBttn.Click
        If String.IsNullOrWhiteSpace(FromTxtBox.Text) Or String.IsNullOrWhiteSpace(ToTxtBox.Text) Then
            FeedbackLbl.Text = "Some fields are empty"
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        ElseIf Not IsNumber(FromTxtBox.Text) Or Not IsNumber(ToTxtBox.Text) Then
            FeedbackLbl.Text = "Some fields are non-integer"
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        ElseIf Integer.Parse(FromTxtBox.Text) < min Or Integer.Parse(ToTxtBox.Text) > max Or Integer.Parse(FromTxtBox.Text) > Integer.Parse(ToTxtBox.Text) > max Then
            FeedbackLbl.Text = "Invalid range"
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        Else
            min = FromTxtBox.Text
            max = ToTxtBox.Text
            Dim connectionString As String = StringStorage.Addresser(StringStorage.SecurityDatabase)
            Dim sql As String = "SELECT * FROM Logs WHERE [LogID] >= @min AND [LogID] <= @max"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@min", min)
                    command.Parameters.AddWithValue("@max", max)
                    Using adapter As New SQLiteDataAdapter(command)
                        Dim datatable As New DataTable()
                        adapter.Fill(datatable)
                        DataGridView1.DataSource = datatable
                    End Using
                End Using
            End Using

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Select a folder to save PDF files"

            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim folderPath As String = folderBrowserDialog.SelectedPath
                ExportAllDataGridViews(folderPath)
            End If
        End If
    End Sub

    Private Sub ExportAllDataGridViews(folderPath As String)
        ' Define the DataGridViews and their respective titles
        Dim dgvList As New List(Of Tuple(Of String, DataGridView)) From {
        Tuple.Create("Security Logs", DataGridView1)
    }

        For Each dgvInfo In dgvList
            Dim fileName As String = System.IO.Path.Combine(folderPath, $"{dgvInfo.Item1}.pdf")
            Export(dgvInfo.Item1, dgvInfo.Item2, fileName)
        Next

        MessageBox.Show("Successfully exported PDF!")
        Close()
    End Sub

    Private Sub Export(text As String, dgv As DataGridView, filepath As String)
        Dim writer As New PdfWriter(filepath)
        Dim pdf As New PdfDocument(writer)
        Dim document As New Document(pdf)

        ' Adjust the page size to accommodate the table width
        Dim pageSize As New PageSize(pageSize.A4) ' A4 portrait
        pdf.SetDefaultPageSize(pageSize)

        ' Define the number of columns per page (excluding the LogID column)
        Const columnsPerPage As Integer = 4

        ' Find the index of the LogID column
        Dim LogIDColumnIndex As Integer = -1
        For j As Integer = 0 To dgv.Columns.Count - 1
            If dgv.Columns(j).Name = "LogID" Then
                LogIDColumnIndex = j
                Exit For
            End If
        Next

        ' Ensure the LogID column exists
        If LogIDColumnIndex = -1 Then
            Throw New ArgumentException("LogID column not found in the DataGridView.")
        End If

        ' Calculate the number of chunks of columns per page
        Dim totalColumns As Integer = dgv.Columns.Count - 1 ' Exclude LogID from the count
        Dim chunks As Integer = Math.Ceiling(totalColumns / columnsPerPage)

        ' Loop through each chunk of columns
        For i As Integer = 0 To chunks - 1
            Dim startColumn As Integer = i * columnsPerPage
            Dim endColumn As Integer = Math.Min(startColumn + columnsPerPage, totalColumns)

            ' Create an array of column widths for the table
            Dim columnWidths As Single() = Enumerable.Repeat(1.0F, endColumn - startColumn + 1).ToArray() ' +1 for LogID

            ' Create a table with the calculated number of columns
            Dim table As New Table(UnitValue.CreatePercentArray(columnWidths))
            table.UseAllAvailableWidth()

            ' Add LogID column header
            Dim LogIDColumn As DataGridViewColumn = dgv.Columns(LogIDColumnIndex)
            Dim headerCell As New Cell()
            headerCell.Add(New Paragraph(LogIDColumn.HeaderText).SetBold())
            table.AddHeaderCell(headerCell)

            ' Add other column headers
            For j As Integer = startColumn To endColumn - 1
                Dim column As DataGridViewColumn = dgv.Columns(j + 1) ' Skip LogID, start from next column
                If column.Index <> LogIDColumnIndex Then ' Skip LogID, it's already added
                    headerCell = New Cell()
                    headerCell.Add(New Paragraph(column.HeaderText).SetBold())
                    table.AddHeaderCell(headerCell)
                End If
            Next

            ' Add table rows
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    ' Add LogID cell
                    Dim LogIDCell As DataGridViewCell = row.Cells(LogIDColumnIndex)
                    Dim cellValue As String = If(LogIDCell.Value IsNot Nothing, LogIDCell.Value.ToString(), String.Empty)
                    table.AddCell(New Cell().Add(New Paragraph(cellValue)))

                    ' Add other cells
                    For j As Integer = startColumn To endColumn - 1
                        Dim cell As DataGridViewCell = row.Cells(j + 1) ' Skip LogID, start from next column
                        If cell.ColumnIndex <> LogIDColumnIndex Then ' Skip LogID, it's already added
                            cellValue = If(cell.Value IsNot Nothing, cell.Value.ToString(), String.Empty)
                            If TypeOf cell.Value Is DateTime Then
                                cellValue = CType(cell.Value, DateTime).ToString("MM/dd/yyyy")
                            End If
                            table.AddCell(New Cell().Add(New Paragraph(cellValue)))
                        End If
                    Next
                End If
            Next

            ' Add the title and table to the document
            If i = 0 Then
                Dim titleFont As PdfFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)
                document.Add(New Paragraph(text).SetFont(titleFont).SetFontSize(20))
                document.Add(New Paragraph(" "))
                document.Add(New Paragraph("Extracted on: " & DateTime.Now.ToString("MM/dd/yyyy; HH:mm:ss")).SetFontSize(10))
            End If
            document.Add(table)

            ' Add a new page if there are more chunks to process
            If i < chunks - 1 Then
                document.Add(New AreaBreak(AreaBreakType.NEXT_PAGE))
            End If
        Next

        ' Close the document
        document.Close()
    End Sub

    Private Sub CloseBttn_Click(sender As Object, e As EventArgs) Handles CloseBttn.Click
        Close()
    End Sub

    Private Sub FromTxtBox_TextChanged(sender As Object, e As EventArgs) Handles FromTxtBox.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ToTxtBox_TextChanged(sender As Object, e As EventArgs) Handles ToTxtBox.TextChanged

    End Sub
End Class