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
    public partial class Product_view : System.Web.UI.Page
    {
        connection_cls ob = new connection_cls();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string sale = "select * from Product_Table where Category_id='"+Session["id"]+"'";
                DataSet ds = ob.Fn_exeAdapter(sale);
                DataList1.DataSource = ds;
                DataList1.DataBind();

            }

        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["pid"] = id;
            Response.Redirect("view_single_page.aspx");
        }
    }
}