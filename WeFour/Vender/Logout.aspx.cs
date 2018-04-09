using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Logout : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.Cookies["inf"] != null)
            {
                Response.Cookies["inf"].Expires = DateTime.Now;
                Response.Redirect("~/Vender/Login.aspx", true);
            }
        }
    }
}