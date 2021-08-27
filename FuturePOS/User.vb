Imports System.Data.SqlClient
Public Class User
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub cmbRole_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRole.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Try
            If IS_EMPTY(txtUsername) = True Then Return
            If IS_EMPTY(txtPassword) = True Then Return
            If IS_EMPTY(txtConPassword) = True Then Return
            If IS_EMPTY(cmbRole) = True Then Return
            If IS_EMPTY(txtName) = True Then Return

            If txtPassword.Text <> txtConPassword.Text Then
                MsgBox("Passwords did not Match,Please Double Check", vbCritical)
                Return
            ElseIf MsgBox("Please Confirm Adding New User", vbYesNo + vbQuestion) = vbYes Then


                Dim found As Boolean = False
                con.Open()
                cmd = New SqlCommand("select * from Users where Username = '" & txtUsername.Text & "' and Name ='" & txtName.Text & "'", con)
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    found = True
                Else
                    found = False
                End If
                dr.Close()
                con.Close()



                If found = False Then
                    con.Open()
                    cmd = New SqlCommand("insert into Users (Username,Password,Name,UserRole,Status) values (@Username,@Password,@Name,@UserRole,@Status)", con)
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@Name", txtName.Text)
                    cmd.Parameters.AddWithValue("@UserRole", cmbRole.Text)
                    cmd.Parameters.AddWithValue("@Status", "Active")
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("New User Added to the System", vbInformation)
                    Clear()
                ElseIf found = True Then
                    MsgBox("Duplicate Data Warning, Username Already Exists", vbCritical)
                End If
                LoadUsersList()
            End If

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtConPassword.Clear()
        txtName.Clear()
        txtUsername.Focus()
        cmbRole.Text = ""
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub txtConPassword_ButtonClick(sender As Object, e As EventArgs) Handles txtConPassword.ButtonClick
        txtConPassword.PasswordChar = ""
    End Sub

    Private Sub User_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPassword.PasswordChar = "•"
        txtConPassword.PasswordChar = "•"
    End Sub

    Private Sub txtPassword_ButtonClick(sender As Object, e As EventArgs) Handles txtPassword.ButtonClick
        txtPassword.PasswordChar = ""
    End Sub

    Sub LoadUsersList()
        DataGridView3.Rows.Clear()
        Dim i As Integer = 0
        con.Open()
        cmd = New SqlCommand("select * from Users order by UserRole,Username", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            i += 1
            DataGridView3.Rows.Add(i, dr.Item("Username").ToString, dr.Item("UserRole").ToString, dr.Item("Name").ToString, dr.Item("Status").ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        Dim colName As String = DataGridView3.Columns(e.ColumnIndex).Name
        If colName = "colStatus" Then
            If DataGridView3.Rows(e.RowIndex).Cells(4).Value.ToString = "Active" Then
                If MsgBox("Change Account Status to Deactive?, Confirm Action", vbYesNo + vbQuestion) = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("update Users set Status = 'Deactive' where Username like '" & DataGridView3.Rows(e.RowIndex).Cells(1).Value.ToString & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Account Status is Deactive", vbInformation)
                End If
            ElseIf DataGridView3.Rows(e.RowIndex).Cells(4).Value.ToString = "Deactive" Then
                If MsgBox("Change Account Status to Active?, Confirm Action", vbYesNo + vbQuestion) = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("update Users set Status = 'Active' where Username like '" & DataGridView3.Rows(e.RowIndex).Cells(1).Value.ToString & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Account Status is Active", vbInformation)
                End If
            End If
        End If
        LoadUsersList()
    End Sub

    Private Sub forgotpassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgotpassword.LinkClicked
        With ChangeSecurity
            .ShowDialog()
        End With
    End Sub
End Class