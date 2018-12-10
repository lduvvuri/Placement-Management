<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="adminhome.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50px;
        }
        .auto-style2 {
            width: 268435456px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="cl1">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="skyblue" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="425px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="50%" BorderWidth="10px" CssClass="cal" SelectedDate="01-01-0001">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderColor="skyblue" BorderWidth="30px" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#000000" ForeColor="White" />
        <TitleStyle BackColor="skyblue" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderColor="Black" BorderWidth="4px" />
        <TodayDayStyle BackColor="CadetBlue" ForeColor="White" />
    </asp:Calendar>
    <table style="width: 48%; float: left; height: 427px;">
        <tr>
            <th colspan="4"><asp:Label ID="day" runat="server" Text=""></asp:Label></th>
        </tr>
        <tr>
            <td class="auto-style1" >company name</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <asp:label ID="name" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"  >round<asp:Label ID="no" runat="server" Text=""></asp:Label>
            </td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <asp:label ID="round" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"  >date</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <asp:Label ID="date" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >Branches</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <asp:label ID="req" runat="server" ></asp:label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >venue</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                
                <span class=" button mif-lg mif-location-city icon bg-white fg-dark"></span><asp:TextBox ID="venue" runat="server" CssClass="input-control text" ToolTip="Enter the Venue details for the Round that is going to take place!" ValidationGroup="calup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="venue" Display="Dynamic" ErrorMessage="venue required" CssClass="validate" ValidationGroup="date"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >time</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <span class=" button mif-lg mif-alarm icon bg-white fg-dark"></span><asp:TextBox ID="time" runat="server" TextMode="time" CssClass="input-control text" ToolTip="Enter the Timings for Round that is going to take place" ValidationGroup="calup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="time" Display="Dynamic" ErrorMessage="time required" CssClass="validate" ValidationGroup="date"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >address</td>
            <td colspan="2" >:</td>
            <td class="auto-style2">
                <span class=" button mif-lg mif-map icon bg-white fg-dark"></span><asp:TextBox ID="address" runat="server" Rows="5" TextMode="MultiLine" CssClass="input-control text" ToolTip="Enter the Address for the round that is going to takeplace!" ValidationGroup="calup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="address" Display="Dynamic" ErrorMessage="address required" CssClass="validate" ValidationGroup="date"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th colspan="2">
                <button runat="server" id="Button1" onserverclick="Button1_Click" ValidationGroup="date" class="button primary" > <span class=" mif-file-upload icon "></span>submit</button>
            </th>
            <th colspan="2">
                <asp:Label ID="update" runat="server" CssClass="validate"></asp:Label>
            </th>
        </tr>
    </table>

        </div>

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <marquee direction="up" loop="true" width="100%" onmouseover="this.stop();" onmouseout="this.start();" style="height: 64%">
             <ul>
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>
    <asp:TextBox ID="newstb" runat="server" Columns="45" Rows="5" TextMode="MultiLine" CssClass="input-control text" ToolTip="Enter the Important Events of the college" ValidationGroup="news"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="newstb" CssClass="validate" Display="Dynamic" ErrorMessage="enter  news" ValidationGroup="news"></asp:RequiredFieldValidator>
    <br />
    <button id="Button3" runat="server" onserverclick="news_Click" class="button primary" ValidationGroup="news"><span class=" mif-clipboard icon"></span> submit</button>
    <br />
    <button id="Button2" runat="server" class="button primary" onserverclick="Button2_Click" ValidationGroup="deldata"><span class=" mif-cancel icon"></span> clean slate</button>
    
</asp:Content>
