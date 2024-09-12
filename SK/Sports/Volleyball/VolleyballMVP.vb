Imports System.Data.SQLite

Public Class VolleyballMVP
    Private Sub VolleyballMVP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim names As New Dictionary(Of Integer, String)
        Dim score As New Dictionary(Of String, Integer)
        Dim assist As New Dictionary(Of String, Integer)
        Dim rebound As New Dictionary(Of String, Integer)
        Dim games As New Dictionary(Of String, Integer)

        Dim spg As New Dictionary(Of String, Double)
        Dim apg As New Dictionary(Of String, Double)
        Dim rpg As New Dictionary(Of String, Double)

        Dim plb As New List(Of String)
        Dim alb As New List(Of String)
        Dim rlb As New List(Of String)

        Dim count As Integer = -1
        Dim sql1 As String = "SELECT [Name] FROM Players WHERE [PlayerID] > 0"

        Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SportsVolleyballDatabase))
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        count += 1
                        names.Add(count, reader.GetString(0))
                        score.Add(reader.GetString(0), 0)
                        assist.Add(reader.GetString(0), 0)
                        rebound.Add(reader.GetString(0), 0)
                        games.Add(reader.GetString(0), 0)
                    End While
                End Using
            End Using

            Dim sql2 As String = "SELECT [Points], [Blocks], [Digs] FROM Records WHERE [PlayerName] = @pn"
            For i = 0 To count
                Using Command As New SQLiteCommand(sql2, connection)
                    Command.Parameters.AddWithValue("@pn", names(i))
                    Using reader As SQLiteDataReader = Command.ExecuteReader
                        While reader.Read
                            score(names(i)) += reader.GetInt32(0)
                            assist(names(i)) += reader.GetInt32(1)
                            rebound(names(i)) += reader.GetInt32(2)
                            games(names(i)) += 1
                        End While
                    End Using
                End Using
            Next
        End Using

        For i = 0 To count
            If games(names(i)) > 0 Then
                spg.Add(names(i), score(names(i)) / games(names(i)))
                apg.Add(names(i), assist(names(i)) / games(names(i)))
                rpg.Add(names(i), rebound(names(i)) / games(names(i)))
            Else
                spg.Add(names(i), 0)
                apg.Add(names(i), 0)
                rpg.Add(names(i), 0)
            End If
        Next


        'Score
        For i = 0 To count
            Dim max As Double = -1
            Dim maxname As String = ""
            For Each pair In spg
                If pair.Value > max Then
                    max = pair.Value
                    maxname = pair.Key
                End If
            Next

            plb.Add(i + 1 & ". " & maxname & "    -    " & max)
            spg.Remove(maxname)
        Next

        'Assists
        For i = 0 To count
            Dim max As Double = -1
            Dim maxname As String = ""
            For Each pair In apg
                If pair.Value > max Then
                    max = pair.Value
                    maxname = pair.Key
                End If
            Next

            alb.Add(i + 1 & ". " & maxname & "    -    " & max)
            apg.Remove(maxname)
        Next

        'Rebound
        For i = 0 To count
            Dim max As Double = -1
            Dim maxname As String = ""
            For Each pair In rpg
                If pair.Value > max Then
                    max = pair.Value
                    maxname = pair.Key
                End If
            Next

            rlb.Add(i + 1 & ". " & maxname & "    -    " & max)
            rpg.Remove(maxname)
        Next


        PointsLB.DataSource = plb
        AssistsLB.DataSource = alb
        ReboundLB.DataSource = rlb
    End Sub
End Class