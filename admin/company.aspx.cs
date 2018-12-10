using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
public partial class company : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        //Button1.Visible = true;
        //Button2.Visible = false;
       // Button3.Visible = false;
        //SqlConnection con = new SqlConnection("Initial catalog=Nexus; Data Source=LAHARI-PC\\SQLEXPRESS; Integrated Security=true");
        /*SqlCommand cmd = new SqlCommand("Select *from company", con);
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        //GridView1.DataBind();
        con.Close();*/
    }
    /* protected void Button1_Click(object sender, EventArgs e)
     {
         SqlConnection con = new SqlConnection("Initial catalog=employee; Data Source=LAHARI-PC\\SQLEXPRESS; Integrated Security=true");
         con.Open();
         SqlCommand incmd = new SqlCommand("insert into company imageurl ='~/Imgs/"+TextBox6.Text+"'",con);
         incmd.ExecuteNonQuery();
         con.Close();
     }*/
    protected void Button1_Click1(object sender, EventArgs e)
    {
        //Response.Redirect("company.aspx");
        if (tbCompanyName.Text != "")
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from company where name='"+ tbCompanyName.Text +"'", con);
            if (cmd2.ExecuteScalar() == null)
            {
                SqlCommand countrecords = new SqlCommand("select cid from company order by cid desc", con);
                int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
                SqlCommand incmd = new SqlCommand("insert into company (cid,name,addrs,email,mobile,contper,imageurl) values(" + noofrecs + ",'" + tbCompanyName.Text + "','" + tbAddress.Text + "','" + tbEmail.Text + "','" + tbContact.Text + "','" + tbContactPerson.Text + "','~/placement management/general/Imgs/" + tbLogo.Text + "')", con);
                incmd.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("Select *from company", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
                SqlCommand create = new SqlCommand("create table " + tbCompanyName.Text + " (sname varchar(20) constraint " + tbCompanyName.Text + "pk primary key,r1 bit ,r2 bit,r3 bit,r4 bit,r5 bit,slmail bit,r1mail bit,r2mail bit,r3mail bit,r4mail bit,r5mail bit); ", con);
                create.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("insert into clogs values('" + tbCompanyName.Text + "','" + pwd.Text + "') ", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Redirect("company.aspx");
            }
            else
            {
                MessageBox.Show("company already exist");
                Response.Redirect("company.aspx");
   
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Are you sure to delete the company", "delete " + tbCompanyName.Text, MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE company WHERE cid=" + Convert.ToInt32(lbcid.Text), con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("delete clogs where username='" + tbCompanyName.Text + "'", con);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("drop table " + tbCompanyName.Text + "", con);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("delete round where cid=" + Convert.ToInt32(lbcid.Text), con);
            cmd3.ExecuteNonQuery();
            SqlCommand cmd4 = new SqlCommand("DELETE compsk WHERE cid=" + Convert.ToInt32(lbcid.Text), con);
            cmd4.ExecuteNonQuery();
            SqlCommand cmd5 = new SqlCommand("select *from checks where cid=" + Convert.ToInt32(lbcid.Text), con);
            if (cmd5.ExecuteScalar() != null)
            {
                SqlCommand cmd6 = new SqlCommand("DELETE checks WHERE cid=" + Convert.ToInt32(lbcid.Text), con);
                cmd6.ExecuteNonQuery();
            }
            con.Close();
            Response.Redirect("company.aspx");
        }
        else if (dialogResult == DialogResult.No)
        {
            //do something else
        }
        
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Button1.Visible = false;
       // Button3.Visible = true;
        //Button2.Visible = true;
        SqlCommand dat = new SqlCommand("select * from company", con);
        con.Open();
        SqlDataReader r = dat.ExecuteReader();
        while (r.Read())
        {
            if (GridView1.SelectedRow.Cells[1].Text.ToString() == r.GetValue(1).ToString())
            {
                lbcid.Text = r.GetValue(0).ToString();
                tbCompanyName.Text = r.GetValue(1).ToString();
                tbAddress.Text = r.GetValue(2).ToString();
                tbEmail.Text = r.GetValue(3).ToString();
                tbContact.Text = r.GetValue(4).ToString();
                tbContactPerson.Text = r.GetValue(5).ToString();
                tbLogo.Text = r.GetValue(6).ToString();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("select pawd from clogs where username='"+tbCompanyName.Text+"'", con);
                con.Open();
                pwd.Text= cmd1.ExecuteScalar().ToString();
                break;

            }
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE company SET name='" + tbCompanyName.Text + "',addrs='" + tbAddress.Text + "',email='" + tbEmail.Text + "',mobile='" + tbContact.Text + "',contper='" + tbContactPerson.Text + "',imageurl='" + tbLogo.Text + "' WHERE cid='" + lbcid.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 =new SqlCommand("update clogs set pawd='"+pwd.Text+"' where username='"+tbCompanyName.Text+"'",con);
        cmd1.ExecuteNonQuery();
        con.Close();
        Response.Redirect("company.aspx");
    }

}