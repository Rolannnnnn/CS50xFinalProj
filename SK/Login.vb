Imports System.Data.SQLite
Imports System.Net
Imports System.Net.Mail

Public Class Login
    Public logged As String = -1

    Dim connectionStringBB As String = "DataSource=SportsBasketballDatabase.db;Version=3;"
    Dim connectionStringVB As String = "DataSource=SportsVolleyballDatabase.db;Version=3;"
    Dim connectionStringESports As String = "DataSource=SportsESportsDatabase.db;Version=3;"
    Dim connectionStringKK As String = "DataSource=EventHandler.db;Version=3;"
    Dim connectionStringKKP As String = "DataSource=Information.db;Version=3;"
    Dim connectionStringB As String = "DataSource=Budget.db;Version=3;"
    Dim connectionStringS As String = "DataSource=Security.db;Version=3;"

    Private Function Reminders() As Integer
        Dim emailcount As Integer = 0

        Dim t0 As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim t1 As String = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
        Dim t2 As String = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")
        Dim t3 As String = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd")

        Dim sqle As String = "SELECT [EventID], [Name], [Date] FROM [Events] WHERE DATE(Date) IN (@t0, @t1, @t2, @t3) AND [Reminded] = 0"
        Dim eids As New List(Of Integer)
        Dim ename As New List(Of String)
        Dim edate As New List(Of DateTime)

        Using connection As New SQLiteConnection(connectionStringKK)
            connection.Open()
            Using command As New SQLiteCommand(sqle, connection)
                command.Parameters.AddWithValue("@t0", t0)
                command.Parameters.AddWithValue("@t1", t1)
                command.Parameters.AddWithValue("@t2", t2)
                command.Parameters.AddWithValue("@t3", t3)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    While reader.Read
                        eids.Add(reader.GetInt32(0))
                        ename.Add(reader.GetString(1))
                        edate.Add(reader.GetDateTime(2))
                    End While
                End Using
            End Using
        End Using

        For i = 0 To eids.Count - 1
            Dim yid As New List(Of Integer)
            Dim sqlp As String = "SELECT [YouthID] FROM [Participants] WHERE [EventID] = @eid"
            Dim sqly As String = "SELECT [Email] FROM [Youth] WHERE [YouthID] = @yid"

            Using connection As New SQLiteConnection(connectionStringKK)
                connection.Open()
                Using command As New SQLiteCommand(sqlp, connection)
                    command.Parameters.AddWithValue("@eid", eids(i))
                    Using reader As SQLiteDataReader = command.ExecuteReader
                        While reader.Read
                            yid.Add(reader.GetInt32(0))
                        End While
                    End Using
                End Using
            End Using

            For Each y In yid
                Dim email As String = ""
                Using connection As New SQLiteConnection(connectionStringKKP)
                    connection.Open()
                    Using command As New SQLiteCommand(sqly, connection)
                        command.Parameters.AddWithValue("@yid", y)
                        email = command.ExecuteScalar.ToString
                    End Using
                End Using
                sendEmail(ename(i), edate(i).ToString("MM/dd/yyyy"), email)
                emailcount += 1
            Next

            Dim sqleu As String = "UPDATE [Events] SET [Reminded] = 1 WHERE [EventID] = @id"
            Using connection As New SQLiteConnection(connectionStringKK)
                connection.Open()
                Using command As New SQLiteCommand(sqleu, connection)
                    command.Parameters.AddWithValue("@id", eids(i))
                    command.ExecuteNonQuery()
                End Using
            End Using
        Next

        Return emailcount
    End Function

    Private Sub sendEmail(eventName As String, eventDate As String, address As String)
        Try
            Dim fromaddress As New MailAddress("tanza1sk@gmail.com", "SK Tanza 1")
            Dim toaddress As New MailAddress(address)
            Dim subject As String = "Reminder for " & eventName
            Dim body As String = "Hello and Good Day!" & vbCrLf & "We are reminding you of the event - " & eventName & ", in which you are registered in. Please come and join us this " & eventDate & "!" & vbCrLf & vbCrLf & " - SK Tanza 1" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "This is a system-generated email. No need to reply."

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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = Guna2Button2
        timerDateTime.Start()


        'Reminding
        If System.IO.File.Exists("EventHandler.db") Then
            Dim c As Integer = Reminders()
            If c > 0 Then
                MessageBox.Show(c & " emails sent to pariticipants of upcoming events.")
            End If
        End If

        'Databasing
        If Not System.IO.File.Exists("SportsBasketballDatabase.db") Then
            MessageBox.Show("Sports-Basketball Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("SportsBasketballDatabase.db")
            InitializeDatabaseBasketball()
        End If

        If Not System.IO.File.Exists("SportsVolleyballDatabase.db") Then
            MessageBox.Show("Sports-Volleyball Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("SportsVolleyballDatabase.db")
            InitializeDatabaseVolleyball()
        End If

        If Not System.IO.File.Exists("SportsESportsDatabase.db") Then
            MessageBox.Show("Sports-ESports Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("SportsESportsDatabase.db")
            InitializeDatabaseESports()
        End If

        If Not System.IO.File.Exists("EventHandler.db") Then
            MessageBox.Show("Event Handler Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("EventHandler.db")
            InitializeDatabaseEvent()
        End If

        If Not System.IO.File.Exists("Information.db") Then
            MessageBox.Show("Information Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("Information.db")
            InitializeDataBaseInformation()
        End If

        If Not System.IO.File.Exists("Budget.db") Then
            MessageBox.Show("Budget Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("Budget.db")
            InitializeBudget()
        End If

        If Not System.IO.File.Exists("Security.db") Then
            MessageBox.Show("Security Database does not exists, creating a new one.")
            SQLiteConnection.CreateFile("Security.db")
            InitializeSecurity()
        End If
    End Sub

    Private Sub InitializeDatabaseESports()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Games (GameId INTEGER PRIMARY KEY, GameDate DATETIME, Team1 TEXT, Team2 TEXT, TeamWon TEXT);"
        Dim sql3 As String = "CREATE TABLE IF NOT EXISTS Players (PlayerId INTEGER PRIMARY KEY, [PlayerName] TEXT, YouthID INTEGER, Position TEXT, TeamName TEXT);"
        Dim sql4 As String = "CREATE TABLE IF NOT EXISTS Records (RecordId INTEGER PRIMARY KEY, [PlayerName] TEXT, YouthID INTEGER, Position TEXT, Kills INTEGER, Deaths INTEGER, Assists INTEGER, GameId INTEGER, FOREIGN KEY (GameId) REFERENCES Games(GameId));"
        Dim sql5 As String = "CREATE TABLE IF NOT EXISTS Teams (TeamId INTEGER PRIMARY KEY, TeamName TEXT, NumberofPlayers INTEGER);"

        Dim sql6 As String = "INSERT INTO Games (GameId, GameDate, Team1, Team2, TeamWon) VALUES (@gid, @gdate, @t1, @t2, @tw);"
        Dim sql8 As String = "INSERT INTO Players (PlayerId, PlayerName, YouthID, Position, TeamName) VALUES (@pid, @pname, @yid, @pos, @tname);"
        Dim sql9 As String = "INSERT INTO Records (RecordId, PlayerName, YouthID, Position, Kills, Deaths, Assists, GameId) VALUES (@rid, @pname, @yid, @pos, @kil, @dth, @ast, @gid);"
        Dim sql10 As String = "INSERT INTO Teams (TeamId, TeamName, NumberofPlayers) VALUES (@tid, @tname, @nop);"

        Using connection As New SQLiteConnection(connectionStringESports)
            connection.Open()
            Using cmd As New SQLiteCommand(sql1, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql3, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql4, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql5, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql6, connection)
                cmd.Parameters.AddWithValue("@gid", 0)
                cmd.Parameters.AddWithValue("@gdate", New DateTime(1970, 1, 1))
                cmd.Parameters.AddWithValue("@t1", "-")
                cmd.Parameters.AddWithValue("@t2", "-")
                cmd.Parameters.AddWithValue("@tw", "-")
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql8, connection)
                cmd.Parameters.AddWithValue("@pid", 0)
                cmd.Parameters.AddWithValue("@pname", "-")
                cmd.Parameters.AddWithValue("@yid", 0)
                cmd.Parameters.AddWithValue("@pos", "-")
                cmd.Parameters.AddWithValue("@tname", "-")
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql9, connection)
                cmd.Parameters.AddWithValue("@rid", 0)
                cmd.Parameters.AddWithValue("@pname", "-")
                cmd.Parameters.AddWithValue("@yid", 0)
                cmd.Parameters.AddWithValue("@pos", "-")
                cmd.Parameters.AddWithValue("@kil", 0)
                cmd.Parameters.AddWithValue("@dth", 0)
                cmd.Parameters.AddWithValue("@ast", 0)
                cmd.Parameters.AddWithValue("@gid", 0)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql10, connection)
                cmd.Parameters.AddWithValue("@tid", 0)
                cmd.Parameters.AddWithValue("@tname", "-")
                cmd.Parameters.AddWithValue("@nop", 0)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub InitializeDatabaseBasketball()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Games (GameID INTEGER PRIMARY KEY, GameDate DATETIME, Team1 TEXT, Team2 TEXT, TeamWon TEXT);"
        Dim sql2 As String = "CREATE TABLE IF NOT EXISTS Members (MemberId INTEGER PRIMARY KEY, [Player Name] TEXT, YouthID INTEGER, [Team Name] TEXT, [Jersey Number] INTEGER, Position TEXT, Division TEXT, Height INTEGER, Weight FLOAT);"
        Dim sql3 As String = "CREATE TABLE IF NOT EXISTS Records (RecordID INTEGER PRIMARY KEY, [Player Name] TEXT, Points INTEGER, Assists INTEGER, Rebounds INTEGER, Position TEXT, GameID INTEGER);"
        Dim sql4 As String = "CREATE TABLE IF NOT EXISTS Teams (ID INTEGER PRIMARY KEY, [Team Name] TEXT, [Team Coach] TEXT, Division TEXT);"

        Dim insertGames As String = "INSERT INTO Games (GameID, GameDate, Team1, Team2, TeamWon) VALUES (@gid, @gdate, @t1, @t2, @tw);"
        Dim insertMem As String = "INSERT INTO Members (MemberId, [Player Name], YouthID, [Team Name], [Jersey Number], Position, Division, Height, Weight) VALUES (@memId, @pname, @youthid, @tname, @jnum, @pos, @div, @height, @weight);"
        Dim insertRec As String = "INSERT INTO Records (RecordID, [Player Name], Points, Assists, Rebounds, Position, GameID) VALUES (@rec, @pname, @pts, @ast, @reb, @pos, @gid);"
        Dim insertTeam As String = "INSERT INTO Teams (ID, [Team Name], [Team Coach], Division) VALUES (@id, @tname, @tcoach, @div);"

        Using connection As New SQLiteConnection(connectionStringBB)
            connection.Open()
            Using cmd As New SQLiteCommand(sql1, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql2, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql3, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(sql4, connection)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(insertGames, connection)
                cmd.Parameters.AddWithValue("@gid", 0)
                cmd.Parameters.AddWithValue("@gdate", New DateTime(1970, 1, 1))
                cmd.Parameters.AddWithValue("@t1", "-")
                cmd.Parameters.AddWithValue("@t2", "-")
                cmd.Parameters.AddWithValue("@tw", "-")
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(insertMem, connection)
                cmd.Parameters.AddWithValue("@memId", 0)
                cmd.Parameters.AddWithValue("@pname", "-")
                cmd.Parameters.AddWithValue("@youthid", 0)
                cmd.Parameters.AddWithValue("@tname", "-")
                cmd.Parameters.AddWithValue("@jnum", "-")
                cmd.Parameters.AddWithValue("@pos", "-")
                cmd.Parameters.AddWithValue("@div", "-")
                cmd.Parameters.AddWithValue("@height", 0)
                cmd.Parameters.AddWithValue("@weight", 0)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(insertRec, connection)
                cmd.Parameters.AddWithValue("@rec", 0)
                cmd.Parameters.AddWithValue("@pname", "-")
                cmd.Parameters.AddWithValue("@pts", 0)
                cmd.Parameters.AddWithValue("@ast", 0)
                cmd.Parameters.AddWithValue("@reb", 0)
                cmd.Parameters.AddWithValue("@pos", "-")
                cmd.Parameters.AddWithValue("@gid", 0)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SQLiteCommand(insertTeam, connection)
                cmd.Parameters.AddWithValue("@id", 0)
                cmd.Parameters.AddWithValue("@tname", "-")
                cmd.Parameters.AddWithValue("@tcoach", "-")
                cmd.Parameters.AddWithValue("@div", "-")
                cmd.ExecuteNonQuery()
            End Using
        End Using
        End Sub

    Public Sub InitializeDatabaseVolleyball()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Entries (EntryID INTEGER PRIMARY KEY, TeamName TEXT, SetNum INTEGER, Points INTEGER, Date DATETIME);"
        Dim sql2 As String = "CREATE TABLE IF NOT EXISTS Games (GameID INTEGER PRIMARY KEY, Team1 TEXT, Team2 TEXT, Date DATETIME, TeamWon TEXT);"
        Dim sql3 As String = "CREATE TABLE IF NOT EXISTS Players (PlayerID INTEGER PRIMARY KEY, Name TEXT, YouthID INTEGER, JerseyNum INTEGER, Position TEXT, TeamName TEXT, Division TEXT, Height FLOAT, Weight FLOAT);"
        Dim sql4 As String = "CREATE TABLE IF NOT EXISTS Records (RecordID INTEGER PRIMARY KEY, PlayerName TEXT, Position TEXT, Points INTEGER, Blocks INTEGER, Digs INTEGER, GameID INTEGER, FOREIGN KEY (GameID) REFERENCES Games(GameID));"
        Dim sql5 As String = "CREATE TABLE IF NOT EXISTS Team (TeamID INTEGER PRIMARY KEY, TeamName TEXT, Division TEXT, Coach TEXT);"

        Dim sql6 As String = "INSERT INTO Entries VALUES (@id, @tn, @sn, @p, @dt);"
        Dim sql7 As String = "INSERT INTO Games VALUES (@id, @t1, @t2, @dt, @tw);"
        Dim sql8 As String = "INSERT INTO Players VALUES (@id, @n, @yid, @jn, @pos, @tn, @div, @h, @w);"
        Dim sql9 As String = "INSERT INTO Records VALUES (@id, @pn, @pos, @p, @b, @d, @gid);"
        Dim sql10 As String = "INSERT INTO Team VALUES (@id, @tn, @div, @c);"

        Using connection As New SQLiteConnection(connectionStringVB)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql2, connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql3, connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql4, connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql5, connection)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql6, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@tn", "-")
                command.Parameters.AddWithValue("@sn", "-")
                command.Parameters.AddWithValue("@p", "-")
                command.Parameters.AddWithValue("@dt", New DateTime(1970, 1, 1))
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql7, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@t1", "-")
                command.Parameters.AddWithValue("@t2", "-")
                command.Parameters.AddWithValue("@dt", New DateTime(1970, 1, 1))
                command.Parameters.AddWithValue("@tw", "-")
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql8, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@n", "-")
                command.Parameters.AddWithValue("@yid", 0)
                command.Parameters.AddWithValue("@jn", 0)
                command.Parameters.AddWithValue("@pos", "-")
                command.Parameters.AddWithValue("@tn", "-")
                command.Parameters.AddWithValue("@div", "-")
                command.Parameters.AddWithValue("@h", 0)
                command.Parameters.AddWithValue("@w", 0)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql9, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@pn", "-")
                command.Parameters.AddWithValue("@pos", "-")
                command.Parameters.AddWithValue("@p", 0)
                command.Parameters.AddWithValue("@b", 0)
                command.Parameters.AddWithValue("@d", 0)
                command.Parameters.AddWithValue("@gid", 0)
                command.ExecuteNonQuery()
            End Using

            Using command As New SQLiteCommand(sql10, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@tn", "-")
                command.Parameters.AddWithValue("@div", "-")
                command.Parameters.AddWithValue("@c", "-")
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub InitializeDatabaseEvent()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Events (EventID INTEGER PRIMARY KEY, Name TEXT, Description TEXT, Date DATETIME, Time TEXT, Venue TEXT, NumberofParticipants INTEGER DEFAULT 0, Reminded BIT DEFAULT 0);"
        Dim sql2 As String = "CREATE TABLE IF NOT EXISTS Participants (ParticipantID INTEGER PRIMARY KEY, Name TEXT, EventID INTEGER, YouthID INTEGER, FOREIGN KEY (EventID) REFERENCES Events(EventID));"

        Dim sql4 As String = "INSERT INTO Events VALUES (@id, @n, @desc, @date, @t, @v, @num, @rem)"
        Dim sql5 As String = "INSERT INTO Participants VALUES (@id, @n, @eid, @yid)"


        Using connection As New SQLiteConnection(connectionStringKK)
            connection.Open()
            Using Command As New SQLiteCommand(sql1, connection)
                Command.ExecuteNonQuery()
            End Using

            Using Command As New SQLiteCommand(sql2, connection)
                Command.ExecuteNonQuery()
            End Using

            Using Command As New SQLiteCommand(sql4, connection)
                Command.Parameters.AddWithValue("@id", 0)
                Command.Parameters.AddWithValue("@n", "-")
                Command.Parameters.AddWithValue("@desc", "-")
                Command.Parameters.AddWithValue("@date", New DateTime(1970, 1, 1))
                Command.Parameters.AddWithValue("@t", "-")
                Command.Parameters.AddWithValue("@v", "-")
                Command.Parameters.AddWithValue("@num", 0)
                Command.Parameters.AddWithValue("@rem", 0)
                Command.ExecuteNonQuery()
            End Using

            Using Command As New SQLiteCommand(sql5, connection)
                Command.Parameters.AddWithValue("@id", 0)
                Command.Parameters.AddWithValue("@n", "-")
                Command.Parameters.AddWithValue("@eid", 0)
                Command.Parameters.AddWithValue("@yid", 0)
                Command.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Public Sub InitializeDataBaseInformation()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Youth (YouthID INTEGER PRIMARY KEY, Name TEXT, ContactNumber TEXT, DateAnswered DATETIME, Region TEXT, Province TEXT, City TEXT, Barangay TEXT, Age INT, Birthday DATETIME, Sex TEXT, Civil TEXT, Classification TEXT, YouthAgeGroup TEXT, Email TEXT, Address TEXT, Education TEXT, Work TEXT, IsVoter TEXT, VotedLast TEXT, IsSKVoter TEXT, IsNationalVoter TEXT, AttendedKKAssembly TEXT, YesHowMany TEXT, NoWhy TEXT);"
        Dim sql2 As String = "INSERT INTO Youth VALUES (@id, @name, @contact, @date, @region, @province, @city, @barangay, @age, @birthday, @sex, @civil, @classification, @YouthAge, @Email, @Address, @Education, @Work, @Voter, @Vote, @SKVoter, @NVoter, @Que, @Yes, @No)"

        Using connection As New SQLiteConnection(connectionStringKKP)
            connection.Open()
            Using Command As New SQLiteCommand(sql1, connection)
                Command.ExecuteNonQuery()
            End Using

            Using Command As New SQLiteCommand(sql2, connection)
                Command.Parameters.AddWithValue("@id", 0)
                Command.Parameters.AddWithValue("@name", "-")
                Command.Parameters.AddWithValue("@contact", "-")
                Command.Parameters.AddWithValue("@date", New DateTime(1970, 1, 1))
                Command.Parameters.AddWithValue("@region", "-")
                Command.Parameters.AddWithValue("@province", "-")
                Command.Parameters.AddWithValue("@city", "-")
                Command.Parameters.AddWithValue("@barangay", "-")
                Command.Parameters.AddWithValue("@age", 0)
                Command.Parameters.AddWithValue("@birthday", New DateTime(1970, 1, 1))
                Command.Parameters.AddWithValue("@sex", "-")
                Command.Parameters.AddWithValue("@civil", "-")
                Command.Parameters.AddWithValue("@classification", "-")
                Command.Parameters.AddWithValue("@YouthAge", "-")
                Command.Parameters.AddWithValue("@Email", "-")
                Command.Parameters.AddWithValue("@Address", "-")
                Command.Parameters.AddWithValue("@Education", "-")
                Command.Parameters.AddWithValue("@Work", "-")
                Command.Parameters.AddWithValue("@Voter", "-")
                Command.Parameters.AddWithValue("@Vote", "-")
                Command.Parameters.AddWithValue("@SKVoter", "-")
                Command.Parameters.AddWithValue("@NVoter", "-")
                Command.Parameters.AddWithValue("@Que", "-")
                Command.Parameters.AddWithValue("@Yes", 0)
                Command.Parameters.AddWithValue("@No", "-")
                Command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub InitializeBudget()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Expense (ExpenseID INTEGER PRIMARY KEY, Amount MONEY, Item TEXT, EventName TEXT, Date DATETIME)"
        Dim sql2 As String = "CREATE TABLE IF NOT EXISTS Inflow (InflowID INTEGER PRIMARY KEY, Amount MONEY, Source TEXT, Date DATETIME)"
        Dim sql3 As String = "INSERT INTO Expense VALUES (@id, @amount, @item, @eventn, @date)"
        Dim sql4 As String = "INSERT INTO Inflow VALUES (@id, @amount, @source, @date)"

        Using connection As New SQLiteConnection(connectionStringB)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql2, connection)
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql3, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@amount", 0.0)
                command.Parameters.AddWithValue("@item", "-")
                command.Parameters.AddWithValue("@eventn", "-")
                command.Parameters.AddWithValue("@date", New DateTime(1970, 1, 1))
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql4, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@amount", 0.0)
                command.Parameters.AddWithValue("@source", "-")
                command.Parameters.AddWithValue("@date", New DateTime(1970, 1, 1))
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub InitializeSecurity()
        Dim sql1 As String = "CREATE TABLE IF NOT EXISTS Users (UserID INTEGER PRIMARY KEY, Username TEXT, Password TEXT, Email TEXT, Attempts TEXT, Locked BIT)"
        Dim sql2 As String = "CREATE TABLE IF NOT EXISTS Logs (LogID INTEGER PRIMARY KEY, [Database] TEXT, [Table] TEXT, [Action] TEXT, [From] TEXT, [To] TEXT, [DateTime] DATETIME, User TEXT)"
        Dim sql3 As String = "INSERT INTO Users VALUES (@id, @user, @password, @email, @at, @l)"
        Dim sql4 As String = "INSERT INTO Logs VALUES (@id, @db, @t, @act, @from, @to, @dt, @user)"

        Using connection As New SQLiteConnection(connectionStringS)
            connection.Open()
            Using command As New SQLiteCommand(sql1, connection)
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql2, connection)
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql3, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@user", "superuser")
                command.Parameters.AddWithValue("password", BCrypt.Net.BCrypt.HashPassword("1234"))
                command.Parameters.AddWithValue("@email", "tanza1sk@gmail.com")
                command.Parameters.AddWithValue("@at", 0)
                command.Parameters.AddWithValue("@l", 0)
                command.ExecuteNonQuery()
            End Using
            Using command As New SQLiteCommand(sql4, connection)
                command.Parameters.AddWithValue("@id", 0)
                command.Parameters.AddWithValue("@db", "-")
                command.Parameters.AddWithValue("@t", "-")
                command.Parameters.AddWithValue("@act", "-")
                command.Parameters.AddWithValue("@from", "-")
                command.Parameters.AddWithValue("@to", "-")
                command.Parameters.AddWithValue("@dt", New DateTime(1970, 1, 1))
                command.Parameters.AddWithValue("@user", "-")
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Application.Exit()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.TabIndex = 2
        Dim userfound As Boolean = False
        Dim isLocked As Boolean = False
        Dim retrieved As String = ""

        If Not StringStorage.CheckString(UserTxtBox.Text, 100).Equals("") Or Not StringStorage.CheckString(PassTxtBox.Text, 100).Equals("") Then
            FeedbackLbl.Text = "Some fields are empty or too long."
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Exit Sub
        End If

        Dim sql As String = "SELECT [Password], [Locked] FROM [Users] WHERE [Username] = @user"
        Using connection As New SQLiteConnection(connectionStringS)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@user", UserTxtBox.Text)
                Using reader As SQLiteDataReader = command.ExecuteReader
                    If reader.Read Then
                        userfound = True
                        retrieved = reader.GetString(0)
                        isLocked = reader.GetBoolean(1)
                    End If
                End Using
            End Using
        End Using

        If userfound Then
            Dim attempts As Integer
            If isLocked Then
                FeedbackLbl.Text = "Account is locked. Unlock below."
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            ElseIf Not BCrypt.Net.BCrypt.Verify(PassTxtBox.Text, retrieved) Then
                Dim sql1 As String = "UPDATE Users SET Attempts = Attempts + 1 WHERE Username = @user"
                Dim sql2 As String = "SELECT [Attempts] FROM Users WHERE Username = @user"
                Dim sql3 As String = "UPDATE Users SET [Locked] = 1 WHERE Username = @user"

                Using connection As New SQLiteConnection(connectionStringS)
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@user", UserTxtBox.Text)
                        command.ExecuteNonQuery()
                    End Using
                    Using command As New SQLiteCommand(sql2, connection)
                        command.Parameters.AddWithValue("@user", UserTxtBox.Text)
                        attempts = Integer.Parse(command.ExecuteScalar)
                    End Using
                    If attempts >= 5 Then
                        Using command As New SQLiteCommand(sql3, connection)
                            command.Parameters.AddWithValue("@user", UserTxtBox.Text)
                            command.ExecuteNonQuery()
                        End Using
                    End If
                End Using

                FeedbackLbl.Text = "Incorrect password"
                StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
            Else
                Dim sql1 As String = "UPDATE Users SET Attempts = 0 WHERE [Username] = @user"
                Using connection As New SQLiteConnection(connectionStringS)
                    connection.Open()
                    Using command As New SQLiteCommand(sql1, connection)
                        command.Parameters.AddWithValue("@user", UserTxtBox.Text)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                logged = UserTxtBox.Text
                MainForm.Show()
                UserTxtBox.Text = Nothing
                PassTxtBox.Text = Nothing
                Hide()
                Guna2CheckBox1.Checked = False

            End If
        Else
            FeedbackLbl.Text = "Cannot find account"
            StringStorage.ShowLabelsForThreeSeconds(FeedbackLbl)
        End If
    End Sub

    Private Sub timerDateTime_Tick(sender As Object, e As EventArgs) Handles timerDateTime.Tick

        Label4.Text = DateTime.Now.ToString("hh:mm:ss")


        Label5.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")


        Label6.Text = DateTime.Now.ToString("tt")
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked Then
            PassTxtBox.UseSystemPasswordChar = False
        Else
            PassTxtBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        AccountUnlocking.Show()
        Hide()
    End Sub
    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UserTxtBox.Focus()
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        AccountForgotPassword.Show()
        Hide()
    End Sub

    Private Sub PassTxtBox_TextChanged(sender As Object, e As EventArgs) Handles PassTxtBox.TextChanged
        Me.TabIndex = 1
    End Sub

    Private Sub UserTxtBox_TabIndexChanged(sender As Object, e As EventArgs) Handles UserTxtBox.TabIndexChanged
        PassTxtBox.Focus()
    End Sub

    Private Sub UserTxtBox_KeyDown(sender As Object, e As KeyPressEventArgs) Handles UserTxtBox.KeyPress
        If e.KeyChar = ChrW(Keys.Tab) Then
            PassTxtBox.Focus()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub FeedbackLbl_Click(sender As Object, e As EventArgs) Handles FeedbackLbl.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub UserTxtBox_TextChanged(sender As Object, e As EventArgs) Handles UserTxtBox.TextChanged

    End Sub

    Private Sub Guna2GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2GradientPanel1.Paint

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MnV.Show()
        Me.Hide()
    End Sub
End Class