using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12
{
    public partial class frm_delivery : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=procurement;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bindData();

                //when page loading it should be hidden unwanted columns
                foreach (GridViewRow GridViewRow in dtg_dataGrid.Rows)
                {
                    GridViewRow.Cells[3].Visible = false;
                    GridViewRow.Cells[4].Visible = false;
                    GridViewRow.Cells[5].Visible = false;
                    GridViewRow.Cells[6].Visible = false;
                    GridViewRow.Cells[7].Visible = false;
                }
            }
        }

        protected void bindData()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from delivery", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dtg_dataGrid.DataSource = ds;
                dtg_dataGrid.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dtg_dataGrid.DataSource = ds;
                dtg_dataGrid.DataBind();
                int columncount = dtg_dataGrid.Rows[0].Cells.Count;
                dtg_dataGrid.Rows[0].Cells.Clear();
                dtg_dataGrid.Rows[0].Cells.Add(new TableCell());
                dtg_dataGrid.Rows[0].Cells[0].ColumnSpan = columncount;
                dtg_dataGrid.Rows[0].Cells[0].Text = "No Records Found";
            }
        }

        protected void imb_delivery_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                ImageButton btn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                btn.ImageUrl = "/Resources/images/delivery.png";

                int id = int.Parse(row.Cells[0].Text);

                con.Open();
                MySqlCommand cmd = new MySqlCommand("update delivery set delivery_status='" + DateTime.Now.ToString() + "' where orderID=" + id, con);
                cmd.ExecuteNonQuery();
                con.Close();
                row.Cells[2].Enabled = false;
                row.Cells[3].Visible = true;
            }
        }

        protected void imb_okay_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                ImageButton btn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                row.Cells[5].Visible = false;
                row.Cells[6].Visible = false;
                int id = int.Parse(row.Cells[0].Text);

                con.Open();
                MySqlCommand cmd = new MySqlCommand("update delivery set quality_status='" + "Good Quality" + "' where orderID=" + id, con);
                cmd.ExecuteNonQuery();
                con.Close();
                row.Cells[3].Enabled = false;
                row.Cells[4].Visible = true;

                row.Cells[7].Visible = true;
            }
        }

        protected void imb_notOkay_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                ImageButton btn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                row.Cells[4].Visible = false;
                row.Cells[7].Visible = false;

                int id = int.Parse(row.Cells[0].Text);

                con.Open();
                MySqlCommand cmd = new MySqlCommand("update delivery set quality_status='" + "Bad Quality" + "' where orderID=" + id, con);
                cmd.ExecuteNonQuery();
                con.Close();

                row.Cells[3].Enabled = false;
                row.Cells[5].Visible = true;
                row.Cells[6].Visible = true;
            }
        }

        protected void imb_enquery_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string orderID = row.Cells[0].Text;

            Response.Redirect(string.Format("frm_enquery.aspx?par_orderID={0}", orderID));
        }

        protected void imb_save_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string orderID = row.Cells[0].Text;

            Response.Redirect(string.Format("frm_deliveryInfo.aspx?par_orderID={0}", orderID));
        }

    }
}