<%@ Page Language="C#" Title="Employees Repeater" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="_5._2___5._6.Employees.EmployeesRender" %>

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
            <asp:Repeater ID="RepeaterEmployees" ItemType="_5._2___5._6.Employees.Employee" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.FirstName + " " + Item.LastName %></td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Address %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
