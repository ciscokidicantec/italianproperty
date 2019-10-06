Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web


Public Class insertpostcodes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myerrors As String = ""

        Dim numberofins As Integer = 0%

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")
        myconnection.ConnectionString = connStr.ToString

        Dim mycommand As MySql.Data.MySqlClient.MySqlCommand = New MySql.Data.MySqlClient.MySqlCommand()

        Dim firstpcpos As Integer = 0%
        Dim lastpcpos As Integer = 0%

        Dim pcstring As String = ""
        Dim placestring As String = ""

        Dim app_path = HttpContext.Current.Server.MapPath("~/App_Data/pc.txt")

        Dim variableins As String = "36333333"
        Dim pccode As String = ""
        Dim pccodedescription As String = ""

        Dim readsinallfiledata As String()

        Dim pcindex As Integer = 0%

        Dim insrttext As String = ""

        readsinallfiledata = File.ReadAllLines(app_path)
        For Each wholelinearray In readsinallfiledata
            ListBox2.Items.Add(wholelinearray.TrimEnd)
        Next

        'Return

        mycommand.Connection = myconnection

        Try
            myconnection.Open()

            For Each line As String In File.ReadLines(app_path)
                pcindex += 1%
                firstpcpos = InStr(line, " ")
                pccode = line.TrimEnd.ToString().Substring(0%, firstpcpos%)
                pccodedescription = line.TrimEnd.ToString().Substring(firstpcpos%, Len(line) - firstpcpos)
                insrttext = "INSERT INTO `estateporrtal`.`postcodes` (`indexpostcode`,`postcode`,`codeareadescription`) VALUES ('" & pcindex & "','" & pccode & "', '" & pccodedescription & "');"
                mycommand.CommandText = insrttext
                ListBox1.Items.Add(line.TrimEnd)
                numberofins = mycommand.ExecuteNonQuery()
            Next
        Catch ex As MySql.Data.MySqlClient.MySqlException
            myerrors = ex.Number
            'MsgBox(ex.Message & "  Error Number =  " & ex.Number)
        End Try


        'Dim insrttext As String = "INSERT INTO `estateporrtal`.`postcodes` (`indexpostcode`,`postcode`,`codeareadescription`) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "', '" & variableins & "');"
        'Dim insrttext As String = "INSERT INTO `estateporrtal`.`postcodes` (`indexpostcode`,`postcode`,`codeareadescription`) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "');"

        myconnection.Close()


        Return

        mycommand.CommandText = insrttext
        mycommand.Connection = myconnection

        Try
            myconnection.Open()

            'mycommand.Parameters.Add("@index", SqlDbType.Int).Value = Convert.ToInt32(5)
            'mycommand.Parameters.Add("@indexpostcode", SqlDbType.Int).Value = Convert.ToInt32(2%)
            'mycommand.Parameters.Add("@postcode", SqlDbType.NVarChar).Value = "FY"
            'mycommand.Parameters.Add("@codeareadescription", SqlDbType.NVarChar).Value = "FYLDE"


            ' mycommand.Parameters.AddWithValue("@index", 50%)
            'mycommand.Parameters.AddWithValue("@postcode", "FN")
            'mycommand.Parameters.AddWithValue("@codeareadescription", "Fylde")
            'mycommand.CommandText = "INSERT INTO postcodes VALUES ('@indexpostcode','@postcode', '@codeareadescription')"


            numberofins = mycommand.ExecuteNonQuery()
            MsgBox("Success")
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message)
        End Try

        myconnection.Close()

    End Sub
End Class