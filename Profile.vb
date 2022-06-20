Imports MySql.Data.MySqlClient


Public Class Profile
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If txtfullname.Text = "" Or txtphone.Text = "" Or txtlocation.Text = "" Or txtpassword.Text = "" Then
            MsgBox("Field can not be blank")
        Else
            connection.Open()
            SQL = "update registration set FullName='" & txtfullname.Text & "',PhoneNumber='" & txtphone.Text & "',Location='" & txtlocation.Text & "',Password='" & txtpassword.Text & "' where UserId='" & first.Id.Text & "'"

            command = New MySqlCommand(SQL, connection)
            If command.ExecuteNonQuery() = 1 Then
                MsgBox("Information Updated sucessfully", vbInformation)
            Else
                MsgBox("Failed To update Intomation")
            End If
            connection.Close()
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint
        SQL = "select * from registration where UserId='" & first.Id.Text & "'"
        command = New MySqlCommand(SQL, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)

        txtfullname.Text = table.Rows(0)("FullName").ToString
        txtemail.Text = table.Rows(0)("Email").ToString
        txtlocation.Text = table.Rows(0)("Location").ToString
        txtphone.Text = table.Rows(0)("PhoneNumber").ToString
        txtpassword.Text = table.Rows(0)("Password").ToString

    End Sub
End Class