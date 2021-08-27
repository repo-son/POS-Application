Imports System.Data.SqlClient
Imports System.Data
Public Class AddNewType
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub AddNewType_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtType.Focus()
        Connection()
        LoadData()
    End Sub
    Private Sub LoadData()
        con.Open()
        cmd = New SqlCommand("select count(*) from Type", con)
        cmd.ExecuteNonQuery()
        Label4.Text = cmd.ExecuteScalar().ToString()
        con.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If (txtType.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Type to Save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtType.Focus()
            Else
                reloadText("Select * from Type where typeName = '" + txtType.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Type Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtType.Clear()
                    txtType.Focus()
                Else
                    If (MsgBox("Save Type to Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("insert into Type (typeName) values ('" + txtType.Text + "')", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Saved to the Database", vbInformation)
                        With ItemTypeList
                            .LoadData()
                        End With
                        LoadData()
                        txtType.Clear()
                        txtType.Focus()
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
            If (txtType.Text = "") Then
                MessageBox.Show("Fill the Field", "Please Enter Type to Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtType.Focus()
            Else
                reloadText("Select * from Type where typeName = '" + txtType.Text + "'")
                If (dt.Rows.Count > 0) Then
                    MessageBox.Show("Data Exists", "Please Choose Another Type Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If (MsgBox("Update Type In Database?", vbYesNo + vbQuestion) = vbYes) Then
                        con.Open()
                        cmd = New SqlCommand("Update Type set typeName ='" + txtType.Text + "' where typeId like '" + Label6.Text + "' ", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Type Updated Successfully", vbInformation)
                        With ItemTypeList
                            .LoadData()
                        End With
                        LoadData()
                        txtType.Clear()
                        txtType.Focus()
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
        txtType.Clear()
        txtType.Focus()
    End Sub

    Private Sub AddNewType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case Keys.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub
End Class