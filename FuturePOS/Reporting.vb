Imports System.Data.SqlClient
Public Class Reporting

    Private Sub Reporting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroTabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub MetroTabControl1_Click(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        LoadSales2()
    End Sub

    Sub LoadSales1()
        Dim sdate1 As String = MetroDateTime1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = MetroDateTime2.Value.ToString("yyyy-MM-dd")
        DataGridView1.Rows.Clear()
        Dim i As Integer = 0
        con.Open()
        cmd = New SqlCommand("select * from Cart as ca inner join Products as p on ca.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where sdate between '" & sdate1 & "' and '" & sdate2 & "' and status like 'Sold' order by invoice,ItemName", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            i += 1
            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("invoice").ToString, dr.Item("ItemName").ToString, dr.Item("SpecificationName").ToString, dr.Item("IngredientName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("price").ToString, dr.Item("qty").ToString, dr.Item("total").ToString)
        End While
        dr.Close()
        con.Close()

        lblTot2.Text = Format(GetData("select isnull(sum(total),0) from Cart where sdate between '" & sdate1 & "' and '" & sdate2 & "' and status like 'Sold'"), "#,##0.00")
        DataGridView1.Rows.Add("", "", "", "", "", "", "", "", "", "Total", lblTot2.Text)
    End Sub

    Function GetData(ByVal sql As String) As Double
        con.Open()
        cmd = New SqlCommand(sql, con)
        GetData = CDbl(cmd.ExecuteScalar)

        con.Close()
        Return GetData
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadSales1()
    End Sub

    Sub LoadSales2()
        Dim sdate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        DataGridView2.Rows.Clear()
        Dim i As Integer = 0
        con.Open()
        cmd = New SqlCommand("select * from Cart as ca inner join Products as p on ca.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where sdate between '" & sdate & "' and '" & sdate & "' and status like 'Sold' order by invoice,ItemName", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("invoice").ToString, dr.Item("ItemName").ToString, dr.Item("SpecificationName").ToString, dr.Item("IngredientName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("price").ToString, dr.Item("qty").ToString, dr.Item("total").ToString)
        End While
        dr.Close()
        con.Close()

        lblTot2.Text = Format(GetData("select isnull(sum(total),0) from Cart where sdate between '" & sdate & "' and '" & sdate & "' and status like 'Sold'"), "#,##0.00")
        lblDisc.Text = Format(GetData("select isnull(sum(discount),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "' "), "#,##0.00")
        lblSub.Text = Format(GetData("select isnull(sum(subtotal),0) from Payment where sdate between '" & sdate & "'and '" & sdate & "' "), "#,##0.00")
        lblMBSpecial.Text = Format(GetData("select isnull(sum(vat),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "'"), "#,##0.00")
        lblTotSales.Text = Format(GetData("select isnull(sum(amountdue),0) from Payment where sdate between '" & sdate & "' and '" & sdate & "'"), "#,##0.00")
        lblTotal.Text = "Total Daily Sales : " & lblTotSales.Text
        DataGridView2.Rows.Add("", "", "", "", "", "", "", "", "", "Total", lblTot2.Text)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        LoadSales2()
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

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim imagebmp As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(imagebmp, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(imagebmp, 75, 100)

    End Sub
End Class




