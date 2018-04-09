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
public partial class Vender_viewfull_product : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();

    protected void Page_PreLoad(object sender, EventArgs e)
    { login(); }

    protected void Page_Load(object sender, EventArgs e)
    {
        string tbl1, str, get;
        string dsget = null;
        string tbl = null;
        string sid = null;
        if (Request.QueryString["pid"] != null)
        {
            string skpa = Request.QueryString["pid"].ToString();
            string[] ll = skpa.Split('D');
            for (int i = 0; ll.Length > i; i++)
            {
                if (tbl == null)
                {
                    tbl = ll[i] + "D";
                }
                else
                {
                    sid = ll[i].ToString();
                }
            }
        }
        con.Open();
        DataSet dsnew = new DataSet();
        SqlCommand cmd = new SqlCommand("select * from Products where Product_id='" + sid + "' and Prefix='" + tbl + "' and Vender_id='" + ssss + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lblpname.Text = dr["Product_Name"].ToString();
            lblsprice.Text = dr["Your_selling_price"].ToString();
            lblmrp.Text = dr["MRP"].ToString();
            lblweight.Text = dr["P_weight"].ToString();
            //lbldes.Text = dr["Description"].ToString();
            lblstock.Text = dr["Stocks"].ToString();
            lblgst.Text = dr["GST"].ToString();
            lblhsn.Text = dr["HSN"].ToString();
            lblliststatus.Text = dr["Listing_status"].ToString();
            lblprocurmenttype.Text = dr["Procurement_types"].ToString();
            mainimg.ImageUrl = "~/Product_IMG/" + dr["Image_1"].ToString();
            mainimg1.ImageUrl = "~/Product_IMG/" + dr["Image_2"].ToString();
            mainimg2.ImageUrl= "~/Product_IMG/" + dr["Image_3"].ToString();
            mainimg3.ImageUrl= "~/Product_IMG/" + dr["Image_4"].ToString();

            //mainimg.ImageUrl = "~/Product_IMG/" + dr["Image"].ToString();

            //string img1 = "~/Product_IMG/" + dsnew.Tables[0].Rows[0]["Image_ext"].ToString();
            //string[] imgg = img1.Split(',');
            //for (int n = 0; n < imgg.Length; n++)
            //{
            //    mainimg1.ImageUrl= "~/Product_IMG/" + imgg[n];
            //    mainimg2.ImageUrl = "~/Product_IMG/" + imgg[n];
            //    mainimg3.ImageUrl = "~/Product_IMG/" + imgg[n];
            //}

        }

    }
    public void login()
    {
        con.Open();

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
        con.Close();
    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vender/View_Product.aspx");
    }
}