Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class StockManage
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Sub LoadProducts1()
        Try
            If txtCombo.Text = String.Empty Then Return
            If txtSearch.Text = String.Empty Then Return
            Dim i As Integer = 0
            DataGridView2.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Ingredients as f on p.IngId = f.IngredientId inner join Specifications as c  on p.SpecId = c.SpecificationId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where " & txtCombo.Text & " like '" & txtSearch.Text & "%'", con)
            dr = cmd.ExecuteReader()
            While dr.Read()
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("pid").ToString, dr.Item("ItemName").ToString + Space(2) + "|" + Space(2) + dr.Item("IngredientName").ToString + Space(2) + "|" + Space(2) + dr.Item("SpecificationName").ToString + Space(2) + "|" + Space(2) + dr.Item("category").ToString + Space(2) + "|" + Space(2) + dr.Item("typeName").ToString)
            End While
            dr.Close()
            con.Close()
        Catch ex As InvalidCastException
        End Try
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        'Select Case Asc(e.KeyChar)
        '    Case 13
        '        If IS_EMPTY(txtCombo) = True Then Return
        '        If IS_EMPTY(txtSearch) = True Then Return
        'End Select
    End Sub

    Private Sub DataGridView2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
        If DataGridView2.Columns(e.ColumnIndex).Name = "Column4" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.forward_20px, CInt((e.CellBounds.Width / 2) - (My.Resources.forward_20px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.forward_20px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadProducts1()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim colName As String = DataGridView2.Columns(e.ColumnIndex).Name
        If colName = "Column4" Then
            con.Open()
            cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Ingredients as f on p.IngId = f.IngredientId inner join Specifications as c  on p.SpecId = c.SpecificationId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where pid like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", con)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                txtPID.Text = dr.Item("pid").ToString
                txtItemName.Text = dr.Item("ItemName").ToString
                txtIngID.Text = dr.Item("IngredientName").ToString
                txtSpeciId.Text = dr.Item("SpecificationName").ToString
                txtCategory.Text = dr.Item("category").ToString
                txtType.Text = dr.Item("typeName").ToString
                txtQuantityLeft.Text = dr.Item("Qty").ToString
            End If
            con.Close()
        End If
    End Sub

    Sub Clear()
        txtPID.Clear()
        txtItemName.Clear()
        txtIngID.Clear()
        txtSpeciId.Clear()
        txtCategory.Clear()
        txtType.Clear()
        txtQuantityLeft.Clear()
        txtAdjustingQuantity.Clear()
        MetroTextBox1.Clear()
        txtSearch.Clear()
        DataGridView2.Rows.Clear()

    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        Clear()
    End Sub

    Private Sub StockManage_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtManagedBy.Text = strUser
        MetroTabControl1.SelectedIndex = 0
    End Sub

    Private Sub txtAdjustingQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdjustingQuantity.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If IS_EMPTY(txtAdjustingQuantity) Then Return
            If rdAdd.Checked = False And rdRemove.Checked = False Then
                MsgBox("Please Choose the Manage Type", vbExclamation)
                Return
            End If
            If IS_EMPTY(MetroTextBox1) = True Then Return
            If MsgBox("Please Confirm Managing this Field", vbYesNo + vbQuestion) = vbYes Then
                If rdAdd.Checked = True Then
                    con.Open()
                    cmd = New SqlCommand("update Products set Qty = (Qty + " & CInt(txtAdjustingQuantity.Text) & ") where pid like '" & txtPID.Text & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf rdRemove.Checked = True Then
                    If CInt(txtQuantityLeft.Text) < CInt(txtAdjustingQuantity.Text) Then
                        MsgBox("Unable to Proceed, Available Stock " & txtQuantityLeft.Text & ".", vbExclamation)
                        Return
                    Else
                        con.Open()
                        cmd = New SqlCommand("update Products set Qty = (Qty - " & CInt(txtAdjustingQuantity.Text) & ") where pid like '" & txtPID.Text & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                End If

                Dim tes As String = ""
                If rdAdd.Checked = True Then tes = rdAdd.Text
                If rdRemove.Checked = True Then tes = rdRemove.Text
                Dim sdate As String = Now.ToString("yyyy-MM-dd")
                con.Open()
                cmd = New SqlCommand("insert into StockManage (pid,qty,stype,reason,ManagedBy,sdate) values (@pid,@qty,@stype,@reason,@ManagedBy,@sdate)", con)
                With cmd
                    .Parameters.AddWithValue("@pid", txtPID.Text)
                    .Parameters.AddWithValue("@qty", CInt(txtAdjustingQuantity.Text))
                    .Parameters.AddWithValue("@stype", tes)
                    .Parameters.AddWithValue("@reason", MetroTextBox1.Text)
                    .Parameters.AddWithValue("@ManagedBy", txtManagedBy.Text)
                    .Parameters.AddWithValue("@sdate", sdate)
                    .ExecuteNonQuery()
                End With
                con.Close()
                MsgBox("Stock Managed Successfully", vbInformation)
                Clear()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub LoadStockHistory1()
        Try
            Dim i As Integer = 0
            DataGridView3.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("select * from StockManage as s inner join Products as p on s.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where sDate between '" & CDate(MetroDateTime1.Value.ToString) & "' and '" & CDate(MetroDateTime2.Value.ToString) & "'", con)
            dr = cmd.ExecuteReader()
            While dr.Read
                i += 1
                DataGridView3.Rows.Add(i, dr.Item("pid").ToString, dr.Item("ItemName").ToString, dr.Item("SpecificationName").ToString, dr.Item("IngredientName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("qty").ToString, dr.Item("stype").ToString, dr.Item("reason").ToString, dr.Item("ManagedBy"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Please Reload Page and Try Again")

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadStockHistory1()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.FormBorderStyle = FormBorderStyle.FixedSingle
        PrintPreviewDialog1.ControlBox = False
        PrintPreviewDialog1.MinimumSize = New System.Drawing.Size(1000, 800)
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterParent
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebmp As New Bitmap(Me.DataGridView3.Width, Me.DataGridView3.Height)
        DataGridView3.DrawToBitmap(imagebmp, New Rectangle(0, 0, Me.DataGridView3.Width, Me.DataGridView3.Height))
        e.Graphics.DrawImage(imagebmp, 25, 100)

    End Sub
End Class