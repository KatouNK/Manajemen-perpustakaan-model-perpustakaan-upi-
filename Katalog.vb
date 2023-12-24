Imports System.Data.Odbc

Public Class Katalog

    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Dim connection As New OdbcConnection(connectionString)


    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim query As String = "SELECT * FROM books WHERE 
                        (Title LIKE ? OR Author LIKE ? OR ISBN LIKE ?)"
        Dim adapter As New OdbcDataAdapter(query, connection)

        Dim searchKeyword As String = txtSearch.Text
        Dim searchPattern As String = $"%{searchKeyword}%"

        adapter.SelectCommand.Parameters.AddWithValue("param1", searchPattern)
        adapter.SelectCommand.Parameters.AddWithValue("param2", searchPattern)
        adapter.SelectCommand.Parameters.AddWithValue("param3", searchPattern)


        connection.Open()

        Dim ds As New DataSet()
        adapter.Fill(ds, "Books")


        DataGridView1.DataSource = ds.Tables("Books")


        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Katalog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class