Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class ESportsMainForm
    Private Sub RegisterTeamBttn_Click(sender As Object, e As EventArgs) Handles RegisterTeamBttn.Click
        MovePanel(RegisterTeamBttn)
        openChildForm(New ESportsRegisterTeam)
    End Sub

    Private Sub DeleteTeamBttn_Click(sender As Object, e As EventArgs) Handles DeleteTeamBttn.Click
        MovePanel(DeleteTeamBttn)
        openChildForm(New ESportsEditTeam)
    End Sub

    Private Sub RegisterMemberBttn_Click(sender As Object, e As EventArgs) Handles RegisterMemberBttn.Click
        MovePanel(RegisterMemberBttn)
        openChildForm(New ESportsRegisterPlayer)
    End Sub

    Private Sub RecordDayBttn_Click(sender As Object, e As EventArgs) Handles RecordDayBttn.Click
        MovePanel(RecordDayBttn)
        openChildForm(New ESportsRegisterRecord)
    End Sub

    Private Sub DeleteDayBttn_Click(sender As Object, e As EventArgs) Handles DeleteDayBttn.Click
        MovePanel(DeleteDayBttn)
        openChildForm(New ESportsEditGame)
    End Sub

    Private Sub DeleteMemberBttn_Click(sender As Object, e As EventArgs) Handles DeleteMemberBttn.Click
        MovePanel(DeleteMemberBttn)
        openChildForm(New ESportsEditPlayer)
    End Sub

    Private Sub ViewTeamBttn_Click(sender As Object, e As EventArgs) Handles ViewTeamBttn.Click
        MovePanel(ViewTeamBttn)
        openChildForm(New ESportsView)
    End Sub

    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        SportsMainForm.Show()
        Close()
    End Sub

    Private activeForm As Form = Nothing

    Private Sub openChildForm(childForm As Form)
        If activeForm IsNot Nothing Then
            activeForm.Close()
        End If

        activeForm = childForm
        childForm.TopLevel = False
        childForm.Dock = DockStyle.Fill
        childForm.FormBorderStyle = FormBorderStyle.None

        Guna2Panel3.Controls.Add(childForm)
        Guna2Panel3.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub MovePanel(button As Guna2Button)
        Guna2Panel5.Top = button.Top
        Guna2Panel5.Height = button.Height
        Guna2Panel5.Visible = True

        If Guna2Panel5.Top < 0 Then
            Guna2Panel5.Top = 0
        End If

        If Guna2Panel5.Bottom > Me.ClientSize.Height Then
            Guna2Panel5.Top = Me.ClientSize.Height - Guna2Panel5.Height
        End If

        Guna2Panel5.BringToFront()
    End Sub

    Private Sub moveBarPanel(sender As Object)
        Dim b As Guna2Button = CType(sender, Guna2Button)
        Guna2Panel5.Location = New Point(b.Location.X - 121, b.Location.Y - 30)
        Guna2Panel5.SendToBack()
    End Sub

    Private Sub Guna2Button5_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2Button5.CheckedChanged
        Dim button As Guna2Button = CType(sender, Guna2Button)
        If button.Checked Then
            button.FillColor = Color.FromArgb(114, 151, 98)    'TO CHANGE
        Else
            button.FillColor = Color.FromArgb(89, 116, 69)   'TO CHANGE
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If activeForm IsNot Nothing Then
            activeForm.Hide()
            activeForm = Nothing
        End If

        Label2.Text = "E-SPORTS CONTROL PANEL"


        MovePanel(Guna2Button5)
        UpdateCounts()
    End Sub

    Private connectionStringBB As String = StringStorage.Addresser(StringStorage.SportsEsportsDatabase)

    Public Function GetTeamCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Teams"

        Using connection As New SQLiteConnection(connectionStringBB)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Public Function GetPlayerCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Players"

        Using connection As New SQLiteConnection(connectionStringBB)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Public Function GetCoachCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Games"

        Using connection As New SQLiteConnection(connectionStringBB)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateCounts()
        Dim currentdate As DateTime = DateTime.Now
        Dim year As String = currentdate.Year.ToString()
        Label11.Text = year

    End Sub

    Private Sub UpdateCounts()
        Label9.Text = GetTeamCount().ToString()
        Label5.Text = GetPlayerCount().ToString()
        Label7.Text = GetCoachCount().ToString()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        MovePanel(Guna2Button1)
        openChildForm(New ESportsMVP)
    End Sub


End Class
