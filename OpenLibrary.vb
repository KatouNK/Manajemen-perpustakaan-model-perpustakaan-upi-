Imports System.Data.Odbc

Public Class OpenLibrary

    Dim connectionString As String = "Dsn=Manajemen Perpustakaan;uid=root;database=manajement perpustakaan;db=manajement perpustakaan;no_schema=1;port=3306;user=root"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
    End Sub

End Class