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

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select pwd from studlog where username='" + Session["sname"] + "'", con);
        con.Open();
        if (oldpwd.Text == cmd.ExecuteScalar().ToString())
        {
            SqlCommand update = new SqlCommand("update studlog set pwd='" + newpwd.Text + "' where username='" + Session["sname"] + "'", con);
            update.ExecuteNonQuery();
            view.Text = "password sucessfully changed";
            
        }
        else
        {
            pwd.Text = "invalid password";
      
        }
    }
}