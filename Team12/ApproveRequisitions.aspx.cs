using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Team12
{
    public partial class ApproveRequisitions : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // MySql.Data.MySqlClient.MySqlCommand cmd;
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();
                queryStr = "select distinct name,ass_eid from assigned_employee group by name";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "ass_eid";
                DropDownList1.DataBind();

                

            }
        }

        protected void ConDataBind()
        {
            using (MySqlConnection con = new MySqlConnection(ConnString))
            {
                string eid = Convert.ToString(DropDownList1.SelectedValue);
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM requisition Where eid = '" +eid+ "' and status = 'pending' "))
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
                                //bind the data source
                            }
                            //count is 0 -> No recordsfound
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ConDataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Response.Redirect("AcceptOrDeny.aspx?val=" + GridView1.SelectedRow.Cells[1].Text);
            string val,val2,val3,val4,val5;
            val = GridView1.SelectedRow.Cells[1].Text;
            val2= GridView1.SelectedRow.Cells[3].Text;
            val3 = GridView1.SelectedRow.Cells[4].Text;
            val4 = GridView1.SelectedRow.Cells[6].Text;
            val5 = Convert.ToString(DropDownList1.SelectedItem);

            Response.Redirect(String.Format("AcceptOrDeny.aspx?val={0}&val2={1}&val3={2}&val4={3}&val5={4}", val, val2,val3,val4,val5));

            //hidden_txtOrderId.Text = GridView1.SelectedRow.Cells[1].Text;
            //txtOrderId.Text = GridView1.SelectedRow.Cells[1].Text;
            //DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
            //txtOrderName.Text = GridView1.SelectedRow.Cells[3].Text;
            //txtQtyOrder.Text = GridView1.SelectedRow.Cells[4].Text;
            //txtOrderDate.Text = GridView1.SelectedRow.Cells[5].Text;
        }
    }
}