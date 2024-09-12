<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballDeletePlayer
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
        Me.PlayerDeleteBtn = New System.Windows.Forms.Button()
        Me.PlayerCBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(306, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Delete a player"
        '
        'PlayerDeleteBtn
        '
        Me.PlayerDeleteBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.PlayerDeleteBtn.FlatAppearance.BorderSize = 0
        Me.PlayerDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayerDeleteBtn.ForeColor = System.Drawing.Color.White
        Me.PlayerDeleteBtn.Location = New System.Drawing.Point(330, 287)
        Me.PlayerDeleteBtn.Name = "PlayerDeleteBtn"
        Me.PlayerDeleteBtn.Size = New System.Drawing.Size(75, 23)
        Me.PlayerDeleteBtn.TabIndex = 9
        Me.PlayerDeleteBtn.Text = "Delete"
        Me.PlayerDeleteBtn.UseVisualStyleBackColor = False
        '
        'PlayerCBox
        '
        Me.PlayerCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerCBox.FormattingEnabled = True
        Me.PlayerCBox.Location = New System.Drawing.Point(287, 248)
        Me.PlayerCBox.Name = "PlayerCBox"
        Me.PlayerCBox.Size = New System.Drawing.Size(220, 21)
        Me.PlayerCBox.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Player Name:"
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(146, 331)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(457, 19)
        Me.FeedbackLbl.TabIndex = 12
        Me.FeedbackLbl.Text = "FeedbackLbl"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'VolleyballDeletePlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlayerDeleteBtn)
        Me.Controls.Add(Me.PlayerCBox)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballDeletePlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VolleyballDeletePlayer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PlayerDeleteBtn As Button
    Friend WithEvents PlayerCBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FeedbackLbl As Label
End Class
