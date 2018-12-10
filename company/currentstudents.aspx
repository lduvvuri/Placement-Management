<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/company/company.master" AutoEventWireup="true" CodeFile="currentstudents.aspx.cs" Inherits="company_currentstudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" Height="100%" PageSize="5" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ItemType="On Click Enables to see the Details of the Student!" ToolTip="On Click Enables to see the Complete Details of the Student!" AllowPaging="True" DataSourceID="SqlDataSource1" OnRowUpdating="GridView1_RowUpdating" AllowSorting="True" DataKeyNames="sname" OnRowUpdated="GridView1_RowUpdated" OnDataBound="GridView1_DataBound" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="button primary" ButtonType="Button" >

            </asp:CommandField>
            <asp:CommandField ShowEditButton="True"  ControlStyle-CssClass="button primary" ButtonType="Button">

            </asp:CommandField>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT sname FROM [microsoft]" UpdateCommand="update microsoft set r1=@r1,r2=@r2,r3=@r4,r4=@r4,r5=@r5 where sname=@sname">
        <UpdateParameters>
            <asp:Parameter Name="r1" />
            <asp:Parameter Name="r2" />
            <asp:Parameter Name="r4" />
            <asp:Parameter Name="r5" />
            <asp:Parameter Name="sname" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <table style="width:100%;">
        <tr>
            <td><button class="button primary"><a href="../company/company.aspx" style="color:white;">change criteria</a></button></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="button primary" ToolTip="Submits the ShortListed Students!" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <marquee direction="up" loop="true" width="100%" onmouseover="this.stop();" onmouseout="this.start();" style="height: 80%">
             <ul class="news">
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>
    
</asp:Content>

