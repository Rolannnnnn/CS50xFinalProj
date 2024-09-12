Imports System.Data.SQLite
Imports System.Reflection.Emit
Imports Guna.UI2.WinForms

Public Class BasketballMainForm
    Private Sub BackBtn_Click(sender As Object, e As EventArgs)
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub AddTeamBtn_Click(sender As Object, e As EventArgs) Handles AddTeamBtn.Click
        MovePanel(AddTeamBtn)
        openChildForm(New BasketballRegisterTeam)
    End Sub

    Private Sub AddPlayerBtn_Click(sender As Object, e As EventArgs) Handles AddPlayerBtn.Click
        MovePanel(AddPlayerBtn)
        openChildForm(New BasketballAddPlayers)
    End Sub

    Private Sub BasketballAddGameBtn_Click(sender As Object, e As EventArgs) Handles BasketballAddGameBtn.Click
        MovePanel(BasketballAddGameBtn)
        openChildForm(New BasketballAddGame)
    End Sub

    Private Sub DeleteTeamBtn_Click(sender As Object, e As EventArgs) Handles DeleteTeamBtn.Click
        MovePanel(DeleteTeamBtn)
        openChildForm(New BasketballDeleteTeam)
    End Sub

    Private Sub DeleteMemberBtn_Click(sender As Object, e As EventArgs) Handles DeleteMemberBtn.Click
        MovePanel(DeleteMemberBtn)
        openChildForm(New BasketballDeletePlayer)
    End Sub

    Private Sub EditDeleteGameBtn_Click(sender As Object, e As EventArgs) Handles EditDeleteGameBtn.Click
        MovePanel(EditDeleteGameBtn)
        openChildForm(New BasketballEditDeleteGame(Me))
    End Sub

    Private Sub EditTeamBtn_Click(sender As Object, e As EventArgs) Handles EditTeamBtn.Click
        MovePanel(EditTeamBtn)
        openChildForm(New BasketballEditTeam)
    End Sub

    Private Sub EditMemberBtn_Click(sender As Object, e As EventArgs) Handles EditMemberBtn.Click
        MovePanel(EditMemberBtn)
        openChildForm(New BasketballEditPlayer)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MovePanel(Button1)
        openChildForm(New BasketBallView)
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

        Guna2Panel4.Controls.Add(childForm)
        Guna2Panel4.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

        If activeForm IsNot Nothing Then
            activeForm.Hide()
            activeForm = Nothing
        End If

        Label2.Text = "BASKETBALL CONTROL PANEL"
    End Sub

    Private Sub BackBtn_Click_1(sender As Object, e As EventArgs) Handles BackBtn.Click
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub MovePanel(button As Guna2Button)
        Panel1.Top = button.Top
        Panel1.Height = button.Height

        If Panel1.Top < 0 Then
            Panel1.Top = 0
        End If

        If Panel1.Bottom > Me.ClientSize.Height Then
            Panel1.Top = Me.ClientSize.Height - Panel1.Height
        End If

        Panel1.BringToFront()
    End Sub

    Private Sub moveBarPanel(sender As Object)
        Dim b As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Panel1.Location = New Point(b.Location.X - 121, b.Location.Y - 30)
        Panel1.SendToBack()
    End Sub

    Private Sub Guna2Button1_CheckedChanged(sender As Object, e As EventArgs)
        moveBarPanel(sender)
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        If activeForm IsNot Nothing Then
            activeForm.Hide()
            activeForm = Nothing
        End If

        MovePanel(Guna2Button5)
        UpdateCounts()
    End Sub

    Private connectionStringBB As String = "DataSource=SportsBasketballDatabase.db;Version=3;"

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
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Members"

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
        Dim sql As String = "SELECT COUNT(DISTINCT [Team Coach]) - 1 FROM Teams"

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
        Dim datenow As DateTime = DateTime.Now
        Dim yearToday As String = datenow.Year.ToString()
        YearText.Text = yearToday
    End Sub

    Private Sub UpdateCounts()
        Label1.Text = GetTeamCount().ToString()
        Label5.Text = GetPlayerCount().ToString()
        Label7.Text = GetCoachCount().ToString()

    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        MovePanel(EditTeamBtn)
        openChildForm(New BasketballMVP)
    End Sub

    Public Sub OpenChildFormInPanel(childForm As Form)
        If activeForm IsNot Nothing Then
            activeForm.Close()
        End If

        activeForm = childForm
        childForm.TopLevel = False
        childForm.Dock = DockStyle.Fill
        childForm.FormBorderStyle = FormBorderStyle.None

        Guna2Panel4.Controls.Add(childForm)
        Guna2Panel4.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub


End Class
