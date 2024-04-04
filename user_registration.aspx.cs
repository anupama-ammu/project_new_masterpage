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
    public partial class WebForm1 : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string d = "select * from State_table";
                DataSet ds = ob.Fn_exeAdapter(d);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "State_Name";
                DropDownList1.DataValueField = "State_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--select--");
            }


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
            string ins = "insert into User_table values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','"+TextBox3.Text+"','"+TextBox4.Text+"','"+TextBox5.Text+ "','" + DropDownList1.SelectedItem.Value + "','" + DropDownList2.SelectedItem.Value + "','" + TextBox8.Text + "','active')";
            int i = ob.Fn_NonqQuery(ins);
            if (i != 0)
            {
                string inslog = "insert into Login_table values('"+TextBox1+"','"+TextBox2+ "','user','active'," + Reg_id + ")";
                Label10.Text = "inserted";
            }

        }
        protected void DropDownList1_TextChanged1(object sender, EventArgs e)
        {
            string s = "select * from  Dist_table where State_id=" + DropDownList1.SelectedItem.Value + "";
            DataSet ds1 = ob.Fn_exeAdapter(s);
            DropDownList2.DataSource = ds1;
            DropDownList2.DataTextField = "Dist_Name";
            DropDownList2.DataValueField = "Dist_id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--select--");

        }
    }
}