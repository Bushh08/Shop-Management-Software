Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public reader As SqlDataReader
    Public cnt As Short
    Sub connect()
        con.ConnectionString = "Data Source=.;Initial Catalog=ShopManagement;user Id=sa;Password=1234"
        con.Open()
        cmd.Connection = con
    End Sub
    Sub discon()
        con.Close()
    End Sub
End Module
