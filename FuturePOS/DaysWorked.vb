Public Class DaysWorked
    Private Sub DaysWorked_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
            Case Keys.Down
                txtOTDays.Focus()
            Case Keys.Up
                txtQty.Focus()
        End Select
    End Sub

    Private Sub DaysWorked_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        txtQty.Focus()
        txtQty.SelectionStart = 0
        txtOTDays.SelectionStart = 0
        txtQty.SelectionLength = txtQty.Text.Length
        txtOTDays.SelectionLength = txtOTDays.Text.Length
    End Sub

    Private Sub DaysWorked_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                AddDays()
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Sub AddDays()

        Try
            If txtQty.Text = String.Empty Or txtQty.Text = "0" Then Return
            With EmployeeSection
                .lblDaysWorked.Text = txtQty.Text
                .lblOTSalary.Text = txtOTDays.Text
            End With
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
End Class