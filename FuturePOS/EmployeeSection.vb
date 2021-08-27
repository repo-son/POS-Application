Imports System.Data.SqlClient
Public Class EmployeeSection
    Private Const textPrefix As String = " "
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub EmployeeSection_Load(sender As Object, e As EventArgs) Handles Me.Load
        MetroTabControl1.SelectedIndex = 0
        LoadDepartments()
        txtEmployeeID.Enabled = False
        txtEmployeeID.Text = getEmployeeID()
        LoadEmployee()

    End Sub

    Private Sub MetroTabControl1_Click(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        If MetroTabControl1.SelectedIndex = 5 Then
            With Shifts
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

    Private Sub btnAddRate_Click(sender As Object, e As EventArgs) Handles btnAddRate.Click
        If IS_EMPTY(txtPaymentRate) = True Then Return
        If IS_EMPTY(cmbDepartmentRates) = True Then Return
        If IS_EMPTY(txtot) = True Then Return
        Try

            con.Open()
            cmd = New SqlCommand("select count(*) from PaymentRates where department like '" & cmbDepartmentRates.SelectedItem & "'", con)
            Dim icount As Integer = cmd.ExecuteScalar()
            con.Close()
            If icount > 0 Then
                con.Open()
                cmd = New SqlCommand("update PaymentRates set paymentrate = '" & CLng(txtPaymentRate.Text) & "', ot = '" & CLng(txtot.Text) & "' where department = '" & cmbDepartmentRates.SelectedItem & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                LoadDepartments()
                txtPaymentRate.Clear()
                txtot.Clear()
                MsgBox("Payment Rates Successfully Updated", vbInformation)
            ElseIf icount <= 0 Then
                con.Open()
                cmd = New SqlCommand("insert into PaymentRates (department,paymentrate,ot) values ('" & cmbDepartmentRates.SelectedItem & "','" & CLng(txtPaymentRate.Text) & "','" & CLng(txtot.Text) & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()
                LoadDepartments()
                txtPaymentRate.Clear()
                txtot.Clear()
                MsgBox("Payment Rates Successfully Added", vbInformation)
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtPaymentRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaymentRate.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub cmbDepartmentRates_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartmentRates.TextChanged
        Try
            txtPaymentRate.Clear()
            txtot.Clear()
            con.Open()
            cmd = New SqlCommand("select * from PaymentRates where department =  '" & cmbDepartmentRates.SelectedItem & "'", con)
            dr = cmd.ExecuteReader()
            While dr.Read()
                txtPaymentRate.Text = dr.Item("paymentrate").ToString
                txtot.Text = dr.Item("ot").ToString
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub LoadDepartments()
        Try
            Dim i As Integer = 0
            DataGridView4.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("select * from PaymentRates", con)
            dr = cmd.ExecuteReader()
            While dr.Read()
                i += 1
                DataGridView4.Rows.Add(i, dr.Item("id").ToString, dr.Item("department").ToString, dr.Item("ot").ToString, dr.Item("paymentrate").ToString)
            End While
            dr.Close()
            con.Close()
        Catch ex As InvalidCastException
        End Try
    End Sub

    Private Sub txtot_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtot.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnBonus_Click(sender As Object, e As EventArgs) Handles btnBonus.Click
        If IS_EMPTY(txtBonus) = True Then Return
        Try
            con.Open()
            cmd = New SqlCommand("select count(*) from Bonus", con)
            Dim icount As Integer = CInt(cmd.ExecuteScalar)
            con.Close()

            If icount > 0 Then
                con.Open()
                cmd = New SqlCommand("update Bonus set bonus = '" & CDbl(txtBonus.Text) & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Bonus Updated Succesfully", vbInformation)

            Else
                con.Open()
                cmd = New SqlCommand("insert into Bonus (bonus) values ('" & CDbl(txtBonus.Text) & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Bonus Added to the Salary Department", vbInformation)
            End If

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Function getEmployeeID() As String
        Try
            Dim sdate As String = Now.ToString("yyyy")
            con.Open()
            cmd = New SqlCommand("select EmpID from Employee where EmpID like '%" & sdate & "%' order by id desc", con)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then getEmployeeID = dr.Item("EmpID").ToString Else getEmployeeID = String.Empty
            dr.Close()
            con.Close()
            If getEmployeeID = String.Empty Then
                getEmployeeID = sdate & "001"
                Return getEmployeeID
            Else
                getEmployeeID = Str(CLng(getEmployeeID) + 1)
                Return getEmployeeID
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
            Return getEmployeeID()
        Finally
            con.Close()
        End Try
    End Function

    Private Sub txtBonus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBonus.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnRegisterNew_Click(sender As Object, e As EventArgs) Handles btnRegisterNew.Click
        Try
            Dim sdate1 As String = txtDOB.Value.ToString("yyyy-MM-dd")
            Dim sdate2 As String = txtDatehired.Value.ToString("yyyy-MM-dd")
            If IS_EMPTY(txtFirstName) = True Then Return
            If IS_EMPTY(txtMiddleName) = True Then Return
            If IS_EMPTY(txtLastName) = True Then Return
            If IS_EMPTY(cmbGender) = True Then Return
            If IS_EMPTY(txtMobile) = True Then Return
            If IS_EMPTY(txtMobileSOS) = True Then Return
            If IS_EMPTY(txtDOB) = True Then Return
            If IS_EMPTY(txtCurrentAddress) = True Then Return
            If IS_EMPTY(txtCivilStatus) = True Then Return
            If IS_EMPTY(txtPOB) = True Then Return
            If IS_EMPTY(cmbDepartmentRegister) = True Then Return
            If IS_EMPTY(txtDatehired) = True Then Return
            If IS_EMPTY(cmbWorkStatus) = True Then Return
            If IS_EMPTY(cmbPaidBy) = True Then Return
            If MsgBox("Register New Employee, Please Confirm Details", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = Nothing
                cmd = New SqlCommand("insert into Employee(firstname,middlename,lastname,gender,mobile,mobileSOS,DOB,currentaddress,civilstatus,POB,department,datehired,workstatus,paidby,EmpID) values(@firstname,@middlename,@lastname,@gender,@mobile,@mobileSOS,@DOB,@currentaddress,@civilstatus,@POB,@department,@datehired,@workstatus,@paidby,@EmpID)", con)
                With cmd
                    cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@middlename", txtMiddleName.Text)
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem)
                    cmd.Parameters.AddWithValue("@mobile", txtMobile.Text)
                    cmd.Parameters.AddWithValue("@mobileSOS", txtMobileSOS.Text)
                    cmd.Parameters.AddWithValue("@DOB", sdate1)
                    cmd.Parameters.AddWithValue("@currentaddress", txtCurrentAddress.Text)
                    cmd.Parameters.AddWithValue("@civilstatus", txtCivilStatus.SelectedItem)
                    cmd.Parameters.AddWithValue("@POB", txtPOB.Text)
                    cmd.Parameters.AddWithValue("@department", cmbDepartmentRegister.SelectedItem)
                    cmd.Parameters.AddWithValue("@datehired", sdate2)
                    cmd.Parameters.AddWithValue("@workstatus", cmbWorkStatus.SelectedItem)
                    cmd.Parameters.AddWithValue("@paidby", cmbPaidBy.SelectedItem)
                    cmd.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Clear()
                    txtEmployeeID.Text = getEmployeeID()
                    MsgBox("Registration Succesfull, Thank You", vbInformation)
                    txtFirstName.Focus()
                End With

            End If


        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtLastName.Clear()
        cmbGender.ResetText()
        txtMobile.Clear()
        txtMobileSOS.Clear()
        txtDOB.ResetText()
        txtCurrentAddress.Clear()
        txtCivilStatus.ResetText()
        txtPOB.Clear()
        cmbDepartmentRegister.ResetText()
        txtDatehired.ResetText()
        cmbWorkStatus.ResetText()
        cmbPaidBy.ResetText()
    End Sub

    Private Sub btnCleanNew_Click(sender As Object, e As EventArgs) Handles btnCleanNew.Click
        Clear()
    End Sub

    Sub LoadEmployee()
        Try
            Dim i As Integer = 0
            con.Open()
            DataGridView3.Rows.Clear()
            cmd = New SqlCommand("select * from Employee order by datehired desc", con)
            dr = cmd.ExecuteReader()
            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            DataGridView3.Rows.Clear()
            Dim ii As Integer = 0
            If IS_EMPTY(cmbFilterDepa) = True Then Return
            If cmbFilterDepa.Text = "All" Then

                con.Open()
                cmd = New SqlCommand("select * from Employee", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    ii += 1
                    DataGridView3.Rows.Add(ii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
                End While
                dr.Close()
                con.Close()
            ElseIf cmbFilterDepa.SelectedItem = "Cooking" Then
                con.Open()
                cmd = New SqlCommand("select * from Employee where department = '" & cmbFilterDepa.SelectedItem & "'", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    ii += 1
                    DataGridView3.Rows.Add(ii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
                End While
                dr.Close()
                con.Close()
            ElseIf cmbFilterDepa.SelectedItem = "Cleaning" Then
                con.Open()
                cmd = New SqlCommand("select * from Employee where department = '" & cmbFilterDepa.SelectedItem & "'", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    ii += 1
                    DataGridView3.Rows.Add(ii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
                End While
                dr.Close()
                con.Close()
            ElseIf cmbFilterDepa.SelectedItem = "Serving" Then
                con.Open()
                cmd = New SqlCommand("select * from Employee where department = '" & cmbFilterDepa.SelectedItem & "'", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    ii += 1
                    DataGridView3.Rows.Add(ii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
                End While
                dr.Close()
                con.Close()
            ElseIf cmbFilterDepa.SelectedItem = "Front House" Then
                con.Open()
                cmd = New SqlCommand("select * from Employee where department = '" & cmbFilterDepa.SelectedItem & "'", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    ii += 1
                    DataGridView3.Rows.Add(ii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("mobile").ToString, dr.Item("mobileSOS").ToString, dr.Item("DOB").ToString, dr.Item("currentaddress").ToString, dr.Item("civilstatus").ToString, dr.Item("POB").ToString, dr.Item("department").ToString, dr.Item("datehired").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString)
                End While
                dr.Close()
                con.Close()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshSalary_Click(sender As Object, e As EventArgs) Handles btnRefreshSalary.Click
        Try
            DataGridView1.Rows.Clear()
            Dim iii As Integer = 0
            If IS_EMPTY(txtEmpIDSalary) = True Then Return

            con.Open()
            cmd = New SqlCommand("select * from Bonus", con)
            dr = cmd.ExecuteReader()
            While dr.Read()
                Label5.Text = dr.Item("bonus").ToString
            End While
            dr.Close()
            con.Close()


            con.Open()
            cmd = New SqlCommand("select * from Employee as e inner join PaymentRates as p on e.department = p.department where EmpID = '" & txtEmpIDSalary.Text & "'", con)
            dr = cmd.ExecuteReader()
            If dr.HasRows() Then

                While dr.Read()
                    lblFullName.Text = dr("firstname") & Space(1) & dr("lastname")
                    lblDepartmentSalary.Text = dr("department")
                    lblWorkStatus.Text = dr("workstatus")
                    lblPaymentType.Text = dr("paidby")
                    lblBonus.Text = Label5.Text
                    lblDefaultRate.Text = dr("paymentrate")
                    lblOTBonus.Text = dr("ot")
                End While
                dr.Close()
                con.Close()
                With DaysWorked
                    .ShowDialog()
                End With
                TotalPayment()

                con.Open()
                cmd = New SqlCommand("select * from Employee as e inner join PaymentRates as p on e.department = p.department where EmpID = '" & txtEmpIDSalary.Text & "'", con)
                dr = cmd.ExecuteReader()
                While dr.Read()
                    iii += 1
                    DataGridView1.Rows.Add(iii, dr.Item("EmpID").ToString, dr.Item("firstname").ToString + Space(2) + "" + Space(2) + dr.Item("lastname").ToString, dr.Item("department").ToString, dr.Item("workstatus").ToString, dr.Item("paidby").ToString, dr.Item("paymentrate").ToString, lblDaysWorked.Text, Label5.Text, dr.Item("ot").ToString, lblOTSalary.Text, lblTotalPayment.Text)
                End While
                dr.Close()
                con.Close()
            Else
                MsgBox("Wrong ID Entered, Please Double Check Employee ID", vbCritical)
            End If
            dr.Close()
            con.Close()

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CLear2()
        txtEmpIDSalary.Clear()
        lblFullName.Text = ""
        lblDepartmentSalary.Text = ""
        lblWorkStatus.Text = ""
        lblPaymentType.Text = ""
        lblDefaultRate.Text = ""
        lblBonus.Text = ""
        lblOTBonus.Text = ""
        lblOTSalary.Text = ""
        lblDaysWorked.Text = ""
        lblTotalPayment.Text = ""
    End Sub

    Private Sub txtEmpIDSalary_TextChanged(sender As Object, e As EventArgs) Handles txtEmpIDSalary.TextChanged
        If Not txtEmpIDSalary.Text.StartsWith(textPrefix) Then
            txtEmpIDSalary.Text = textPrefix
            txtEmpIDSalary.SelectionStart = txtEmpIDSalary.Text.Length
        End If

    End Sub

    Sub TotalPayment()
        Try
            If lblOTSalary.Text = 0 Then
                lblTotalPayment.Text = Format(CDec(lblDefaultRate.Text * lblDaysWorked.Text) + CDec(lblDefaultRate.Text * lblDaysWorked.Text * lblBonus.Text), "#,##0.00")
            Else
                lblTotalPayment.Text = Format(CDec(lblDefaultRate.Text * lblDaysWorked.Text) + CDec(lblDefaultRate.Text * lblDaysWorked.Text * lblBonus.Text) + CDec(lblOTSalary.Text * lblOTBonus.Text), "#,##0.00")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtEmpIDSalary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmpIDSalary.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtMobileSOS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobileSOS.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbFilterDepa.SelectedItem = "" Then
            MsgBox("Select Department to Generate Report", vbCritical)
        Else
            With PrintPreview1
                .ShowDialog()
            End With
        End If

    End Sub

    Private Sub btnPrintSlip_Click(sender As Object, e As EventArgs) Handles btnPrintSlip.Click
        If MsgBox("Do you want to Print Slip and Finalize the Work", vbYesNo + vbInformation) = vbYes Then
            If lblTotalPayment.Text = "" Then
                MsgBox("Fill Pay Slip Before Make the Report", vbCritical)
            Else
                CLear2()
                With PaySlip
                    .ShowDialog()
                End With
            End If

        End If


    End Sub
End Class