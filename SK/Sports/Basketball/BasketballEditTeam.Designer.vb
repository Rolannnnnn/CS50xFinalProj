<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballEditTeam
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
        Me.TeamCBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TeamCoachTBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TeamNameTB = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DivisionTBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(424, 85)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edit Team"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 233)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Team: "
        '
        'TeamCBox
        '
        Me.TeamCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamCBox.FormattingEnabled = True
        Me.TeamCBox.Location = New System.Drawing.Point(431, 231)
        Me.TeamCBox.Margin = New System.Windows.Forms.Padding(4)
        Me.TeamCBox.Name = "TeamCBox"
        Me.TeamCBox.Size = New System.Drawing.Size(160, 24)
        Me.TeamCBox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 334)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Team Coach:"
        Me.Label3.Visible = False
        '
        'TeamCoachTBox
        '
        Me.TeamCoachTBox.Location = New System.Drawing.Point(188, 334)
        Me.TeamCoachTBox.Margin = New System.Windows.Forms.Padding(4)
        Me.TeamCoachTBox.Name = "TeamCoachTBox"
        Me.TeamCoachTBox.Size = New System.Drawing.Size(180, 22)
        Me.TeamCoachTBox.TabIndex = 4
        Me.TeamCoachTBox.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(608, 334)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Division:"
        Me.Label4.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button1.Location = New System.Drawing.Point(425, 535)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 31)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Confirm changes"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'TeamNameTB
        '
        Me.TeamNameTB.Location = New System.Drawing.Point(425, 431)
        Me.TeamNameTB.Margin = New System.Windows.Forms.Padding(4)
        Me.TeamNameTB.Name = "TeamNameTB"
        Me.TeamNameTB.Size = New System.Drawing.Size(180, 22)
        Me.TeamNameTB.TabIndex = 10
        Me.TeamNameTB.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(295, 430)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Team Name:"
        Me.Label5.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button2.Location = New System.Drawing.Point(405, 316)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(167, 38)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Confirm changes"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'DivisionTBox
        '
        Me.DivisionTBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DivisionTBox.FormattingEnabled = True
        Me.DivisionTBox.Items.AddRange(New Object() {"MOSQUITO", "MIDGET", "JUNIOR", "SENIOR"})
        Me.DivisionTBox.Location = New System.Drawing.Point(690, 330)
        Me.DivisionTBox.Margin = New System.Windows.Forms.Padding(4)
        Me.DivisionTBox.Name = "DivisionTBox"
        Me.DivisionTBox.Size = New System.Drawing.Size(196, 24)
        Me.DivisionTBox.TabIndex = 12
        Me.DivisionTBox.Visible = False
        '
        'BasketballEditTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(977, 751)
        Me.Controls.Add(Me.DivisionTBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TeamNameTB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TeamCoachTBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TeamCBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "BasketballEditTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasketballEditTeam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TeamCBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TeamCoachTBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TeamNameTB As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents DivisionTBox As ComboBox
End Class
