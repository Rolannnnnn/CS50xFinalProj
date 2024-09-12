<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ESportsEditPlayer
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EditBttn = New System.Windows.Forms.Button()
        Me.DeleteBttn = New System.Windows.Forms.Button()
        Me.ConfirmBttn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PositionCB = New System.Windows.Forms.ComboBox()
        Me.TeamNameCB = New System.Windows.Forms.ComboBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.TeamNamesCB = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(100, 118)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(572, 236)
        Me.DataGridView1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 87)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Player List"
        '
        'EditBttn
        '
        Me.EditBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.EditBttn.ForeColor = System.Drawing.Color.White
        Me.EditBttn.Location = New System.Drawing.Point(100, 368)
        Me.EditBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.EditBttn.Name = "EditBttn"
        Me.EditBttn.Size = New System.Drawing.Size(67, 36)
        Me.EditBttn.TabIndex = 5
        Me.EditBttn.Text = "Edit"
        Me.EditBttn.UseVisualStyleBackColor = False
        '
        'DeleteBttn
        '
        Me.DeleteBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteBttn.ForeColor = System.Drawing.Color.White
        Me.DeleteBttn.Location = New System.Drawing.Point(605, 368)
        Me.DeleteBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.DeleteBttn.Name = "DeleteBttn"
        Me.DeleteBttn.Size = New System.Drawing.Size(67, 36)
        Me.DeleteBttn.TabIndex = 6
        Me.DeleteBttn.Text = "Delete"
        Me.DeleteBttn.UseVisualStyleBackColor = False
        '
        'ConfirmBttn
        '
        Me.ConfirmBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBttn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBttn.Location = New System.Drawing.Point(605, 490)
        Me.ConfirmBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.ConfirmBttn.Name = "ConfirmBttn"
        Me.ConfirmBttn.Size = New System.Drawing.Size(67, 36)
        Me.ConfirmBttn.TabIndex = 7
        Me.ConfirmBttn.Text = "Confirm"
        Me.ConfirmBttn.UseVisualStyleBackColor = False
        Me.ConfirmBttn.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 372)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Player Name:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 403)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Position:"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(242, 433)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Team Name:"
        Me.Label4.Visible = False
        '
        'PositionCB
        '
        Me.PositionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionCB.FormattingEnabled = True
        Me.PositionCB.Items.AddRange(New Object() {"Roam", "Gold Lane", "Exp Lane", "Mid Lane", "Jungle"})
        Me.PositionCB.Location = New System.Drawing.Point(320, 401)
        Me.PositionCB.Margin = New System.Windows.Forms.Padding(2)
        Me.PositionCB.Name = "PositionCB"
        Me.PositionCB.Size = New System.Drawing.Size(183, 21)
        Me.PositionCB.TabIndex = 13
        Me.PositionCB.Visible = False
        '
        'TeamNameCB
        '
        Me.TeamNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamNameCB.FormattingEnabled = True
        Me.TeamNameCB.Location = New System.Drawing.Point(320, 431)
        Me.TeamNameCB.Margin = New System.Windows.Forms.Padding(2)
        Me.TeamNameCB.Name = "TeamNameCB"
        Me.TeamNameCB.Size = New System.Drawing.Size(183, 21)
        Me.TeamNameCB.TabIndex = 14
        Me.TeamNameCB.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(105, 456)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(567, 32)
        Me.FeedbackLbl.TabIndex = 15
        Me.FeedbackLbl.Text = "Click the Player to Edit or Delete"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TeamNamesCB
        '
        Me.TeamNamesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamNamesCB.FormattingEnabled = True
        Me.TeamNamesCB.Location = New System.Drawing.Point(320, 372)
        Me.TeamNamesCB.Name = "TeamNamesCB"
        Me.TeamNamesCB.Size = New System.Drawing.Size(183, 21)
        Me.TeamNamesCB.TabIndex = 16
        Me.TeamNamesCB.Visible = False
        '
        'ESportsEditPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 585)
        Me.Controls.Add(Me.TeamNamesCB)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.TeamNameCB)
        Me.Controls.Add(Me.PositionCB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ConfirmBttn)
        Me.Controls.Add(Me.DeleteBttn)
        Me.Controls.Add(Me.EditBttn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ESportsEditPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESportsEditPlayer"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents EditBttn As Button
    Friend WithEvents DeleteBttn As Button
    Friend WithEvents ConfirmBttn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PositionCB As ComboBox
    Friend WithEvents TeamNameCB As ComboBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents TeamNamesCB As ComboBox
End Class
