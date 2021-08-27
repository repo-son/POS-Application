<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeSecurity
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOldPassword = New MetroFramework.Controls.MetroTextBox()
        Me.txtNewPassword = New MetroFramework.Controls.MetroTextBox()
        Me.txtConfirmNewPassword = New MetroFramework.Controls.MetroTextBox()
        Me.btnClean = New MetroFramework.Controls.MetroButton()
        Me.btnChange = New MetroFramework.Controls.MetroButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 36)
        Me.Panel1.TabIndex = 3
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.FuturePOS.My.Resources.Resources.close_window_40px
        Me.Button4.Location = New System.Drawing.Point(508, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 36)
        Me.Button4.TabIndex = 1
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Change Credentials"
        '
        'txtOldPassword
        '
        '
        '
        '
        Me.txtOldPassword.CustomButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPassword.CustomButton.Image = Nothing
        Me.txtOldPassword.CustomButton.Location = New System.Drawing.Point(461, 2)
        Me.txtOldPassword.CustomButton.Name = ""
        Me.txtOldPassword.CustomButton.Size = New System.Drawing.Size(27, 27)
        Me.txtOldPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtOldPassword.CustomButton.TabIndex = 1
        Me.txtOldPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtOldPassword.CustomButton.UseSelectable = True
        Me.txtOldPassword.CustomButton.Visible = False
        Me.txtOldPassword.DisplayIcon = True
        Me.txtOldPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtOldPassword.Icon = Global.FuturePOS.My.Resources.Resources.password_20px22
        Me.txtOldPassword.Lines = New String(-1) {}
        Me.txtOldPassword.Location = New System.Drawing.Point(28, 65)
        Me.txtOldPassword.MaxLength = 32767
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtOldPassword.PromptText = "Old Password"
        Me.txtOldPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtOldPassword.SelectedText = ""
        Me.txtOldPassword.SelectionLength = 0
        Me.txtOldPassword.SelectionStart = 0
        Me.txtOldPassword.ShortcutsEnabled = True
        Me.txtOldPassword.ShowClearButton = True
        Me.txtOldPassword.Size = New System.Drawing.Size(491, 32)
        Me.txtOldPassword.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtOldPassword.TabIndex = 4
        Me.txtOldPassword.UseSelectable = True
        Me.txtOldPassword.UseStyleColors = True
        Me.txtOldPassword.UseSystemPasswordChar = True
        Me.txtOldPassword.WaterMark = "Old Password"
        Me.txtOldPassword.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtOldPassword.WaterMarkFont = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtNewPassword
        '
        '
        '
        '
        Me.txtNewPassword.CustomButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPassword.CustomButton.Image = Nothing
        Me.txtNewPassword.CustomButton.Location = New System.Drawing.Point(461, 2)
        Me.txtNewPassword.CustomButton.Name = ""
        Me.txtNewPassword.CustomButton.Size = New System.Drawing.Size(27, 27)
        Me.txtNewPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNewPassword.CustomButton.TabIndex = 1
        Me.txtNewPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtNewPassword.CustomButton.UseSelectable = True
        Me.txtNewPassword.CustomButton.Visible = False
        Me.txtNewPassword.DisplayIcon = True
        Me.txtNewPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtNewPassword.Icon = Global.FuturePOS.My.Resources.Resources.password_20px22
        Me.txtNewPassword.Lines = New String(-1) {}
        Me.txtNewPassword.Location = New System.Drawing.Point(28, 103)
        Me.txtNewPassword.MaxLength = 32767
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNewPassword.PromptText = "New Password"
        Me.txtNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtNewPassword.SelectedText = ""
        Me.txtNewPassword.SelectionLength = 0
        Me.txtNewPassword.SelectionStart = 0
        Me.txtNewPassword.ShortcutsEnabled = True
        Me.txtNewPassword.ShowClearButton = True
        Me.txtNewPassword.Size = New System.Drawing.Size(491, 32)
        Me.txtNewPassword.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtNewPassword.TabIndex = 5
        Me.txtNewPassword.UseSelectable = True
        Me.txtNewPassword.UseStyleColors = True
        Me.txtNewPassword.UseSystemPasswordChar = True
        Me.txtNewPassword.WaterMark = "New Password"
        Me.txtNewPassword.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtNewPassword.WaterMarkFont = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtConfirmNewPassword
        '
        '
        '
        '
        Me.txtConfirmNewPassword.CustomButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmNewPassword.CustomButton.Image = Nothing
        Me.txtConfirmNewPassword.CustomButton.Location = New System.Drawing.Point(461, 2)
        Me.txtConfirmNewPassword.CustomButton.Name = ""
        Me.txtConfirmNewPassword.CustomButton.Size = New System.Drawing.Size(27, 27)
        Me.txtConfirmNewPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConfirmNewPassword.CustomButton.TabIndex = 1
        Me.txtConfirmNewPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtConfirmNewPassword.CustomButton.UseSelectable = True
        Me.txtConfirmNewPassword.CustomButton.Visible = False
        Me.txtConfirmNewPassword.DisplayIcon = True
        Me.txtConfirmNewPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtConfirmNewPassword.Icon = Global.FuturePOS.My.Resources.Resources.password_20px22
        Me.txtConfirmNewPassword.Lines = New String(-1) {}
        Me.txtConfirmNewPassword.Location = New System.Drawing.Point(28, 141)
        Me.txtConfirmNewPassword.MaxLength = 32767
        Me.txtConfirmNewPassword.Name = "txtConfirmNewPassword"
        Me.txtConfirmNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirmNewPassword.PromptText = "Confirm New Password"
        Me.txtConfirmNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtConfirmNewPassword.SelectedText = ""
        Me.txtConfirmNewPassword.SelectionLength = 0
        Me.txtConfirmNewPassword.SelectionStart = 0
        Me.txtConfirmNewPassword.ShortcutsEnabled = True
        Me.txtConfirmNewPassword.ShowClearButton = True
        Me.txtConfirmNewPassword.Size = New System.Drawing.Size(491, 32)
        Me.txtConfirmNewPassword.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtConfirmNewPassword.TabIndex = 6
        Me.txtConfirmNewPassword.UseSelectable = True
        Me.txtConfirmNewPassword.UseStyleColors = True
        Me.txtConfirmNewPassword.UseSystemPasswordChar = True
        Me.txtConfirmNewPassword.WaterMark = "Confirm New Password"
        Me.txtConfirmNewPassword.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtConfirmNewPassword.WaterMarkFont = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnClean
        '
        Me.btnClean.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnClean.Location = New System.Drawing.Point(289, 179)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(112, 53)
        Me.btnClean.Style = MetroFramework.MetroColorStyle.Yellow
        Me.btnClean.TabIndex = 8
        Me.btnClean.Text = "Clean"
        Me.btnClean.Theme = MetroFramework.MetroThemeStyle.Light
        Me.btnClean.UseSelectable = True
        Me.btnClean.UseStyleColors = True
        '
        'btnChange
        '
        Me.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnChange.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.btnChange.Location = New System.Drawing.Point(407, 179)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(112, 53)
        Me.btnChange.Style = MetroFramework.MetroColorStyle.Yellow
        Me.btnChange.TabIndex = 7
        Me.btnChange.Text = "Reset"
        Me.btnChange.Theme = MetroFramework.MetroThemeStyle.Light
        Me.btnChange.UseSelectable = True
        Me.btnChange.UseStyleColors = True
        '
        'ChangeSecurity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(550, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClean)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.txtConfirmNewPassword)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ChangeSecurity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOldPassword As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtNewPassword As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtConfirmNewPassword As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnClean As MetroFramework.Controls.MetroButton
    Friend WithEvents btnChange As MetroFramework.Controls.MetroButton
End Class
