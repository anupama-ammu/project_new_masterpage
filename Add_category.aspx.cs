using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_new_masterpage
{
    public partial class Add_category : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/photos" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            string str = "insert into Category_Table values('" + TextBox1.Text + "','" + s + "','" + TextBox2.Text + "','available')";
            int i = ob.Fn_NonqQuery(str);
            if(i==1)
            {
                Label4.Text = "success";
            }

        }
    }
}