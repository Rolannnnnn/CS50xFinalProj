Imports System.IO
Imports System.Text.RegularExpressions

Module StringStorage

    'Addresses
    Public EventHandlerDatabase As String = "EventHandler.db"
    Public SportsBasketballDatabase As String = "SportsBasketballDatabase.db"
    Public SportsVolleyballDatabase As String = "SportsVolleyballDatabase.db"
    Public SportsEsportsDatabase As String = "SportsESportsDatabase.db"
    Public KKProfilingDatabase As String = "Information.db"
    Public BudgetDatabase As String = "Budget.db"
    Public SecurityDatabase As String = "Security.db"

    'For generating data source using an address
    Public Function Addresser(address As String) As String
        Dim returning As String = "DataSource=" & address & ";Version=3;"
        Return returning
    End Function

    'For checking strings, returns an empty string if there's no error, otherwise returns the error message
    'Checking if a field is empty or if the input exceeds the max length
    Public Function CheckString(input As String, length As Integer) As String
        Dim result As String = ""
        If String.IsNullOrWhiteSpace(input) Then
            result = "The field is empty."
        ElseIf input.Length > length Then
            result = "Keep it within " & length & " characters."
        End If
        Return result
    End Function

    Public Function CheckString(tb() As TextBox, cb() As ComboBox, length As Integer) As String
        For Each i In tb
            If String.IsNullOrWhiteSpace(i.Text) Then
                Return "The field is empty."
            ElseIf i.Text.Length > length Then
                Return "Keep it within " & length & " characters."
            End If
        Next

        For Each i In cb
            If String.IsNullOrWhiteSpace(i.Text) Then
                Return "The field is empty."
            ElseIf i.Text.Length > length Then
                Return "Keep it within " & length & " characters."
            End If
        Next

        Return ""
    End Function

    'Shortcut for delays, also allows for simultaneous delaying
    Public Async Sub ShowLabelsForThreeSeconds(label As Label)
        label.Visible = True
        Await Task.Delay(3000)
        label.Visible = False
    End Sub

    'Clearing fields of textboxes in one go
    Public Sub ClearFields(tb() As TextBox)
        For Each textb As TextBox In tb
            textb.Text = ""
        Next
    End Sub

    'Clearing fields of textboxes and comboboxes in one go
    Public Sub ClearFields(cb() As ComboBox)
        For Each combob As ComboBox In cb
            combob.SelectedItem = Nothing
        Next
    End Sub

    'Setting the visibility to a defined setting
    Public Sub Visible(lbl() As Label, visible As Boolean)
        For Each label As Label In lbl
            label.Visible = visible
        Next
    End Sub

    Public Sub Visible(cb() As ComboBox, visible As Boolean)
        For Each combo As ComboBox In cb
            combo.Visible = visible
        Next
    End Sub

    Public Sub Visible(txt() As TextBox, visible As Boolean)
        For Each tb As TextBox In txt
            tb.Visible = visible
        Next
    End Sub

    Public Sub Visible(bttn() As Button, visible As Boolean)
        For Each btn As Button In bttn
            btn.Visible = visible
        Next
    End Sub

    'Checks if some comboboxes have same values
    Public Function Similar(cb() As ComboBox) As Boolean
        For i As Integer = 0 To cb.Length - 1
            For j As Integer = i + 1 To cb.Length - 1
                If cb(i).Text = cb(j).Text Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    'Checks if text is only numbers
    Public Function IsNumber(text As String) As Boolean
        If Regex.IsMatch(text, "^[0-9]+$") Then
            Return True
        End If
        Return False
    End Function

    Public Function IsNumber(text() As TextBox) As Boolean
        For Each i In text
            If Not Regex.IsMatch(i.Text, "^[0-9]+$") Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function IsDecimal(text As String) As Boolean
        If Regex.IsMatch(text, "^\d+(\.\d+)?$") Then
            Return True
        End If
        Return False
    End Function

    Public Function IsDecimal(text() As TextBox) As Boolean
        For Each i In text
            If Not Regex.IsMatch(i.Text, "^\d+(\.\d+)?$") Then
                Return False
            End If
        Next
        Return True
    End Function

    Friend Function SportsBasketballDatabaseDatabase() As String
        Throw New NotImplementedException()
    End Function
End Module