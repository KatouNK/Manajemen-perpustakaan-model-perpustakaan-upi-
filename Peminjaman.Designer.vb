<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Peminjaman
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Peminjaman))
        ButtonSearch = New Button()
        TextBoxSearch = New TextBox()
        DataGridViewBooks = New DataGridView()
        TextBoxNIM = New TextBox()
        ButtonPinjam = New Button()
        Label1 = New Label()
        Button1 = New Button()
        CType(DataGridViewBooks, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.Location = New Point(675, 87)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(75, 23)
        ButtonSearch.TabIndex = 0
        ButtonSearch.Text = "cari"
        ButtonSearch.UseVisualStyleBackColor = True
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(49, 88)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(611, 23)
        TextBoxSearch.TabIndex = 1
        ' 
        ' DataGridViewBooks
        ' 
        DataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewBooks.Location = New Point(49, 130)
        DataGridViewBooks.Name = "DataGridViewBooks"
        DataGridViewBooks.RowTemplate.Height = 25
        DataGridViewBooks.Size = New Size(701, 196)
        DataGridViewBooks.TabIndex = 2
        ' 
        ' TextBoxNIM
        ' 
        TextBoxNIM.Location = New Point(58, 344)
        TextBoxNIM.Name = "TextBoxNIM"
        TextBoxNIM.Size = New Size(265, 23)
        TextBoxNIM.TabIndex = 3
        ' 
        ' ButtonPinjam
        ' 
        ButtonPinjam.Location = New Point(336, 344)
        ButtonPinjam.Name = "ButtonPinjam"
        ButtonPinjam.Size = New Size(75, 23)
        ButtonPinjam.TabIndex = 4
        ButtonPinjam.Text = "Pinjam"
        ButtonPinjam.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(40, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(206, 32)
        Label1.TabIndex = 5
        Label1.Text = "Peminjaman Buku"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(675, 403)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 6
        Button1.Text = "Kembali"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Peminjaman
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(ButtonPinjam)
        Controls.Add(TextBoxNIM)
        Controls.Add(DataGridViewBooks)
        Controls.Add(TextBoxSearch)
        Controls.Add(ButtonSearch)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Peminjaman"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Peminjaman"
        CType(DataGridViewBooks, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonSearch As Button
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents DataGridViewBooks As DataGridView
    Friend WithEvents TextBoxNIM As TextBox
    Friend WithEvents ButtonPinjam As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
