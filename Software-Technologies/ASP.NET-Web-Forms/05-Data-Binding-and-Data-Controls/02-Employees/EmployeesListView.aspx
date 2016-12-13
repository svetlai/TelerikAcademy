<%@ Page Language="C#" Title="Employees ListView" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="_5._2___5._6.Employees.EmployeesListView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Job Title</th>
                <th>City</th>
                <th>Address</th>
            </tr>
        </thead>
        <tbody>
            <asp:ListView ID="ListViewEmployees" ItemType="_5._2___5._6.Employees.Employee" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.FirstName + " " + Item.LastName %></td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Address %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>
    </table>
</asp:Content>
