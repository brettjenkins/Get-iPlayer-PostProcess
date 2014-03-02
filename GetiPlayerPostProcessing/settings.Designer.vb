<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.txtWatched = New System.Windows.Forms.TextBox()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtPlex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFFMpeg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBoxReplaceToTemplate = New System.Windows.Forms.TextBox()
        Me.LabelReplaceTemplate = New System.Windows.Forms.Label()
        Me.TextBoxReplaceFromTemplate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWatched
        '
        Me.txtWatched.Location = New System.Drawing.Point(104, 6)
        Me.txtWatched.Name = "txtWatched"
        Me.txtWatched.Size = New System.Drawing.Size(214, 20)
        Me.txtWatched.TabIndex = 0
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(104, 35)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(214, 20)
        Me.txtOutput.TabIndex = 1
        '
        'txtPlex
        '
        Me.txtPlex.Location = New System.Drawing.Point(104, 62)
        Me.txtPlex.Name = "txtPlex"
        Me.txtPlex.Size = New System.Drawing.Size(214, 20)
        Me.txtPlex.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Watched Folder:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Output Folder:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Plex URL:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Leave blank to disable"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(233, 314)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(94, 314)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(115, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Discard Changes"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ffmpeg Location:"
        '
        'txtFFMpeg
        '
        Me.txtFFMpeg.Location = New System.Drawing.Point(104, 90)
        Me.txtFFMpeg.Name = "txtFFMpeg"
        Me.txtFFMpeg.Size = New System.Drawing.Size(214, 20)
        Me.txtFFMpeg.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(111, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "All paths must have no trailing slashes"
        '
        'btnAddRow
        '
        Me.btnAddRow.Location = New System.Drawing.Point(94, 285)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(214, 23)
        Me.btnAddRow.TabIndex = 13
        Me.btnAddRow.Text = "Add Row"
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.TextBoxReplaceToTemplate)
        Me.Panel1.Controls.Add(Me.LabelReplaceTemplate)
        Me.Panel1.Controls.Add(Me.TextBoxReplaceFromTemplate)
        Me.Panel1.Location = New System.Drawing.Point(12, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 135)
        Me.Panel1.TabIndex = 14
        '
        'TextBoxReplaceToTemplate
        '
        Me.TextBoxReplaceToTemplate.Location = New System.Drawing.Point(205, 13)
        Me.TextBoxReplaceToTemplate.Name = "TextBoxReplaceToTemplate"
        Me.TextBoxReplaceToTemplate.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxReplaceToTemplate.TabIndex = 2
        '
        'LabelReplaceTemplate
        '
        Me.LabelReplaceTemplate.AutoSize = True
        Me.LabelReplaceTemplate.Location = New System.Drawing.Point(3, 16)
        Me.LabelReplaceTemplate.Name = "LabelReplaceTemplate"
        Me.LabelReplaceTemplate.Size = New System.Drawing.Size(59, 13)
        Me.LabelReplaceTemplate.TabIndex = 1
        Me.LabelReplaceTemplate.Text = "Replace 1:"
        '
        'TextBoxReplaceFromTemplate
        '
        Me.TextBoxReplaceFromTemplate.Location = New System.Drawing.Point(91, 13)
        Me.TextBoxReplaceFromTemplate.Name = "TextBoxReplaceFromTemplate"
        Me.TextBoxReplaceFromTemplate.Size = New System.Drawing.Size(105, 20)
        Me.TextBoxReplaceFromTemplate.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(426, 28)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Sometimes you'll need to rename files to allow Plex to match up with it's databas" & _
            "es. For example Click needs to change to Click (2000) to match."
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 366)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFFMpeg)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlex)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.txtWatched)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Settings"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtWatched As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents txtPlex As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFFMpeg As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxReplaceToTemplate As System.Windows.Forms.TextBox
    Friend WithEvents LabelReplaceTemplate As System.Windows.Forms.Label
    Friend WithEvents TextBoxReplaceFromTemplate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
