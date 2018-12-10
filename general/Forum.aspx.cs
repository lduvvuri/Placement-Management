using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class general_Forum : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["nname"] = GridView1.SelectedRow.Cells[1].Text.ToString();
        Session["sname"] = GridView1.SelectedRow.Cells[2].Text.ToString();
        Response.Redirect("Forumquest.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd2 = new SqlCommand("Select * from Forum where question='" + tb1.Text + "'", con);
        if (cmd2.ExecuteScalar() == null)
        {
            SqlCommand countrecords = new SqlCommand("select sno from Forum order by sno desc", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand incmd = new SqlCommand("insert into Forum (sno,question) values(" + noofrecs + ",'" + tb1.Text + "')", con);
            incmd.ExecuteNonQuery();
            //SqlCommand cmd = new SqlCommand("Select *from company", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            con.Close();
            Response.Redirect("Forum.aspx");
        }
    }
}