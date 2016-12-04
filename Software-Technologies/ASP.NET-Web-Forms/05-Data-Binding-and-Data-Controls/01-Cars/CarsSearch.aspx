<%@ Page Language="C#" Title="Search" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarsSearch.aspx.cs" Inherits="_5._1.Cars.CarsSearch" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:DropDownList ID="DropDownListProducers" runat="server"
        DataTextField="Name"
        OnSelectedIndexChanged="DropDownListProducers_SelectedIndexChanged"
        AutoPostBack="true">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownListModels" runat="server" DataTextField="Name" ></asp:DropDownList>
    <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" DataTextField="Name"></asp:CheckBoxList>
    <asp:RadioButtonList ID="RadioButtonListEngines" runat="server"></asp:RadioButtonList>
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
    <br />
    <hr />
    <asp:Literal ID="LiteralSearchInfo" runat="server"></asp:Literal>
</asp:Content>

