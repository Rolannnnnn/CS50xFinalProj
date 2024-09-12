<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballEditPlayer
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
        Me.SelectPlayerCB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.JerseyNumberTB = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PositionCB = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DivisionCB = New System.Windows.Forms.ComboBox()
        Me.HeightTB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.WeightTB = New System.Windows.Forms.TextBox()
        Me.ConfirmBtn = New System.Windows.Forms.Button()
        Me.TeamCB = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(428, 102)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edit Player"
        '
        'SelectPlayerCB
        '
        Me.SelectPlayerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SelectPlayerCB.FormattingEnabled = True
        Me.SelectPlayerCB.Location = New System.Drawing.Point(405, 224)
        Me.SelectPlayerCB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SelectPlayerCB.Name = "SelectPlayerCB"
        Me.SelectPlayerCB.Size = New System.Drawing.Size(160, 24)
        Me.SelectPlayerCB.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(412, 188)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Select Player"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(403, 271)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Jersey Number"
        '
        'JerseyNumberTB
        '
        Me.JerseyNumberTB.Location = New System.Drawing.Point(405, 306)
        Me.JerseyNumberTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.JerseyNumberTB.Name = "JerseyNumberTB"
        Me.JerseyNumberTB.Size = New System.Drawing.Size(160, 22)
        Me.JerseyNumberTB.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(760, 271)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 24)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Position"
        '
        'PositionCB
        '
        Me.PositionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionCB.FormattingEnabled = True
        Me.PositionCB.Items.AddRange(New Object() {"PG", "SG", "SF", "PF", "C"})
        Me.PositionCB.Location = New System.Drawing.Point(728, 306)
        Me.PositionCB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PositionCB.Name = "PositionCB"
        Me.PositionCB.Size = New System.Drawing.Size(160, 24)
        Me.PositionCB.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(115, 410)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 24)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Division"
        '
        'DivisionCB
        '
        Me.DivisionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DivisionCB.FormattingEnabled = True
        Me.DivisionCB.Items.AddRange(New Object() {"MOSQUITO", "MIDGET", "JUNIOR", "SENIOR"})
        Me.DivisionCB.Location = New System.Drawing.Point(85, 444)
        Me.DivisionCB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DivisionCB.Name = "DivisionCB"
        Me.DivisionCB.Size = New System.Drawing.Size(163, 24)
        Me.DivisionCB.TabIndex = 10
        '
        'HeightTB
        '
        Me.HeightTB.Location = New System.Drawing.Point(405, 446)
        Me.HeightTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.HeightTB.Name = "HeightTB"
        Me.HeightTB.Size = New System.Drawing.Size(160, 22)
        Me.HeightTB.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(447, 410)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 24)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Height"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(760, 410)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Weight"
        '
        'WeightTB
        '
        Me.WeightTB.Location = New System.Drawing.Point(728, 446)
        Me.WeightTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WeightTB.Name = "WeightTB"
        Me.WeightTB.Size = New System.Drawing.Size(160, 22)
        Me.WeightTB.TabIndex = 14
        '
        'ConfirmBtn
        '
        Me.ConfirmBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBtn.FlatAppearance.BorderSize = 0
        Me.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConfirmBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirmBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.ConfirmBtn.Location = New System.Drawing.Point(407, 564)
        Me.ConfirmBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ConfirmBtn.Name = "ConfirmBtn"
        Me.ConfirmBtn.Size = New System.Drawing.Size(161, 34)
        Me.ConfirmBtn.TabIndex = 16
        Me.ConfirmBtn.Text = "Confirm Changes"
        Me.ConfirmBtn.UseVisualStyleBackColor = False
        '
        'TeamCB
        '
        Me.TeamCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamCB.FormattingEnabled = True
        Me.TeamCB.Location = New System.Drawing.Point(85, 304)
        Me.TeamCB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TeamCB.Name = "TeamCB"
        Me.TeamCB.Size = New System.Drawing.Size(163, 24)
        Me.TeamCB.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 268)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 24)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Team"
        '
        'BasketballEditPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(977, 751)
        Me.Controls.Add(Me.TeamCB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ConfirmBtn)
        Me.Controls.Add(Me.WeightTB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.HeightTB)
        Me.Controls.Add(Me.DivisionCB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PositionCB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.JerseyNumberTB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelectPlayerCB)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BasketballEditPlayer"
        Me.ShowInTaskbar = False
        Me.Text = "BasketballEditPlayer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SelectPlayerCB As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents JerseyNumberTB As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PositionCB As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DivisionCB As ComboBox
    Friend WithEvents HeightTB As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents WeightTB As TextBox
    Friend WithEvents ConfirmBtn As Button
    Friend WithEvents TeamCB As ComboBox
    Friend WithEvents Label3 As Label
End Class
