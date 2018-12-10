using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Net.Mail;
using System.Globalization;


public partial class company_company : System.Web.UI.Page
{
    
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());//connecting to database
    int rid,pack;
    string s1, s2, s3, s4, s5;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (CheckBox1.Checked)
        {
            Session["type"] = "0";
        }
        else
        {
            Session["type"] = "1";
        }
        if (TextBox1.Text != "")
        {
            pack = Convert.ToInt32(TextBox1.Text);
            pac.Text = pack.ToString("C", new CultureInfo("en-in"));
        }
        CompareEndTodayValidator.ValueToCompare = DateTime.Now.ToShortDateString();
        cname.Text = (string)Session["UserName"];//taking the company name from login page
        r1.Enabled = false;//disabling the round dates
        r2.Enabled = false;
        r3.Enabled = false;
        r4.Enabled = false;
        r5.Enabled = false;
        rd1tp.Enabled = false;
        rd2tp.Enabled = false;
        rd3tp.Enabled = false;
        rd4tp.Enabled = false;
        rd5tp.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
        RequiredFieldValidator5.Enabled = false;
        RequiredFieldValidator6.Enabled = false;
        RequiredFieldValidator7.Enabled = false;
        RequiredFieldValidator8.Enabled = false;
        RequiredFieldValidator9.Enabled = false;
        RequiredFieldValidator10.Enabled = false;
        RequiredFieldValidator11.Enabled = false;
        Button3.Visible = false;
        con.Open();
        SqlCommand id = new SqlCommand("select cid from company where name='" + cname.Text + "'", con);//taking the company id using the company name
        rid = Convert.ToInt32(id.ExecuteScalar());
        Session["cid"] = rid;
        if (!IsPostBack)
        {
            BindList();
            int i = 0;
            SqlCommand skill = new SqlCommand("select skill from skillstaught", con);
            SqlDataReader readsk = skill.ExecuteReader();
            while (readsk.Read())
            {
                SqlCommand stud = new SqlCommand("select COUNT(sname) from skills where skill1='" + readsk.GetValue(0).ToString() + "' or skill2='" + readsk.GetValue(0).ToString() + "' or skill3='" + readsk.GetValue(0).ToString() + "'or skill4='" + readsk.GetValue(0).ToString() + "'or skill5='" + readsk.GetValue(0).ToString() + "'or skill6='" + readsk.GetValue(0).ToString() + "'or skill7='" + readsk.GetValue(0).ToString() + "'or skill8='" + readsk.GetValue(0).ToString() + "'or skill9='" + readsk.GetValue(0).ToString() + "'or skill10='" + readsk.GetValue(0).ToString() + "' ", con);
                CheckBoxList2.Items[i].Text += "  (" + stud.ExecuteScalar() + ")";
                i++;
            }
        }
        con.Close();

        SqlCommand check = new SqlCommand("select * from compsk where cid =" + (int)Session["cid"], con);
        con.Open();
        if (check.ExecuteScalar() != null)
        {
            Button3.Visible = true;
            Button4.Visible = false;

        }
        con.Close();
        SqlCommand roundcheck = new SqlCommand("select * from round where cid =" + (int)Session["cid"], con);
        con.Open();
        if (roundcheck.ExecuteScalar() != null)
        {

            Button3.Visible = false;
        }
        con.Close();
    


    }
    private void BindList()
    {
        DataSet ds = new DataSet();
        string cmdstr = "select skill from skillstaught";
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);
        CheckBoxList2.DataSource = ds;
        CheckBoxList2.DataTextField = "skill";
        CheckBoxList2.DataValueField = "skill";
        CheckBoxList2.DataBind();
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        per1.Text = "";
        for (int i = 0; i < DropDownList3.Items.Count; i++)
            if (DropDownList3.Items[i].Selected)
                per1.Text += DropDownList3.Items[i].Value.ToString();//selecting the minimum percentage
    }
    protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lbsk1.Text = "";
        lbsk2.Text = "";
        lbsk3.Text = "";
        lbsk4.Text = "";

        int flag = 0;
        for (int i = 0; i < CheckBoxList2.Items.Count; i++)
            if (CheckBoxList2.Items[i].Selected)//selecting the required skills
            {

                flag++;

                if (flag == 1)
                {

                    lbsk1.Text = CheckBoxList2.Items[i].Value;//first skill 
                }
                if (flag == 2)
                {

                    lbsk2.Text = CheckBoxList2.Items[i].Value;// second skill
                }
                if (flag == 3)
                {

                    lbsk3.Text = CheckBoxList2.Items[i].Value;//third skill
                }

                if (flag == 4)
                {

                    lbsk4.Text = CheckBoxList2.Items[i].Value;//fourth skill
                }
                if (flag > 4)
                {
                    if (CheckBoxList2.Items[i].Selected == true)
                        CheckBoxList2.Items[i].Selected = false;//deselecting if the selected skills are more than 4
                    break;
                }
            }
    }
    protected void CheckBoxList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lbbr1.Text = "";
        lbbr2.Text = "";
        lbbr3.Text = "";
        lbbr4.Text = "";

        int flag = 0;

        for (int i = 0; i < CheckBoxList3.Items.Count; i++)
            if (CheckBoxList3.Items[i].Selected)
            {

                flag++;
                if (flag == 1)
                {

                    lbbr1.Text = CheckBoxList3.Items[i].Value;//selecting first branch
                }
                if (flag == 2)
                {

                    lbbr2.Text = CheckBoxList3.Items[i].Value;//selecting second branch
                }
                if (flag == 3)
                {

                    lbbr3.Text = CheckBoxList3.Items[i].Value;//selecting  third branch
                }
                if (flag == 4)
                {

                    lbbr4.Text = CheckBoxList3.Items[i].Value;//selecting fourth branch
                }


            }
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)//entering round dates
    {
        try
        {
            r1.Enabled = true;//enabling the round dates
            r2.Enabled = true;
            r3.Enabled = true;
            r4.Enabled = true;
            r5.Enabled = true;
            rd1tp.Enabled = true;
            rd2tp.Enabled = true;
            rd3tp.Enabled = true;
            rd4tp.Enabled = true;
            rd5tp.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
            RequiredFieldValidator10.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
            
            

            int i;
            for (i = 0; i < DropDownList4.Items.Count; i++)//disabling the rounds on the basis of number of rounds selected
            {
                if (DropDownList4.Items[i].Selected) break;

            }


            if (i <= 4)
            {
                r5.Enabled = false; rd5tp.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                RequiredFieldValidator11.Enabled = false;


                if (i <= 3)
                {

                    r4.Enabled = false; rd4tp.Enabled = false;
                    RequiredFieldValidator5.Enabled = false;
                    RequiredFieldValidator10.Enabled = false;

                    if (i <= 2)
                    {
                        r3.Enabled = false; rd3tp.Enabled = false;
                        RequiredFieldValidator4.Enabled = false;
                        RequiredFieldValidator9.Enabled = false;
                        if (i <= 1)
                        {
                            r2.Enabled = false; rd2tp.Enabled = false;
                            RequiredFieldValidator3.Enabled = false;
                            RequiredFieldValidator8.Enabled = false;



                            if (i <= 0)
                            {
                                r1.Enabled = false; rd1tp.Enabled = false;
                               






                            }
                        }
                    }
                }
            }
        }
        catch (Exception p)
        {
        }
    }


    protected void Button3_Click(object sender, EventArgs e)//entering the dates into the database(COMPANY CANNOT CHANGE THE DATE ONCE ENTERED AND NO TWO CCOMPANIES CAN COME ON THE SAME DAY)
    {
        
        int flag = 0;
        try
        {
            con.Open();
            
            SqlCommand insert1 = new SqlCommand("select *from round where cid=" + rid + " ", con);
            object n = insert1.ExecuteScalar();
            if (n == null)//checking if the dates are already present inthe database
            {
                SqlCommand check = new SqlCommand("select * from round", con);
                SqlDataReader r = check.ExecuteReader();
                while (r.Read())
                {
                    if (DropDownList4.SelectedItem.Text == "1")// converting the date format from MM-dd-yyyy to dd-MM-yyyy for comparing the dates with the database dates 
                    {
                        s1 = DateTime.Parse(r1.Text).ToString("dd-MM-yyyy HH:mm:ss");
                    }
                    if (DropDownList4.SelectedValue == "2")
                    {
                        s1 = DateTime.Parse(r1.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s2 = DateTime.Parse(r2.Text).ToString("dd-MM-yyyy HH:mm:ss");
                    }
                    if (DropDownList4.SelectedValue == "3")
                    {
                        s1 = DateTime.Parse(r1.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s2 = DateTime.Parse(r2.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s3 = DateTime.Parse(r3.Text).ToString("dd-MM-yyyy HH:mm:ss");
                    }
                    if (DropDownList4.SelectedValue == "4")
                    {
                        s1 = DateTime.Parse(r1.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s2 = DateTime.Parse(r2.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s3 = DateTime.Parse(r3.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s4 = DateTime.Parse(r4.Text).ToString("dd-MM-yyyy HH:mm:ss");
                    }
                    if (DropDownList4.SelectedValue == "5")
                    {
                        s1 = DateTime.Parse(r1.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s2 = DateTime.Parse(r2.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s3 = DateTime.Parse(r3.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s4 = DateTime.Parse(r4.Text).ToString("dd-MM-yyyy HH:mm:ss");
                        s5 = DateTime.Parse(r5.Text).ToString("dd-MM-yyyy HH:mm:ss");

                    }



                    // MessageBox.Show(r.GetValue(1).ToString());
                    if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString())
                    {
                        flag = 1;// setting flag=1 if the round 1 date tallies with one of the date in the database
                    }
                    if (s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString())
                    {
                        flag = 2;// setting flag=2 if the round 2 date tallies with one of the date in the database
                    }
                    if (s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString())
                    {
                        flag = 3;// setting flag=3 if the round 3 date tallies with one of the date in the database
                    }
                    if (s4 == r.GetValue(1).ToString() || s4 == r.GetValue(2).ToString() || s4 == r.GetValue(3).ToString() || s4 == r.GetValue(4).ToString() || s4 == r.GetValue(5).ToString())
                    {
                        flag = 4;// setting flag=4 if the round 4 date tallies with one of the date in the database
                    }
                    if (s5 == r.GetValue(1).ToString() || s5 == r.GetValue(2).ToString() || s5 == r.GetValue(3).ToString() || s5 == r.GetValue(4).ToString() || s5 == r.GetValue(5).ToString())
                    {
                        flag = 5;// setting flag=5 if the round 5 date tallies with one of the date in the database
                    }
                }
                if (flag == 1) rounds.Text = "Round 1 date already booked";//displaying that the round's date is already booked by some other company
                if (flag == 2) rounds.Text = "Round 2 date already booked";
                if (flag == 3) rounds.Text = "Round 3 date already booked";
                if (flag == 4) rounds.Text = "Round 4 date already booked";
                if (flag == 5) rounds.Text = "Round 5 date already booked";
                if (flag == 0)//if the date is not present in the database
                {
                    SqlCommand cmd = new SqlCommand("insert into round values(" + rid + ", '" + r1.Text + "', '" + r2.Text + "', '" + r3.Text + "', '" + r4.Text + "','" + r5.Text + "','" + rd1tp.SelectedValue.ToString() + "','" + rd2tp.SelectedValue.ToString() + "','" + rd3tp.SelectedValue.ToString() + "','" + rd4tp.SelectedValue.ToString() + "','" + rd5tp.SelectedValue.ToString() + "',"+ Convert.ToInt32(DropDownList4.SelectedValue) +") ", con);
                    cmd.ExecuteNonQuery();//enters the rounds into the database table
                    string from = "placementportal.kmit@gmail.com";
                    //SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                    string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                    string sub = "Round information of " + Session["UserName"].ToString();
                    string msg = "Mr. sudheer reddy , we are from " + Session["UserName"].ToString() + " . We have given information about the rounds . Once aknowledge the dates make students available on the respective days of the rounds . Thank you for your cooperation . For any other information contact our contact person .";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                    smtp.EnableSsl = true;
                    smtp.Send(from, to, sub, msg);
                }


            }
            else MessageBox.Show("Company round dates already exists update unsuccessful");
            con.Close();
        }
        catch (Exception p)
        {
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand package = new SqlCommand("update company set package='" + pack + "' where name='" + Session["UserName"] + "'", con);
            package.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("select *from checks where cid=" + (int)Session["cid"], con);
            if (cmd1.ExecuteScalar() != null)
            {
                SqlCommand cmd = new SqlCommand("DELETE checks WHERE cid=" + (int)Session["cid"], con);
                cmd.ExecuteNonQuery();
            }
            SqlCommand checksk = new SqlCommand("select * from checks where cid =" + rid, con);
            object n = checksk.ExecuteScalar();
            if (n == null)//checking if the data is already present in the database table
            {

                SqlCommand data = new SqlCommand(" insert into checks values(" + rid + "," + Convert.ToInt32(per1.Text) + ",'" + lbsk1.Text + "','" + lbsk2.Text + "','" + lbsk3.Text + "','" + lbsk4.Text + "','" + lbbr1.Text + "','" + lbbr2.Text + "','" + lbbr3.Text + "','" + lbbr4.Text + "',"+ Convert.ToInt32((string)Session["type"]) +")", con);
                data.ExecuteNonQuery();//entering the data into the table
                //lbup.Text = "successful";
            }

            //else MessageBox.Show("Company criterion already exists update unsuccessful");
            con.Close();

            Response.Redirect("../company/currentstudents.aspx");//redirected to current students page to display the shortlisted students
        }
        catch (Exception p)
        {
        }
    }



    protected void rd1tp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Session["type"] = RadioButtonList1.SelectedValue.ToString();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            Session["type"] = "0";
        }
        else
        {
            Session["type"] = "1";
        }
    }
}