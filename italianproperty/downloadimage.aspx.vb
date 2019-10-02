Imports System.Net

Public Class downloadimage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim source As String = "https://lc.zoocdn.com/3ee8a8e3a2e196d0626de69b4a660d3e865df6e4.jpg"
        Dim Destination As String = "C:\Users\Public\Documents\testdownloadmario.jpg"

        'Dim mysource As String = "https://www.pornhub.com/view_video.php?viewkey=ph5c1554734d8d0"

        Dim mydestination = "C:\Users\Public\Documents\"
        Dim Client As New WebClient

        'Client.DownloadFile(mysource, Destination)


        Client.DownloadFile(source, Destination)

        ' My.Computer.Network.DownloadFile(source, mydestination + "mario3oct2019.jpg", "", "", False, 5000, True)

        Client.Dispose()


    End Sub
End Class