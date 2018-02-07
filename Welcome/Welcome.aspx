<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Button ID="btnLogout" runat="server" Text="Logout" style="float:right"/>
    <div>
        <asp:Label ID="lblWelcome" runat="server" Text="" ></asp:Label>
    </div>
        <asp:Label ID="lblAge" runat="server" Text ="Age : "></asp:Label>
        <asp:Label ID="lblUserAge" runat="server" Text =""></asp:Label>

        <asp:Label ID="lblAdmin" runat="server" Text ="Admin : "></asp:Label>
        <asp:Label ID="lblUserAdmin" runat="server" Text =""></asp:Label><br />
        <asp:Button ID="btnUserList" runat="server" Text="List Of Users" Visible="false" style="justify-content:center" OnClick="btnUserList_Click"/>

    </form>
    
</body>
</html>   
