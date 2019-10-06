<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="insertimage.aspx.vb" Inherits="italianproperty.insertimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
