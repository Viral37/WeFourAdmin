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

public partial class Vender_View_Product : System.Web.UI.Page
{

    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    CRUD objcrud = new CRUD();
    int flag, flagnull;

    string dsgetnonlive, dsget, dsfinal, get, str, newdata, new1, tbl1, dsget1, dsfinal1, get1, str1, tbl11, tblnonlive;

    string ssss = null;
    protected void Page_Load(object sender, EventArgs e)
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

        if (!IsPostBack)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "get();", true);

            BindData_Live();
            BindData_Nonlive();

        }

    }

    public void BindData_Live()
    {
        //ll.Attributes.Add("class", "active");
        con.Open();
        DataSet dsnew = new DataSet();
        string skl = "select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks != 0 and (Product_status='Approve without Brand' or Product_status='Approve with Brand') order by Product_id desc";
        SqlCommand cmd = new SqlCommand(skl, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew);
        apd.DataSource = dsnew;
        apd.DataBind();
        con.Close();
    }
    public void BindData_Nonlive()
    {
        con.Open();
        DataSet dsnew1 = new DataSet();
        SqlCommand cmd = new SqlCommand("select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks != '0' and Product_status='Pending' order by Product_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew1);
        nonlive.DataSource = dsnew1;
        nonlive.DataBind();
        con.Close();
    }

    protected void mylist_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vender/Edit_Product.aspx");

    }

    protected void apd_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Response.Redirect("~/Vender/Listing.aspx");
    }

    protected void apd_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/Vender/Listing.aspx");
    }

    protected void ab_ServerClick(object sender, EventArgs e)
    {
        con.Open();

        DataSet dsnew1 = new DataSet();
        SqlCommand cmd = new SqlCommand("select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks!='0' and Product_status='Approve with Brand' order by Product_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew1);
        apd.DataSource = null;
        apd.DataSource = dsnew1;
        apd.DataBind();
        apd.Visible = true;
        con.Close();
    }

    protected void sall_ServerClick(object sender, EventArgs e)
    {
        BindData_Live();
        BindData_Nonlive();
    }

    protected void awb_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        DataSet dsnew1 = new DataSet();
        SqlCommand cmd = new SqlCommand("select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks!='0' and Product_status='Approve without Brand' order by Product_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew1);
        apd.DataSource = null;
        apd.DataSource = dsnew1;
        apd.DataBind();
        apd.Visible = true;
        con.Close();

    }

    protected void sl5_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        DataSet dsnew1 = new DataSet();
        string skl = "select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks<='10' and (Product_status='Approve without Brand' or Product_status='Approve with Brand') order by Product_id desc";
        SqlCommand cmd = new SqlCommand(skl, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew1);
        //apd.DataSource = null;
        apd.DataSource = dsnew1;
        apd.DataBind();
        apd.Visible = true;
        con.Close();
    }

    protected void sm5_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        DataSet dsnew1 = new DataSet();
        string skl = "select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks>='10' and (Product_status='Approve without Brand' or Product_status='Approve with Brand') order by Product_id desc";
        SqlCommand cmd = new SqlCommand(skl, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnew1);
        apd.DataSource = null;
        apd.DataSource = dsnew1;
        apd.DataBind();
        apd.Visible = true;
        con.Close();
    }

    protected void outst_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        string tblout;
        DataSet dsoutstock = new DataSet();
        SqlCommand cmd = new SqlCommand("select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks<='0' and (Product_status='Approve without Brand' or Product_status='Approve with Brand') order by Product_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsoutstock);
        apd.DataSource = null;
        apd.DataSource = dsoutstock;
        apd.DataBind();
        apd.Visible = true;
        con.Close();
    }

    protected void btnRun_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        DataSet dsnew1 = new DataSet();
        SqlCommand cmd = new SqlCommand("select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,Vender_id from Products where Vender_id='" + ssss + "' and Stocks<='0' and (Product_status='Approve without Brand' or Product_status='Approve with Brand') order by Product_id desc", con);
        SqlDataAdapter dr = new SqlDataAdapter(cmd);
        dr.Fill(dsnew1);
        apd.DataSource = dsnew1;
        apd.DataBind();
        apd.Visible = true;
        con.Close();
    }
    protected void apd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        apd.PageIndex = e.NewPageIndex;
        BindData_Live();
    }
    protected void nonlive_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        nonlive.PageIndex = e.NewPageIndex;
        BindData_Nonlive();
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCity(string prefixText)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["skp"].ToString();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select Product_Name from Products where Product_Name like @Product_Name+'%'", con);
        cmd.Parameters.AddWithValue("@Product_Name", prefixText);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        List<string> CityNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CityNames.Add(dt.Rows[i][1].ToString());
        }
        return CityNames;
    }

    protected void lbtnviewproduct_Click(object sender, EventArgs e)
    {
        string pname = null;
        con.Open();
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)(((Control)sender).NamingContainer);
        //DropDownList dr = (DropDownList)gvr1.FindControl("apd");
        pname = btn.CommandArgument;
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

    protected void srchnonlive_ServerClick(object sender, EventArgs e)
    {
        con.Open();
        string schfildnonlive = nonlivesrch.Text.ToString();
        DataSet dsnewnonlive = new DataSet();
        SqlCommand cmd = new SqlCommand(@"select Product_id,Prefix,Product_Name,Product_status,MRP,Your_selling_price,Stocks,GST,
                            Vender_id from Products where Vender_id='" + ssss
  + "'and Product_Name='" + schfildnonlive + "' and Product_status='Pending' order by Product_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dsnewnonlive);
        nonlive.DataSource = dsnewnonlive;
        nonlive.DataBind();
        nonlive.Visible = true;
        //nl.Attributes.Add("class", "active");
        //ll.Attributes.Remove("class");
        //popular10.Attributes.Remove("class");
        //recent10.Attributes.Add("class", "tab-pane active");
    }
}
