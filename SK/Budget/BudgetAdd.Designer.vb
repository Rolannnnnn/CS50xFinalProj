<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BudgetAdd
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
        Me.AmountTxtBox = New System.Windows.Forms.TextBox()
        Me.ItemSourceLbl = New System.Windows.Forms.Label()
        Me.ItemSourceTxtBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.EventLbl = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TitleLbl = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ItemSourceSubLbl = New System.Windows.Forms.Label()
        Me.DateSubLbl = New System.Windows.Forms.Label()
        Me.EventSubLbl = New System.Windows.Forms.Label()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Amount:"
        '
        'AmountTxtBox
        '
        Me.AmountTxtBox.Location = New System.Drawing.Point(97, 84)
        Me.AmountTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AmountTxtBox.Name = "AmountTxtBox"
        Me.AmountTxtBox.Size = New System.Drawing.Size(193, 22)
        Me.AmountTxtBox.TabIndex = 1
        '
        'ItemSourceLbl
        '
        Me.ItemSourceLbl.AutoSize = True
        Me.ItemSourceLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemSourceLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ItemSourceLbl.Location = New System.Drawing.Point(45, 127)
        Me.ItemSourceLbl.Name = "ItemSourceLbl"
        Me.ItemSourceLbl.Size = New System.Drawing.Size(38, 17)
        Me.ItemSourceLbl.TabIndex = 2
        Me.ItemSourceLbl.Text = "Item:"
        '
        'ItemSourceTxtBox
        '
        Me.ItemSourceTxtBox.Location = New System.Drawing.Point(97, 124)
        Me.ItemSourceTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ItemSourceTxtBox.Name = "ItemSourceTxtBox"
        Me.ItemSourceTxtBox.Size = New System.Drawing.Size(193, 22)
        Me.ItemSourceTxtBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(44, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(97, 180)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(193, 22)
        Me.DateTimePicker1.TabIndex = 5
        '
        'EventLbl
        '
        Me.EventLbl.AutoSize = True
        Me.EventLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.EventLbl.Location = New System.Drawing.Point(39, 241)
        Me.EventLbl.Name = "EventLbl"
        Me.EventLbl.Size = New System.Drawing.Size(48, 17)
        Me.EventLbl.TabIndex = 6
        Me.EventLbl.Text = "Event:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(97, 238)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(193, 24)
        Me.ComboBox1.TabIndex = 7
        '
        'TitleLbl
        '
        Me.TitleLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TitleLbl.Location = New System.Drawing.Point(12, 21)
        Me.TitleLbl.Name = "TitleLbl"
        Me.TitleLbl.Size = New System.Drawing.Size(309, 46)
        Me.TitleLbl.TabIndex = 8
        Me.TitleLbl.Text = "Add Expense"
        Me.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 336)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(245, 336)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ItemSourceSubLbl
        '
        Me.ItemSourceSubLbl.AutoSize = True
        Me.ItemSourceSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemSourceSubLbl.ForeColor = System.Drawing.Color.White
        Me.ItemSourceSubLbl.Location = New System.Drawing.Point(100, 151)
        Me.ItemSourceSubLbl.Name = "ItemSourceSubLbl"
        Me.ItemSourceSubLbl.Size = New System.Drawing.Size(150, 15)
        Me.ItemSourceSubLbl.TabIndex = 11
        Me.ItemSourceSubLbl.Text = "Item/Service that is bought"
        '
        'DateSubLbl
        '
        Me.DateSubLbl.AutoSize = True
        Me.DateSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateSubLbl.ForeColor = System.Drawing.Color.White
        Me.DateSubLbl.Location = New System.Drawing.Point(132, 207)
        Me.DateSubLbl.Name = "DateSubLbl"
        Me.DateSubLbl.Size = New System.Drawing.Size(101, 15)
        Me.DateSubLbl.TabIndex = 12
        Me.DateSubLbl.Text = "Date of Purchase"
        '
        'EventSubLbl
        '
        Me.EventSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventSubLbl.ForeColor = System.Drawing.Color.White
        Me.EventSubLbl.Location = New System.Drawing.Point(91, 265)
        Me.EventSubLbl.Name = "EventSubLbl"
        Me.EventSubLbl.Size = New System.Drawing.Size(201, 48)
        Me.EventSubLbl.TabIndex = 13
        Me.EventSubLbl.Text = "Event Associated with the Purchase"
        Me.EventSubLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.OrangeRed
        Me.FeedbackLbl.Location = New System.Drawing.Point(40, 314)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(263, 23)
        Me.FeedbackLbl.TabIndex = 14
        Me.FeedbackLbl.Text = "Label3"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'BudgetAdd
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
        Me.Name = "BudgetAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BudgetAdd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents AmountTxtBox As TextBox
    Friend WithEvents ItemSourceLbl As Label
    Friend WithEvents ItemSourceTxtBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents EventLbl As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TitleLbl As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ItemSourceSubLbl As Label
    Friend WithEvents DateSubLbl As Label
    Friend WithEvents EventSubLbl As Label
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
