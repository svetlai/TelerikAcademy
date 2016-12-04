<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="_2._1.WebForms_Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox id="TextBoxFirstNumber" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox id="TextBoxSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Sum" runat="server" Text="Sum" onclick="ButtonSum_Click"/>
        <br />
        <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
