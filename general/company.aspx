<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/general/home.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 106px;
        }
        .auto-style4 {
            width: 23px;
        }
        .auto-style7 {
            width: 23px;
            height: 55px;
        }
        .auto-style8 {
            height: 55px;
        }
        .auto-style9 {
            width: 70px;
            height: 51px;
        }
        .auto-style18 {
            width: 23px;
            height: 78px;
        }
        .auto-style19 {
            height: 78px;
        }
        .auto-style20 {
            width: 23px;
            height: 64px;
        }
        .auto-style21 {
            height: 64px;
        }
        .auto-style22 {
            width: 23px;
            height: 63px;
        }
        .auto-style23 {
            height: 63px;
        }
        .auto-style24 {
            width: 23px;
            height: 56px;
        }
        .auto-style25 {
            height: 56px;
        }
        .auto-style26 {
            width: 23px;
            height: 52px;
        }
        .auto-style27 {
            height: 52px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:GridView ID="GridView1" runat="server" CssClass="table "  AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="100%" Width="100%" ToolTip="On Click Enables to see the Details of the Company!" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="select" ControlStyle-CssClass="button primary">
            </asp:CommandField>
            <asp:BoundField DataField="name" HeaderText="Company Name" SortExpression="name" />
            <asp:TemplateField HeaderText="Company Logo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("imageurl") %>' Height="50px" Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>
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
		
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [name], [imageurl] FROM [company]"></asp:SqlDataSource>
		
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%; height: 80%;">
        <tr>
            <td class="auto-style4">&nbsp;<br />
                NAME:</td>
            <td class="auto-style3">
                &nbsp;&nbsp;<asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style4">ADDRESS:</td>
            <td class="auto-style9">
                &nbsp;&nbsp;&nbsp; &nbsp;
                
                <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style26">EMAIL:</td>
            <td class="auto-style27">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style7">CONTACT NO.:</td>
            <td class="auto-style8">
                &nbsp;&nbsp;&nbsp; &nbsp;
                
                <asp:Label ID="lbContact" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style24">CONTACT PERSON:</td>
            <td class="auto-style25">
                &nbsp;&nbsp;&nbsp; &nbsp;
                
                <asp:Label ID="lbPerson" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="Label2" runat="server" Text="PREFERRED KMOWLEDGE:"></asp:Label>
            </td>
            <td class="auto-style23">
                <br />
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style18">
                <asp:Label ID="Label3" runat="server" Text="STARTING SALARY:"></asp:Label>
            </td>
            <td class="auto-style19">
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style20">
            </td>
            <td class="auto-style21">
            </td>
        </tr>
        </table>
</asp:Content>
