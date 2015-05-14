<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="NewsSite.Web.Controls.Like" %>
<div class="row likes">
    <div class="col-md-12">Likes</div>
    <div class="col-md-12">
        <asp:Button ID="ButtonVoteUp" CssClass="btn btn-default"
            runat="server" Text="+" OnClick="ButtonVoteUp_Click" />
    </div>
    <div class="col-md-12">
        <asp:Label CssClass="text-center like-value" ID="LabelLike" runat="server"></asp:Label>
    </div>
    <div class="col-md-12">
        <asp:Button ID="ButtonVoteDown" CssClass="btn btn-default"
            runat="server" Text="-" OnClick="ButtonVoteDown_Click" />
    </div>
</div>
