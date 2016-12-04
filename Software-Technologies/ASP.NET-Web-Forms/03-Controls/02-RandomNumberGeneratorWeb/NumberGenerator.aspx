<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumberGenerator.aspx.cs" Inherits="_3._1.Random_Number_Generator___HTML.NumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formNumberGenerator" runat="server">
    <div>
        <h3>Random Number Generator - using Web Controls</h3>
        <p>Enter min and max values to declare the number's range.</p>
        <asp:TextBox ID="TextMin" runat="server" placeholder="Min" ></asp:TextBox>
        <asp:TextBox ID="TextMax" runat="server" placeholder="Max"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Generate" onclick="ButtonSubmit_Click" />
        <br />
        <br />
        <asp:Label ID="SpanResult" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
