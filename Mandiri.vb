Imports System.Data.Odbc
Imports Microsoft.Web.WebView2.WinForms

Public Class Mandiri
    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Private Sub Mandiri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView21.Source = New Uri("https://perpustakaan.upi.edu/layanan-mandiri/")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Peminjaman.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nim As String = InputBox("Masukkan NIM:", "Pengembalian Buku")

        ' Cek apakah NIM valid (tidak kosong)
        If Not String.IsNullOrWhiteSpace(nim) Then
            ' Melakukan proses pengembalian buku berdasarkan NIM
            ProsesPengembalian(nim)
        Else
            MessageBox.Show("NIM tidak valid.", "Pengembalian Buku")
        End If
    End Sub

    Private Sub ProsesPengembalian(nim As String)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                ' Cari data peminjaman berdasarkan NIM
                Dim queryPeminjaman As String = "SELECT peminjaman_id, book_id, tanggal_pinjam FROM peminjaman WHERE nim = ?"
                Using commandPeminjaman As New OdbcCommand(queryPeminjaman, connection)
                    commandPeminjaman.Parameters.AddWithValue("@nim", nim)

                    ' Membuat DataTable untuk menampung hasil query
                    Dim tablePeminjaman As New DataTable()

                    ' Membuat adapter untuk mengisi DataTable
                    Dim adapterPeminjaman As New OdbcDataAdapter(commandPeminjaman)
                    adapterPeminjaman.Fill(tablePeminjaman)

                    ' Cek apakah ada data peminjaman untuk NIM tersebut
                    If tablePeminjaman.Rows.Count > 0 Then
                        ' Melakukan pengembalian untuk setiap peminjaman
                        For Each row As DataRow In tablePeminjaman.Rows
                            Dim peminjamanId As Integer = Convert.ToInt32(row("peminjaman_id"))
                            Dim bookId As Integer = Convert.ToInt32(row("book_id"))
                            Dim tanggalPinjam As DateTime = Convert.ToDateTime(row("tanggal_pinjam"))

                            ' Hitung denda jika pengembalian terlambat
                            Dim denda As Decimal = HitungDenda(tanggalPinjam)

                            ' Mengubah status buku menjadi "Dikembalikan" pada tabel books
                            UpdateBooksStatus(bookId, "Dikembalikan")

                            ' Menghapus data peminjaman dari tabel peminjaman
                            DeleteFromPeminjaman(peminjamanId)

                            ' Menambah data pengembalian pada tabel pengembalian_buku
                            InsertIntoPengembalian(peminjamanId, Date.Now, denda)
                        Next

                        MessageBox.Show("Pengembalian buku berhasil.", "Pengembalian Buku")
                    Else
                        MessageBox.Show("Data peminjaman tidak ditemukan untuk NIM tersebut.", "Pengembalian Buku")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Pengembalian Buku")
        End Try
    End Sub

    Private Sub InsertIntoPengembalian(idPeminjaman As Integer, tanggalPengembalian As Date, denda As Decimal)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim insertQuery As String = "INSERT INTO pengembalian_buku (id_peminjaman, tanggal_pengembalian, denda) VALUES (?, ?, ?)"
                Using command As New OdbcCommand(insertQuery, connection)
                    command.Parameters.AddWithValue("@id_peminjaman", idPeminjaman)
                    command.Parameters.AddWithValue("@tanggal_pengembalian", tanggalPengembalian)
                    command.Parameters.AddWithValue("@denda", denda)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting data into pengembalian_buku: " & ex.Message)
        End Try
    End Sub


    Private Sub UpdateBooksStatus(bookId As Integer, newStatus As String)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim updateQuery As String = "UPDATE books SET status = ? WHERE book_id = ?"
                Using command As New OdbcCommand(updateQuery, connection)
                    command.Parameters.AddWithValue("@status", newStatus)
                    command.Parameters.AddWithValue("@book_id", bookId)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status in books: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteFromPeminjaman(peminjamanId As Integer)
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim deleteQuery As String = "DELETE FROM peminjaman WHERE peminjaman_id = ?"
                Using command As New OdbcCommand(deleteQuery, connection)
                    command.Parameters.AddWithValue("@peminjaman_id", peminjamanId)

                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting data from peminjaman: " & ex.Message)
        End Try
    End Sub

    Private Function HitungDenda(tanggalPinjam As DateTime) As Decimal
        ' Implementasikan logika perhitungan denda di sini
        ' Misalnya, hitung selisih hari dan kalikan dengan tarif denda per hari
        Return 0
    End Function

End Class