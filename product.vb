Imports MySql.Data.MySqlClient
Public Class product
    Dim connection As New MySqlConnection("server=localhost;user=root;pasword=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim SQL As String
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Me.Close()
    End Sub

    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQL = "select * from product"
        command = New MySqlCommand(SQL, connection)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        Guna2DataGridView1.DataSource = table
    End Sub
End Class