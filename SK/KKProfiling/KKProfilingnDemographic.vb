Public Class KKProfilingnDemographic

    ' Other variables from KKProfilingConfirmation
    Private _name As String
    Private _contact As String
    Private _date As Date

    ' Additional variables for this form
    Private _region As String
    Private _province As String
    Private _city As String
    Private _barangay As String
    Private _age As String
    Private _email As String
    Private _address As String
    Private _sex As String
    Private _civil As String
    Private _classification As String
    Private _youthage As String
    Private _education As String
    Private _birthday As Date

    ' Constructor to receive data from KKProfilingConfirmation
    Public Sub New(name As String, contact As String, [date] As Date)
        InitializeComponent()
        _name = name
        _contact = contact
        _date = [date]
    End Sub



    Private Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click

        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox2.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox3.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox4.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox5.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox7.Text) AndAlso
       Not String.IsNullOrWhiteSpace(TextBox8.Text) AndAlso
       ComboBox1.SelectedIndex <> -1 AndAlso
       ComboBox2.SelectedIndex <> -1 AndAlso
       ComboBox3.SelectedIndex <> -1 AndAlso
       ComboBox4.SelectedIndex <> -1 AndAlso
       DateTimePicker1.Value <> DateTime.MinValue AndAlso
       Integer.TryParse(TextBox5.Text, _age) AndAlso
       TextBox7.Text.EndsWith("@gmail.com") Then


            _region = TextBox1.Text
            _province = TextBox2.Text
            _city = TextBox3.Text
            _barangay = TextBox4.Text
            _email = TextBox7.Text
            _address = TextBox8.Text
            _civil = ComboBox2.Text
            _sex = ComboBox1.Text
            _classification = ComboBox3.Text
            _youthage = ComboBox4.Text
            _education = ComboBox5.Text
            _birthday = DateTimePicker1.Value.Date


            Dim demographicForm2 As New KKProfilingnDemogrpahic2(_name, _contact, _date, _region, _province, _city, _barangay, _age, _sex, _email, _address, _civil, _classification, _youthage, _education, _birthday)
            demographicForm2.Show()
            Hide()
        Else
            If Not TextBox7.Text.EndsWith("@gmail.com") Then
                MessageBox.Show("Email must be on Gmail format.", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf Not Integer.TryParse(TextBox5.Text, _age) Then
                MessageBox.Show("Age must be a number.", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Please fill in all required fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        KKProfilingConfirmation.Show()
        Hide()
    End Sub
End Class
