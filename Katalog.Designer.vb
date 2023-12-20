<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Katalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        txtSearch = New TextBox()
        btnSearch = New Button()
        Button2 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(39, 90)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(727, 277)
        DataGridView1.TabIndex = 0
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(39, 50)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(646, 23)
        txtSearch.TabIndex = 1
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(691, 50)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 2
        btnSearch.Text = "search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(39, 393)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 3
        Button2.Text = "Kembali"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Katalog
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(DataGridView1)
        Name = "Katalog"
        Text = "Katalog Buku"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Button2 As Button
End Class
