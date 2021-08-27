
Imports System.Data.SqlClient
Imports System.Data
Module ConnectionModule
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public dt As DataTable
    Public daa As SqlDataAdapter
    Public strUser As String
    Public StrName As String
    Public strPass As String
    Public strUserRole As String
    Public strStatus As String
    Public Title As String = "My Burger POS System"


    Sub Connection()
        con = New SqlConnection
        With con
            .ConnectionString = "Data Source=.;Initial Catalog=MyBurgerFuturePay;Integrated Security=True"
        End With
    End Sub
    Function GetVat() As Double
        con.Open()
        cmd = New SqlCommand("select * from Vat", con)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then GetVat = CDbl(dr.Item("vat").ToString) Else GetVat = 0.00
        dr.Close()
        con.Close()
        Return GetVat
    End Function

    Public Function IS_EMPTY(ByVal sText As Object) As Boolean
        On Error Resume Next
        If sText.Text = "" Then
            IS_EMPTY = True
            MsgBox("Missing or Incorrect Fields Detected", vbExclamation)
            sText.BackColor = Color.LightYellow
            sText.Focus()
        Else
            IS_EMPTY = False
            sText.BackColor = Color.White
        End If
    End Function
    Public Function IS_EMPTY(ByVal sText As Object, sText1 As Object) As Boolean
        On Error Resume Next
        If sText.Text = "" Then
            IS_EMPTY = True
            MsgBox("Missing or Incorrect Fields Detected", vbExclamation)
            sText1.BackColor = Color.LightYellow
            sText1.Focus()
        Else
            IS_EMPTY = False
            sText1.BackColor = Color.White
        End If
    End Function
    Public Function ValidationDuplicate(ByVal sql As String) As Boolean
        con.Open()
        cmd = New SqlCommand(sql, con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            ValidationDuplicate = True
            MsgBox("Duplicate Warning: Data Already In Database", vbExclamation)
        Else
            ValidationDuplicate = False
        End If
        dr.Close()
        con.Close()
    End Function
End Module
