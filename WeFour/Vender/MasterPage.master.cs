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

public partial class MasterPage : System.Web.UI.MasterPage
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            string ssss = null;
            if (Context.Request.Cookies["inf"] != null)
            {
                string skp = Request.Cookies["inf"].Value;
                string mp = null;
                if (skp != null)
                {
                    string[] sdss = skp.Split('$');
                    for (int k = 0; k < sdss.Length; k++)
                    {
                        if (mp == null)
                        {
                            mp = sdss[k];
                        }
                    }
                }
                ssss = Encoding.UTF32.GetString(Convert.FromBase64String(mp));
            }
            SqlCommand cmd = new SqlCommand("select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='A1'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lbluser.Text = dr["username"].ToString();
                dr.Close();
            }
            else
            {
                Response.Redirect("~/Seller/SellerHome.aspx");
            }

            con.Close();
        }
        catch(Exception ex)
        {
            //Response.Redirect("~/Vender/PageNotFound.aspx");
        }
        
    }
}

