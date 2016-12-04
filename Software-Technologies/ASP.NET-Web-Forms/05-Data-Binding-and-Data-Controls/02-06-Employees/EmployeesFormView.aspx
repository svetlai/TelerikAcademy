<%@ Page Language="C#" Title="Employees FormView" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeesFormView.aspx.cs" Inherits="_5._2___5._6.Employees.EmployeesFormView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:FormView ID="FormViewEmployees" ItemType="_5._2___5._6.Employees.Employee" runat="server">
        <ItemTemplate>
            <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
            <table>
                <tr>
                    <td>Job Title:</td>
                    <td><%#: Item.Title %></td>
                </tr>
                <tr>
                    <td>City</td>
                    <td><%#: Item.City %></td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td><%#: Item.Address %></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:GridView ID="GridViewEmployees" runat="server" OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" DataKeyNames="EmployeeID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>