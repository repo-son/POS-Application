Imports System.Data.SqlClient
Public Class Maintainance
    Dim _id As String
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub MetroTabControl1_Click(sender As Object, e As EventArgs) Handles MetroTabControl1.Click
        If MetroTabControl1.SelectedIndex = 3 Then
            With Category
                .TopLevel = False
                Panel5.Controls.Add(Category)
                .BringToFront()
                .LoadData()
                .Show()
            End With
        ElseIf MetroTabControl1.SelectedIndex = 0 Then
            With ItemList
                .TopLevel = False
                Panel2.Controls.Add(ItemList)
                .BringToFront()
                .LoadData()
                .Show()
            End With
        ElseIf MetroTabControl1.SelectedIndex = 1 Then
            With IngredientList
                .TopLevel = False
                Panel3.Controls.Add(IngredientList)
                .BringToFront()
                .LoadData()
                .Show()
            End With
        ElseIf MetroTabControl1.SelectedIndex = 4 Then
            With ItemTypeList
                .TopLevel = False
                Panel6.Controls.Add(ItemTypeList)
                .BringToFront()
                .LoadData()
                .Show()
            End With
        ElseIf MetroTabControl1.SelectedIndex = 2 Then
            With ItemSpecsList
                .TopLevel = False
                Panel4.Controls.Add(ItemSpecsList)
                .BringToFront()
                .LoadData()
                .Show()
            End With
        End If
    End Sub

    Private Sub Maintainance_Load(sender As Object, e As EventArgs) Handles Me.Load
        MetroTabControl1.SelectedIndex = 0
        With ItemList
            .TopLevel = False
            Panel2.Controls.Add(ItemList)
            .BringToFront()
            .LoadData()
            .Show()
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            con.Open()
            cmd = New SqlCommand("select count(*) from Vat", con)
            Dim icount As Integer = CInt(cmd.ExecuteScalar)
            con.Close()

            If icount > 0 Then
                con.Open()
                cmd = New SqlCommand("update Vat set vat = '" & CDbl(txtVat.Text) & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()

            Else
                con.Open()
                cmd = New SqlCommand("insert into Vat (vat) values ('" & CDbl(txtVat.Text) & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            MsgBox("VAT Added to the FuturePOS", vbInformation)
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtVat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVat.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub
    Private Sub txtDiscountRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscountRate.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnAddDiscount_Click(sender As Object, e As EventArgs) Handles btnAddDiscount.Click
        Try
            If IS_EMPTY(txtDiscTitle) = True Then Return
            If IS_EMPTY(txtDiscountRate) = True Then Return

            If ValidationDuplicate("Select * from Discount where info like '" & txtDiscTitle.Text & "'") = True Then Return

            con.Open()
            cmd = New SqlCommand("insert into Discount (info,discount) values (@info,@discount)", con)
            With cmd
                .Parameters.AddWithValue("@info", txtDiscTitle.Text)
                .Parameters.AddWithValue("@discount", txtDiscountRate.Text)
                .ExecuteNonQuery()
            End With
            con.Close()
            MsgBox("Discount Successfully Added to the FuturePOS", vbInformation)
            LoadDiscounts()
            ClearDisc()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub LoadDiscounts()
        Dim i As Integer = 0
        DataGridView2.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Discount", con)
        dr = cmd.ExecuteReader
        While dr.Read()
            i += 1
            DataGridView2.Rows.Add(i, dr.Item(0).ToString, dr.Item(1).ToString, dr.Item(2).ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Sub ClearDisc()
        txtDiscTitle.Clear()
        txtDiscountRate.Clear()
        btnAddDiscount.Enabled = True
        Button1.Enabled = False
        txtDiscTitle.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearDisc()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim colName As String = DataGridView2.Columns(e.ColumnIndex).Name
        If colName = "edit" Then
            _id = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
            txtDiscTitle.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
            txtDiscountRate.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
            btnAddDiscount.Enabled = False
            Button1.Enabled = True
        ElseIf colName = "delete" Then
            If MsgBox("Removing Discount Tab, Please Confirm", vbYesNo + vbQuestion) = vbYes Then
                con.Open()
                cmd = New SqlCommand("delete from Discount where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Discount Tab Deleted Successfully", vbInformation)
                LoadDiscounts()
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If IS_EMPTY(txtDiscTitle) = True Then Return
            If IS_EMPTY(txtDiscountRate) = True Then Return
            con.Open()
            cmd = New SqlCommand("update Discount set info = @info , discount = @discount where id like @id", con)
            With cmd
                .Parameters.AddWithValue("@info", txtDiscTitle.Text)
                .Parameters.AddWithValue("@discount", CDbl(txtDiscountRate.Text))
                .Parameters.AddWithValue("@id", _id)
                .ExecuteNonQuery()
            End With
            con.Close()
            MsgBox("Discount Successfully Updated", vbInformation)
            LoadDiscounts()
            ClearDisc()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class