<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballAddPlayers
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
        Me.JerseyNumberTBox = New System.Windows.Forms.TextBox()
        Me.PositionCBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DivisionCBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HeightTBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.WeightTBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TeamCBox = New System.Windows.Forms.ComboBox()
        Me.RegisterPlayerBtn = New System.Windows.Forms.Button()
        Me.FeedBLbl = New System.Windows.Forms.Label()
        Me.PlayerNameCBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Player Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jersey Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(144, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Position"
        '
        'JerseyNumberTBox
        '
        Me.JerseyNumberTBox.Location = New System.Drawing.Point(125, 209)
        Me.JerseyNumberTBox.Name = "JerseyNumberTBox"
        Me.JerseyNumberTBox.Size = New System.Drawing.Size(129, 20)
        Me.JerseyNumberTBox.TabIndex = 5
        '
        'PositionCBox
        '
        Me.PositionCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionCBox.FormattingEnabled = True
        Me.PositionCBox.Items.AddRange(New Object() {"PG", "SG", "SF", "PF", "C"})
        Me.PositionCBox.Location = New System.Drawing.Point(125, 288)
        Me.PositionCBox.Name = "PositionCBox"
        Me.PositionCBox.Size = New System.Drawing.Size(129, 21)
        Me.PositionCBox.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(144, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division"
        '
        'DivisionCBox
        '
        Me.DivisionCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DivisionCBox.FormattingEnabled = True
        Me.DivisionCBox.Items.AddRange(New Object() {"MOSQUITO", "MIDGET", "JUNIOR", "SENIOR"})
        Me.DivisionCBox.Location = New System.Drawing.Point(125, 361)
        Me.DivisionCBox.Name = "DivisionCBox"
        Me.DivisionCBox.Size = New System.Drawing.Size(129, 21)
        Me.DivisionCBox.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(480, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 25)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Height"
        '
        'HeightTBox
        '
        Me.HeightTBox.Location = New System.Drawing.Point(457, 179)
        Me.HeightTBox.Name = "HeightTBox"
        Me.HeightTBox.Size = New System.Drawing.Size(129, 20)
        Me.HeightTBox.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(480, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Weight"
        '
        'WeightTBox
        '
        Me.WeightTBox.Location = New System.Drawing.Point(457, 257)
        Me.WeightTBox.Name = "WeightTBox"
        Me.WeightTBox.Size = New System.Drawing.Size(129, 20)
        Me.WeightTBox.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(487, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Team"
        '
        'TeamCBox
        '
        Me.TeamCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamCBox.FormattingEnabled = True
        Me.TeamCBox.Location = New System.Drawing.Point(457, 328)
        Me.TeamCBox.Name = "TeamCBox"
        Me.TeamCBox.Size = New System.Drawing.Size(129, 21)
        Me.TeamCBox.TabIndex = 14
        '
        'RegisterPlayerBtn
        '
        Me.RegisterPlayerBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.RegisterPlayerBtn.FlatAppearance.BorderSize = 0
        Me.RegisterPlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RegisterPlayerBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegisterPlayerBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.RegisterPlayerBtn.Location = New System.Drawing.Point(307, 463)
        Me.RegisterPlayerBtn.Name = "RegisterPlayerBtn"
        Me.RegisterPlayerBtn.Size = New System.Drawing.Size(118, 34)
        Me.RegisterPlayerBtn.TabIndex = 15
        Me.RegisterPlayerBtn.Text = "Register Player"
        Me.RegisterPlayerBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RegisterPlayerBtn.UseVisualStyleBackColor = False
        '
        'FeedBLbl
        '
        Me.FeedBLbl.AutoSize = True
        Me.FeedBLbl.Location = New System.Drawing.Point(345, 500)
        Me.FeedBLbl.Name = "FeedBLbl"
        Me.FeedBLbl.Size = New System.Drawing.Size(39, 13)
        Me.FeedBLbl.TabIndex = 17
        Me.FeedBLbl.Text = "Label8"
        Me.FeedBLbl.Visible = False
        '
        'PlayerNameCBox
        '
        Me.PlayerNameCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerNameCBox.FormattingEnabled = True
        Me.PlayerNameCBox.Location = New System.Drawing.Point(125, 139)
        Me.PlayerNameCBox.Name = "PlayerNameCBox"
        Me.PlayerNameCBox.Size = New System.Drawing.Size(129, 21)
        Me.PlayerNameCBox.TabIndex = 18
        '
        'BasketballAddPlayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(733, 610)
        Me.Controls.Add(Me.PlayerNameCBox)
        Me.Controls.Add(Me.FeedBLbl)
        Me.Controls.Add(Me.RegisterPlayerBtn)
        Me.Controls.Add(Me.TeamCBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.WeightTBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HeightTBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DivisionCBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PositionCBox)
        Me.Controls.Add(Me.JerseyNumberTBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BasketballAddPlayers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasketballAddPlayers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents JerseyNumberTBox As TextBox
    Friend WithEvents PositionCBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DivisionCBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents HeightTBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents WeightTBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TeamCBox As ComboBox
    Friend WithEvents RegisterPlayerBtn As Button
    Friend WithEvents FeedBLbl As Label
    Friend WithEvents PlayerNameCBox As ComboBox
End Class
