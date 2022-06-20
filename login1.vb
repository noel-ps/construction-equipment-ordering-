Imports MySql.Data.MySqlClient

Public Class login1
    Dim connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim SQL As String
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        register1.Show()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click

        If userRadio.Checked Then
            If TextEmail.Text = "" Or TextPassword.Text = "" Then
                MessageBox.Show("Fill Both Text")
            Else

                SQL = "select * from Registration where Email = @email and Password = @pass"
                command = New MySqlCommand(SQL, connection)

                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextEmail.Text
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextPassword.Text

                Dim adapter As New MySqlDataAdapter(command)

                Dim table As New DataTable()

                adapter.Fill(table)

                If table.Rows.Count <= 0 Then
                    MessageBox.Show("Incorrect Usename Or Password")
                Else
                    MessageBox.Show("Successfuly, And Welcome Ujenzi House System")
                    Me.Hide()
                    first.Show()
                    TextEmail.Clear()
                    TextPassword.Clear()
                    userRadio.Checked = False
                    first.Id.Text = table.Rows(0)("UserId").ToString

                End If

            End If
        ElseIf adminRadio.Checked Then


            If TextEmail.Text = "" Or TextPassword.Text = "" Then
                MessageBox.Show("Please Fill The Blanks")
            Else
                SQL = "select * from Admin where Email= @email and Password = @pass"
                command = New MySqlCommand(SQL, connection)
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextEmail.Text
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextPassword.Text

                Dim adapter As New MySqlDataAdapter(command)

                Dim table As New DataTable

                adapter.Fill(table)

                If table.Rows.Count() <= 0 Then
                    MessageBox.Show("Wrong Username Or Password")
                Else
                    MessageBox.Show("Login Successfully")
                    Me.Hide()
                    admin.Show()
                    TextEmail.Clear()
                    TextPassword.Clear()
                    adminRadio.Checked = False

                End If
            End If


        Else
            MessageBox.Show("Choose Role")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Hide()
        admin.Show()
    End Sub

End Class