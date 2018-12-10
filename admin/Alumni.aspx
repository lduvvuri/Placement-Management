<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="Alumni.aspx.cs" Inherits="Admin_Alumni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 158px;
            height: 76px;
        }
        .auto-style4 {
            width: 7px;
            height: 76px;
        }
        .auto-style5 {
            height: 76px;
        }
        .auto-style9 {
            width: 158px;
            height: 72px;
        }
        .auto-style10 {
            width: 7px;
            height: 72px;
        }
        .auto-style11 {
            height: 72px;
        }
        .auto-style12 {
            width: 158px;
            height: 51px;
        }
        .auto-style13 {
            width: 7px;
            height: 51px;
        }
        .auto-style14 {
            height: 51px;
        }
        .auto-style15 {
            width: 158px;
            height: 61px;
        }
        .auto-style16 {
            width: 7px;
            height: 61px;
        }
        .auto-style17 {
            height: 61px;
        }
        .auto-style18 {
            width: 158px;
            height: 62px;
        }
        .auto-style19 {
            width: 7px;
            height: 62px;
        }
        .auto-style20 {
            height: 62px;
        }
        .auto-style21 {
            width: 158px;
            height: 35px;
        }
        .auto-style22 {
            width: 7px;
            height: 35px;
        }
        .auto-style23 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="sno" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="Black" Height="100%"  AllowPaging="True" AllowSorting="True" PageSize="5" ToolTip="Select to get the Details of the Alumni!" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="button primary" >

            </asp:CommandField>
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="cname" HeaderText="Company Name" SortExpression="cname" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [sno], [name], [branch], [cname], [salary], [email] FROM [alumni]"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style21">
                <asp:Label ID="Label7" runat="server" Text="ID"></asp:Label>
            </td>
            <td class="auto-style22">:</td>
            <td class="auto-style23">
                <asp:Label ID="lbsno" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="auto-style10">:</td>
            <td class="auto-style11">
                <span class=" button mif-user icon bg-white fg-dark"></span><asp:TextBox ID="tbName" runat="server" CssClass="input-control text" ToolTip="Enter the Name of the Alumni"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" CssClass="validate" Display="Dynamic" ErrorMessage="Name required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label3" runat="server" Text="Branch"></asp:Label>
            </td>
            <td class="auto-style10">:</td>
            <td class="auto-style11">
                <span class=" button mif-tree icon bg-white fg-dark"></span><asp:TextBox ID="tbBranch" runat="server" CssClass="input-control text" ToolTip="Enter the Branch of Alumni"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbBranch" CssClass="validate" Display="Dynamic" ErrorMessage="Branch required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style18">
                <asp:Label ID="Label4" runat="server" Text="Company Name"></asp:Label>
            </td>
            <td class="auto-style19">:</td>
            <td class="auto-style20">
                <span class=" button mif-suitcase icon bg-white fg-dark"></span><asp:TextBox ID="tbCname" runat="server" CssClass="input-control text" ToolTip="Enter the name of the company where the Alumni is placed"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbCname" CssClass="validate" Display="Dynamic" ErrorMessage="Company name Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">
                <asp:Label ID="Label5" runat="server" Text="Salary"></asp:Label>
            </td>
            <td class="auto-style16">:</td>
            <td class="auto-style17">
               <span class=" button mif-money icon bg-white fg-dark"></span><asp:TextBox ID="tbSalary" runat="server" CssClass="input-control text" ToolTip="Enter the salary package of Almuni"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbSalary" CssClass="validate" Display="Dynamic" ErrorMessage="Salary Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label6" runat="server" Text="E-mail"></asp:Label>
            </td>
            <td class="auto-style13">:</td>
            <td class="auto-style14">
                <span class=" button mif-mail icon bg-white fg-dark"></span><asp:TextBox ID="tbEmail" runat="server" CssClass="input-control text" ToolTip="Enter the Email id of the Alumni"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbEmail" CssClass="validate" ErrorMessage="Email required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <button id="Button1" runat="server"   onserverclick="Button1_Click" class="button primary" tooltip="Inserts the Details of  New Alumni's!" ><span class=" mif-file-download icon"></span> Insert</button>
                <button id="Button2" runat="server"   onserverclick="Button2_Click" class="button primary" tooltip="Updates the Details of Existing Alumni's!" ><span class=" mif-file-upload icon"></span> Update</button>
               </td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">
                <button id="Button3" runat="server"  onserverclick="Button3_Click" class="button primary" tooltip="Delete's the Details of the Existing Alumni's!" ><span class=" mif-bin icon"></span> Delete</button>
                </td>
        </tr>
    </table>
</asp:Content>


