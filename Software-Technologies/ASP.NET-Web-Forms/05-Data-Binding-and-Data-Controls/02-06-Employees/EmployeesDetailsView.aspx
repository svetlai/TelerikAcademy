<%@ Page Language="C#" Title="Employee Details" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeesDetailsView.aspx.cs" Inherits="_5._2___5._6.Employees.EmployeesDetailsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:DetailsView ID="DetailsViewEmployee" runat="server" ></asp:DetailsView>
    <asp:HyperLink ID="HyperLinkBack" NavigateUrl="~/EmployeesGrid.aspx" runat="server">Go Back</asp:HyperLink>
</asp:Content>
