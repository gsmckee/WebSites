<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentAdd.aspx.cs" Inherits="StudentAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblF_Name" Text ="Students first name: " />

        <asp:TextBox runat="server" ID="tbF_name" />    <asp:RegularExpressionValidator runat="server" 
            ControlToValidate="tbF_name" 
            ErrorMessage="The name can only contain letters!" 
            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" />      <br />
          
        
        <asp:Label runat="server" ID="lblLName" Text ="Students last name: " />
        <asp:TextBox runat="server" ID="tbL_name" />   <asp:RegularExpressionValidator runat="server" 
            ControlToValidate="tbL_name" 
            ErrorMessage="The name can only contain letters!" 
            ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" />    <br />

        <asp:Button runat="server" ID="btnSubmit" Text="Submit" Onclick="btnSubmit_Click"/>
    </div>
    </form>
</body>
</html>

        