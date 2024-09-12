Public Class KKProfilingConfirmation


    Private _name As String
    Private _contact As String
    Private _date As Date


    Private Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso
           Not String.IsNullOrWhiteSpace(TextBox2.Text) AndAlso
           DateTimePicker1.Value <> DateTime.MinValue AndAlso
           StringStorage.IsNumber(TextBox2.Text) AndAlso
           TextBox2.Text.StartsWith("09") AndAlso
           CheckBox1.Checked Then

            _name = TextBox1.Text
            _contact = TextBox2.Text
            _date = DateTimePicker1.Value.Date

            Dim demographicForm As New KKProfilingnDemographic(_name, _contact, _date)
            demographicForm.Show()
            Hide()
        Else
            If Not StringStorage.IsNumber(TextBox2.Text) OrElse Not TextBox2.Text.StartsWith("09") Then
                MessageBox.Show("Contact Number is on the wrong format.", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please fill in all required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs)
        TextBox1.Text = ""
        TextBox2.Text = ""
        DateTimePicker1.Value = DateTime.Now
        CheckBox1.Checked = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        KKProfilingForm.Show()
        Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        KKProfilingMainForm.Show()
        Close()
    End Sub
End Class
