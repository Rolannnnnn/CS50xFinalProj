<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ESportsEditGame
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SportsBasketballDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SportsESportsDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EditGBttn = New System.Windows.Forms.Button()
        Me.DeleteBttn = New System.Windows.Forms.Button()
        Me.EditPBttn = New System.Windows.Forms.Button()
        Me.ConfirmBttn = New System.Windows.Forms.Button()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SportsBasketballDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SportsESportsDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(113, 112)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(553, 236)
        Me.DataGridView1.TabIndex = 0
        '
        'EditGBttn
        '
        Me.EditGBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.EditGBttn.ForeColor = System.Drawing.Color.White
        Me.EditGBttn.Location = New System.Drawing.Point(113, 383)
        Me.EditGBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.EditGBttn.Name = "EditGBttn"
        Me.EditGBttn.Size = New System.Drawing.Size(92, 28)
        Me.EditGBttn.TabIndex = 2
        Me.EditGBttn.Text = "Edit Game"
        Me.EditGBttn.UseVisualStyleBackColor = False
        '
        'DeleteBttn
        '
        Me.DeleteBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.DeleteBttn.ForeColor = System.Drawing.Color.White
        Me.DeleteBttn.Location = New System.Drawing.Point(545, 383)
        Me.DeleteBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.DeleteBttn.Name = "DeleteBttn"
        Me.DeleteBttn.Size = New System.Drawing.Size(97, 28)
        Me.DeleteBttn.TabIndex = 4
        Me.DeleteBttn.Text = "Delete Game"
        Me.DeleteBttn.UseVisualStyleBackColor = False
        '
        'EditPBttn
        '
        Me.EditPBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.EditPBttn.ForeColor = System.Drawing.Color.White
        Me.EditPBttn.Location = New System.Drawing.Point(319, 383)
        Me.EditPBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.EditPBttn.Name = "EditPBttn"
        Me.EditPBttn.Size = New System.Drawing.Size(131, 28)
        Me.EditPBttn.TabIndex = 3
        Me.EditPBttn.Text = "Edit Individual Players"
        Me.EditPBttn.UseVisualStyleBackColor = False
        '
        'ConfirmBttn
        '
        Me.ConfirmBttn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ConfirmBttn.ForeColor = System.Drawing.Color.White
        Me.ConfirmBttn.Location = New System.Drawing.Point(575, 466)
        Me.ConfirmBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.ConfirmBttn.Name = "ConfirmBttn"
        Me.ConfirmBttn.Size = New System.Drawing.Size(67, 28)
        Me.ConfirmBttn.TabIndex = 5
        Me.ConfirmBttn.Text = "Confirm"
        Me.ConfirmBttn.UseVisualStyleBackColor = False
        Me.ConfirmBttn.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Location = New System.Drawing.Point(106, 405)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(524, 43)
        Me.FeedbackLbl.TabIndex = 6
        Me.FeedbackLbl.Text = "Select the Game you want to Edit or Delete"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 448)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date:"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 469)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Team Won:"
        Me.Label2.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(301, 461)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(174, 21)
        Me.ComboBox1.TabIndex = 9
        Me.ComboBox1.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(301, 439)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(174, 20)
        Me.DateTimePicker1.TabIndex = 10
        Me.DateTimePicker1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(122, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 24)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Games List"
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'ESportsEditGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 585)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.ConfirmBttn)
        Me.Controls.Add(Me.DeleteBttn)
        Me.Controls.Add(Me.EditPBttn)
        Me.Controls.Add(Me.EditGBttn)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ESportsEditGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESportsEditRecord"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SportsBasketballDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SportsESportsDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SportsESportsDataSetBindingSource As BindingSource
    Friend WithEvents SportsBasketballDataSetBindingSource As BindingSource
    Friend WithEvents EditGBttn As Button
    Friend WithEvents DeleteBttn As Button
    Friend WithEvents EditPBttn As Button
    Friend WithEvents ConfirmBttn As Button
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
