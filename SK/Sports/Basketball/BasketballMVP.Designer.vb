<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BasketballMVP
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
        Me.PointsLB = New System.Windows.Forms.ListBox()
        Me.AssistsLB = New System.Windows.Forms.ListBox()
        Me.ReboundLB = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PointsLB
        '
        Me.PointsLB.FormattingEnabled = True
        Me.PointsLB.Location = New System.Drawing.Point(34, 195)
        Me.PointsLB.Margin = New System.Windows.Forms.Padding(2)
        Me.PointsLB.Name = "PointsLB"
        Me.PointsLB.Size = New System.Drawing.Size(185, 264)
        Me.PointsLB.TabIndex = 0
        '
        'AssistsLB
        '
        Me.AssistsLB.FormattingEnabled = True
        Me.AssistsLB.Location = New System.Drawing.Point(245, 194)
        Me.AssistsLB.Margin = New System.Windows.Forms.Padding(2)
        Me.AssistsLB.Name = "AssistsLB"
        Me.AssistsLB.Size = New System.Drawing.Size(194, 264)
        Me.AssistsLB.TabIndex = 1
        '
        'ReboundLB
        '
        Me.ReboundLB.FormattingEnabled = True
        Me.ReboundLB.Location = New System.Drawing.Point(485, 194)
        Me.ReboundLB.Margin = New System.Windows.Forms.Padding(2)
        Me.ReboundLB.Name = "ReboundLB"
        Me.ReboundLB.Size = New System.Drawing.Size(194, 264)
        Me.ReboundLB.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 68)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Points per Game"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 113)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 68)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Assists per Game"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(479, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 68)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rebounds per Game"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BasketballMVP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(717, 571)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReboundLB)
        Me.Controls.Add(Me.AssistsLB)
        Me.Controls.Add(Me.PointsLB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BasketballMVP"
        Me.Text = "BasketballMVP"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PointsLB As ListBox
    Friend WithEvents AssistsLB As ListBox
    Friend WithEvents ReboundLB As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
