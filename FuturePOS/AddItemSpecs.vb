Imports System.Data.SqlClient
Imports System.Data
Public Class AddItemSpecs
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub AddItemSpecs_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtSpecs.Focus()
        Connection()
        LoadData()
    End Sub
    Private Sub LoadData()
        con.Open()
        cmd = New SqlCommand("select count(*) from Specifications", con)
        cmd.ExecuteNonQuery()
        Label4.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (txtSpecs.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Specification to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSpecs.Focus()
            Else
                reloadText("Select * from Specifications where SpecificationName = '" + txtSpecs.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Specification Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSpecs.Clear()
                    txtSpecs.Focus()
                Else
                    If (MsgBox("Save Specification to Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("insert into Specifications (SpecificationName) values ('" + txtSpecs.Text + "')", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved to the Database", vbInformation)
                        With ItemSpecsList
                            .LoadData()
                        End With
                        LoadData()
                        txtSpecs.Clear()
                        txtSpecs.Focus()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtSpecs.Clear()
        txtSpecs.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If (txtSpecs.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Specification to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSpecs.Focus()
            Else
                reloadText("Select * from Specifications where SpecificationName = '" + txtSpecs.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Specification Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If (MsgBox("Update Specification In Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("Update Specifications set SpecificationName ='" + txtSpecs.Text + "' where SpecificationId like '" + Label6.Text + "' ", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Specification Updated Successfully", vbInformation)
                        With ItemList
                            .LoadData()
                        End With
                        LoadData()
                        txtSpecs.Clear()
                        txtSpecs.Focus()
                        Me.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
            MsgBox("Something Went Wrong", vbCritical)
        End Try
    End Sub

    Private Sub AddItemSpecs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
End Class