<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumberGenerator.aspx.cs" Inherits="_3._1.Random_Number_Generator___HTML.NumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formNumberGenerator" runat="server">
    <div>
        <h3>Random Number Generator - using HTML Controls</h3>
        <p>Enter min and max values to declare the number's range.</p>
        <input type="text" id="TextMin" runat="server" placeholder="Min" />
        <input type="text" id="TextMax" runat="server" placeholder="Max" />
        <input id="ButtonSubmit" type="button"
            runat="server" value="Generate"
            onserverclick="ButtonSubmit_Click" />
        <h3 runat="server" id="SpanResult"></h3>
    </div>
    </form>
</body>
</html>
