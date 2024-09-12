Imports System.Data.SQLite

Public Class CalendarEventMain
    Dim datetime As DateTime
    Dim numberofevents As Integer
    Dim progress As Integer
    Dim id As Integer

    Dim deletequeued As Boolean = False

    Private Sub CalendarEventMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If numberofevents = 0 Then
            EventNoLbl.Text = "There are no events yet for " & datetime.Date.ToString("MM/dd/yyyy")
            Dim lbls() As Label = {Label1, Label2, Label3, EventProgressLbl, EventNameLbl, DescriptionLbl, ParticipantLbl, Label5, Label7, VenueLbl, TimeLbl}
            Dim bttns() As Button = {PreviousBttn, NextBttn, EditEventBttn, DeleteEventBttn, ViewParticipantBttn}
            StringStorage.Visible(lbls, False)
            StringStorage.Visible(bttns, False)
        Else
            EventNoLbl.Text = "There are " & numberofevents & " events in the day " & datetime.Date.ToString("MM/dd/yyyy")
            EventProgressLbl.Text = "Event " & progress & " of " & numberofevents

            Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
            Dim sql As String = "SELECT [Name], [Description], [NumberofParticipants], [EventID], [Time], [Venue] FROM [Events] WHERE [Date] = @date"
            Dim row As Integer = 1

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql, connection)
                    command.Parameters.AddWithValue("@date", datetime)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read
                            If Not progress = row Then
                                row += 1
                            Else
                                EventNameLbl.Text = reader.GetString(0)
                                DescriptionLbl.Text = reader.GetString(1)
                                ParticipantLbl.Text = reader.GetInt32(2).ToString()
                                id = reader.GetInt32(3)
                                TimeLbl.Text = reader.GetString(4)
                                VenueLbl.Text = reader.GetString(5)
                                Exit While
                            End If
                        End While
                    End Using
                End Using
            End Using
        End If
    End Sub

    Public Sub New(d As DateTime, noe As Integer, p As Integer)
        InitializeComponent()
        datetime = d
        numberofevents = noe
        progress = p
    End Sub

    Private Sub PreviousLbl_Click(sender As Object, e As EventArgs) Handles PreviousBttn.Click
        If progress = 1 Then
            MessageBox.Show("You are at the Event 1.", "Cannot Previous", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cem As New CalendarEventMain(datetime, numberofevents, progress - 1)
            cem.Show()
            Close()
        End If
    End Sub

    Private Sub NextLbl_Click(sender As Object, e As EventArgs) Handles NextBttn.Click
        If progress = numberofevents Then
            MessageBox.Show("No more events to show.", "Cannot Next", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cem As New CalendarEventMain(datetime, numberofevents, progress + 1)
            cem.Show()
            Close()
        End If
    End Sub

    Private Sub CloseBttn_Click(sender As Object, e As EventArgs) Handles CloseBttn.Click
        Close()
    End Sub

    Private Sub AddEventBttn_Click(sender As Object, e As EventArgs) Handles AddEventBttn.Click
        Dim cae As New CalendarAddEditEvents(datetime, "Add", Nothing)
        cae.Show()
        Close()
    End Sub

    Private Sub EditEventBttn_Click(sender As Object, e As EventArgs) Handles EditEventBttn.Click
        Dim cae As New CalendarAddEditEvents(datetime, "Edit", id)
        cae.Show()
        Close()
    End Sub

    Private Sub DeleteEventBttn_Click(sender As Object, e As EventArgs) Handles DeleteEventBttn.Click
        If Not deletequeued Then
            MessageBox.Show("You are about to delete this event, along with its participants. Click the delete button again to confirm", "Deletion Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            deletequeued = True
        Else
            'For security
            Dim f As New List(Of String)
            Dim sql3 As String = "SELECT MAX(LogID) FROM Logs"
            Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @table, @act, @f, @t, @dt, @user)"
            Dim sql5 As String = "SELECT [Name], [Description], [Date], [NumberofParticipants] FROM [Events] WHERE [EventID] = @id"
            Dim sql6 As String = "SELECT [ParticipantID], [Name], [EventID], [YouthID] FROM [Participants] WHERE [EventID] = @id"
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.EventHandlerDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql5, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            Dim n As String = reader.GetString(0)
                            Dim d As String = reader.GetString(1)
                            Dim dt As DateTime = reader.GetDateTime(2)
                            Dim nop As Integer = reader.GetInt32(3)
                            f.Add("ID: " & id & " | Name: " & n & " | Description: " & d & " | Date: " & dt.ToString("MM/dd/yyyy") & " | NumberofParticipants: " & nop)
                            Exit While
                        End While
                    End Using
                End Using

                Using command As New SQLiteCommand(sql6, connection)
                    command.Parameters.AddWithValue("@id", id)
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            Dim pid As String = reader.GetInt32(0)
                            Dim n As String = reader.GetString(1)
                            Dim eid As Integer = reader.GetInt32(2)
                            Dim yid As Integer = reader.GetInt32(3)
                            f.Add("ParticipantID: " & pid & " | Name: " & n & " | EventID: " & eid & " | YouthID: " & yid)
                        End While
                    End Using
                End Using
            End Using
            Dim maxidlog As Integer
            Dim counter As Integer = 2
            Using connection As New SQLiteConnection(StringStorage.Addresser(StringStorage.SecurityDatabase))
                connection.Open()
                Using command As New SQLiteCommand(sql3, connection)
                    maxidlog = Integer.Parse(command.ExecuteScalar)
                End Using
                Using command As New SQLiteCommand(sql4, connection)
                    command.Parameters.AddWithValue("@id", maxidlog + 1)
                    command.Parameters.AddWithValue("@db", "EventHandler")
                    command.Parameters.AddWithValue("@table", "Events")
                    command.Parameters.AddWithValue("@act", "Delete")
                    command.Parameters.AddWithValue("@f", f(0))
                    command.Parameters.AddWithValue("@t", "-")
                    command.Parameters.AddWithValue("@dt", DateTime.Now)
                    command.Parameters.AddWithValue("@user", Login.logged)
                    command.ExecuteNonQuery()
                End Using
                f.RemoveAt(0)
                For Each from In f
                    Using command As New SQLiteCommand(sql4, connection)
                        command.Parameters.AddWithValue("@id", maxidlog + counter)
                        command.Parameters.AddWithValue("@db", "EventHandler")
                        command.Parameters.AddWithValue("@table", "Participants")
                        command.Parameters.AddWithValue("@act", "Delete")
                        command.Parameters.AddWithValue("@f", from)
                        command.Parameters.AddWithValue("@t", "-")
                        command.Parameters.AddWithValue("@dt", DateTime.Now)
                        command.Parameters.AddWithValue("@user", Login.logged)
                        command.ExecuteNonQuery()
                        counter += 1
                    End Using
                Next
            End Using

            'Delete
            Dim connectionString As String = StringStorage.Addresser(StringStorage.EventHandlerDatabase)
            Dim sql1 As String = "DELETE FROM [Events] WHERE [EventID] = @id"
            Dim sql2 As String = "DELETE FROM [Participants] WHERE [EventID] = @id"

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql2, connection)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using
            End Using

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Using command As New SQLiteCommand(sql1, connection)
                    command.Parameters.AddWithValue("@id", id)
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Successfully deleted this event and its participants!")
            CalendarMainForm.Close()
            CalendarMainForm.Show()
            Close()
        End If
    End Sub

    Private Sub ViewParticipantBttn_Click(sender As Object, e As EventArgs) Handles ViewParticipantBttn.Click
        Dim cp As New CalendarParticipants(id)
        cp.Show()
        Close()
    End Sub
End Class