<%@ Page Title="File Upload" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="_7.File_Upload.FileUpload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
 <input name="uploaded" id="uploaded" type="file" runat="server" />

    <div runat="server" id="uploadedStuff">
        <%= FileOutput %>
    </div>

    <script>
        //function onUpload(e) {
        //    var files = e.files;
        //    $.each(files, function () {
        //        if (this.extension.toLowerCase() != ".zip") {
        //            alert("Only .zip files can be uploaded");
        //            e.preventDefault();
        //        }
        //    });
        //}

        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload",
                    autoUpload: true,
                },
                //upload: onUpload
            });
        });
    </script>
    </asp:Content>
