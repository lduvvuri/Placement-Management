<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/student/nomenu.master" AutoEventWireup="true" CodeFile="compstudinfo.aspx.cs" Inherits="student_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/student/studentimages/profile-male-default-image2.gif" CssClass="stuimg" />
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
                    <a href="../company/currentstudents.aspx" ><=GO BACK</a>
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
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divVideo" runat="server">
    </div>

</asp:Content>

