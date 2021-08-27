Imports System.Data.SqlClient
Public Class Qty
    Private Sub Qty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtQty.Focus()
        txtQty.SelectionStart = 0
        txtQty.SelectionLength = txtQty.Text.Length
    End Sub

    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                With Sales
                    .txtSearch.Focus()
                    .txtSearch.SelectionStart = 0
                    .txtSearch.SelectionLength = .txtSearch.Text.Length
                End With
                Me.Dispose()
        End Select
    End Sub

    Function GetStockAvailable(ByVal sql As String) As Integer
        con.Open()
        cmd = New SqlCommand(sql, con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GetStockAvailable = CInt(dr.Item("qty").ToString)
        Else
            GetStockAvailable = 0
        End If
        dr.Close()
        con.Close()
        Return GetStockAvailable
    End Function

    Sub AddtoCart()
        Try
            If txtQty.Text = String.Empty Or txtQty.Text = "0" Then Return
            Dim sdate As String = Now.ToString("yyyy-MM-dd")

            con.Open()
            cmd = New SqlCommand("select * from Products where pid like '" & lblID.Text & "' and Qty >= " & CInt(txtQty.Text) & " ", con)
            dr = cmd.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                dr.Close()
                con.Close()
            Else

                dr.Close()
                con.Close()
                MsgBox("Unable to Proceed, Stock is not Enough " & GetStockAvailable("select * from Products where pid like '" & lblID.Text & "'") & "", vbCritical)
                txtQty.Focus()
                txtQty.SelectionStart = 0
                txtQty.SelectionLength = txtQty.Text.Length
                Return
            End If



            con.Open()
            cmd = New SqlCommand("insert into Cart (invoice,pid,price,qty,sdate,users) values (@invoice,@pid,@price,@qty,@sdate,@users)", con)
            With Sales
                cmd.Parameters.AddWithValue("@invoice", .lblInvoice.Text)
                cmd.Parameters.AddWithValue("@pid", lblID.Text)
                cmd.Parameters.AddWithValue("@price", CDbl(lblPrice.Text))
                cmd.Parameters.AddWithValue("@qty", CInt(txtQty.Text))
                cmd.Parameters.AddWithValue("@sdate", sdate)
                cmd.Parameters.AddWithValue("@users", strUser)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("update Cart set total = price * qty where invoice like '" & .lblInvoice.Text & "' ", con)
                cmd.ExecuteNonQuery()
                con.Close()
                .txtSearch.Focus()
                .txtSearch.SelectionStart = 0
                .txtSearch.SelectionLength = .txtSearch.Text.Length
                .LoadCart()
            End With
            Me.Dispose()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                AddtoCart()
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub
End Class