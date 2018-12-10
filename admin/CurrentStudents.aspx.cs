using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
public partial class Admin_CurrentStudents : System.Web.UI.Page
{
    int j;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlCommand cmd1 = new SqlCommand("select skill  from skillstaught ", con);

        //con.Open();
        //SqlDataReader rdr1 = cmd1.ExecuteReader();
        //if (rdr1.HasRows == true)
        //{
        //    ListBox1.DataSource = rdr1;
        //    ListBox1.DataTextField = "skill";
        //    ListBox1.DataValueField = "skill";
        //    ListBox1.DataBind();
        //    //ListBox1.Items.Insert(0, new ListItem("--Select--", "0"));
        //}
        //con.Close();
        
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
           
            int a = ListBox1.Items.Count;
            SqlCommand dat = new SqlCommand("select * from skills where sname='" + sname.Text + "'", con);
            SqlDataReader r = dat.ExecuteReader();

            r.Read();
            if (r.HasRows)
            {
                for (int i = 0; i < a; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        if (ListBox1.Items[i].Text != r.GetValue(1).ToString() && ListBox1.Items[i].Text != r.GetValue(2).ToString() && ListBox1.Items[i].Text != r.GetValue(3).ToString() && ListBox1.Items[i].Text != r.GetValue(4).ToString() && ListBox1.Items[i].Text != r.GetValue(5).ToString() && ListBox1.Items[i].Text != r.GetValue(6).ToString() && ListBox1.Items[i].Text != r.GetValue(7).ToString() && ListBox1.Items[i].Text != r.GetValue(8).ToString() && ListBox1.Items[i].Text != r.GetValue(9).ToString() && ListBox1.Items[i].Text != r.GetValue(10).ToString())
                        {
                            for (j = 1; j <= 10; j++)
                            {
                                if (r.GetValue(j).ToString() == "")
                                {
                                    con.Close();

                                    SqlCommand icmd = new SqlCommand("UPDATE skills SET skill" + j + "='" + ListBox1.Items[i].Text + "' WHERE sname='" + sname.Text + "'", con);
                                    con.Open();
                                    icmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("student skill " + ListBox1.Items[i].Text + " updated");
                                    
                                    break;

                                }

                            }
                            if (j == 11)
                            {
                                MessageBox.Show("student skills are full");
                                skills.Text = "10";
                            }
                        }
                        else MessageBox.Show("skill " + ListBox1.Items[i].Text + " already exists");

                    }
                }
            }
            else MessageBox.Show("student not selected");
            con.Close();
            Response.Redirect("CurrentStudents.aspx");
        }
        catch (Exception p)
        { }
    }
   
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        /*Session["sname"]*/sname.Text = GridView1.SelectedRow.Cells[1].Text.ToString();
        try
        {
            con.Open();
            SqlCommand dat = new SqlCommand("select * from studetails", con);

            SqlDataReader r = dat.ExecuteReader();
            while (r.Read())
            {
                if (sname.Text.ToString() == r.GetValue(0).ToString())
                {
                    //string str = r.GetValue(3).ToString();
                    // twelfthper.Enabled = false;
                    // firstper.Enabled = false;
                    branch.Text = r.GetValue(1).ToString();
                    tenper.Text = r.GetValue(2).ToString();
                    interper.Text = r.GetValue(3).ToString();
                    enggper.Text = r.GetValue(4).ToString();
                    emailid.Text = r.GetValue(5).ToString();
                    contact.Text = r.GetValue(6).ToString();



                }
            }
            con.Close();
            //con.Open();
            //SqlCommand percmd = new SqlCommand("UPDATE skills SET per=" + enggper.Text + " WHERE sname='" + sname.Text + "'", con);
            //percmd.ExecuteNonQuery();
            //SqlCommand brcmd = new SqlCommand("UPDATE skills SET branch='" + branch.Text + "' WHERE sname='" + sname.Text + "'", con);
            //brcmd.ExecuteNonQuery();
            //con.Close();
            SqlCommand dat1 = new SqlCommand("select * from skills where sname='" + sname.Text + "'", con);
            con.Open();
            SqlDataReader r1 = dat1.ExecuteReader();
            int a = ListBox1.Items.Count;
            r1.Read();
            if (r1.HasRows)
            {
              for (j = 1; j <= 10; j++)
              if (r1.GetValue(j).ToString() == "")
                  {
                     skills.Text = Convert.ToString(j-1);
                     break;
                  }
            }
            con.Close();
        }
        catch (SqlException m)
        { }
        //Response.Redirect("../student/studentinfo.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select *from studetails where sname='" + sname.Text + "'", con);
        if (cmd.ExecuteScalar() == null)
        {
            SqlCommand stdsk = new SqlCommand("insert into skills (sname,per,branch) values('" + sname.Text + "'," + Convert.ToDecimal(enggper.Text) + ",'" + branch.Text + "')", con);
            stdsk.ExecuteNonQuery();
            SqlCommand icmd = new SqlCommand("insert into studetails (sname,branch,tenper,interper,enggper,email,contact) values('" + sname.Text + "','" + branch.Text + "','" + tenper.Text + "','" + interper.Text + "','" + enggper.Text + "','"+ emailid.Text+"','"+contact.Text+"')", con);
            icmd.ExecuteNonQuery();
            con.Close();
            
        }
        Response.Redirect("CurrentStudents.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE studetails SET sname='" + sname.Text + "',branch='" + branch.Text + "',tenper='"+tenper.Text+"',interper='"+interper.Text+"',enggper='"+enggper.Text+"',email='" + emailid.Text + "',contact='"+contact.Text+"' WHERE sname='" + sname.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("UPDATE skills SET per=" + Convert.ToDecimal(enggper.Text) + ",branch='" + branch.Text + "' WHERE sname='" + sname.Text + "'", con);
        cmd1.ExecuteNonQuery();
        con.Close();
        Response.Redirect("CurrentStudents.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Sure", "delete student " + sname.Text, MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            con.Open();
            SqlCommand stdsk = new SqlCommand(" delete skills where sname='" + sname.Text + "'", con);
            stdsk.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("DELETE studetails WHERE sname='" + sname.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("CurrentStudents.aspx");
        }
        else if (dialogResult == DialogResult.No)
        {
            //do something else
        }
        
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["sname"] = GridView1.SelectedRow.Cells[1].Text.ToString();
        Response.Redirect("Studentinfo.aspx");
    
    }
}