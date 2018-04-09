using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Shreeman.Models;


public partial class Vender_Login : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Request.Cookies["logincookie"] != null)
        {
            Response.Redirect("~/Home.aspx");
        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlParameter[] lstparameter = new SqlParameter[3];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "Login" };
        lstparameter[1] = new SqlParameter { ParameterName = "@Email", Value = txtemail.Text };
        lstparameter[2] = new SqlParameter { ParameterName = "@Password", Value = txtpwd.Text};
        DataSet dslogin = objsql.ExecuteQuery("UserLoginProcedure", CommandType.StoredProcedure,lstparameter);
        if (dslogin.Tables[0].Rows.Count > 0)
        {

            HttpCookie cookie = new HttpCookie("logincookie");
            cookie.Value = txtemail.Text;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Home.aspx");

        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
            "<script type='text/javascript'>alert('Login Fail, Please Provide true data.');</script>");
        }

    }
}