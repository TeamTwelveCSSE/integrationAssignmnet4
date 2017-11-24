using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Team12
{
    public partial class frm_deliveryInfo : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=procurement;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["par_orderID"] != null)
            {
                string orderID = Request.QueryString["par_orderID"];
                int order = int.Parse(orderID);

                con.Open();
                MySqlCommand cmd = new MySqlCommand("select deliveryID,supplier,delivery_status,quality_status from delivery where orderID=" + order, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txt_deliveryID.Text = dt.Rows[0][0].ToString();
                txt_orderID.Text = orderID;
                txt_supplier.Text = dt.Rows[0][1].ToString();
                txt_deliveryStatus.Text = dt.Rows[0][2].ToString();
                txt_qualityStatus.Text = dt.Rows[0][3].ToString();
                con.Close();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into procurement.delivery_save(deliveryID,orderID,supplier,delivery_status,quality_status) values('" + txt_deliveryID.Text + "','"
                + txt_orderID.Text + "','" + txt_supplier.Text + "','" + txt_deliveryStatus.Text + "','" + txt_qualityStatus.Text + "')";
            cmd.ExecuteNonQuery();

            MySqlCommand cmdx = new MySqlCommand("delete from delivery where deliveryID=" + txt_deliveryID.Text, con);
            cmdx.ExecuteNonQuery();

            con.Close();
            Response.Redirect("~/frm_deliveryOrderDetails.aspx");
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm_delivery.aspx");
        }
    }
}