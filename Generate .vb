Imports System.Data.SqlClient
Public Class Form2
    Dim sno, sn As Integer
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ShopManagementDataSet.Bill' table. You can move, or remove it, as needed.
        '  Me.BillTableAdapter.Fill(Me.ShopManagementDataSet.Bill)
        connect()
        cmd.CommandText = "select count (*) from Bill"
        cnt = cmd.ExecuteScalar()
        discon()
        If cnt = 0 Then
            sno = 1
        Else
            connect()
            cmd.CommandText = "select max (sno) from Bill"
            cnt = cmd.ExecuteScalar()
            discon()
            sno = cnt + 1
        End If
        TextBox1.Text = sno
        TextBox2.Text = Today
        sn = 1
        TextBox8.Text = sn
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox4.TextLength = 0 Then
            MsgBox("Enter the name.", MsgBoxStyle.Critical, "Error")
            TextBox4.Focus()
        ElseIf DateTimePicker1.Value.Date >= Today Then
            MsgBox("Enter the correct DOB.", MsgBoxStyle.Critical, "Error")
            DateTimePicker1.Value = Today
            DateTimePicker1.Focus()
        ElseIf TextBox6.TextLength = 0 Then
            MsgBox("Enter the address.", MsgBoxStyle.Critical, "Error")
            TextBox6.Focus()
        ElseIf TextBox7.TextLength = 0 Then
            MsgBox("Enter the mobile no.", MsgBoxStyle.Critical, "Error")
            TextBox7.Focus()
        ElseIf Not IsNumeric(TextBox7.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox7.Clear()
            TextBox7.Focus()
        ElseIf TextBox9.TextLength = 0 Then
            MsgBox("Enter the item name.", MsgBoxStyle.Critical, "Error")
            TextBox9.Focus()
        ElseIf TextBox12.TextLength = 0 Then
            MsgBox("Enter the item type.", MsgBoxStyle.Critical, "Error")
            TextBox12.Focus()
        ElseIf TextBox10.TextLength = 0 Then
            MsgBox("Enter the qty.", MsgBoxStyle.Critical, "Error")
            TextBox10.Focus()
        ElseIf Not IsNumeric(TextBox10.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox10.Clear()
            TextBox10.Focus()
        ElseIf TextBox11.TextLength = 0 Then
            MsgBox("Enter the price.", MsgBoxStyle.Critical, "Error")
            TextBox11.Focus()
        ElseIf Not IsNumeric(TextBox11.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox11.Clear()
            TextBox11.Focus()
        Else
            Dim bno, qty, price, total As Integer
            Dim dt, place, cnm, dob, adds, itnm, type As String
            Dim mob As Long
            bno = TextBox1.Text
            dt = TextBox2.Text
            place = TextBox3.Text
            cnm = TextBox4.Text
            dob = DateTimePicker1.Value.Date
            adds = TextBox6.Text
            mob = TextBox7.Text
            sn = TextBox8.Text
            itnm = TextBox9.Text
            qty = TextBox10.Text
            price = TextBox11.Text
            type = TextBox12.Text
            total = qty * price
            connect()
            cmd.CommandText = "insert into Bill values(" & sno & "," & bno & ",'" & dt & "','" & place & "','" & cnm & "','" & dob & "','" & adds & "'," & mob & "," & sn & ",'" & itnm & "','" & type & "'," & qty & "," & price & "," & total & ")"
            cmd.ExecuteNonQuery()
            discon()
            Dim da As New SqlDataAdapter
            Dim ds As New Data.DataSet
            connect()
            cmd.CommandText = "select * from Bill where bno=" & bno & ""
            da.SelectCommand = cmd
            da.Fill(ds, "Bill")
            Me.DataGridView1.DataSource = ds
            Me.DataGridView1.DataMember = "Bill"
            discon()
            Button5.Enabled = False
            Button2.Enabled = False
            Dim result As DialogResult
            MsgBox("Item added successfully.", MsgBoxStyle.Information, "Information")
            result = MsgBox("Won't to add more item?", MsgBoxStyle.YesNo, "Conformation")
            If result = Windows.Forms.DialogResult.Yes Then
                sn = sn + 1
                TextBox8.Text = sn
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox4.ReadOnly = True
                TextBox6.ReadOnly = True
                TextBox7.ReadOnly = True
                DateTimePicker1.Enabled = False
                TextBox9.Focus()
            Else
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox8.ReadOnly = True
                TextBox9.ReadOnly = True
                TextBox10.ReadOnly = True
                TextBox11.ReadOnly = True
                TextBox12.ReadOnly = True
                TextBox4.ReadOnly = True
                TextBox6.ReadOnly = True
                TextBox7.ReadOnly = True
                Button1.Enabled = False
                Button3.Enabled = True
                DateTimePicker1.Enabled = False
                Button3.Focus()
            End If
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        DateTimePicker1.Value = Today
        TextBox4.Focus()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class