Imports System.Data.Odbc

Public Class Form1
    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Katalog.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Mandiri.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private originalText As String

    Private Sub SetTextBoxTextBasedOnCheckBoxes()
        If CheckBox1.Checked Then
            TextBox1.Text = "Cari buku"
        ElseIf CheckBox2.Checked Then
            TextBox1.Text = "Cari repository"
        ElseIf CheckBox3.Checked Then
            TextBox1.Text = "Cek peminjaman"
        ElseIf CheckBox4.Checked Then
            TextBox1.Text = "Cari oalib"
        End If
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Cari buku" OrElse TextBox1.Text = "Cari repository" OrElse TextBox1.Text = "Cek peminjaman" OrElse TextBox1.Text = "Cari oalib" Then
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Regular)
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            SetTextBoxTextBasedOnCheckBoxes()
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
            TextBox1.ForeColor = Color.DimGray
        Else
            ' Simpan teks asli ketika TextBox memiliki konten
            originalText = TextBox1.Text
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.Text = "Cari buku"
            originalText = TextBox1.Text
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            TextBox1.Text = "Cari repository"
            originalText = TextBox1.Text
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            TextBox1.Text = "Cek peminjaman"
            originalText = TextBox1.Text
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            TextBox1.Text = "Cari oalib"
            originalText = TextBox1.Text
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked AndAlso Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            Dim katalogForm As New Katalog()
            katalogForm.txtSearch.Text = TextBox1.Text
            katalogForm.Show()
        ElseIf CheckBox2.Checked Then
            Dim keyword As String = TextBox1.Text.Trim()

            Try
                Using connection As New OdbcConnection(connectionString)
                    connection.Open()

                    Dim query As String = "SELECT * FROM repository " &
                                          "WHERE judul_skripsi LIKE ? OR penulis LIKE ? OR tahun_terbit = ? OR penerbit LIKE ? OR abstrak LIKE ?"
                    Using command As New OdbcCommand(query, connection)
                        ' Parameterisasi query untuk mencegah SQL injection
                        command.Parameters.AddWithValue("@judul_skripsi", "%" & keyword & "%")
                        command.Parameters.AddWithValue("@penulis", "%" & keyword & "%")
                        command.Parameters.AddWithValue("@tahun_terbit", keyword)
                        command.Parameters.AddWithValue("@penerbit", "%" & keyword & "%")
                        command.Parameters.AddWithValue("@abstrak", "%" & keyword & "%")

                        ' Membuat DataTable untuk menampung hasil query
                        Dim table As New DataTable()

                        ' Membuat adapter untuk mengisi DataTable
                        Dim adapter As New OdbcDataAdapter(command)
                        adapter.Fill(table)

                        ' Membuka form SkripsiForm dan menetapkan DataTable sebagai sumber data DataGridView
                        Dim skripsiForm As New Skripsi()
                        skripsiForm.DataGridView1.DataSource = table
                        skripsiForm.Show()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        ElseIf CheckBox3.Checked Then
            Dim nim As String = TextBox1.Text.Trim()

            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT books.title, peminjaman.tanggal_pinjam
                                   FROM peminjaman
                                   INNER JOIN books ON peminjaman.book_id = books.book_id
                                   WHERE peminjaman.nim = ?"
                Using command As New OdbcCommand(query, connection)
                    command.Parameters.AddWithValue("@nim", nim)

                    ' Membuat DataTable untuk menampung hasil query
                    Dim table As New DataTable()

                    ' Membuat adapter untuk mengisi DataTable
                    Dim adapter As New OdbcDataAdapter(command)
                    adapter.Fill(table)

                    ' Menampilkan hasil query dalam MessageBox
                    Dim result As String = "Buku yang dipinjam oleh mahasiswa dengan NIM " & nim & ":" & Environment.NewLine
                    For Each row As DataRow In table.Rows
                        result &= $"Title: {row("title")}, Tanggal Pinjam: {row("tanggal_pinjam")}" & Environment.NewLine
                    Next

                    MessageBox.Show(result, "Data Peminjaman")
                End Using
            End Using
        ElseIf CheckBox4.Checked Then
            Dim keyword As String = TextBox1.Text.Trim()

            Try
                Using connection As New OdbcConnection(connectionString)
                    connection.Open()

                    Dim query As String = "SELECT * FROM open_access_library " &
                  "WHERE title LIKE ? OR author LIKE ? OR document_id = ?"
                    Using command As New OdbcCommand(query, connection)
                        ' Parameterisasi query untuk mencegah SQL injection
                        command.Parameters.AddWithValue("@title", "%" & keyword & "%")
                        command.Parameters.AddWithValue("@author", "%" & keyword & "%")
                        ' Parameter untuk document_id
                        command.Parameters.AddWithValue("@document_id", keyword)

                        ' Membuat DataTable untuk menampung hasil query
                        Dim table As New DataTable()

                        ' Membuat adapter untuk mengisi DataTable
                        Dim adapter As New OdbcDataAdapter(command)
                        adapter.Fill(table)

                        ' Membuka form OpenLibraryForm dan menetapkan DataTable sebagai sumber data DataGridView
                        Dim openLibraryForm As New OpenLibrary()
                        openLibraryForm.DataGridView1.DataSource = table
                        openLibraryForm.Show()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Journal.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Skripsi.Show()
        Me.Hide()
    End Sub
End Class
