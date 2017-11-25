using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;

namespace Team12
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader, dr;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {

                DateTime now = DateTime.Now;

                conn.Open();
                queryStr = "insert into purchaseorder ( reqId,requestDate,approveBy,requireDate,status) values ('" + txtReqId.Text + "','" + txtReqDate.Text + "','" + txtapprove.Text + "','" + txtOrderDate.Text + "','pending')";
                //qry = "UPDATE requisition SET status='deny' WHERE reqid='" + txtReqId.Text + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                //cmd1 = new MySql.Data.MySqlClient.MySqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Created Purchase Order!  ');</script>");

            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Purchase Order failed');window.location ='ViewPurchaseOrders.aspx'</script>");
            }

            conn.Close();
            //Response.Redirect("PendingRequisitions.aspx");
            Button2.Visible = true;
            Button1.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            //Sending mails to suppliers using default email address
            
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("ashi9422@gmail.com", "0711997398");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("ashi9422@gmail.com");
            msg.To.Add(new MailAddress(hidden_mail.Text.ToString()));

            msg.Subject = "Purchase Order Details";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<body><table align='center' border='1' cellpadding='0' cellspacing='0' width='600'><tr><td align='center' bgcolor='#808080' style='padding: 40px 0 30px 0;'><table border='1' cellpadding='0' cellspacing='0' width='80%' style='background-color:white; font-family:Calibri' id='t1'><tr><td style='text-align:center; font-size:22px'>Hi</td></tr><tr><td style='padding: 10px 0 0px 0;'>&emsp;Issued :  <p style='font-weight:bolder'>&emsp;</p><p style='color:green; font-weight:bolder;text-align:center;font-size:30px'>&emsp;Purchase order Details</p></td></tr><tr><td style='font-weight:bolder;'><u> <p style='font-size:40px; text-align:center'>Order Details</p></u><br/><br/>&emsp;Order Date : " + txtOrderDate.Text + "<br />&emsp;Request Date : " + txtReqDate.Text + "<p style='font-size:20px'>&emsp;Approved By&emsp;&emsp;&emsp;&emsp;" + txtapprove.Text + "</p>&emsp;&emsp;&emsp;Item Name &emsp;&emsp;&emsp; &nbsp;  &nbsp;" + txtItemName.Text + "  <br />&emsp;&emsp;&emsp;Quantity  &emsp;&emsp;&emsp;  " + txtQuntity.Text + "<br />&emsp;&emsp;&emsp;Unit Of Measure  &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp; &nbsp;    " + txtumo.Text + "      <br /><br /> <br /> <br /></td></tr></table></td></tr><tr></tr></table></body>");

            try
            {
                client.Send(msg);
                lbl_emailValidation.Text = " Purchase order has been successfully sent.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Purchase ordere has been successfully sent  ');window.location ='ViewPurchaseOrders.aspx'</script>");
                lbl_emailValidation.Enabled = true;
            }
            catch (Exception ex)
            {
                lbl_emailValidation.ForeColor = System.Drawing.Color.Red;
                lbl_emailValidation.Text = "Error occured while sending your message." + ex.Message;
                lbl_emailValidation.Enabled = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;
            DateTime dNow = DateTime.Now;

            
            TextBox1.Text = (dNow.ToString("MM/dd/yyyy"));
            

            txtReqId.Text = Request.QueryString["val"];
            txtReqDate.Text = Request.QueryString["val2"];
            txtapprove.Text = Request.QueryString["val5"];

            if (!this.IsPostBack)
            {
                // MySql.Data.MySqlClient.MySqlCommand cmd;
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();

                string query = "SELECT item_name,itemid FROM procurement.item where reqid ='" + txtReqId.Text + "' ";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                ListBox1.DataSource = cmd.ExecuteReader();
                ListBox1.DataTextField = "item_name";
                ListBox1.DataValueField = "itemid";
                ListBox1.DataBind();


                conn.Close();
            }

        }
    
    }
}