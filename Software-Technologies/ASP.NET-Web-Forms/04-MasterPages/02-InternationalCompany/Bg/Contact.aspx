<%@ Page Title="Контакти" Language="C#" MasterPageFile="~/SiteBg.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainBgContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Контакти</h3>
    <address>
        София<br />
        ул. Раковска 108А<br />
        <abbr title="Phone">тел:</abbr>
        02/555-55-55
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Маркетинг:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
