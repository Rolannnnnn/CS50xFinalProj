Imports System.Data.SQLite

Public Class KKProfilingnDemogrpahic2

    Private _name As String
    Private _contact As String
    Private _date As Date
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

    Public Sub New(name As String, contact As String, [date] As Date, region As String, province As String, city As String, barangay As String, age As String, sex As String, email As String, address As String, civil As String, classification As String, youthage As String, education As String, birthday As Date)
        InitializeComponent()
        _name = name
        _contact = contact
        _date = [date]
        _region = region
        _province = province
        _city = city
        _barangay = barangay
        _age = age
        _email = email
        _address = address
        _sex = sex
        _civil = civil
        _classification = classification
        _youthage = youthage
        _education = education
        _birthday = birthday
    End Sub

    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        Dim demographicForm As New KKProfilingnDemographic(_name, _contact, _date)
        demographicForm.Show()
        Hide()
    End Sub

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        If ComboBox1.SelectedIndex = -1 OrElse
       ComboBox2.SelectedIndex = -1 OrElse
       ComboBox3.SelectedIndex = -1 OrElse
       ComboBox4.SelectedIndex = -1 OrElse
       ComboBox5.SelectedIndex = -1 OrElse
       ComboBox6.SelectedIndex = -1 OrElse
       ComboBox7.SelectedIndex = -1 OrElse
       ComboBox8.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all ComboBoxes.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim sql1 As String = "SELECT MAX(YouthId) FROM [Youth]"
        Dim sql2 As String = "INSERT INTO Youth VALUES (@id, @name, @contact, @date, @region, @province, @city, @barangay, @age, @birthday, @sex, @civil, @classification, @YouthAge, @Email, @Address, @Education, @Work, @Voter, @Vote, @SKVoter, @NVoter, @Que, @Yes, @No)"
        Dim connectionString As String = StringStorage.Addresser(StringStorage.KKProfilingDataBase)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim maxid As Integer = 0
            Using command As New SQLiteCommand(sql1, connection)
                Dim result = command.ExecuteScalar()
                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                    maxid = Convert.ToInt32(result)
                End If
            End Using

            Using command As New SQLiteCommand(sql2, connection)
                command.Parameters.AddWithValue("@id", maxid + 1)
                command.Parameters.AddWithValue("@name", _name)
                command.Parameters.AddWithValue("@contact", _contact)
                command.Parameters.AddWithValue("@date", _date)
                command.Parameters.AddWithValue("@region", _region)
                command.Parameters.AddWithValue("@province", _province)
                command.Parameters.AddWithValue("@city", _city)
                command.Parameters.AddWithValue("@barangay", _barangay)
                command.Parameters.AddWithValue("@age", _age)
                command.Parameters.AddWithValue("@birthday", _birthday)
                command.Parameters.AddWithValue("@sex", _sex)
                command.Parameters.AddWithValue("@civil", _civil)
                command.Parameters.AddWithValue("@classification", _classification)
                command.Parameters.AddWithValue("@YouthAge", _youthage)
                command.Parameters.AddWithValue("@Email", _email)
                command.Parameters.AddWithValue("@Address", _address)
                command.Parameters.AddWithValue("@Education", _education)

                command.Parameters.AddWithValue("@Work", ComboBox1.SelectedItem)
                command.Parameters.AddWithValue("@Voter", ComboBox2.SelectedItem)
                command.Parameters.AddWithValue("@Vote", ComboBox3.SelectedItem)
                command.Parameters.AddWithValue("@SKVoter", ComboBox4.SelectedItem)
                command.Parameters.AddWithValue("@NVoter", ComboBox5.SelectedItem)
                command.Parameters.AddWithValue("@Que", ComboBox6.SelectedItem)
                command.Parameters.AddWithValue("@Yes", ComboBox7.SelectedItem)
                command.Parameters.AddWithValue("@No", ComboBox8.SelectedItem)

                command.ExecuteNonQuery()
            End Using
        End Using


        MessageBox.Show("Data submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim doneForm As New KKProfilingDone()
        KKProfilingMainForm.Show()
        Me.Close()
    End Sub


    Private Sub Clear_Click(sender As Object, e As EventArgs)

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
        ComboBox6.SelectedIndex = -1
        ComboBox7.SelectedIndex = -1
        ComboBox8.SelectedIndex = -1
    End Sub


End Class
