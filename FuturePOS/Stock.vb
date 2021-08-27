Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing.Printing

Public Class Stock
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub
    Sub LoadProducts()
        Try
            txtCheckedBy.Text = strUser
            If txtCombo.Text = String.Empty Then Return
            If txtSearch.Text = String.Empty Then Return
            Dim i As Integer = 0
            DataGridView2.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("select * from Products as p inner join Items as b on p.ItmId = b.ItemId inner join Ingredients as f on p.IngId = f.IngredientId inner join Specifications as c  on p.SpecId = c.SpecificationId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where " + txtCombo.Text + " like '" + txtSearch.Text + "%'", con)
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

    Private Sub DataGridView2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
        If DataGridView2.Columns(e.ColumnIndex).Name = "Column4" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.forward_20px, CInt((e.CellBounds.Width / 2) - (My.Resources.forward_20px.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.forward_20px.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCombo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCombo.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadProducts()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If IS_EMPTY(txtSerialNumber) = True Then Return
            If IS_EMPTY(txtCheckedBy) = True Then Return
            Dim colName As String = DataGridView2.Columns(e.ColumnIndex).Name
            Dim data As String = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
            Dim arr() As String = data.Split("|")
            If colName = "Column4" Then
                If MsgBox("Item Name :" & arr(0).ToString & vbCr &
                "Ingredient Name :" & arr(1).ToString & vbCr &
                "Specification Name :" & arr(2).ToString & vbCr &
                "Category Name :" & arr(3).ToString & vbCr &
                "Type Name :" & arr(4).ToString & vbCr & "   Please Confirm Details", vbYesNo + vbQuestion) = vbYes Then
                    DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString, arr(0).ToString, arr(1).ToString, arr(2).ToString, arr(3).ToString, arr(4).ToString)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(7).Value = String.Empty Then
                    MsgBox("Please Input Initial Quantity", vbExclamation)
                    Return
                End If
            Next
            Dim added_recode As Boolean = False
            For i As Integer = 0 To DataGridView1.Rows.Count - 1


                Dim found As Boolean = False
                con.Open()
                cmd = New SqlCommand("select * from Stock where SerialNumber like '" & txtSerialNumber.Text & "' and pid like '" & DataGridView1.Rows(i).Cells(1).Value.ToString & "' and sDate like '" & CDate(dDate.Value.ToString) & "'", con)
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    found = True
                Else
                    found = False
                End If
                dr.Close()
                con.Close()


                If found = False Then
                    con.Open()
                    cmd = Nothing
                    cmd = New SqlCommand("insert into Stock (SerialNumber,CheckedBy,pid,Qty,sDate) values  ('" & txtSerialNumber.Text & "','" & txtCheckedBy.Text & "','" & CInt(DataGridView1.Rows(i).Cells(1).Value.ToString()) & "','" & CInt(DataGridView1.Rows(i).Cells(7).Value.ToString()) & "','" & CDate(dDate.Value.ToString) & "') ", con)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    con.Open()
                    cmd = Nothing
                    cmd = New SqlCommand("update Products set Qty = Qty + " & CInt(DataGridView1.Rows(i).Cells(7).Value.ToString()) & " where pid like '" & DataGridView1.Rows(i).Cells(1).Value.ToString() & "'", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    added_recode = True
                End If
            Next
            If added_recode = True Then MsgBox("Stock Updated Successfully", vbInformation)

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        On Error Resume Next
        Dim stock As Double = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(7).Value.ToString <> String.Empty Then
                stock += CDbl(DataGridView1.Rows(i).Cells(7).Value.ToString)
            End If
        Next
        txtCount.Text = stock
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtSerialNumber.Clear()
        dDate.Value = Now
        DataGridView1.Rows.Clear()
        txtCount.Clear()
    End Sub
    Sub LoadStockHistory()
        'Dim sDate1 As String = MetroDateTime1.Value.ToString("yyyy-dd-MM")
        'Dim sDate2 As String = MetroDateTime2.Value.ToString("yyyy-dd-MM")
        Dim i As Integer = 0
        DataGridView3.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Stock as s inner join Products as p on s.pid = p.pid inner join Items as b on p.ItmId = b.ItemId inner join Specifications as c on p.SpecId = c.SpecificationId inner join Ingredients as f  on p.IngId = f.IngredientId inner join tblCategory as g on p.CatId = g.id inner join Type as t on p.TypId = t.typeId where sDate between '" & CDate(dDate.Value.ToString) & "' and '" & CDate(dDate.Value.ToString) & "' and SerialNumber like '" & cmbReference.Text & "'", con)
        dr = cmd.ExecuteReader()
        While dr.Read
            i += 1
            DataGridView3.Rows.Add(i, dr.Item("pid").ToString, dr.Item("SerialNumber").ToString, dr.Item("CheckedBy").ToString, dr.Item("ItemName").ToString, dr.Item("IngredientName").ToString, dr.Item("SpecificationName").ToString, dr.Item("category").ToString, dr.Item("typeName").ToString, dr.Item("Qty").ToString, Format(CDate(dr.Item("sDate").ToString), "yyyy/dd/MM"))
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IS_EMPTY(cmbReference) = True Then Return
        LoadStockHistory()
    End Sub

    Private Sub cmbReference_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbReference.KeyPress
        e.Handled = True
    End Sub
    Sub GetSerialNumber()
        Try
            cmbReference.Items.Clear()
            'Dim sdate1 As String = MetroDateTime1.Value.ToString("yyyy-dd-MM")
            'Dim sdate2 As String = MetroDateTime2.Value.ToString("yyyy-dd-MM")
            con.Open()
            cmd = New SqlCommand("select SerialNumber from Stock where sDate between '" & CDate(dDate.Value.ToString) & "' and '" & CDate(dDate.Value.ToString) & "'", con)
            dr = cmd.ExecuteReader
            While dr.Read()
                cmbReference.Items.Add(dr.Item("SerialNumber").ToString)
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub MetroDateTime1_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime1.ValueChanged
        GetSerialNumber()
    End Sub

    Private Sub MetroDateTime2_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime2.ValueChanged
        GetSerialNumber()
    End Sub

    Private Sub Stock_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolTip1.SetToolTip(Button4, "Close")
        MetroTabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With GrantAccess
            .ShowDialog()
        End With
        If cmbReference.SelectedItem = Nothing Then
            MsgBox("Please Select Reference Number First to Load Data And Print", vbInformation)
        Else
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.FormBorderStyle = FormBorderStyle.FixedSingle
            PrintPreviewDialog1.ControlBox = False
            PrintPreviewDialog1.MinimumSize = New System.Drawing.Size(1000, 800)
            PrintPreviewDialog1.StartPosition = FormStartPosition.CenterParent
            PrintPreviewDialog1.ShowDialog()
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim imagebmp As New Bitmap(Me.DataGridView3.Width, Me.DataGridView3.Height)
        DataGridView3.DrawToBitmap(imagebmp, New Rectangle(0, 0, Me.DataGridView3.Width, Me.DataGridView3.Height))
        e.Graphics.DrawImage(imagebmp, 7, 100)

    End Sub
End Class