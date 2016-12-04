<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs" Inherits="Countries.Web.Controls.FileUpload" %>

<asp:FileUpload ID="ImageUpload" runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldImage" Visible="false" ControlToValidate="ImageUpload" CssClass="label label-danger pull-right" ErrorMessage="Image is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>