Imports System.Data.SqlClient
Public Class ChangeSecurity
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        txtConfirmNewPassword.Clear()
        txtNewPassword.Clear()
        txtOldPassword.Clear()
        txtOldPassword.Focus()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            If IS_EMPTY(txtOldPassword) = True Then Return
            If IS_EMPTY(txtNewPassword) = True Then Return
            If IS_EMPTY(txtConfirmNewPassword) = True Then Return
            If txtOldPassword.Text <> strPass Then
                MsgBox("Old Password Did Not Match", vbExclamation)
                Return
            End If
            If txtNewPassword.Text <> txtConfirmNewPassword.Text Then
                MsgBox("New Passwords Did not Match", vbExclamation)
                Return
            End If
            If MsgBox("Confirm Password Change", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = New SqlCommand("update Users set Password =  @Password where Username like @Username", con)
                cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text)
                cmd.Parameters.AddWithValue("@Username", strUser)
                cmd.ExecuteNonQuery()
                con.Close()
                strPass = txtNewPassword.Text
                MsgBox("Password Reset Completed", vbInformation)
                txtConfirmNewPassword.Clear()
                txtNewPassword.Clear()
                txtOldPassword.Clear()
                txtOldPassword.Focus()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class