<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="CurrentStudents.aspx.cs" Inherits="Admin_CurrentStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 8px;
            margin-left: 240px;
        }
        .auto-style5 {
            width: 200px;
        }
        .auto-style7 {
            width: 8px;
            height: 42px;
        }
        .auto-style8 {
            width: 200px;
            height: 42px;
        }
        .auto-style9 {
            width: 200px;
            height: 22px;
        }
        .auto-style12 {
            width: 207px;
            margin-left: 240px;
        }
        .auto-style13 {
            width: 207px;
            height: 42px;
        }
        .auto-style16 {
            height: 22px;
            width: 8px;
        }
        .auto-style17 {
            height: 22px;
            width: 207px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table style="width:100%; height: 394px; margin-right: 1px;">
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label1" runat="server" Text="Student Name"></asp:Label>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style5">
                <span class=" button mif-user icon bg-white fg-dark"></span><asp:TextBox ID="sname" runat="server"  BackColor="White" CssClass="input-control text" ToolTip="Enter(type) the Name of Student"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="sname" CssClass="validate" Display="Dynamic" ErrorMessage="Student Name Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label2" runat="server" Text="Branch"></asp:Label>
            </td>
            <td class="auto-style1">
                :</td>
            <td class="auto-style5">
                <span class=" button mif-tree icon bg-white fg-dark"></span><asp:TextBox ID="branch" runat="server" BackColor="White" CssClass="input-control text" ToolTip="Enter the Branch of the Student"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="branch" CssClass="validate" Display="Dynamic" ErrorMessage="Branch Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="Label3" runat="server" Text="10th percentage"></asp:Label>
            &nbsp;</td>
            <td class="auto-style7">
                :</td>
            <td class="auto-style8">
                <span class=" button mif-chart-bars icon bg-white fg-dark"></span><asp:TextBox ID="tenper" runat="server" BackColor="White" CssClass="input-control text" ToolTip="Enter the 10th Percentage of the Student!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tenper" CssClass="validate" Display="Dynamic" ErrorMessage="Percentage required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label4" runat="server" Text="12th Percentage"></asp:Label>
            </td>
            <td class="auto-style1">
                :</td>
            <td class="auto-style5">
                <span class=" button mif-chart-bars2 icon bg-white fg-dark"></span><asp:TextBox ID="interper" runat="server" BackColor="White" CssClass="input-control text" ToolTip="Enter the 12th  or(diploma) Percentage of the Student!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="interper" CssClass="validate" Display="Dynamic" ErrorMessage="Inter percentage  required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label5" runat="server" Text="Engineering Percentage"></asp:Label>
            </td>
            <td class="auto-style1">
                :</td>
            <td class="auto-style5">
                <span class=" button mif-chart-dots icon bg-white fg-dark"></span><asp:TextBox ID="enggper" runat="server" BackColor="White" CssClass="input-control text" ToolTip="Enter the Engineering Percentage of the Student!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="enggper" CssClass="validate" Display="Dynamic" ErrorMessage="Engineering Percentage required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label6" runat="server" Text="Email-Id"></asp:Label>
            </td>
            <td class="auto-style1">
                :</td>
            <td class="auto-style5">
                <span class=" button mif-mail icon bg-white fg-dark"></span><asp:TextBox ID="emailid" runat="server" BackColor="White" CssClass="input-control text" TextMode="Email" ToolTip="Enter the Email id of the Student!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emailid" CssClass="validate" Display="Dynamic" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="Label7" runat="server" Text="Contact no"></asp:Label>
            </td>
            <td class="auto-style1">
                :</td>
            <td class="auto-style5">
                <span class=" button mif-phone-in-talk icon bg-white fg-dark"></span><asp:TextBox ID="contact" runat="server" BackColor="White" CssClass="input-control text" TextMode="Phone" ToolTip="Enter the Contact Number of the Student!" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="contact" CssClass="validate" Display="Dynamic" ErrorMessage="Contact no required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
                <button id="Button3" runat="server" class="button primary" onserverclick="Button3_Click"  tooltip="Inserts the Details of New Student!"><span class="mif-file-download"></span>Insert</button>
                <br />
                <button id="Button4" runat="server" class="button primary"  onserverclick="Button4_Click" tooltip="Updates the Details of the Existing Student!"><span class="mif-file-upload"></span> Update</button>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style5">
                <button id="Button5" runat="server" onserverclick="Button5_Click" class="button primary"><span class=" mif-bin"></span> Delete</button>
               <%--<asp:Button ID="Button5" runat="server" CssClass="button" Text="Delete" OnClick="Button5_Click" ToolTip="Delete's the Details of the Existing Student!"/>--%>
                <br />
                <button id="Button6" runat="server" class="button primary"  onserverclick="Button6_Click"><span class="mif-video-camera"></span> Upload video</button>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">
                <br />
                <br />
                <asp:Label ID="Label14" runat="server" Text="Skills:"></asp:Label>
            </td>
            <td class="auto-style16"></td>
            <td class="auto-style9">
           
                <asp:dropdownlist  ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" CssClass="button dropdown-toggle" ToolTip="Select the Skill the Student Knows!" DataSourceID="SqlDataSource2" DataTextField="skill" DataValueField="skill">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">
           
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" CssClass="button primary" ToolTip="Updates the Skills of the Student!" />
            </td>
            <td class="auto-style1">
                   
                &nbsp;</td>
            <td class="auto-style5">
                skills known:<asp:Label ID="skills" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [skill] FROM [skillstaught]"></asp:SqlDataSource>
            
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="sname" DataSourceID="SqlDataSource1" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AllowPaging="True" AllowSorting="True" PageSize="5" Height="80%" Width="100%" ToolTip="On Click Gets the Details of the Student!" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:CommandField ButtonType="Button" HeaderText="get details" SelectText="get details" ShowSelectButton="True" ControlStyle-CssClass="button primary" />
            <asp:BoundField DataField="sname" HeaderText="sname" ReadOnly="True" SortExpression="sname"  />
            <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch" />

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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [sname], [branch], [enggper], [email], [contact] FROM [studetails]"></asp:SqlDataSource>
</asp:Content>
