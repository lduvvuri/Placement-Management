<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="general_Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" GridLines="None" Height="100%" Width="100%" ToolTip="On Click Enables to see the Details of the Company!" AllowSorting="True" DataKeyNames="sno">

        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="select" ControlStyle-CssClass="button primary">
            </asp:CommandField>
           
            <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" ReadOnly="True" />
            <asp:BoundField DataField="question" HeaderText="question" SortExpression="question" />
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
    <asp:Label ID="Label1" runat="server" Text="Ask Questions Here:"></asp:Label>
    <asp:TextBox ID="tb1" runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT * FROM [forum]"></asp:SqlDataSource>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

