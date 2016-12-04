<%@ Page Title="ToDo" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ToDo.aspx.cs" Inherits="Countries.Web.ToDo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <table>
        <thead>
            <tr>
                <th></th>
                <th>Title</th>
                <th>Body</th>
                <th>Date Modified</th>
                <th>Category</th>
            </tr>
        </thead>
        <tbody>
            <asp:ListView ID="ListViewToDos" runat="server" ItemType="Countries.Models.ToDo.ToDoTask" DataKeyNames="Id"
                OnItemEditing="ListViewToDos_ItemEditing"
                OnItemDeleting="ListViewToDos_ItemDeleting"
                OnItemCanceling="ListViewToDos_ItemCanceling"
                OnItemUpdating="ListViewToDos_ItemUpdating"
                OnItemInserting="ListViewToDos_ItemInserting"
                InsertItemPosition="None"
                ItemPlaceholderID="toDosPlaceholder">
                <ItemTemplate>
                    <tr>
                        <td>
                           <asp:Button ID="EditButton" runat="server"
                                CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server"
                                CommandName="Delete" Text="Delete" />
                        </td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.Body %></td>
                        <td><%#: Item.DateModified %></td>
                        <td><%#: Item.Category.Name %></td>
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
                        <td><%#: Item.Id %></td>
                        <td>
                            <asp:TextBox ID="ToDoTitleTextBox" runat="server"
                                Text='<%# Item.Title %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ToDoBodyTextBox" runat="server"
                                Text='<%# Item.Body %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ToDoCategoryTextBox" runat="server"
                                Text='<%# Item.Category.Name %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                    <LayoutTemplate>
                    <asp:Button ID="ButtonInsertTown" runat="server" OnClick="ButtonInsertToDo_Click" Text="Add New" />
                        <asp:PlaceHolder runat="server" ID="toDosPlaceholder"></asp:PlaceHolder>
                    <br />
                        </LayoutTemplate>
                <InsertItemTemplate>
                    <br />
                    Title:
                    <asp:TextBox ID="ToDoTitleInsertTextBox" runat="server" Text="<%# BindItem.Title %>" />
                    <br />
                    Body
                    <asp:TextBox ID="ToDoBodyInsertTextBox" runat="server" Text="<%# BindItem.Body %>" />
                    <br />
                    Category
                    <asp:TextBox ID="ToDoCategoryInsertTextBox" runat="server" Text="<%# BindItem.Category %>" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorToDoTitle" runat="server"
                        ErrorMessage="Required field!" ControlToValidate="ToDoTitleInsertTextBox">
                    </asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorToDoBody" runat="server"
                        ErrorMessage="Required field!" ControlToValidate="ToDoBodyInsertTextBox">
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="ButtonInsert" runat="server" CommandName="Insert" Text="Insert" />
                </InsertItemTemplate>
            </asp:ListView>
        </tbody>
    </table>
</asp:Content>
