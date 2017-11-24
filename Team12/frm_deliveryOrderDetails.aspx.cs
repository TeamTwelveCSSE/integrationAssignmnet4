using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team12
{
    public partial class frm_deliveryOderDetails : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=procurement;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bindData();
            }
        }

        public int bindData()
        {
            int count = 0;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from delivery_save", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dtg_dataGrid.DataSource = ds;
                dtg_dataGrid.DataBind();
                count =1;
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
                count = -1;
            }
            return count;
        }
    }
}