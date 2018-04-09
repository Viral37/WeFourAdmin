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
public partial class Vender_Active_Order : System.Web.UI.Page
{
    string ssss = null;
    CRUD objcrud = new CRUD();
    string sel, tab2, str2, get2;
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }
    
    public void login()
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
        string today = DateTime.Now.ToString("d/M/yyyy");
        string dsgetdata = @"select		 order_num_det,toi.Product_id,customer_emailid,Status,order_date,Return_date,delivery_after_date,Product_Name,GST,order_quantity,sell_price
                             from        tblorderitem as toi
                             inner join  Products as pro
                             on          pro.Product_id = toi.Product_id
                             inner join  tblorderdetails as tod
                             on          toi.order_num_det=concAT(tod.prefix,tod.order_number)
                             where      vender_emailid = '" + ssss + "' and Status IN('Pending') and order_date!='" + today + "' order by	Convert(datetime,order_date,103)  DESC";
        DataSet dss = objcrud.dataset_(dsgetdata);
        gdorder.DataSource = dss;
        gdorder.DataBind();

    }
    protected void btnserch_ServerClick(object sender, EventArgs e)
    {
        string get = srchorder.Text + "%";
        string dsgetdata = @"select		 order_num_det,toi.Product_id,customer_emailid,Status,order_date,Return_date,delivery_after_date,Product_Name,GST,order_quantity,sell_price
                             from        tblorderitem as toi
                             inner join  Products as pro
                             on          pro.Product_id = toi.Product_id
                             inner join  tblorderdetails as tod
                             on          toi.order_num_det=concAT(tod.prefix,tod.order_number)
                             where      vender_emailid = '" + ssss + "' and order_num_det Like '" + get + "'order by	Convert(datetime,order_date,103)  DESC";
        DataSet dssnew = objcrud.dataset_(dsgetdata);
        gdorder.DataSource = dssnew;
        gdorder.DataBind();

    }
    protected void btn_find_Click(object sender, EventArgs e)
    {
        string getd = hd.Value;
        string start = getd.Substring(0, getd.IndexOf("-"));
        string end = getd.Substring(getd.IndexOf("-") + 1);
        string dsgetdata = @"select		 order_num_det,toi.Product_id,customer_emailid,Status,order_date,Return_date,delivery_after_date,Product_Name,GST,order_quantity,sell_price
                             from        tblorderitem as toi
                             inner join  Products as pro
                             on          pro.Product_id = toi.Product_id
                             inner join  tblorderdetails as tod
                             on          toi.order_num_det=concAT(tod.prefix,tod.order_number)
                             where		Convert(datetime,tod.order_date,103) BETWEEN Convert(datetime,'" + start + "',103) AND Convert(datetime,'" + end + "',103) and toi.vender_emailid = '" + ssss + "'  and toi.Status = '" + ddl_status.SelectedValue + "'";
        DataSet dss = objcrud.dataset_(dsgetdata);
        gdorder.DataSource = dss;
        gdorder.DataBind();

    }
    protected void lbb_Click(object sender, EventArgs e)
    {
        string name = null;

        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)(((Control)sender).NamingContainer);
        DropDownList dr = (DropDownList)gvr1.FindControl("ddv");
        name = btn.CommandArgument;
        string pid = btn.CommandName;
        if (name != "null")
        {
            Server.Transfer("ViewFull_order.aspx?oname=" + name + "&pid=" + pid + "");
            //string lst = "http://localhost:49514/Vender/ViewFull_order.aspx?oname=" + name + "&pname=" + vemail + "";
            Response.Write("<script>");
            Response.Write("window.open(_parent)");
            Response.Write("</script>");
        }
    }
     
    protected void gdorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdorder.PageIndex = e.NewPageIndex;
        Bind();
    }

    public class MYCRUD
    {
    }
}