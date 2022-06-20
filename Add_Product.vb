Imports MySql.Data.MySqlClient

Public Class Add_Product
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        SQL = "insert into product(ProductName,Quantity,Price,Unit) values('" & txtname.Text & "','" & txtquantity.Text & "','" & txtprice.Text & "','" & txtunit.Text & "')"
        If connection.State = ConnectionState.Closed Then
            connection.Open()
            If txtname.Text = "" Or txtprice.Text = "" Or txtquantity.Text = "" Or txtunit.Text = "" Then
                MsgBox("Please Enter All product Details")
            Else
                command = New MySqlCommand(SQL, connection)
                If command.ExecuteNonQuery() = 1 Then

                    txtname.Clear()
                    txtprice.Clear()
                    txtquantity.Clear()
                    txtunit.Clear()
                    Label5.Text = "Inserted Successfully"

                    MessageBox.Show("Product Inserted Successfully")
                Else
                    MessageBox.Show("Product Not Inserted")
                End If
            End If
        End If
        connection.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class