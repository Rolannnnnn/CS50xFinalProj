Public Class KKProfilingForm

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        KKProfilingConfirmation.Show()
        KKProfilingMainForm.Close()
    End Sub
End Class