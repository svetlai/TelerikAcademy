<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NewsSite.Web.News" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <h2>Most popular articles</h2>
    <asp:ListView ID="ListViewNews" runat="server"
        ItemType="NewsSite.Web.Models.Article"
        DataKeyNames="Id"
        SelectMethod="ListViewNews_GetData"
        OnItemDataBound="ListViewNews_DisplayNews">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%#: Item.Title %>' />
                        <small><%#: Item.Category.Name %></small>
                    </h3>
                </div>
                <div class="col-md-12">
                    <p>
                        <asp:Label ID="LabelContent" runat="server" Text="<%#: Item.Content %>"></asp:Label>
                    </p>
                </div>
                <div class="col-md-12">
                    <p>
                        <%#: string.Format("Likes: {0}", Item.Likes.Count) %>
                    </p>
                </div>
                <div class="col-md-12">
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
                <hr />
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <li>No articles.
            </li>
        </EmptyDataTemplate>
    </asp:ListView>
    <h2>All categories</h2>
    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="NewsSite.Web.Models.Category"
        DataKeyNames="Id"
        SelectMethod="ListViewCategories_GetData"
        GroupItemCount="2">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView ID="ListViewCategoryNews" runat="server"
                    ItemType="NewsSite.Web.Models.Article"
                    DataSource="<%# Item.Articles %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server"
                                Text='<%# string.Format("<strong>{0}</strong> by <i>{1}</i>", Item.Title, Item.Author.UserName) %>'>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="col-md-12">
                            <p>No articles.</p>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
