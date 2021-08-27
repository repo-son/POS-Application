Imports System.Data.SqlClient
Imports System.Data
Public Class Items
    Private Sub Items_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtItem.Focus()
        Connection()
        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (txtItem.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Item to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtItem.Focus()
            Else
                reloadText("Select * from Items where ItemName = '" + txtItem.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Item Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtItem.Clear()
                    txtItem.Focus()
                Else
                    If (MsgBox("Save Item to Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("insert into Items (ItemName) values ('" + txtItem.Text + "')", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved to the Database", vbInformation)
                        With ItemList
                            .LoadData()
                        End With
                        LoadData()
                        txtItem.Clear()
                        txtItem.Focus()
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
            If (txtItem.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Items to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtItem.Focus()
            Else
                reloadText("Select * from Items where ItemName = '" + txtItem.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Item Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If (MsgBox("Update Item In Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("Update Items set ItemName ='" + txtItem.Text + "' where ItemId like '" + Label6.Text + "' ", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Item Updated Successfully", vbInformation)
                        With ItemList
                            .LoadData()
                        End With
                        LoadData()
                        txtItem.Clear()
                        txtItem.Focus()
                        Me.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub

    Private Sub LoadData()
        con.Open()
        cmd = New SqlCommand("select count(*) from Items", con)
        cmd.ExecuteNonQuery()
        Label4.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtItem.Clear()
        txtItem.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()

    End Sub

    Private Sub Items_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
End Class