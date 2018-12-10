using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class general_stats : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        charttype.Enabled = false;
        int j = 0;
        string[] news = new string[5];
        con.Open();
        SqlCommand countrecords1 = new SqlCommand("select count(sno) from news", con);
        for (int i = Convert.ToInt32(countrecords1.ExecuteScalar()); i > Convert.ToInt32(countrecords1.ExecuteScalar()) - 5; i--, j++)
        {
            SqlCommand dat = new SqlCommand("select msg from news where sno=" + i, con);
            news[j] = dat.ExecuteScalar().ToString();
        }
        con.Close();
        l1.Text = news[0];
        l2.Text = news[1];
        l3.Text = news[2];
        l4.Text = news[3];
        l5.Text = news[4];

    }
    private void GetChartData()
    {

        try
        {
            SqlCommand cmd = new SqlCommand("select branch,sel from " + year.SelectedValue + " where cname='" + companylist.SelectedValue + "'", con);
            Series series = Chart1.Series["Series1"];
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Chart1.Series["Series1"].XValueMember = "branch";
            Chart1.Series["Series1"].YValueMembers = "sel";
            Chart1.DataSource = rdr;
            Chart1.DataBind();
            charttype.Enabled = true;
            Chart1.Titles.Add(new Title(companylist.SelectedValue, Docking.Top));
            con.Close();
        }

        catch (Exception p)
        {
        }
    }
    private void chart()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select branch,sel from " + year.SelectedValue + " where cname='" + companylist.SelectedValue + "'", con);
            Series series = Chart1.Series["Series1"];
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Chart1.Series["Series1"].XValueMember = "branch";
            Chart1.Series["Series1"].YValueMembers = "sel";
            Chart1.DataSource = rdr;
            Chart1.DataBind();
           
            con.Close();
        }
        catch (Exception p)
        {
        }
    }

    protected void charttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetChartData();
            switch (charttype.SelectedValue)
            {
                case "bar":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "stacked column":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    break;
                case "pie":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "pyramid":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pyramid;
                    break;
                case "doughnut":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
                    break;


            }
        }
        catch (Exception p)
        {
        }
    }
    protected void Chart1_Load(object sender, EventArgs e)
    {
        
        
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd1 = new SqlCommand("select distinct cname from " + year.SelectedValue, con);

            con.Open();
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            if (rdr1.HasRows == true)
            {
                companylist.DataSource = rdr1;
                companylist.DataTextField = "cname";
                companylist.DataValueField = "cname";
                companylist.DataBind();
                companylist.Items.Insert(0, new ListItem("--Select--", ""));
                
            }
            con.Close();
            GetChartData();
            switch (charttype.SelectedValue)
            {
                case "bar":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "stacked column":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    break;
                case "pie":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "spline":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "doughnut":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
                    break;


            }
        }
        catch (Exception p)
        {
        }
    }
    protected void companylist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            GetChartData();
            switch (charttype.SelectedValue)
            {
                case "bar":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "stacked column":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    break;
                case "pie":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "pyramid":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pyramid;
                    break;
                case "doughnut":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
                    break;


            }
        }
        catch (Exception p)
        {
        }
    }
}
