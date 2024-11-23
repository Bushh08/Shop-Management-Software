Public Class user_account

    Private Sub user_account_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.SelectedIndex = 0
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Main.Show()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 0 Then
            MsgBox("Select the valid user ID.", MsgBoxStyle.Critical, "Error")
            ComboBox1.Focus()
        ElseIf TextBox1.TextLength = 0 Then
            MsgBox("Enter the old password.", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        ElseIf TextBox2.TextLength = 0 Then
            MsgBox("Enter the new password.", MsgBoxStyle.Critical, "Error")
            TextBox2.Focus()
        ElseIf TextBox3.TextLength = 0 Then
            MsgBox("Enter the confirm password.", MsgBoxStyle.Critical, "Error")
            TextBox3.Focus()
        Else
            Dim id, opw, npw, cpw As String
            id = ComboBox1.SelectedItem
            opw = TextBox1.Text
            npw = TextBox2.Text
            cpw = TextBox3.Text
            connect()
            cmd.CommandText = "select * from login where id='" & id & "'"
            reader = cmd.ExecuteReader()
            reader.Read()


            If opw = reader.Item("pw") Then
                If npw = cpw Then
                    discon()
                    connect()
                    cmd.CommandText = "update login set pw= '" & npw & "' where id='" & id & "'"
                    cmd.ExecuteNonQuery()
                    discon()
                    MsgBox("Password changed successfully.", MsgBoxStyle.Information, "Information")
                    ComboBox1.SelectedIndex = 0
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    ComboBox1.Focus()
                Else
                    MsgBox("New and confirm password not matched.", MsgBoxStyle.Critical, "Error")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox1.Focus()
                End If
            Else
                MsgBox("Invalid old password.", MsgBoxStyle.Critical, "Error")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox1.Focus()
            End If
            discon()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class