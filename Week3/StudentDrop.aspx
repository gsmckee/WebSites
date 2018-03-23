<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDrop.aspx.cs" Inherits="StudentDrop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblF_Name" Text ="Students first name: " />
        <asp:TextBox runat="server" ID="tbF_name" />
       <br />
        <asp:Label runat="server" ID="lblL_Name" Text ="Students last name: " />
        <asp:TextBox runat="server" ID="tbL_name" /><br />
        <asp:Button runat="server" ID="btnDropStud" Text="Drop" OnClick="btnDropStud_Click" />
        <asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click" Visible="false"/>
        <asp:Button runat="server" ID="btnAddStud" Text="Add Student" OnClick="btnAddStud_Click" Visible="false" />
    </div>
    </form>
</body>
</html>
 <%--<asp:RegularExpressionValidator runat="server" ControlToValidate="tbF_name" 
            ErrorMessage="The name can only contain letters!" 
            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbL_name" 
            ErrorMessage="The name can only contain letters!" 
            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" />--%>  