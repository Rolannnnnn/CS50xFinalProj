Imports System.Data.SqlClient
Public Class SportsMainForm
    Private Sub SportsMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BasketballMainForm.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        VolleyballMainForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ESportsMainForm.Show()
        Close()
    End Sub

    Private Sub BackBttn_Click_1(sender As Object, e As EventArgs) Handles BackBttn.Click
        MainForm.Show()
        Close()
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Close()
        MainForm.Show()
    End Sub
End Class