<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenu.ascx.cs" Inherits="_12.User_Controls.Controls.LinkMenu" %>

<ul id="nav" runat="server">
    <asp:DataList ID="DataListMenu" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%# Eval("Url") %>' style='color:<%# Eval("FontColor")  %>'><%# Eval("Text") %></a>
            </li>
        </ItemTemplate>
    </asp:DataList>
</ul>