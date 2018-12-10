<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="Alumni.aspx.cs" Inherits="general_Alumni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="sno" DataSourceID="SqlDataSource1" ForeColor="Black" PageSize="4" Height="100%" Width="99%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="button primary"  >

<ControlStyle CssClass="button primary"></ControlStyle>

            </asp:CommandField>
            <asp:BoundField DataField="sno" HeaderText="S.No" ReadOnly="True" SortExpression="sno" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="branch" HeaderText="Branch" SortExpression="branch" />
            <asp:BoundField DataField="cname" HeaderText="Company Name" SortExpression="cname" />
            <asp:BoundField DataField="salary" HeaderText="Salary" SortExpression="salary" />
            <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="10" position="Bottom" />
        <PagerStyle CssClass="pagination" HorizontalAlign="Left"  Font-Underline="true" VerticalAlign="Middle" BackColor="#CCCCCC" ForeColor="Black"/>
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [sno], [name], [branch], [cname], [salary], [email] FROM [alumni]"></asp:SqlDataSource>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <div id="placeholder-div"></div>
    <script>
        gapi.hangout.layout('placeholder-div', { 'render': 'createhangout' });
</script>
    <script >
        window.___gcfg = {
            lang: 'zh-CN',
            parsetags: 'onload'
        };
</script>
<script src="https://apis.google.com/js/platform.js" async defer></script>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
<div class="g-hangout" data-render="createhangout"
    data-initial_apps="[{ app_id : '123456789012', start_data : 'dQw4w9WgXcQ', 'app_type' : 'ROOM_APP' }]">
</div>
    <script>
        window.___gcfg = {
            lang: 'en-US'
        };
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <marquee direction="up" loop="true" width="100%" onmouseover="this.stop();" onmouseout="this.start();" style="height: 80%">
             <ul>
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>

</asp:Content>

