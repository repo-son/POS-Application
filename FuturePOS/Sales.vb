Imports System.Data.SqlClient
Imports System.Data
Public Class Sales
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If strUserRole = "Cashier" Then
            Application.Exit()
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If DataGridView1.RowCount > 0 Then Return
        lblInvoice.Text = getInvoiceNumber()
        btnUpkeep.Enabled = True
        txtSearch.Enabled = True
        txtSearch.Focus()
    End Sub
    Sub LoadCart()
        Try
            Dim totale As Double = 0, i As Integer = 0
            con.Open()
            DataGridView1.Rows.Clear()
            cmd = New SqlCommand("select * from Cart as ct inner join Products as p on ct.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where invoice like '" & lblInvoice.Text & "' ", con)
            dr = cmd.ExecuteReader()
            While dr.Read
                i += 1
                DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pid").ToString, dr.Item("invoice").ToString, dr.Item("ItemName").ToString, dr.Item("SpecificationName").ToString, dr.Item("IngredientName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("price").ToString, dr.Item("qty").ToString, dr.Item("total").ToString)
                totale += CDbl(dr.Item("total").ToString)
            End While
            dr.Close()
            con.Close()
            SalesDetails(CDbl(totale))
            If DataGridView1.RowCount > 0 Then btnSettle.Enabled = True Else btnSettle.Enabled = False
            If DataGridView1.RowCount > 0 Then btnDiscount.Enabled = True Else btnDiscount.Enabled = False
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Sub SalesDetails(ByVal totale As Double)
        lblTotal.Text = Format(totale, "#,##0.00")
        lblSubtotal.Text = Format(CDbl(lblTotal.Text) - CDbl(lblDiscount.Text), "#,##0.00")
        lblSpecial.Text = Format(CDbl(lblSubtotal.Text) * GetVat(), "#,##0.00")
        lblAmount.Text = Format(CDbl(lblSubtotal.Text) - CDbl(lblSpecial.Text), "#,##0.00")
        lblDisplay.Text = lblAmount.Text
    End Sub

    Function getInvoiceNumber() As String
        Try
            Dim sdate As String = Now.ToString("yyyyMMdd")
            con.Open()
            cmd = New SqlCommand("select invoice from Cart where invoice like '%" & sdate & "%' order by id desc", con)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then getInvoiceNumber = dr.Item("invoice").ToString Else getInvoiceNumber = String.Empty
            dr.Close()
            con.Close()
            If getInvoiceNumber = String.Empty Then
                getInvoiceNumber = sdate & "0001"
                Return getInvoiceNumber
            Else
                getInvoiceNumber = Str(CLng(getInvoiceNumber) + 1)
                Return getInvoiceNumber
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
            Return getInvoiceNumber()
        Finally
            con.Close()
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToLongDateString
        lblTime.Text = Now.ToString("hh:mm:ss tt")
    End Sub
    Sub SearchProduct(ByVal psearch As String)
        Try

            If psearch = String.Empty Then Return
            con.Open()
            cmd = New SqlCommand("select * from Products where productcode like '" & psearch & "'", con)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                With Qty
                    .lblPrice.Text = dr.Item("price").ToString
                    .lblID.Text = dr.Item("pid").ToString
                    dr.Close()
                    con.Close()
                    .ShowDialog()
                    Return
                End With
                con.Close()
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        SearchProduct(txtSearch.Text)
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If DataGridView1.Columns(e.ColumnIndex).Name = "Column5" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.delete_trash_20px, CInt((e.CellBounds.Width / 2) - (My.Resources.delete_trash_20px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.delete_trash_20px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        With Security
            .Hide()
        End With
        lblEMP.Text = StrName
        lblDate.Text = Date.Now
    End Sub

    Private Sub Sales_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                btnNew_Click(sender, e)
            Case Keys.F2
                btnUpkeep_Click(sender, e)
            Case Keys.F3
                btnDiscount_Click(sender, e)
            Case Keys.F4
                btnSettle_Click(sender, e)
            Case Keys.F5
                btnDailySales_Click(sender, e)
            Case Keys.F6
                btnShifts_Click(sender, e)


        End Select
    End Sub

    Private Sub btnDailySales_Click(sender As Object, e As EventArgs) Handles btnDailySales.Click
        With DailySales
            .LoadSales()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnShifts_Click(sender As Object, e As EventArgs) Handles btnShifts.Click
        With GrantAccess
            .ShowDialog()
        End With

        With Shifts
            .ShowDialog()
        End With
    End Sub

    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        With Settle
            .lblAmountDue.Text = lblAmount.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        With Discount
            .GetDiscount()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnUpkeep_Click(sender As Object, e As EventArgs) Handles btnUpkeep.Click
        With ProductInquiry
            .LoadDatabase()
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column5" Then
            If MsgBox("Want to Remove Item from Transaction?", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = New SqlCommand("delete from Cart where id like '" & DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Product Removed Successfully", vbInformation)
                LoadCart()
            End If
        End If
    End Sub
    Sub Clear()
        lblDiscount.Text = "0.00"
        lblSpecial.Text = "0.00"
        lblSubtotal.Text = "0.00"
        lblAmount.Text = "0.00"
        lblDisplay.Text = "0.00"

    End Sub

    Private Sub Sales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        With Security
            .Show()
        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With ChangeSecurity
            .ShowDialog()
        End With
    End Sub
End Class