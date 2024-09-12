<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalendarParticipants
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CloseBttn = New System.Windows.Forms.Button()
        Me.InsertBttn = New System.Windows.Forms.Button()
        Me.ConfirmBttn = New System.Windows.Forms.Button()
        Me.DeleteBttn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 9)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(262, 191)
        Me.DataGridView1.TabIndex = 3
        '
        'CloseBttn
        '
        Me.CloseBttn.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBttn.Location = New System.Drawing.Point(216, 307)
        Me.CloseBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.CloseBttn.Name = "CloseBttn"
        Me.CloseBttn.Size = New System.Drawing.Size(56, 19)
        Me.CloseBttn.TabIndex = 4
        Me.CloseBttn.Text = "Close"
        Me.CloseBttn.UseVisualStyleBackColor = True
        '
        'InsertBttn
        '
        Me.InsertBttn.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertBttn.Location = New System.Drawing.Point(74, 211)
        Me.InsertBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.InsertBttn.Name = "InsertBttn"
        Me.InsertBttn.Size = New System.Drawing.Size(56, 19)
        Me.InsertBttn.TabIndex = 5
        Me.InsertBttn.Text = "Insert"
        Me.InsertBttn.UseVisualStyleBackColor = True
        '
        'ConfirmBttn
        '
        Me.ConfirmBttn.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirmBttn.Location = New System.Drawing.Point(10, 308)
        Me.ConfirmBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.ConfirmBttn.Name = "ConfirmBttn"
        Me.ConfirmBttn.Size = New System.Drawing.Size(56, 19)
        Me.ConfirmBttn.TabIndex = 7
        Me.ConfirmBttn.Text = "Confirm"
        Me.ConfirmBttn.UseVisualStyleBackColor = True
        Me.ConfirmBttn.Visible = False
        '
        'DeleteBttn
        '
        Me.DeleteBttn.Font = New System.Drawing.Font("Poppins", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteBttn.Location = New System.Drawing.Point(152, 211)
        Me.DeleteBttn.Margin = New System.Windows.Forms.Padding(2)
        Me.DeleteBttn.Name = "DeleteBttn"
        Me.DeleteBttn.Size = New System.Drawing.Size(56, 19)
        Me.DeleteBttn.TabIndex = 8
        Me.DeleteBttn.Text = "Delete"
        Me.DeleteBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(2, 248)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "KK Verified:"
        Me.Label1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(71, 246)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(137, 21)
        Me.ComboBox1.TabIndex = 10
        Me.ComboBox1.Visible = False
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.FeedbackLbl.Location = New System.Drawing.Point(6, 269)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(262, 19)
        Me.FeedbackLbl.TabIndex = 11
        Me.FeedbackLbl.Text = "Label2"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'CalendarParticipants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(281, 336)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DeleteBttn)
        Me.Controls.Add(Me.ConfirmBttn)
        Me.Controls.Add(Me.InsertBttn)
        Me.Controls.Add(Me.CloseBttn)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CalendarParticipants"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CalendarParticipants"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CloseBttn As Button
    Friend WithEvents InsertBttn As Button
    Friend WithEvents ConfirmBttn As Button
    Friend WithEvents DeleteBttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
