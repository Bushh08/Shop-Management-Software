Public Class Update__Delete_Items

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DateTimePicker1.Value.Date > Today Then
            MsgBox("enter the correct date.", MsgBoxStyle.Critical, "error")
            DateTimePicker1.Focus()
        ElseIf TextBox4.TextLength = 0 Then
            MsgBox("Enter the item name.", MsgBoxStyle.Critical, "Error")
            TextBox4.Focus()
        ElseIf ComboBox1.SelectedIndex = 0 Then
            MsgBox("select the valid type.", MsgBoxStyle.Critical, "Error")
            ComboBox1.Focus()
        ElseIf ComboBox2.SelectedIndex = 0 Then
            MsgBox("select the valid  qtyp.", MsgBoxStyle.Critical, "Error")
            ComboBox2.Focus()
        ElseIf TextBox5.TextLength = 0 Then
            MsgBox("Enter the MRP.", MsgBoxStyle.Critical, "Error")
            TextBox5.Focus()
        ElseIf Not IsNumeric(TextBox5.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox5.Clear()
            TextBox5.Focus()
        ElseIf TextBox6.TextLength = 0 Then
            MsgBox("Enter the Qty.", MsgBoxStyle.Critical, "Error")
            TextBox6.Focus()
        ElseIf Not IsNumeric(TextBox6.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox6.Clear()
            TextBox6.Focus()
        Else

            Dim result As DialogResult
            Dim itnm, dt, typ, qtyp As String
            Dim id, mrp, qty As Integer
            id = TextBox3.Text
            dt = DateTimePicker1.Value.Date
            itnm = TextBox4.Text
            mrp = TextBox5.Text
            qty = TextBox6.Text
            typ = ComboBox1.SelectedItem
            qtyp = ComboBox2.SelectedItem
            result = MsgBox("Are you sure,you want to update this record ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conformation")
            If result = Windows.Forms.DialogResult.Yes Then
                connect()
                cmd.CommandText = "update ad_itm set Dt='" & dt & "', nme= '" & itnm & "', typ = '" & typ & "',qty='" & qty & "',qtyp='" & qtyp & "', mrp='" & mrp & "'Where ID=" & id
                cmd.ExecuteNonQuery()
                discon()
                MsgBox("Record updated successfully.", MsgBoxStyle.Information, "Information")
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                DateTimePicker1.Value = Today
                ComboBox1.SelectedIndex = 0
                ComboBox2.SelectedIndex = 0
                TextBox1.Focus()
                Button3.Enabled = False
                Button4.Enabled = False
                RadioButton1.Checked = True
                TextBox1.Focus()
            Else
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                DateTimePicker1.Value = Today
                ComboBox1.SelectedIndex = 0
                ComboBox2.SelectedIndex = 0
                TextBox1.Focus()
                Button3.Enabled = False
                Button4.Enabled = False
                RadioButton1.Checked = True
                TextBox1.Focus()
                ' MsgBox ("Record updated successfully.",msgboxstyle.information,"information"
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim result As DialogResult
        result = MsgBox(" Are you sure,you want to delete this Record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confomation")
        If result = Windows.Forms.DialogResult.Yes Then
            Dim ID As Integer
            ID = TextBox3.Text
            connect()
            cmd.CommandText = " delete from ad_itm Where ID=" & ID
            cmd.ExecuteNonQuery()
            discon()
            TextBox3.Clear()
            DateTimePicker1.Value = Today
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            RadioButton1.Checked = True
            TextBox1.Focus()
            MsgBox("Record deleted successfully.", MsgBoxStyle.Information, "Information")
        Else
            Button3.Enabled = False
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ID As Integer
        If TextBox1.TextLength = 0 Then
            MsgBox("Enter the ID", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        ElseIf Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox1.Clear()
            TextBox1.Focus()
        Else
            connect()
            ID = TextBox1.Text()
            cmd.CommandText = "select *from ad_itm where id=" & ID
            reader = cmd.ExecuteReader
            If reader.HasRows = False Then
                MsgBox("Record not found.,", MsgBoxStyle.Critical, "Error")
                TextBox1.Clear()
                TextBox1.Focus()
                discon()
            Else
                discon()
                connect()
                ID = TextBox1.Text
                cmd.CommandText = "select * from ad_itm where id='" & ID & "'"
                reader = cmd.ExecuteReader
                reader.Read()
                TextBox3.Text = reader.Item("id")
                TextBox4.Text = reader.Item("nme")
                TextBox5.Text = reader.Item("mrp")
                TextBox6.Text = reader.Item("qty")
                DateTimePicker1.Value = reader.Item("dt")
                ComboBox1.SelectedItem = reader.Item("typ")
                ComboBox2.SelectedItem = reader.Item("qtyp")

                discon()
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button3.Focus()
            End If
            End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.TextLength = 0 Then
            MsgBox("Enter the Item Name.", MsgBoxStyle.Critical, "Error")
            TextBox2.Focus()
        Else
            Dim itnm As String
            itnm = TextBox2.Text
            connect()
            cmd.CommandText = " select * from ad_itm Where nme='" & itnm & "'"
            reader = cmd.ExecuteReader
            ComboBox1.SelectedIndex = 0
            If reader.HasRows = False Then
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Error")
                TextBox2.Clear()
                TextBox2.Focus()
                discon()
            Else : discon()
                connect()
                itnm = TextBox2.Text
                cmd.CommandText = "select * from ad_itm where nme='" & itnm & "' "
                reader = cmd.ExecuteReader
                reader.Read()
                TextBox3.Text = reader.Item("id")
                TextBox4.Text = reader.Item("nme")
                TextBox4.Text = reader.Item("mrp")
                TextBox5.Text = reader.Item("qty")
                DateTimePicker1.Value = reader.Item("dt")
                ComboBox1.SelectedItem = reader.Item("typ")
                ComboBox2.SelectedItem = reader.Item("qtyp")

                discon()
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button3.Focus()

            End If
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox3.Clear()
        DateTimePicker1.Value = Today
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
        Button3.Enabled = False
        Button4.Enabled = False
        Button6.Enabled = False
        RadioButton1.Checked = True
        TextBox1.Focus()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox2.Enabled = False
        Button2.Enabled = False
        TextBox1.Enabled = True
        TextBox1.Focus()
        Button1.Enabled = True
        TextBox2.Clear()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Enabled = False
        Button1.Enabled = False
        TextBox2.Enabled = True
        Button2.Enabled = True
        TextBox2.Focus()
        TextBox1.Clear()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class