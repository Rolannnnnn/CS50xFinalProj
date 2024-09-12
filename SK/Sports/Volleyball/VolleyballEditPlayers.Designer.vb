<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballEditPlayers
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.JNumTB = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TeamCB = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.HeightTB = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.WeightTB = New System.Windows.Forms.TextBox()
        Me.ConfirmBtn = New System.Windows.Forms.Button()
        Me.Position1CB = New System.Windows.Forms.ComboBox()
        Me.DivisionCB = New System.Windows.Forms.ComboBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.PlayerNameCB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(373, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Edit Player"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(381, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Select Player"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(400, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Position"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(529, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Jersey Number"
        '
        'JNumTB
        '
        Me.JNumTB.Location = New System.Drawing.Point(520, 262)
        Me.JNumTB.Name = "JNumTB"
        Me.JNumTB.Size = New System.Drawing.Size(109, 20)
        Me.JNumTB.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(265, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Team"
        '
        'TeamCB
        '
        Me.TeamCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamCB.FormattingEnabled = True
        Me.TeamCB.Location = New System.Drawing.Point(228, 260)
        Me.TeamCB.Name = "TeamCB"
        Me.TeamCB.Size = New System.Drawing.Size(109, 21)
        Me.TeamCB.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(249, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Division"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(404, 306)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Height"
        '
        'HeightTB
        '
        Me.HeightTB.Location = New System.Drawing.Point(371, 333)
        Me.HeightTB.Name = "HeightTB"
        Me.HeightTB.Size = New System.Drawing.Size(109, 20)
        Me.HeightTB.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(548, 306)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Weight"
        '
        'WeightTB
        '
        Me.WeightTB.Location = New System.Drawing.Point(520, 333)
        Me.WeightTB.Name = "WeightTB"
        Me.WeightTB.Size = New System.Drawing.Size(109, 20)
        Me.WeightTB.TabIndex = 18
        '
        'ConfirmBtn
        '
        Me.ConfirmBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBtn.FlatAppearance.BorderSize = 0
        Me.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConfirmBtn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBtn.Location = New System.Drawing.Point(378, 419)
        Me.ConfirmBtn.Name = "ConfirmBtn"
        Me.ConfirmBtn.Size = New System.Drawing.Size(115, 30)
        Me.ConfirmBtn.TabIndex = 19
        Me.ConfirmBtn.Text = "Confirm Changes"
        Me.ConfirmBtn.UseVisualStyleBackColor = False
        '
        'Position1CB
        '
        Me.Position1CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Position1CB.FormattingEnabled = True
        Me.Position1CB.Items.AddRange(New Object() {"Setter", "Outside Hitter", "Middle Hitter", "Opposite Hitter", "Libero", "Defensive Specialist"})
        Me.Position1CB.Location = New System.Drawing.Point(370, 261)
        Me.Position1CB.Name = "Position1CB"
        Me.Position1CB.Size = New System.Drawing.Size(110, 21)
        Me.Position1CB.TabIndex = 20
        '
        'DivisionCB
        '
        Me.DivisionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DivisionCB.FormattingEnabled = True
        Me.DivisionCB.Items.AddRange(New Object() {"Youth Division", "Men's and Women's Division", "Seniors Division", "Mixed Division", "Community or Recreational Division"})
        Me.DivisionCB.Location = New System.Drawing.Point(224, 332)
        Me.DivisionCB.Name = "DivisionCB"
        Me.DivisionCB.Size = New System.Drawing.Size(110, 21)
        Me.DivisionCB.TabIndex = 21
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(180, 367)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(478, 19)
        Me.FeedbackLbl.TabIndex = 23
        Me.FeedbackLbl.Text = "Click the player to edit and fill in the player details in the fields"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlayerNameCB
        '
        Me.PlayerNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerNameCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerNameCB.FormattingEnabled = True
        Me.PlayerNameCB.Location = New System.Drawing.Point(372, 199)
        Me.PlayerNameCB.Name = "PlayerNameCB"
        Me.PlayerNameCB.Size = New System.Drawing.Size(109, 20)
        Me.PlayerNameCB.TabIndex = 24
        '
        'VolleyballEditPlayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.PlayerNameCB)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.DivisionCB)
        Me.Controls.Add(Me.Position1CB)
        Me.Controls.Add(Me.ConfirmBtn)
        Me.Controls.Add(Me.WeightTB)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.HeightTB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TeamCB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.JNumTB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballEditPlayers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "s"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents JNumTB As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TeamCB As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents HeightTB As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents WeightTB As TextBox
    Friend WithEvents ConfirmBtn As Button
    Friend WithEvents Position1CB As ComboBox
    Friend WithEvents DivisionCB As ComboBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents PlayerNameCB As ComboBox
End Class
