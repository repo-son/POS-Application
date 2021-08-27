﻿Imports System.Data.SqlClient
Imports System.Data
Public Class ItemSpecsList
    Dim SpecId, SpecName As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With AddItemSpecs
            .txtSpecs.Clear()
            .txtSpecs.Focus()
            .btnAdd.Show()
            .btnEdit.Enabled = False
            .Label6.Hide()
            .Label5.Hide()
            .ShowDialog()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub
    Public Sub LoadData()
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("Select * from Specifications", con)
        dr = cmd.ExecuteReader
        While dr.Read
            i += 1
            DataGridView1.Rows.Add(dr.Item("SpecificationId").ToString, i, dr.Item("SpecificationName").ToString, "", "")

        End While
        dr.Close()
        con.Close()
        lblCount.Text = "Specifications Count :" & DataGridView1.Rows.Count & ""
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column4" Then
            With AddItemSpecs
                .Label6.Show()
                .Label5.Show()
                .txtSpecs.Focus()
                .Label6.Text = SpecId
                .txtSpecs.Text = SpecName
                .btnAdd.Enabled = False
                .btnEdit.Show()
                .ShowDialog()
                LoadData()
            End With
        ElseIf colName = "Column5" Then
            If (MsgBox("Do you want to Delete Specification from DataBase", vbYesNo) = vbYes) Then
                con.Open()
                cmd = New SqlCommand("delete from Specifications where SpecificationId like '" + SpecId + "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Specification Deleted", vbInformation)
                LoadData()
            End If
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer = DataGridView1.CurrentRow.Index
        SpecId = DataGridView1.Item(0, i).Value
        SpecName = DataGridView1.Item(2, i).Value
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

    Private Sub ItemSpecsList_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolTip1.SetToolTip(Button4, "Close")
        ToolTip2.SetToolTip(Button1, "Add Specification")
        LoadData()
    End Sub
End Class