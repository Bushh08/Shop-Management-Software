Imports System.Data.SqlClient
Public Class Delete_bill

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox2.Enabled = False
        Button2.Enabled = False
        TextBox1.Enabled = True
        Button1.Enabled = True
        TextBox1.Focus()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.TextLength = 0 Then
            MsgBox("Enter the bill no.", MsgBoxStyle.Critical, "Error")
            TextBox1.Focus()
        ElseIf Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox1.Clear()
            TextBox1.Focus()

        Else
            Dim bill As Integer
            bill = TextBox1.Text
            connect()
            cmd.CommandText = "select *from Bill where bno =" & bill
            reader = cmd.ExecuteReader()
            If reader.HasRows = False Then
                MsgBox("Record not found ", MsgBoxStyle.Critical, "error ")
                TextBox1.Clear()
                TextBox1.Focus()
                discon()
            Else
                discon()
                connect()
                cmd.CommandText = "select * from Bill where bno = " & bill
                reader = cmd.ExecuteReader()
                reader.Read()

                TextBox8.Text = reader.Item("bno")
                TextBox5.Text = reader.Item("dt")
                TextBox3.Text = reader.Item("place")
                TextBox4.Text = reader.Item("cnm")
                TextBox9.Text = reader.Item("dob")
                TextBox6.Text = reader.Item("adds")
                TextBox7.Text = reader.Item("cout")
                discon()

                Dim da As New SqlDataAdapter
                Dim ds As New Data.DataSet
                connect()
                cmd.CommandText = "select * from Bill where bno=" & bill
                da.SelectCommand = cmd
                da.Fill(ds, "Bill")
                Me.DataGridView1.DataSource = ds
                Me.DataGridView1.DataMember = "Bill"
                discon()
                Button3.Enabled = True
                Button4.Enabled = True
                Button3.Focus()
            End If
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.TextLength = 0 Then
            MsgBox("Enter the mobile no.", MsgBoxStyle.Critical, "Error")
            TextBox2.Focus()
        ElseIf Not IsNumeric(TextBox2.Text) Then
            MsgBox("Enter the numeric value.", MsgBoxStyle.Critical, "Error")
            TextBox2.Clear()
            TextBox2.Focus()

        Else
            Dim mob As Long
            mob = TextBox2.Text
            connect()
            cmd.CommandText = "select * from Bill where cout = " & mob
            reader = cmd.ExecuteReader()
            If reader.HasRows = False Then
                MsgBox("Record not found.", MsgBoxStyle.Critical, "Error")
                TextBox2.Clear()
                TextBox2.Focus()
                discon()
            Else

                discon()

                mob = TextBox2.Text
                connect()
                cmd.CommandText = "select * from Bill where cout = " & mob
                reader = cmd.ExecuteReader()
                reader.Read()

                TextBox8.Text = reader.Item("bno")
                TextBox5.Text = reader.Item("dt")
                TextBox3.Text = reader.Item("place")
                TextBox4.Text = reader.Item("cnm")
                TextBox9.Text = reader.Item("dob")
                TextBox6.Text = reader.Item("adds")
                TextBox7.Text = reader.Item("cout")
                discon()

                Dim da As New SqlDataAdapter
                Dim ds As New Data.DataSet
                connect()
                cmd.CommandText = "select * from Bill where cout=" & mob
                da.SelectCommand = cmd
                da.Fill(ds, "Bill")
                Me.DataGridView1.DataSource = ds
                Me.DataGridView1.DataMember = "Bill"
                discon()

                Button3.Enabled = True
                Button4.Enabled = True
                Button3.Focus()


            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        Button3.Enabled = False
        Button4.Enabled = False
        DataGridView1.DataSource = Nothing
        RadioButton1.Checked = True
        TextBox1.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MsgBox("Are you sure, want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Warning")
        If result = Windows.Forms.DialogResult.Yes Then
            Dim bill As Integer
            bill = TextBox8.Text
            connect()
            cmd.CommandText = "delete from Bill where bno = " & bill
            cmd.ExecuteNonQuery()
            discon()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            Button3.Enabled = False
            Button4.Enabled = False
            DataGridView1.DataSource = Nothing
            RadioButton1.Checked = True
            MsgBox("Record deleted successfully.", MsgBoxStyle.Information, "Information")
            TextBox1.Focus()
        Else
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            Button3.Enabled = False
            Button4.Enabled = False
            DataGridView1.DataSource = Nothing
            RadioButton1.Checked = True
            TextBox1.Focus()
        End If
        If result = Windows.Forms.DialogResult.Yes Then
            Dim mob As Long
            mob = TextBox8.Text
            connect()
            cmd.CommandText = "delete from Bill where mob = " & mob
            cmd.ExecuteNonQuery()
            discon()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            Button3.Enabled = False
            Button4.Enabled = False
            DataGridView1.DataSource = Nothing
            RadioButton2.Checked = True
            MsgBox("Record deleted successfully.", MsgBoxStyle.Information, "Information")
            TextBox2.Focus()
        Else
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            Button3.Enabled = False
            Button4.Enabled = False
            DataGridView1.DataSource = Nothing
            RadioButton2.Checked = True
            TextBox2.Focus()
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Delete_bill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Main.Show()
    End Sub

    Private Sub Delete_bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ShopManagementDataSet6.Bill' table. You can move, or remove it, as needed.
        ' Me.BillTableAdapter1.Fill(Me.ShopManagementDataSet6.Bill)
        'TODO: This line of code loads data into the 'ShopManagementDataSet2.Bill' table. You can move, or remove it, as needed.
        ' Me.BillTableAdapter.Fill(Me.ShopManagementDataSet2.Bill)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class



