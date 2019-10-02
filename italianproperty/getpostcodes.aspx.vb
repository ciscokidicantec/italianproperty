Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class getpostcodes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")
        Dim sqlquery As String = "SELECT * FROM estate"
        Dim data As MySqlDataReader
        Dim secondreader As MySqlDataReader

        Dim secondconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection

        myconnection.ConnectionString = connStr.ToString
        secondconnection.ConnectionString = connStr.ToString


        Try
            secondconnection.Open()
            Dim command As New MySqlCommand
            command.Connection = secondconnection
            command.CommandText = sqlquery
            secondreader = command.ExecuteReader()

            GridView3.DataSource = secondreader
            GridView3.DataBind()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        secondconnection.Close()

        Try
            myconnection.Open()
            Dim command As New MySqlCommand
            command.Connection = myconnection
            command.CommandText = sqlquery
            data = command.ExecuteReader()

            Dim dt As New DataTable

            dt.Columns.Add("First Name", GetType(String))
            dt.Columns.Add("Last Name", GetType(String))

            While data.Read
                If data.HasRows = True Then
                    ListBox1.Items.Add("First Name = " + data(2).ToString + "   " + "Last Name = " + data(4).ToString)
                    dt.Rows.Add(data(2).ToString, data(4).ToString)
                End If
            End While

            GridView2.DataSource = dt
            GridView2.DataBind()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        myconnection.Close()

    End Sub
End Class