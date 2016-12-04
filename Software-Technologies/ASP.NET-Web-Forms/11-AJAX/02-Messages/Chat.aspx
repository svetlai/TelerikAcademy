<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="_11._2.Messages.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formChat" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:UpdatePanel runat='server' ID='UpdatePanelChat' UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridViewChat" runat="server" AutoGenerateColumns="true" DataKeyNames="Id">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />
        <p>The messages won't change because no new messages are added to the database but you can see it refreshes every 500ms in the Network tab of Dev Tools. </p>
    </div>
    </form>
</body>
</html>
