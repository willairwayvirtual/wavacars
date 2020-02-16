Imports System.Data.OleDb
Public Class screen2
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim time As New DateTime

    Dim conn As OleDbConnection = New OleDbConnection
    Public Property stringtext1 As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = stringtext1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "d:\VisStudioProj\wav web\willairwayvirtual34\willairwayvirtual34\app_data\willairwayvirtualDBv1.accdb"
        connString = provider & dataFile
        conn.ConnectionString = connString
        'check status of connection string
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        Else
            conn.Close()
        End If

        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        Dim da As New OleDbDataAdapter

        da = New OleDbDataAdapter("Select * from flightplan WHERE [fltnum] = '" & TextBox1.Text & "' or [Deptair] = '" & TextBox2.Text & "'", conn)
        da.Fill(dt)

        DataGridView1.DataSource = dt.DefaultView
        conn.Close()
    End Sub
End Class