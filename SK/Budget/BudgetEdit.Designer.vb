<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BudgetEdit
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
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.EventSubLbl = New System.Windows.Forms.Label()
        Me.DateSubLbl = New System.Windows.Forms.Label()
        Me.ItemSourceSubLbl = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TitleLbl = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.EventLbl = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ItemSourceTxtBox = New System.Windows.Forms.TextBox()
        Me.ItemSourceLbl = New System.Windows.Forms.Label()
        Me.AmountTxtBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.SuspendLayout()
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.OrangeRed
        Me.FeedbackLbl.Location = New System.Drawing.Point(36, 305)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(263, 23)
        Me.FeedbackLbl.TabIndex = 29
        Me.FeedbackLbl.Text = "Label3"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'EventSubLbl
        '
        Me.EventSubLbl.AutoSize = True
        Me.EventSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventSubLbl.ForeColor = System.Drawing.Color.White
        Me.EventSubLbl.Location = New System.Drawing.Point(100, 261)
        Me.EventSubLbl.Name = "EventSubLbl"
        Me.EventSubLbl.Size = New System.Drawing.Size(176, 13)
        Me.EventSubLbl.TabIndex = 28
        Me.EventSubLbl.Text = "Event Associated with the Purchase"
        '
        'DateSubLbl
        '
        Me.DateSubLbl.AutoSize = True
        Me.DateSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateSubLbl.ForeColor = System.Drawing.Color.White
        Me.DateSubLbl.Location = New System.Drawing.Point(100, 202)
        Me.DateSubLbl.Name = "DateSubLbl"
        Me.DateSubLbl.Size = New System.Drawing.Size(89, 13)
        Me.DateSubLbl.TabIndex = 27
        Me.DateSubLbl.Text = "Date of Purchase"
        '
        'ItemSourceSubLbl
        '
        Me.ItemSourceSubLbl.AutoSize = True
        Me.ItemSourceSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemSourceSubLbl.ForeColor = System.Drawing.Color.White
        Me.ItemSourceSubLbl.Location = New System.Drawing.Point(100, 146)
        Me.ItemSourceSubLbl.Name = "ItemSourceSubLbl"
        Me.ItemSourceSubLbl.Size = New System.Drawing.Size(132, 13)
        Me.ItemSourceSubLbl.TabIndex = 26
        Me.ItemSourceSubLbl.Text = "Item/Service that is bought"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(245, 331)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 331)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TitleLbl
        '
        Me.TitleLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLbl.ForeColor = System.Drawing.Color.Black
        Me.TitleLbl.Location = New System.Drawing.Point(20, 11)
        Me.TitleLbl.Name = "TitleLbl"
        Me.TitleLbl.Size = New System.Drawing.Size(309, 46)
        Me.TitleLbl.TabIndex = 23
        Me.TitleLbl.Text = "Edit Expense"
        Me.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(97, 231)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(193, 24)
        Me.ComboBox1.TabIndex = 22
        '
        'EventLbl
        '
        Me.EventLbl.AutoSize = True
        Me.EventLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventLbl.ForeColor = System.Drawing.Color.Black
        Me.EventLbl.Location = New System.Drawing.Point(24, 230)
        Me.EventLbl.Name = "EventLbl"
        Me.EventLbl.Size = New System.Drawing.Size(56, 20)
        Me.EventLbl.TabIndex = 21
        Me.EventLbl.Text = "Event:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(97, 175)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(193, 22)
        Me.DateTimePicker1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Date:"
        '
        'ItemSourceTxtBox
        '
        Me.ItemSourceTxtBox.Location = New System.Drawing.Point(97, 119)
        Me.ItemSourceTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ItemSourceTxtBox.Name = "ItemSourceTxtBox"
        Me.ItemSourceTxtBox.Size = New System.Drawing.Size(193, 22)
        Me.ItemSourceTxtBox.TabIndex = 18
        '
        'ItemSourceLbl
        '
        Me.ItemSourceLbl.AutoSize = True
        Me.ItemSourceLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemSourceLbl.ForeColor = System.Drawing.Color.Black
        Me.ItemSourceLbl.Location = New System.Drawing.Point(33, 118)
        Me.ItemSourceLbl.Name = "ItemSourceLbl"
        Me.ItemSourceLbl.Size = New System.Drawing.Size(46, 20)
        Me.ItemSourceLbl.TabIndex = 17
        Me.ItemSourceLbl.Text = "Item:"
        '
        'AmountTxtBox
        '
        Me.AmountTxtBox.Location = New System.Drawing.Point(97, 79)
        Me.AmountTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AmountTxtBox.Name = "AmountTxtBox"
        Me.AmountTxtBox.Size = New System.Drawing.Size(193, 22)
        Me.AmountTxtBox.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Amount:"
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'BudgetEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(333, 370)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.EventSubLbl)
        Me.Controls.Add(Me.DateSubLbl)
        Me.Controls.Add(Me.ItemSourceSubLbl)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TitleLbl)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.EventLbl)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ItemSourceTxtBox)
        Me.Controls.Add(Me.ItemSourceLbl)
        Me.Controls.Add(Me.AmountTxtBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "BudgetEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BudgetEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents EventSubLbl As Label
    Friend WithEvents DateSubLbl As Label
    Friend WithEvents ItemSourceSubLbl As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TitleLbl As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents EventLbl As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents ItemSourceTxtBox As TextBox
    Friend WithEvents ItemSourceLbl As Label
    Friend WithEvents AmountTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
