<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="compstudshortlist.aspx.cs" Inherits="Admin_compstudshortlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="100%" HorizontalAlign="Center" Width="99%" ToolTip="Click Select to  Get the Details of the Company!" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="button primary" >

            </asp:CommandField>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:TemplateField HeaderText="logo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("imageurl") %>' Height="50px" Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [name], [imageurl] FROM [company]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="input-control text">
        <asp:ListItem Selected="True">short list</asp:ListItem>
        <asp:ListItem Value="r1">cleared round 1</asp:ListItem>
        <asp:ListItem Value="r2">cleared round 2</asp:ListItem>
        <asp:ListItem Value="r3">cleared round 3</asp:ListItem>
        <asp:ListItem Value="r4">cleared round 4</asp:ListItem>
        <asp:ListItem Value="r5">cleared round 5</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" AllowPaging="True" AllowSorting="True" PageSize="5" Height="100%" Width="100%" ToolTip="On Click Gets the Details of the Student!" DataKeyNames="sname" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="sname" HeaderText="sname" ReadOnly="True" SortExpression="sname" />
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [sname] FROM [adp]" OnSelecting="SqlDataSource2_Selecting"></asp:SqlDataSource>
    <br />
    <button id="Button1"  runat="server"   class="button primary" onserverclick="Button1_Click"><span class="mif-mail-read"></span> send e-mail</button>
</asp:Content>

