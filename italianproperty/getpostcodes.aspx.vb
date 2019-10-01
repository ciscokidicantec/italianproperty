Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class getpostcodes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        'Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")
        Dim sqlquery As String = "SELECT * FROM estate"
        Dim data As MySqlDataReader

        Dim connStr As String = "server=localhost;user id=root;password=Coreldraw1$;persistsecurityinfo=True;database=estateporrtal"
        myconnection.ConnectionString = connStr

        '    Dim command As New SqlCommand
        '    Command.CommandText = sqlquery
        '   Command.Connection = conn
        '  Adapter.SelectCommand = command
        ' data = command.ExecuteReader()
        'While data.Read
        'If data.HasRows = True Then





        Try
            myconnection.Open()
            Dim command As New MySqlCommand
            command.Connection = myconnection
            command.CommandText = sqlquery
            data = command.ExecuteReader()

            While data.Read
                If data.HasRows = True Then
                    If data(2).ToString = "password_user.Text" Then
                        MsgBox("Sucsess")
                    Else
                        MsgBox("Login Failed! Please try again or contact support")
                    End If
                Else
                    MsgBox("Login Failed! Please try again or contact support")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        myconnection.Close()


        'connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString
        'connStr = ConfigurationManager.ConnectionStrings("myConnectionString")

        'Dim conn As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("connstring")
        'Dim connString As String = conn.ConnectionString
        'myconnection = New MySqlConnection(connString)
        'myconnection.Open()
        'command.CommandText = sqlquery


        '  Try
        '    myconnection.Open()
        ' Dim sqlquery As String = "SELECT * FROM estate"
        '   Dim data As SqlDataReader
        '  Dim adapter As New SqlDataAdapter
        ' Dim command As New SqlCommand
        'command.CommandText = sqlquery
        'command.Connection = myconnection
        '          adapter.SelectCommand = command
        '         data = command.ExecuteReader()
        '     While data.Read
        'If data.HasRows = True Then
        'If data(2).ToString = password_user.Text Then
        'MsgBox("Sucsess")
        'Else
        'MsgBox("Login Failed! Please try again or contact support")
        'End If
        'Else
        'MsgBox("Login Failed! Please try again or contact support")
        'End If
        'End While
        'Catch ex As Exception

        'End Try





    End Sub
End Class