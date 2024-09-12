<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BudgetMainForm
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
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.BudgetPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Button3 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2Button4 = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BudgetPanel
        '
        Me.BudgetPanel.AutoScroll = True
        Me.BudgetPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.BudgetPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.BudgetPanel.Location = New System.Drawing.Point(680, 12)
        Me.BudgetPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BudgetPanel.Name = "BudgetPanel"
        Me.BudgetPanel.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.BudgetPanel.Size = New System.Drawing.Size(349, 426)
        Me.BudgetPanel.TabIndex = 0
        Me.BudgetPanel.WrapContents = False
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(12, 12)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Me.Chart1.Size = New System.Drawing.Size(644, 348)
        Me.Chart1.TabIndex = 12
        Me.Chart1.Text = "Chart1"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.LightGray
        Me.Guna2Button1.BorderColor = System.Drawing.Color.DimGray
        Me.Guna2Button1.CheckedState.Parent = Me.Guna2Button1
        Me.Guna2Button1.CustomImages.Parent = Me.Guna2Button1
        Me.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button1.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button1.HoverState.Parent = Me.Guna2Button1
        Me.Guna2Button1.Location = New System.Drawing.Point(157, 373)
        Me.Guna2Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.ShadowDecoration.Parent = Me.Guna2Button1
        Me.Guna2Button1.Size = New System.Drawing.Size(159, 48)
        Me.Guna2Button1.TabIndex = 13
        Me.Guna2Button1.Text = "Add Inflow"
        '
        'Guna2Button2
        '
        Me.Guna2Button2.BackColor = System.Drawing.Color.LightGray
        Me.Guna2Button2.BorderColor = System.Drawing.Color.DimGray
        Me.Guna2Button2.CheckedState.Parent = Me.Guna2Button2
        Me.Guna2Button2.CustomImages.Parent = Me.Guna2Button2
        Me.Guna2Button2.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Guna2Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button2.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Guna2Button2.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button2.HoverState.Parent = Me.Guna2Button2
        Me.Guna2Button2.Location = New System.Drawing.Point(157, 428)
        Me.Guna2Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2Button2.Name = "Guna2Button2"
        Me.Guna2Button2.ShadowDecoration.Parent = Me.Guna2Button2
        Me.Guna2Button2.Size = New System.Drawing.Size(159, 48)
        Me.Guna2Button2.TabIndex = 14
        Me.Guna2Button2.Text = "Add Expense"
        '
        'Guna2Button3
        '
        Me.Guna2Button3.BackColor = System.Drawing.Color.LightGray
        Me.Guna2Button3.BorderColor = System.Drawing.Color.DimGray
        Me.Guna2Button3.CheckedState.Parent = Me.Guna2Button3
        Me.Guna2Button3.CustomImages.Parent = Me.Guna2Button3
        Me.Guna2Button3.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Guna2Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button3.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Guna2Button3.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button3.HoverState.Parent = Me.Guna2Button3
        Me.Guna2Button3.Location = New System.Drawing.Point(325, 428)
        Me.Guna2Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2Button3.Name = "Guna2Button3"
        Me.Guna2Button3.ShadowDecoration.Parent = Me.Guna2Button3
        Me.Guna2Button3.Size = New System.Drawing.Size(159, 48)
        Me.Guna2Button3.TabIndex = 15
        Me.Guna2Button3.Text = "Back"
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.TargetControl = Me
        '
        'Guna2Button4
        '
        Me.Guna2Button4.BackColor = System.Drawing.Color.LightGray
        Me.Guna2Button4.BorderColor = System.Drawing.Color.DimGray
        Me.Guna2Button4.CheckedState.Parent = Me.Guna2Button4
        Me.Guna2Button4.CustomImages.Parent = Me.Guna2Button4
        Me.Guna2Button4.FillColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Guna2Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button4.HoverState.FillColor = System.Drawing.Color.Maroon
        Me.Guna2Button4.HoverState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Guna2Button4.HoverState.Parent = Me.Guna2Button4
        Me.Guna2Button4.Location = New System.Drawing.Point(325, 372)
        Me.Guna2Button4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Guna2Button4.Name = "Guna2Button4"
        Me.Guna2Button4.ShadowDecoration.Parent = Me.Guna2Button4
        Me.Guna2Button4.Size = New System.Drawing.Size(159, 48)
        Me.Guna2Button4.TabIndex = 16
        Me.Guna2Button4.Text = "Print"
        '
        'BudgetMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1051, 490)
        Me.Controls.Add(Me.Guna2Button4)
        Me.Controls.Add(Me.Guna2Button3)
        Me.Controls.Add(Me.Guna2Button2)
        Me.Controls.Add(Me.Guna2Button1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.BudgetPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "BudgetMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BudgetMainForm"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BudgetPanel As FlowLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Button3 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2Button4 As Guna.UI2.WinForms.Guna2Button
End Class
