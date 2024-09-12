<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SecurityPrintDialog
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
        Me.CloseBttn = New System.Windows.Forms.Button()
        Me.PrintBttn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FromTxtBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToTxtBox = New System.Windows.Forms.TextBox()
        Me.FeedbackLbl = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseBttn
        '
        Me.CloseBttn.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBttn.Location = New System.Drawing.Point(295, 125)
        Me.CloseBttn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CloseBttn.Name = "CloseBttn"
        Me.CloseBttn.Size = New System.Drawing.Size(56, 28)
        Me.CloseBttn.TabIndex = 0
        Me.CloseBttn.Text = "Close"
        Me.CloseBttn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CloseBttn.UseVisualStyleBackColor = True
        '
        'PrintBttn
        '
        Me.PrintBttn.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBttn.Location = New System.Drawing.Point(9, 125)
        Me.PrintBttn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PrintBttn.Name = "PrintBttn"
        Me.PrintBttn.Size = New System.Drawing.Size(63, 28)
        Me.PrintBttn.TabIndex = 1
        Me.PrintBttn.Text = "Print"
        Me.PrintBttn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.PrintBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(38, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select the LogIDs to include in the PDF"
        '
        'FromTxtBox
        '
        Me.FromTxtBox.Location = New System.Drawing.Point(93, 63)
        Me.FromTxtBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.FromTxtBox.Name = "FromTxtBox"
        Me.FromTxtBox.Size = New System.Drawing.Size(65, 20)
        Me.FromTxtBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "—"
        '
        'ToTxtBox
        '
        Me.ToTxtBox.Location = New System.Drawing.Point(211, 63)
        Me.ToTxtBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToTxtBox.Name = "ToTxtBox"
        Me.ToTxtBox.Size = New System.Drawing.Size(65, 20)
        Me.ToTxtBox.TabIndex = 5
        '
        'FeedbackLbl
        '
        Me.FeedbackLbl.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FeedbackLbl.ForeColor = System.Drawing.Color.White
        Me.FeedbackLbl.Location = New System.Drawing.Point(16, 94)
        Me.FeedbackLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FeedbackLbl.Name = "FeedbackLbl"
        Me.FeedbackLbl.Size = New System.Drawing.Size(342, 19)
        Me.FeedbackLbl.TabIndex = 6
        Me.FeedbackLbl.Text = "Label3"
        Me.FeedbackLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FeedbackLbl.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 63)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(52, 35)
        Me.DataGridView1.TabIndex = 7
        Me.DataGridView1.Visible = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'SecurityPrintDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(364, 164)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.FeedbackLbl)
        Me.Controls.Add(Me.ToTxtBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromTxtBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PrintBttn)
        Me.Controls.Add(Me.CloseBttn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SecurityPrintDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SecurityPrintDialog"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseBttn As Button
    Friend WithEvents PrintBttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FromTxtBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToTxtBox As TextBox
    Friend WithEvents FeedbackLbl As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
