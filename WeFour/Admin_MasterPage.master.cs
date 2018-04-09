using Shreeman.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    string loginuser = string.Empty;
    SQLHelper objsql = new SQLHelper();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.Cookies["logincookie"] != null)
        {
            finduser();
        }
        else
        {
            Response.Redirect("~/index.aspx");

        }
        
    }
    public void finduser()
    {
        loginuser = Context.Request.Cookies["logincookie"].Value;

        SqlParameter[] lstparameter = new SqlParameter[2];
        lstparameter[0] = new SqlParameter { ParameterName = "@Action", Value = "FindUser" };
        lstparameter[1] = new SqlParameter { ParameterName = "@Email", Value = loginuser };
        DataSet dsfinduser = objsql.ExecuteQuery("UserLoginProcedure", CommandType.StoredProcedure, lstparameter);
        if (dsfinduser.Tables[0].Rows.Count > 0)
        {
            lbluser.Text = dsfinduser.Tables[0].Rows[0]["UserName"].ToString();
        }
        else
        {
            lbluser.Text = "UserName";
        }

    }


    protected void linklogout_ServerClick(object sender, EventArgs e)
    {
        Context.Response.Cookies["logincookie"].Expires = DateTime.Now.AddDays(-1);
        Session.Abandon();
        Response.Redirect("~/index.aspx");
    }
}
