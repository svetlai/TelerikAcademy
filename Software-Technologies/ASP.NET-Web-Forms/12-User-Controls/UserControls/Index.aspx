<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_12.User_Controls.Index" %>

<%@ Register Src="~/Controls/LinkMenu.ascx" TagPrefix="uc" TagName="LinkMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <uc:LinkMenu runat="server" ID="LinkMenu" />
    </div>
    </form>
</body>
</html>
