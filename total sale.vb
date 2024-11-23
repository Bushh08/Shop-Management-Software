Public Class total_sale

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As String
        Dim net As Integer
        dt = DateTimePicker1.Value.Date
        connect()
        cmd.CommandText = "select sum (total) from Bill where dt='" & dt & "'"
        net = cmd.ExecuteScalar
        TextBox1.Text = net
        discon()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dt1, dt2 As String
        Dim net As Integer
        dt1 = DateTimePicker2.Value.Date
        dt2 = DateTimePicker3.Value.Date
        connect()
        cmd.CommandText = "select sum (total) from Bill where dt between '" & dt1 & "' and '" & dt2 & "'"
        net = cmd.ExecuteScalar
        TextBox2.Text = net
        discon()
    End Sub
End Class