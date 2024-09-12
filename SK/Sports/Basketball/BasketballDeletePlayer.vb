Imports System.Data.SQLite

Public Class BasketballDeletePlayer
    Dim con As String = StringStorage.Addresser(StringStorage.SportsBasketballDatabase)
    Dim conkk As String = StringStorage.Addresser(StringStorage.KKProfilingDatabase)

    Private Sub BasketballDeletePlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPlayers()
    End Sub

    Private Sub LoadPlayers()
        Dim sql As String = "SELECT YouthID FROM members WHERE [MemberId] > 0;"

        PlayerCBox.Items.Clear()

        Try
            Using connectionSports As New SQLiteConnection(con)
                connectionSports.Open()
                Using cmdSports As New SQLiteCommand(sql, connectionSports)
                    Using readerSports As SQLiteDataReader = cmdSports.ExecuteReader()
                        Dim youthIDs As New List(Of Integer)()
                        While readerSports.Read()
                            Dim youthID As Integer
                            If Integer.TryParse(readerSports("YouthID").ToString(), youthID) Then
                                youthIDs.Add(youthID)
                            End If
                        End While
                        Dim youthIDsString As String = String.Join(",", youthIDs)
                        Dim sqlKKProfiling As String = $"SELECT YouthID, Name FROM Youth WHERE YouthID IN ({youthIDsString});"

                        Using connectionKKProfiling As New SQLiteConnection(conkk)
                            connectionKKProfiling.Open()
                            Using cmdKKProfiling As New SQLiteCommand(sqlKKProfiling, connectionKKProfiling)
                                Using readerKKProfiling As SQLiteDataReader = cmdKKProfiling.ExecuteReader()

                                    While readerKKProfiling.Read()
                                        Dim playerId As Integer = readerKKProfiling.GetInt32(0)
                                        Dim playerName As String = readerKKProfiling.GetString(1)
                                        PlayerCBox.Items.Add(New KeyValuePair(Of Integer, String)(playerId, playerName))
                                    End While
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PlayerDeleteBtn_Click(sender As Object, e As EventArgs) Handles PlayerDeleteBtn.Click
        If PlayerCBox.SelectedIndex = -1 Then
            MessageBox.Show("Please select a player to delete.")
            Return
        End If

        Dim kvp As KeyValuePair(Of Integer, String) = DirectCast(PlayerCBox.SelectedItem, KeyValuePair(Of Integer, String))
        Dim youthID As Integer = kvp.Key
        Dim playerName As String = kvp.Value

        Dim sqlDelete As String = "DELETE FROM [Members] WHERE [YouthID] = @youthid;"

        'Security
        Dim fp As String = ""
        Dim sqlsf1 As String = "SELECT [MemberId], [Player Name], [YouthID], [Team Name], [Jersey Number], [Position], [Division], [Height], [Weight] FROM [Members] WHERE [YouthID] = @yid"

        Using connection As New SQLiteConnection(con)
            connection.Open()

            Using command As New SQLiteCommand(sqlsf1, connection)
                command.Parameters.AddWithValue("@yid", youthID)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        fp = "MemberId: " & reader.GetInt32(0) & " | Player Name: " & reader.GetString(1) & " | YouthID: " & reader.GetInt32(2) & " | Team Name: " & reader.GetString(3) & " | Jersey Number: " & reader.GetInt32(4) & " | Position: " & reader.GetString(5) & " | Division: " & reader.GetString(6) & " | Height: " & reader.GetInt32(7) & " | Weight: " & reader.GetFloat(8)
                    End If
                End Using
            End Using

            Using cmd As New SQLiteCommand(sqlDelete, connection)
                cmd.Parameters.AddWithValue("@youthid", youthID)
                Try
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Deleted player '" & playerName & "' Successfully!")

                        PlayerCBox.Text = Nothing
                        LoadPlayers()
                    Else
                        MessageBox.Show("No Player Deleted")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error deleting player: " & ex.Message)
                End Try
            End Using
        End Using

        'Security
        Dim sqls1 As String = "SELECT MAX(LogID) FROM Logs"
        Dim sqls2 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
        Dim maxidlog As Integer
        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
            connection.Open()
            Using command As New SQLiteCommand(sqls1, connection)
                maxidlog = Integer.Parse(command.ExecuteScalar)
            End Using

            Using command As New SQLiteCommand(sqls2, connection)
                command.Parameters.AddWithValue("@id", maxidlog + 1)
                command.Parameters.AddWithValue("@db", "SportsBasketball")
                command.Parameters.AddWithValue("@table", "Players")
                command.Parameters.AddWithValue("@act", "Delete")
                command.Parameters.AddWithValue("@f", fp)
                command.Parameters.AddWithValue("@t", "-")
                command.Parameters.AddWithValue("@dt", DateTime.Now)
                command.Parameters.AddWithValue("@user", Login.logged)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
