<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateEntry.aspx.cs" Inherits="UpdateEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="lblSearch" Text="Enter Student ID or last name:" />
        <asp:TextBox runat="server" ID="tbSearchTerm" /> <br />
        <asp:Button runat="server" ID="btnStudInfo" Text="Search" OnClick="studInfo_Click" />
    <div>
        <asp:CheckBoxList runat="server" ID="cblColName" Visible="false" 
            OnSelectedIndexChanged="cblColName_SelectedIndexChanged" AutoPostBack="true" >
            <asp:ListItem Value="firstName">First name</asp:ListItem>
            <asp:ListItem Value="lastName">Last name</asp:ListItem>
        </asp:CheckBoxList>
        <hr />
        <asp:Textbox runat="server" ID="tbF_Name" Visible="false" />
        <asp:TextBox runat="server" ID="tbL_Name" Visible="false" /><br />
        <asp:Button runat="server" ID="btnUpdate" Text="Update Entry" OnClick="btnUpdate_Click" />
    </div>
    </form>
</body>
</html>
