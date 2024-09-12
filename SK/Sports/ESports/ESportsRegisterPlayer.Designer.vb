<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ESportsRegisterPlayer
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TeamNameCB = New System.Windows.Forms.ComboBox()
        Me.PositionCB = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FeedbackTeamLbl = New System.Windows.Forms.Label()
        Me.FeedbackPlayerLbl = New System.Windows.Forms.Label()
        Me.FeedbackPositionLbl = New System.Windows.Forms.Label()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.PlayerCBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(287, 134)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 36)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Register a Player"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 206)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Team:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(159, 243)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Player Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(159, 281)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 19)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Position"
        '
        'TeamNameCB
        '
        Me.TeamNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamNameCB.FormattingEnabled = True
        Me.TeamNameCB.Location = New System.Drawing.Point(258, 208)
        Me.TeamNameCB.Margin = New System.Windows.Forms.Padding(2)
        Me.TeamNameCB.Name = "TeamNameCB"
        Me.TeamNameCB.Size = New System.Drawing.Size(237, 21)
        Me.TeamNameCB.TabIndex = 10
        '
        'PositionCB
        '
        Me.PositionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionCB.FormattingEnabled = True
        Me.PositionCB.Items.AddRange(New Object() {"Roam", "Gold Lane", "Exp Lane", "Mid Lane", "Jungle"})
        Me.PositionCB.Location = New System.Drawing.Point(258, 279)
        Me.PositionCB.Margin = New System.Windows.Forms.Padding(2)
        Me.PositionCB.Name = "PositionCB"
        Me.PositionCB.Size = New System.Drawing.Size(237, 21)
        Me.PositionCB.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(533, 322)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 22)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Register"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FeedbackTeamLbl
        '
        Me.FeedbackTeamLbl.AutoSize = True
        Me.FeedbackTeamLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackTeamLbl.ForeColor = System.Drawing.Color.Red
        Me.FeedbackTeamLbl.Location = New System.Drawing.Point(512, 208)
        Me.FeedbackTeamLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackTeamLbl.Name = "FeedbackTeamLbl"
        Me.FeedbackTeamLbl.Size = New System.Drawing.Size(45, 19)
        Me.FeedbackTeamLbl.TabIndex = 15
        Me.FeedbackTeamLbl.Text = "Label5"
        Me.FeedbackTeamLbl.Visible = False
        '
        'FeedbackPlayerLbl
        '
        Me.FeedbackPlayerLbl.AutoSize = True
        Me.FeedbackPlayerLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackPlayerLbl.ForeColor = System.Drawing.Color.Red
        Me.FeedbackPlayerLbl.Location = New System.Drawing.Point(512, 246)
        Me.FeedbackPlayerLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackPlayerLbl.Name = "FeedbackPlayerLbl"
        Me.FeedbackPlayerLbl.Size = New System.Drawing.Size(45, 19)
        Me.FeedbackPlayerLbl.TabIndex = 16
        Me.FeedbackPlayerLbl.Text = "Label6"
        Me.FeedbackPlayerLbl.Visible = False
        '
        'FeedbackPositionLbl
        '
        Me.FeedbackPositionLbl.AutoSize = True
        Me.FeedbackPositionLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackPositionLbl.ForeColor = System.Drawing.Color.Red
        Me.FeedbackPositionLbl.Location = New System.Drawing.Point(512, 281)
        Me.FeedbackPositionLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackPositionLbl.Name = "FeedbackPositionLbl"
        Me.FeedbackPositionLbl.Size = New System.Drawing.Size(44, 19)
        Me.FeedbackPositionLbl.TabIndex = 17
        Me.FeedbackPositionLbl.Text = "Label7"
        Me.FeedbackPositionLbl.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.Green
        Me.FeedbackLbl.Location = New System.Drawing.Point(222, 316)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(292, 33)
        Me.FeedbackLbl.TabIndex = 18
        Me.FeedbackLbl.Text = "Label"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'PlayerCBox
        '
        Me.PlayerCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerCBox.FormattingEnabled = True
        Me.PlayerCBox.Location = New System.Drawing.Point(258, 246)
        Me.PlayerCBox.Margin = New System.Windows.Forms.Padding(2)
        Me.PlayerCBox.Name = "PlayerCBox"
        Me.PlayerCBox.Size = New System.Drawing.Size(237, 21)
        Me.PlayerCBox.TabIndex = 19
        '
        'ESportsRegisterPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 585)
        Me.Controls.Add(Me.PlayerCBox)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.FeedbackPositionLbl)
        Me.Controls.Add(Me.FeedbackPlayerLbl)
        Me.Controls.Add(Me.FeedbackTeamLbl)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PositionCB)
        Me.Controls.Add(Me.TeamNameCB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ESportsRegisterPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESportsRegisterPlayer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TeamNameCB As ComboBox
    Friend WithEvents PositionCB As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents FeedbackTeamLbl As Label
    Friend WithEvents FeedbackPlayerLbl As Label
    Friend WithEvents FeedbackPositionLbl As Label
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents PlayerCBox As ComboBox
End Class
