Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Imports System.Web


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

        'App_LocalResources

        'Dim sr As StreamReader
        ' Dim line As String
        Dim ResultBlock As String = ""

        Dim s As String = ""

        Dim postcodetable As New DataTable


        postcodetable.Columns.Add("Post Code", GetType(String))
        postcodetable.Columns.Add("Place", GetType(String))

        For Each row As DataRow In postcodetable.Rows
            ' Write value of first Integer.
            ListBox3.Items.Add(row.Field(Of Integer)(0).ToString() + "   " + row.Field(Of String)(2).ToString() + "   " + row.Field(Of String)(1).ToString() + "   " + row.Field(Of Date)(3).ToString())
        Next

        Dim firstpcpos As Integer = 0%
        Dim lastpcpos As Integer = 0%

        Dim pcstring As String = ""
        Dim placestring As String = ""


        For Each line As String In File.ReadLines("~/App_LocalResources/pc.txt")
            'For Each line As String In File.ReadLines("C:\Users\Owner\source\repos\italianproperty\italianproperty\App_LocalResources\pc.txt")

            ' For Each line As String In File.ReadLines("C:\Users\Owner\Documents\pc.txt")
            firstpcpos = InStr(line, " ")
            pcstring = line.TrimEnd.ToString().Substring(0%, firstpcpos%)
            placestring = line.TrimEnd.ToString().Substring(firstpcpos%, Len(line) - firstpcpos)
            postcodetable.Rows.Add(placestring, pcstring)
            ListBox2.Items.Add(line.TrimEnd)
        Next

        Dim table As New DataTable


        ' Create four typed columns in the DataTable.
        table.Columns.Add("Dosage", GetType(Integer))
        table.Columns.Add("Drug", GetType(String))
        table.Columns.Add("Patient", GetType(String))
        table.Columns.Add("Date", GetType(DateTime))

        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add(25, "Indocin", "David", DateTime.Now)
        table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now)
        table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now)
        table.Rows.Add(21, "Combivent", "Janet", DateTime.Now)
        table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now)

        For Each row As DataRow In table.Rows
            ' Write value of first Integer.
            ListBox1.Items.Add(row.Field(Of Integer)(0).ToString() + "   " + row.Field(Of String)(2).ToString() + "   " + row.Field(Of String)(1).ToString() + "   " + row.Field(Of Date)(3).ToString())
        Next

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
            dt.Columns.Add("Email", GetType(String))


            While data.Read

                If data.HasRows = True Then
                    ListBox1.Items.Add("First Name = " + data(2).ToString + "   " + "Last Name = " + data(4).ToString + "   Email = " + data(17).ToString)
                    dt.Rows.Add(data(2).ToString, data(4).ToString, data(17).ToString)
                End If
            End While

            Dim magestring As String = dt.Rows.Item(0%).Item(2%).ToString

            Image1.ImageUrl = dt.Rows.Item(0%).Item(2%).ToString
            MsgBox(dt.Rows.Item(0%).Item(2%).ToString)

            GridView2.DataSource = dt
            GridView2.DataBind()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        myconnection.Close()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged


    End Sub
End Class