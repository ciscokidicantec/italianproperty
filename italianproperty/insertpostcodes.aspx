<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="insertpostcodes.aspx.vb" Inherits="italianproperty.insertpostcodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:ListBox ID="ListBox1" runat="server" Height="610px" Width="723px"></asp:ListBox>
    </p>
        <p>
            <asp:ListBox ID="ListBox2" runat="server" Height="254px" Width="720px"></asp:ListBox>
        <br />
    </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
