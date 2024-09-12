Module FunctionStorage
    Public Function CheckString(input As String, length As Integer) As String
        Dim result As String = ""
        If String.IsNullOrWhiteSpace(input) Then
            result = "The field is empty."
        ElseIf input.Length > length Then
            result = "Keep it within " & length & " characters."
        End If
        Return result
    End Function

End Module
