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

        'Dim myconnect As New SqlClient.SqlConnection
        '[myconnect.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DB\InvDB.mdf;Integrated Security=True;User Instance=True"

        Dim mycommand As MySql.Data.MySqlClient.MySqlCommand = New MySql.Data.MySqlClient.MySqlCommand

        'Dim mycommand As mySqlClient.mySqlCommand = New SqlClient.SqlCommand()

        myconnection.ConnectionString = connStr.ConnectionString

        mycommand.CommandText = "INSERT INTO postcodes (index, postcode, codeareadescription VALUES (@index, @postcode, @codeareadescription)"
        myconnection.Open()

        Try
            mycommand.Parameters.Add("@index", SqlDbType.Int).Value = 1%
            mycommand.Parameters.Add("@postcode", SqlDbType.NVarChar).Value = "abc"
            mycommand.Parameters.Add("@codeareadescription", SqlDbType.NVarChar).Value = "def"
            numberofins = mycommand.ExecuteNonQuery()
            MsgBox("Success")
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message)
        End Try
        myconnection.Close()



    End Sub
End Class