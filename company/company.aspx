<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/company/company.master" AutoEventWireup="true" CodeFile="company.aspx.cs" Inherits="company_company" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
        width: 144px;
    }

        .auto-style4 {
            width: 2px;
        }

        .auto-style5 {
            width: 78px;
            float: right;
        }

        .auto-style6 {
            width: 6px;
        }

        .auto-style7 {
        }

        .auto-style8 {
            width: 91px;
            height: 143px;
        }

        .auto-style9 {
            width: 6px;
            height: 143px;
        }

        .auto-style14 {
            width: 13px;
        }

        .auto-style15 {
            width: 13px;
            height: 143px;
        }
        .auto-style16 {
            width: 78px;
            float: right;
            height: 77px;
        }
        .auto-style17 {
            width: 2px;
            height: 77px;
        }
        .auto-style18 {
            height: 77px;
        }
        .auto-style19 {
            width: 78px;
            float: right;
            height: 37px;
        }
        .auto-style20 {
            width: 2px;
            height: 37px;
        }
        .auto-style21 {
            height: 37px;
        }
        .auto-style22 {
            height: 77px;
            width: 112px;
        }
        .auto-style23 {
            height: 37px;
            width: 112px;
        }
        .auto-style24 {
            width: 112px;
        }
        .auto-style25 {
            height: 77px;
            width: 40px;
        }
        .auto-style26 {
            height: 37px;
            width: 40px;
        }
        .auto-style27 {
            width: 40px;
        }
        .auto-style28 {
            width: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 45%; height: 450px; float: left;">
        <tr>
            <td class="auto-style2">Company name</td>
            <td>:</td>
            <td class="auto-style28">
                <asp:Label ID="cname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">package for selected students</td>
            <td>:</td>
            <td class="auto-style28">

                <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" AutoPostBack="True" CssClass="input-control text"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="enter package details" CssClass="validate" ControlToValidate="TextBox1" Display="Dynamic" ValidationGroup="val2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Minimum Percentage Required</td>
            <td>:</td>
            <td class="auto-style28">
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CssClass="input-control text" ValidationGroup="val2" ToolTip="Select the Percentage For Setting the Criteria!">
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                    <asp:ListItem>90</asp:ListItem>
                    <asp:ListItem>80</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                    </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList3" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the percentage" InitialValue="0" ValidationGroup="val2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Preferred Software Knowledge<br />
                <asp:Label ID="select" runat="server" Text="Maximum 4 can be selected" CssClass="validate"></asp:Label>
            </td>
            <td>:</td>
            <td class="auto-style28">

                <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged" ToolTip="Select the Skills to Set the Criteria!" >
                </asp:CheckBoxList>
                
            </td>
        </tr>
        </table>
    <table style="width: 45%; height: 449px; float: left;">
        <tr>
            <td class="auto-style16">

                &nbsp;</td>

            <td class="auto-style17">&nbsp;</td>

            <td class="auto-style22">

                <br />

                <label class="switch">
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
    <span class="check"></span>   any one skill
</label>
            </td>

            <td class="auto-style25">

                &nbsp;</td>

            <td class="auto-style18">&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style16">

                <br />
                <br />

                <asp:Label ID="branch" runat="server" Text="Branches"></asp:Label>
            </td>

            <td class="auto-style17">&nbsp;</td>

            <td class="auto-style22">

                <asp:CheckBoxList ID="CheckBoxList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList3_SelectedIndexChanged" RepeatDirection="Horizontal" ToolTip="Select the Branches to Set the Criteria!">
                    <asp:ListItem Value="CSE">CSE</asp:ListItem>
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>ECE</asp:ListItem>
                    <asp:ListItem>EIE</asp:ListItem>
                </asp:CheckBoxList>
                <br /></td>

            <td class="auto-style25">

                &nbsp;</td>

            <td class="auto-style18">&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style16">

                &nbsp;</td>

            <td class="auto-style17">&nbsp;</td>

            <td class="auto-style22">

                <asp:Button ID="Button4" runat="server" Text="Check Criteria" OnClick="Button4_Click" CssClass="button primary" ValidationGroup="val2" ToolTip="On click Enables to see the  Short Listed Students!" />
            </td>

            <td class="auto-style25">

                &nbsp;</td>

            <td class="auto-style18">&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style16">

                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Number Of Rounds"></asp:Label>
            </td>

            <td class="auto-style17">:</td>

            <td class="auto-style22">

                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" CssClass="input-control text" ToolTip="Select the Number of Rounds!">
                    <asp:ListItem Value="11">--select--</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList4" Display="Dynamic" ErrorMessage="Select number of rounds" CssClass="validate" ValidationGroup="val3" InitialValue="11"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style25">

                &nbsp;</td>

            <td class="auto-style18">&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style16">

                <br />
                <br />
                <br />

                <asp:Label ID="round1" runat="server" Text="Round 1"></asp:Label>
            </td>

            <td class="auto-style17">:</td>

            <td class="auto-style22">

                <asp:TextBox ID="r1" runat="server" TextMode="Date" CssClass="input-control text" ValidationGroup="val3" ToolTip="Select the Date For Round1!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="r1" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the date !" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style25">

                <asp:DropDownList ID="rd1tp" runat="server" Width="80px" CssClass="input-control text" OnSelectedIndexChanged="rd1tp_SelectedIndexChanged" ToolTip="Select the type of test for Round1!">
                    <asp:ListItem Value="1">--select--</asp:ListItem>
                    <asp:ListItem Value="aptitude">aptitude</asp:ListItem>
                    <asp:ListItem>written test</asp:ListItem>
                    <asp:ListItem>machine test</asp:ListItem>
                    <asp:ListItem>technical interview</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rd1tp" CssClass="validate" Display="Dynamic" ErrorMessage="Enter any one option" InitialValue="1" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style18">&nbsp;&nbsp;<asp:CompareValidator ID="CompareEndTodayValidator" runat="server" ControltoValidate="r1" CssClass="validate" ErrorMessage="date cannot be before todays date" Operator="GreaterThanEqual" type="Date" ValidationGroup="val3" />
            </td>

        </tr>
        <tr>
            <td class="auto-style19">

                <br />

                <asp:Label ID="round2" runat="server" Text="Round 2"></asp:Label>
            </td>

            <td class="auto-style20">:</td>

            <td class="auto-style23">

                <asp:TextBox ID="r2" runat="server" TextMode="Date" CssClass="input-control text" ToolTip="Select the Date For Round2!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="r2" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the date!" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style26">

                <asp:DropDownList ID="rd2tp" runat="server" Width="80px" CssClass="input-control text" ToolTip="Select the type of test for Round2!">
                    <asp:ListItem Value="2">--select--</asp:ListItem>
                    <asp:ListItem>aptitude</asp:ListItem>
                    <asp:ListItem>written test</asp:ListItem>
                    <asp:ListItem>machine test</asp:ListItem>
                    <asp:ListItem>technical interview</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rd2tp" CssClass="validate" Display="Dynamic" ErrorMessage="Enter any one option" InitialValue="2" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style21">&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="r1" ControlToValidate="r2" Display="Dynamic" ErrorMessage="round 2 cannot be before round 1" Operator="GreaterThanEqual" CssClass="validate" ValidationGroup="val3"></asp:CompareValidator>
            </td>

        </tr>
        <tr>
            <td class="auto-style5">

                <br />

                <asp:Label ID="round3" runat="server" Text="Round 3"></asp:Label>
            </td>

            <td class="auto-style4">:</td>

            <td class="auto-style24">

                <asp:TextBox ID="r3" runat="server" TextMode="Date" CssClass="input-control text" ToolTip="Select the Date For Round3!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="r3" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the date!" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style27">

                <asp:DropDownList ID="rd3tp" runat="server" Width="80px" CssClass="input-control text" ToolTip="Select the type of test for Round3!">
                    <asp:ListItem Value="3">--select--</asp:ListItem>
                    <asp:ListItem>aptitude</asp:ListItem>
                    <asp:ListItem>written test</asp:ListItem>
                    <asp:ListItem>machine test</asp:ListItem>
                    <asp:ListItem>technical interview</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rd3tp" CssClass="validate" Display="Dynamic" ErrorMessage="Enter any one option" InitialValue="3" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td>&nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="r2" ControlToValidate="r3" Display="Dynamic" ErrorMessage="Round 3 cannot be before Round2" Operator="GreaterThanEqual" CssClass="validate" ValidationGroup="val3"></asp:CompareValidator>
            </td>

        </tr>
        <tr>
            <td class="auto-style5">

                <br />

                <asp:Label ID="round4" runat="server" Text="Round 4"></asp:Label>
            </td>

            <td class="auto-style4">:</td>

            <td class="auto-style24">

                <asp:TextBox ID="r4" runat="server" TextMode="Date" CssClass="input-control text" ToolTip="Select the Date For Round4!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="r4" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the date!" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style27">

                <asp:DropDownList ID="rd4tp" runat="server" Width="80px" CssClass="input-control text" ToolTip="Select the type of test for Round4!">
                    <asp:ListItem Value="4">--select--</asp:ListItem>
                    <asp:ListItem>aptitude</asp:ListItem>
                    <asp:ListItem>written test</asp:ListItem>
                    <asp:ListItem>machine test</asp:ListItem>
                    <asp:ListItem>technical interview</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rd4tp" CssClass="validate" Display="Dynamic" ErrorMessage="Enter any one option" InitialValue="4" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td>

                <br />
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="r3" ControlToValidate="r4" Display="Dynamic" ErrorMessage="Round 4 cannot be before Round 3" Operator="GreaterThanEqual" CssClass="validate" ValidationGroup="val3"></asp:CompareValidator>
            </td>

        </tr>
        <tr>
            <td class="auto-style5">

                <br />

                <asp:Label ID="round5" runat="server" Text="Round 5"></asp:Label>
            </td>

            <td class="auto-style4">:</td>

            <td class="auto-style24">

                <asp:TextBox ID="r5" runat="server" TextMode="Date" CssClass="input-control text" ToolTip="Select the Date For Round5!"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="r5" CssClass="validate" Display="Dynamic" ErrorMessage="Enter the date!" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td class="auto-style27">

                <asp:DropDownList ID="rd5tp" runat="server" Width="80px" CssClass="input-control text" ToolTip="Select the type of test for Round5!">
                    <asp:ListItem Value="5">--select--</asp:ListItem>
                    <asp:ListItem>aptitude</asp:ListItem>
                    <asp:ListItem>written test</asp:ListItem>
                    <asp:ListItem>machine test</asp:ListItem>
                    <asp:ListItem>technical interview</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rd5tp" CssClass="validate" Display="Dynamic" ErrorMessage="Enter any one option" InitialValue="5" ValidationGroup="val3"></asp:RequiredFieldValidator>
            </td>

            <td>

                <br />
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="r4" ControlToValidate="r5" Display="Dynamic" ErrorMessage="Round 5 cannot be before Round 4" Operator="GreaterThanEqual" CssClass="validate" ValidationGroup="val3"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">

                <asp:Button ID="Button3" runat="server" CssClass="button primary" OnClick="Button3_Click" Text="rounds" ValidationGroup="val3" ToolTip="Submits the Details of Selected Rounds!" />
            </td>

            <td class="auto-style4">&nbsp;</td>

            <td class="auto-style24">

                <asp:Label ID="rounds" runat="server" CssClass="validate" Text=""></asp:Label>
            </td>

            <td class="auto-style27">

                &nbsp;</td>

            <td>

                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%; height: 297px;">
        <tr>
            <td class="auto-style7">
                <asp:Label ID="pers" runat="server" Text="percentage"></asp:Label>
            </td>
            <td class="auto-style6">:</td>
            <td colspan="4">
                <asp:Label ID="per1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                package</td>
            <td class="auto-style6">:</td>
            <td colspan="4">
                <asp:Label ID="pac" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="knows" runat="server" Text="Knowledge"></asp:Label>
            </td>
            <td class="auto-style9">:</td>
            <td class="auto-style15">
                <asp:Label ID="lbsk1" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style15">
                <asp:Label ID="lbsk2" runat="server" Text=""></asp:Label></td>
            <td class="auto-style15">
                <asp:Label ID="lbsk3" runat="server" Text=""></asp:Label></td>
            <td class="auto-style15">
                <asp:Label ID="lbsk4" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="branchs" runat="server" Text="branches"></asp:Label>
            </td>
            <td class="auto-style6">:</td>
            <td class="auto-style14">
                <asp:Label ID="lbbr1" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style14">
                <asp:Label ID="lbbr2" runat="server" Text=""></asp:Label></td>
            <td class="auto-style14">
                <asp:Label ID="lbbr3" runat="server" Text=""></asp:Label></td>
            <td class="auto-style14">
                <asp:Label ID="lbbr4" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3">
                <asp:Label ID="Label3" runat="server" Text="Note:After Submiting the ShortListed Students(Rounds Button Gets Visible) then Submit the Rounds" CssClass="validate"></asp:Label>
                <br />
                <br />
                <br />
            </td>
            <td class="auto-style7" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3">
                &nbsp;</td>
            <td class="auto-style7" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
