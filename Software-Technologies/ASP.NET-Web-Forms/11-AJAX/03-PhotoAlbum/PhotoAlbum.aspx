<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlum.aspx.cs" Inherits="_11._3.Photo_Album.PhotoAlbum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/site.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ajaxToolkit:ToolkitScriptManager ID="ScriptManager" runat="server">
            </ajaxToolkit:ToolkitScriptManager>
            <div class="Image">
                <asp:Image ID="img1" runat="server"
                    Height="400px" Width="400px"
                    ImageUrl="~/images/1.jpg" />
            </div>

            <ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server"
                BehaviorID="SSBehaviorID"
                TargetControlID="img1"
                SlideShowServiceMethod="GetSlides"
                AutoPlay="true"
                ImageDescriptionLabelID="lblDesc"
                NextButtonID="btnNext"
                PreviousButtonID="btnPrev"
                PlayButtonID="btnPlay"
                PlayButtonText="Play"
                StopButtonText="Stop"
                Loop="true">
            </ajaxToolkit:SlideShowExtender>

            <div>
                <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label><br />
                <asp:Button ID="btnPrev" runat="server" Text="Previous" />
                <asp:Button ID="btnPlay" runat="server" Text="" />
                <asp:Button ID="btnNext" runat="server" Text="Next" />
            </div>
        </div>
        
    </form>
    <script type="text/javascript" src="libs/jquery-2.0.3.js"></script>
    <script type="text/javascript" src="scripts/main.js"></script>
</body>
</html>
