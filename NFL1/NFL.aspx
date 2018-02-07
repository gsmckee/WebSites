<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NFL.aspx.cs" Inherits="NFL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text="National Football League" Font-Size="Large"></asp:Label>
        <asp:Panel ID="pnlTeams" runat="server">
            <asp:DropDownList ID="ddlTeams" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTeams_SelectedIndexChanged">
            </asp:DropDownList><br />
            <asp:Image ID="Image1" runat="server" />
        </asp:Panel>
    
    </div>
        <asp:Panel ID="pnlPlayers" runat="server" Visible="False">
            <asp:ListBox ID="lbPlayers" runat="server"></asp:ListBox>
        </asp:Panel>
    </form>
</body>
</html>
