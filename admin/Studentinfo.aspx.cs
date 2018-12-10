using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

public partial class Admin_Studentinfo : System.Web.UI.Page
{
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        lbname.Text = (string)Session["sname"];
        if (lbname.Text != "")
        {
            SqlCommand cmd = new SqlCommand(" select * from studetails where sname='" + lbname.Text + "'", con1);
            con1.Open();
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            // lbname.Text = r.GetValue(1).ToString();
            lbbranch.Text = r.GetValue(1).ToString();
            email.Text = r.GetValue(5).ToString();
            lbper.Text = r.GetValue(4).ToString();
            contact.Text = r.GetValue(6).ToString();
            con1.Close();
            SqlCommand cmd1 = new SqlCommand(" select * from skills where sname='" + lbname.Text + "'", con1);
            con1.Open();
            SqlDataReader r1 = cmd1.ExecuteReader();
            r1.Read();
            lbsk.Text = "" + r1.GetValue(1).ToString() + ", " + r1.GetValue(2).ToString() + ", " + r1.GetValue(3).ToString() + ", " + r1.GetValue(4).ToString() + ", " + r1.GetValue(5).ToString() + ", " + r1.GetValue(6).ToString() + ", " + r1.GetValue(7).ToString() + ", " + r1.GetValue(8).ToString() + ", " + r1.GetValue(9).ToString() + ", " + r1.GetValue(10).ToString() + ". ";
            con1.Close();
        }
        else MessageBox.Show("Name not selected");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con1.Open();
        SqlCommand cmd = new SqlCommand("UPDATE studetails SET video='"+TextBox1.Text+"'where sname='" + lbname.Text + "'", con1);
        cmd.ExecuteNonQuery();
        con1.Close();
        Label2.Text = "Update Successful";
        Response.Redirect("../Admin/Studentinfo.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
}