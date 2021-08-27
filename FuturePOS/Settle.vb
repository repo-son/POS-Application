Imports System.Data.SqlClient
Public Class Settle
    Private Sub Settle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub Settle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                SettleAmountDue()
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Sub SettleAmountDue()
        Try
            Dim sdate As String = Now.ToString("yyyy-MM-dd")
            If CDbl(lblAmountDue.Text) > CDbl(txtCash.Text) Then
                MsgBox("Insufficient Cash to Balance the Bill", vbInformation)
                Return
            End If
            If MsgBox("Proceed to Checkout, Please Confirm", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = Nothing
                cmd = New SqlCommand("insert into Payment(invoice,subtotal,vat,discount,amountdue,sdate,users) values(@invoice,@subtotal,@vat,@discount,@amountdue,@sdate,@users)", con)
                With Sales
                    cmd.Parameters.AddWithValue("@invoice", .lblInvoice.Text)
                    cmd.Parameters.AddWithValue("@subtotal", CDbl(.lblSubtotal.Text))
                    cmd.Parameters.AddWithValue("@vat", CDbl(.lblSpecial.Text))
                    cmd.Parameters.AddWithValue("@discount", CDbl(.lblDiscount.Text))
                    cmd.Parameters.AddWithValue("@amountdue", CDbl(.lblAmount.Text))
                    cmd.Parameters.AddWithValue("@sdate", sdate)
                    cmd.Parameters.AddWithValue("@users", strUser)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ManageStockWhenPurchase()
                    MsgBox("Payment Succesfull, Thank You", vbInformation)
                    .lblInvoice.Text = .getInvoiceNumber
                    .LoadCart()
                    .txtSearch.Clear()
                    .txtSearch.Focus()
                    .Clear()
                    Me.Dispose()

                End With

            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        Try
            Dim Change As Double = CDbl(txtCash.Text) - CDbl(lblAmountDue.Text)
            If Change < 0 Then

                lblChange.Text = "0.00"
            Else
                lblChange.Text = Format(Change, "#,##0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ManageStockWhenPurchase()
        With Sales
            For i = 0 To .DataGridView1.Rows.Count - 1
                con.Open()
                cmd = New SqlCommand("update Products set Qty = Qty - " & CInt(.DataGridView1.Rows(i).Cells(10).Value.ToString) & " where pid like " & CInt(.DataGridView1.Rows(i).Cells(2).Value.ToString) & "", con)
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            con.Open()
            cmd = New SqlCommand("update Cart set status = 'Sold' where invoice like '" & .lblInvoice.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
        End With
    End Sub
End Class