Imports MySql.Data.MySqlClient
Public Class Admin1
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        product.Show()
    End Sub
    Sub choose()
        connection.Open()

        SQL = "select ProductName,Unit,Quantity,Price from Product"
        Dim adapter As New MySqlDataAdapter(SQL, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Sub chooseorder()
        connection.Open()

        SQL = "select registration.FullName,registration.Location,orders.Orderid,orders.Product,orders.Price,orders.Unit,orders.Quantity,orders.status from orders inner join registration on orders.UserId=registration.UserId"
        Dim adapter As New MySqlDataAdapter(SQL, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label4.Text = "Orders"
        chooseorder()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        UpdateUser.Show()

    End Sub
    Sub chooseuser()
        connection.Open()

        SQL = "select FullName,Email,Location,PhoneNumber from registration"
        Dim adapter As New MySqlDataAdapter(SQL, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.Guna2DataGridView1.Rows(e.RowIndex)
            Order.Text = row.Cells("Orderid").Value.ToString
            confirm.txtname.Text = row.Cells("FullName").Value.ToString
            confirm.txtproduct.Text = row.Cells("Product").Value.ToString
            confirm.txtqty.Text = row.Cells("Quantity").Value.ToString
            confirm.txtunit.Text = row.Cells("Unit").Value.ToString
            confirm.txtprice.Text = row.Cells("Price").Value.ToString
            confirm.txttotal.Text = row.Cells("Price").Value.ToString * row.Cells("Quantity").Value.ToString
            confirm.txtstatus.Text = row.Cells("status").Value.ToString
        End If
        confirm.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles panel1.Paint
        Order.Visible = False
    End Sub
End Class