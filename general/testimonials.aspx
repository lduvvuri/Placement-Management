<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="general_testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
      
     
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [msg] FROM [stestimo]"></asp:SqlDataSource>
    
     
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="msg" HeaderText="student testimonials" SortExpression="msg" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
         <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="10" position="Bottom" />
        <PagerStyle CssClass="pagination" HorizontalAlign="Center"  Font-Underline="true" VerticalAlign="Middle" BackColor="#999999" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
      </asp:GridView>
    
      </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"  >

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="msg" HeaderText="company testimonials" SortExpression="msg" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
         <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="10" position="Bottom" />
        <PagerStyle CssClass="pagination" HorizontalAlign="Center"  Font-Underline="true" VerticalAlign="Middle" BackColor="#999999" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [msg] FROM [testimo]"></asp:SqlDataSource>
</asp:Content>

