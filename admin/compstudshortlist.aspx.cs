using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Windows.Forms;

public partial class Admin_compstudshortlist : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    MailMessage mail = new MailMessage(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView2.Visible = false;
            DropDownList1.Visible = false;
            Button1.Visible = false;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            GridView2.Visible = false;
            DropDownList1.Visible = false;
            Button1.Visible = false;
        
        con.Open();
        int rid;
        SqlCommand id = new SqlCommand("select cid from company where name='" + GridView1.SelectedRow.Cells[1].Text.ToString() + "'", con);//taking the company id using the company name
        rid = Convert.ToInt32(id.ExecuteScalar());
        SqlCommand check = new SqlCommand("select * from compsk where cid ="+ rid, con);
       
        if (check.ExecuteScalar() != null)
        {
            DropDownList1.Visible = true;
            DropDownList1.SelectedValue = "short list";
            GridView2.Visible = true;
            
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString();

        }
        
    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand id = new SqlCommand("select cid from company where name='" + GridView1.SelectedRow.Cells[1].Text.ToString()+"'", con);
        int cid = Convert.ToInt32(id.ExecuteScalar());
       
        if (DropDownList1.SelectedIndex == 0)
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString(), con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Shortlisted for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have been shortlisted by " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about the Company round please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                 MessageBox.Show(msg);
                 SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set slmail=1", con);
                 sendmail.ExecuteNonQuery();
                
            }
            Button1.Visible = false;
        }
        if (DropDownList1.SelectedValue.ToString() == "r1")
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r1=1", con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Round 1 cleared for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have cleared round 1 for " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about the round 2 please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                MessageBox.Show(msg);
                SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set r1mail=1", con);
                sendmail.ExecuteNonQuery();
                
            }
            Button1.Visible = false;
        }
        if (DropDownList1.SelectedValue.ToString() == "r2")
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r2=1", con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Round 2 cleared for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have cleared round 2 for " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about the round 3 please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                MessageBox.Show(msg);
                SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set r2mail=1", con);
                sendmail.ExecuteNonQuery();
               
            }
            Button1.Visible = false;
        }
        if (DropDownList1.SelectedValue.ToString() == "r3")
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r3=1", con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Round 3 cleared for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have cleared round 3 for " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about the round 4 please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                MessageBox.Show(msg);
                SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set r3mail=1", con);
                sendmail.ExecuteNonQuery();
               
            }
            Button1.Visible = false;
        }
        if (DropDownList1.SelectedValue.ToString() == "r4")
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r4=1", con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Round 4 cleared for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have cleared round 4 for " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about the round 5 please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                MessageBox.Show(msg);
                SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set r4mail=1", con);
                sendmail.ExecuteNonQuery();
               
            }
            Button1.Visible = false;
        }
        if (DropDownList1.SelectedValue.ToString() == "r5")
        {
            SqlCommand stud = new SqlCommand("select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r5=1", con);
            SqlDataReader read = stud.ExecuteReader();
            while (read.Read())
            {
                string from = "placementportal.kmit@gmail.com";
                SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "K.M.I.T placements : Selected for " + GridView1.SelectedRow.Cells[1].Text.ToString();
                string msg = "Hello Mr./Ms" + read.GetValue(0).ToString() + " , you have been selected by " + GridView1.SelectedRow.Cells[1].Text.ToString() + " . For any further details about selection please wisit the website http://localhost:5918/public/login.aspx or contact ur placement manager Mr. sudheer Reddy . ";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                //smtp.Send(from, to, sub, msg);
                MessageBox.Show(msg);
                SqlCommand sendmail = new SqlCommand("update " + GridView1.SelectedRow.Cells[1].Text.ToString() + " set r5mail=1", con);
                sendmail.ExecuteNonQuery();
               
            }
            Button1.Visible = false;
        }
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button1.Visible = false;
        con.Open();
        if (DropDownList1.SelectedIndex == 0)
        {
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString();
            GridView2.Visible = true;
            SqlCommand sendmail = new SqlCommand("select slmail from " + GridView1.SelectedRow.Cells[1].Text.ToString(), con);
            string test = sendmail.ExecuteScalar().ToString();
            if (sendmail.ExecuteScalar().ToString() == "")
            {
                Button1.Visible = true;
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "r1")
        {
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r1=1";
            GridView2.Visible = true;
            SqlCommand sendmail = new SqlCommand("select r1mail from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r1=1", con);
            if(sendmail.ExecuteScalar()!=null)
            if (sendmail.ExecuteScalar().ToString() == "")
            {
                Button1.Visible = true;
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "r2")
        {
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r2=1";
            GridView2.Visible = true;
            SqlCommand sendmail = new SqlCommand("select r2mail from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r2=1", con);
            if (sendmail.ExecuteScalar() != null)
            if (sendmail.ExecuteScalar().ToString() == "")
            {
                Button1.Visible = true;
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "r3")
        {
             SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r3=1";
             GridView2.Visible = true;
             SqlCommand sendmail = new SqlCommand("select r3mail from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r3=1", con);
             if (sendmail.ExecuteScalar() != null)
             if (sendmail.ExecuteScalar().ToString() == "")
             {
                 Button1.Visible = true;
             }
        }
        if (DropDownList1.SelectedValue.ToString() == "r4")
        {
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r4=1";
            GridView2.Visible = true;
            SqlCommand sendmail = new SqlCommand("select r4mail from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r4=1", con);
            if (sendmail.ExecuteScalar() != null)
            if (sendmail.ExecuteScalar().ToString() == "false")
            {
                Button1.Visible = true;
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "")
        {
            SqlDataSource2.SelectCommand = "select sname from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r5=1";
            GridView2.Visible = true;
            SqlCommand sendmail = new SqlCommand("select r5mail from " + GridView1.SelectedRow.Cells[1].Text.ToString() + " where r5=1", con);
            if (sendmail.ExecuteScalar() != null)
            if (sendmail.ExecuteScalar().ToString() == "")
            {
                Button1.Visible = true;
            }
        }
        con.Close();
    }
}