Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class VolleyballMainForm

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

    Private Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MovePanel(Button1)
        openChildForm(New VollerballAddplayers)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MovePanel(Button2)
        openChildForm(New VolleyballRegisterTeam)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MovePanel(Button3)
        openChildForm(New VolleyballRegisterGame)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MovePanel(Button6)
        openChildForm(New VolleyballEditDeleteTeam)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MovePanel(Button9)
        openChildForm(New VolleyballEditPlayers)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MovePanel(Button7)
        openChildForm(New VolleyballEditDeleteGame)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MovePanel(Button8)
        openChildForm(New VolleyballDeletePlayer)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MovePanel(Button10)
        openChildForm(New VolleyballView)
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
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
            button.FillColor = Color.FromArgb(255, 143, 0)
        Else
            button.FillColor = Color.FromArgb(175, 71, 210)
        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If activeForm IsNot Nothing Then
            activeForm.Hide()
            activeForm = Nothing
        End If

        Label2.Text = "VOLLEYBALL CONTROL PANEL"


        MovePanel(Guna2Button5)
        UpdateCounts()
    End Sub

    Private connectionStringBB As String = StringStorage.Addresser(StringStorage.SportsVolleyballDatabase)

    Public Function GetTeamCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Team"

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
        Dim sql As String = "SELECT COUNT(DISTINCT [Coach]) - 1 FROM Team"

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
        Dim yearnow As String = currentdate.Year.ToString()
        Label11.Text = yearnow
    End Sub

    Private Sub UpdateCounts()
        Label1.Text = GetTeamCount().ToString()
        Label5.Text = GetPlayerCount().ToString()
        Label7.Text = GetCoachCount().ToString()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        MovePanel(Guna2Button1)
        openChildForm(New VolleyballMVP)
    End Sub
End Class
