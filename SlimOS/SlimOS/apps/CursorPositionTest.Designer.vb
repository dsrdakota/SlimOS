<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CursorPositionTest
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
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblBtn = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX.Location = New System.Drawing.Point(15, 11)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(56, 37)
        Me.lblX.TabIndex = 0
        Me.lblX.Text = "X: "
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY.Location = New System.Drawing.Point(190, 11)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(57, 37)
        Me.lblY.TabIndex = 1
        Me.lblY.Text = "Y: "
        '
        'lblBtn
        '
        Me.lblBtn.AutoSize = True
        Me.lblBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtn.Location = New System.Drawing.Point(15, 88)
        Me.lblBtn.Name = "lblBtn"
        Me.lblBtn.Size = New System.Drawing.Size(383, 37)
        Me.lblBtn.TabIndex = 2
        Me.lblBtn.Text = "Key and/or Mouse button:"
        '
        'CursorPositionTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBtn)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Name = "CursorPositionTest"
        Me.Size = New System.Drawing.Size(626, 174)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblBtn As System.Windows.Forms.Label

End Class
