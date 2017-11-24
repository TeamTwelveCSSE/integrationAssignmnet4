using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;

namespace Team12
{
    public partial class frm_enquery : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=procurement;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["par_orderID"] != null)
            {
                string orderID = Request.QueryString["par_orderID"];
                int order = int.Parse(orderID);

                con.Open();
                MySqlCommand cmd = new MySqlCommand("select deliveryID,supplier,suppllier_email,delivery_status,quality_status from delivery where orderID=" +
                    order, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txt_deliveryID.Text = dt.Rows[0][0].ToString();
                txt_orderID.Text = orderID;
                txt_supplier.Text = dt.Rows[0][1].ToString();
                txt_email.Text = dt.Rows[0][2].ToString();
                txt_deliveryStatus.Text = dt.Rows[0][3].ToString();
                txt_qualityStatus.Text = dt.Rows[0][4].ToString();
                con.Close();

                txt_enqueryID.Text = generateID();
            }
        }

        public string generateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            SendMail("thanuji.shashikala@gmail.com", txt_email.Text);
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into procurement.delivery_save(deliveryID,orderID,supplier,delivery_status,quality_status,enqueryID,enquery_type,enquery_desc) values('"
                + txt_deliveryID.Text + "','" + txt_orderID.Text + "','" + txt_supplier.Text + "','" + txt_deliveryStatus.Text + "','" + txt_qualityStatus.Text +
                "','" + txt_enqueryID.Text + "','" + ddl_enqueryType.SelectedValue + "','" + txt_description.Text + "')";
            cmd.ExecuteNonQuery();

            MySqlCommand cmdx = new MySqlCommand("delete from delivery where deliveryID=" + txt_deliveryID.Text, con);
            cmdx.ExecuteNonQuery();

            con.Close();

            Response.Redirect("~/frm_deliveryOrderDetails.aspx");
        }

        public string SendMail(string sender, string receiver)
        {
            string message = string.Empty;
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(sender, "11dec@1993");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("thanuji.shashikala@gmail.com");
            msg.To.Add(new MailAddress(receiver));

            msg.Subject = "Enquery for your supply";
            msg.IsBodyHtml = true;
            msg.Body = "Order ID : " + txt_orderID.Text + "<br/> Delivery ID : " + txt_deliveryID.Text + "<br/> Delivery date and time : " + txt_deliveryStatus.Text +
                "<br/>Enquery Type : " + ddl_enqueryType.SelectedValue + " <br/> Description : " + txt_description.Text;

            try
            {
                client.Send(msg);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = "Unsuccessful";
            }
            return message;
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frm_delivery.aspx");
        }
    }
}