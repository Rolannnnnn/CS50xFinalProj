<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KKProfilingDelete
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Errorlbl = New System.Windows.Forms.Label()
        Me.DeleteBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.ConfirmBtn = New Guna.UI2.WinForms.Guna2Button()
        Me.NameCB = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(209, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name: "
        '
        'Errorlbl
        '
        Me.Errorlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Errorlbl.ForeColor = System.Drawing.Color.Red
        Me.Errorlbl.Location = New System.Drawing.Point(180, 316)
        Me.Errorlbl.Name = "Errorlbl"
        Me.Errorlbl.Size = New System.Drawing.Size(460, 17)
        Me.Errorlbl.TabIndex = 5
        Me.Errorlbl.Text = "Errorlbl"
        Me.Errorlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Errorlbl.Visible = False
        '
        'DeleteBtn
        '
        Me.DeleteBtn.BorderRadius = 20
        Me.DeleteBtn.CheckedState.Parent = Me.DeleteBtn
        Me.DeleteBtn.CustomImages.Parent = Me.DeleteBtn
        Me.DeleteBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteBtn.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteBtn.ForeColor = System.Drawing.Color.White
        Me.DeleteBtn.HoverState.FillColor = System.Drawing.Color.LightCoral
        Me.DeleteBtn.HoverState.Parent = Me.DeleteBtn
        Me.DeleteBtn.Location = New System.Drawing.Point(321, 257)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.ShadowDecoration.Parent = Me.DeleteBtn
        Me.DeleteBtn.Size = New System.Drawing.Size(180, 45)
        Me.DeleteBtn.TabIndex = 8
        Me.DeleteBtn.Text = "Delete"
        '
        'ConfirmBtn
        '
        Me.ConfirmBtn.BorderRadius = 20
        Me.ConfirmBtn.CheckedState.Parent = Me.ConfirmBtn
        Me.ConfirmBtn.CustomImages.Parent = Me.ConfirmBtn
        Me.ConfirmBtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBtn.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirmBtn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBtn.HoverState.FillColor = System.Drawing.Color.Lime
        Me.ConfirmBtn.HoverState.Parent = Me.ConfirmBtn
        Me.ConfirmBtn.Location = New System.Drawing.Point(321, 353)
        Me.ConfirmBtn.Name = "ConfirmBtn"
        Me.ConfirmBtn.ShadowDecoration.Parent = Me.ConfirmBtn
        Me.ConfirmBtn.Size = New System.Drawing.Size(180, 45)
        Me.ConfirmBtn.TabIndex = 9
        Me.ConfirmBtn.Text = "Confirm"
        Me.ConfirmBtn.Visible = False
        '
        'NameCB
        '
        Me.NameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NameCB.FormattingEnabled = True
        Me.NameCB.Location = New System.Drawing.Point(298, 199)
        Me.NameCB.Name = "NameCB"
        Me.NameCB.Size = New System.Drawing.Size(203, 21)
        Me.NameCB.TabIndex = 10
        '
        'KKProfilingDelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 616)
        Me.Controls.Add(Me.NameCB)
        Me.Controls.Add(Me.ConfirmBtn)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.Errorlbl)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "KKProfilingDelete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KKProfilingDelete"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Errorlbl As Label
    Friend WithEvents DeleteBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ConfirmBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents NameCB As ComboBox
End Class
