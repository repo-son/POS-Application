Imports System.Data.SqlClient
Imports System.Data
Public Class AddNewIngredient
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub AddNewIngredient_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtIngredient.Focus()
        Connection()
        LoadData()
    End Sub
    Private Sub LoadData()
        con.Open()
        cmd = New SqlCommand("select count(*) from Ingredients", con)
        cmd.ExecuteNonQuery()
        Label4.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (txtIngredient.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Ingredient to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIngredient.Focus()
            Else
                reloadText("Select * from Ingredients where IngredientName = '" + txtIngredient.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Ingredient Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtIngredient.Clear()
                    txtIngredient.Focus()
                Else
                    If (MsgBox("Save Ingredient to Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("insert into Ingredients (IngredientName) values ('" + txtIngredient.Text + "')", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved to the Database", vbInformation)
                        With IngredientList
                            .LoadData()
                        End With
                        LoadData()
                        txtIngredient.Clear()
                        txtIngredient.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub
    Private Sub reloadText(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            dt = New DataTable
            daa = New SqlDataAdapter(sql, con)
            daa.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message & "reloadText")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
                daa.Dispose()
            End If
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If (txtIngredient.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Ingredient to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIngredient.Focus()
            Else
                reloadText("Select * from Ingredients where IngredientName = '" + txtIngredient.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Ingredient Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If (MsgBox("Update Ingredient In Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("Update Ingredients set IngredientName ='" + txtIngredient.Text + "' where IngredientID like '" + Label6.Text + "' ", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Ingredient Updated Successfully", vbInformation)
                        With IngredientList
                            .LoadData()
                        End With
                        LoadData()
                        txtIngredient.Clear()
                        txtIngredient.Focus()
                        Me.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtIngredient.Clear()
        txtIngredient.Focus()
    End Sub

    Private Sub AddNewIngredient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
End Class