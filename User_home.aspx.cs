﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace project_new_masterpage
{
    public partial class User_home : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string sale1 = "select * from Category_Table";
                DataSet ds = ob.Fn_exeAdapter(sale1);
                DataList2.DataSource = ds;
                DataList2.DataBind();

            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["id"] = id;
            Response.Redirect("view_product.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "insert into Fb_table values(" + Session["user_id"] + ",'" + TextBox1.Text + "','  waiting  ','  pending  ')";
            int r = ob.Fn_NonqQuery(ins);
            if (r == 1)
            {
                Label4.Visible = true;
                Label4.Text = "success";

            }
        }
    }
}