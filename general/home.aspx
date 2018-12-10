<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <marquee direction="up" loop="true" width="100%"  onmouseover="this.stop();" onmouseout="this.start();" style="height: 83%">
             <ul class="news">
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="skyblue" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="400px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="50%" BorderWidth="10px" CssClass="cal">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderColor="skyblue" BorderWidth="30px" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="skyblue" ForeColor="White" />
        <TitleStyle BackColor="skyblue" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderColor="Black" BorderWidth="4px" />
        <TodayDayStyle BackColor="CadetBlue" ForeColor="White" />
    </asp:Calendar>
    <table style="float: left; height: 400px;margin-left:50px">
        <tr>
            <th colspan="3"><asp:Label ID="day" runat="server" Text=""></asp:Label></th>
        </tr>
        <tr>
            <td >Company Name</td>
            <td>:</td>
            <td>
                <asp:Label ID="name" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td >Round</td>
            <td>:</td>
            <td>
                <asp:Label ID="round" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td >Date</td>
            <td>:</td>
            <td>
                <asp:Label ID="date" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Branches</td>
            <td>:</td>
            <td>
                <asp:Label ID="req" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Venue</td>
            <td>:</td>
            <td>
                <asp:Label ID="venue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Time</td>
            <td>:</td>
            <td>
                <asp:Label ID="time" runat="server" Text="" TextMode="date"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>:</td>
            <td>
                <asp:Label ID="address" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>



