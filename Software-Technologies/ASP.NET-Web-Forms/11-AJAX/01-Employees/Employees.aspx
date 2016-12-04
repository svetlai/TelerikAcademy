<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_11._1.Employees.Employees1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />

            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="true"
                OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" DataKeyNames="EmployeeID">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanelOrders" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="true">
                        <Columns>
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridViewEmployees" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:UpdateProgress ID="OrdersUpdateProgress" AssociatedUpdatePanelID="UpdatePanelOrders" runat="server">
                <ProgressTemplate>
                    <img src="loading.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
