<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRG340 03/2018</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="addStud" Text="Add a Student" OnClick="addStud_Click" />
        <aside><asp:Button runat="server" ID="fullProfile" Text="Course List" OnClick="fullProfile_Click" /></aside>
        <hr />
        <asp:Button runat="server" ID="dropStud" Text="Drop a Student" OnClick="dropStud_Click" />
    </div>
    </form>
</body>
</html>
