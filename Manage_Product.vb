Imports MySql.Data.MySqlClient
Public Class Manage_Product
    Public connection As New MySqlConnection("server=localhost; user=root; password=;database=ujenzihouse;")
    Public command As New MySqlCommand
    Public SQL As String
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.Guna2DataGridView1.Rows(e.RowIndex)
            pname.Text = row.Cells("ProductName").Value.ToString
            qty.Text = row.Cells("Quantity").Value.ToString
            unit.Text = row.Cells("Unit").Value.ToString
            price.Text = row.Cells("Price").Value.ToString
            idtxt.Text = row.Cells("ProductId").Value.ToString

        End If

    End Sub
    Sub choose()
        connection.Open()
        SQL = "select ProductId,ProductName,Quantity,Unit,Price from product"
        Dim adapter As New MySqlDataAdapter(SQL, connection)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
        connection.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        price.Visible = False
        qty.Visible = False
        unit.Visible = False
        pname.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        save.Visible = False
        choose()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        price.Visible = True
        qty.Visible = True
        unit.Visible = True
        pname.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        save.Visible = True

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        SQL = "delete from product where ProductId= '" & idtxt.Text & "'"
        command = New MySqlCommand(SQL, connection)
        connection.Open()
        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Product Deleted Successfully")
            price.Clear()
            pname.Clear()
            qty.Clear()
            unit.Clear()
        Else
            MsgBox("Failed To Delete Product")
        End If
        connection.Close()
        choose()

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles save.Click
        If pname.Text = "" Or price.Text = "" Or qty.Text = "" Or unit.Text = "" Then
            MsgBox("please field can not be blank")
        Else
            SQL = "update product set ProductName = '" & pname.Text & "',Price = '" & price.Text & "',Quantity='" & qty.Text & "',Unit= '" & unit.Text & "'  where ProductId= '" & idtxt.Text & "'"
            command = New MySqlCommand(SQL, connection)
            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Product Saved")
                price.Clear()
                pname.Clear()
                qty.Clear()
                unit.Clear()
            Else
                MsgBox("Failed To Save Product")
            End If
        End If
        connection.Close()
        choose()
    End Sub
End Class