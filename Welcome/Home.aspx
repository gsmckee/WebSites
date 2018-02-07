<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body>
    
        <form id="form2" runat="server">
            <div>
    
        
        
    
            </div>
            <table>
                <tr>
                    <th>User Name<asp:TextBox ID="tbUser" runat="server" ></asp:TextBox></th>
                </tr>

                <tr>
                    <th>Password<asp:TextBox ID="tbPass" runat="server"></asp:TextBox></th>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
            <br />
            <br />
            <asp:Button ID="btnCreateAcct" runat="server" Text="Create" OnClick="btnCreateAcct_Click" />
            <p>
                <asp:Label ID="lblMsg" runat="server" BackColor="Black" ForeColor="#CC0000" Visible="False"></asp:Label>
            </p>
        </form>
    </body>
</html>
<%--Previously used asp control... replaced by html table above
            <asp:Label ID="lblUsrName" runat="server" Text="User Name"></asp:Label>
            <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbUser" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="tbPass" runat="server"></asp:TextBox> --%>
              
