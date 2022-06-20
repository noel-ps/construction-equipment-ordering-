Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class register1
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        login1.Show()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Dim regex As Regex = New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        Dim check As Boolean = regex.IsMatch(txtemail.Text.Trim)

        If (txtfullname.Text = "" Or txtemail.Text = "" Or txtphone.Text = "" Or txtlocation.Text = "" Or txtpassword.Text = "") Then
            MessageBox.Show("Please Fill All The Blanks")

        Else
            If Not check Then
                MsgBox("invalid Email")
            Else
                SQL = "select * from registration where Email='" & txtemail.Text & "'"

                command = New MySqlCommand(SQL, connection)
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable
                adapter.Fill(table)

                If table.Rows.Count() >= 1 Then
                    MsgBox("Email Already exist")
                Else
                    SQL = "Insert Into registration(FullName,Email,PhoneNumber,Location,Password) Values('" & txtfullname.Text & "','" & txtemail.Text & "','" & txtphone.Text & "','" & txtlocation.Text & "','" & txtpassword.Text & "')"

                    command = New MySqlCommand(SQL, connection)
                    If connection.State = ConnectionState.Closed Then
                        connection.Open()
                        If command.ExecuteNonQuery() = 1 Then
                            MsgBox("Registered Successfully", vbInformation)
                            Me.Hide()
                            login1.Show()
                        Else
                            MessageBox.Show("Failed To Be Registered")
                        End If
                        connection.Close()
                    End If
                End If
            End If
        End If
    End Sub


    'Private Sub txtphone_KeyUp(sender As Object, e As KeyEventArgs) Handles txtphone.KeyUp
    '    If (Not Char.IsNumber(ChrW(e.KeyCode))) Then
    '        MessageBox.Show("Sorry Enter Number Only")
    '        txtphone.Text = ""
    '    End If
    'End Sub

End Class