Imports System.Data.SqlClient
Imports System.Data
Public Class AddNewCategory
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtCategory.Clear()
        txtCategory.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (txtCategory.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Category to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCategory.Focus()
            Else
                reloadText("Select * from tblCategory where category = '" + txtCategory.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Category Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCategory.Clear()
                    txtCategory.Focus()
                Else
                    If (MsgBox("Save Category to Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("insert into tblCategory (category) values ('" + txtCategory.Text + "')", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved to the Database", vbInformation)
                        With Category
                            .LoadData()
                        End With
                        LoadData()
                        txtCategory.Clear()
                        txtCategory.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub

    Private Sub AddNewCategory_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtCategory.Focus()
        Connection()
        LoadData()

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

    Private Sub LoadData()
        con.Open()
        cmd = New SqlCommand("select count(*) from tblCategory", con)
        cmd.ExecuteNonQuery()
        Label4.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If (txtCategory.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Category to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCategory.Focus()
            Else
                reloadText("Select * from tblCategory where category = '" + txtCategory.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Category Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If (MsgBox("Update Category In Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("Update tblCategory set category ='" + txtCategory.Text + "' where id like '" + Label6.Text + "' ", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Category Updated Successfully", vbInformation)
                        With Category
                            .LoadData()
                        End With
                        LoadData()
                        txtCategory.Clear()
                        txtCategory.Focus()
                        Me.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub

    Private Sub AddNewCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
End Class