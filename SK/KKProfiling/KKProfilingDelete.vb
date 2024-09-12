Imports System.Data.SQLite

Public Class KKProfilingDelete
    Dim connectionString As String = StringStorage.Addresser(StringStorage.KKProfilingDataBase)
    Private Sub KKProfilingDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        KKProfilingMainForm.Show()
        Close()
    End Sub



    Private Sub DeleteBtn_Click_1(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        DeleteBtn.Visible = False
        Errorlbl.Visible = True
        Errorlbl.Text = "The profile is about to be deleted and cannot be reverted. Press confirm to continue."
        ConfirmBtn.Visible = True
    End Sub

    Private Sub ConfirmBtn_Click_1(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        Dim sql As String = "DELETE FROM [Youth] WHERE [Name] = @pname;"
        Dim selectedPlayer As String = NameCB.SelectedItem.ToString()

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Using cmd As New SQLiteCommand(sql, connection)
                cmd.Parameters.AddWithValue("@pname", selectedPlayer)
                Try
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Deleted Successfully!")
                        NameCB.Items.Remove(selectedPlayer)
                        NameCB.SelectedIndex = -1
                        NameCB.Text = ""
                        Errorlbl.Visible = False
                        KKProfilingMainForm.Close()
                        KKProfilingMainForm.Show()
                    Else
                        MessageBox.Show("No Profile Deleted")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error deleting profile: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


End Class