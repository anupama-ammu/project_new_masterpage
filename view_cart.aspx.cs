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
    public partial class view_cart : System.Web.UI.Page
    {

        connection_cls ob = new connection_cls();
        int cid;
        int cqu;
        int cto;
        string cst;
        int pid;
        int uid;
        int gt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                grid_view();
            }

        }
        public void grid_view()
        {
            string y = "select t1.*,t2.* from Product_Table t1 join Cart_Table t2 on t2.Product_id=t1.Product_id where User_id=" + Session["user_id"] + "";
            DataSet ds = ob.Fn_exeAdapter(y);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Panel1.Visible = true;
            Session["cartid"] = Convert.ToInt32(e.CommandArgument);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string t = "select t2.Product_price from Product_Table t2 join Cart_Table t1 on t1.Product_id=t2.Product_id where t1.Cart_id='" + Session["cartid"] + "'";
            string f = ob.Fn_exeScalar(t);
            int q = Convert.ToInt32(TextBox1.Text);
            int h = Convert.ToInt32(f);
            int total_price = q * h;
            string r = "update Cart_Table set Quantity='" + TextBox1.Text + "',Total_price='" + total_price + "' where Cart_id='" + Session["cartid"] + "'";
            int i = ob.Fn_NonqQuery(r);
            if(i==1)
            {
                grid_view();
                Label2.Visible = true;
                Label2.Text = "success";
            }


        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string del = "delete from Cart_Table where  Cart_id='" + Session["cartid"] + "'";
            int i = ob.Fn_NonqQuery(del);
            if(i==1)
            {
                grid_view();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string xm = "select max(Cart_id) from Cart_Table ";
            string m = ob.Fn_exeScalar(xm);
            int max = Convert.ToInt32(m);

            for(int i=1;i<=max;i++)
            {
                string uidn = "select User_id from Cart_Table where Cart_id=" + i + "";
                string st = ob.Fn_exeScalar(uidn);
                int q = Convert.ToInt32(st);
                int ids = Convert.ToInt32(Session["user_id"]);
                if(q==ids)
                {
                    string cat= "select * from Cart_Table where Cart_id="+i+"";
                    SqlDataReader dr = ob.Fn_exeReader(cat);

                    while(dr.Read())
                    {
                        cid = Convert.ToInt32(dr["Cart_id"].ToString());
                        cqu = Convert.ToInt32(dr["Quantity"].ToString());
                        cto = Convert.ToInt32(dr["Total_price"].ToString());
                        cst = dr["Status"].ToString();
                        pid = Convert.ToInt32(dr["Product_id"].ToString());
                        uid = Convert.ToInt32(dr["User_id"].ToString());

                    }
                    gt = gt + cto;
                    string ins = "insert into Order_table values(" + cid + "," + pid + "," + uid + ",'unpayed'," + cqu + "," + cto + ")";
                    int j = ob.Fn_NonqQuery(ins);

                    

                }
                
            }
            string bin = "insert into Bill_table values('" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + uid + "," + gt + ",'unpayed')";
            int k = ob.Fn_NonqQuery(bin);

            if(k!=0)
            {
                //string del = "delete from Cart_Table where User_id=" + Session["user_id"] + "";
               // int l = ob.Fn_NonqQuery(del);
            }
            Response.Redirect("viewbill.aspx");
        }
    }
}