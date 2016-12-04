<%@ Page Title="Session" Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="_8._2.Session.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <h4>Enter some text into the text box to store in the session.</h4>
        <asp:TextBox ID="TextBoxSession" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSession" runat="server" Text="Button" OnClick="ButtonSession_Click"/>
        <br />
        <h4>Output: </h4>
        <asp:Label ID="LabelSessionOutput" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
