<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballEditStats
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Errorlbl = New System.Windows.Forms.Label()
        Me.PointsTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AssistsTB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ReboundsTB = New System.Windows.Forms.TextBox()
        Me.ConfirmBtn = New System.Windows.Forms.Button()
        Me.SelectBtn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(326, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Statistics"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(100, 98)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(541, 214)
        Me.DataGridView1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 416)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Points: "
        Me.Label3.Visible = False
        '
        'Errorlbl
        '
        Me.Errorlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Errorlbl.Location = New System.Drawing.Point(69, 315)
        Me.Errorlbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Errorlbl.Name = "Errorlbl"
        Me.Errorlbl.Size = New System.Drawing.Size(600, 19)
        Me.Errorlbl.TabIndex = 15
        Me.Errorlbl.Text = "Select the row to edit"
        Me.Errorlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PointsTB
        '
        Me.PointsTB.Location = New System.Drawing.Point(90, 413)
        Me.PointsTB.Name = "PointsTB"
        Me.PointsTB.Size = New System.Drawing.Size(119, 20)
        Me.PointsTB.TabIndex = 16
        Me.PointsTB.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(275, 419)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Assists:"
        Me.Label2.Visible = False
        '
        'AssistsTB
        '
        Me.AssistsTB.Location = New System.Drawing.Point(323, 416)
        Me.AssistsTB.Name = "AssistsTB"
        Me.AssistsTB.Size = New System.Drawing.Size(119, 20)
        Me.AssistsTB.TabIndex = 18
        Me.AssistsTB.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(485, 422)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Rebounds:"
        Me.Label4.Visible = False
        '
        'ReboundsTB
        '
        Me.ReboundsTB.Location = New System.Drawing.Point(550, 419)
        Me.ReboundsTB.Name = "ReboundsTB"
        Me.ReboundsTB.Size = New System.Drawing.Size(119, 20)
        Me.ReboundsTB.TabIndex = 20
        Me.ReboundsTB.Visible = False
        '
        'ConfirmBtn
        '
        Me.ConfirmBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBtn.FlatAppearance.BorderSize = 0
        Me.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConfirmBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirmBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.ConfirmBtn.Location = New System.Drawing.Point(423, 503)
        Me.ConfirmBtn.Name = "ConfirmBtn"
        Me.ConfirmBtn.Size = New System.Drawing.Size(75, 23)
        Me.ConfirmBtn.TabIndex = 22
        Me.ConfirmBtn.Text = "Confirm"
        Me.ConfirmBtn.UseVisualStyleBackColor = False
        Me.ConfirmBtn.Visible = False
        '
        'SelectBtn
        '
        Me.SelectBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.SelectBtn.FlatAppearance.BorderSize = 0
        Me.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectBtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.SelectBtn.Location = New System.Drawing.Point(198, 503)
        Me.SelectBtn.Name = "SelectBtn"
        Me.SelectBtn.Size = New System.Drawing.Size(75, 23)
        Me.SelectBtn.TabIndex = 23
        Me.SelectBtn.Text = "Select"
        Me.SelectBtn.UseVisualStyleBackColor = False
        '
        'BasketballEditStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(733, 610)
        Me.Controls.Add(Me.SelectBtn)
        Me.Controls.Add(Me.ConfirmBtn)
        Me.Controls.Add(Me.ReboundsTB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AssistsTB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PointsTB)
        Me.Controls.Add(Me.Errorlbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BasketballEditStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasketballEditStats"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Errorlbl As Label
    Friend WithEvents PointsTB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AssistsTB As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ReboundsTB As TextBox
    Friend WithEvents ConfirmBtn As Button
    Friend WithEvents SelectBtn As Button
End Class
