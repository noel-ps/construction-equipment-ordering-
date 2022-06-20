Imports MySql.Data.MySqlClient
Public Class Product_Order
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Me.Close()
    End Sub

    Private Sub Product_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        choose()
    End Sub
    Public Sub choose()
        connection.Open()
        SQL = "select ProductName,Unit,Price,Quantity from product"
        Dim adapter As New MySqlDataAdapter(SQL, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Public Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.Guna2DataGridView1.Rows(e.RowIndex)
            txtpname.Text = row.Cells("ProductName").Value.ToString
            txtprice.Text = row.Cells("Price").Value.ToString
            txtunit.Text = row.Cells("Unit").Value.ToString
            lblqty.Text = row.Cells("Quantity").Value.ToString
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If txtpname.Text = "" Or txtprice.Text = "" Or txtqty.Text = "" Or txtunit.Text = "" Then
            MsgBox("Please select product and enter quantity", vbInformation)
        Else
            If Int(txtqty.Text) > Int(lblqty.Text) Or txtqty.Text = 0 Then
                MsgBox("Sorry Quantity can not be large that the current quantity or less than 1")
            Else
                SQL = "insert into orders(Product,Price,Unit,Quantity,UserId) values('" & txtpname.Text & "','" & txtprice.Text & "','" & txtunit.Text & "','" & txtqty.Text & "','" & first.Id.Text & "')"
                connection.Open()
                command = New MySqlCommand(SQL, connection)
                If command.ExecuteNonQuery = 1 Then
                    MessageBox.Show("Order Placed")
                    txtpname.Clear()
                    txtprice.Clear()
                    txtqty.Clear()
                    txtunit.Clear()
                End If
                connection.Close()
            End If
        End If
    End Sub
End Class