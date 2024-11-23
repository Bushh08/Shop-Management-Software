Imports System.Data.SqlClient
Public Class Invoice

    Private Sub Invoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Generate_Bill.Close()
        Duplicate_Bill.Close()
        Main.Show()
    End Sub

    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim da As New SqlDataAdapter
        Dim ds As New Data.DataSet
        Dim report As New CrystalReport3
        connect()
        cmd.CommandText = "select * from Bill where bno=" & Generate_Bill.bno & " or bno=" & Duplicate_Bill.bno1
        da.SelectCommand = cmd
        da.Fill(ds, "Bill")
        report.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = report
        discon()
    End Sub
End Class