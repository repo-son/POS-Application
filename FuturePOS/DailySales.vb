Imports System.Data.SqlClient
Public Class DailySales
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub
    Sub LoadSales()
        Dim sdate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        DataGridView1.Rows.Clear()
        Dim i As Integer = 0
        con.Open()
        cmd = New SqlCommand("select * from Cart as ca inner join Products as p on ca.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where sdate between '" & sdate & "' and '" & sdate & "' and status like 'Sold' order by invoice,ItemName", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            i += 1
            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("invoice").ToString, dr.Item("ItemName").ToString, dr.Item("SpecificationName").ToString, dr.Item("IngredientName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("price").ToString, dr.Item("qty").ToString, dr.Item("total").ToString)
        End While
        dr.Close()
        con.Close()

        lblTot.Text = Format(GetData("select isnull(sum(total),0) from Cart where sdate between '" & sdate & "' and '" & sdate & "' and status like 'Sold'"), "#,##0.00")
        lblDisc.Text = Format(GetData("select isnull(sum(discount),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "' "), "#,##0.00")
        lblSub.Text = Format(GetData("select isnull(sum(subtotal),0) from Payment where sdate between '" & sdate & "'and '" & sdate & "' "), "#,##0.00")
        lblMBSpecial.Text = Format(GetData("select isnull(sum(vat),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "'"), "#,##0.00")
        lblTotSales.Text = Format(GetData("select isnull(sum(amountdue),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "'"), "#,##0.00")
        lblTotal.Text = "Total Daily Sales : " & lblTotSales.Text
        DataGridView1.Rows.Add("", "", "", "", "", "", "", "", "", "Total", lblTot.Text)
    End Sub
    Function GetData(ByVal sql As String) As Double
        con.Open()
        cmd = New SqlCommand(sql, con)
        GetData = CDbl(cmd.ExecuteScalar)

        con.Close()
        Return GetData
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        LoadSales()
    End Sub
End Class