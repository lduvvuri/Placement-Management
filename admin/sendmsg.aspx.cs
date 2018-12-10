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
using ASPSnippets.SmsAPI;
using System.Drawing;

public partial class PassAdmin_sendmsg : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    string msg;
    int otp;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
           
           
        }
        catch(NullReferenceException ex)
        { 

        }
            
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

       if((string)Session["otp"] != "")
        if ((string)Session["otp"] == onetp.Text)
        {
           
            Session["otp"] ="";
           // MessageBox.Show((string)Session["otp"]);
            con.Open();
            SqlCommand round = new SqlCommand(" delete round", con);
            round.ExecuteNonQuery();
            SqlCommand checks = new SqlCommand(" delete checks", con);
            checks.ExecuteNonQuery();
            SqlCommand compsk = new SqlCommand(" delete compsk", con);
            compsk.ExecuteNonQuery();
            //SqlCommand skills = new SqlCommand(" delete skills", con);
            //skills.ExecuteNonQuery();
            //SqlCommand std = new SqlCommand(" delete studetails", con);
            //std.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully deteled the data");
            Response.Redirect("../Admin/adminhome.aspx");
        }
    }
}