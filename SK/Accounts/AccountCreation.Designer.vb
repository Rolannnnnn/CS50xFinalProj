<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountCreation
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
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UsernameTB = New System.Windows.Forms.TextBox()
        Me.PasswordTB = New System.Windows.Forms.TextBox()
        Me.EmailTB = New System.Windows.Forms.TextBox()
        Me.OTPLbl = New System.Windows.Forms.Label()
        Me.OTPTB = New System.Windows.Forms.TextBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(357, 204)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 19)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(41, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(41, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(41, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Email:"
        '
        'UsernameTB
        '
        Me.UsernameTB.Location = New System.Drawing.Point(118, 37)
        Me.UsernameTB.Margin = New System.Windows.Forms.Padding(2)
        Me.UsernameTB.Name = "UsernameTB"
        Me.UsernameTB.Size = New System.Drawing.Size(235, 20)
        Me.UsernameTB.TabIndex = 4
        '
        'PasswordTB
        '
        Me.PasswordTB.Location = New System.Drawing.Point(118, 71)
        Me.PasswordTB.Margin = New System.Windows.Forms.Padding(2)
        Me.PasswordTB.Name = "PasswordTB"
        Me.PasswordTB.Size = New System.Drawing.Size(235, 20)
        Me.PasswordTB.TabIndex = 5
        '
        'EmailTB
        '
        Me.EmailTB.Location = New System.Drawing.Point(118, 110)
        Me.EmailTB.Margin = New System.Windows.Forms.Padding(2)
        Me.EmailTB.Name = "EmailTB"
        Me.EmailTB.Size = New System.Drawing.Size(235, 20)
        Me.EmailTB.TabIndex = 6
        '
        'OTPLbl
        '
        Me.OTPLbl.AutoSize = True
        Me.OTPLbl.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OTPLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.OTPLbl.Location = New System.Drawing.Point(124, 147)
        Me.OTPLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.OTPLbl.Name = "OTPLbl"
        Me.OTPLbl.Size = New System.Drawing.Size(35, 22)
        Me.OTPLbl.TabIndex = 7
        Me.OTPLbl.Text = "OTP:"
        Me.OTPLbl.Visible = False
        '
        'OTPTB
        '
        Me.OTPTB.Location = New System.Drawing.Point(163, 147)
        Me.OTPTB.Margin = New System.Windows.Forms.Padding(2)
        Me.OTPTB.Name = "OTPTB"
        Me.OTPTB.Size = New System.Drawing.Size(114, 20)
        Me.OTPTB.TabIndex = 8
        Me.OTPTB.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.LightCoral
        Me.FeedbackLbl.Location = New System.Drawing.Point(52, 176)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(320, 19)
        Me.FeedbackLbl.TabIndex = 9
        Me.FeedbackLbl.Text = "Label4"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(9, 204)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 19)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Confirm"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'AccountCreation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(422, 232)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.OTPTB)
        Me.Controls.Add(Me.OTPLbl)
        Me.Controls.Add(Me.EmailTB)
        Me.Controls.Add(Me.PasswordTB)
        Me.Controls.Add(Me.UsernameTB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "AccountCreation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AccountCreation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents UsernameTB As TextBox
    Friend WithEvents PasswordTB As TextBox
    Friend WithEvents EmailTB As TextBox
    Friend WithEvents OTPLbl As Label
    Friend WithEvents OTPTB As TextBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
