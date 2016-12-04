<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="_3._4.StudentsSystem.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formAddStudent" runat="server">
        <asp:Panel ID="PanelAddStudent" runat="server">
            <asp:Literal ID="LiteralFirstName" runat="server">First Name: </asp:Literal>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="LiteralLastName" runat="server">Last Name: </asp:Literal>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="LiteralFacultyNumber" runat="server">Faculty Number: </asp:Literal>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Literal ID="LiteralUniversity" runat="server">Select University: </asp:Literal>
            <br />
            <asp:DropDownList ID="DropDownListUniversity" runat="server">
                <asp:ListItem>Telerik Academy</asp:ListItem>
                <asp:ListItem>University of National and World Economy</asp:ListItem>
                <asp:ListItem>Sofia University</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Literal ID="LiteralCourses" runat="server">Select Courses: </asp:Literal>
            <br />
            <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple">
                <asp:ListItem>ASP.NET Web Forms</asp:ListItem>
                <asp:ListItem>ASP.NET MVC</asp:ListItem>
                <asp:ListItem>Node JS</asp:ListItem>
                <asp:ListItem>CSS</asp:ListItem>
                <asp:ListItem>JavaScript Fundamentals</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:Button ID="ButtonAddStudent" runat="server" Text="Add Student" OnClick="ButtonAddStudent_Click" />
            <asp:RequiredFieldValidator ControlToValidate="TextBoxFirstName" runat="server"
                ErrorMessage="First name is required!" />
            <asp:RequiredFieldValidator ControlToValidate="TextBoxLastName" runat="server"
                ErrorMessage="Last name is required!" />
        </asp:Panel>
        <asp:Panel ID="PanelAddedStudent" runat="server"></asp:Panel>
    </form>
</body>
</html>
