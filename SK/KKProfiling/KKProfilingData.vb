Imports System.Data.SQLite
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.Layout
Imports System.IO
Imports iText.Kernel.Geom
Imports System.Windows.Forms
Public Class KKProfilingData

    Private Sub KKProfilingData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadKK("SELECT * FROM [Youth] WHERE [YouthID] > 0;")
    End Sub

    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        KKProfilingMainForm.Show()
        Close()
    End Sub

    Private Sub LoadKK(sql As String)
        Dim connectionString As String = "Data Source=Information.db;Version=3;"
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
    End Sub



    Private Sub LoadSearchKK(sql As String, searchText As String)
        Dim connectionString As String = "Data Source=Information.db;Version=3;"
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
                Using adapter As New SQLiteDataAdapter(command)
                    Dim datatable As New DataTable()
                    adapter.Fill(datatable)
                    DataGridView1.DataSource = datatable
                End Using
            End Using
        End Using
    End Sub



    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim searchText As String = TextBox1.Text.Trim()

        If Not String.IsNullOrEmpty(searchText) Then
            Dim sql As String = "SELECT * FROM [Youth] WHERE Name LIKE @searchText;"
            LoadSearchKK(sql, searchText)
        Else
            LoadKK("SELECT * FROM [Youth];")
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        TextBox1.Text = Nothing
        LoadKK("SELECT * FROM [Youth];")
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
        Tuple.Create("KK Profiling Data", DataGridView1)
    }

        For Each dgvInfo In dgvList
            Dim fileName As String = System.IO.Path.Combine(folderPath, $"{dgvInfo.Item1}.pdf")
            Export(dgvInfo.Item1, dgvInfo.Item2, fileName)
        Next

        MessageBox.Show("Successfully exported PDF!")
    End Sub

    Private Sub Export(text As String, dgv As DataGridView, filepath As String)
        Dim writer As New PdfWriter(filepath)
        Dim pdf As New PdfDocument(writer)
        Dim document As New Document(pdf)

        ' Adjust the page size to accommodate the table width
        Dim pageSize As New PageSize(PageSize.A4) ' A4 portrait
        pdf.SetDefaultPageSize(pageSize)

        ' Define the number of columns per page (excluding the YouthID column)
        Const columnsPerPage As Integer = 6

        ' Find the index of the YouthID column
        Dim youthIdColumnIndex As Integer = -1
        For j As Integer = 0 To dgv.Columns.Count - 1
            If dgv.Columns(j).Name = "YouthID" Then
                youthIdColumnIndex = j
                Exit For
            End If
        Next

        ' Ensure the YouthID column exists
        If youthIdColumnIndex = -1 Then
            Throw New ArgumentException("YouthID column not found in the DataGridView.")
        End If

        ' Calculate the number of chunks of columns per page
        Dim totalColumns As Integer = dgv.Columns.Count - 1 ' Exclude YouthID from the count
        Dim chunks As Integer = Math.Ceiling(totalColumns / columnsPerPage)

        ' Loop through each chunk of columns
        For i As Integer = 0 To chunks - 1
            Dim startColumn As Integer = i * columnsPerPage
            Dim endColumn As Integer = Math.Min(startColumn + columnsPerPage, totalColumns)

            ' Create an array of column widths for the table
            Dim columnWidths As Single() = Enumerable.Repeat(1.0F, endColumn - startColumn + 1).ToArray() ' +1 for YouthID

            ' Create a table with the calculated number of columns
            Dim table As New Table(UnitValue.CreatePercentArray(columnWidths))
            table.UseAllAvailableWidth()

            ' Add YouthID column header
            Dim youthIdColumn As DataGridViewColumn = dgv.Columns(youthIdColumnIndex)
            Dim headerCell As New Cell()
            headerCell.Add(New Paragraph(youthIdColumn.HeaderText).SetBold())
            table.AddHeaderCell(headerCell)

            ' Add other column headers
            For j As Integer = startColumn To endColumn - 1
                Dim column As DataGridViewColumn = dgv.Columns(j + 1) ' Skip YouthID, start from next column
                If column.Index <> youthIdColumnIndex Then ' Skip YouthID, it's already added
                    headerCell = New Cell()
                    headerCell.Add(New Paragraph(column.HeaderText).SetBold())
                    table.AddHeaderCell(headerCell)
                End If
            Next

            ' Add table rows
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    ' Add YouthID cell
                    Dim youthIdCell As DataGridViewCell = row.Cells(youthIdColumnIndex)
                    Dim cellValue As String = If(youthIdCell.Value IsNot Nothing, youthIdCell.Value.ToString(), String.Empty)
                    table.AddCell(New Cell().Add(New Paragraph(cellValue)))

                    ' Add other cells
                    For j As Integer = startColumn To endColumn - 1
                        Dim cell As DataGridViewCell = row.Cells(j + 1) ' Skip YouthID, start from next column
                        If cell.ColumnIndex <> youthIdColumnIndex Then ' Skip YouthID, it's already added
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
End Class
