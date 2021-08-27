Imports System.Data.SqlClient
Public Class Records
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Sub LoadStocks()
        Dim i As Integer = 0, total As Double
        DataGridView1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where Qty > 0 and " & cmbFilter.Text & " like '" & txtSearch.Text & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read()
            i += 1
            total += CInt(dr.Item("Qty").ToString)
            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("productcode").ToString, dr.Item("ItemName").ToString, dr.Item("IngredientName").ToString, dr.Item("SpecificationName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("Qty").ToString)
        End While
        dr.Close()
        cmd = Nothing
        con.Close()
        lblStock.Text = "Total Records : " & DataGridView1.Rows.Count
        lblTotStock.Text = "Current Available Stock(s) : " & total
    End Sub

    Private Sub cmbFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFilter.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If IS_EMPTY(cmbFilter) = True Then Return
        If IS_EMPTY(txtSearch) = True Then Return
        LoadStocks()
    End Sub

    Private Sub cmbSelect_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbSelect.KeyPress
        e.Handled = True
    End Sub

    Sub StockCritical()
        Dim i As Integer = 0
        DataGridView2.Rows.Clear()
        con.Open()
        If IS_EMPTY(cmbSelect) = True Then Return
        If cmbSelect.Text = "Currently On Stock" Then
            cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where (Qty <= BsQty and Qty <> 0)", con)

        ElseIf cmbSelect.Text = "Out Of Stock" Then
            cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where Qty = 0", con)
        End If
        dr = cmd.ExecuteReader
        While dr.Read()
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("productcode").ToString, dr.Item("ItemName").ToString, dr.Item("IngredientName").ToString, dr.Item("SpecificationName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("BsQty").ToString, dr.Item("Qty").ToString)
        End While
        dr.Close()
        cmd = Nothing
        con.Close()
        lblcritical.Text = "Total Records : " & DataGridView2.Rows.Count
    End Sub

    Private Sub cmbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelect.SelectedIndexChanged
        StockCritical()
    End Sub

    Private Sub Records_Load(sender As Object, e As EventArgs) Handles Me.Load
        MetroTabControl1.SelectedIndex = 0
    End Sub
    Sub LoadSalesInventory()
        Dim i As Integer = 0
        Dim sdate1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        DataGridView3.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "' order by id", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            i += 1
            DataGridView3.Rows.Add(i, dr.Item("invoice").ToString, dr.Item("subtotal").ToString, dr.Item("vat").ToString, dr.Item("discount").ToString, dr.Item("amountdue").ToString, Format(CDate(dr.Item("sdate").ToString), "MM-dd-yyyy"), dr.Item("users").ToString)
        End While
        dr.Close()
        con.Close()

        lblSaless.Text = "Records Count : " & DataGridView3.RowCount _
                             & Space(10) & "Sub Total : " & Format(GetDataSales("select isnull(sum(subtotal),0) from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "'"), "#,##0.00") _
                             & Space(10) & "MB Special Total : " & Format(GetDataSales("select isnull(sum(vat),0) from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "'"), "#,##0.00") _
                             & Space(10) & "Total Discount : " & Format(GetDataSales("select isnull(sum(discount),0) from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "'"), "#,##0.00") _
                             & Space(10) & "Total Sales : " & Format(GetDataSales("select isnull(sum(amountdue),0) from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "'"), "#,##0.00")
        lblTotalSalesTab.Text = "Total : " & Format(GetDataSales("select isnull(sum(amountdue),0) from Payment where sdate between '" & sdate1 & "' and '" & sdate2 & "'"), "#,##0.00")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadSalesInventory()
    End Sub

    Function GetDataSales(ByVal sql As String) As Double
        con.Open()
        cmd = New SqlCommand(sql, con)
        GetDataSales = CDbl(cmd.ExecuteScalar)
        con.Close()
        Return GetDataSales
    End Function

    Sub GetSoldItems()
        Dim i As Integer = 0
        Dim sdate1 As String = DateSold1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = DateSold2.Value.ToString("yyyy-MM-dd")
        DataGridView4.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select ca.pid, b.ItemName,g.IngredientName,c.SpecificationName,t.category,f.typeName,ca.qty
                                from Cart as ca inner join Products as p on ca.pid = p.pid 
                                inner join Items as b on p.ItmId = b.ItemId 
                                inner join Ingredients as g on p.IngId = g.IngredientId 
                                inner join Specifications as c on p.SpecId = c.SpecificationId 
                                inner join tblCategory as t on p.CatId = t.id 
                                inner join Type as f on p.TypId = f.typeId where sdate between '" & sdate1 & "' and '" & sdate2 & "' order by ItemName,category", con)
        dr = cmd.ExecuteReader
        While dr.Read()
            i += 1
            DataGridView4.Rows.Add(i, dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString, dr.Item(3).ToString, dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(6).ToString)
        End While
        dr.Close()
        con.Close()

        lblSoldItemTracker.Text = "Total Checkouts So Far : " & GetDataSales("select isnull(count(pid),0) from Cart where sdate between '" & sdate1 & "' and '" & sdate2 & "'") _
            & Space(10) & "Total Quantity Sold : " & GetDataSales("select isnull(sum(qty),0) from Cart where sdate between '" & sdate1 & "' and '" & sdate2 & "'")

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        GetSoldItems()
    End Sub

    Private Sub cmbBest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBest.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnFastSelling_Click(sender As Object, e As EventArgs) Handles btnFastSelling.Click
        If IS_EMPTY(cmbBest) = True Then Return
        GetFastSellingProducts()
    End Sub

    Sub GetFastSellingProducts()
        Dim i As Integer = 0
        Dim sdate1 As String = DateFastSelling1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = DateFastSelling2.Value.ToString("yyyy-MM-dd")
        DataGridView5.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select ca.pid, b.ItemName,g.IngredientName,c.SpecificationName,t.category,f.typeName,ca.qty
                                from Cart as ca inner join Products as p on ca.pid = p.pid 
                                inner join Items as b on p.ItmId = b.ItemId 
                                inner join Ingredients as g on p.IngId = g.IngredientId 
                                inner join Specifications as c on p.SpecId = c.SpecificationId 
                                inner join tblCategory as t on p.CatId = t.id 
                                inner join Type as f on p.TypId = f.typeId where sdate between '" & sdate1 & "' and '" & sdate2 & "' order by qty desc", con)
        dr = cmd.ExecuteReader
        While dr.Read()
            i += 1
            DataGridView5.Rows.Add(i, dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString, dr.Item(3).ToString, dr.Item(4).ToString, dr.Item(5).ToString, dr.Item(6).ToString)
        End While
        dr.Close()
        con.Close()

        lblFastTrack.Text = "Total Fast Selling Products by Date : " & DataGridView5.RowCount

    End Sub
End Class