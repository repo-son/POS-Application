Imports System.Data.SqlClient
Imports System.Data
Public Class ProductsList
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Product
            .btnAdd.Enabled = True
            .btnEdit.Enabled = False
            .ShowDialog()
        End With
    End Sub
    Sub LoadDatabase()
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId ", con)
        dr = cmd.ExecuteReader()
        While dr.Read
            i += 1
            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("productcode").ToString, dr.Item("ItemName").ToString, dr.Item("IngredientName").ToString, dr.Item("SpecificationName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("BsQty").ToString, dr.Item("price").ToString, dr.Item("Qty").ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column4" Then
            With Product
                .lblID.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                .txtProductCode.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                .txtItemName.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                .txtIngredientName.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                .txtSpecification.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                .txtCategory.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                .txtItemType.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                .txtBaselineQty.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                .txtPrice.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                .txtQty.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
                .btnAdd.Enabled = False
                .btnEdit.Enabled = True
                .txtQty.Enabled = False
                .ShowDialog()
            End With
        ElseIf colName = "Column5" Then
            If MsgBox("Do you want to Delete Data from Database?", vbYesNo + vbCritical) = vbYes Then
                con.Open()
                cmd = New SqlCommand("delete from Products where pid like '" & DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "' ", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Data Successfully Deleted from Database", vbInformation)
                LoadDatabase()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If DataGridView1.Columns(e.ColumnIndex).Name = "Column4" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.edit_20px, CInt((e.CellBounds.Width / 2) - (My.Resources.edit_20px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.edit_20px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        ElseIf DataGridView1.Columns(e.ColumnIndex).Name = "Column5" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.remove_24px, CInt((e.CellBounds.Width / 2) - (My.Resources.remove_24px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.remove_24px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Stock
            .LoadProducts()
            .ShowDialog()
        End With
    End Sub

    Private Sub ProductsList_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblCount.Text = "Total Products : " & DataGridView1.Rows.Count
    End Sub
End Class