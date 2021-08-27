Imports System.Data.SqlClient
Public Class ProductInquiry
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If DataGridView1.Columns(e.ColumnIndex).Name = "colCart" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.Sales36, CInt((e.CellBounds.Width / 2) - (My.Resources.Sales36.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.Sales36.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Sub LoadDatabase()
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId 
                                inner join Specifications as c on p.SpecId = c.SpecificationId 
                                inner join Ingredients as f  on p.IngId = f.IngredientId 
                                inner join tblCategory as g on p.CatId = g.id 
                                inner join Type as t on p.TypId = t.typeId where Qty <> 0 and (ItemName like '" & txtSearchMe.Text & "%' OR IngredientName like '" & txtSearchMe.Text & "%')", con)
        dr = cmd.ExecuteReader()
        While dr.Read
            i += 1
            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("productcode").ToString, dr.Item("ItemName").ToString, dr.Item("IngredientName").ToString, dr.Item("SpecificationName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("BsQty").ToString, dr.Item("price").ToString, dr.Item("Qty").ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub txtSearchMe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchMe.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                LoadDatabase()
        End Select
    End Sub

    Private Sub txtSearchMe_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMe.TextChanged
        LoadDatabase()
    End Sub

    Private Sub ProductInquiry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
    End Sub

    Private Sub ProductInquiry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case (e.KeyCode)
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "colCart" Then
            SearchProduct(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString)
            With Sales
                .LoadCart()
            End With
        End If
    End Sub

    Sub SearchProduct(ByVal psearch As String)
        Try

            If psearch = String.Empty Then Return
            con.Open()
            cmd = New SqlCommand("select * from Products where CatId like '" & psearch & "'", con)
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

End Class