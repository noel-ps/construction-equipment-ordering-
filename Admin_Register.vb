Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class Admin_Register
    Dim connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim SQL As String
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim regex As Regex = New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        Dim check As Boolean = regex.IsMatch(txtemail.Text.Trim)
        If txtFname.Text = "" Or txtlname.Text = "" Or txtemail.Text = "" Or txtaddress.Text = "" Or txtpassword.Text = "" Then
            MsgBox("please enter all the field")
        Else
            If Not check Then
                MsgBox("invalid Email")
            Else
                SQL = "insert into Admin(FirstName,LastName,Email,Address,Password) values(@firstname,@lastname,@email,@address,@password)"

                command = New MySqlCommand(SQL, connection)
                command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = txtFname.Text
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = txtlname.Text
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtemail.Text
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = txtaddress.Text
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtpassword.Text

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                    If command.ExecuteNonQuery() = 1 Then
                        MessageBox.Show("New Admin Added")
                        txtFname.Clear()
                        txtlname.Clear()
                        txtemail.Clear()
                        txtaddress.Clear()
                        txtpassword.Clear()
                    Else
                        MessageBox.Show("Failed To Add New Admin")
                    End If
                    connection.Close()
                End If
            End If
        End If

    End Sub
End Class