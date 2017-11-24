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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Team12
{
    public partial class Add_Requisition : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlCommand cmdd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        String req_date;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            getPaymentDate();
            if (!this.IsPostBack)
            {
                getPaymentDate();
                req_date = tb_reqdate.Text;
                tb_reqdate.Attributes["disabled"] = "disabled";
                tb_reqid.Attributes["disabled"] = "disabled";
                try
                {
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM employee";

                    DataTable dt = new DataTable();

                    dt.Load(cmd.ExecuteReader());
                    conn.Close();

                    if (dt.Rows.Count == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No employees in the table ');</script>");
                    }

                    else
                    {
                        list_createdby.DataSource = dt;
                        list_createdby.DataTextField = "name";
                        //list_createdby.DataValueField = "eid";
                        list_createdby.DataBind();
                    }


                }

                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No employees in the table ');</script>");
                }

            }
            getID();
        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'AddItems.aspx?x=" + ReqIDToSend + "', null, 'height=500,width=900,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            tb_addedItems.Visible = true;
            btn_addedItems.Visible = true;
        }

        protected void Unnamed2_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'AssignedEmployee.aspx?x=" + ReqIDToSend + "', null, 'height=500,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            tb_assignedto.Visible = true;
            btn_show.Visible = true;
        }
        String ReqIDToSend;
        public void getID()
        {
            //get the requisition ID incrementing it by 1
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM requisition ORDER BY reqid DESC LIMIT 1 ";

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("reqid");
                    idd = idd + 1;
                    tb_reqid.Text = idd + "";
                    ReqIDToSend = tb_reqid.Text;

                }
            }
            catch { }
            conn.Close();
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM assigned_employee where reqid='" + tb_reqid.Text + "'";

                reader = cmd.ExecuteReader();
                //int x =reader.ro;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('COUNT IS '+'"+x+"');</script>");
                //("COUNT IS " + x);

                //DataTable dt = new DataTable();
                //dt.Load(reader);
                //int numberOfResults = dt.Rows.Count;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('COUNT IS '+'" + numberOfResults + "');</script>");
                //for (int z=0; z< numberOfResults; z++)
                //{
                while (reader.Read())
                {
                    tb_assignedto.Text = tb_assignedto.Text + reader.GetString("name") + "\n";
                }
                //}


            }
            catch { }
            conn.Close();


        }

        protected void btn_addedItems_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM item where reqid='" + tb_reqid.Text + "'";

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tb_addedItems.Text = tb_addedItems.Text + (reader.GetString("item_name") + " - " + reader.GetString("quantity")) + " \n";
                }
            }



            catch { }
            conn.Close();
            checkApprovalNeeded();


        }

        public void checkApprovalNeeded()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            double count = 0;
            double item_price;
            double qty;
            double policy_amount;
            //try
            //{
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM item where reqid='" + tb_reqid.Text + "' ";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                item_price = reader.GetDouble("item_price");
                qty = reader.GetDouble("quantity");
                count = count + (item_price * qty);
            }

            conn.Close();

            conn.Open();
            cmdd = conn.CreateCommand();
            cmdd.CommandText = "SELECT * FROM policy where policy_name='Requisition Approval'";

            reader1 = cmdd.ExecuteReader();
            if (reader1.Read())
            {
                policy_amount = reader1.GetDouble("amount");

                if (count < policy_amount)
                {
                    imgbtn_assignedto.Enabled = false;
                    System.Diagnostics.Debug.WriteLine(count);
                    System.Diagnostics.Debug.WriteLine("Hellooo");
                }
            }
            conn.Close();
            //}

            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Fisrt add the items');</script>");
            //}
        }

        protected void btn_addreq_Click(object sender, EventArgs e)
        {
            hidden_reddate.Text = tb_reqdate.Text;


            bool result = validateAllFields();
            if (result)
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();
                queryStr = "insert into requisition (reqid,created_by,req_date,state,priority,remarks,status) values ('" + Convert.ToInt32(tb_reqid.Text) + "','" + Convert.ToString(list_createdby.SelectedValue) + "','" + Convert.ToString(req_date) + "','" + Convert.ToString(lst_state.SelectedValue) + "','" + Convert.ToString(list_priority.SelectedValue) + "','" + Convert.ToString(Request.Form["TextArea1"]) + "','Pending')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted  ');</script>");
            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please fill all the required fields');</script>");
            }
        }

        protected void btn_printreq_Click(object sender, EventArgs e)
        {

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<body><table align='center' border='1' cellpadding='0' cellspacing='0' width='600'><tr><td align='center' bgcolor='#808080' style='padding: 0px 0 30px 0;'><table border='1' cellpadding='0' cellspacing='0' width='80%' style='background-color:white; font-family:Calibri' align='center' id='t1'><tr><td style='text-align:center; font-size:22px'>Requisition " + tb_reqid.Text + "</td></tr><tr><td style='padding: 10px 0 0px 0;'>&emsp;Issued : " + getPaymentDate() + " <p style='font-weight:bolder'>&emsp; </p><p style='color:green; font-weight:bolder;text-align:center;font-size:30px'>&emsp;Your requisition is successfull !!!</p></td></tr><tr><td style='font-weight:bolder;'><u> <p style='font-size:40px; text-align:center'>Requisition Summary</p></u><br/><br/>&emsp;Created By : " + list_createdby.SelectedValue + "<br />&emsp;Priority : " + list_priority.SelectedValue + "<p style='font-size:16px'>&emsp;State : &emsp;&emsp;&emsp;&emsp;" + lst_state.SelectedValue + "</p>&emsp;&emsp;&emsp;<br /><br /> <br /> <br /></td></tr></table></td></tr><tr></tr></table></body>");

                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.LEGAL_LANDSCAPE);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Requisition_Note_" + tb_reqid.Text + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        protected void btn_calcelreq_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Requisition.aspx");
        }

        public bool validateAllFields()
        {
            if (tb_reqid.Text == "" || req_date == "" || TextArea1.Text == "")
            {
                System.Diagnostics.Debug.WriteLine(tb_reqid.Text);
                System.Diagnostics.Debug.WriteLine(tb_reqdate.Text);
                System.Diagnostics.Debug.WriteLine(Request.Form["TextArea1"]);
                return false;
            }

            else
            {
                return true;
            }
        }

        public String getPaymentDate()
        {
            //payment date means current date
            // DateTime today = DateTime.Today;
            tb_reqdate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            return DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}