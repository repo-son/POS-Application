Imports System.Data.SqlClient
Public Class Shifts
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub Shifts_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadShifts2()
    End Sub

    Private Sub DataGridView4_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView4.CellPainting
        If DataGridView4.Columns(e.ColumnIndex).Name = "Column3" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.remove_24px, CInt((e.CellBounds.Width / 2) - (My.Resources.remove_24px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.remove_24px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cmbDepartmentShift.ResetText()
        cmbEmployeeShift.ResetText()
        dtSet1.ResetText()
        dtSet2.ResetText()
    End Sub

    Private Sub cmbEmployeeShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmployeeShift.SelectedIndexChanged

    End Sub

    Private Sub cmbDepartmentShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartmentShift.SelectedIndexChanged

    End Sub

    Private Sub cmbDepartmentShift_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartmentShift.TextChanged
        Try
            cmbEmployeeShift.Items.Clear()
            con.Open()
            cmd = New SqlCommand("select firstname,EmpID from Employee where department = '" & cmbDepartmentShift.SelectedItem & "'", con)
            dr = cmd.ExecuteReader
            While dr.Read()
                cmbEmployeeShift.Items.Add(dr.Item("firstname").ToString & Space(3) & dr.Item("EmpID".ToString))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Try
            If IS_EMPTY(cmbEmployeeShift) = True Then Return
            If IS_EMPTY(cmbDepartmentShift) = True Then Return
            Dim time1 As String = dtSet1.Value.ToString("hh:mm:ss")
            Dim time2 As String = dtSet2.Value.ToString("hh:mm:ss")
            If time1 < time2 Then
                con.Open()
                cmd = New SqlCommand("insert into Shifts (EmpIDname,timeStart,timefinish,department,Shiftstatus,today) values('" & cmbEmployeeShift.SelectedItem & "','" & time1 & "','" & time2 & "','" & cmbDepartmentShift.SelectedItem & "','Not Completed','" & CDate(DateTimePicker1.Value.ToString) & "')", con)
                cmd.ExecuteNonQuery()
                MsgBox("Shift Assigned Successfully", vbInformation)
                con.Close()
                LoadShifts2()
            Else
                MsgBox("Cannot Assign Working time, Please Adjust Correctly", vbCritical)
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Format(Now, "dd/MM/yyyy")
        lblTime.Text = Format(Now, "hh:mm:ss")
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        Dim colName As String = DataGridView4.Columns(e.ColumnIndex).Name
        If colName = "Column4" Then
            If DataGridView4.Rows(e.RowIndex).Cells(5).Value.ToString = "Not Completed" Then
                If MsgBox("Complete Shift Manually, Confirm Action", vbYesNo + vbQuestion) = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("update Shifts set Shiftstatus = 'Completed' where EmpIDname like '" & DataGridView4.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Shift Completed", vbInformation)
                    LoadShifts2()
                End If
            ElseIf DataGridView4.Rows(e.RowIndex).Cells(5).Value.ToString = "Completed" Then
                If MsgBox("Change Shift Back Again, Confirm Action", vbYesNo + vbQuestion) = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("update Shifts set Shiftstatus = 'Not Completed' where EmpIDname like '" & DataGridView4.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Shift is Live", vbInformation)
                    LoadShifts2()
                End If
            End If
        ElseIf colName = "Column3" Then
            If (MsgBox("Do you want to Remove Shift from List and ReAssign?", vbYesNo) = vbYes) Then
                con.Open()
                cmd = New SqlCommand("delete from Shifts where EmpIDname like '" & DataGridView4.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Shift Removed", vbInformation)
                LoadShifts2()
            End If
        End If
    End Sub
    Sub LoadShifts2()
        Try
            DataGridView4.Rows.Clear()
            Dim i As Integer = 0
            con.Open()
            cmd = New SqlCommand("select * from Shifts where today like '" & lblDate.Text & "%' ", con)
            dr = cmd.ExecuteReader()
            While dr.Read()
                i += 1
                DataGridView4.Rows.Add(i, dr.Item("department").ToString, dr.Item("EmpIDname").ToString, dr.Item("timestart").ToString, dr.Item("timefinish").ToString, dr.Item("Shiftstatus").ToString)
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try

    End Sub
End Class