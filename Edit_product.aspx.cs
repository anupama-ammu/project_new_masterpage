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
    public partial class Edit_product:System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();

        protected void page_load(object sender,EventArgs e)
        {
            if(!IsPostBack)
            {
                grid_bind();
            }
        }
        public void grid_bind()
        {
            string sale = "select * from Product_Table";
            DataSet ds = ob.Fn_exeAdapter(sale);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }
        protected void LinkButton1_Command1(object sender, CommandEventArgs e)
        {
            Panel1.Visible = true;
            Session["Id"] = Convert.ToInt32(e.CommandArgument);
            string s = "select * from Product_Table where Product_id='" + Session["Id"] + "'";
            SqlDataReader dr = ob.Fn_exeReader(s);
            while (dr.Read())
            {
                TextBox1.Text = dr["Product_name"].ToString();
                Image1.ImageUrl = dr["Product_image"].ToString();
                TextBox2.Text = dr["Product_description"].ToString();
                TextBox3.Text = dr["Product_price"].ToString();
                TextBox4.Text = dr["Product_stock"].ToString();

            }





        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string p = "/~photos" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string m = "update Product_Table set Product_name='" + TextBox1.Text + "',Product_image='" + p + "',Product_description='" + TextBox2.Text + "' where Product_id=" + Session["Id"] + "";
            int upd1 = ob.Fn_NonqQuery(m);
            grid_bind();
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            Panel3.Visible = true;
            string n = "select * from Product_Table";
            SqlDataReader dr = ob.Fn_exeReader(n);
            while (dr.Read())
            {
                TextBox5.Text = dr["Product_status"].ToString();
            }
            int id2 = Convert.ToInt32(e.CommandArgument);
            Session["uid2"] = id2;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string D = "update Product_Table set Product_status='" + TextBox5.Text + "' where Product_id = " + Session["uid2"] + "";
            int upd2 = ob.Fn_NonqQuery(D);
            grid_bind();
        }

      


        
    }
}