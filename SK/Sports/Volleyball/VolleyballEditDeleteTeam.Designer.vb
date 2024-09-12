<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballEditDeleteTeam
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
        Me.TNameLbl = New System.Windows.Forms.Label()
        Me.NewNameTB = New System.Windows.Forms.TextBox()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.EditBtn = New System.Windows.Forms.Button()
        Me.ConfirmBtn = New System.Windows.Forms.Button()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(321, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Edit or Delete Team"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(220, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Teams:"
        '
        'TeamNameCB
        '
        Me.TeamNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamNameCB.FormattingEnabled = True
        Me.TeamNameCB.Location = New System.Drawing.Point(281, 189)
        Me.TeamNameCB.Name = "TeamNameCB"
        Me.TeamNameCB.Size = New System.Drawing.Size(286, 21)
        Me.TeamNameCB.TabIndex = 3
        '
        'TNameLbl
        '
        Me.TNameLbl.AutoSize = True
        Me.TNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNameLbl.Location = New System.Drawing.Point(166, 279)
        Me.TNameLbl.Name = "TNameLbl"
        Me.TNameLbl.Size = New System.Drawing.Size(120, 17)
        Me.TNameLbl.TabIndex = 4
        Me.TNameLbl.Text = "New Team Name:"
        Me.TNameLbl.Visible = False
        '
        'NewNameTB
        '
        Me.NewNameTB.Location = New System.Drawing.Point(294, 277)
        Me.NewNameTB.Name = "NewNameTB"
        Me.NewNameTB.Size = New System.Drawing.Size(286, 20)
        Me.NewNameTB.TabIndex = 5
        Me.NewNameTB.Visible = False
        '
        'DeleteBtn
        '
        Me.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteBtn.FlatAppearance.BorderSize = 0
        Me.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteBtn.ForeColor = System.Drawing.Color.White
        Me.DeleteBtn.Location = New System.Drawing.Point(567, 409)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(82, 31)
        Me.DeleteBtn.TabIndex = 6
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = False
        '
        'EditBtn
        '
        Me.EditBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.EditBtn.FlatAppearance.BorderSize = 0
        Me.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditBtn.ForeColor = System.Drawing.Color.White
        Me.EditBtn.Location = New System.Drawing.Point(133, 409)
        Me.EditBtn.Name = "EditBtn"
        Me.EditBtn.Size = New System.Drawing.Size(81, 31)
        Me.EditBtn.TabIndex = 7
        Me.EditBtn.Text = "Edit"
        Me.EditBtn.UseVisualStyleBackColor = False
        '
        'ConfirmBtn
        '
        Me.ConfirmBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBtn.FlatAppearance.BorderSize = 0
        Me.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConfirmBtn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBtn.Location = New System.Drawing.Point(337, 408)
        Me.ConfirmBtn.Name = "ConfirmBtn"
        Me.ConfirmBtn.Size = New System.Drawing.Size(132, 32)
        Me.ConfirmBtn.TabIndex = 8
        Me.ConfirmBtn.Text = "Confirm Changes"
        Me.ConfirmBtn.UseVisualStyleBackColor = False
        Me.ConfirmBtn.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(166, 368)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(483, 19)
        Me.FeedbackLbl.TabIndex = 9
        Me.FeedbackLbl.Text = "Label3"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(166, 312)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Division"
        Me.Label3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Youth Division", "Men's and Women's Division", "Seniors Division", "Mixed Division", "Community or Recreational Division"})
        Me.ComboBox1.Location = New System.Drawing.Point(294, 309)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(286, 21)
        Me.ComboBox1.TabIndex = 11
        Me.ComboBox1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(294, 344)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(286, 20)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(166, 344)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Coach"
        Me.Label4.Visible = False
        '
        'VolleyballEditDeleteTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.ConfirmBtn)
        Me.Controls.Add(Me.EditBtn)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.NewNameTB)
        Me.Controls.Add(Me.TNameLbl)
        Me.Controls.Add(Me.TeamNameCB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballEditDeleteTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VolleyballEditDeleteTeam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TeamNameCB As ComboBox
    Friend WithEvents TNameLbl As Label
    Friend WithEvents NewNameTB As TextBox
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents EditBtn As Button
    Friend WithEvents ConfirmBtn As Button
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
End Class
