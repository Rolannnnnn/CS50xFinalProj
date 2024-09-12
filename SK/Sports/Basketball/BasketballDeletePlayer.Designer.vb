<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballDeletePlayer
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlayerCBox = New System.Windows.Forms.ComboBox()
        Me.PlayerDeleteBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(203, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Player Name"
        '
        'PlayerCBox
        '
        Me.PlayerCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerCBox.FormattingEnabled = True
        Me.PlayerCBox.Location = New System.Drawing.Point(276, 239)
        Me.PlayerCBox.Name = "PlayerCBox"
        Me.PlayerCBox.Size = New System.Drawing.Size(220, 21)
        Me.PlayerCBox.TabIndex = 3
        '
        'PlayerDeleteBtn
        '
        Me.PlayerDeleteBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.PlayerDeleteBtn.FlatAppearance.BorderSize = 0
        Me.PlayerDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayerDeleteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerDeleteBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.PlayerDeleteBtn.Location = New System.Drawing.Point(317, 340)
        Me.PlayerDeleteBtn.Name = "PlayerDeleteBtn"
        Me.PlayerDeleteBtn.Size = New System.Drawing.Size(95, 35)
        Me.PlayerDeleteBtn.TabIndex = 4
        Me.PlayerDeleteBtn.Text = "Delete"
        Me.PlayerDeleteBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Delete a player"
        '
        'BasketballDeletePlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(733, 610)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlayerDeleteBtn)
        Me.Controls.Add(Me.PlayerCBox)
        Me.Controls.Add(Me.Label2)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BasketballDeletePlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasketballDeletePlayer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents PlayerCBox As ComboBox
    Friend WithEvents PlayerDeleteBtn As Button
    Friend WithEvents Label1 As Label
End Class
