using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class placement_management_logins_clogin : System.Web.UI.Page
{
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int flag = 1;
        if (flag == 1)
        {
            con.Open();
            SqlCommand clogrecords = new SqlCommand("select * from studlog", con);
            SqlDataReader r = clogrecords.ExecuteReader();
            while (r.Read())
            {
                if (user.Text == r.GetValue(0).ToString() && pwd.Text == r.GetValue(1).ToString())
                {
                    Session["sname"] = user.Text;
                    flag = 0;
                    Response.Redirect("../general/home.aspx");

                }

            }
            con.Close();
        }
        if (flag == 1)
        {
            con.Open();
            SqlCommand logrecords = new SqlCommand("select * from logs", con);
            SqlDataReader r = logrecords.ExecuteReader();
            while (r.Read())
            {
                if (user.Text == r.GetValue(0).ToString() && pwd.Text == r.GetValue(1).ToString())
                {
                    Session["aname"] = user.Text;
                    flag = 0;
                    Response.Redirect("../admin/adminhome.aspx");

                }

            }
            con.Close();
            
        }
        if (flag == 1)
        {
            con.Open();
            SqlCommand clogrecords = new SqlCommand("select * from clogs", con);
            SqlDataReader r = clogrecords.ExecuteReader();
            while (r.Read())
            {
                if (user.Text == r.GetValue(0).ToString() && pwd.Text == r.GetValue(1).ToString())
                {
                    Session["UserName"] = user.Text;
                    flag = 0;
                    Response.Redirect("../company/company.aspx");

                }

            }
            con.Close();
        }

        
    }
}