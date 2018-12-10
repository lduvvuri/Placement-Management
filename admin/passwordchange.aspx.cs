using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class general_passwordchange : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        pwd.Text = "";
        view.Text = "";

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select pawd from logs where username='" + Session["aname"] + "'", con);
        con.Open();
        if (oldpwd.Text == cmd.ExecuteScalar().ToString())
        {
            SqlCommand update = new SqlCommand("update logs set pawd='" + newpwd.Text + "' where username='" + Session["aname"] + "'", con);
            update.ExecuteNonQuery();
            view.Text = "password sucessfully changed";
            
        }
        else
        {
            pwd.Text = "invalid password";
      
        }
    }
}