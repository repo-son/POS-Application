Imports System.Data.SqlClient
Public Class Discount
    Private Sub Discount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub Discount_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub cmbDiscTitle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDiscTitle.KeyPress
        e.Handled = True
    End Sub

    Sub GetDiscount()
        cmbDiscTitle.Items.Clear()
        con.Open()
        cmd = New SqlCommand("select * from Discount", con)
        dr = cmd.ExecuteReader
        While dr.Read()
            cmbDiscTitle.Items.Add(dr.Item(1).ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub cmbDiscTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscTitle.SelectedIndexChanged
        con.Open()
        cmd = New SqlCommand("select * from Discount where info like '" & cmbDiscTitle.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then txtDisc.Text = dr.Item(2).ToString Else txtDisc.Text = 0
        dr.Close()
        con.Close()
    End Sub

    Private Sub btnAddDiscount_Click(sender As Object, e As EventArgs) Handles btnAddDiscount.Click
        If IS_EMPTY(cmbDiscTitle) = True Then Return
        With Sales
            Dim discount As Double
            discount = CDbl(.lblTotal.Text) * CDbl(txtDisc.Text)
            .lblDiscount.Text = Format(discount, "#,##0.00")
            .LoadCart()
            Me.Dispose()
        End With
    End Sub
End Class