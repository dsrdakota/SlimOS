<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateUserStructure
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNextFinish = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.mainPanel = New System.Windows.Forms.Panel()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbHandler = New System.Windows.Forms.ProgressBar()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrCreate = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btnNextFinish, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPrev, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(287, 277)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(223, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnNextFinish
        '
        Me.btnNextFinish.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNextFinish.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNextFinish.Location = New System.Drawing.Point(76, 3)
        Me.btnNextFinish.Name = "btnNextFinish"
        Me.btnNextFinish.Size = New System.Drawing.Size(67, 23)
        Me.btnNextFinish.TabIndex = 2
        Me.btnNextFinish.Text = "Ne&xt"
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnPrev.Enabled = False
        Me.btnPrev.Location = New System.Drawing.Point(3, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(67, 23)
        Me.btnPrev.TabIndex = 0
        Me.btnPrev.Text = "&Prev."
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(151, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Cancel"
        '
        'picIcon
        '
        Me.picIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.picIcon.BackgroundImage = Global.SlimOS.My.Resources.Resources.SlimOS
        Me.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picIcon.Location = New System.Drawing.Point(-1, 1)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(147, 76)
        Me.picIcon.TabIndex = 1
        Me.picIcon.TabStop = False
        '
        'mainPanel
        '
        Me.mainPanel.Controls.Add(Me.lblStatus)
        Me.mainPanel.Controls.Add(Me.lblS)
        Me.mainPanel.Controls.Add(Me.lblDescr)
        Me.mainPanel.Controls.Add(Me.lblTop)
        Me.mainPanel.Controls.Add(Me.lblTitle)
        Me.mainPanel.Controls.Add(Me.pbHandler)
        Me.mainPanel.Location = New System.Drawing.Point(152, 1)
        Me.mainPanel.Name = "mainPanel"
        Me.mainPanel.Size = New System.Drawing.Size(358, 270)
        Me.mainPanel.TabIndex = 2
        '
        'lblDescr
        '
        Me.lblDescr.AutoSize = True
        Me.lblDescr.Location = New System.Drawing.Point(14, 120)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(106, 13)
        Me.lblDescr.TabIndex = 3
        Me.lblDescr.Text = "Click next to begin ..."
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Location = New System.Drawing.Point(14, 51)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(103, 13)
        Me.lblTop.TabIndex = 2
        Me.lblTop.Text = "Currently installing ..."
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(3, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(354, 20)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Welcome to the First Time Logon Wizard"
        '
        'pbHandler
        '
        Me.pbHandler.Location = New System.Drawing.Point(3, 188)
        Me.pbHandler.Name = "pbHandler"
        Me.pbHandler.Size = New System.Drawing.Size(352, 23)
        Me.pbHandler.TabIndex = 0
        Me.pbHandler.Visible = False
        '
        'lblS
        '
        Me.lblS.AutoSize = True
        Me.lblS.Location = New System.Drawing.Point(14, 214)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(40, 13)
        Me.lblS.TabIndex = 4
        Me.lblS.Text = "&Status:"
        Me.lblS.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Location = New System.Drawing.Point(27, 242)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(328, 23)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Waiting ..."
        Me.lblStatus.Visible = False
        '
        'tmrCreate
        '
        Me.tmrCreate.Interval = 1100
        '
        'frmCreateUserStructure
        '
        Me.AcceptButton = Me.btnPrev
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(513, 315)
        Me.Controls.Add(Me.mainPanel)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateUserStructure"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SlimOS - First time logon Wizard"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainPanel.ResumeLayout(False)
        Me.mainPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnNextFinish As System.Windows.Forms.Button
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents mainPanel As System.Windows.Forms.Panel
    Friend WithEvents lblDescr As System.Windows.Forms.Label
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbHandler As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblS As System.Windows.Forms.Label
    Friend WithEvents tmrCreate As System.Windows.Forms.Timer

End Class
