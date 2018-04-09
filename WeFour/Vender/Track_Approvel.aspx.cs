using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Net.Sockets;
using System.Web.UI.HtmlControls;
using System.Text;
public partial class Vender_Track_Approvel : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    CRUD objcrud = new CRUD();
    int flag, flagnull;
    string dsget, dsfinal, get, str, newdata, new1, tbl1, dsgetsrch;
    string ssss = null;
    DataSet dsnew;
    protected void Page_Load(object sender, EventArgs e)
    {
        Login();
        if (!Page.IsPostBack)
        {
            Bind();
        }

    }
    public void Login()
    {

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
    }

    public void Bind()
    {
        string selectgroupname = @"select		Product_id,Prefix,Product_Name,Your_selling_Price,GST,Stocks,Product_status,Vender_id,Cat_group_id 
                                   from         Products as Pro
                                   where        Vender_id = '" + ssss + "' and Stocks>= '1' and Listing_status = 'Active' and Product_status In('Decline','Pending','Approve with Brand','Approve without Brand')";
        DataSet dsgrpname = objcrud.dataset_(selectgroupname);
        apd.DataSource = dsgrpname;
        apd.DataBind();
    }

    //string str = "a,b,c";
    //foreach (string s in str.Split(','))
    //{
    //    s
    //}



    protected void ddfliter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddfliter.SelectedIndex == 0)
        {
            Bind();

        }
        else
        {
            string selectgroupname = @"select		Product_id,Prefix,Product_Name,Your_selling_Price,GST,Stocks,Product_status,Vender_id,Cat_group_id 
                                   from         Products as Pro
                                   where        Vender_id = '" + ssss + "' and Stocks>= '1' and Listing_status = 'Active' and Product_status='" + ddfliter.SelectedValue + "'";
            DataSet dsgrpname = objcrud.dataset_(selectgroupname);
            apd.DataSource = dsgrpname;
            apd.DataBind();
            ddfliter.SelectedValue = "0";
        }
    }

    protected void btnserch_ServerClick(object sender, EventArgs e)
    {
        string get = srchorder.Text + "%";
        string selectgroupname = @"select		Product_id,Prefix,Product_Name,Your_selling_Price,GST,Stocks,Product_status,Vender_id,Cat_group_id 
                                   from         Products as Pro
                                   where        Vender_id = '" + ssss + "'  and  Stocks>= '1' and Listing_status = 'Active' and Product_status In('Decline','Pending','Approve with Brand','Approve without Brand') and Product_Name Like '" + get + "'";
        DataSet dsgrpname = objcrud.dataset_(selectgroupname);
        apd.DataSource = dsgrpname;
        apd.DataBind();
        srchorder.Text = "";
    }
    protected void lbtnviewproduct_Click(object sender, EventArgs e)
    {
        
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)(((Control)sender).NamingContainer);
        //DropDownList dr = (DropDownList)gvr1.FindControl("apd");
      string  pname = btn.CommandArgument;
        //string proid = btn.CommandName;
        if (pname != "null")
        {
            Server.Transfer("viewfull_product.aspx?pid=" + pname + "");
            //string lst = "http://localhost:49514/Vender/ViewFull_order.aspx?oname=" + name + "&pname=" + vemail + "";
            Response.Write("<script>");
            Response.Write("window.open(_parent')");
            Response.Write("</script>");
        }
    }
}




