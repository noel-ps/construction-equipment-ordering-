Imports MySql.Data.MySqlClient
Public Class confirm
    Dim connection As New MySqlConnection("server=localhost; user=root;password=;database=ujenzihouse;")
    Dim command As New MySqlCommand
    Dim SQL As String
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Me.Close()
    End Sub

    Private Sub Btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        connection.Open()
        SQL = "update orders set status='Confirmed' where OrderId= '" & Admin1.Order.Text & "'"

        command = New MySqlCommand(SQL, connection)

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("Order Confirmed", vbInformation)
        Else
            MsgBox("Failed To comfirm order", vbInformation)
        End If
        connection.Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        connection.Open()
        SQL = "update orders set status='Cancelled' where OrderId= '" & Admin1.Order.Text & "'"

        command = New MySqlCommand(SQL, connection)

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("Order Cancelled", vbInformation)
        Else
            MsgBox("Failed To Cancel order", vbInformation)
        End If
        connection.Close()
    End Sub

End Class