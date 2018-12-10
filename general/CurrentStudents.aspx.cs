using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class CurrentStudents : System.Web.UI.Page
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
    
}