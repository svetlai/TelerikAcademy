<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" MasterPageFile="~/Site.Master" Inherits="_2.Hello_ASP.NET.Hello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <p>Hello, ASP.NET from aspx.</p>
            <asp:Label ID="LabelHello" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <span>Assembly: </span><asp:Label ID="LabelAssembly" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <p class="italic">Code-behind refers to code for your ASP.NET page that is contained within a separate class file. 
                This allows a clean separation of the HTML from the presentation logic.</p>
        </div>
    </div>
</asp:Content>
