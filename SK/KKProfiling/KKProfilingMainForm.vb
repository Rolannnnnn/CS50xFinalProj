
Imports System.Data.SQLite
Imports Guna.UI2.WinForms

Public Class KKProfilingMainForm

    Private Sub BackBttn_Click(sender As Object, e As EventArgs)
        MainForm.Show()
        Close()
    End Sub

    Private Sub KKProfilingDataBtn_Click(sender As Object, e As EventArgs)
        KKProfilingForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        MovePanel(Guna2Button1)
        openChildForm(New KKPofilingEdit)

        Label1.Text = "KK PROFILING EDIT"

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        MovePanel(Guna2Button4)
        openChildForm(New KKProfilingDelete)
        Label1.Text = "KK PROFILING DELETE"
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        MovePanel(Guna2Button2)
        openChildForm(New KKProfilingData)
        Label1.Text = "KK PROFILING DATA"
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        MovePanel(Guna2Button3)
        openChildForm(New KKProfilingForm)
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

    Private Sub BackBttn_Click_1(sender As Object, e As EventArgs) Handles BackBttn.Click
        Close()
        MainForm.Show()
    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox3.Click
        Close()
        MainForm.Show()
    End Sub

    Private connectionStringKKP As String = "Data Source=Information.db;Version=3;"

    Public Function GetYouthCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) - 1 FROM Youth"

        Using connection As New SQLiteConnection(connectionStringKKP)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Public Function GetMaleCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) FROM Youth WHERE Sex = 'Male'"

        Using connection As New SQLiteConnection(connectionStringKKP)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Public Function GetFemaleCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) FROM Youth WHERE Sex = 'Female'"

        Using connection As New SQLiteConnection(connectionStringKKP)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Public Function GetVoterCount() As Integer
        Dim count As Integer = 0
        Dim sql As String = "SELECT COUNT(*) FROM Youth WHERE IsVoter = 'Yes'"

        Using connection As New SQLiteConnection(connectionStringKKP)
            connection.Open()
            Using command As New SQLiteCommand(sql, connection)
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateCounts()
    End Sub

    Private Sub UpdateCounts()
        Dim youthCount As Integer = GetYouthCount()
        Label2.Text = youthCount.ToString()
        Label5.Text = GetMaleCount().ToString()
        Label7.Text = GetFemaleCount().ToString()
        Label9.Text = GetVoterCount().ToString()
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

        Label2.Text = "KK PROFILING MAIN"


        MovePanel(Guna2Button5)
        UpdateCounts()
    End Sub
End Class