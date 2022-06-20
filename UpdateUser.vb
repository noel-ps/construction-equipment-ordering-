Imports MySql.Data.MySqlClient
Public Class UpdateUser
    Dim connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim sql

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Me.Close()
    End Sub

    Public Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.Guna2DataGridView1.Rows(e.RowIndex)
            Label1.Text = row.Cells("UserId").Value.ToString
            txtfullname.Text = row.Cells("FullName").Value.ToString
            txtemail.Text = row.Cells("Email").Value.ToString
            txtphone.Text = row.Cells("PhoneNumber").Value.ToString
            txtlocation.Text = row.Cells("Location").Value.ToString
            txtpassword.Text = row.Cells("Password").Value.ToString


        End If
    End Sub
    Sub choose()
        connection.Open()
        sql = "select * from registration"
        Dim adapter As New MySqlDataAdapter(Sql, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Private Sub UpdateUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        choose()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        If txtfullname.Text = "" Or txtemail.Text = "" Or txtlocation.Text = "" Or txtphone.Text = "" Or txtpassword.Text = "" Then
            MsgBox("Please Select User")
        Else


            sql = "update registration set FullName='" & txtfullname.Text & "',Email='" & txtemail.Text & "', PhoneNumber='" & txtphone.Text & "', Location ='" & txtlocation.Text & "', Password='" & txtpassword.Text & "' where UserId= '" & Label1.Text & "'"
            command = New MySqlCommand(sql, connection)
            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MsgBox("User Updated Successfully")
            Else
                MsgBox("failed To Update User")
            End If
        End If
        connection.Close()
        choose()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If txtfullname.Text = "" Or txtemail.Text = "" Or txtlocation.Text = "" Or txtphone.Text = "" Or txtpassword.Text = "" Then
            MsgBox("Please Select User")
        Else


            sql = "delete from registration where UserId= '" & Label1.Text & "'"
            command = New MySqlCommand(sql, connection)
            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MsgBox("User Deleted Successfully")
                txtfullname.Clear()
                txtemail.Clear()
                txtlocation.Clear()
                txtpassword.Clear()
                txtphone.Clear()

            Else
                MsgBox("failed To Delete User")
            End If
        End If
        connection.Close()
        choose()
    End Sub
End Class