Public Class Form1

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point
    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        With Maintainance
            .TopLevel = False
            .AutoSize = True
            Me.Panel3.Controls.Add(Maintainance)
            Panel3.Dock = DockStyle.Fill
            .BringToFront()
            .txtVat.Text = GetVat()
            .LoadDiscounts()
            .Show()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to Exit Application?", "Data Loss Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Application.Exit()
        ElseIf result = DialogResult.No Then

        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Format(Now, "hh:mm:ss")
        Label5.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        MonthCalendar1.Hide()
        Connection()
        With Security
            .Hide()
        End With
        ToolTip1.SetToolTip(Button1, "Cashier Window")
        ToolTip2.SetToolTip(Button2, "Sales Report")
        ToolTip3.SetToolTip(Button3, "Add Products To Cashier")
        ToolTip4.SetToolTip(btnCategory, "UpKeep Programm")
        ToolTip5.SetToolTip(Button5, "Keep Records")
        ToolTip6.SetToolTip(btnStockHistory, "Stock History")
        ToolTip7.SetToolTip(btnManagement, "Stock Manage")
        ToolTip8.SetToolTip(Button8, "Sign Out")
        ToolTip9.SetToolTip(btnSettings, "Settings")
        ToolTip10.SetToolTip(Button6, "Manage User")
        ToolTip11.SetToolTip(Button9, "Minimize")
        ToolTip12.SetToolTip(Button4, "Close")
        ToolTip13.SetToolTip(lblShow, "Current User")
        ToolTip14.SetToolTip(Label5, "Today")
        ToolTip15.SetToolTip(Label4, "Time")
        ToolTip16.SetToolTip(btnEmployee, "Employee Section")
    End Sub

    Private Sub Button10_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mouseOffset = New Point(-e.X, -e.Y)
            isMouseDown = True
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Location = mousePos
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With ProductsList
            .TopLevel = False
            .AutoSize = True
            Me.Panel3.Controls.Add(ProductsList)
            .LoadDatabase()
            Panel3.Dock = DockStyle.Fill
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Sales
            .ShowDialog()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With Records
            .TopLevel = False
            .AutoSize = True
            Me.Panel3.Controls.Add(Records)
            Panel3.Dock = DockStyle.Fill
            .LoadStocks()
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With User
            .LoadUsersList()
            .ShowDialog()
            .BringToFront()
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        With Security
            .Show()
        End With
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        With Settings
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With GrantAccess
            .ShowDialog()
        End With

        With Reporting
            .TopLevel = False
            Me.Panel3.Controls.Add(Reporting)
            Panel3.Dock = DockStyle.Fill
            .BringToFront()
            .LoadSales2()
            .Show()
        End With
    End Sub

    Private Sub btnStockHistory_Click(sender As Object, e As EventArgs) Handles btnStockHistory.Click
        With Stock
            .ShowDialog()
            .LoadProducts()
            .GetSerialNumber()
        End With
    End Sub

    Private Sub btnManagement_Click(sender As Object, e As EventArgs) Handles btnManagement.Click
        With GrantAccess
            .ShowDialog()
            With StockManage

                .ShowDialog()
                .LoadProducts1()
            End With
        End With

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click

        If MonthCalendar1.Visible = False Then
            MonthCalendar1.Show()
        ElseIf MonthCalendar1.Visible = True Then
            MonthCalendar1.Hide()
        End If
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        With EmployeeSection
            .TopLevel = False
            .AutoSize = True
            Me.Panel3.Controls.Add(EmployeeSection)
            Panel3.Dock = DockStyle.Fill
            .BringToFront()
            .Show()
        End With
    End Sub
End Class
