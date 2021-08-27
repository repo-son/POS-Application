<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product
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
        Me.txtProductCode = New MetroFramework.Controls.MetroTextBox()
        Me.txtItemName = New MetroFramework.Controls.MetroTextBox()
        Me.txtIngredientName = New MetroFramework.Controls.MetroTextBox()
        Me.txtSpecification = New MetroFramework.Controls.MetroTextBox()
        Me.txtCategory = New MetroFramework.Controls.MetroTextBox()
        Me.txtItemType = New MetroFramework.Controls.MetroTextBox()
        Me.txtBaselineQty = New MetroFramework.Controls.MetroTextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblIngredientName = New System.Windows.Forms.Label()
        Me.lblSpecification = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.txtPrice = New MetroFramework.Controls.MetroTextBox()
        Me.txtQty = New MetroFramework.Controls.MetroTextBox()
        Me.lblID = New System.Windows.Forms.Label()
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
        Me.Panel1.Size = New System.Drawing.Size(496, 36)
        Me.Panel1.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.FuturePOS.My.Resources.Resources.close_window_40px1
        Me.Button4.Location = New System.Drawing.Point(454, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 36)
        Me.Button4.TabIndex = 14
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add New Product"
        '
        'txtProductCode
        '
        '
        '
        '
        Me.txtProductCode.CustomButton.Image = Nothing
        Me.txtProductCode.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtProductCode.CustomButton.Name = ""
        Me.txtProductCode.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtProductCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtProductCode.CustomButton.TabIndex = 1
        Me.txtProductCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtProductCode.CustomButton.UseSelectable = True
        Me.txtProductCode.CustomButton.Visible = False
        Me.txtProductCode.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtProductCode.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtProductCode.Lines = New String(-1) {}
        Me.txtProductCode.Location = New System.Drawing.Point(38, 69)
        Me.txtProductCode.MaxLength = 32767
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtProductCode.PromptText = "Product Code"
        Me.txtProductCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtProductCode.SelectedText = ""
        Me.txtProductCode.SelectionLength = 0
        Me.txtProductCode.SelectionStart = 0
        Me.txtProductCode.ShortcutsEnabled = True
        Me.txtProductCode.Size = New System.Drawing.Size(418, 30)
        Me.txtProductCode.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtProductCode.TabIndex = 1
        Me.txtProductCode.UseSelectable = True
        Me.txtProductCode.UseStyleColors = True
        Me.txtProductCode.WaterMark = "Product Code"
        Me.txtProductCode.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtProductCode.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtItemName
        '
        '
        '
        '
        Me.txtItemName.CustomButton.Image = Nothing
        Me.txtItemName.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtItemName.CustomButton.Name = ""
        Me.txtItemName.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtItemName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtItemName.CustomButton.TabIndex = 1
        Me.txtItemName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtItemName.CustomButton.UseSelectable = True
        Me.txtItemName.CustomButton.Visible = False
        Me.txtItemName.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtItemName.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtItemName.Lines = New String(-1) {}
        Me.txtItemName.Location = New System.Drawing.Point(38, 115)
        Me.txtItemName.MaxLength = 32767
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemName.PromptText = "Item Name"
        Me.txtItemName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtItemName.SelectedText = ""
        Me.txtItemName.SelectionLength = 0
        Me.txtItemName.SelectionStart = 0
        Me.txtItemName.ShortcutsEnabled = True
        Me.txtItemName.Size = New System.Drawing.Size(418, 30)
        Me.txtItemName.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtItemName.TabIndex = 2
        Me.txtItemName.UseSelectable = True
        Me.txtItemName.UseStyleColors = True
        Me.txtItemName.WaterMark = "Item Name"
        Me.txtItemName.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtItemName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtIngredientName
        '
        '
        '
        '
        Me.txtIngredientName.CustomButton.Image = Nothing
        Me.txtIngredientName.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtIngredientName.CustomButton.Name = ""
        Me.txtIngredientName.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtIngredientName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIngredientName.CustomButton.TabIndex = 1
        Me.txtIngredientName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtIngredientName.CustomButton.UseSelectable = True
        Me.txtIngredientName.CustomButton.Visible = False
        Me.txtIngredientName.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtIngredientName.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtIngredientName.Lines = New String(-1) {}
        Me.txtIngredientName.Location = New System.Drawing.Point(38, 161)
        Me.txtIngredientName.MaxLength = 32767
        Me.txtIngredientName.Name = "txtIngredientName"
        Me.txtIngredientName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIngredientName.PromptText = "Ingredient Name"
        Me.txtIngredientName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtIngredientName.SelectedText = ""
        Me.txtIngredientName.SelectionLength = 0
        Me.txtIngredientName.SelectionStart = 0
        Me.txtIngredientName.ShortcutsEnabled = True
        Me.txtIngredientName.Size = New System.Drawing.Size(418, 30)
        Me.txtIngredientName.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtIngredientName.TabIndex = 3
        Me.txtIngredientName.UseSelectable = True
        Me.txtIngredientName.UseStyleColors = True
        Me.txtIngredientName.WaterMark = "Ingredient Name"
        Me.txtIngredientName.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtIngredientName.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtSpecification
        '
        '
        '
        '
        Me.txtSpecification.CustomButton.Image = Nothing
        Me.txtSpecification.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtSpecification.CustomButton.Name = ""
        Me.txtSpecification.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtSpecification.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSpecification.CustomButton.TabIndex = 1
        Me.txtSpecification.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtSpecification.CustomButton.UseSelectable = True
        Me.txtSpecification.CustomButton.Visible = False
        Me.txtSpecification.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtSpecification.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtSpecification.Lines = New String(-1) {}
        Me.txtSpecification.Location = New System.Drawing.Point(38, 206)
        Me.txtSpecification.MaxLength = 32767
        Me.txtSpecification.Name = "txtSpecification"
        Me.txtSpecification.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSpecification.PromptText = "Specification"
        Me.txtSpecification.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSpecification.SelectedText = ""
        Me.txtSpecification.SelectionLength = 0
        Me.txtSpecification.SelectionStart = 0
        Me.txtSpecification.ShortcutsEnabled = True
        Me.txtSpecification.Size = New System.Drawing.Size(418, 30)
        Me.txtSpecification.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtSpecification.TabIndex = 4
        Me.txtSpecification.UseSelectable = True
        Me.txtSpecification.UseStyleColors = True
        Me.txtSpecification.WaterMark = "Specification"
        Me.txtSpecification.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtSpecification.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtCategory
        '
        '
        '
        '
        Me.txtCategory.CustomButton.Image = Nothing
        Me.txtCategory.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtCategory.CustomButton.Name = ""
        Me.txtCategory.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtCategory.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCategory.CustomButton.TabIndex = 1
        Me.txtCategory.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtCategory.CustomButton.UseSelectable = True
        Me.txtCategory.CustomButton.Visible = False
        Me.txtCategory.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtCategory.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtCategory.Lines = New String(-1) {}
        Me.txtCategory.Location = New System.Drawing.Point(38, 253)
        Me.txtCategory.MaxLength = 32767
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCategory.PromptText = "Category"
        Me.txtCategory.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtCategory.SelectedText = ""
        Me.txtCategory.SelectionLength = 0
        Me.txtCategory.SelectionStart = 0
        Me.txtCategory.ShortcutsEnabled = True
        Me.txtCategory.Size = New System.Drawing.Size(418, 30)
        Me.txtCategory.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtCategory.TabIndex = 5
        Me.txtCategory.UseSelectable = True
        Me.txtCategory.UseStyleColors = True
        Me.txtCategory.WaterMark = "Category"
        Me.txtCategory.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtCategory.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtItemType
        '
        '
        '
        '
        Me.txtItemType.CustomButton.Image = Nothing
        Me.txtItemType.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtItemType.CustomButton.Name = ""
        Me.txtItemType.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtItemType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtItemType.CustomButton.TabIndex = 1
        Me.txtItemType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtItemType.CustomButton.UseSelectable = True
        Me.txtItemType.CustomButton.Visible = False
        Me.txtItemType.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtItemType.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtItemType.Lines = New String(-1) {}
        Me.txtItemType.Location = New System.Drawing.Point(38, 299)
        Me.txtItemType.MaxLength = 32767
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemType.PromptText = "Item Type"
        Me.txtItemType.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtItemType.SelectedText = ""
        Me.txtItemType.SelectionLength = 0
        Me.txtItemType.SelectionStart = 0
        Me.txtItemType.ShortcutsEnabled = True
        Me.txtItemType.Size = New System.Drawing.Size(418, 30)
        Me.txtItemType.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtItemType.TabIndex = 6
        Me.txtItemType.UseSelectable = True
        Me.txtItemType.UseStyleColors = True
        Me.txtItemType.WaterMark = "Item Type"
        Me.txtItemType.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtItemType.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtBaselineQty
        '
        '
        '
        '
        Me.txtBaselineQty.CustomButton.Image = Nothing
        Me.txtBaselineQty.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtBaselineQty.CustomButton.Name = ""
        Me.txtBaselineQty.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtBaselineQty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtBaselineQty.CustomButton.TabIndex = 1
        Me.txtBaselineQty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtBaselineQty.CustomButton.UseSelectable = True
        Me.txtBaselineQty.CustomButton.Visible = False
        Me.txtBaselineQty.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtBaselineQty.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtBaselineQty.Lines = New String(-1) {}
        Me.txtBaselineQty.Location = New System.Drawing.Point(38, 344)
        Me.txtBaselineQty.MaxLength = 32767
        Me.txtBaselineQty.Name = "txtBaselineQty"
        Me.txtBaselineQty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBaselineQty.PromptText = "Wanted Level"
        Me.txtBaselineQty.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtBaselineQty.SelectedText = ""
        Me.txtBaselineQty.SelectionLength = 0
        Me.txtBaselineQty.SelectionStart = 0
        Me.txtBaselineQty.ShortcutsEnabled = True
        Me.txtBaselineQty.Size = New System.Drawing.Size(418, 30)
        Me.txtBaselineQty.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtBaselineQty.TabIndex = 7
        Me.txtBaselineQty.UseSelectable = True
        Me.txtBaselineQty.UseStyleColors = True
        Me.txtBaselineQty.WaterMark = "Wanted Level"
        Me.txtBaselineQty.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtBaselineQty.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnEdit
        '
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnEdit.Image = Global.FuturePOS.My.Resources.Resources.edit_folder_36px
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(222, 501)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(114, 45)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnAdd.Image = Global.FuturePOS.My.Resources.Resources.Add36
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(342, 501)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(114, 45)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnClear.Image = Global.FuturePOS.My.Resources.Resources.Clear36
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(102, 501)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(114, 45)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.BackColor = System.Drawing.Color.White
        Me.lblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.Black
        Me.lblItemName.Location = New System.Drawing.Point(463, 117)
        Me.lblItemName.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(30, 30)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Visible = False
        '
        'lblIngredientName
        '
        Me.lblIngredientName.AutoSize = True
        Me.lblIngredientName.BackColor = System.Drawing.Color.White
        Me.lblIngredientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngredientName.ForeColor = System.Drawing.Color.Black
        Me.lblIngredientName.Location = New System.Drawing.Point(462, 161)
        Me.lblIngredientName.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblIngredientName.Name = "lblIngredientName"
        Me.lblIngredientName.Size = New System.Drawing.Size(30, 30)
        Me.lblIngredientName.TabIndex = 32
        Me.lblIngredientName.Visible = False
        '
        'lblSpecification
        '
        Me.lblSpecification.AutoSize = True
        Me.lblSpecification.BackColor = System.Drawing.Color.White
        Me.lblSpecification.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecification.ForeColor = System.Drawing.Color.Black
        Me.lblSpecification.Location = New System.Drawing.Point(462, 206)
        Me.lblSpecification.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblSpecification.Name = "lblSpecification"
        Me.lblSpecification.Size = New System.Drawing.Size(30, 30)
        Me.lblSpecification.TabIndex = 33
        Me.lblSpecification.Visible = False
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.BackColor = System.Drawing.Color.White
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.Black
        Me.lblCategory.Location = New System.Drawing.Point(462, 253)
        Me.lblCategory.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(30, 30)
        Me.lblCategory.TabIndex = 34
        Me.lblCategory.Visible = False
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.BackColor = System.Drawing.Color.White
        Me.lblItemType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemType.ForeColor = System.Drawing.Color.Black
        Me.lblItemType.Location = New System.Drawing.Point(466, 299)
        Me.lblItemType.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(30, 30)
        Me.lblItemType.TabIndex = 35
        Me.lblItemType.Visible = False
        '
        'txtPrice
        '
        '
        '
        '
        Me.txtPrice.CustomButton.Image = Nothing
        Me.txtPrice.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtPrice.CustomButton.Name = ""
        Me.txtPrice.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPrice.CustomButton.TabIndex = 1
        Me.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtPrice.CustomButton.UseSelectable = True
        Me.txtPrice.CustomButton.Visible = False
        Me.txtPrice.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtPrice.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtPrice.Lines = New String(-1) {}
        Me.txtPrice.Location = New System.Drawing.Point(38, 390)
        Me.txtPrice.MaxLength = 32767
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPrice.PromptText = "Price"
        Me.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPrice.SelectedText = ""
        Me.txtPrice.SelectionLength = 0
        Me.txtPrice.SelectionStart = 0
        Me.txtPrice.ShortcutsEnabled = True
        Me.txtPrice.Size = New System.Drawing.Size(418, 30)
        Me.txtPrice.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtPrice.TabIndex = 8
        Me.txtPrice.UseSelectable = True
        Me.txtPrice.UseStyleColors = True
        Me.txtPrice.WaterMark = "Price"
        Me.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtPrice.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtQty
        '
        '
        '
        '
        Me.txtQty.CustomButton.Image = Nothing
        Me.txtQty.CustomButton.Location = New System.Drawing.Point(390, 2)
        Me.txtQty.CustomButton.Name = ""
        Me.txtQty.CustomButton.Size = New System.Drawing.Size(25, 25)
        Me.txtQty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQty.CustomButton.TabIndex = 1
        Me.txtQty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtQty.CustomButton.UseSelectable = True
        Me.txtQty.CustomButton.Visible = False
        Me.txtQty.FontSize = MetroFramework.MetroTextBoxSize.Medium
        Me.txtQty.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.txtQty.Lines = New String(-1) {}
        Me.txtQty.Location = New System.Drawing.Point(38, 435)
        Me.txtQty.MaxLength = 32767
        Me.txtQty.Name = "txtQty"
        Me.txtQty.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQty.PromptText = "Baseline Quantity"
        Me.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtQty.SelectedText = ""
        Me.txtQty.SelectionLength = 0
        Me.txtQty.SelectionStart = 0
        Me.txtQty.ShortcutsEnabled = True
        Me.txtQty.Size = New System.Drawing.Size(418, 30)
        Me.txtQty.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQty.TabIndex = 9
        Me.txtQty.UseSelectable = True
        Me.txtQty.UseStyleColors = True
        Me.txtQty.WaterMark = "Baseline Quantity"
        Me.txtQty.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtQty.WaterMarkFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.White
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Black
        Me.lblID.Location = New System.Drawing.Point(49, 501)
        Me.lblID.MinimumSize = New System.Drawing.Size(30, 30)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(30, 30)
        Me.lblID.TabIndex = 38
        Me.lblID.Visible = False
        '
        'Product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(496, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.lblItemType)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblSpecification)
        Me.Controls.Add(Me.lblIngredientName)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtBaselineQty)
        Me.Controls.Add(Me.txtItemType)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtSpecification)
        Me.Controls.Add(Me.txtIngredientName)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.txtProductCode)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Product"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProductCode As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtItemName As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtIngredientName As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtSpecification As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtCategory As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtItemType As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtBaselineQty As MetroFramework.Controls.MetroTextBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblIngredientName As Label
    Friend WithEvents lblSpecification As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblItemType As Label
    Friend WithEvents txtPrice As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtQty As MetroFramework.Controls.MetroTextBox
    Friend WithEvents lblID As Label
End Class
