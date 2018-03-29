<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRG340 03/2018</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnAddStud" Text="Add a Student" OnClick="addStud_Click" />
        <asp:Button runat="server" ID="btnAddCourse" Text="Add a Course" OnClick="addCourse_Click" /> <br />
        <asp:Button runat="server" ID="btnFullProfile" Text="Course List" OnClick="fullProfile_Click" Style="margin-left:105px; display:block"/>
        <hr />
        <asp:Button runat="server" ID="btnChangeStud" Text="Alter Student Info" Onclick="changeStud_Click"/>  
        <asp:Button runat="server" ID="btnDropStud" Text="Drop a Student" OnClick="dropStud_Click" />      
        <hr />
        
        
    </div>
    </form>
</body>
</html>
