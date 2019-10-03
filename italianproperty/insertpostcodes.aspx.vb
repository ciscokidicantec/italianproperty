Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web


Public Class insertpostcodes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim numberofins As Integer = 0%

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")
        myconnection.ConnectionString = connStr.ToString

        Dim mycommand As MySql.Data.MySqlClient.MySqlCommand = New MySql.Data.MySqlClient.MySqlCommand()
        mycommand.CommandText = "INSERT INTO postcodes VALUES ('@indexpostcode','@postcode', '@codeareadescription')"
        mycommand.Connection = myconnection

        'mycommand.CommandText = "INSERT INTO 'postcodes' ('index', 'postcode', 'codeareadescription' VALUES (51, 'FY', 'Fylde')"
        'mycommand.CommandText = "INSERT INTO 'postcodes' ('index', 'postcode', 'codeareadescription' VALUES (51, 'FY', 'Fylde')"

        ' Dim query As String = "INSERT INTO [PHONE DIRECTORY] VALUES(@id, @description)"
        'Dim command As New SqlCommand(query, conn)


        Try
            myconnection.Open()

            '            mycommand.Parameters.Add("@index", SqlDbType.Int).Value = Convert.ToInt32(5)
            mycommand.Parameters.Add("@indexpostcode", SqlDbType.Int).Value = Convert.ToInt32(2%)
            mycommand.Parameters.Add("@postcode", SqlDbType.NVarChar).Value = "FY"
            mycommand.Parameters.Add("@codeareadescription", SqlDbType.NVarChar).Value = "FYLDE"


            ' mycommand.Parameters.AddWithValue("@index", 50%)
            'mycommand.Parameters.AddWithValue("@postcode", "FN")
            'mycommand.Parameters.AddWithValue("@codeareadescription", "Fylde")
            numberofins = mycommand.ExecuteNonQuery()
            MsgBox("Success")
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message)
        End Try

        myconnection.Close()

    End Sub
End Class