Imports System.Data.Odbc

Public Class Journal
    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Private Sub Kembali_Click(sender As Object, e As EventArgs) Handles Kembali.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Journal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayJournalData()
    End Sub

    Private Sub DisplayJournalData()
        Try
            ' Membuka koneksi ke database
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                ' Query untuk mendapatkan seluruh data dari tabel journal
                Dim query As String = "SELECT * FROM journals"
                Using command As New OdbcCommand(query, connection)

                    ' Membuat DataTable untuk menampung hasil query
                    Dim table As New DataTable()

                    ' Membuat adapter untuk mengisi DataTable
                    Dim adapter As New OdbcDataAdapter(command)
                    adapter.Fill(table)

                    ' Menetapkan DataTable sebagai sumber data DataGridView
                    DataGridView1.DataSource = table
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class