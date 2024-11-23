Imports System.Data.SqlClient
Public Class Login
    Public Shared id As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.TextLength = 0 Then
            MsgBox("Enter the User ID.", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        ElseIf TextBox2.TextLength = 0 Then
            MsgBox("Enter the password.", MsgBoxStyle.Critical, "Error")
            TextBox2.Focus()
        Else
            connect()
        Dim pw, pw1 As String
        id = TextBox1.Text
        pw = TextBox2.Text
        cmd.CommandText = "select * from login where id='" & id & "'"
        reader = cmd.ExecuteReader()

        If reader.HasRows = Nothing Then
            MsgBox("Wrong ID or Password.", MsgBoxStyle.Critical, "Error")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        Else
            discon()
            connect()
            cmd.CommandText = "select * from login where id='" & id & "'"
            reader = cmd.ExecuteReader()
            reader.Read()
            pw1 = reader.Item("pw")
            If pw = pw1 Then
                MsgBox("Logged in successfully.", MsgBoxStyle.Information, "Information")
                Me.Hide()
                Main.Show()
            Else
                MsgBox("Wrong ID or Password.", MsgBoxStyle.Critical, "Error")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            End If
        End If
            discon()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
      
    End Sub
End Class