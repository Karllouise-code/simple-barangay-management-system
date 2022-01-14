Imports System.Data.OleDb
Module connection
    Public con As New OleDbConnection
    Public query As New OleDbCommand
    Public adapter As New OleDb.OleDbDataAdapter(query)
    Public dt As New DataTable
    Public dr As OleDbDataReader

    Sub OpenCon()
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\karll\source\repos\simple-barangay-system\bin\Debug\barangaydb.mdb;"
        con.Open()
    End Sub
End Module
