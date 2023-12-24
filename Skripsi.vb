Imports System.Data.Odbc

Public Class Skripsi

    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Skripsi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRepositoryData()
    End Sub

    Private Sub LoadRepositoryData()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM repository"
                Using command As New OdbcCommand(query, connection)
                    ' Membuat DataTable untuk menampung hasil query
                    Dim table As New DataTable()

                    ' Membuat adapter untuk mengisi DataTable
                    Dim adapter As New OdbcDataAdapter(command)
                    adapter.Fill(table)

                    ' Menetapkan DataTable sebagai sumber data DataGridView1
                    DataGridView1.DataSource = table
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class