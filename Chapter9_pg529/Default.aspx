<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
        <asp:TextBox ID="tbUser" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    
    </div>
    </form>
</body>
</html>
