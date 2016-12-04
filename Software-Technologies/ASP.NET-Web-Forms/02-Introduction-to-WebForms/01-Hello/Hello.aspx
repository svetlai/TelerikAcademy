<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="_1.Hello.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormHello" runat="server">
    <div>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Label ID="LabelHello" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="ButtonHello" runat="server" Text="Say Hello" onclick="ButtonHello_Click"/>
    </div>
    </form>
</body>
</html>
