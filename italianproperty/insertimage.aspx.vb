Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Web
Imports System.Drawing





Public Class insertimage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")

        Dim picsave As Object = ""

        Dim ms As New MemoryStream
        picSave.Image.Save(ms, picSave.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer
        Dim Name As String = Label1.Text.ToString
        Dim sqlcmd As New MySqlCommand
        Dim sql As String

        myconnection.ConnectionString = connStr.ToString

        ms.Close()
        sql = " INSERT INTO images (imageindex, image)" &
            " VALUES (@imageindex, @image)"

        Try
            myconnection.Open()
            With sqlcmd
                .CommandText = sql
                .Connection = myconnection
                .Parameters.Add("@imageindex", DbType.Int32)
                .Parameters.Add("@image", MySqlDbType.Blob)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myconnection.Close()
        End Try



    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim myconnection As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("estateportalConnectionString")
        Dim insrttext As String = ""
        Dim numberofins As Integer = 0%

        myconnection.ConnectionString = connStr.ToString

        'Save an Image to a memory stream so you can get the bytes
        Dim sampleImage As Bitmap = New Bitmap(100, 100)
        Dim mStream As New System.IO.MemoryStream
        Dim ImageBytes As Byte()
        'Dim dummytext As String

        sampleImage.Save(mStream, Imaging.ImageFormat.Png)
        ImageBytes = mStream.ToArray

        Dim mycom As New MySql.Data.MySqlClient.MySqlCommand
        'Dim myrdr As MySql.Data.MySqlClient.MySqlDataReader

        mycom.CommandText = "SELECT * FROM images"

        Dim con As New MySqlConnection(connStr.ToString)

        Try

            con.Open()

            Dim sql As String = "SELECT * FROM images;"

            Dim cmd As New MySqlCommand(sql, con)

            Dim myreader As MySqlDataReader = cmd.ExecuteReader()

            Dim outputresult As String = ""
            Dim outputresult1 As String = ""
            While myreader.Read()
                outputresult = myreader("imageindex").ToString
                'outputresult1 = myreader("image").ToString
            End While
            cmd.Dispose()
            myreader.Close()
            myconnection.Close()
            con.Dispose()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("Error: " & ex.ToString())
        End Try

        'Sample Insert image command
        'Save the bytes from the image into a image or varbinary column

        Dim pcindex = 133%
        Dim image As String = "dummytest"

        'dummytext = "INSERT INTO `estateporrtal`.`postcodes` (`indexpostcode`,`postcode`,`codeareadescription`) VALUES ('" & pcindex & "','" & pccode & "', '" & pccodedescription & "');"

        insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES ('" & pcindex & "','" & image & "');"

        Dim com As New MySqlCommand(insrttext, myconnection)

        'com.CommandText = insrttext

        Try
            myconnection.Open()
            numberofins = com.ExecuteNonQuery()
            myconnection.Close()
            myconnection.Dispose()

        Catch ex As MySqlException
            MsgBox(ex.Message & "  Error Number =  " & ex.Number)
        End Try

        'an image column or varbinary column
        'com.Parameters.Add("@imageindex", SqlDbType.Image)
        'com.Parameters("@MyImage").Value = ImageBytes


        'Sample Read Image Command
        'Read the bytes from the table and create a new memory stream from them
        com.CommandText = "Select * From images"

        myconnection.Open()

        Dim rdr As MySqlDataReader

        rdr = com.ExecuteReader
        If rdr.Read Then
            Dim newMstream As New System.IO.MemoryStream(CType(rdr.Item("MyImage"), Byte()))
            'Create a new image from the bytes from the memory
            Dim ImageFromDB As New Bitmap(newMstream)

        End If

        com.Dispose()
        myconnection.Close()
        myconnection.Dispose()


    End Sub
End Class