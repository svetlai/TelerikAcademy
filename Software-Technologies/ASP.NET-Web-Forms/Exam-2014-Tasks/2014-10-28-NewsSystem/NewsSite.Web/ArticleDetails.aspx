<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="NewsSite.Web.ArticleDetails" %>

<%@ Register TagPrefix="uc" TagName="LikeControl" Src="~/Controls/LikeControl.ascx" %>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:Panel ID="PanelLikeControl" runat="server" Visible="false">
            <asp:UpdatePanel ID="UpdatePanelLikeControl" runat="server">
                <ContentTemplate>
                    <div class="col-md-1">
                        <uc:LikeControl ID="LikeControl" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <div class="col-md-11">
            <asp:FormView ID="FormViewArticleDetails" runat="server"
                ItemType="NewsSite.Web.Models.Article"
                DataKeyNames="Id"
                SelectMethod="FormViewArticleDetails_GetData">
                <ItemTemplate>
                    <h2>Where can I get some? <small>Category: Education</small></h2>
                    <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don&amp;#39;t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn&amp;#39;t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.</p>
                    <p>
                        <span>Author: Anonimous</span>
                        <span class="pull-right">10/31/2014 11:02:29 AM</span>
                    </p>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
