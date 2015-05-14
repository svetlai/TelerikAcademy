<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="NewsSite.Web.Admin.Articles" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewNews" runat="server"
        ItemType="NewsSite.Web.Models.Article"
        DataKeyNames="Id"
        SelectMethod="ListViewNews_GetData"
        UpdateMethod="ListViewNews_UpdateItem"
        DeleteMethod="ListViewNews_DeleteItem"
        InsertMethod="ListViewNews_InsertItem"
        OnItemDataBound="ListViewNews_DisplayNews"
        InsertItemPosition="None">
        <LayoutTemplate>
            <div class="row">
                <div class="col-md-12">
                    <asp:LinkButton ID="LinkButtonSortNewsByTitle" runat="server"
                        Text="Sort By Title"
                        CommandName="Sort"
                        CommandArgument="Title"
                        CssClass="btn btn-default" />
                    <asp:LinkButton ID="LinkButtonSortNewsByDate" runat="server"
                        Text="Sort By Date"
                        CommandName="Sort"
                        CommandArgument="DateCreated"
                        CssClass="btn btn-default" />
                    <asp:LinkButton ID="LinkButtonSortByLikes"
                        runat="server"
                        Text="Sort by Likes"
                        CommandName="Sort"
                        CommandArgument="Likes.Count"
                        CssClass="btn btn-default">
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonSortByCategoryName"
                        runat="server"
                        Text="Sort by Category"
                        CommandName="Sort"
                        CommandArgument="Category.Name"
                        CssClass="btn btn-default">
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonInsert" runat="server"
                        Text="Add New Article"
                        CssClass="btn btn-success pull-right"
                        OnClick="LinkButtonInsert_Click" />
                </div>
            </div>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            <asp:DataPager runat="server" ID="DataPagerCategories"
                PagedControlID="ListViewNews" PageSize="5">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%#: Item.Title %>' />
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Edit" CssClass="btn btn-info" CommandName="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete"></asp:LinkButton>

                    </h3>
                </div>
                <div class="col-md-12">
                    <p>
                        Category: <%#: Item.Category.Name %>
                    </p>
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
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <li>No articles.
            </li>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:Label ID="LabelInsertArticle" runat="server" Text="Edit Article" />
                    </h3>
                    <asp:TextBox ID="TextBoxEditTitle" runat="server" Text="<%#: BindItem.Title %>" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditTitle"
                        runat="server"
                        ErrorMessage="Title cannot be empty."
                        ControlToValidate="TextBoxEditTitle"
                        ForeColor="Red" />
                    <asp:CustomValidator ID="CustomValidatorEditTitleLength" runat="server" ControlToValidate="TextBoxEditTitle"
                        OnServerValidate="CustomValidatorEditTitleLength_ServerValidate"
                        ErrorMessage="Article title cannot not be longer than 100 characters." ForeColor="Red" />
                </div>
                <div class="col-md-12">
                    <p>
                        <asp:DropDownList ID="DropDownListEditCategory"
                            runat="server"
                            SelectedValue="<%#: BindItem.CategoryId %>"
                            DataTextField="Name"
                            DataValueField="Id"
                            SelectMethod="DropDownListCategory_GetData"
                            CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryDropDown"
                            runat="server"
                            ErrorMessage="Category is required."
                            ControlToValidate="DropDownListEditCategory"
                            ForeColor="Red" />
                    </p>
                </div>
                <div class="col-md-12">
                    <p>
                        <asp:TextBox ID="TextBoxEditContent" runat="server" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Rows="6" CssClass="col-md-12 form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditContent"
                            runat="server"
                            ErrorMessage="Content cannot be empty."
                            ControlToValidate="TextBoxEditContent"
                            ForeColor="Red" />
                    </p>
                </div>
                <div class="col-md-12">
                    <p>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Save" CssClass="btn btn-success" CommandName="Update"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CommandName="Cancel"></asp:LinkButton>
                    </p>
                </div>
                <div class="col-md-12">
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
                <hr />
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:Label ID="LabelInsertArticle" runat="server" Text="Add New Article" />
                    </h3>
                    <asp:TextBox ID="TextBoxInsertTitle" runat="server" Text="<%#: BindItem.Title %>" CssClass="form-control" PlaceHolder="Title" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditTitle"
                        runat="server"
                        ErrorMessage="Title cannot be empty."
                        ControlToValidate="TextBoxInsertTitle"
                        ForeColor="Red" />
                    <asp:CustomValidator ID="CustomValidatorInsertTitleLength" runat="server" ControlToValidate="TextBoxInsertTitle"
                        OnServerValidate="CustomValidatorEditTitleLength_ServerValidate"
                        ErrorMessage="Article title cannot not be longer than 100 characters." ForeColor="Red" />

                </div>
                <div class="col-md-12">
                    <p>
                        <asp:DropDownList ID="DropDownListInsertCategory"
                            runat="server"
                            SelectedValue="<%#: BindItem.CategoryId %>"
                            DataTextField="Name"
                            DataValueField="Id"
                            SelectMethod="DropDownListCategory_GetData"
                            CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryDropDown"
                            runat="server"
                            ErrorMessage="Category is required."
                            ControlToValidate="DropDownListInsertCategory"
                            ForeColor="Red" />
                    </p>
                </div>
                <div class="col-md-12">
                    <p>
                        <asp:TextBox ID="TextBoxInsertContent" runat="server" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Rows="6" CssClass="col-md-12 form-control" PlaceHolder="Content" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditContent"
                            runat="server"
                            ErrorMessage="Content cannot be empty."
                            ControlToValidate="TextBoxInsertContent"
                            ForeColor="Red" />
                    </p>
                </div>
                <div class="col-md-12">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Save" CssClass="btn btn-success" CommandName="Insert"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CommandName="Cancel"></asp:LinkButton>
                </div>
                <div class="col-md-12">
                    <i>by <%#: Context.User.Identity.GetUserName() %></i>
                    <i>created on: <%#: DateTime.Now %></i>
                </div>
                <hr />
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
