<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="Studentinfo.aspx.cs" Inherits="Admin_Studentinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/student/studentimages/profile-male-default-image2.gif" CssClass="stuimg" />
        <table style="width:50%; float:left; ">
            <tr>
                <td>Student HallTicket Number</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lbhaltkt" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Student name</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lbname" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>:</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Branch</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lbbranch" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>E-Mail</td>
                <td>:</td>
                <td>
                    <asp:Label ID="email" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Contact Number</td>
                <td>:</td>
                <td>
                    <asp:Label ID="contact" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>B.Tech overall percentage</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lbper" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="../Admin/CurrentStudents.aspx" ><=GO BACK</a>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    </div>
    <table style="width: 100%;">
        <tr>
            <td>Skills</td>
            <td>:</td>
            <td>
                <asp:Label ID="lbsk" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Video" Font-Bold="True"></asp:Label>
    :
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="input" OnTextChanged="TextBox1_TextChanged" TextMode="Url"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Upload URL" />
    <asp:Label ID="Label2" runat="server"></asp:Label>
</asp:Content>