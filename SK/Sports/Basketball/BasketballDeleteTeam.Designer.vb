<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballDeleteTeam
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
        Me.DeleteTeamBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(380, 199)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Delete Team"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 334)
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
        Me.TeamCBox.Location = New System.Drawing.Point(328, 334)
        Me.TeamCBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TeamCBox.Name = "TeamCBox"
        Me.TeamCBox.Size = New System.Drawing.Size(345, 24)
        Me.TeamCBox.TabIndex = 2
        '
        'DeleteTeamBtn
        '
        Me.DeleteTeamBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteTeamBtn.FlatAppearance.BorderSize = 0
        Me.DeleteTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteTeamBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteTeamBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.DeleteTeamBtn.Location = New System.Drawing.Point(392, 453)
        Me.DeleteTeamBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeleteTeamBtn.Name = "DeleteTeamBtn"
        Me.DeleteTeamBtn.Size = New System.Drawing.Size(176, 44)
        Me.DeleteTeamBtn.TabIndex = 3
        Me.DeleteTeamBtn.Text = "Delete Team"
        Me.DeleteTeamBtn.UseVisualStyleBackColor = False
        '
        'BasketballDeleteTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(977, 751)
        Me.Controls.Add(Me.DeleteTeamBtn)
        Me.Controls.Add(Me.TeamCBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BasketballDeleteTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasketballDeleteTeam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TeamCBox As ComboBox
    Friend WithEvents DeleteTeamBtn As Button
End Class
