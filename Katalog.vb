Imports System.Data.Odbc

Public Class Katalog

    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Dim connection As New OdbcConnection(connectionString)
    Private Sub LoadBooks()
        ' Ambil data buku dari database.
        Dim query As String = "SELECT * FROM books"
        Dim adapter As New OdbcDataAdapter(query, connection)
        Dim ds As New DataSet()
        adapter.Fill(ds, "Books")

        ' Tampilkan data dalam DataGridView.
        DataGridView1.DataSource = ds.Tables("Books")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        ' Cari buku berdasarkan kriteria yang dimasukkan.
        Dim query As String = "SELECT * FROM books WHERE 
                            (Title LIKE '%' + ? + '%' OR Author LIKE '%' + ? + '%' OR ISBN LIKE '%' + ? + '%')"
        Dim adapter As New OdbcDataAdapter(query, connection)

        ' Parameterized queries untuk menghindari SQL injection.
        Dim searchKeyword As String = txtSearch.Text
        adapter.SelectCommand.Parameters.AddWithValue("param1", searchKeyword)
        adapter.SelectCommand.Parameters.AddWithValue("param2", searchKeyword)
        adapter.SelectCommand.Parameters.AddWithValue("param3", searchKeyword)

        Dim ds As New DataSet()
        adapter.Fill(ds, "Books")

        ' Tampilkan hasil pencarian dalam DataGridView.
        DataGridView1.DataSource = ds.Tables("Books")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class