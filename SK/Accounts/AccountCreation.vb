Imports System.Data.SQLite
Imports System.Net
Imports System.Net.Mail
Imports Guna.UI2.WinForms.Suite
Public Class AccountCreation
    Dim confirmed As Boolean = False
    Dim gen As System.Random = New System.Random()
    Dim code As Integer = gen.Next(100000, 999999)
    Dim sentcode As Integer = code

    Private Function CheckStrings() As Boolean
        Dim uniqueUsername As Boolean = True
        Dim uniqueEmail As Boolean = True

        Dim sql As String = "SELECT [Username] FROM Users WHERE [Username] = @un"
        Dim sql1 As String = "SELECT [Username] FROM Users WHERE [Email] = @email"
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
            connection.Open()
            Using Command As New SQLiteCommand(sql, connection)
                Command.Parameters.AddWithValue("@un", UsernameTB.Text)
                Using reader As SQLiteDataReader = Command.ExecuteReader
                    If reader.Read Then
                        uniqueUsername = False
                    End If
                End Using
            End Using

            Using command As New SQLiteCommand(sql1, connection)
                command.Parameters.AddWithValue("@email", EmailTB.Text)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        uniqueEmail = False
                    End If
                End Using
            End Using
        End Using

        FeedbackLbl.ForeColor = Color.Red
        If UsernameTB.Text = "" Or PasswordTB.Text = "" Or EmailTB.Text = "" Then
            FeedbackLbl.Text = "Some fields are empty."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return False
        End If

        If Not uniqueUsername Then
            FeedbackLbl.Text = "Username already taken."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return False
        End If

        If Not uniqueEmail Then
            FeedbackLbl.Text = "Email is already being used by another user."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return False
        End If

        If PasswordTB.Text.Length < 8 Then
            FeedbackLbl.Text = "Password is too short."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return False
        End If

        If Not EmailTB.Text.EndsWith("@gmail.com") Then
            FeedbackLbl.Text = "Invalid gmail email."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return False
        End If

        Return True
    End Function

    Private Sub sendEmail(address As String, code As Integer)
        Try
            Dim fromaddress As New MailAddress("tanza1sk@gmail.com", "SK Tanza 1")
            Dim toaddress As New MailAddress(address)
            Dim subject As String = "SK Tanza 1 System - Account Creation - Verification"
            Dim body As String = "To complete your account creation, use this OTP: " & code & ". Thank you." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "This is a system-generated email. No need to reply."

            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New NetworkCredential("tanza1sk@gmail.com", "tagp dqjw yfwz yepo")
            Dim message As New MailMessage(fromaddress, toaddress)
            message.Subject = subject
            message.Body = body

            smtp.Send(message)

        Catch ex As Exception
            FeedbackLbl.Text = "Error sending OTP email. Try to recheck every info and try again. " & ex.Message
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not confirmed Then
            If CheckStrings() Then
                confirmed = True
                UsernameTB.Enabled = False
                PasswordTB.Enabled = False
                EmailTB.Enabled = False
                OTPLbl.Visible = True
                OTPTB.Visible = True
                sendEmail(EmailTB.Text, sentcode)
                FeedbackLbl.Text = "Input the OTP in the field to complete the account creation"
                FeedbackLbl.ForeColor = Color.Black
                FeedbackLbl.Visible = True
            End If
        Else
            If CheckStrings() Then
                If String.IsNullOrWhiteSpace(OTPTB.Text) Then
                    FeedbackLbl.Text = "OTP field is empty."
                    FeedbackLbl.ForeColor = Color.Red
                    StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
                ElseIf Not OTPTB.Text = sentcode.ToString Then
                    FeedbackLbl.Text = "Incorrect OTP."
                    FeedbackLbl.ForeColor = Color.Red
                    StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
                Else
                    Dim sql1 As String = "INSERT INTO [Users] VALUES (@id, @un, @pw, @email, @attempts, @locked)"
                    Dim sql2 As String = "SELECT MAX(UserID) FROM [Users]"
                    Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
                    Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
                    Dim maxid As Integer
                    Dim maxidlog As Integer

                    Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                        connection.Open()
                        Using command As New SQLiteCommand(sql2, connection)
                            maxid = Integer.Parse(command.ExecuteScalar)
                        End Using

                        Using command As New SQLiteCommand(sql1, connection)
                            command.Parameters.AddWithValue("@id", maxid + 1)
                            command.Parameters.AddWithValue("@un", UsernameTB.Text)
                            command.Parameters.AddWithValue("@pw", BCrypt.Net.BCrypt.HashPassword(PasswordTB.Text))
                            command.Parameters.AddWithValue("@email", EmailTB.Text)
                            command.Parameters.AddWithValue("@attempts", 0)
                            command.Parameters.AddWithValue("@locked", 0)
                            command.ExecuteNonQuery()
                        End Using

                        Dim t As String = "ID: " & maxid + 1 & " | Username: " & UsernameTB.Text & " | Password: " & BCrypt.Net.BCrypt.HashPassword(PasswordTB.Text) & " | Email: " & EmailTB.Text & " | Attempts: " & 0 & " | Locked: " & 0
                        Using command As New SQLiteCommand(sql3, connection)
                            maxidlog = Integer.Parse(command.ExecuteScalar)
                        End Using
                        Using command As New SQLiteCommand(sql4, connection)
                            command.Parameters.AddWithValue("@id", maxidlog + 1)
                            command.Parameters.AddWithValue("@db", "Security")
                            command.Parameters.AddWithValue("@table", "Users")
                            command.Parameters.AddWithValue("@act", "Insert")
                            command.Parameters.AddWithValue("@f", "-")
                            command.Parameters.AddWithValue("@t", t)
                            command.Parameters.AddWithValue("@dt", DateTime.Now)
                            command.Parameters.AddWithValue("@user", Login.logged)
                            command.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show("Successfully created account!")
                    MainForm.Show()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.Show()
        Close()
    End Sub
End Class