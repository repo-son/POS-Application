Imports System.Data.SqlClient
Public Class Product
    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItem()
        LoadIngredient()
        LoadSpecification()
        LoadCategory()
        LoadItemType()
        txtProductCode.Focus()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub
    Public Sub LoadItem()
        Try
            con.Open()
            cmd = New SqlCommand("select * from Items order by ItemName", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "ItemName")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("ItemName").ToString)
            Next
            con.Close()
            txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtItemName.AutoCompleteCustomSource = col
            txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest
            cmd = Nothing
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

    End Sub
    Public Sub LoadIngredient()
        Try
            con.Open()
            cmd = New SqlCommand("select * from Ingredients order by IngredientName", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "IngredientName")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("IngredientName").ToString)
            Next
            txtIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtIngredientName.AutoCompleteCustomSource = col
            txtIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest
            cmd = Nothing
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
            con.Close()
        End If
        End Try
    End Sub
    Public Sub LoadSpecification()
        Try
            con.Open()
            cmd = New SqlCommand("select * from Specifications order by SpecificationName", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "SpecificationName")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("SpecificationName").ToString)
            Next
            txtSpecification.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSpecification.AutoCompleteCustomSource = col
            txtSpecification.AutoCompleteMode = AutoCompleteMode.Suggest
            cmd = Nothing
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Public Sub LoadCategory()
        Try
            con.Open()
            cmd = New SqlCommand("select * from tblCategory order by category", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "category")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("category").ToString)
            Next
            txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtCategory.AutoCompleteCustomSource = col
            txtCategory.AutoCompleteMode = AutoCompleteMode.Suggest
            cmd = Nothing
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Public Sub LoadItemType()
        Try
            con.Open()
            cmd = New SqlCommand("select * from Type order by typeName", con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "typeName")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("typeName").ToString)
            Next
            txtItemType.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtItemType.AutoCompleteCustomSource = col
            txtItemType.AutoCompleteMode = AutoCompleteMode.Suggest
            cmd = Nothing
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        con.Open()
        cmd = New SqlCommand("select * from Items where ItemName like @ItemName", con)
        cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then lblItemName.Text = dr.Item(0).ToString Else lblItemName.Text = String.Empty
        cmd = Nothing
        dr.Close()
        con.Close()
    End Sub

    Private Sub txtIngredientName_TextChanged(sender As Object, e As EventArgs) Handles txtIngredientName.TextChanged
        con.Open()
        cmd = New SqlCommand("select * from Ingredients where IngredientName like @IngredientName", con)
        cmd.Parameters.AddWithValue("@IngredientName", txtIngredientName.Text)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then lblIngredientName.Text = dr.Item(0).ToString Else lblIngredientName.Text = String.Empty
        cmd = Nothing
        dr.Close()
        con.Close()
    End Sub

    Private Sub txtSpecification_TextChanged(sender As Object, e As EventArgs) Handles txtSpecification.TextChanged
        con.Open()
        cmd = New SqlCommand("select * from Specifications where SpecificationName like @SpecificationName", con)
        cmd.Parameters.AddWithValue("@SpecificationName", txtSpecification.Text)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then lblSpecification.Text = dr.Item(0).ToString Else lblSpecification.Text = String.Empty
        cmd = Nothing
        dr.Close()
        con.Close()
    End Sub

    Private Sub txtCategory_TextChanged(sender As Object, e As EventArgs) Handles txtCategory.TextChanged
        con.Open()
        cmd = New SqlCommand("select * from tblCategory where category like @category", con)
        cmd.Parameters.AddWithValue("@category", txtCategory.Text)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then lblCategory.Text = dr.Item(0).ToString Else lblCategory.Text = String.Empty
        cmd = Nothing
        dr.Close()
        con.Close()
    End Sub
    Private Sub txtItemType_TextChanged(sender As Object, e As EventArgs) Handles txtItemType.TextChanged
        con.Open()
        cmd = New SqlCommand("select * from Type where typeName like @typeName", con)
        cmd.Parameters.AddWithValue("@typeName", txtItemType.Text)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then lblItemType.Text = dr.Item(0).ToString Else lblItemType.Text = String.Empty
        cmd = Nothing
        dr.Close()
        con.Close()
    End Sub
    Sub Clear()
        txtItemName.Clear()
        txtProductCode.Clear()
        txtIngredientName.Clear()
        txtSpecification.Clear()
        txtCategory.Clear()
        txtItemType.Clear()
        txtBaselineQty.Clear()
        txtQty.Clear()
        txtPrice.Clear()
        btnAdd.Enabled = True
        btnEdit.Enabled = False
        txtProductCode.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If IS_EMPTY(txtProductCode) = True Then Return
            If IS_EMPTY(lblItemName, txtItemName) = True Then Return
            If IS_EMPTY(lblIngredientName, txtIngredientName) = True Then Return
            If IS_EMPTY(lblSpecification, txtSpecification) = True Then Return
            If IS_EMPTY(lblCategory, txtCategory) = True Then Return
            If IS_EMPTY(lblItemType, txtItemType) = True Then Return
            If IS_EMPTY(txtBaselineQty) = True Then Return
            If IS_EMPTY(txtPrice) = True Then Return
            If IS_EMPTY(txtQty) = True Then Return

            If ValidationDuplicate("select * from Products where productcode like '" & txtProductCode.Text & "'") = True Then Return
            If ValidationDuplicate("select ItmId from Products where productcode like '" & txtProductCode.Text & "'") = True Then Return

            con.Open()
            cmd = New SqlCommand("insert into Products (productcode,ItmId,IngId,SpecId,CatId,TypId,BsQty,Qty,price) values (@productcode,@ItmId,@IngId,@SpecId,@CatId,@TypId,@BsQty,@Qty,@price)", con)
            With cmd
                .Parameters.AddWithValue("@productcode", txtProductCode.Text)
                .Parameters.AddWithValue("@ItmId", CInt(lblItemName.Text))
                .Parameters.AddWithValue("@IngId", CInt(lblIngredientName.Text))
                .Parameters.AddWithValue("@SpecId", CInt(lblSpecification.Text))
                .Parameters.AddWithValue("@CatId", CInt(lblCategory.Text))
                .Parameters.AddWithValue("@TypId", CInt(lblItemType.Text))
                .Parameters.AddWithValue("@BsQty", CInt(txtBaselineQty.Text))
                .Parameters.AddWithValue("@Qty", CInt(txtQty.Text))
                .Parameters.AddWithValue("@price", CDbl(txtPrice.Text))
                .ExecuteNonQuery()
            End With
            MsgBox("Data Successfully Saved to the Database", vbInformation)
            con.Close()
            Clear()
            With ProductsList
                .LoadDatabase()
            End With
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If IS_EMPTY(txtProductCode) = True Then Return
            If IS_EMPTY(lblItemName, txtItemName) = True Then Return
            If IS_EMPTY(lblIngredientName, txtIngredientName) = True Then Return
            If IS_EMPTY(lblSpecification, txtSpecification) = True Then Return
            If IS_EMPTY(lblCategory, txtCategory) = True Then Return
            If IS_EMPTY(lblItemType, txtItemType) = True Then Return
            If IS_EMPTY(txtBaselineQty) = True Then Return
            If IS_EMPTY(txtPrice) = True Then Return
            If IS_EMPTY(txtQty) = True Then Return
            If MsgBox("Do you want to Update Data to the Database?", vbYesNo, vbQuestion) = vbYes Then


                con.Open()
                cmd = New SqlCommand("Update Products set productcode = @productcode,ItmId = @ItmId,IngId = @IngId,SpecId = @SpecId,CatId = @CatId,TypId=@TypId,BsQty=@BsQty,Qty=@Qty,price=@price where pid like @pid", con)
                With cmd
                    .Parameters.AddWithValue("@productcode", txtProductCode.Text)
                    .Parameters.AddWithValue("@ItmId", CInt(lblItemName.Text))
                    .Parameters.AddWithValue("@IngId", CInt(lblIngredientName.Text))
                    .Parameters.AddWithValue("@SpecId", CInt(lblSpecification.Text))
                    .Parameters.AddWithValue("@CatId", CInt(lblCategory.Text))
                    .Parameters.AddWithValue("@TypId", CInt(lblItemType.Text))
                    .Parameters.AddWithValue("@BsQty", CInt(txtBaselineQty.Text))
                    .Parameters.AddWithValue("@Qty", CInt(txtQty.Text))
                    .Parameters.AddWithValue("@price", CDbl(txtPrice.Text))
                    .Parameters.AddWithValue("@pid", CInt(lblID.Text))
                    .ExecuteNonQuery()
                End With
                MsgBox("Data Successfully Updated", vbInformation)
                con.Close()
                Clear()
                With ProductsList
                    .LoadDatabase()
                End With
                Me.Dispose()
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtBaselineQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBaselineQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57

            Case Else
                e.Handled = True
        End Select
    End Sub
End Class