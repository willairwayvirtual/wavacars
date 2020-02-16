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

    Private Sub StFlight_Click(sender As Object, e As EventArgs) Handles StFlight.Click
        If Timer1.Enabled = True Then
            Timer1.Stop()

        Else
            time = DateTime.Now
            Timer1.Start()

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim difference As TimeSpan = DateTime.Now.Subtract(time)
        lblTimer.Text = difference.Hours.ToString & ":" &
            difference.Minutes.ToString & ":" &
            difference.Seconds.ToString
    End Sub

    Private Sub CompFlight_Click(sender As Object, e As EventArgs) Handles CompFlight.Click
        Timer1.Stop()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Close()
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "C:\VisStudioProj\wav web\willairwayvirtual34\willairwayvirtual34\app_data\willairwayvirtualDBv1.accdb"
        connString = provider & dataFile
        conn.ConnectionString = connString
        'check status of connection string
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        Else
            conn.Close()
        End If
        Dim savenew As String = "INSERT INTO [acars_log]  (Fltnum,lblTimer,Uname) values('" &
            TextBox1.Text & "','" &
            lblTimer.Text & "','" &
        Uname.Text & "');"





        Dim cmd As New OleDbCommand

        With cmd
            .CommandText = savenew
            .Connection = conn
            .ExecuteNonQuery()
        End With
        MessageBox.Show("Hours saved Have a good day")
    End Sub

End Class