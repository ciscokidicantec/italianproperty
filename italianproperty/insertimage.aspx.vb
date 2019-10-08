Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Web
Imports System.Drawing
Imports System.Net

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

        Dim insrttext As String = ""
        Dim pcindex As Integer = 1008%
        Dim Image() As Byte

        myconnection.ConnectionString = connStr.ToString

        ms.Close()

        'insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES ('" & pcindex & "','" & Image & "');"

        Dim com As New MySqlCommand(insrttext, myconnection)


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
        Dim insrttext As String
        Dim numberofins As Integer

        Dim myimages As New System.Web.UI.WebControls.Image
        'myimages.ImageUrl = "~/App_Data/" & "helen.jpg"
        'myimages.ImageUrl = "C:\Users\Owner\source\repos\italianproperty\italianproperty\App_Data\updatedhelen.jpg"
        'myimages.ImageUrl = "https://www.zoopla.co.uk/static/images/home-page/carousel-for-sale-london.png"
        myimages.ImageUrl = "images/" & "helen.jpg"


        myimages.Height = "250"
        Me.Controls.Add(myimages)

        'get absolute path from relative path
        'Dim fullPath As String = Path.GetFullPath("~/App_Data/" & "helen.jpg")

        'Dim virtualpath As String = Server.MapPath("~/App_Data/" & "helen.jpg")

        'Dim relativePath As String = HttpContext.Current.Server.MapPath("~/App_Data/" & "helen.jpg")

        'Dim serverpathurl As String = HttpContext.Current.Request.Url.AbsoluteUri

        'Dim hosturl As String = HttpContext.Current.Request.Url.Host

        'Dim getwholepath As String = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "italianproperty/" + "App_Data/helen.jpg"
        'Dim getwholepath As String = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "App_Data/helen.jpg"
        'Dim getwholepath As String = "App_Data/helen.jpg"
        Dim getwholepath As String = "images\helen.jpg"




        Dim querypath As String = Request.Url.AbsoluteUri

        Dim pandq As String = Request.Url.PathAndQuery

        Dim apppath As String = System.IO.Path.GetFullPath(Server.MapPath("~/App_Path/helen.jpg"))


        Dim myfullpathimages As New System.Web.UI.WebControls.Image
        myfullpathimages.ImageUrl = getwholepath
        myfullpathimages.Height = "450"
        myfullpathimages.BorderColor = Color.Yellow

        Me.Controls.Add(myfullpathimages)



        'Return

        'Dim myimg As New Bitmap(200, 200)

        'Dim mynewimg As New Bitmap(200, 200)
        'mynewimg.Save("C:\Users\Owner\source\repos\italianproperty\italianproperty\App_Data\updatedhelen.jpg")

        'Using GraphicsObject As Graphics = Graphics.FromImage(mynewimg)
        'GraphicsObject.DrawImage(mynewimg, 0, 0)
        'X, Y are the coordinates (inside the bitmap we're drawing into), of where the new bitmap will be drawn
        ' The bitmap will be drawn with its original Width and Height
        'End Using


        'Dim Img As New Bitmap("C:\Users\Owner\source\repos\italianproperty\italianproperty\App_Data\helen.jpg")

        'Return

        ' Dim mymStream As New MemoryStream
        'Dim myImageBytes As Byte()

        'Img.Save(mymStream, Imaging.ImageFormat.Png)
        'myImageBytes = mymStream.ToArray

        'Img.Dispose()

        'myconnection.ConnectionString = connStr.ToString

        'Save an Image to a memory stream so you can get the bytes
        Dim sampleImage As Bitmap = New Bitmap(100, 100)
        Dim mStream As New MemoryStream
        Dim ImageBytes As Byte()

        sampleImage.Save(mStream, Imaging.ImageFormat.Png)
        ImageBytes = mStream.ToArray

        '********************************************************************************************************************************

        Dim ms As New MemoryStream

        sampleImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim var As Int64 = Convert.ToBase64String(ms.ToArray())
        mybitmap.Src = "data:image/gif;base64," + var

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

        Dim pcindex = 194%
        Dim image As String = "dummytest"

        'SHOW VARIABLES LIKE 'max_allowed_packet';

        'VALUES (1, 20, LOAD_FILE('/data/test.txt'));

        'C:\Users\Owner\source\repos\italianproperty\italianproperty\Images\helen.jpg

        insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES(198, LOAD_FILE('Images/helen.jpg'));"

        'insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES(1955, LOAD_FILE('~/Images/helen.jpg'));"
        'insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES(1955, LOAD_FILE('~/Images/helen.jpg'));"
        'insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES(1992, LOAD_FILE('Images/helen.jpg'));"

        'dummytext = "INSERT INTO `estateporrtal`.`postcodes` (`indexpostcode`,`postcode`,`codeareadescription`) VALUES ('" & pcindex & "','" & pccode & "', '" & pccodedescription & "');"
        'insrttext = "INSERT INTO `estateporrtal`.`images` (`imageindex`,`image`) VALUES ('" & pcindex & "','" & image & "');"

        Dim com As New MySqlCommand(insrttext, myconnection)

        'com.CommandText = insrttext

        'myconnection = MySqlConnection(connStr.ToString)
        myconnection.ConnectionString = connStr.ToString

        Try
            myconnection.Open()
            numberofins = com.ExecuteNonQuery()
            myconnection.Close()
            myconnection.Dispose()

        Catch ex As MySqlException
            MsgBox(ex.Message & "  Error Number =  " & ex.Number)
        End Try

        'Return

        'an image column or varbinary column
        'com.Parameters.Add("@imageindex", SqlDbType.Image)
        'com.Parameters("@MyImage").Value = ImageBytes


        'Sample Read Image Command
        'Read the bytes from the table and create a new memory stream from them
        com.CommandText = "Select * From images"

        'Select Case MyBlobColumn From MyTable Where UserId = 20;
        myconnection.ConnectionString = connStr.ToString

        'Dim b As Bitmap = New Bitmap("asdf.jpg")
        'Dim myImage As Image = CType(b, Byte())

        Dim ImageFromDB As Bitmap
        Dim newMstream As MemoryStream
        Try
            myconnection.Open()
            Dim rdr As MySqlDataReader
            rdr = com.ExecuteReader
            If rdr.Read Then
                newMstream = New MemoryStream(CType(rdr.Item("Image"), Byte()))
                'Create a new image from the bytes from the memory
                ImageFromDB = New Bitmap(newMstream)
            End If
            com.Dispose()
            myconnection.Close()
            myconnection.Dispose()
        Catch ex As MySqlException
            MsgBox(ex.Message & "  Error Number =  " & ex.Number)
        End Try

        'Stream imageStream = New MemoryStream();
        'Using (Bitmap bmp = New Bitmap(Img))

        Dim RGB As Int64
        Dim c As Color = Color.Yellow

        For y As Int64 = 0 To ImageFromDB.Height - 1
            For x As Int64 = 0 To ImageFromDB.Width - 1
                c = ImageFromDB.GetPixel(x, y)
                'RGB = CType(c.R + c.G + c.B / 3, Int64)
                ImageFromDB.SetPixel(x, y, Color.FromArgb(RGB, RGB, RGB))
            Next
        Next

        ImageFromDB.Save("C:\compress\marioimg.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

        'ImageFromDB.Save(newMstream, System.Drawing.Imaging.ImageFormat.Jpeg)


    End Sub
End Class