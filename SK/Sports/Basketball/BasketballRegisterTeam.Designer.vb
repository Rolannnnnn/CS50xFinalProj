<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballRegisterTeam
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
        Me.RegisterTeamBtn = New System.Windows.Forms.Button()
        Me.ErrorLbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TeamNameTBox = New System.Windows.Forms.TextBox()
        Me.TeamCoachTBox = New System.Windows.Forms.TextBox()
        Me.DivisionCB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(144, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Team Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(595, 130)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Team Coach"
        '
        'RegisterTeamBtn
        '
        Me.RegisterTeamBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.RegisterTeamBtn.FlatAppearance.BorderSize = 0
        Me.RegisterTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RegisterTeamBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegisterTeamBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.RegisterTeamBtn.Location = New System.Drawing.Point(369, 481)
        Me.RegisterTeamBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RegisterTeamBtn.Name = "RegisterTeamBtn"
        Me.RegisterTeamBtn.Size = New System.Drawing.Size(163, 38)
        Me.RegisterTeamBtn.TabIndex = 5
        Me.RegisterTeamBtn.Text = "RegisterTeam"
        Me.RegisterTeamBtn.UseVisualStyleBackColor = False
        '
        'ErrorLbl
        '
        Me.ErrorLbl.AutoSize = True
        Me.ErrorLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorLbl.Location = New System.Drawing.Point(408, 535)
        Me.ErrorLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ErrorLbl.Name = "ErrorLbl"
        Me.ErrorLbl.Size = New System.Drawing.Size(79, 17)
        Me.ErrorLbl.TabIndex = 6
        Me.ErrorLbl.Text = "Error Label"
        Me.ErrorLbl.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(399, 316)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 29)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Division"
        '
        'TeamNameTBox
        '
        Me.TeamNameTBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TeamNameTBox.Location = New System.Drawing.Point(97, 171)
        Me.TeamNameTBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TeamNameTBox.Name = "TeamNameTBox"
        Me.TeamNameTBox.Size = New System.Drawing.Size(265, 24)
        Me.TeamNameTBox.TabIndex = 12
        '
        'TeamCoachTBox
        '
        Me.TeamCoachTBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TeamCoachTBox.Location = New System.Drawing.Point(531, 171)
        Me.TeamCoachTBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TeamCoachTBox.Name = "TeamCoachTBox"
        Me.TeamCoachTBox.Size = New System.Drawing.Size(265, 24)
        Me.TeamCoachTBox.TabIndex = 13
        '
        'DivisionCB
        '
        Me.DivisionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DivisionCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DivisionCB.FormattingEnabled = True
        Me.DivisionCB.Items.AddRange(New Object() {"MOSQUITO", "MIDGET", "JUNIOR", "SENIOR"})
        Me.DivisionCB.Location = New System.Drawing.Point(343, 382)
        Me.DivisionCB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DivisionCB.Name = "DivisionCB"
        Me.DivisionCB.Size = New System.Drawing.Size(217, 26)
        Me.DivisionCB.TabIndex = 14
        '
        'BasketballRegisterTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(977, 751)
        Me.Controls.Add(Me.DivisionCB)
        Me.Controls.Add(Me.TeamCoachTBox)
        Me.Controls.Add(Me.TeamNameTBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ErrorLbl)
        Me.Controls.Add(Me.RegisterTeamBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BasketballRegisterTeam"
        Me.Text = "S"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RegisterTeamBtn As Button
    Friend WithEvents ErrorLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TeamNameTBox As TextBox
    Friend WithEvents TeamCoachTBox As TextBox
    Friend WithEvents DivisionCB As ComboBox
End Class
