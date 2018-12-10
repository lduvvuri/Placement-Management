using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class company : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand dat = new SqlCommand("select * from company", con);
        con.Open();
        SqlDataReader r = dat.ExecuteReader();
        while (r.Read())
        {
            if (GridView1.SelectedRow.Cells[1].Text.ToString() == r.GetValue(1).ToString())
            {
                lbName.Text = r.GetValue(1).ToString();
                lbAddress.Text = r.GetValue(2).ToString();
                lbEmail.Text = r.GetValue(3).ToString();
                lbContact.Text = r.GetValue(4).ToString();
                lbPerson.Text = r.GetValue(5).ToString();
            }
        }
    }
}