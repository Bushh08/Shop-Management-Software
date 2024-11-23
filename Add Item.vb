Public Class Add_Item
    Dim sno, id As Integer
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Add_Item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        cmd.CommandText = "select count(*)from ad_itm"
        cnt = cmd.ExecuteScalar()
        discon()
        If cnt = 0 Then
            sno = 1
            id = id + 1

        Else
            sno = cnt + 1
            connect()
            cmd.CommandText = "select max(id) from ad_itm"
            id = cmd.ExecuteScalar()
            id = id + 1
            discon()
        End If
        TextBox1.Text = id
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Update__Delete_Items.Show()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DateTimePicker1.Value.Date > Today Then
            MsgBox("Enter the correct date.", MsgBoxStyle.Critical, "Error")
            DateTimePicker1.Focus()
        ElseIf TextBox2.TextLength = 0 Then
            MsgBox("Enter the item name.", MsgBoxStyle.Critical, "Error")
            TextBox2.Focus()
        ElseIf ComboBox1.SelectedIndex = 0 Then
            MsgBox("Select the valid type.", MsgBoxStyle.Critical, "Error")
            ComboBox1.Focus()
        ElseIf TextBox3.TextLength = 0 Then
            MsgBox("Enter the MRP (Rs).", MsgBoxStyle.Critical, "Error")
            TextBox3.Focus()
        ElseIf Not IsNumeric(TextBox3.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox3.Clear()
            TextBox3.Focus()
        ElseIf TextBox4.TextLength = 0 Then
            MsgBox(" Enter the qty.", MsgBoxStyle.Critical, "Error")
            TextBox4.Focus()
        ElseIf Not IsNumeric(TextBox4.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
        ElseIf ComboBox2.SelectedIndex = 0 Then
            MsgBox("Select the valid quantity type.", MsgBoxStyle.Critical, "Error")
            ComboBox2.Focus()
        Else
            Dim MRP, Qty As Integer
            Dim dt, itnm, type, Qtyp As String
            id = TextBox1.Text
            itnm = TextBox2.Text
            dt = DateTimePicker1.Value.Date
            MRP = TextBox3.Text
            type = ComboBox1.SelectedItem
            Qty = TextBox4.Text
            Qtyp = ComboBox2.SelectedItem

            Dim result As DialogResult
            result = MsgBox("Are you sure, won't to add this record?", MsgBoxStyle.YesNo, "Conformation")
            If result = Windows.Forms.DialogResult.Yes Then
                connect()
                cmd.CommandText = " Insert into ad_itm values(" & sno & ",'" & dt & "'," & id & ",'" & itnm & "','" & type & "'," & Qty & ",'" & Qtyp & "'," & MRP & ")"
                cmd.ExecuteNonQuery()
                discon()
                MsgBox("Item added successfully.", MsgBoxStyle.Information, "Information")

                id = id + 1
                sno = sno + 1
                TextBox1.Text = id
                DateTimePicker1.Value = Today
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.SelectedIndex = 0
                ComboBox2.SelectedIndex = 0
                TextBox2.Focus()
            Else
                DateTimePicker1.Value = Today
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.SelectedIndex = 0
                ComboBox2.SelectedIndex = 0
                TextBox2.Focus()
            End If

        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        DateTimePicker1.Value = Today
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        TextBox2.Focus()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class