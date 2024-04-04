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
    public partial class edit_category : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                grid_bind();
            }

        }
        public void grid_bind()
        {
            string sale = "select * from Category_Table";
            DataSet ds = ob.Fn_exeAdapter(sale);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

       
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Panel1.Visible = true;
            Session["Id"] = Convert.ToInt32(e.CommandArgument);
            string s = "select * from Category_Table where Category_id='"+Session["Id"]+"'";
            SqlDataReader dr = ob.Fn_exeReader(s);
            while(dr.Read())
            {
                TextBox1.Text = dr["Category_name"].ToString();
                Image1.ImageUrl = dr["Category_image"].ToString();
                TextBox2.Text = dr["Category_description"].ToString();

            }
           


        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            Panel2.Visible = true;
            string n = "select * from Category_Table";
            SqlDataReader dr = ob.Fn_exeReader(n);
            while(dr.Read())
            {
                TextBox3.Text = dr["Status"].ToString();
            }
            int id2 = Convert.ToInt32(e.CommandArgument);
            Session["uid2"] = id2;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string u = "update Category_Table set Category_name='" + TextBox1.Text + "',Category_image='" + p + "',Category_description='" + TextBox2.Text + "'where Category_id=" + Session["Id"] + "";
            int upd1 = ob.Fn_NonqQuery(u);
            grid_bind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string D = "update Category_Table set Status='" + TextBox3.Text + "' where Category_id = "+Session["uid2"]+"";
            int upd2 = ob.Fn_NonqQuery(D);
            grid_bind();
        }

       
    }
}