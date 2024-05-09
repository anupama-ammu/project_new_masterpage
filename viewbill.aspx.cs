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
    public partial class viewbill : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select t1.*,t2.* from Product_table t1 join Order_table t2 on t1.Product_id=t2.Product_id where Order_status='unpayed' and User_id=" + Session["user_id"] + "";
            DataSet ds = ob.Fn_exeAdapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            string st = "select * from Bill_table where User_id=" + Session["user_id"] + " and Bill_Status='unpayed'";
            SqlDataReader dr = ob.Fn_exeReader(st);
            while (dr.Read())
            {
                Label2.Text = dr["Bill_id"].ToString();
                Label3.Text = dr["Bill_date"].ToString();
                Label6.Text = dr["Grand_total"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string st = "select Grand_total from Bill_table where User_id=" + Session["user_id"] + "";
            string t = ob.Fn_exeScalar(st);
            int gt = Convert.ToInt32(t);

            checkbalance.ServiceClient obj = new checkbalance.ServiceClient();
            string bal = obj.balancecheck(TextBox1.Text);

            int ba = Convert.ToInt32(bal);




            if (ba > gt)
            {

                string up = "select max(Order_id) from Order_table where User_id=" + Session["user_id"] + "";
                string c = ob.Fn_exeScalar(up);
                int count = Convert.ToInt32(c);
                if (count != 0)
                {
                    int pro_id = 0;
                    for (int w = 1; w <= count;w++)
                    {
                        int pro_qty = 0, cart_qty = 0, qty = 0;
                        string stup = "select Order_table.Product_id,Product_Table.Product_id,Order_table.Quantity,Product_Table.Product_stock from Product_Table join Order_table on Product_Table.Product_id=Order_table.Product_id where User_id=" + Session["user_id"] + "and Order_id=" + w + "";
                        SqlDataReader dr = ob.Fn_exeReader(stup);
                        while (dr.Read())
                        {
                            pro_qty = Convert.ToInt32(dr["Product_stock"]);
                            cart_qty = Convert.ToInt32(dr["Quantity"]);
                            pro_id = Convert.ToInt32(dr["Product_id"]);
                            break;
                        }
                        qty = pro_qty - cart_qty;
                        string stock = "update Product_Table set Product_stock =" + qty + " where Product_id=" + pro_id + "";
                        int stockup = ob.Fn_NonqQuery(stock);
                        if (qty == 0)
                        {
                            string no = "update Product_Table set Product_status='Unavailable' where Product_id=" + pro_id + "";
                            int ng = ob.Fn_NonqQuery(no);
                        }
                    }
                }


                string cup = "update Order_table set Order_status='payed' where  User_id=" + Session["user_id"] + "";
                int i = ob.Fn_NonqQuery(cup);

                string bup = "update Bill_table set Bill_Status='payed'  where  User_id=" + Session["user_id"] + "";
                int j = ob.Fn_NonqQuery(bup);

                string uac = "update Ac_table set Ac_balance=" + (ba - gt) + "  where  User_id=" + Session["user_id"] + "";
                int k = ob.Fn_NonqQuery(uac);

                Label7.Visible = true;
                Label7.Text = "payed";

            }
            else
            {
                Label7.Visible = true;
                Label7.Text = "Insufficient Balance";
            }

        }
    } 
}
