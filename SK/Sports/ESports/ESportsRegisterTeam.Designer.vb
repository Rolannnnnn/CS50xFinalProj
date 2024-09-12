<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ESportsRegisterTeam
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RegisterBttn = New System.Windows.Forms.Button()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 132)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Register a Team"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(162, 197)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Team Name:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(280, 201)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(223, 20)
        Me.TextBox1.TabIndex = 2
        '
        'RegisterBttn
        '
        Me.RegisterBttn.Location = New System.Drawing.Point(341, 269)
        Me.RegisterBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.RegisterBttn.Name = "RegisterBttn"
        Me.RegisterBttn.Size = New System.Drawing.Size(67, 22)
        Me.RegisterBttn.TabIndex = 3
        Me.RegisterBttn.Text = "Register"
        Me.RegisterBttn.UseVisualStyleBackColor = True
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackLbl.Location = New System.Drawing.Point(153, 223)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(434, 19)
        Me.FeedbackLbl.TabIndex = 5
        Me.FeedbackLbl.Text = "Feedback"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'ESportsRegisterTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 585)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.RegisterBttn)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ESportsRegisterTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESportsRegisterTeam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents RegisterBttn As Button
    Friend WithEvents FeedbackLbl As Label
End Class
