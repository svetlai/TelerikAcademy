<%@ Page Title="Employees Grid" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeesGrid.aspx.cs" Inherits="_5._2___5._6.Employees.EmployeesGrid" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="GridViewEmployees" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="EmployeeID"
                DataNavigateUrlFormatString="EmployeesDetailsView.aspx?EmployeeID={0}"
                HeaderText="LastName"
                DataTextField="LastName" />
        </Columns>
    </asp:GridView>
</asp:Content>

