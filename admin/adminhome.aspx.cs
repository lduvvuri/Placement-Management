using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using ASPSnippets.SmsAPI;

public partial class home : System.Web.UI.Page
{
    string msg;
    int otp;
    SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        int j = 0;
        string[] news = new string[5];
        con.Open();
        SqlCommand countrecords1 = new SqlCommand("select count(sno) from news", con);
        for (int i = Convert.ToInt32(countrecords1.ExecuteScalar()); i > Convert.ToInt32(countrecords1.ExecuteScalar()) - 5; i--, j++)
        {
            SqlCommand dat = new SqlCommand("select msg from news where sno=" + i, con);
            news[j] = dat.ExecuteScalar().ToString();
        }
        con.Close();
        l1.Text = news[0];
        l2.Text = news[1];
        l3.Text = news[2];
        l4.Text = news[3];
        l5.Text = news[4];
    
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        string flag;
        date.Text = " " + Calendar1.SelectedDate.Month + "-" + Calendar1.SelectedDate.Day + "-" + Calendar1.SelectedDate.Year;
        day.Text = Calendar1.SelectedDate.ToShortDateString();
        SqlCommand dat = new SqlCommand("select * from calendar", con);
        con.Open();
        name.Text = "";
        round.Text = "";
        req.Text = "";
        venue.Text = "";
        time.Text = "";
        address.Text = "";
        no.Text = "";
        SqlDataReader r = dat.ExecuteReader();
        while (r.Read())
        {
            if (Calendar1.SelectedDate.ToString() ==r.GetValue(0).ToString()) //if selected date is same as the date from the database
            {
                name.Text = r.GetValue(1).ToString();
                round.Text = r.GetValue(2).ToString();
                req.Text = r.GetValue(3).ToString();
                venue.Text = r.GetValue(4).ToString();
                time.Text = r.GetValue(5).ToString();
                address.Text = r.GetValue(6).ToString();
                break;
            }

            else
            {
                name.Text = "";
                round.Text = "";
                req.Text = "";
               //venue.Text = "";
                //time.Text = "";
                //address.Text = "";
            }
            
 
        }
       // con.Close();
        
        SqlCommand cmd = new SqlCommand("select cid from round where rd1dt='" + date.Text + "' or rd2dt='" + date.Text + "' or rd3dt='" + date.Text + "' or rd4dt='" + date.Text + "' or rd5dt='" + date.Text + "'  ", con);
       // con.Open();
        int id = Convert.ToInt32(cmd.ExecuteScalar());
        if (id != 0)
        {
            name.Text = "";
            round.Text = "";
            req.Text = "";
            //venue.Text = "";
            //time.Text = "";
            //address.Text = "";
           // con.Close();
            SqlCommand nam = new SqlCommand("select name from company where cid=" + id + "", con);
           // con.Open();
            name.Text = nam.ExecuteScalar().ToString();
           // con.Close();
            SqlCommand re = new SqlCommand("select b1,b2,b3,b4 from compsk where cid=" + id + "", con);
           // con.Open();
            SqlDataReader ed = re.ExecuteReader();
            ed.Read();
            req.Text = " " + ed.GetValue(0) + " " + ed.GetValue(1) + " " + ed.GetValue(2) + " " + ed.GetValue(3) + " ";
           // con.Close();
           
            
            
            SqlCommand r1 = new SqlCommand("select rd1dt,r1tp from round where cid="+ id +" ", con);
           // con.Open();
            SqlDataReader rd1 = r1.ExecuteReader();
            rd1.Read();
            if (Calendar1.SelectedDate.ToString() == rd1.GetValue(0).ToString())
            {
                no.Text = "1";
                flag = rd1.GetValue(1).ToString();
                round.Text += flag;
   
            }
              //  con.Close();
            SqlCommand r2 = new SqlCommand("select rd2dt,r2tp from round where cid=" + id + " ", con);
           // con.Open();
            SqlDataReader rd2 = r2.ExecuteReader();
            rd2.Read();
            if (Calendar1.SelectedDate.ToString() == rd2.GetValue(0).ToString())
            {
                no.Text = "2";
                flag =  rd2.GetValue(1).ToString();
                round.Text += flag;
            }
                //con.Close();
            SqlCommand r3 = new SqlCommand("select rd3dt,r3tp from round where cid=" + id + " ", con);
           // con.Open();
            SqlDataReader rd3 = r3.ExecuteReader();
            rd3.Read();
            if (Calendar1.SelectedDate.ToString() == rd3.GetValue(0).ToString())
            {
                no.Text = "3";
                flag = rd3.GetValue(1).ToString();
                round.Text += flag;
            }
            //con.Close();
            SqlCommand r4 = new SqlCommand("select rd4dt,r4tp from round where cid=" + id + " ", con);
            //con.Open();
            SqlDataReader rd4 = r4.ExecuteReader();
            rd4.Read();
            if (Calendar1.SelectedDate.ToString() == rd4.GetValue(0).ToString())
            {
                no.Text = "4";
                flag = rd4.GetValue(1).ToString();
                round.Text += flag;
            }
            //con.Close();
            SqlCommand r5 = new SqlCommand("select rd5dt,r5tp from round where cid=" + id + " ", con);
           // con.Open();
            SqlDataReader rd5 = r5.ExecuteReader();
            rd5.Read();
            if (Calendar1.SelectedDate.ToString() == rd5.GetValue(0).ToString())
            {
                no.Text = "5";
                flag =  rd5.GetValue(1).ToString();
                round.Text += flag;
            }
            //con.Close();   
            
        }

        con.Close();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)//changes the background of all the dates that are present in the database
    {
        SqlCommand cmd = new SqlCommand("select * from round ", con);
        con.Open();
        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            if (e.Day.Date.ToString() == rdr.GetValue(1).ToString() || e.Day.Date.ToString() == rdr.GetValue(2).ToString() || e.Day.Date.ToString() == rdr.GetValue(3).ToString() || e.Day.Date.ToString() == rdr.GetValue(4).ToString() || e.Day.Date.ToString() == rdr.GetValue(5).ToString())
            {
                e.Cell.BackColor = System.Drawing.Color.OrangeRed;
            }

        }
        con.Close();
        SqlCommand cmd1 = new SqlCommand("select idate from calendar ", con);
        con.Open();

        SqlDataReader rdr1 = cmd1.ExecuteReader();

        while (rdr1.Read())
        {
            if (e.Day.Date.ToString() == rdr1.GetValue(0).ToString())
            {
                e.Cell.BackColor = System.Drawing.Color.Yellow;
            }

        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (date.Text != "")
        {
            con.Open();
            SqlCommand check = new SqlCommand("select idate from calendar where idate ='" + date.Text + "'", con);
            object n = check.ExecuteScalar();
            if (n == null)
            {
                SqlCommand insert = new SqlCommand("insert into calendar values('" + date.Text + "','" + name.Text + "','" + round.Text + "','" + req.Text + "','" + venue.Text + "','" + time.Text.ToString() + "','" + address.Text + "')", con);

                SqlDataReader put = insert.ExecuteReader();
                update.Text = "update sucessful";

            }
            con.Close();
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Sure", "empty the database for the next acadamic year", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            Random num = new Random();
            otp = num.Next(1000, 9999);
            SMS.APIType = SMSGateway.Site2SMS;
            SMS.MashapeKey = "PzDd5ioa9EmshA8xsDkQVYGhMIObp1ZLEWsjsnfjrzQP84mZLN";
            SMS.Username = "8978250195";
            SMS.Password = "8978250195";

            //Single SMS
            msg = "the otp is" + Convert.ToString(otp);
            Session["otp"] = Convert.ToString(otp);
            // SMS.SendSms("9502966861", msg);
            MessageBox.Show("Message sent Successfully");
            MessageBox.Show((string)Session["otp"]);
            Response.Redirect("sendmsg.aspx"); //do something
        }
        else if (dialogResult == DialogResult.No)
        {
            //do something else
        }
        
    }
    protected void news_Click(object sender, EventArgs e)
    {
        int j = 0;
        string[] news = new string[5];
        con.Open();
        if (newstb.Text != "")
        {
            SqlCommand countrecords = new SqlCommand("select count(sno) from news", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand incmd = new SqlCommand("insert into news (sno,msg) values(" + noofrecs + ", '" + newstb.Text + "')", con);
            incmd.ExecuteNonQuery();
        }
        SqlCommand countrecords1 = new SqlCommand("select count(sno) from news", con);
        for (int i = Convert.ToInt32(countrecords1.ExecuteScalar()); i > Convert.ToInt32(countrecords1.ExecuteScalar()) - 5; i--, j++)
        {
            SqlCommand dat = new SqlCommand("select msg from news where sno=" + i, con);
            news[j] = dat.ExecuteScalar().ToString();
        }
        /*if (Convert.ToInt32(countrecords1.ExecuteScalar()) > 5)
        {
            int a = Convert.ToInt32(countrecords1.ExecuteScalar()) - 4;
            SqlCommand del = new SqlCommand("delete news where sno <" + a, con);
            del.ExecuteNonQuery();
            int b = Convert.ToInt32(countrecords1.ExecuteScalar()) - 6;
            SqlCommand up = new SqlCommand("update news set sno=sno+" + b, con);
            up.ExecuteNonQuery();
        }*/
        con.Close();
        l1.Text = news[0];
        l2.Text = news[1];
        l3.Text = news[2];
        l4.Text = news[3];
        l5.Text = news[4];
    }
    

}