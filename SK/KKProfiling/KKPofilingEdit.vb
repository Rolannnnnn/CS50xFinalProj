Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class KKPofilingEdit

    Dim connectionString As String = StringStorage.Addresser(StringStorage.KKProfilingDataBase)

    Private Sub KKPofilingEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT [Name] FROM Youth;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader
                Dim skip As Boolean = False

                While reader.Read
                    If Not skip Then
                        skip = True
                    Else
                        NameCB.Items.Add(reader.GetString(0))
                    End If
                End While
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        KKProfilingMainForm.Show()
        Close()
    End Sub

    Private Sub NameCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NameCB.SelectedIndexChanged
        Dim selectedPlayer As String = NameCB.SelectedItem.ToString()
        Dim sql As String = "SELECT Name, ContactNumber, Region, Province, City, Barangay, Age, Birthday, Sex, Civil, Classification, YouthAgeGroup, Email, Address, Education, Work, IsVoter, VotedLast, IsSKVoter, IsNationalVoter, AttendedKKAssembly, YesHowMany, NoWhy FROM [Youth] WHERE [Name] = @pname;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            Using cmd As New SQLiteCommand(sql, connection)
                cmd.Parameters.AddWithValue("@pname", selectedPlayer)
                Try
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        NameTB.Text = reader.GetString(0)
                        ContactTB.Text = reader.GetString(1)
                        RegionTB.Text = reader.GetString(2)
                        ProvinceTB.Text = reader.GetString(3)
                        CityTB.Text = reader.GetString(4)
                        BarangayTB.Text = reader.GetString(5)
                        AgeTB.Text = reader.GetInt32(6).ToString()
                        BirthdayDTP.Value = DateTime.Parse(reader.GetString(7))
                        SexCB.Text = reader.GetString(8)
                        CivilCB.Text = reader.GetString(9)
                        ClassificationCB.Text = reader.GetString(10)
                        YouthAgeGroupCB.Text = reader.GetString(11)
                        EmailTB.Text = reader.GetString(12)
                        AddressTB.Text = reader.GetString(13)
                        EducationCB.Text = reader.GetString(14)
                        WorkCB.Text = reader.GetString(15)
                        IsVoterCB.Text = reader.GetString(16)
                        VotedLastCB.Text = reader.GetString(17)
                        IsSKVoterCB.Text = reader.GetString(18)
                        IsNationalVoterCB.Text = reader.GetString(19)
                        AttendedSKAssCB.Text = reader.GetString(20)
                        IfYesCB.Text = reader.GetString(21)
                        IfNoCB.Text = reader.GetString(22)
                    End If
                    reader.Close()
                    Dim lbl() As Label = {NameLbl, ContactLbl, RegionLbl, ProvinceLbl, CityLbl, BarangayLbl, AgeLbl, BirthdayLbl, SexLbl, CivilLbl, ClassificationLbl, YouthAgeGroupLbl, EmailLbl, AddressLbl, EducationLbl, WorkLbl, IsVoterLbl, VotedLastLbl, IsSKVoterLbl, IsNationalVoterLbl, AttendedSKAssLbl, IfYesLbl, IfNoLbl}
                    Dim txt() As TextBox = {NameTB, ContactTB, RegionTB, ProvinceTB, CityTB, BarangayTB, AgeTB, EmailTB, AddressTB}
                    Dim cb() As ComboBox = {SexCB, CivilCB, ClassificationCB, YouthAgeGroupCB, EducationCB, WorkCB, IsVoterCB, VotedLastCB, IsSKVoterCB, IsNationalVoterCB, AttendedSKAssCB, IfYesCB, IfNoCB}

                    StringStorage.Visible(lbl, True)
                    StringStorage.Visible(txt, True)
                    StringStorage.Visible(cb, True)
                    BirthdayDTP.Visible = True
                    ConfirmBtn.Visible = True
                    NameCB.Visible = False
                    Label2.Visible = False
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click

        Dim email As String = EmailTB.Text.Trim()
        Dim newName As String = NameTB.Text
        Dim newContact As String = ContactTB.Text
        Dim newRegion As String = RegionTB.Text
        Dim newProvince As String = ProvinceTB.Text
        Dim newCity As String = CityTB.Text
        Dim newBarangay As String = BarangayTB.Text
        Dim newAge As String = AgeTB.Text
        Dim newBirthday As Date = BirthdayDTP.Value
        Dim newSex As String = SexCB.Text
        Dim newCivil As String = CivilCB.Text
        Dim newClassification As String = ClassificationCB.Text
        Dim newYouthAge As String = YouthAgeGroupCB.Text
        Dim newEmail As String = EmailTB.Text
        Dim newAddress As String = AddressTB.Text
        Dim newEducation As String = EducationCB.Text
        Dim newWork As String = WorkCB.Text
        Dim newIsVoter As String = IsVoterCB.Text
        Dim newVotedLast As String = VotedLastCB.Text
        Dim newIsSkVoter As String = IsSKVoterCB.Text
        Dim newIsNationalVoter As String = IsNationalVoterCB.Text
        Dim newAttendedKKAss As String = AttendedSKAssCB.Text
        Dim newIfYes As String = IfYesCB.Text
        Dim newIfNo As String = IfNoCB.Text

        If Not IsValidEmail(email) Then
            MessageBox.Show("Invalid email address. Please enter a valid email address.")
            Return
        End If

        Dim sql As String = "UPDATE [Youth] SET Name = @name, ContactNumber = @contact, Region = @region, Province = @province, City = @city, Barangay = @barangay, Age = @age, Birthday = @birthday, Sex = @sex, Civil = @civil, Classification = @classification, YouthAgeGroup = @youthage, Email = @email, Address = @address, Education = @education, Work = @work, IsVoter = @isvoter, VotedLast = @votedlast, IsSKVoter = @isskvoter, IsNationalVoter = @isnationalvoter, AttendedKKAssembly = @attendedkk, YesHowMany = @ifyes, NoWhy = @ifno WHERE Name = @selectedName;"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                cmd.Parameters.AddWithValue("@name", newName)
                cmd.Parameters.AddWithValue("@contact", newContact)
                cmd.Parameters.AddWithValue("@region", newRegion)
                cmd.Parameters.AddWithValue("@province", newProvince)
                cmd.Parameters.AddWithValue("@city", newCity)
                cmd.Parameters.AddWithValue("@barangay", newBarangay)
                cmd.Parameters.AddWithValue("@age", newAge)
                cmd.Parameters.AddWithValue("@birthday", newBirthday)
                cmd.Parameters.AddWithValue("@sex", newSex)
                cmd.Parameters.AddWithValue("@civil", newCivil)
                cmd.Parameters.AddWithValue("@classification", newClassification)
                cmd.Parameters.AddWithValue("@youthage", newYouthAge)
                cmd.Parameters.AddWithValue("@email", newEmail)
                cmd.Parameters.AddWithValue("@address", newAddress)
                cmd.Parameters.AddWithValue("@education", newEducation)
                cmd.Parameters.AddWithValue("@work", newWork)
                cmd.Parameters.AddWithValue("@isvoter", newIsVoter)
                cmd.Parameters.AddWithValue("@votedlast", newVotedLast)
                cmd.Parameters.AddWithValue("@isskvoter", newIsSkVoter)
                cmd.Parameters.AddWithValue("@isnationalvoter", newIsNationalVoter)
                cmd.Parameters.AddWithValue("@attendedkk", newAttendedKKAss)
                cmd.Parameters.AddWithValue("@ifyes", newIfYes)
                cmd.Parameters.AddWithValue("@ifno", newIfNo)
                cmd.Parameters.AddWithValue("@selectedName", NameCB.SelectedItem.ToString())
                Try
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If NameTB.Text = "" Or ContactTB.Text = "" Or RegionTB.Text = "" Or CityTB.Text = "" Or BarangayTB.Text = "" Or AgeTB.Text = "" Or SexCB.Text = "" Or CivilCB.Text = "" Or ClassificationCB.Text = "" Or YouthAgeGroupCB.Text = "" Or EmailTB.Text = "" Or AddressTB.Text = "" Or EducationCB.Text = "" Or WorkCB.Text = "" Or IsVoterCB.Text = "" Or VotedLastCB.Text = "" Or IsSKVoterCB.Text = "" Or IsNationalVoterCB.Text = "" Or AttendedSKAssCB.Text = "" Or IfYesCB.Text = "" Or IfNoCB.Text = "" Then
                        MessageBox.Show("Some fields are empty.")
                    ElseIf rowsAffected > 0 Then
                        MessageBox.Show("Changes saved successfully!")
                        KKProfilingMainForm.Show()
                        Close()
                    Else
                        MessageBox.Show("No changes were made.")
                        KKProfilingMainForm.Show()
                        Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub numChecker(sender As Object, e As KeyPressEventArgs) Handles ContactTB.KeyPress, AgeTB.KeyPress, CityTB.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub letterChecker(sender As Object, e As KeyPressEventArgs) Handles NameTB.KeyPress, ProvinceTB.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Dim pattern As String = "^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
        Return Regex.IsMatch(email, pattern)
    End Function

   
End Class