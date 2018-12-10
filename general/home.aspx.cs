using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
        
    
    protected void Page_Load(object sender, EventArgs e)
    {

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
    
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        day.Text = Calendar1.SelectedDate.ToShortDateString();
        date.Text = Calendar1.SelectedDate.ToShortDateString();
        SqlCommand dat = new SqlCommand("select * from calendar", con);
        con.Open();
        name.Text = "";
        round.Text = "";
        req.Text ="";
        venue.Text = "";
        time.Text = "";
        address.Text = "";

        SqlDataReader r = dat.ExecuteReader();
        while (r.Read())
        {
            if (Calendar1.SelectedDate.ToString() == r.GetValue(0).ToString()) //if selected date is same as the date from the database
            {
                name.Text += r.GetValue(1).ToString();
                round.Text += r.GetValue(2).ToString();
                req.Text += r.GetValue(3).ToString();
                venue.Text += r.GetValue(4).ToString();
                time.Text += r.GetValue(5).ToString();
                address.Text += r.GetValue(6).ToString();
                break;
            }
            else
            {
                name.Text = "";
                round.Text = "";
                req.Text = "";
                venue.Text = "";
                time.Text = "";
                address.Text = "";
            }
            
        }
        
        con.Close();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)//changes the background of all the dates that are present in the database
    {
        SqlCommand cmd = new SqlCommand("select idate,cname from calendar ", con);
        con.Open();
        
        SqlDataReader rdr = cmd.ExecuteReader();
        
        while (rdr.Read())
        {
            
            if (e.Day.Date.ToString() == rdr.GetValue(0).ToString())
            {
                e.Cell.BackColor = System.Drawing.Color.Yellow;
                //e.Cell.ToolTip =""+rdr.GetValue(1).ToString();
            }
            

        }
        con.Close();
    }
}