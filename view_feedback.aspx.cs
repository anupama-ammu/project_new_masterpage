using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;


namespace project_new_masterpage
{
    public partial class view_feedback : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid_bind();
            }
        }


        public void Grid_bind()
        {
            string sel = "select * from Fb_table where fb_status='  pending  '";
            DataSet ds = ob.Fn_exeAdapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            
                int id = Convert.ToInt32(e.CommandArgument);
                string se = "select * from Fb_table where fb_id=" + id + "";
                string sele = ob.Fn_exeScalar(se);
                Session["id"] = id;
                string sel = "select User_table.User_name,User_table.User_email,Fb_table.Replay from Fb_table join User_table on Fb_table.User_id=User_table.User_id";
                SqlDataReader dr = ob.Fn_exeReader(sel);
                while (dr.Read())
                {
                    Label2.Text = dr["User_name"].ToString();
                    Label7.Text = dr["User_email"].ToString();
                }
                Panel1.Visible = true;
                
            

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        
        
            string up = "update Fb_table set Replay='" + TextBox1.Text + "' where fb_id=" + Session["id"] + "";
            int upd = ob.Fn_NonqQuery(up);
            if (upd != 0)
            {
                string st = "update Fb_table set fb_status='  pending  ' where fb_id=" + Session["id"] + "";
                int sta = ob.Fn_NonqQuery(st);
            }
            Grid_bind();
            SendEmail2("project_new_masterpage", "anu348185@gmail.com", "fsmq bgoi qkrc yisz", Label2.Text, Label7.Text, "Replay", TextBox1.Text);
        }




        public static void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)
        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        
    }
}
