<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="user_registration.aspx.cs" Inherits="project_new_masterpage.WebForm1" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 27px;
    }
        .auto-style3 {
            height: 27px;
            width: 195px;
        }
        .auto-style4 {
            width: 195px;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
    <tr>
        <td class="auto-style3" style="height: 27px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Name"></asp:Label>
        </td>
        <td class="auto-style1" style="height: 27px">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style1" style="height: 27px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter the name"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style1" style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Age"></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox2" ErrorMessage="Mandatory field"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Email"></asp:Label>
        </td>
        <td style="height: 27px">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
        <td style="height: 27px">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Mandatory field" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Mandatory field" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Address"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="Enter the adddess"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px">
            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="State"></asp:Label>
        </td>
        <td style="height: 27px">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged1">
            </asp:DropDownList>
        </td>
        <td style="height: 27px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Mandatory field"></asp:RequiredFieldValidator>
        </td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="District"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Mandatory field"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px">
            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="Pincode"></asp:Label>
        </td>
        <td style="height: 27px">
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        </td>
        <td style="height: 27px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8" ErrorMessage="Mandatory field"></asp:RequiredFieldValidator>
        </td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px">
            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="True" Text="Username" ForeColor="#663300"></asp:Label>
        </td>
        <td style="height: 27px">
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </td>
        <td style="height: 27px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9" ErrorMessage="Mandatory field"></asp:RequiredFieldValidator>
        </td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px"></td>
        <td style="height: 27px">
            </td>
        <td style="height: 27px"></td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Text="Password" ForeColor="#663300"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td></td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#663300" Text="cofirm password"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox11" ErrorMessage="Password missmatch" ControlToCompare="TextBox10"></asp:CompareValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Smaller" Font-Strikeout="False" Font-Underline="False" ForeColor="#333300" Text="USER REGISTRATION" OnClick="Button1_Click" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" style="height: 27px"></td>
        <td style="height: 27px">
            <asp:Label ID="Label10" runat="server" Text="label"></asp:Label>
        </td>
        <td style="height: 27px"></td>
        <td style="height: 27px"></td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
