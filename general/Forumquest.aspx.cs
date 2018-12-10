using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class general_Forumquest : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        string lb1 = (string)Session["nname"];
        lbname.Text = (string)Session["sname"];
        SqlDataSource1.SelectCommand = "select comment from comments where sn=" + lb1 + "";
       

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        

        con.Open();
        SqlCommand cmd2 = new SqlCommand("Select * from comments where comment='" + tb1.Text + "'", con);
        if (cmd2.ExecuteScalar() == null)
        {
            SqlCommand countrecords = new SqlCommand("select sn from comments order by sn desc", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand incmd = new SqlCommand("insert into comments (sn,comment) values(" + (string)Session["nname"] + ",'" + tb1.Text + "')", con);
            incmd.ExecuteNonQuery();
            //SqlCommand cmd = new SqlCommand("Select *from company", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            con.Close();
            Response.Redirect("Forumquest.aspx");
        }
    }
}