<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/admin/administration.master" AutoEventWireup="true" CodeFile="stats.aspx.cs" Inherits="general_stats" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
    .chart {}
    .chart {}
    .chart {}
        
        .chart {}
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table style="width:100%;">
        <tr>
            <td>
                year</td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  CssClass="button dropdown-toggle" ToolTip="Select the Year to get the Statastical Data!">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem Value="place1112">2011-2012</asp:ListItem>
                    <asp:ListItem Value="place1213">2012-2013</asp:ListItem>
                    <asp:ListItem Value="place13141">2013-2014</asp:ListItem>
                    <asp:ListItem Value="Overall">Overall</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                company</td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="companylist" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="companylist_SelectedIndexChanged" CssClass="button dropdown-toggle" ToolTip="Select the Company to get the Statastical Data!"  >
                </asp:DropDownList>
            </td>
            <td>
                graph type</td>
            <td>
                :</td>
            <td>
                <asp:DropDownList ID="charttype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="charttype_SelectedIndexChanged"  CssClass="button dropdown-toggle" ToolTip="Select the Type of Graph!">
                    <asp:ListItem>stacked column</asp:ListItem>
                    <asp:ListItem>bar</asp:ListItem>
                    <asp:ListItem>doughnut</asp:ListItem>
                    <asp:ListItem>pyramid</asp:ListItem>
                    <asp:ListItem>pie</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
    </table>
    
    <asp:Chart ID="Chart1" runat="server" Height="328px" Width="527px" CssClass="chart" OnLoad="Chart1_Load" BackColor="skyblue" BackGradientStyle="DiagonalRight" Palette="None" BorderlineWidth="0">
    <series>
        <asp:Series Name="Series1" ChartType="column" IsValueShownAsLabel="True" Legend="Legend1">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1" BackColor="skyblue" BackGradientStyle="DiagonalRight">
            <AxisY>
                <MajorGrid Enabled="False" />
            </AxisY>
            <AxisX>
                <MajorGrid Enabled="False" />
            </AxisX>
            <Area3DStyle Enable3D="true" PointDepth="75" PointGapDepth="75" />
        </asp:ChartArea>
    </chartareas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles >
   
        </Titles>
</asp:Chart>
    <br />
    <asp:Label ID="chartnote" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NexusConnectionString %>" SelectCommand="SELECT [cname], [tot] FROM [test]"></asp:SqlDataSource>
    <br />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <marquee direction="up" loop="true" width="100%" onmouseover="this.stop();" onmouseout="this.start();" style="height: 80%">
             <ul>
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>

</asp:Content>

