<%@ Page Title="Continents" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Continents.aspx.cs" Inherits="Countries.Web.Continents" %>

<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:ListBox ID="ListBoxContinents" runat="server"
        DataTextField="Name" DataValueField="Id"
        OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged" AutoPostBack="True" />
    <h2>Countries</h2>                    
    <asp:GridView ID="GridViewCountries" runat="server" AutoGenerateColumns="false" AutoPostBack="true"
        AllowPaging="True" PageSize="2" OnPageIndexChanging="GridViewCountries_PageIndexChanging"
        DataKeyNames="Id" OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged"
        OnRowEditing="GridViewCountries_RowEditing"
        OnRowUpdating="GridViewCountries_RowUpdating"
        OnRowCancelingEdit="GridViewCountries_RowCancelingEdit"
        OnRowDeleting="GridViewCountries_RowDeleting"
        OnRowCommand="GridViewCountries_RowCommand"
        ShowFooter="false"
        ItemType="Countries.Models.Country">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="true"/>
            <asp:TemplateField>
                <ItemTemplate><%#: Item.Name %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCountryName" runat="server" Text="<%#: BindItem.Name %>"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertCountryName" runat="server" Text=""></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><%#: Item.Language %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCountryLanguage" runat="server" Text=""></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertCountryLanguage" runat="server" Text=""></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><%#: Item.Population %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCountryPopulation" runat="server" Text="<%#: BindItem.Population %>"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBoxInsertCountryPopulation" runat="server" Text="<%#: BindItem.Population %>"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <ItemTemplate>
                        <img src='<%#: Item.Images.Any()? Page.ResolveUrl(Item.Images.FirstOrDefault().Path) : "/Images/default.png" %>' />
                    </ItemTemplate>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button Text="Insert" CommandName="Insert" CausesValidation="true" runat="server" ID="btInsert" />&nbsp;
               <asp:Button Text="Cancel" CommandName="Cancel" CausesValidation="false" runat="server" ID="btCancel" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                 <ItemTemplate>
   
                    </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:Panel ID="PanelFileUpload" Visible="false" runat="server">
            <br />
            <p>Change Flag: </p>
            <uc:FileUpload ID="FileUploadControl" runat="server" />
            <asp:Button ID="SubmitFileUpload" CssClass="" runat="server" OnClick="SubmitFileUpload_Click" Text="Upload"></asp:Button>
        </asp:Panel>
    <h2>Towns</h2>
    <table>
        <thead>
            <tr>
                <th></th>
                <th>Name</th>
                <th>Population</th>
                <th>Country</th>
            </tr>
        </thead>
        <tbody>
            <asp:ListView ID="ListViewTowns" runat="server"
                ItemType="Countries.Models.Town" 
                OnItemEditing="ListViewTowns_ItemEditing"
                OnItemCanceling="ListViewTowns_ItemCanceling"
                OnItemUpdating="ListViewTowns_ItemUpdating"
                OnItemDeleting="ListViewTowns_ItemDeleting"
                OnItemInserting="ListViewTowns_ItemInserting"
                OnPagePropertiesChanging="ListViewTowns_PagePropertiesChanging"
                DataKeyNames="Id"
                ItemPlaceholderID="townsPlaceholder"
                InsertItemPosition="None">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="EditButton" runat="server"
                                CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server"
                                CommandName="Delete" Text="Delete" />
                        </td>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Population %></td>
                        <td><%#: Item.Country.Name %></td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #008A8C; color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server"
                                CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server"
                                CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="TownNameTextBox" runat="server"
                                Text='<%# BindItem.Name %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TownPopulationTextBox" runat="server"
                                Text='<%# BindItem.Population %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TownCountryTextBox" runat="server"
                                Text='<%# BindItem.Country.Name %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <LayoutTemplate>
                    <asp:Button ID="ButtonInsertTown" runat="server" OnClick="ButtonInsertTown_Click" Text="Add New" />
                    <br />
                    <asp:PlaceHolder runat="server" ID="townsPlaceholder"></asp:PlaceHolder>
                    <asp:DataPager ID="DataPagerTowns" runat="server" PagedControlID="ListViewTowns" PageSize="2">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <InsertItemTemplate>
                    <br />
                    Town Name:
                    <asp:TextBox ID="TextBoxInsertTownName" runat="server" Text="<%# BindItem.Name %>" />
                    <br />
                    Town Population:
                    <asp:TextBox ID="TextBoxInsertPopulation" runat="server" Text="<%# BindItem.Population %>" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorTownName" runat="server"
                        ErrorMessage="Required field!" ControlToValidate="TextBoxInsertTownName">
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                </InsertItemTemplate>
            </asp:ListView>
        </tbody>
    </table>

</asp:Content>
