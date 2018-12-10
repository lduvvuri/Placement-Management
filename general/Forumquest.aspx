<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="Forumquest.aspx.cs" Inherits="general_Forumquest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1> <asp:Label ID="lbname" runat="server" Text="Question:"></asp:Label></h1>
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="10" position="Bottom" />
        <PagerStyle CssClass="pagination"  Font-Underline="true" VerticalAlign="Middle" BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left"/>
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [comment] FROM [comments]"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Comment Here:"></asp:Label>
    <asp:TextBox ID="tb1" runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

