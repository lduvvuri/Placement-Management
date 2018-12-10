using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_testimonials : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        

        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int j = 0;
        string[] news = new string[15];
        con.Open();
        if (msg.Text != "")
        {
            SqlCommand countrecords = new SqlCommand("select count(sno) from testimo", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand incmd = new SqlCommand("insert into testimo(sno,msg) values(" + noofrecs + ", '" + msg.Text + "')", con);
            incmd.ExecuteNonQuery();
        }

        Response.Redirect("testimonials.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        con.Open();
        if (msga.Text != "")
        {
            SqlCommand countrecords = new SqlCommand("select count(sno) from stestimo", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand incmd = new SqlCommand("insert into stestimo(sno,msg) values(" + noofrecs + ", '" + msga.Text + "')", con);
            incmd.ExecuteNonQuery();
        }

        Response.Redirect("testimonials.aspx");
    }
}
