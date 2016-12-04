<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_8._4.ViewState_less.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <button id="ButtonDeleteViewState">Delete View State</button>
        <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
    </div>
    </form>
    <script>
        $(document).ready(
             $("#formMain").on("click", "#ButtonDeleteViewState", function () {

                 $("#__VIEWSTATE").val("");
             })
             );
    </script>
</body>
</html>
