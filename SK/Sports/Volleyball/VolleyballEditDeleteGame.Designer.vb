<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballEditDeleteGame
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
        Me.Cnfrmbtn = New System.Windows.Forms.Button()
        Me.Idetbtn = New System.Windows.Forms.Button()
        Me.Statsbtn = New System.Windows.Forms.Button()
        Me.Dltbtn = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(122, 92)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(553, 225)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(342, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select row to Edit"
        '
        'Cnfrmbtn
        '
        Me.Cnfrmbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Cnfrmbtn.FlatAppearance.BorderSize = 0
        Me.Cnfrmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cnfrmbtn.ForeColor = System.Drawing.Color.White
        Me.Cnfrmbtn.Location = New System.Drawing.Point(122, 499)
        Me.Cnfrmbtn.Name = "Cnfrmbtn"
        Me.Cnfrmbtn.Size = New System.Drawing.Size(75, 23)
        Me.Cnfrmbtn.TabIndex = 2
        Me.Cnfrmbtn.Text = "Confirm"
        Me.Cnfrmbtn.UseVisualStyleBackColor = False
        Me.Cnfrmbtn.Visible = False
        '
        'Idetbtn
        '
        Me.Idetbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Idetbtn.FlatAppearance.BorderSize = 0
        Me.Idetbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Idetbtn.ForeColor = System.Drawing.Color.White
        Me.Idetbtn.Location = New System.Drawing.Point(122, 359)
        Me.Idetbtn.Name = "Idetbtn"
        Me.Idetbtn.Size = New System.Drawing.Size(75, 23)
        Me.Idetbtn.TabIndex = 3
        Me.Idetbtn.Text = "Edit Game"
        Me.Idetbtn.UseVisualStyleBackColor = False
        '
        'Statsbtn
        '
        Me.Statsbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Statsbtn.FlatAppearance.BorderSize = 0
        Me.Statsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Statsbtn.ForeColor = System.Drawing.Color.White
        Me.Statsbtn.Location = New System.Drawing.Point(334, 362)
        Me.Statsbtn.Name = "Statsbtn"
        Me.Statsbtn.Size = New System.Drawing.Size(127, 23)
        Me.Statsbtn.TabIndex = 4
        Me.Statsbtn.Text = "Edit Stats per player"
        Me.Statsbtn.UseVisualStyleBackColor = False
        '
        'Dltbtn
        '
        Me.Dltbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Dltbtn.FlatAppearance.BorderSize = 0
        Me.Dltbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Dltbtn.ForeColor = System.Drawing.Color.White
        Me.Dltbtn.Location = New System.Drawing.Point(617, 359)
        Me.Dltbtn.Name = "Dltbtn"
        Me.Dltbtn.Size = New System.Drawing.Size(58, 23)
        Me.Dltbtn.TabIndex = 5
        Me.Dltbtn.Text = "Delete"
        Me.Dltbtn.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(303, 465)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(199, 20)
        Me.DateTimePicker1.TabIndex = 7
        Me.DateTimePicker1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(544, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Select time and data to change"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(300, 505)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Won:"
        Me.Label3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(343, 505)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(148, 21)
        Me.ComboBox1.TabIndex = 10
        Me.ComboBox1.Visible = False
        '
        'VolleyballEditDeleteGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Dltbtn)
        Me.Controls.Add(Me.Statsbtn)
        Me.Controls.Add(Me.Idetbtn)
        Me.Controls.Add(Me.Cnfrmbtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballEditDeleteGame"
        Me.Text = "VolleyballEditDeleteGame"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Cnfrmbtn As Button
    Friend WithEvents Idetbtn As Button
    Friend WithEvents Statsbtn As Button
    Friend WithEvents Dltbtn As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
