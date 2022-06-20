Imports MySql.Data.MySqlClient
Public Class manage_order
    Dim connection As New MySqlConnection("server=localhost;user=root; password=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim sql As String
    Private Sub Manage_order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        choose()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Me.Close()
    End Sub
    Public Sub choose()

        sql = "select orders.OrderId,orders.Product,orders.Price,orders.Unit,orders.Quantity,orders.status from orders where UserId='" & first.Id.Text & "'"
        command = New MySqlCommand(sql, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table

    End Sub

    Public Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Guna2DataGridView1.Rows(e.RowIndex)
            Label5.Text = row.Cells("OrderId").Value.ToString
            txtpname.Text = row.Cells("Product").Value.ToString
            txtprice.Text = row.Cells("Price").Value.ToString
            txtunit.Text = row.Cells("Unit").Value.ToString
            txtqty.Text = row.Cells("Quantity").Value.ToString

        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        sql = "update orders set Quantity='" & txtqty.Text & "' where UserId='" & first.Id.Text & "' AND OrderId= '" & Label5.Text & "'"
        command = New MySqlCommand(sql, connection)
        If connection.State = ConnectionState.Closed Then
            connection.Open()
            If txtqty.Text = "" Or txtpname.Text = "" Then
                MsgBox("Please Enter Quantity or select product")
            Else
                If command.ExecuteNonQuery() = 1 Then
                    MsgBox("Order Updated")
                Else
                    MsgBox("Failed To Update Order")
                End If
                connection.Close()
                choose()
            End If
        End If


    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        sql = "delete from orders where  UserId='" & first.Id.Text & "' and OrderId= '" & Label5.Text & "'"
        command = New MySqlCommand(sql, connection)
        If connection.State = ConnectionState.Closed Then
            connection.Open()
            If txtpname.Text = "" Or txtprice.Text = "" Or txtqty.Text = "" Or txtunit.Text = "" Then
                MsgBox("Please Select Product")
            Else
                If command.ExecuteNonQuery() = 1 Then
                    MsgBox("Order Deleted Successfully")
                Else
                    MsgBox("Failed To Delete Order")
                End If

            End If
        End If
        connection.Close()
        choose()

    End Sub
End Class