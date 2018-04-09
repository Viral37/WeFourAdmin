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


public partial class Vender_Login : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    CRUD objcrud = new CRUD();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    

    protected void btnlogin_Click(object sender, EventArgs e)
    {

        string sna = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtpwd.Text));
        string selectsk = "select * from tbl_login where status='Active' and email_id='" + txtemail.Text + "' and password='" + sna + "' and Vender='0'";
        SqlDataReader drs = objcrud.datareader(selectsk);
        if (drs.Read())
        {
            string sn = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtemail.Text));
            HttpCookie ckid = new HttpCookie("inf");
            ckid.Value = sn + "$" + sna;
            ckid.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(ckid);
            //Response.Redirect("~/Seller/Register_Seller.aspx");
        }
        else
        {
            string selectv = "select * from tbl_login where status='Active' and email_id='" + txtemail.Text + "' and password='" + sna + "' and Vender='1'";
            SqlDataReader drv = objcrud.datareader(selectv);
            if (drv.Read())
            {
                Response.Write("<script>alert('Please check your mail and activate ID.');</script>");
                drv.Close();
            }
            else
            {
                string selectva = "select * from tbl_login where status='Active' and email_id='" + txtemail.Text + "' and password='" + sna + "' and Vender='2'";
                SqlDataReader drva = objcrud.datareader(selectva);
                if (drva.Read())
                {
                    Response.Write("<script>alert('Please Wait for activate Your Vender Account from Admin side.');</script>");
                    drva.Close();
                }
                else
                {
                    string select = "select * from tbl_login where status='Active' and email_id='" + txtemail.Text + "' and password='" + sna + "' and Vender='A1'";
                    SqlDataReader dr = objcrud.datareader(select);
                    //if (dr.HasRows)
                    //{
                    if (dr.Read())
                    {
                        if (txtemail.Text == dr["email_id"].ToString() && sna == dr["password"].ToString())
                        {

                            string sn = Convert.ToBase64String(Encoding.UTF32.GetBytes(txtemail.Text));
                            HttpCookie ckid = new HttpCookie("inf");
                            ckid.Value = sn + "$" + sna;
                            ckid.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(ckid);
                            
                            Response.Redirect("~/Vender/Home.aspx");

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Enter Valid Username and Password.');</script>");
                    }
                }
            }
        }
    }
}