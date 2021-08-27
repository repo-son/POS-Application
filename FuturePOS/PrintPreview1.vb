Imports System.Drawing.Printing

Public Class PrintPreview1
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Dispose()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim Xx1 As Integer = 580
        Dim Yy1 As Integer = 5
        Dim Xwidthx1 As Integer = 250
        Dim Yheighty1 As Integer = 30
        Dim Cellwidths1 As Integer = 200
        Dim Cellheights1 As Integer = 370

        Dim fons1 As New Font(FontFamily.GenericSerif, 10, FontStyle.Bold)
        Dim rectHeader11 As New Rectangle(Xx1, 10, Xwidthx1, Yheighty1)
        Dim stringsHeader11 As New StringFormat

        stringsHeader11.Alignment = StringAlignment.Center
        stringsHeader11.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader11)
        e.Graphics.DrawRectangle(Pens.White, rectHeader11)
        e.Graphics.DrawString(Now.ToString, fons1, Brushes.Black, rectHeader11, stringsHeader11)



        Dim Xx As Integer = 20
        Dim Yy As Integer = 50
        Dim Xwidthx As Integer = 800
        Dim Yheighty As Integer = 53
        Dim Cellwidths As Integer = 200
        Dim Cellheights As Integer = 370

        Dim fons As New Font(FontFamily.GenericSerif, 36, FontStyle.Bold)
        Dim rectHeader As New Rectangle(Xx, 35, Xwidthx, Yheighty)
        Dim stringsHeader As New StringFormat

        stringsHeader.Alignment = StringAlignment.Center
        stringsHeader.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader)
        e.Graphics.DrawRectangle(Pens.White, rectHeader)
        e.Graphics.DrawString("My Burger Employee Report", fons, Brushes.Black, rectHeader, stringsHeader)


        Dim Xxx As Integer = 32
        Dim Yyy As Integer = 90
        Dim Xwidthxx As Integer = 800
        Dim Yheightyy As Integer = 25
        Dim Cellwidthss As Integer = 200
        Dim Cellheightss As Integer = 370

        Dim fonst As New Font(FontFamily.GenericSerif, 12, FontStyle.Bold)
        Dim rectHeader1 As New Rectangle(Xxx, 93, Xwidthxx, Yheightyy)
        Dim stringsHeader1 As New StringFormat

        stringsHeader1.Alignment = StringAlignment.Center
        stringsHeader1.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader1)
        e.Graphics.DrawRectangle(Pens.White, rectHeader1)
        e.Graphics.DrawString("My Burger Restaurants Pvt(Ltd) Main Branch - Dambulla", fonst, Brushes.Black, rectHeader1, stringsHeader1)

        Dim Xx11 As Integer = 32
        Dim Yy11 As Integer = 105
        Dim Xwidthx11 As Integer = 800
        Dim Yheighty11 As Integer = 25
        Dim Cellwidths11 As Integer = 200
        Dim Cellheights11 As Integer = 370

        Dim fons11 As New Font(FontFamily.GenericSerif, 9, FontStyle.Bold)
        Dim rectHeader111 As New Rectangle(Xx11, 125, Xwidthx11, Yheighty11)
        Dim stringsHeader111 As New StringFormat

        stringsHeader111.Alignment = StringAlignment.Center
        stringsHeader111.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader111)
        e.Graphics.DrawRectangle(Pens.White, rectHeader111)
        e.Graphics.DrawString("Email - MBRestaurantsOriginal@gmail.com | Mobile - 0112 345 6789", fons11, Brushes.Black, rectHeader111, stringsHeader111)


        Dim Xx111 As Integer = 1
        Dim Yy111 As Integer = 105
        Dim Xwidthx111 As Integer = 900
        Dim Yheighty111 As Integer = 25
        Dim Cellwidths111 As Integer = 200
        Dim Cellheights111 As Integer = 370

        Dim fons111 As New Font(FontFamily.GenericSerif, 12, FontStyle.Bold)
        Dim rectHeader1111 As New Rectangle(Xx111, 145, Xwidthx111, Yheighty111)
        Dim stringsHeader1111 As New StringFormat

        stringsHeader111.Alignment = StringAlignment.Center
        stringsHeader111.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader1111)
        e.Graphics.DrawRectangle(Pens.White, rectHeader1111)
        e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", fons111, Brushes.Black, rectHeader1111, stringsHeader1111)


        Dim Xx1111 As Integer = 20
        Dim Yy1111 As Integer = 105
        Dim Xwidthx1111 As Integer = 200
        Dim Yheighty1111 As Integer = 25
        Dim Cellwidths1111 As Integer = 200
        Dim Cellheights1111 As Integer = 370

        Dim fons1111 As New Font(FontFamily.GenericSerif, 15, FontStyle.Bold)
        Dim rectHeader11111 As New Rectangle(Xx1111, 165, Xwidthx1111, Yheighty1111)
        Dim stringsHeader11111 As New StringFormat

        stringsHeader11111.Alignment = StringAlignment.Center
        stringsHeader11111.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader11111)
        e.Graphics.DrawRectangle(Pens.White, rectHeader11111)
        e.Graphics.DrawString("Department(s) - ", fons1111, Brushes.Black, rectHeader11111, stringsHeader11111)


        Dim Xx11111 As Integer = 210
        Dim Yy11111 As Integer = 105
        Dim Xwidthx11111 As Integer = 250
        Dim Yheighty11111 As Integer = 25
        Dim Cellwidths11111 As Integer = 200
        Dim Cellheights11111 As Integer = 370

        Dim fons11111 As New Font(FontFamily.GenericSerif, 15, FontStyle.Bold)
        Dim rectHeader111111 As New Rectangle(Xx11111, 165, Xwidthx11111, Yheighty11111)
        Dim stringsHeader111111 As New StringFormat

        stringsHeader111111.Alignment = StringAlignment.Center
        stringsHeader111111.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader111111)
        e.Graphics.DrawRectangle(Pens.White, rectHeader111111)
        With EmployeeSection
            e.Graphics.DrawString(.cmbFilterDepa.SelectedItem, fons11111, Brushes.Black, rectHeader111111, stringsHeader111111)
        End With











        Dim X As Integer = 5
        Dim Y As Integer = 360
        Dim Xwidth As Integer = 90
        Dim Yheight As Integer = 20
        Dim Cellwidth As Integer = 300
        Dim Cellheight As Integer = 370

        Dim fon As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect As New Rectangle(X, 220, Xwidth, Yheight)
        Dim strings As New StringFormat

        strings.Alignment = StringAlignment.Center
        strings.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(1).HeaderText, fon, Brushes.Black, rect, strings)
        End With

        Dim X1 As Integer = 90
        Dim Y1 As Integer = 360
        Dim Xwidth1 As Integer = 90
        Dim Yheight1 As Integer = 20
        Dim Cellwidth1 As Integer = 300
        Dim Cellheight1 As Integer = 370

        Dim fon1 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect1 As New Rectangle(X1, 220, Xwidth1, Yheight1)
        Dim strings1 As New StringFormat

        strings1.Alignment = StringAlignment.Center
        strings1.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect1)
        e.Graphics.DrawRectangle(Pens.Black, rect1)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(2).HeaderText, fon1, Brushes.Black, rect1, strings1)
        End With

        Dim X2 As Integer = 180
        Dim Y2 As Integer = 360
        Dim Xwidth2 As Integer = 90
        Dim Yheight2 As Integer = 20
        Dim Cellwidth2 As Integer = 300
        Dim Cellheight2 As Integer = 370

        Dim fon2 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect2 As New Rectangle(X2, 220, Xwidth2, Yheight2)
        Dim strings2 As New StringFormat

        strings2.Alignment = StringAlignment.Center
        strings2.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect2)
        e.Graphics.DrawRectangle(Pens.Black, rect2)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(3).HeaderText, fon2, Brushes.Black, rect2, strings2)
        End With


        Dim X3 As Integer = 270
        Dim Y3 As Integer = 360
        Dim Xwidth3 As Integer = 70
        Dim Yheight3 As Integer = 20
        Dim Cellwidth3 As Integer = 300
        Dim Cellheight3 As Integer = 370

        Dim fon3 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect3 As New Rectangle(X3, 220, Xwidth3, Yheight3)
        Dim strings3 As New StringFormat

        strings3.Alignment = StringAlignment.Center
        strings3.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect3)
        e.Graphics.DrawRectangle(Pens.Black, rect3)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(4).HeaderText, fon3, Brushes.Black, rect3, strings3)
        End With


        Dim X4 As Integer = 340
        Dim Y4 As Integer = 360
        Dim Xwidth4 As Integer = 100
        Dim Yheight4 As Integer = 20
        Dim Cellwidth4 As Integer = 300
        Dim Cellheight4 As Integer = 370

        Dim fon4 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect4 As New Rectangle(X4, 220, Xwidth4, Yheight4)
        Dim strings4 As New StringFormat

        strings4.Alignment = StringAlignment.Center
        strings4.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect4)
        e.Graphics.DrawRectangle(Pens.Black, rect4)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(5).HeaderText, fon2, Brushes.Black, rect4, strings4)
        End With


        Dim X5 As Integer = 440
        Dim Y5 As Integer = 360
        Dim Xwidth5 As Integer = 100
        Dim Yheight5 As Integer = 20
        Dim Cellwidth5 As Integer = 300
        Dim Cellheight5 As Integer = 370

        Dim fon5 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect5 As New Rectangle(X5, 220, Xwidth5, Yheight5)
        Dim strings5 As New StringFormat

        strings5.Alignment = StringAlignment.Center
        strings5.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect5)
        e.Graphics.DrawRectangle(Pens.Black, rect5)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(7).HeaderText, fon5, Brushes.Black, rect5, strings5)
        End With

        Dim X6 As Integer = 540
        Dim Y6 As Integer = 360
        Dim Xwidth6 As Integer = 100
        Dim Yheight6 As Integer = 20
        Dim Cellwidth6 As Integer = 300
        Dim Cellheight6 As Integer = 370

        Dim fon6 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect6 As New Rectangle(X6, 220, Xwidth6, Yheight6)
        Dim strings6 As New StringFormat

        strings6.Alignment = StringAlignment.Center
        strings6.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect6)
        e.Graphics.DrawRectangle(Pens.Black, rect6)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(8).HeaderText, fon6, Brushes.Black, rect6, strings6)
        End With

        Dim X7 As Integer = 640
        Dim Y7 As Integer = 360
        Dim Xwidth7 As Integer = 100
        Dim Yheight7 As Integer = 20
        Dim Cellwidth7 As Integer = 300
        Dim Cellheight7 As Integer = 370

        Dim fon7 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect7 As New Rectangle(X7, 220, Xwidth7, Yheight7)
        Dim strings7 As New StringFormat

        strings7.Alignment = StringAlignment.Center
        strings7.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect7)
        e.Graphics.DrawRectangle(Pens.Black, rect7)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(9).HeaderText, fon7, Brushes.Black, rect7, strings7)
        End With

        Dim X8 As Integer = 740
        Dim Y8 As Integer = 360
        Dim Xwidth8 As Integer = 100
        Dim Yheight8 As Integer = 20
        Dim Cellwidth8 As Integer = 300
        Dim Cellheight8 As Integer = 370

        Dim fon8 As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)
        Dim rect8 As New Rectangle(X8, 220, Xwidth8, Yheight8)
        Dim strings8 As New StringFormat

        strings8.Alignment = StringAlignment.Center
        strings8.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect8)
        e.Graphics.DrawRectangle(Pens.Black, rect8)
        With EmployeeSection
            e.Graphics.DrawString(.DataGridView3.Columns(11).HeaderText, fon8, Brushes.Black, rect8, strings8)
        End With

        '.....................................................................................










        '.....................................................................................
        Dim Xx111112 As Integer = 300
        Dim Yy111112 As Integer = 105
        Dim Xwidthx111112 As Integer = 250
        Dim Yheighty111112 As Integer = 25
        Dim Cellwidths111112 As Integer = 200
        Dim Cellheights111112 As Integer = 370

        Dim fons111112 As New Font(FontFamily.GenericSerif, 10, FontStyle.Bold)
        Dim rectHeader1111112 As New Rectangle(Xx111112, 1020, Xwidthx111112, Yheighty111112)
        Dim stringsHeader1111112 As New StringFormat

        stringsHeader1111112.Alignment = StringAlignment.Center
        stringsHeader1111112.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader1111112)
        e.Graphics.DrawRectangle(Pens.White, rectHeader1111112)
        e.Graphics.DrawString("Page - 1", fons11111, Brushes.Black, rectHeader1111112, stringsHeader1111112)


        Dim Xx1111123 As Integer = 500
        Dim Yy1111123 As Integer = 105
        Dim Xwidthx1111123 As Integer = 300
        Dim Yheighty1111123 As Integer = 25
        Dim Cellwidths1111123 As Integer = 200
        Dim Cellheights1111123 As Integer = 370

        Dim fons1111123 As New Font(FontFamily.GenericSerif, 8, FontStyle.Bold)
        Dim rectHeader11111123 As New Rectangle(Xx1111123, 1050, Xwidthx1111123, Yheighty1111123)
        Dim stringsHeader11111123 As New StringFormat

        stringsHeader11111123.Alignment = StringAlignment.Center
        stringsHeader11111123.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(Brushes.WhiteSmoke, rectHeader11111123)
        e.Graphics.DrawRectangle(Pens.White, rectHeader11111123)
        e.Graphics.DrawString("My Burger Company All Rights Reserved, Don not Copy", fons1111123, Brushes.Black, rectHeader11111123, stringsHeader11111123)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewControl1.Zoom = 1.2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintPreviewControl1.AutoZoom = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = vbYes Then
            PrintDocument1.Print()
        End If
    End Sub
End Class