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

public partial class Admin_Alumni : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
       // Button2.Visible = false;
        //Button3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Alumni.aspx");
        con.Open();
        SqlCommand cmd = new SqlCommand("Select *from alumni where name='"+tbName.Text+"'",con);
        if (cmd.ExecuteScalar() == null)
        {

            SqlCommand countrecords = new SqlCommand("select sno from alumni order by sno desc", con);
            int noofrecs = Convert.ToInt32(countrecords.ExecuteScalar()) + 1;
            SqlCommand icmd = new SqlCommand("insert into alumni (sno,name,branch,cname,salary,email) values(" + noofrecs + ",'" + tbName.Text + "','" + tbBranch.Text + "','" + tbCname.Text + "','" + tbSalary.Text + "','" + tbEmail.Text + "')", con);
            icmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Alumni.aspx");
        }
        else MessageBox.Show("alumni already exists");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Button2.Visible = true;
       // Button3.Visible = true;
        SqlCommand cmd = new SqlCommand("Select *from alumni where name='"+ GridView1.SelectedRow.Cells[1].Text.ToString() +"'", con);
        con.Open();
        SqlDataReader r = cmd.ExecuteReader();
        r.Read();
                lbsno.Text = r.GetValue(0).ToString();
                tbName.Text = r.GetValue(1).ToString();
                tbBranch.Text = r.GetValue(2).ToString();
                tbCname.Text = r.GetValue(3).ToString();
                tbSalary.Text = r.GetValue(4).ToString();
                tbEmail.Text = r.GetValue(5).ToString();

        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE alumni SET name='" + tbName.Text + "',branch='" + tbBranch.Text + "',cname='" + tbCname.Text + "',salary='" + tbSalary.Text + "',email='" + tbEmail.Text + "' WHERE sno='" + lbsno.Text + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Alumni.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Sure", "delete the alumni " + tbName.Text, MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE alumni WHERE sno=" + Convert.ToInt32(lbsno.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Alumni.aspx");  //do something
        }
        else if (dialogResult == DialogResult.No)
        {
            //do something else
        }
        
    }
} 