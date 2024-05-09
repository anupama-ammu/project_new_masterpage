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
    public partial class Product_view1 : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "select * from Product_Table where Product_id=" + Session["pid"] + "";
            SqlDataReader dr = ob.Fn_exeReader(s);
            while(dr.Read())
            {
                Label1.Text = dr["Product_name"].ToString();
                Label2.Text = dr["Product_price"].ToString();
                Label3.Text = dr["Product_description"].ToString();
                Image1.ImageUrl = dr["Product_image"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(Cart_id) from Cart_Table";
            string cartid = ob.Fn_exeScalar(s);
            int Cart_id = 0;
            if(cartid=="")
            {
                Cart_id = 1;
            }
            else
            {
                int newcartid = Convert.ToInt32(cartid);
                Cart_id = newcartid + 1;
            }
            string m = "select Product_price from  Product_Table where Product_id= " + Session["pid"] + "";
            string price = ob.Fn_exeScalar(m);

            int g = Convert.ToInt32(TextBox1.Text);
            int p = Convert.ToInt32(price);
            int tp = g * p;

            string ins = "insert into Cart_Table values(" + Cart_id + "," + Session["pid"] + "," + Session["user_id"] + ",'" + TextBox1.Text + "'," + tp + ",'available')";
            int i = ob.Fn_NonqQuery(ins);
            if(i==1)
            {
                //Label4.Visible = true;
                //Label4.Text = "Add to cart";
                Response.Redirect("view_cart.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_home.aspx");
        }
    }
}