using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.IO;

namespace Team12
{
    public partial class AssignedEmployee : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_reqid.Text = Request.QueryString["x"];
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.SelectedRow.Enabled = false;
            GridView1.SelectedRow.Cells[0].Enabled = false;
            tb_assignedSupervisor.Text = tb_assignedSupervisor.Text + " " + GridView1.SelectedRow.Cells[3].Text + ", ";

        }



        protected void btn_search_Click1(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                string selectedBy = list_search.SelectedValue.ToString();

                if (selectedBy == "Supervisor ID" && tb_SearchId.Text != "")
                {
                    query = "SELECT name,designation,email from supervisor where sid=" + Convert.ToInt32(tb_SearchId.Text);
                }
                else if (selectedBy == "Supervisor Name" && tb_SearchId.Text != "")
                {
                    query = "SELECT name,designation,email from supervisor where name='" + tb_SearchId.Text + "'";
                }
                else if (selectedBy == "Supervisor ID" && tb_SearchId.Text == "")
                {
                    query = "SELECT name,designation,email from supervisor";
                }
                else if (selectedBy == "Supervisor Name" && tb_SearchId.Text == "")
                {
                    query = "SELECT name,designation,email from supervisor";
                }
                else if (selectedBy == "")
                {
                    query = "SELECT name,designation,email from supervisor";
                }

                using (MySqlConnection con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand(query))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                con.Close();
                                if (dt.Rows.Count > 0)
                                {
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                                else
                                {
                                    dt.Rows.Add(dt.NewRow());
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    int columncount = GridView1.Rows[0].Cells.Count;
                                    GridView1.Rows[0].Cells.Clear();
                                    GridView1.Rows[0].Cells.Add(new TableCell());
                                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please fill the fields ');</script>");
            }
        }

        protected void btn_CancelSelection_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            gvr.Cells[0].Enabled = true;
            //GridView1.SelectedRow.Cells[0].Enabled = true;
            //tb_assignedSupervisor.Text = tb_assignedSupervisor.Text + " " + GridView1.SelectedRow.Cells[3].Text + ", ";
            //tb_assignedSupervisor.Text = tb_assignedSupervisor.Text;
            String line = tb_assignedSupervisor.Text;
            tb_assignedSupervisor.Text = line.Replace(gvr.Cells[3].Text + ",", "");
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close()", true);
        }

        protected void btn_Assign_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {
                //check whether all the fields are not null
                bool fieldsReq = RequiredFieldValidate();
                if (fieldsReq)
                {
                    String listOfAssignedManagers = (tb_assignedSupervisor.Text).Trim();
                    if (listOfAssignedManagers.EndsWith(","))
                    {
                        listOfAssignedManagers = listOfAssignedManagers.Substring(0, listOfAssignedManagers.Length - 1);
                    }
                    String[] arrayOfAssignedManagers = listOfAssignedManagers.Split(',');
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ arrayOfAssignedManagers[2]  + "');</script>");


                    for (int i = 0; i < arrayOfAssignedManagers.Length; i++)
                    {

                        conn.Open();
                        try
                        {
                            cmd = conn.CreateCommand();
                            cmd.CommandText = "SELECT * FROM supervisor where name='" + arrayOfAssignedManagers[i] + "' ";

                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                hiiden_designation.Text = reader.GetString("designation");
                                hidden_phone.Text = reader.GetString("phone");
                                hidden_email.Text = reader.GetString("email");
                            }
                            conn.Close();

                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ hiiden_designation.Text + "');</script>");
                            conn.Open();
                            queryStr = "insert into assigned_employee (name,designation,phone,reqid,email) values ('" + arrayOfAssignedManagers[i].Trim() + "','" + hiiden_designation.Text + "','" + hidden_phone.Text + "','" + tb_reqid.Text + "','" + hidden_email.Text + "')";
                            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted.!  ');</script>");
                            conn.Close();
                        }
                        catch
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('failed');</script>");
                        }


                    }


                    //queryStr = "insert into assigned_employee (name,designation,email,reqid) values ('" + tb_expenseid.Text + "','" + tb_expensedate.Text + "','" + Convert.ToString(list_expensetype.SelectedValue) + "','" + tb_expensedescription.Text + "','" + tb_expenseamount.Text + "')";
                    //cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                    //cmd.ExecuteNonQuery();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted.!  ');</script>");


                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please assign managers to approve requisition..!!');</script>");
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data insertion failed');</script>");
            }



        }

        protected bool RequiredFieldValidate()
        {
            if ((tb_assignedSupervisor.Text == "") || (tb_assignedSupervisor.Text == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}