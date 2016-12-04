<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Chat</h1>
        <p class="lead">Welcome to MyChatApp</p>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Literal ID="LiteralRole" runat="server"></asp:Literal>
            <br />
            <asp:Panel ID="PanelMessages" Visible="false" runat="server">
                <asp:ListView ID="ListViewChat" runat="server" ItemType="Chat.Models.Message" DataKeyNames="Id"
                    OnItemEditing="ListViewChat_ItemEditing"
                    OnItemCanceling="ListViewChat_ItemCanceling"
                    OnItemUpdating="ListViewChat_ItemUpdating"
                    OnItemDeleting="ListViewChat_ItemDeleting"
                    OnItemDataBound="ListViewChat_ItemDataBound">
                    <ItemTemplate>                                    
                        <p>
                              <strong><%#: Item.AuthorName %>: </strong>
                            <span><%#: Item.Text %></span>
                            <asp:Button ID="EditButton" runat="server"
                                CommandName="Edit" Text="Edit" Visible="false" />
                            <asp:Button ID="DeleteButton" runat="server"
                                CommandName="Delete" Text="Delete" Visible="false" />
                        </p>       
                    </ItemTemplate>
                    <EditItemTemplate>
                        <p>                          
                            <asp:TextBox ID="TextBoxEditMessageText" runat="server" Text="<%#: BindItem.Text %>"></asp:TextBox>
                             <asp:Button ID="UpdateButton" runat="server"
                                CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server"
                                CommandName="Cancel" Text="Cancel" />
                        </p>
                    </EditItemTemplate>
                </asp:ListView>
                <br />
                <asp:TextBox ID="TextBoxPostMessage" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonPostMessage" runat="server" Text="Post" OnClick="ButtonPostMessage_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
