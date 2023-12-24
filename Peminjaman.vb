Imports System.Data.Odbc

Public Class Peminjaman
    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"

    Private Sub PeminjamanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil metode untuk mengisi DataGridView dengan data buku
        LoadBookData()
    End Sub

    Private Sub LoadBookData()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM books"
                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)

                DataGridViewBooks.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        ' Metode untuk mencari buku berdasarkan judul
        SearchBook()
    End Sub

    Private Sub SearchBook()
        Try
            Dim searchKeyword As String = TextBoxSearch.Text.Trim()

            If Not String.IsNullOrEmpty(searchKeyword) Then
                Using connection As New OdbcConnection(connectionString)
                    connection.Open()

                    Dim query As String = "SELECT * FROM books WHERE title LIKE ?"
                    Dim adapter As New OdbcDataAdapter(query, connection)
                    Dim command As New OdbcCommand(query, connection)
                    command.Parameters.AddWithValue("@title", "%" & searchKeyword & "%")

                    Dim table As New DataTable()
                    adapter.SelectCommand = command
                    adapter.Fill(table)

                    DataGridViewBooks.DataSource = table
                End Using
            Else
                ' Jika pencarian kosong, tampilkan semua buku
                LoadBookData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonPinjam_Click(sender As Object, e As EventArgs) Handles ButtonPinjam.Click
        Try
            Dim nim As String = TextBoxNIM.Text
            Dim bookID As Integer = Convert.ToInt32(DataGridViewBooks.CurrentRow.Cells("book_id").Value)

            ' Perbarui status buku menjadi "Dipinjam"
            UpdateBookStatus(bookID, "Dipinjam")

            ' Simpan data peminjaman ke database
            InsertPeminjaman(nim, bookID)

            MessageBox.Show("Buku berhasil dipinjam!")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateBookStatus(bookID As Integer, status As String)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim updateQuery As String = "UPDATE books SET status = ? WHERE book_id = ?"
                Using command As New OdbcCommand(updateQuery, connection)
                    command.Parameters.AddWithValue("@status", status)
                    command.Parameters.AddWithValue("@book_id", bookID)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertPeminjaman(nim As String, bookID As Integer)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim insertQuery As String = "INSERT INTO peminjaman (nim, book_id, tanggal_pinjam) VALUES (?, ?, ?)"
                Using command As New OdbcCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@nim", nim)
                    command.Parameters.AddWithValue("@book_id", bookID)
                    command.Parameters.AddWithValue("@tanggal_pinjam", DateTime.Now)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class
