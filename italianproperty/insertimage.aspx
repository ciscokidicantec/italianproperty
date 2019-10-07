<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="insertimage.aspx.vb" Inherits="italianproperty.insertimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 232px;
            height: 172px;
        }
        .auto-style2 {
            width: 823px;
            height: 568px;
        }
        .auto-style3 {
            width: 1008px;
            height: 756px;
        }
    </style>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Text="image information"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <img alt="" class="auto-style1" src="App_Data/helen.jpg" /><img alt="This is helen" class="auto-style2" src="Images/helen.jpg" /></p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <img class="auto-style3" src="Images/helen.jpg" /><img class="auto-style3" src="Images/helen.jpg" /><img class="auto-style3" src="Images/helen.jpg" /><asp:Image ID="Image2" runat="server" Height="145px" ImageUrl="App_Data/helen.jpg" Width="167px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Image ID="Image3" runat="server" Height="252px" Width="277px" ImageUrl="~/App_Data/testdownloadmario.jpg" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="MySql Insert Image" Width="293px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Insert Image Into Database" />
        </p>
        <div>
        </div>
    </form>
</body>
</html>
