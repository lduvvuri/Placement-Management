<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="sendmsg.aspx.cs" Inherits="PassAdmin_sendmsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    
        .auto-style1 {
            width: 158px;
        }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table border="0" class="auto-style10">
<tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Send Message" CssClass="auto-style8" Font-Size="X-Large" Font-Underline="True" Height="30px" Width="143%"></asp:Label>
        </td>
    
</tr>
<tr>
    
    <td>
        <asp:Label ID="onetimepwd" runat="server" Text="OTP"></asp:Label>
    </td>
    
    <td class="auto-style1">
        <asp:TextBox ID="onetp" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    
</tr>
<tr>
    
    <td colspan="2">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" CssClass="button" />
    </td>
    
</tr>
</table>
</asp:Content>

