<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BudgetUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.AmountLbl = New System.Windows.Forms.Label()
        Me.ItemSourceLbl = New System.Windows.Forms.Label()
        Me.DateLbl = New System.Windows.Forms.Label()
        Me.MoreLbl = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AmountLbl
        '
        Me.AmountLbl.AutoSize = True
        Me.AmountLbl.BackColor = System.Drawing.Color.Transparent
        Me.AmountLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmountLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AmountLbl.Location = New System.Drawing.Point(18, 11)
        Me.AmountLbl.Name = "AmountLbl"
        Me.AmountLbl.Size = New System.Drawing.Size(57, 18)
        Me.AmountLbl.TabIndex = 0
        Me.AmountLbl.Text = "Label1"
        '
        'ItemSourceLbl
        '
        Me.ItemSourceLbl.ForeColor = System.Drawing.Color.White
        Me.ItemSourceLbl.Location = New System.Drawing.Point(18, 39)
        Me.ItemSourceLbl.Name = "ItemSourceLbl"
        Me.ItemSourceLbl.Size = New System.Drawing.Size(202, 38)
        Me.ItemSourceLbl.TabIndex = 1
        Me.ItemSourceLbl.Text = "Label1"
        '
        'DateLbl
        '
        Me.DateLbl.AutoSize = True
        Me.DateLbl.ForeColor = System.Drawing.Color.White
        Me.DateLbl.Location = New System.Drawing.Point(18, 80)
        Me.DateLbl.Name = "DateLbl"
        Me.DateLbl.Size = New System.Drawing.Size(51, 18)
        Me.DateLbl.TabIndex = 2
        Me.DateLbl.Text = "Label1"
        '
        'MoreLbl
        '
        Me.MoreLbl.AutoSize = True
        Me.MoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoreLbl.ForeColor = System.Drawing.Color.White
        Me.MoreLbl.Location = New System.Drawing.Point(183, 13)
        Me.MoreLbl.Name = "MoreLbl"
        Me.MoreLbl.Size = New System.Drawing.Size(37, 16)
        Me.MoreLbl.TabIndex = 3
        Me.MoreLbl.Text = "● ● ●"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 52)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'BudgetUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.MoreLbl)
        Me.Controls.Add(Me.DateLbl)
        Me.Controls.Add(Me.ItemSourceLbl)
        Me.Controls.Add(Me.AmountLbl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "BudgetUserControl"
        Me.Size = New System.Drawing.Size(237, 121)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AmountLbl As Label
    Friend WithEvents ItemSourceLbl As Label
    Friend WithEvents DateLbl As Label
    Friend WithEvents MoreLbl As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
