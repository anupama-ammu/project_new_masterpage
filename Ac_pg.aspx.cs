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
    public partial class Ac_pg : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string r = "insert into Ac_table values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + Session["user_id"] + "','" + TextBox3.Text + "')";
            int i = ob.Fn_NonqQuery(r);

        }
    }
}