<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayText.aspx.cs" Inherits="_3._3.Display_Text.DisplayText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formText" runat="server">
        <asp:Panel ID="PanelDisplayText" runat="server" DefaultButton="ButtonSubmit">
            <h3>Display Text</h3>
            <p>Enter some text in the first text box and click on Display.</p>
            <asp:TextBox ID="TextBoxOriginal" runat="server" ></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBoxCopy" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelCopy" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Display" onclick="ButtonSubmit_Click" />
        </asp:Panel>
    </form>
</body>
</html>
