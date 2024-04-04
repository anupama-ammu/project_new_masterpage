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
    public partial class add_product : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string bc = "select Category_name,Category_id from Category_Table";
                DataSet ds = ob.Fn_exeAdapter(bc);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Category_name";
                DropDownList1.DataValueField = "Category_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "-select-");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string v = "~/photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(v));
            string g = "insert into Product_Table values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + v + "','" + TextBox2.Text + "'," + TextBox3.Text + "," + TextBox4.Text + ",'available')";
            int c = ob.Fn_NonqQuery(g);
            if(c==1)
            {
                Label7.Visible = true;
                Label7.Text = "success";
            }
        }
    }
}