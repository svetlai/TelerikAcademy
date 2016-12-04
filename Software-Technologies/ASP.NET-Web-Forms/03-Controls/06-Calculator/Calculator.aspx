<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_3._6.Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .calcButton {
            width: 50px;
            height: 30px;
            display: inline;
        }

        .equalsButton {
            width: 150px;
            height: 30px;
            margin-left:30px;
        }
        .resultBox {
            margin-left:30px;
        }
        #ButtonClear {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="formCalculator" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <div class="resultBox">
                <asp:TextBox ID="TextBoxResult" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="1" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button2" runat="server" Text="2" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button3" runat="server" Text="3" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="ButtonPlus" runat="server" Text="+" class="calcButton" onclick="ButtonOperator_Click"/>
            </div>
            <div>
                <asp:Button ID="Button4" runat="server" Text="4" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button5" runat="server" Text="5" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button6" runat="server" Text="6" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="ButtonMinus" runat="server" Text="-" class="calcButton" onclick="ButtonOperator_Click" />
            </div>
            <div>
                <asp:Button ID="Button7" runat="server" Text="7" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button8" runat="server" Text="8" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="Button9" runat="server" Text="9" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="ButtonMultiply" runat="server" Text="*" class="calcButton" onclick="ButtonOperator_Click"/>
            </div>
            <div>
                <asp:Button ID="ButtonClear" runat="server" Text="Clear" class="" onclick="ButtonClear_Click"/>
                <asp:Button ID="Button0" runat="server" Text="0" class="calcButton" onclick="ButtonNumber_Click" />
                <asp:Button ID="ButtonDivide" runat="server" Text="/" class="calcButton" onclick="ButtonOperator_Click"/>
                <asp:Button ID="ButtonSqrt" runat="server" Text="&#8730;" class="calcButton" onclick="ButtonSqrt_Click"/>
            </div>
            <div>
                <asp:Button ID="ButtonEquals" runat="server" Text="=" class="equalsButton" onclick="ButtonEquals_Click"/>
            </div>
            <asp:HiddenField runat="server" ID="NumberStorage" Value="" />
            <asp:HiddenField runat="server" ID="Operator" Value="" />
            <asp:HiddenField runat="server" ID="hasResult" Value="" />
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" 
                ControlToValidate="TextBoxResult" ErrorMessage="Value must be a number" />
        </asp:Panel>
    </form>
</body>
</html>
