<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Life-Cycle.aspx.cs" Inherits="_3.Life_Cycle.Life_Cycle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formEvents" runat="server">
    <div>
        <asp:Label ID="LabelEvents" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonOK" Text="OK" runat="server"
        OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
        OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
    </div>
    </form>
</body>
</html>
