using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

public partial class student_Default : System.Web.UI.Page
{
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    string DownloadFileType = "";
    string youtubeUrl = "";
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
            youtubeUrl = r.GetValue(7).ToString();
            con1.Close();
            SqlCommand cmd1 = new SqlCommand(" select * from skills where sname='" + lbname.Text + "'", con1);
            con1.Open();
            SqlDataReader r1 = cmd1.ExecuteReader();
            r1.Read();
            lbsk.Text = "" + r1.GetValue(1).ToString() + ", " + r1.GetValue(2).ToString() + ", " + r1.GetValue(3).ToString() + ", " + r1.GetValue(4).ToString() + ", " + r1.GetValue(5).ToString() + ", " + r1.GetValue(6).ToString() + ", " + r1.GetValue(7).ToString() + ", " + r1.GetValue(8).ToString() + ", " + r1.GetValue(9).ToString() + ", " + r1.GetValue(10).ToString() + ". ";
            con1.Close();
        }
        else MessageBox.Show("name not selected");
        SetVideoForPlay();
    }
    protected void SetVideoForPlay()
    {
        if (youtubeUrl != "")
        {
            string vCode = youtubeUrl.Substring(youtubeUrl.LastIndexOf("v=") + 2);
            if (vCode.Contains("&"))
                vCode = vCode.Substring(0, vCode.LastIndexOf("&"));

            string sHtml = @"<object width='{0}' height='{1}' data='http://www.youtube.com/v/{2}&autoplay=0' codetype='application/x-shockwave-flash'>
  &ltparam name='movie' value='http://www.youtube.com/v/{2}&autoplay=0'></param></object>";
            //define frame size
            string sWidth = "400px";
            string sHeight = "200px";

            //insert code to the Div
            divVideo.InnerHtml = String.Format(sHtml, sWidth, sHeight, vCode);
        }
    }
    

}