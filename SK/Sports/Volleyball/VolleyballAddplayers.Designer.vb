<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VollerballAddplayers
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
        Me.lblPlayerName = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtJerseyNumber = New System.Windows.Forms.TextBox()
        Me.cmbPosition = New System.Windows.Forms.ComboBox()
        Me.cmbDivison = New System.Windows.Forms.ComboBox()
        Me.cmbTeam = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.FeedBackLbl = New System.Windows.Forms.Label()
        Me.PlayerNameCB = New System.Windows.Forms.ComboBox()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPlayerName
        '
        Me.lblPlayerName.AutoSize = True
        Me.lblPlayerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerName.Location = New System.Drawing.Point(62, 138)
        Me.lblPlayerName.Name = "lblPlayerName"
        Me.lblPlayerName.Size = New System.Drawing.Size(97, 16)
        Me.lblPlayerName.TabIndex = 0
        Me.lblPlayerName.Text = "Player Name"
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(179, 258)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(148, 22)
        Me.txtWeight.TabIndex = 2
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(179, 216)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(148, 22)
        Me.txtHeight.TabIndex = 3
        '
        'txtJerseyNumber
        '
        Me.txtJerseyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJerseyNumber.Location = New System.Drawing.Point(179, 175)
        Me.txtJerseyNumber.Name = "txtJerseyNumber"
        Me.txtJerseyNumber.Size = New System.Drawing.Size(148, 22)
        Me.txtJerseyNumber.TabIndex = 4
        '
        'cmbPosition
        '
        Me.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPosition.FormattingEnabled = True
        Me.cmbPosition.Items.AddRange(New Object() {"Setter", "Outside Hitter", "Middle Hitter", "Opposite Hitter", "Libero", "Defensive Specialist"})
        Me.cmbPosition.Location = New System.Drawing.Point(179, 383)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(148, 24)
        Me.cmbPosition.TabIndex = 5
        '
        'cmbDivison
        '
        Me.cmbDivison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDivison.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDivison.FormattingEnabled = True
        Me.cmbDivison.Items.AddRange(New Object() {"Youth Division", "Men's and Women's Division", "Seniors Division", "Mixed Division", "Community or Recreational Division"})
        Me.cmbDivison.Location = New System.Drawing.Point(179, 299)
        Me.cmbDivison.Name = "cmbDivison"
        Me.cmbDivison.Size = New System.Drawing.Size(148, 24)
        Me.cmbDivison.TabIndex = 6
        '
        'cmbTeam
        '
        Me.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTeam.FormattingEnabled = True
        Me.cmbTeam.Location = New System.Drawing.Point(179, 340)
        Me.cmbTeam.Name = "cmbTeam"
        Me.cmbTeam.Size = New System.Drawing.Size(148, 24)
        Me.cmbTeam.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Position"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(62, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Weight"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(62, 221)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(52, 16)
        Me.lblHeight.TabIndex = 10
        Me.lblHeight.Text = "Height"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(62, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Jersey Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(62, 346)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Team"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(62, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Division"
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.btnRegister.FlatAppearance.BorderSize = 0
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(179, 449)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(79, 28)
        Me.btnRegister.TabIndex = 14
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(337, 67)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(158, 25)
        Me.lbl1.TabIndex = 16
        Me.lbl1.Text = "Register Player"
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid1.Location = New System.Drawing.Point(483, 135)
        Me.Grid1.MultiSelect = False
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersWidth = 51
        Me.Grid1.Size = New System.Drawing.Size(302, 329)
        Me.Grid1.TabIndex = 17
        '
        'FeedBackLbl
        '
        Me.FeedBackLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedBackLbl.Location = New System.Drawing.Point(91, 499)
        Me.FeedBackLbl.Name = "FeedBackLbl"
        Me.FeedBackLbl.Size = New System.Drawing.Size(650, 39)
        Me.FeedBackLbl.TabIndex = 20
        Me.FeedBackLbl.Text = "Label1"
        Me.FeedBackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedBackLbl.Visible = False
        '
        'PlayerNameCB
        '
        Me.PlayerNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerNameCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerNameCB.FormattingEnabled = True
        Me.PlayerNameCB.Location = New System.Drawing.Point(179, 135)
        Me.PlayerNameCB.Name = "PlayerNameCB"
        Me.PlayerNameCB.Size = New System.Drawing.Size(148, 20)
        Me.PlayerNameCB.TabIndex = 22
        '
        'VollerballAddplayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.PlayerNameCB)
        Me.Controls.Add(Me.FeedBackLbl)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTeam)
        Me.Controls.Add(Me.cmbDivison)
        Me.Controls.Add(Me.cmbPosition)
        Me.Controls.Add(Me.txtJerseyNumber)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.lblPlayerName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VollerballAddplayers"
        Me.Text = "VollerballAddplayers"
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPlayerName As Label
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents txtJerseyNumber As TextBox
    Friend WithEvents cmbPosition As ComboBox
    Friend WithEvents cmbDivison As ComboBox
    Friend WithEvents cmbTeam As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnRegister As Button
    Friend WithEvents lbl1 As Label
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents FeedBackLbl As Label
    Friend WithEvents PlayerNameCB As ComboBox
End Class
