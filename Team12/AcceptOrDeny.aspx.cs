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
    public partial class AcceptOrDeny : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd,cmd1;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr, qry;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

        protected void Button1_Click(object sender, EventArgs e)
        {
            string val, val2, val3, val4, val5;
            val = txtReqId.Text;
            val2 = txtReqDate.Text;
            val3 = txtPriority.Text;
            val4 = txtStatus.Text;
            val5 = txtapprove.Text;

            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {

                DateTime now = DateTime.Now;

                conn.Open();
                //queryStr = "insert into deny (reqId,reqDate,denyDate,denyBy) values ('" + txtReqId.Text + "','" + txtReqDate.Text + "','" + now + "','" + txtapprove.Text + "')";
                qry = "UPDATE requisition SET status='accepted' WHERE reqid='" + txtReqId.Text + "'";
                //cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(qry, conn);
                //cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Accept Requisition.!  ');</script>");

            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Deny Requisition failed');'</script>");
            }

            conn.Close();
            //Response.Redirect("PendingRequisitions.aspx");


            Response.Redirect(String.Format("PurchaseOrder.aspx?val={0}&val2={1}&val3={2}&val4={3}&val5={4}", val, val2, val3, val4, val5));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtReqId.Text = Request.QueryString["val"];
            txtReqDate.Text = Request.QueryString["val2"];
            txtPriority.Text = Request.QueryString["val3"];
            txtStatus.Text = Request.QueryString["val4"];
            txtapprove.Text= Request.QueryString["val5"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {

                DateTime now = DateTime.Now;

                conn.Open();
                    queryStr = "insert into deny (reqId,reqDate,denyDate,denyBy) values ('" + txtReqId.Text + "','" + txtReqDate.Text + "','" + now + "','" + txtapprove.Text + "')";
                    qry = "UPDATE requisition SET status='deny' WHERE reqid='"+txtReqId.Text+"'";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                    cmd1= new MySql.Data.MySqlClient.MySqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Deny Requisition.!  ');window.location ='DenyRequisitions.aspx';</script>");

            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Deny Requisition failed');window.location ='DenyRequisitions.aspx'</script>");
            }

            conn.Close();
            //Response.Redirect("PendingRequisitions.aspx");

        }
    }
}