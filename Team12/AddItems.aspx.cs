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
    public partial class AddItems : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        //String ConnString = "Data Source=localhost;Initial Catalog=procurement;User ID=root;Password=";

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_reqid.Text = Request.QueryString["x"];
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                string selectedBy = list_search.SelectedValue.ToString();

                if (selectedBy == "Item ID" && tb_SearchId.Text != "")
                {
                    query = "SELECT item_name, description, uom, item_price from all_items where all_itemid=" + Convert.ToInt32(tb_SearchId.Text);
                }
                else if (selectedBy == "Item Name" && tb_SearchId.Text != "")
                {
                    query = "SELECT item_name, description, uom, item_price from all_items where item_name='" + tb_SearchId.Text + "'";
                }
                else if (selectedBy == "Item ID" && tb_SearchId.Text == "")
                {
                    query = "SELECT item_name, description, uom, item_price from all_items";
                }
                else if (selectedBy == "Item Name" && tb_SearchId.Text == "")
                {
                    query = "SELECT item_name, description, uom, item_price from all_items";
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
            gvr.Cells[3].Enabled = true;


            try
            {
                String line = tb_items_withqty.Text;
                System.Diagnostics.Debug.WriteLine(gvr.Cells[4].Text + " - " + ((TextBox)gvr.Cells[3].FindControl("tb_quantity")).Text + ",");
                System.Diagnostics.Debug.WriteLine(tb_items_withqty.Text.Trim());
                tb_items_withqty.Text = (line.Trim()).Replace((gvr.Cells[4].Text + " - " + ((TextBox)gvr.Cells[3].FindControl("tb_quantity")).Text + ",").Trim(), "");

            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please select the item first');</script>");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.SelectedRow.Enabled = false;
            if (((TextBox)GridView1.SelectedRow.Cells[3].FindControl("tb_quantity")).Text == "" || ((TextBox)GridView1.SelectedRow.Cells[3].FindControl("tb_quantity")).Text == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter the qunatity first ');</script>");
            }

            else
            {
                GridView1.SelectedRow.Cells[0].Enabled = false;
                GridView1.SelectedRow.Cells[3].Enabled = false;

                tb_items_withqty.Text = tb_items_withqty.Text + " " + (GridView1.SelectedRow.Cells[4].Text + " - " + ((TextBox)GridView1.SelectedRow.Cells[3].FindControl("tb_quantity")).Text) + ", ";

            }


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
                    String listOfItemsnqty = (tb_items_withqty.Text).Trim();
                    if (listOfItemsnqty.EndsWith(","))
                    {
                        listOfItemsnqty = listOfItemsnqty.Substring(0, listOfItemsnqty.Length - 1);
                    }
                    String[] arrayOfItemsnqty = listOfItemsnqty.Split(',');
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ arrayOfAssignedManagers[2]  + "');</script>");
                    String Item_name;
                    String Item_qty;
                    double count = 0;
                    for (int i = 0; i < arrayOfItemsnqty.Length; i++)
                    {

                        conn.Open();
                        try
                        {
                            Item_name = arrayOfItemsnqty[i].Split('-')[0].Trim();
                            Item_qty = arrayOfItemsnqty[i].Split('-')[1].Trim();
                            System.Diagnostics.Debug.WriteLine(Item_name);
                            System.Diagnostics.Debug.WriteLine(Item_qty);
                            cmd = conn.CreateCommand();
                            cmd.CommandText = "SELECT * FROM all_items where item_name='" + Item_name + "' ";

                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                hiiden_description.Text = reader.GetString("description");
                                hidden_itemprice.Text = reader.GetString("item_price");
                                hidden_uom.Text = reader.GetString("uom");
                                hidden_supplier.Text = reader.GetString("supplier");
                                hidden_sup_email.Text = reader.GetString("supplier_email");
                            }
                            conn.Close();

                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('"+ hiiden_designation.Text + "');</script>");
                            conn.Open();
                            queryStr = "insert into item (item_name,description,uom,item_price,quantity,supplier,supplier_email,reqid) values ('" + Item_name.Trim() + "','" + hiiden_description.Text + "','" + hidden_uom.Text + "','" + Convert.ToDouble(hidden_itemprice.Text) + "','" + Convert.ToDouble(Item_qty) + "','" + hidden_supplier.Text + "','" + hidden_sup_email.Text + "','" + Convert.ToInt32(tb_reqid.Text) + "')";
                            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted.!  ');</script>");
                            conn.Close();

                            count = count + (Convert.ToDouble(hidden_itemprice.Text) * Convert.ToDouble(Item_qty));
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
                    tb_itemPrice.Text = count.ToString();

                    conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                    conn.Open();
                    double policy_amount;
                    try
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT * FROM policy where policy_name='Requisition Approval'";

                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            policy_amount = reader.GetDouble("amount");

                            //if (count > policy_amount)
                            //{
                            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ALERT..!!! \n Item cost exceeds the policy amount. Need supervisor approval for this.!!!');</script>");
                            //    lbl_warning.Visible = true;
                            //    lbl_done.Visible = false;
                            //}

                            if (checkPlicyAmount(count, policy_amount))
                            {
                                lbl_warning.Visible = true;
                                lbl_done.Visible = false;
                            }
                            else
                            {
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ALERT..!!! \n Item cost exceeds the policy amount. Need supervisor approval for this.!!!');</script>");
                                lbl_done.Visible = true;
                                lbl_warning.Visible = false;
                            }
                        }


                    }



                    catch { }
                    conn.Close();

                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please add items to create requisition..!!');</script>");
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data insertion failed');</script>");
            }


        }

        protected bool RequiredFieldValidate()
        {
            if ((tb_items_withqty.Text == "") || (tb_items_withqty.Text == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "script", "window.close()", true);
        }

        public bool checkPlicyAmount(double req_amount, double policy_amount)
        {
            if (req_amount > policy_amount)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}