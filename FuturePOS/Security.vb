Imports System.Data.SqlClient
Public Class Security


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub btnGetStarted_Click_1(sender As Object, e As EventArgs) Handles btnGetStarted.Click
        Try
            Dim found As Boolean = False
            If IS_EMPTY(txtUsername) = True Then Return
            If IS_EMPTY(txtPassword) = True Then Return
            con.Open()
            cmd = New SqlCommand("select * from Users where Username = '" & txtUsername.Text & "' and Password = '" & txtPassword.Text & "'", con)
            dr = cmd.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                strUser = dr.Item("Username").ToString
                StrName = dr.Item("Name").ToString
                strPass = dr.Item("Password").ToString
                strUserRole = dr.Item("UserRole").ToString
                strStatus = dr.Item("Status").ToString
                found = True
            Else
                strUserRole = ""
                strStatus = ""
                strUser = ""
                StrName = ""
                strPass = ""
                found = False
            End If
            dr.Close()
            con.Close()

            If found = True Then
                If strStatus = "Active" Then
                    txtPassword.Clear()
                    txtUsername.Clear()
                    If strUserRole = "Cashier" Then
                        Timer1.Start()
                        MsgBox("Access Granted, Welcome Onboard" & Space(2) & StrName, vbInformation)
                        With Sales
                            .lblEMP.Text = StrName
                            .ShowDialog()
                        End With
                    Else
                        Timer1.Start()
                        With Form1
                            MsgBox("Access Granted, Welcome Onboard" & Space(2) & StrName, vbInformation)
                            .lblShow.Text = "Welcome " & StrName
                            .ShowDialog()
                        End With

                    End If
                Else
                    MsgBox("Account is not Active, Please contact System Administrator", vbCritical)
                End If
            Else
                MsgBox("Invalid Username Or Password", vbCritical)
            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        txtPassword.Clear()
        txtUsername.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub Security_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUsername.Focus()
        Connection()
        ToolTip1.SetToolTip(Button4, "Close")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MetroProgressBar1.Increment(20)
        If MetroProgressBar1.Value = 100 Then
            Timer1.Stop()
        End If
    End Sub
End Class