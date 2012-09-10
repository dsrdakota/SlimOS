<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SlimOS_Form
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
        Me.splitContent = New System.Windows.Forms.SplitContainer()
        Me.splitIcon = New System.Windows.Forms.SplitContainer()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.splitTitle = New System.Windows.Forms.SplitContainer()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMax = New System.Windows.Forms.Button()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.cxtMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaximizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.splitContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContent.Panel1.SuspendLayout()
        Me.splitContent.SuspendLayout()
        CType(Me.splitIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitIcon.Panel1.SuspendLayout()
        Me.splitIcon.Panel2.SuspendLayout()
        Me.splitIcon.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitTitle.Panel1.SuspendLayout()
        Me.splitTitle.Panel2.SuspendLayout()
        Me.splitTitle.SuspendLayout()
        Me.cxtMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContent
        '
        Me.splitContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContent.IsSplitterFixed = True
        Me.splitContent.Location = New System.Drawing.Point(0, 0)
        Me.splitContent.Name = "splitContent"
        Me.splitContent.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContent.Panel1
        '
        Me.splitContent.Panel1.Controls.Add(Me.splitIcon)
        Me.splitContent.Panel1.Tag = "The Titlebar."
        '
        'splitContent.Panel2
        '
        Me.splitContent.Panel2.Tag = "The main content panel where user-defined controls are added."
        Me.splitContent.Size = New System.Drawing.Size(457, 247)
        Me.splitContent.SplitterDistance = 26
        Me.splitContent.TabIndex = 0
        '
        'splitIcon
        '
        Me.splitIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitIcon.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitIcon.IsSplitterFixed = True
        Me.splitIcon.Location = New System.Drawing.Point(0, 0)
        Me.splitIcon.Name = "splitIcon"
        '
        'splitIcon.Panel1
        '
        Me.splitIcon.Panel1.Controls.Add(Me.picIcon)
        Me.splitIcon.Panel1.Tag = "This is where the Window's icon goes."
        '
        'splitIcon.Panel2
        '
        Me.splitIcon.Panel2.Controls.Add(Me.splitTitle)
        Me.splitIcon.Panel2.Tag = "Contains another split container for the Titlebar text and Titlebar buttons."
        Me.splitIcon.Size = New System.Drawing.Size(457, 26)
        Me.splitIcon.SplitterDistance = 36
        Me.splitIcon.TabIndex = 0
        '
        'picIcon
        '
        Me.picIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picIcon.Image = Global.libSlimOS.My.Resources.Resources.Application_Icon
        Me.picIcon.Location = New System.Drawing.Point(0, 0)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(34, 24)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'splitTitle
        '
        Me.splitTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitTitle.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitTitle.IsSplitterFixed = True
        Me.splitTitle.Location = New System.Drawing.Point(0, 0)
        Me.splitTitle.Name = "splitTitle"
        '
        'splitTitle.Panel1
        '
        Me.splitTitle.Panel1.Controls.Add(Me.lblTitle)
        Me.splitTitle.Panel1.Tag = "This is the window's title text."
        '
        'splitTitle.Panel2
        '
        Me.splitTitle.Panel2.Controls.Add(Me.btnClose)
        Me.splitTitle.Panel2.Controls.Add(Me.btnMax)
        Me.splitTitle.Panel2.Controls.Add(Me.btnMin)
        Me.splitTitle.Panel2.Tag = "This is the window's titlebar's buttons."
        Me.splitTitle.Size = New System.Drawing.Size(417, 26)
        Me.splitTitle.SplitterDistance = 317
        Me.splitTitle.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(315, 24)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "New Window"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(63, -1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(31, 25)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMax
        '
        Me.btnMax.Location = New System.Drawing.Point(31, -1)
        Me.btnMax.Name = "btnMax"
        Me.btnMax.Size = New System.Drawing.Size(31, 25)
        Me.btnMax.TabIndex = 1
        Me.btnMax.Text = "□"
        Me.btnMax.UseVisualStyleBackColor = True
        '
        'btnMin
        '
        Me.btnMin.Location = New System.Drawing.Point(0, -1)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(31, 25)
        Me.btnMin.TabIndex = 0
        Me.btnMin.Text = "-"
        Me.btnMin.UseVisualStyleBackColor = True
        '
        'cxtMenu
        '
        Me.cxtMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveToolStripMenuItem, Me.ToolStripMenuItem2, Me.RestoreToolStripMenuItem, Me.MinimizeToolStripMenuItem, Me.MaximizeToolStripMenuItem, Me.ToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.cxtMenu.Name = "cxtMenu"
        Me.cxtMenu.Size = New System.Drawing.Size(125, 126)
        '
        'MoveToolStripMenuItem
        '
        Me.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem"
        Me.MoveToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MoveToolStripMenuItem.Text = "M&ove"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(121, 6)
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Enabled = False
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.RestoreToolStripMenuItem.Text = "&Restore"
        '
        'MinimizeToolStripMenuItem
        '
        Me.MinimizeToolStripMenuItem.Enabled = False
        Me.MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem"
        Me.MinimizeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MinimizeToolStripMenuItem.Text = "M&inimize"
        '
        'MaximizeToolStripMenuItem
        '
        Me.MaximizeToolStripMenuItem.Enabled = False
        Me.MaximizeToolStripMenuItem.Name = "MaximizeToolStripMenuItem"
        Me.MaximizeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.MaximizeToolStripMenuItem.Text = "Ma&ximize"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'SlimOS_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.splitContent)
        Me.Name = "SlimOS_Form"
        Me.Size = New System.Drawing.Size(457, 247)
        Me.splitContent.Panel1.ResumeLayout(False)
        CType(Me.splitContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContent.ResumeLayout(False)
        Me.splitIcon.Panel1.ResumeLayout(False)
        Me.splitIcon.Panel2.ResumeLayout(False)
        CType(Me.splitIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitIcon.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitTitle.Panel1.ResumeLayout(False)
        Me.splitTitle.Panel2.ResumeLayout(False)
        CType(Me.splitTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitTitle.ResumeLayout(False)
        Me.cxtMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitContent As System.Windows.Forms.SplitContainer
    Friend WithEvents splitIcon As System.Windows.Forms.SplitContainer
    Friend WithEvents splitTitle As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMax As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents cxtMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaximizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
