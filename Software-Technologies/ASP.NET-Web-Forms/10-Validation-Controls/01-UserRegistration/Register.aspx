<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_10._1.User_Registration.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Site.css" type="text/css" />
</head>
<body>
    <form id="formRegister" runat="server">
    <div>
        <asp:TextBox ID="TextBoxUserName" runat="server" placeholder="Username"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ControlToValidate="TextBoxUserName" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ControlToValidate="TextBoxPassword" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxConfirmPassword" TextMode="Password" runat="server" placeholder="Confirm Passowrd"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" ControlToValidate="TextBoxConfirmPassword" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidatorConfirmPassword" ControlToValidate="TextBoxConfirmPassword" ControlToCompare="TextBoxPassword" runat="server" ErrorMessage="Passwords don't match."></asp:CompareValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxFirstName" runat="server" placeholder="First Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ControlToValidate="TextBoxFirstName" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxLastName" runat="server" placeholder="Last Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ControlToValidate="TextBoxLastName" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxAge" TextMode="Number" runat="server" placeholder="Age"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ControlToValidate="TextBoxAge" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidatorAge" ControlToValidate="TextBoxAge" MaximumValue="81" MinimumValue="18" runat="server" ErrorMessage="Age must be between 18 and 81"></asp:RangeValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxEmail" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ControlToValidate="TextBoxEmail" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" ControlToValidate="TextBoxEmail" ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" runat="server" ErrorMessage="Please enter your email in the correct format."></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxAddress" runat="server" placeholder="Address"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" ControlToValidate="TextBoxAddress" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBoxPhone" TextMode="Phone" runat="server" placeholder="Phone number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ControlToValidate="TextBoxPhone" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" ControlToValidate="TextBoxPhone" ValidationExpression="/(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]‌​)\s*)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)([2-9]1[02-9]‌​|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})/" runat="server" ErrorMessage="Please enter your phone number in the correct format."></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:CheckBox ID="CheckBoxAccept" runat="server" />
        <asp:Literal ID="LiteralAccept" runat="server">I Accept</asp:Literal>
        <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
    OnServerValidate="CheckBoxRequired_ServerValidate">You must select this box to proceed.</asp:CustomValidator>
        <br />
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" onclick="ButtonSubmit_Click"/>
        <br />
        <br />
        <asp:Literal ID="LiteralSuccess" runat="server"></asp:Literal>
        <br />
        <asp:ValidationSummary ID="ValidationSummaryRegisterForm" ForeColor="Red" runat="server" />
    </div>
    </form>
</body>
</html>
