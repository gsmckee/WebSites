<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="register" runat="server">
    <div>
        
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
        
        <table>
            <tr>
                <th><asp:Label ID="lblUserName" runat="server" Width="150px" Text="User Name"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbUser" ErrorMessage=" Username Field Required!" ForeColor="Red" ID="vUserName">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbUser" runat="server" ></asp:TextBox></th>
            </tr>

            <tr>
                <th><asp:Label ID="lblPassword" runat="server" Width="150px" Text="Password"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPass" ErrorMessage="Password Field Required!" ForeColor="Red" ID="vPass">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox></th>
            </tr>
            <tr>
                <th><asp:Label ID="lblConfirmPass" runat="server" Width="150px" Text="Confirm Password"></asp:Label>
                    <asp:CompareValidator runat="server" ControlToValidate="tbPass" ControlToCompare="tbConfirmPass" ErrorMessage=" Passwords do not match" ForeColor="Red" ID="vPassConfirm">*</asp:CompareValidator>
                    <asp:TextBox ID="tbConfirmPass" runat="server" TextMode="Password"></asp:TextBox></th>
            </tr>
            <tr>
                <th><asp:Label ID="lblFName" runat="server" Width="150px" Text="First Name"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFirst" ErrorMessage="First Name Field Required!" ForeColor="Red" ID="vFName">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbFirst" runat="server" ></asp:TextBox></th>
            </tr>

            <tr>
                <th><asp:Label ID="lblLName" runat="server" Width="150px" Text="Last Name"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLast" ErrorMessage="Last Name Field Required!" ForeColor="Red" ID="vLName">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbLast" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
                <th><asp:Label ID="lblAge" runat="server" Width="150px" Text="Age"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbAge" ErrorMessage="Age Field Required!" ForeColor="Red" ID="vAge">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbAge" runat="server" ></asp:TextBox></th>
            </tr>

            <tr>
                <th><asp:Label ID="lblEmail" runat="server" Width="150px" Text="E-mail"></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail" ErrorMessage="E-mail Field Required!" ForeColor="Red" ID="vEmail">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox></th>
            </tr>
        </table>
        <br /><asp:CheckBox ID="cbAdmin" runat="server" Text="Administrator" TextAlign="Left"/>
        <br />
        <asp:RegularExpressionValidator ID="vEmail2" runat="server" ControlToValidate="tbEmail" ErrorMessage="Enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btnCreateAcct" runat="server" Text="Create" OnClick="btnCreateAcct_Click" Visible="True"/>
        <asp:Button ID="btnLoginRedirect" runat="server" OnClick="btnLoginRedirect_Click" Text="Login" Visible="False" />
        <p>
            <asp:Label ID="lblMsg" runat="server" BackColor="Black" ForeColor="#CC0000" Visible="False"></asp:Label>
        </p>
    
    </div>
    </form>
</body>
</html>
