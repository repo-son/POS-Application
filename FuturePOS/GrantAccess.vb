Public Class GrantAccess
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If IS_EMPTY(txtPass) = True Then Return

        If strPass <> txtPass.Text Then
            MsgBox("Password Invalid. Authorization Failed", vbInformation)
            txtPass.Clear()
            Return
        Else
            Me.Dispose()
        End If
    End Sub


    Private Sub GrantAccess_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPass.Focus()
    End Sub
End Class