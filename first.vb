Public Class first
    Private Sub Panel13_Paint(sender As Object, e As PaintEventArgs) Handles Panel13.Paint

    End Sub

    Private Sub first_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label16.Text = login1.Label3.Text
        SwitchPanel(Home_user)
    End Sub
    Sub SwitchPanel(panel As Form)
        Panel13.Controls.Clear()
        panel.TopLevel = False
        Panel13.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        SwitchPanel(Home_user)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        SwitchPanel(Tools)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Id.Text = Nothing
        Account_user.Show()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        SwitchPanel(Profile)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        manage_order.Show()
    End Sub
End Class