﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VolleyballMVP
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReboundLB = New System.Windows.Forms.ListBox()
        Me.AssistsLB = New System.Windows.Forms.ListBox()
        Me.PointsLB = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(526, 127)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 68)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Digs per Game"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(287, 127)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 68)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Blocks per Game"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 127)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 68)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Points per Game"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ReboundLB
        '
        Me.ReboundLB.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReboundLB.FormattingEnabled = True
        Me.ReboundLB.ItemHeight = 19
        Me.ReboundLB.Location = New System.Drawing.Point(532, 208)
        Me.ReboundLB.Margin = New System.Windows.Forms.Padding(2)
        Me.ReboundLB.Name = "ReboundLB"
        Me.ReboundLB.Size = New System.Drawing.Size(194, 251)
        Me.ReboundLB.TabIndex = 8
        '
        'AssistsLB
        '
        Me.AssistsLB.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AssistsLB.FormattingEnabled = True
        Me.AssistsLB.ItemHeight = 19
        Me.AssistsLB.Location = New System.Drawing.Point(292, 208)
        Me.AssistsLB.Margin = New System.Windows.Forms.Padding(2)
        Me.AssistsLB.Name = "AssistsLB"
        Me.AssistsLB.Size = New System.Drawing.Size(194, 251)
        Me.AssistsLB.TabIndex = 7
        '
        'PointsLB
        '
        Me.PointsLB.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PointsLB.FormattingEnabled = True
        Me.PointsLB.ItemHeight = 19
        Me.PointsLB.Location = New System.Drawing.Point(81, 209)
        Me.PointsLB.Margin = New System.Windows.Forms.Padding(2)
        Me.PointsLB.Name = "PointsLB"
        Me.PointsLB.Size = New System.Drawing.Size(185, 251)
        Me.PointsLB.TabIndex = 6
        '
        'VolleyballMVP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(831, 604)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReboundLB)
        Me.Controls.Add(Me.AssistsLB)
        Me.Controls.Add(Me.PointsLB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VolleyballMVP"
        Me.Text = "VolleyballMVP"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ReboundLB As ListBox
    Friend WithEvents AssistsLB As ListBox
    Friend WithEvents PointsLB As ListBox
End Class
