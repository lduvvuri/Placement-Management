<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="Admin_testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #TextArea1 {
            width: 221px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" Width="100%" PageSize="7" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="msg" HeaderText="company testimonials" SortExpression="msg" />
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

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [msg] FROM [testimo]"></asp:SqlDataSource>

    
    <asp:TextBox ID="msg" runat="server" Columns="45" Rows="5" TextMode="MultiLine" CssClass="input-control text" ToolTip="Enter the Companies Testimonial!"></asp:TextBox>
    <button  id="Button1" runat="server"   onserverclick="Button1_Click"  class="button primary"  validationgroup="val"  tooltip="Submits the Entered Testimonial!"> Submit</button>
            

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="msg" CssClass="validate" Display="Dynamic" ErrorMessage="Donot Submit Without Inserting a Testimonial" ValidationGroup="val"></asp:RequiredFieldValidator>
            

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" Width="100%" PageSize="7" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="msg" HeaderText="student testimonials" SortExpression="msg" />
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

    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [msg] FROM [stestimo]"></asp:SqlDataSource>

    
    <asp:TextBox ID="msga" runat="server" Columns="45" Rows="5" TextMode="MultiLine" CssClass="input-control text" ToolTip="Enter the Students Testimonial!"></asp:TextBox>
    <button  id="Button2" runat="server"  onserverclick="Button2_Click"  class="button primary" ValidationGroup="val1" tooltip="Submits the Entered Testimonial!">submit</button>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="msga" CssClass="validate" Display="Dynamic" EnableTheming="True" ErrorMessage="Donot Submit Without Inserting a Testimonial" ValidationGroup="val1"></asp:RequiredFieldValidator>
</asp:Content>

