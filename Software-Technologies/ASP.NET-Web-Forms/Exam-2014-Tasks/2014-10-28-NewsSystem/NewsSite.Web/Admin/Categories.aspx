<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="NewsSite.Web.Admin.Categories" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="NewsSite.Web.Models.Category"
        DataKeyNames="Id"
        SelectMethod="ListViewCategories_GetData"
        UpdateMethod="ListViewCategories_UpdateItem"
        DeleteMethod="ListViewCategories_DeleteItem"
        InsertMethod="ListViewCategories_InsertItem"
        InsertItemPosition="None">
        <LayoutTemplate>
            <div class="row">
                <div class="col-md-12">
                    <asp:LinkButton ID="LinkButtonSortCategory" runat="server"
                        Text="Sort By Name"
                        CommandName="Sort"
                        CommandArgument="Name"
                        CssClass="btn btn-default" />
                    <asp:LinkButton ID="LinkButtonInsert" runat="server"
                        Text="Add New Category"
                        CssClass="btn btn-success pull-right"
                        OnClick="LinkButtonInsert_Click" />
                </div>
            </div>
            <br />
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            <asp:DataPager runat="server" ID="DataPagerCategories"
                PagedControlID="ListViewCategories" PageSize="5">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-10">
                    <%#: Item.Name %>
                </div>
                <div class="col-md-1 pull-right">
                    <asp:LinkButton ID="LinkButtonDelete" runat="server" Text="Delete" CssClass="btn btn-danger pull-right" CommandName="Delete"></asp:LinkButton>
                </div>
                <div class="col-md-1 pull-right">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Edit" CssClass="btn btn-info pull-right" CommandName="Edit"></asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox ID="TextBoxCategoryEditName" runat="server" Text="<%#: BindItem.Name %>" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEditName" runat="server" ErrorMessage="Name is required."
                        ControlToValidate="TextBoxCategoryEditName" ForeColor="Red" />
                    <asp:CustomValidator ID="CustomValidatorEditNameLength" runat="server" ControlToValidate="TextBoxCategoryEditName"
                        OnServerValidate="CustomValidatorEditNameLength_ServerValidate"
                        ErrorMessage="Category name cannot not be longer than 20 characters." ForeColor="Red" />
                </div>
                <div class="col-md-1 pull-right">
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-danger pull-right" CommandName="Cancel"></asp:LinkButton>
                </div>
                <div class="col-md-1 pull-right">
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Save" CssClass="btn btn-success pull-right" CommandName="Update"></asp:LinkButton>
                </div>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="col-md-9">
                    <asp:TextBox ID="TextBoxCategoryInsertName" runat="server" Text="<%#: BindItem.Name %>" PlaceHolder="Name" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInsertName" runat="server" ErrorMessage="Name is required."
                        ControlToValidate="TextBoxCategoryInsertName" ForeColor="Red" />
                    <asp:CustomValidator ID="CustomValidatorInsertNameLength" runat="server" ControlToValidate="TextBoxCategoryInsertName"
                        OnServerValidate="CustomValidatorEditNameLength_ServerValidate"
                        ErrorMessage="Category name cannot not be longer than 20 characters." ForeColor="Red" />
                </div>
                <div class="col-md-2 pull-right">
                    <asp:LinkButton ID="LinkButtonInsertCancel" runat="server" Text="Cancel" CssClass="btn btn-danger pull-right" CommandName="Cancel"></asp:LinkButton>
                    <div class="col-md-1 pull-right">
                    </div>
                    <asp:LinkButton ID="LinkButtonInsert" runat="server" Text="Save" CssClass="btn btn-success pull-right" CommandName="Insert"></asp:LinkButton>
                </div>
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
