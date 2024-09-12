Imports System.Data.SQLite
Imports System.Drawing.Text
Imports Guna.UI2.WinForms

Public Class MainForm
    Private Sub ExitBttn_Click(sender As Object, e As EventArgs)
        Login.logged = ""
        Login.Show()
        Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        KKProfilingMainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        BudgetMainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        SportsMainForm.Show()
        Close()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        CalendarMainForm.Show()
        Close()
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Login.logged = "" Then
            MessageBox.Show("Please login again.")
            Login.Show()
            Close()
        End If
    End Sub

    Private Sub ExitBttn_Click_1(sender As Object, e As EventArgs) Handles ExitBttn.Click
        Close()
        Login.Show()
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Close()
        Login.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        AccountCreation.Show()
        Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        SecurityLogs.Show()
        Close()
    End Sub
End Class
