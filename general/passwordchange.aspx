<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/css/nomenu.master" AutoEventWireup="true" CodeFile="passwordchange.aspx.cs" Inherits="general_passwordchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="oldpwd" runat="server" TextMode="Password" CssClass="input" ></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="pwd" runat="server" Text="" CssClass="validate" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td>new password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="newpwd" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>confirm password</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="conpwd" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newpwd" ControlToValidate="conpwd" Display="Dynamic" ErrorMessage="password mismatch" CssClass="validate"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="view" runat="server" Text="" CssClass="validate"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="change" OnClick="Button1_Click" CssClass="button primary" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

