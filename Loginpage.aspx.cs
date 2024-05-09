using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
   
namespace project_new_masterpage
{
    public partial class Loginpage : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_id) from Login_table where User_name='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = ob.Fn_exeScalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Reg_id from Login_table where User_name='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string regid = ob.Fn_exeScalar(str1);
                Session["user_id"] = regid;
                string str2 = "select Logintype from Login_table where User_name='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string Logintype = ob.Fn_exeScalar(str2);
                if (Logintype == "admin")
                {
                    Label4.Text = "Admin";
                    Response.Redirect("Admin_home.aspx");


                }
                else if (Logintype == "user")
                {
                    Label4.Text = "User";
                    Response.Redirect("User_home.aspx");
                }
            }

        }
    }
}