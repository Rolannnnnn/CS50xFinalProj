<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SportsMainForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.BackBttn = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2ControlBox2 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2DragControl2 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(238, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(284, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Sports Control Panel"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(186, 369)
        Me.Guna2Panel1.TabIndex = 6
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackgroundImage = Global.SK.My.Resources.Resources._428052465_122127556508113378_7796750536110785820_n_removebg_preview
        Me.Guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(14, 12)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.ShadowDecoration.Parent = Me.Guna2PictureBox1
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(154, 136)
        Me.Guna2PictureBox1.TabIndex = 13
        Me.Guna2PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BorderRadius = 20
        Me.Button2.CheckedState.Parent = Me.Button2
        Me.Button2.CustomImages.Parent = Me.Button2
        Me.Button2.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button2.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Button2.HoverState.ForeColor = System.Drawing.Color.Black
        Me.Button2.HoverState.Parent = Me.Button2
        Me.Button2.Image = Global.SK.My.Resources.Resources.icons8_volleyball_24
        Me.Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Button2.Location = New System.Drawing.Point(283, 179)
        Me.Button2.Name = "Button2"
        Me.Button2.ShadowDecoration.Parent = Me.Button2
        Me.Button2.Size = New System.Drawing.Size(207, 50)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Volleyball"
        '
        'Button3
        '
        Me.Button3.BorderRadius = 20
        Me.Button3.CheckedState.Parent = Me.Button3
        Me.Button3.CustomImages.Parent = Me.Button3
        Me.Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button3.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Button3.HoverState.ForeColor = System.Drawing.Color.Black
        Me.Button3.HoverState.Parent = Me.Button3
        Me.Button3.Image = Global.SK.My.Resources.Resources.icons8_controller_24
        Me.Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Button3.Location = New System.Drawing.Point(283, 245)
        Me.Button3.Name = "Button3"
        Me.Button3.ShadowDecoration.Parent = Me.Button3
        Me.Button3.Size = New System.Drawing.Size(207, 50)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Esports"
        '
        'Button1
        '
        Me.Button1.BorderRadius = 20
        Me.Button1.CheckedState.Parent = Me.Button1
        Me.Button1.CustomImages.Parent = Me.Button1
        Me.Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button1.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Button1.HoverState.ForeColor = System.Drawing.Color.Black
        Me.Button1.HoverState.Parent = Me.Button1
        Me.Button1.Image = Global.SK.My.Resources.Resources.icons8_basketball_24
        Me.Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Button1.Location = New System.Drawing.Point(283, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.ShadowDecoration.Parent = Me.Button1
        Me.Button1.Size = New System.Drawing.Size(207, 50)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Basketball"
        '
        'BackBttn
        '
        Me.BackBttn.BorderRadius = 10
        Me.BackBttn.CheckedState.Parent = Me.BackBttn
        Me.BackBttn.CustomImages.Parent = Me.BackBttn
        Me.BackBttn.FillColor = System.Drawing.Color.Black
        Me.BackBttn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BackBttn.ForeColor = System.Drawing.Color.White
        Me.BackBttn.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.BackBttn.HoverState.ForeColor = System.Drawing.Color.White
        Me.BackBttn.HoverState.Parent = Me.BackBttn
        Me.BackBttn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.BackBttn.Location = New System.Drawing.Point(513, 325)
        Me.BackBttn.Name = "BackBttn"
        Me.BackBttn.ShadowDecoration.Parent = Me.BackBttn
        Me.BackBttn.Size = New System.Drawing.Size(75, 29)
        Me.BackBttn.TabIndex = 12
        Me.BackBttn.Text = "Back"
        '
        'Guna2ControlBox2
        '
        Me.Guna2ControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox2.Animated = True
        Me.Guna2ControlBox2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot
        Me.Guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Guna2ControlBox2.FillColor = System.Drawing.Color.Black
        Me.Guna2ControlBox2.HoverState.Parent = Me.Guna2ControlBox2
        Me.Guna2ControlBox2.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox2.Location = New System.Drawing.Point(550, 3)
        Me.Guna2ControlBox2.Name = "Guna2ControlBox2"
        Me.Guna2ControlBox2.ShadowDecoration.Parent = Me.Guna2ControlBox2
        Me.Guna2ControlBox2.Size = New System.Drawing.Size(20, 21)
        Me.Guna2ControlBox2.TabIndex = 15
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.Animated = True
        Me.Guna2ControlBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.Black
        Me.Guna2ControlBox1.HoverState.Parent = Me.Guna2ControlBox1
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(574, 3)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.ShadowDecoration.Parent = Me.Guna2ControlBox1
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(21, 21)
        Me.Guna2ControlBox1.TabIndex = 14
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'Guna2DragControl2
        '
        Me.Guna2DragControl2.TargetControl = Nothing
        '
        'SportsMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.Guna2ControlBox2)
        Me.Controls.Add(Me.Guna2ControlBox1)
        Me.Controls.Add(Me.BackBttn)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SportsMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SportsMainForm"
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents BackBttn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Guna2ControlBox2 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2DragControl2 As Guna.UI2.WinForms.Guna2DragControl
End Class
