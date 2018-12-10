<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            height: 73px;
        }
        .auto-style5 {
            height: 73px;
            width: 78px;
        }
        .auto-style7 {
        }
        .auto-style8 {
            height: 106px;
            width: 78px;
        }
        .auto-style9 {
            height: 106px;
        }
        .auto-style10 {
            height: 100px;
            width: 78px;
        }
        .auto-style11 {
            height: 100px;
        }
        .auto-style12 {
            width: 78px;
            height: 40px;
        }
        .auto-style13 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="100%" HorizontalAlign="Center" Width="99%" ToolTip="Click Select to  Get the Details of the Company!" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="button primary" >
            </asp:CommandField>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:TemplateField HeaderText="LOGO">
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
    <table style="width: 100%; height: 477px;">
        <tr>
            <td>
                <asp:Label ID="lbcid" runat="server" Text="Company ID"></asp:Label>
            </td>
            </tr>
            <td class="auto-style5">&nbsp; NAME:</td>
            <td class="auto-style3">
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <span class=" button mif-user icon bg-white fg-dark"></span><asp:TextBox ID="tbCompanyName" runat="server" CssClass="input-control text" ToolTip="Enter the Name of  the Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCompanyName" Display="Dynamic" ErrorMessage="name required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">ADDRESS:</td>
            <td class="auto-style9">
                &nbsp;&nbsp;&nbsp; &nbsp;
                <span class=" button mif-location icon bg-white fg-dark"></span><asp:TextBox ID="tbAddress" runat="server" CssClass="input-control text" ToolTip="Enter the Address of the Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbAddress" Display="Dynamic" ErrorMessage="address required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">EMAIL:</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class=" button mif-mail icon bg-white fg-dark"></span><asp:TextBox ID="tbEmail" runat="server" TextMode="Email" CssClass="input-control text" ToolTip="Enter the Email id of the Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="email id required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">CONTACT NO.:</td>
            <td class="auto-style11">
                &nbsp;&nbsp;&nbsp; &nbsp;
                <span class=" button  mif-phone-in-talk icon bg-white fg-dark"></span><asp:TextBox ID="tbContact" runat="server" TextMode="Phone" CssClass="input-control text" ToolTip="Enter the Contact Number of the  Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbContact" Display="Dynamic" ErrorMessage="contact number required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">CONTACT PERSON:</td>
            <td class="auto-style13">
                &nbsp;&nbsp;&nbsp; &nbsp;
                <span class=" button mif-user icon bg-white fg-dark"></span><asp:TextBox ID="tbContactPerson" runat="server" CssClass="input-control text" ToolTip="Enter the Name of the Contact person(H.R) of the Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbContactPerson" Display="Dynamic" ErrorMessage="name required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
            <tr>
            <td class="auto-style12">LOGO:</td>
            <td class="auto-style13">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class=" button mif-image icon bg-white fg-dark"></span><asp:TextBox ID="tbLogo" runat="server" CssClass="input-control text" ToolTip="Enter the Image Path to get the Logo of the Company!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbLogo" Display="Dynamic" ErrorMessage="logo required" CssClass="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
            <tr>
            <td class="auto-style7">
                PASSWORD:</td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class=" button mif-pencil icon bg-white fg-dark"></span><asp:TextBox ID="pwd" runat="server" CssClass="input-control text" ToolTip="Enter the Password and Give it to the Company!"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="2">
                
                <button id="Button1" runat="server"  onserverclick="Button1_Click1" class="button primary" tooltip="Inserts the Details of the New Company!"><span class="mif-file-download"></span>Insert</button>
           &nbsp;&nbsp;
                <button id="Button2" runat="server"  onserverclick="Button2_Click" class="button primary" tooltip="Updates the Details of the Existing Company!"><span class=" mif-file-upload"></span>update</button>
                &nbsp;&nbsp;
                <button id="Button3" runat="server"  onserverclick="Button3_Click" class="button primary" tooltip="Deletes the Complete Details of the Existing  Company!"><span class=" mif-bin"></span>delete</button>
           </td>
        </tr>

        </table>
</asp:Content>


