Imports System.Data.SQLite
Imports System.Net
Imports System.Net.Mail

Public Class AccountUnlocking
    Dim confirmed As Boolean = False
    Dim gen As System.Random = New System.Random()
    Dim code As Integer = gen.Next(100000, 999999)
    Dim sentcode As Integer = code

    Private Sub sendEmail(address As String, code As Integer)
        Try
            Dim fromaddress As New MailAddress("tanza1sk@gmail.com", "SK Tanza 1")
            Dim toaddress As New MailAddress(address)
            Dim subject As String = "SK Tanza 1 System - Account Creation - Verification"
            Dim body As String = "To complete unlocking your account, use this OTP: " & code & ". Thank you." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "This is a system-generated email. No need to reply."

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

    Private Function CheckString() As String
        Dim email As String = ""

        Dim sql As String = "SELECT [Email] FROM Users WHERE [Username] = @un"
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
            connection.Open()
            Using Command As New SQLiteCommand(sql, connection)
                Command.Parameters.AddWithValue("@un", UsernameTB.Text)
                Using reader As SQLiteDataReader = Command.ExecuteReader
                    If reader.Read Then
                        email = reader.GetString(0)
                    End If
                End Using
            End Using
        End Using

        FeedbackLbl.ForeColor = Color.Red
        If UsernameTB.Text = "" Then
            FeedbackLbl.Text = "Some fields are empty."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return ""
        End If

        If email = "" Then
            FeedbackLbl.Text = "Cannot find username."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Return ""
        End If

        Return email
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim email As String = CheckString()
        If Not confirmed Then
            If Not email.Equals("") Then
                confirmed = True
                UsernameTB.Enabled = False
                OTPLbl.Visible = True
                OTPTB.Visible = True
                sendEmail(email, sentcode)
                FeedbackLbl.Text = "Input the OTP in the field to complete the unlocking"
                FeedbackLbl.ForeColor = Color.Black
                FeedbackLbl.Visible = True
            End If
        Else
            If String.IsNullOrWhiteSpace(OTPTB.Text) Then
                FeedbackLbl.Text = "OTP field is empty."
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf Not OTPTB.Text = sentcode.ToString Then
                FeedbackLbl.Text = "Incorrect OTP."
                FeedbackLbl.ForeColor = Color.Red
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                Dim sql As String = "UPDATE [Users] SET [Attempts] = 0, [Locked] = 0 WHERE [Email] = @email"
                Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                    connection.Open()
                    Using command As New SQLiteCommand(sql, connection)
                        command.Parameters.AddWithValue("@email", email)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Successfully unlocked account!")
                Login.Show()
                Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.Show()
        Close()
    End Sub
End Class