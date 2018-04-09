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
public partial class Vender_Return_Order : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();
    DropDownList ddl1;
    string sel, tab2, str2, str2return, get2, dsgetdata = null;

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCancel();
            BindReturn();
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

    protected void gdretuen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdretuen.PageIndex = e.NewPageIndex;
        BindReturn();
    }
    public void BindCancel()
    {
        string cancelselect = @"select		order_num_det,toi.Product_id,customer_emailid,Status,order_date,Return_date,delivery_after_date,Product_Name,Return_qty,Return_resion
                               from		    tblorderitem as toi
                               inner join	Products as pro
                               on			pro.Product_id=toi.Product_id
                               inner join	tblorderdetails as tod 
                               on		   toi.order_num_det=concAT(tod.prefix,tod.order_number) 
                               where		vender_emailid='" + ssss + "' and Status='Canceled'";
        DataSet dscancel = objcrud.dataset_(cancelselect);
        gdcancel.DataSource = dscancel;
        gdcancel.DataBind();
        pncancel.Visible = true;
        gdcancel.Visible = true;
    }

    public void BindReturn()
    {
        string returnselect = @"select		order_num_det,toi.Product_id,customer_emailid,Status,order_date,Return_date,delivery_after_date,Product_Name,Return_qty,Return_resion
                               from		    tblorderitem as toi
                               inner join	Products as pro
                               on			pro.Product_id=toi.Product_id
                               inner join	tblorderdetails as tod 
                               on		    toi.order_num_det=concAT(tod.prefix,tod.order_number)
                               where		vender_emailid='" + ssss + "' and Status='Return'";
        DataSet dsreturn = objcrud.dataset_(returnselect);
        gdretuen.DataSource = dsreturn;
        gdretuen.DataBind();
        pncancel.Visible = true;
        gdcancel.Visible = true;
    }

    protected void lbb_Click(object sender, EventArgs e)
    {
        Response.Redirect("");
    }

    protected void gdcancel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdcancel.PageIndex = e.NewPageIndex;
        BindCancel();
    }

    protected void lbb_Click1(object sender, EventArgs e)
    {
        string order_num = null;
        con.Open();
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)(((Control)sender).NamingContainer);
        //DropDownList dr = (DropDownList)gvr1.FindControl("ddv");
        order_num = btn.CommandArgument;
        string pid = btn.CommandName;
        if (order_num != "null")
        {
            Server.Transfer("ViewFull_order.aspx?oname=" + order_num + "&pid=" + pid + "");
            //string lst = "http://localhost:49514/Vender/ViewFull_order.aspx?oname=" + name + "&pname=" + vemail + "";
            Response.Write("<script>");
            Response.Write("window.open(_parent')");
            Response.Write("</script>");
        }
    }

    protected void lbbcalcel_Click(object sender, EventArgs e)
    {
        string order_num = null;
        con.Open();
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr1 = (GridViewRow)(((Control)sender).NamingContainer);
        //DropDownList dr = (DropDownList)gvr1.FindControl("ddv");
        order_num = btn.CommandArgument;
        string pid = btn.CommandName;
        if (order_num != "null")
        {
            Server.Transfer("ViewFull_order.aspx?oname=" + order_num + "&pid=" + pid + "");
            //string lst = "http://localhost:49514/Vender/ViewFull_order.aspx?oname=" + name + "&pname=" + vemail + "";
            Response.Write("<script>");
            Response.Write("window.open(_parent')");
            Response.Write("</script>");
        }
    }
}