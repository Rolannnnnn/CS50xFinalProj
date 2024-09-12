<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalendarEventMain
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
        Me.CloseBttn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EventNoLbl = New System.Windows.Forms.Label()
        Me.EventProgressLbl = New System.Windows.Forms.Label()
        Me.EventNameLbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DescriptionLbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ParticipantLbl = New System.Windows.Forms.Label()
        Me.PreviousBttn = New System.Windows.Forms.Button()
        Me.NextBttn = New System.Windows.Forms.Button()
        Me.AddEventBttn = New System.Windows.Forms.Button()
        Me.EditEventBttn = New System.Windows.Forms.Button()
        Me.DeleteEventBttn = New System.Windows.Forms.Button()
        Me.ViewParticipantBttn = New System.Windows.Forms.Button()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.VenueLbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TimeLbl = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CloseBttn
        '
        Me.CloseBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBttn.Location = New System.Drawing.Point(235, 574)
        Me.CloseBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CloseBttn.Name = "CloseBttn"
        Me.CloseBttn.Size = New System.Drawing.Size(75, 23)
        Me.CloseBttn.TabIndex = 0
        Me.CloseBttn.Text = "Close"
        Me.CloseBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Event Name:"
        '
        'EventNoLbl
        '
        Me.EventNoLbl.AutoSize = True
        Me.EventNoLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventNoLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.EventNoLbl.Location = New System.Drawing.Point(13, 28)
        Me.EventNoLbl.Name = "EventNoLbl"
        Me.EventNoLbl.Size = New System.Drawing.Size(51, 17)
        Me.EventNoLbl.TabIndex = 2
        Me.EventNoLbl.Text = "Label2"
        '
        'EventProgressLbl
        '
        Me.EventProgressLbl.AutoSize = True
        Me.EventProgressLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventProgressLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.EventProgressLbl.Location = New System.Drawing.Point(13, 81)
        Me.EventProgressLbl.Name = "EventProgressLbl"
        Me.EventProgressLbl.Size = New System.Drawing.Size(84, 17)
        Me.EventProgressLbl.TabIndex = 3
        Me.EventProgressLbl.Text = "Event 0 of 0"
        '
        'EventNameLbl
        '
        Me.EventNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventNameLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.EventNameLbl.Location = New System.Drawing.Point(117, 105)
        Me.EventNameLbl.Name = "EventNameLbl"
        Me.EventNameLbl.Size = New System.Drawing.Size(175, 41)
        Me.EventNameLbl.TabIndex = 4
        Me.EventNameLbl.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Description:"
        '
        'DescriptionLbl
        '
        Me.DescriptionLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.DescriptionLbl.Location = New System.Drawing.Point(117, 146)
        Me.DescriptionLbl.Name = "DescriptionLbl"
        Me.DescriptionLbl.Size = New System.Drawing.Size(175, 62)
        Me.DescriptionLbl.TabIndex = 6
        Me.DescriptionLbl.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 293)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Participant Count:"
        '
        'ParticipantLbl
        '
        Me.ParticipantLbl.AutoSize = True
        Me.ParticipantLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParticipantLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ParticipantLbl.Location = New System.Drawing.Point(159, 293)
        Me.ParticipantLbl.Name = "ParticipantLbl"
        Me.ParticipantLbl.Size = New System.Drawing.Size(51, 17)
        Me.ParticipantLbl.TabIndex = 8
        Me.ParticipantLbl.Text = "Label2"
        '
        'PreviousBttn
        '
        Me.PreviousBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviousBttn.Location = New System.Drawing.Point(29, 389)
        Me.PreviousBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PreviousBttn.Name = "PreviousBttn"
        Me.PreviousBttn.Size = New System.Drawing.Size(81, 23)
        Me.PreviousBttn.TabIndex = 9
        Me.PreviousBttn.Text = "Previous"
        Me.PreviousBttn.UseVisualStyleBackColor = True
        '
        'NextBttn
        '
        Me.NextBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextBttn.Location = New System.Drawing.Point(235, 389)
        Me.NextBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NextBttn.Name = "NextBttn"
        Me.NextBttn.Size = New System.Drawing.Size(75, 23)
        Me.NextBttn.TabIndex = 10
        Me.NextBttn.Text = "Next"
        Me.NextBttn.UseVisualStyleBackColor = True
        '
        'AddEventBttn
        '
        Me.AddEventBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddEventBttn.Location = New System.Drawing.Point(57, 434)
        Me.AddEventBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AddEventBttn.Name = "AddEventBttn"
        Me.AddEventBttn.Size = New System.Drawing.Size(204, 23)
        Me.AddEventBttn.TabIndex = 11
        Me.AddEventBttn.Text = "Add Event for this Day"
        Me.AddEventBttn.UseVisualStyleBackColor = True
        '
        'EditEventBttn
        '
        Me.EditEventBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditEventBttn.Location = New System.Drawing.Point(12, 494)
        Me.EditEventBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EditEventBttn.Name = "EditEventBttn"
        Me.EditEventBttn.Size = New System.Drawing.Size(147, 23)
        Me.EditEventBttn.TabIndex = 12
        Me.EditEventBttn.Text = "Edit this Event"
        Me.EditEventBttn.UseVisualStyleBackColor = True
        '
        'DeleteEventBttn
        '
        Me.DeleteEventBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteEventBttn.Location = New System.Drawing.Point(165, 494)
        Me.DeleteEventBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DeleteEventBttn.Name = "DeleteEventBttn"
        Me.DeleteEventBttn.Size = New System.Drawing.Size(145, 23)
        Me.DeleteEventBttn.TabIndex = 13
        Me.DeleteEventBttn.Text = "Delete this Event"
        Me.DeleteEventBttn.UseVisualStyleBackColor = True
        '
        'ViewParticipantBttn
        '
        Me.ViewParticipantBttn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewParticipantBttn.Location = New System.Drawing.Point(93, 522)
        Me.ViewParticipantBttn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ViewParticipantBttn.Name = "ViewParticipantBttn"
        Me.ViewParticipantBttn.Size = New System.Drawing.Size(131, 23)
        Me.ViewParticipantBttn.TabIndex = 14
        Me.ViewParticipantBttn.Text = "View Participants"
        Me.ViewParticipantBttn.UseVisualStyleBackColor = True
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'VenueLbl
        '
        Me.VenueLbl.AutoSize = True
        Me.VenueLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VenueLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.VenueLbl.Location = New System.Drawing.Point(159, 233)
        Me.VenueLbl.Name = "VenueLbl"
        Me.VenueLbl.Size = New System.Drawing.Size(51, 17)
        Me.VenueLbl.TabIndex = 16
        Me.VenueLbl.Text = "Label2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Venue:"
        '
        'TimeLbl
        '
        Me.TimeLbl.AutoSize = True
        Me.TimeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TimeLbl.Location = New System.Drawing.Point(159, 262)
        Me.TimeLbl.Name = "TimeLbl"
        Me.TimeLbl.Size = New System.Drawing.Size(51, 17)
        Me.TimeLbl.TabIndex = 18
        Me.TimeLbl.Text = "Label2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Time:"
        '
        'CalendarEventMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(323, 609)
        Me.Controls.Add(Me.TimeLbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.VenueLbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ViewParticipantBttn)
        Me.Controls.Add(Me.DeleteEventBttn)
        Me.Controls.Add(Me.EditEventBttn)
        Me.Controls.Add(Me.AddEventBttn)
        Me.Controls.Add(Me.NextBttn)
        Me.Controls.Add(Me.PreviousBttn)
        Me.Controls.Add(Me.ParticipantLbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DescriptionLbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EventNameLbl)
        Me.Controls.Add(Me.EventProgressLbl)
        Me.Controls.Add(Me.EventNoLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CloseBttn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CalendarEventMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CalendarEventMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseBttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents EventNoLbl As Label
    Friend WithEvents EventProgressLbl As Label
    Friend WithEvents EventNameLbl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DescriptionLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ParticipantLbl As Label
    Friend WithEvents PreviousBttn As Button
    Friend WithEvents NextBttn As Button
    Friend WithEvents AddEventBttn As Button
    Friend WithEvents EditEventBttn As Button
    Friend WithEvents DeleteEventBttn As Button
    Friend WithEvents ViewParticipantBttn As Button
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents TimeLbl As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents VenueLbl As Label
    Friend WithEvents Label5 As Label
End Class
