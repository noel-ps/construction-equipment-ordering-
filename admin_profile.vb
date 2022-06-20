Imports MySql.Data.MySqlClient
Public Class admin_profile
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint
        SQL = "select * from admin where Email='" & admin.Label16.Text & "'"
        command = New MySqlCommand(SQL, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable

        adapter.Fill(table)

        txtfirstname.Text = table.Rows(0)("FirstName").ToString
        txtlastname.Text = table.Rows(0)("Lastname").ToString
        txtaddress.Text = table.Rows(0)("Address").ToString
        txtemail.Text = table.Rows(0)("Email").ToString
        txtpassword.Text = table.Rows(0)("Password").ToString

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If txtfirstname.Text = "" Or txtemail.Text = "" Or txtaddress.Text = "" Or txtpassword.Text = "" Then
            MsgBox("please field can not be empty")
        Else
            connection.Open()
            SQL = "update admin set Firstname='" & txtfirstname.Text & "',Lastname='" & txtlastname.Text & "',Address='" & txtaddress.Text & "',Password='" & txtpassword.Text & "' where Email='" & admin.Label16.Text & "'"
            command = New MySqlCommand(SQL, connection)

            If command.ExecuteNonQuery() = 1 Then
                MsgBox("Update Sucessfully")
            Else
                MsgBox("Failed To Update")
            End If
            connection.Close()
        End If

    End Sub
End Class