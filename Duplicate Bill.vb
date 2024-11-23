Public Class Duplicate_Bill
    Public Shared bno1 As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.TextLength = 0 Then
            MsgBox("Enter the bill no.", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        ElseIf Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox1.Clear()
            TextBox1.Focus()
        Else

            bno1 = TextBox1.Text
            connect()
            cmd.CommandText = "select * from Bill where bno=" & bno1
            reader = cmd.ExecuteReader
            If reader.HasRows = False Then
                MsgBox("Bill not found.", MsgBoxStyle.Critical, "Error")
                TextBox1.Clear()
                TextBox1.Focus()
            Else
                discon()
                Me.Hide()
                Invoice.Show()
            End If
            discon()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Duplicate_Bill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Main.Show()
    End Sub

End Class