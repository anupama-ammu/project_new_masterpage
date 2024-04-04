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
    public partial class Admin_registration : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_id) from Login_table";
            string regid = ob.Fn_exeScalar(sel);
            int Reg_id = 0;
            if (regid == "")
            {
                Reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                Reg_id = newregid + 1;
            }
            string ins = "insert into Admin_table values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ")";
            int i = ob.Fn_NonqQuery(ins);
            if (i != 0)
            {
                string inslog = "insert into login_table values(" + Reg_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin','active')";
                int n = ob.Fn_NonqQuery(inslog);
            }
        }
    }
}