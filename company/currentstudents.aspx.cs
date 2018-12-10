using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing;

public partial class company_currentstudents : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NexusConnectionString"].ToString());//connecting to the database
    decimal per;
    int pack1, pack2;
    int nill=0,typ,cid,list=0,noofrounds;
    String s1, s2, s3, s4, b1, b2, b3, b4;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        GridView1.Columns[1].Visible = false;
        SqlDataSource1.SelectCommand = "select sname from dbo." + (string)Session["username"];
        int j = 0;
        string[] news = new string[5];
        con.Open();

        SqlCommand check1 = new SqlCommand("select * from compsk where cid =" + (int)Session["cid"], con);
        
        if (check1.ExecuteScalar() != null)
        {
            Button1.Visible = false;

        }
        SqlCommand roundcheck = new SqlCommand("select no from round where cid =" + (int)Session["cid"], con);
        if(check1.ExecuteScalar()!=null && roundcheck.ExecuteScalar()!=null)
        {
            noofrounds = Convert.ToInt32(roundcheck.ExecuteScalar().ToString());
            GridView1.Columns[1].Visible = true;
        }
        
        


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
        cid = (int)Session["cid"];
        int flag = 0;//taking the company id and storing in cid
        SqlCommand cmd1 = new SqlCommand("select *from checks where cid=" + cid, con);
        con.Open();
        SqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            rdr.Read();
            per = Convert.ToDecimal(rdr.GetValue(1).ToString());//taking the percentage and storing in per 
            s1 = rdr.GetValue(2).ToString();//getting the skills and branches
            s2 = rdr.GetValue(3).ToString();
            s3 = rdr.GetValue(4).ToString();
            s4 = rdr.GetValue(5).ToString();
            b1 = rdr.GetValue(6).ToString();
            b2 = rdr.GetValue(7).ToString();
            b3 = rdr.GetValue(8).ToString();
            b4 = rdr.GetValue(9).ToString();
            typ = Convert.ToInt32(rdr.GetValue(10).ToString());
            con.Close();
            con.Open();
            SqlCommand pac = new SqlCommand("select package from company where cid=" + cid, con);
            int pack = Convert.ToInt32(pac.ExecuteScalar().ToString());
       



           
            SqlCommand check2 = new SqlCommand("select * from compsk where cid =" + (int)Session["cid"], con);
            
            if (check2.ExecuteScalar() == null)
            {
                 SqlCommand dummy = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('dummy')", con);
            dummy.ExecuteNonQuery();
            SqlCommand check = new SqlCommand("delete " + (string)Session["username"], con);
            check.ExecuteNonQuery();
            if (typ==1)
            {
                if (s1 == "" && s2 == "" && s3 == "" && s4 == "" && flag == 0)//if company dosent select any skill
                {

                    
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1=pack2=0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {
                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString())/2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString())/2);
                            }
                        }
                        else continue;
                            if(pack>=pack1 && pack>=pack2)
                                if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                    if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                    {
                                        SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                        cmd4.ExecuteNonQuery();
                                    }
                        
                    }
                    flag = 1;

                }
                if (s2 == "" && s3 == "" && s4 == "" && flag == 0)//if company selects only 1 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {
                                   
                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString())//comparing first skill
                            if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                {
                                    SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                    cmd4.ExecuteNonQuery();
                                }

                    }
                    flag = 1;
                }
                if (s3 == "" && s4 == "" && flag == 0)//if company selects 2 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString())//comparing first skill

                            if (s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString())//comparing second skill
                                if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                    if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                    {
                                        SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                        cmd4.ExecuteNonQuery();
                                    }

                    }
                    flag = 1;
                }

                if (s4 == "" && flag == 0)//if the company selects 3 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString())//comparing first skill
                            if (s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString())//comparing second skill
                                if (s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s3 == r.GetValue(7).ToString() || s3 == r.GetValue(8).ToString() || s3 == r.GetValue(9).ToString() || s3 == r.GetValue(10).ToString())//comparing third skill
                                    if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                        if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                        {
                                            SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                            cmd4.ExecuteNonQuery();
                                        }

                    }
                    flag = 1;
                }

                if (s4 != "" && flag == 0)//if The company selects all 4 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString())//comparing first skill
                            if (s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString())//comparing second skill
                                if (s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s3 == r.GetValue(7).ToString() || s3 == r.GetValue(8).ToString() || s3 == r.GetValue(9).ToString() || s3 == r.GetValue(10).ToString())//comparing third skill
                                    if (s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s3 == r.GetValue(7).ToString() || s3 == r.GetValue(8).ToString() || s3 == r.GetValue(9).ToString() || s3 == r.GetValue(10).ToString())//comparing fourth skill
                                        if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                            if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                            {
                                                SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);

                                                cmd4.ExecuteNonQuery();

                                            }

                    }
                    flag = 1;
                }
            }
            if (typ == 0)
            {
                if (s1 == "" && s2 == "" && s3 == "" && s4 == "" && flag == 0)//if company dosent select any skill
                {


                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                            if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                            {
                                SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                cmd4.ExecuteNonQuery();
                            }
                    }
                    flag = 1;

                }
                if (s2 == "" && s3 == "" && s4 == "" && flag == 0)//if company selects only 3 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString())//comparing first skill
                            if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                {
                                    SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                    cmd4.ExecuteNonQuery();
                                }

                    }
                    flag = 1;
                }
                if (s3 == "" && s4 == "" && flag == 0)//if company selects 2 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString() || s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString())
                                if (per <= Convert.ToDecimal(r.GetValue(11).ToString())) //comparing student percentage with the percentage set by the company
                                    if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                    {
                                        SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                        cmd4.ExecuteNonQuery();
                                    }

                    }
                    flag = 1;
                }

                if (s4 == "" && flag == 0)//if the company selects 3 skills
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {
                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString() || s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString() || s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s3 == r.GetValue(7).ToString() || s3 == r.GetValue(8).ToString() || s3 == r.GetValue(9).ToString() || s3 == r.GetValue(10).ToString())
                                    if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                        if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                        {
                                            SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);
                                            cmd4.ExecuteNonQuery();
                                        }

                    }
                    flag = 1;
                }
                if (s4 != "" && flag == 0)
                {
                    SqlCommand dat = new SqlCommand("select *from skills", con);
                    SqlDataReader r = dat.ExecuteReader();
                    while (r.Read())
                    {

                        pack1 = pack2 = 0;
                        SqlCommand comp = new SqlCommand("select comp1,pack1,comp2,pack2,comp3 from studetails where sname='" + r.GetValue(0).ToString() + "'", con);
                        SqlDataReader read = comp.ExecuteReader();
                        read.Read();
                        if (read.GetValue(4).ToString() == "")
                        {
                            if (read.GetValue(2).ToString() == "")
                            {
                                if (read.GetValue(0).ToString() == "")
                                {
                                }
                                else
                                {

                                    pack1 = Convert.ToInt32(read.GetValue(1).ToString()) + (Convert.ToInt32(read.GetValue(1).ToString()) / 2);
                                }
                            }
                            else
                            {
                                pack2 = Convert.ToInt32(read.GetValue(3).ToString()) + (Convert.ToInt32(read.GetValue(3).ToString()) / 2);
                            }
                        }
                        else continue;
                        if (pack >= pack1 && pack >= pack2)
                        if (s1 == r.GetValue(1).ToString() || s1 == r.GetValue(2).ToString() || s1 == r.GetValue(3).ToString() || s1 == r.GetValue(4).ToString() || s1 == r.GetValue(5).ToString() || s1 == r.GetValue(6).ToString() || s1 == r.GetValue(7).ToString() || s1 == r.GetValue(8).ToString() || s1 == r.GetValue(9).ToString() || s1 == r.GetValue(10).ToString() || s2 == r.GetValue(1).ToString() || s2 == r.GetValue(2).ToString() || s2 == r.GetValue(3).ToString() || s2 == r.GetValue(4).ToString() || s2 == r.GetValue(5).ToString() || s2 == r.GetValue(6).ToString() || s2 == r.GetValue(7).ToString() || s2 == r.GetValue(8).ToString() || s2 == r.GetValue(9).ToString() || s2 == r.GetValue(10).ToString() || s3 == r.GetValue(1).ToString() || s3 == r.GetValue(2).ToString() || s3 == r.GetValue(3).ToString() || s3 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s3 == r.GetValue(7).ToString() || s3 == r.GetValue(8).ToString() || s3 == r.GetValue(9).ToString() || s3 == r.GetValue(10).ToString() || s4 == r.GetValue(1).ToString() || s4 == r.GetValue(2).ToString() || s4 == r.GetValue(3).ToString() || s4 == r.GetValue(4).ToString() || s3 == r.GetValue(5).ToString() || s3 == r.GetValue(6).ToString() || s4 == r.GetValue(7).ToString() || s4 == r.GetValue(8).ToString() || s4 == r.GetValue(9).ToString() || s4 == r.GetValue(10).ToString())
                            if (per <= Convert.ToDecimal(r.GetValue(11).ToString()))//comparing student percentage with the percentage set by the company
                                if (b1 == r.GetValue(12).ToString() || b2 == r.GetValue(12).ToString() || b3 == r.GetValue(12).ToString() || b4 == r.GetValue(12).ToString())//comparing the student branch with the branches selected by the company
                                {
                                    SqlCommand cmd4 = new SqlCommand("insert into " + (string)Session["username"] + "(sname) values('" + r.GetValue(0).ToString() + "')", con);

                                    cmd4.ExecuteNonQuery();

                                }

                    }
                    flag = 1;
                }
            }
        }
            con.Close();
            con.Open();
            
            
        }
        if (noofrounds == 1)
        {
            SqlDataSource1.SelectCommand = "select sname,r1 from dbo." + (string)Session["username"];
            SqlDataSource1.UpdateCommand = "update " + (string)Session["username"] + " set r1=@r1 where sname=@sname";
            SqlCommand comp = new SqlCommand("select sname from dbo." + (string)Session["username"] +" where r1=1", con);
            SqlDataReader read = comp.ExecuteReader();
            while (read.Read())
            {
                SqlCommand pack = new SqlCommand("select package from company where cid =" + (int)Session["cid"], con);
                string package = pack.ExecuteScalar().ToString();
                SqlCommand company = new SqlCommand("select comp1,comp2,comp3 from studetails where sname ='"+  read.GetValue(0).ToString()  +"'", con);
                SqlDataReader rdr1 = company.ExecuteReader();
                while (rdr1.Read())
                {
                    if (rdr1.GetValue(0).ToString() != (string)Session["username"] && rdr1.GetValue(1).ToString() != (string)Session["username"] && rdr1.GetValue(2).ToString() != (string)Session["username"])
                    {
                    if (rdr1.GetValue(0).ToString() == "")
                    {
                        SqlCommand update = new SqlCommand("update studetails set comp1 ='" + (string)Session["username"] + "',pack1='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rdr1.GetValue(1).ToString() == "")
                        {
                            SqlCommand update = new SqlCommand("update studetails set comp2 ='" + (string)Session["username"] + "',pack2='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                            update.ExecuteNonQuery();
                        }
                        else
                        {
                            if (rdr1.GetValue(2).ToString() == "")
                            {
                                SqlCommand update = new SqlCommand("update studetails set comp3 ='" + (string)Session["username"] + "',pack3='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                                update.ExecuteNonQuery();
                            }
                        }
                    }
                }
                }
                
            }
        }
        if (noofrounds == 2)
        {
            SqlDataSource1.SelectCommand = "select sname,r1,r2 from dbo." + (string)Session["username"];
            SqlDataSource1.UpdateCommand = "update " + (string)Session["username"] + " set r1=@r1,r2=@r2 where sname=@sname";
            SqlCommand comp = new SqlCommand("select sname from dbo." + (string)Session["username"] + " where r2=1", con);
            SqlDataReader read = comp.ExecuteReader();
            while (read.Read())
            {
                SqlCommand pack = new SqlCommand("select package from company where cid =" + (int)Session["cid"], con);
                string package = pack.ExecuteScalar().ToString();
                SqlCommand company = new SqlCommand("select comp1,comp2,comp3 from studetails where sname ='" + read.GetValue(0).ToString() + "'", con);
                SqlDataReader rdr1 = company.ExecuteReader();
                while (rdr1.Read())
                {
                    if (rdr1.GetValue(0).ToString() != (string)Session["username"] && rdr1.GetValue(1).ToString() != (string)Session["username"] && rdr1.GetValue(2).ToString() != (string)Session["username"])
                    {
                    if (rdr1.GetValue(0).ToString() == "")
                    {
                        SqlCommand update = new SqlCommand("update studetails set comp1 ='" + (string)Session["username"] + "',pack1='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rdr1.GetValue(1).ToString() == "")
                        {
                            SqlCommand update = new SqlCommand("update studetails set comp2 ='" + (string)Session["username"] + "',pack2='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                            update.ExecuteNonQuery();
                        }
                        else
                        {
                            if (rdr1.GetValue(2).ToString() == "")
                            {
                                SqlCommand update = new SqlCommand("update studetails set comp3 ='" + (string)Session["username"] + "',pack3='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                                update.ExecuteNonQuery();
                            }
                        }
                    }
                }
                }

            }
        }
        if (noofrounds == 3)
        {
            SqlDataSource1.SelectCommand = "select sname,r1,r2,r3 from dbo." + (string)Session["username"];
            SqlDataSource1.UpdateCommand = "update " + (string)Session["username"] + " set r1=@r1,r2=@r2,r3=@r3 where sname=@sname";
            SqlCommand comp = new SqlCommand("select sname from dbo." + (string)Session["username"] + " where r3=1", con);
            SqlDataReader read = comp.ExecuteReader();
            while (read.Read())
            {
                SqlCommand pack = new SqlCommand("select package from company where cid =" + (int)Session["cid"], con);
                string package = pack.ExecuteScalar().ToString();
                SqlCommand company = new SqlCommand("select comp1,comp2,comp3 from studetails where sname ='" + read.GetValue(0).ToString() + "'", con);
                SqlDataReader rdr1 = company.ExecuteReader();
                while (rdr1.Read())
                {
                    if (rdr1.GetValue(0).ToString() != (string)Session["username"] && rdr1.GetValue(1).ToString() != (string)Session["username"] && rdr1.GetValue(2).ToString() != (string)Session["username"])
                    {
                    if (rdr1.GetValue(0).ToString() == "")
                    {
                        SqlCommand update = new SqlCommand("update studetails set comp1 ='" + (string)Session["username"] + "',pack1='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rdr1.GetValue(1).ToString() == "")
                        {
                            SqlCommand update = new SqlCommand("update studetails set comp2 ='" + (string)Session["username"] + "',pack2='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                            update.ExecuteNonQuery();
                        }
                        else
                        {
                            if (rdr1.GetValue(2).ToString() == "")
                            {
                                SqlCommand update = new SqlCommand("update studetails set comp3 ='" + (string)Session["username"] + "',pack3='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                                update.ExecuteNonQuery();
                            }
                        }
                    }
                }
                }

            }
        }
        if (noofrounds == 4)
        {
            SqlDataSource1.SelectCommand = "select sname,r1,r2,r3,r4 from dbo." + (string)Session["username"];
            SqlDataSource1.UpdateCommand = "update " + (string)Session["username"] + " set r1=@r1,r2=@r2,r3=@r3,r4=@r4 where sname=@sname";
            SqlCommand comp = new SqlCommand("select sname from dbo." + (string)Session["username"] + " where r4=1", con);
            SqlDataReader read = comp.ExecuteReader();
            while (read.Read())
            {
                SqlCommand pack = new SqlCommand("select package from company where cid =" + (int)Session["cid"], con);
                string package = pack.ExecuteScalar().ToString();
                SqlCommand company = new SqlCommand("select comp1,comp2,comp3 from studetails where sname ='" + read.GetValue(0).ToString() + "'", con);
                SqlDataReader rdr1 = company.ExecuteReader();
                while (rdr1.Read())
                {
                    if (rdr1.GetValue(0).ToString() != (string)Session["username"] && rdr1.GetValue(1).ToString() != (string)Session["username"] && rdr1.GetValue(2).ToString() != (string)Session["username"])
                    {
                    if (rdr1.GetValue(0).ToString() == "")
                    {
                        SqlCommand update = new SqlCommand("update studetails set comp1 ='" + (string)Session["username"] + "',pack1='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rdr1.GetValue(1).ToString() == "")
                        {
                            SqlCommand update = new SqlCommand("update studetails set comp2 ='" + (string)Session["username"] + "',pack2='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                            update.ExecuteNonQuery();
                        }
                        else
                        {
                            if (rdr1.GetValue(2).ToString() == "")
                            {
                                SqlCommand update = new SqlCommand("update studetails set comp3 ='" + (string)Session["username"] + "',pack3='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                                update.ExecuteNonQuery();
                            }
                        }
                    }
                }
                }

            }
        }
        if (noofrounds == 5)
        {
            SqlDataSource1.SelectCommand = "select sname,r1,r2,r3,r4,r5 from dbo." + (string)Session["username"];
            SqlDataSource1.UpdateCommand = "update " + (string)Session["username"] + " set r1=@r1,r2=@r2,r3=@r3,r4=@r4,r5=@r5 where sname=@sname";
            SqlCommand comp = new SqlCommand("select sname from dbo." + (string)Session["username"] + " where r5=1", con);
            SqlDataReader read = comp.ExecuteReader();
            while (read.Read())
            {
                SqlCommand pack = new SqlCommand("select package from company where cid =" + (int)Session["cid"], con);
                string package = pack.ExecuteScalar().ToString();
                SqlCommand company = new SqlCommand("select comp1,comp2,comp3 from studetails where sname ='" + read.GetValue(0).ToString() + "'", con);
                SqlDataReader rdr1 = company.ExecuteReader();
                while (rdr1.Read())
                {
                    if (rdr1.GetValue(0).ToString() != (string)Session["username"] && rdr1.GetValue(1).ToString() != (string)Session["username"] && rdr1.GetValue(2).ToString() != (string)Session["username"])
                    {
                    if (rdr1.GetValue(0).ToString() == "")
                    {
                        SqlCommand update = new SqlCommand("update studetails set comp1 ='" + (string)Session["username"] + "',pack1='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        if (rdr1.GetValue(1).ToString() == "")
                        {
                            SqlCommand update = new SqlCommand("update studetails set comp2 ='" + (string)Session["username"] + "',pack2='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                            update.ExecuteNonQuery();
                        }
                        else
                        {
                            if (rdr1.GetValue(2).ToString() == "")
                            {
                                SqlCommand update = new SqlCommand("update studetails set comp3 ='" + (string)Session["username"] + "',pack3='" + package + "'where sname='" + read.GetValue(0).ToString() + "'", con);
                                update.ExecuteNonQuery();
                            }
                        }
                    }
                }
                }

            }
        }

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            SqlCommand company = new SqlCommand("select sname from studetails where comp1 !='' or comp2 !='' or comp3 !='' ", con);
            SqlDataReader rdr1 = company.ExecuteReader();
            while (rdr1.Read())
            {
                string test = GridView1.Rows[i].Cells[2].ToString();
                if (GridView1.Rows[i].Cells[2].Text.ToString() == rdr1.GetValue(0).ToString())
                {
                    GridView1.Rows[i].BackColor = Color.Yellow;
                }
            }
        }
        


        con.Close();
    }
    protected void view_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["sname"] = GridView1.SelectedRow.Cells[2].Text.ToString();
        Response.Redirect("../student/compstudinfo.aspx");//sending to students information page
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand check = new SqlCommand("select * from compsk where cid =" + (int)Session["cid"], con);
        con.Open();
        if (check.ExecuteScalar() == null)
        {
            SqlCommand rows = new SqlCommand("select * from "+(string)Session["username"]+"", con);
            
            if (rows.ExecuteScalar() != null)
            {

                SqlCommand cmd = new SqlCommand("INSERT into compsk values(" + (int)Session["cid"] + "," + per + ",'" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + b1 + "','" + b2 + "','" + b3 + "','" + b4 + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("company criteria submited");
                Button1.Visible = false;
                string from = "placementportal.kmit@gmail.com";
                //SqlCommand email = new SqlCommand("select email from studetails where sname='" + read.GetValue(0).ToString() + "'", con);
                string to = "saiananth1995@gmail.com"; //email.ExecuteScalar().ToString();
                string sub = "shortlist of " + Session["UserName"].ToString();
                string msg = "Mr. sudheer reddy , we are from " + Session["UserName"].ToString()+" . We have shortlisted your students as per our requirments . Once aknowledge the list make them available on the respective days of the rounds . Thank you for your cooperation";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("placementportal.kmit@gmail.com", "sala1234@");
                smtp.EnableSsl = true;
                smtp.Send(from, to, sub, msg);
                con.Close();

            }
            else MessageBox.Show("there are no students in the shortlist");
        }
        else MessageBox.Show("company criteria already submited");

        
        
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        Response.Redirect("currentstudents.aspx");
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
       
    }
}