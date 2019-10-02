<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="getpostcodes.aspx.vb" Inherits="italianproperty.getpostcodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
            </asp:GridView>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:estateportalConnectionString %>" ProviderName="<%$ ConnectionStrings:estateportalConnectionString.ProviderName %>" SelectCommand="SELECT * FROM estate"></asp:SqlDataSource>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="469px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" Width="495px">
            </asp:GridView>
            <br />
            <br />
            <asp:GridView ID="GridView3" runat="server" Width="550px">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
