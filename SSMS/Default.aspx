<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Width="850px"></asp:TextBox>
        <br />
        <br />
    
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="185px" TextMode="MultiLine" Width="869px"></asp:TextBox>
    </form>
</body>
</html>
