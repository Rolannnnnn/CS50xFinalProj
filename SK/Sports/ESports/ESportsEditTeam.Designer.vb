<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ESportsEditTeam
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TeamNameCB = New System.Windows.Forms.ComboBox()
        Me.EditBttn = New System.Windows.Forms.Button()
        Me.DeleteBttn = New System.Windows.Forms.Button()
        Me.NewTeamLbl = New System.Windows.Forms.Label()
        Me.NewTeamTxtBox = New System.Windows.Forms.TextBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.ConfirmBttn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(280, 133)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edit or Delete Team"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 202)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Team:"
        '
        'TeamNameCB
        '
        Me.TeamNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamNameCB.FormattingEnabled = True
        Me.TeamNameCB.Location = New System.Drawing.Point(234, 194)
        Me.TeamNameCB.Margin = New System.Windows.Forms.Padding(2)
        Me.TeamNameCB.Name = "TeamNameCB"
        Me.TeamNameCB.Size = New System.Drawing.Size(345, 21)
        Me.TeamNameCB.TabIndex = 2
        '
        'EditBttn
        '
        Me.EditBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.EditBttn.ForeColor = System.Drawing.Color.White
        Me.EditBttn.Location = New System.Drawing.Point(133, 328)
        Me.EditBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.EditBttn.Name = "EditBttn"
        Me.EditBttn.Size = New System.Drawing.Size(76, 35)
        Me.EditBttn.TabIndex = 4
        Me.EditBttn.Text = "Edit"
        Me.EditBttn.UseVisualStyleBackColor = False
        '
        'DeleteBttn
        '
        Me.DeleteBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteBttn.ForeColor = System.Drawing.Color.White
        Me.DeleteBttn.Location = New System.Drawing.Point(550, 328)
        Me.DeleteBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.DeleteBttn.Name = "DeleteBttn"
        Me.DeleteBttn.Size = New System.Drawing.Size(76, 35)
        Me.DeleteBttn.TabIndex = 5
        Me.DeleteBttn.Text = "Delete"
        Me.DeleteBttn.UseVisualStyleBackColor = False
        '
        'NewTeamLbl
        '
        Me.NewTeamLbl.AutoSize = True
        Me.NewTeamLbl.Location = New System.Drawing.Point(142, 241)
        Me.NewTeamLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.NewTeamLbl.Name = "NewTeamLbl"
        Me.NewTeamLbl.Size = New System.Drawing.Size(93, 13)
        Me.NewTeamLbl.TabIndex = 6
        Me.NewTeamLbl.Text = "New Team Name:"
        Me.NewTeamLbl.Visible = False
        '
        'NewTeamTxtBox
        '
        Me.NewTeamTxtBox.Location = New System.Drawing.Point(234, 236)
        Me.NewTeamTxtBox.Margin = New System.Windows.Forms.Padding(2)
        Me.NewTeamTxtBox.Name = "NewTeamTxtBox"
        Me.NewTeamTxtBox.Size = New System.Drawing.Size(345, 20)
        Me.NewTeamTxtBox.TabIndex = 7
        Me.NewTeamTxtBox.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(131, 265)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(476, 45)
        Me.FeedbackLbl.TabIndex = 8
        Me.FeedbackLbl.Text = "Select the Team that will be Edited or Deleted"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ConfirmBttn
        '
        Me.ConfirmBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBttn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBttn.Location = New System.Drawing.Point(318, 328)
        Me.ConfirmBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.ConfirmBttn.Name = "ConfirmBttn"
        Me.ConfirmBttn.Size = New System.Drawing.Size(132, 35)
        Me.ConfirmBttn.TabIndex = 9
        Me.ConfirmBttn.Text = "Confirm Changes"
        Me.ConfirmBttn.UseVisualStyleBackColor = False
        Me.ConfirmBttn.Visible = False
        '
        'ESportsEditTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 585)
        Me.Controls.Add(Me.ConfirmBttn)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.NewTeamTxtBox)
        Me.Controls.Add(Me.NewTeamLbl)
        Me.Controls.Add(Me.DeleteBttn)
        Me.Controls.Add(Me.EditBttn)
        Me.Controls.Add(Me.TeamNameCB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ESportsEditTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESportsEditTeam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TeamNameCB As ComboBox
    Friend WithEvents EditBttn As Button
    Friend WithEvents DeleteBttn As Button
    Friend WithEvents NewTeamLbl As Label
    Friend WithEvents NewTeamTxtBox As TextBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents ConfirmBttn As Button
End Class
