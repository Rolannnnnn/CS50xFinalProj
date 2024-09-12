<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballRegisterTeam
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
        Me.txtTeamName = New System.Windows.Forms.TextBox()
        Me.txtCoach = New System.Windows.Forms.TextBox()
        Me.lblTeamName = New System.Windows.Forms.Label()
        Me.lblCoach = New System.Windows.Forms.Label()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDivision = New System.Windows.Forms.ComboBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.GridTeam = New System.Windows.Forms.DataGridView()
        CType(Me.GridTeam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTeamName
        '
        Me.txtTeamName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeamName.Location = New System.Drawing.Point(68, 196)
        Me.txtTeamName.Name = "txtTeamName"
        Me.txtTeamName.Size = New System.Drawing.Size(246, 22)
        Me.txtTeamName.TabIndex = 0
        '
        'txtCoach
        '
        Me.txtCoach.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoach.Location = New System.Drawing.Point(68, 366)
        Me.txtCoach.Name = "txtCoach"
        Me.txtCoach.Size = New System.Drawing.Size(246, 22)
        Me.txtCoach.TabIndex = 2
        '
        'lblTeamName
        '
        Me.lblTeamName.AutoSize = True
        Me.lblTeamName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeamName.Location = New System.Drawing.Point(66, 169)
        Me.lblTeamName.Name = "lblTeamName"
        Me.lblTeamName.Size = New System.Drawing.Size(88, 16)
        Me.lblTeamName.TabIndex = 3
        Me.lblTeamName.Text = "TeamName"
        '
        'lblCoach
        '
        Me.lblCoach.AutoSize = True
        Me.lblCoach.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoach.Location = New System.Drawing.Point(66, 339)
        Me.lblCoach.Name = "lblCoach"
        Me.lblCoach.Size = New System.Drawing.Size(51, 16)
        Me.lblCoach.TabIndex = 4
        Me.lblCoach.Text = "Coach"
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.Location = New System.Drawing.Point(66, 247)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(63, 16)
        Me.lblPlayer.TabIndex = 5
        Me.lblPlayer.Text = "Division"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(320, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Volleyball Register"
        '
        'cmbDivision
        '
        Me.cmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Items.AddRange(New Object() {"Youth Division", "Men's and Women's Division", "Seniors Division", "Mixed Division", "Community or Recreational Division"})
        Me.cmbDivision.Location = New System.Drawing.Point(68, 278)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(246, 24)
        Me.cmbDivision.TabIndex = 7
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.btnRegister.FlatAppearance.BorderSize = 0
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(146, 423)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(84, 30)
        Me.btnRegister.TabIndex = 8
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'GridTeam
        '
        Me.GridTeam.AllowUserToAddRows = False
        Me.GridTeam.AllowUserToDeleteRows = False
        Me.GridTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTeam.Location = New System.Drawing.Point(506, 175)
        Me.GridTeam.MultiSelect = False
        Me.GridTeam.Name = "GridTeam"
        Me.GridTeam.ReadOnly = True
        Me.GridTeam.RowHeadersWidth = 51
        Me.GridTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridTeam.Size = New System.Drawing.Size(238, 241)
        Me.GridTeam.TabIndex = 11
        '
        'VolleyballRegisterTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.GridTeam)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.cmbDivision)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.lblCoach)
        Me.Controls.Add(Me.lblTeamName)
        Me.Controls.Add(Me.txtCoach)
        Me.Controls.Add(Me.txtTeamName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballRegisterTeam"
        Me.Text = "VolleyballRegisterTeam"
        CType(Me.GridTeam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTeamName As TextBox
    Friend WithEvents txtCoach As TextBox
    Friend WithEvents lblTeamName As Label
    Friend WithEvents lblCoach As Label
    Friend WithEvents lblPlayer As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbDivision As ComboBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents GridTeam As DataGridView
End Class
