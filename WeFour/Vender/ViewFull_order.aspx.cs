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
public partial class Vender_ViewFull_order : System.Web.UI.Page
{
    static string conString = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    string ssss = null;
    CRUD objcrud = new CRUD();
    string str2, sel;

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string getorder = @"select          distinct order_num_det,order_date,Status,Product_Name,order_username,customer_emailid,order_caddress,order_carea,order_cvillageorcity,order_cpincode,order_baseunit,toi.mrp,sell_price,order_quantity,GST,order_deliverytype,order_promocode,Return_qty,Return_resion
                            from            tblorderitem  as toi
                            inner join		tblorderdetails as tod 
                            on              toi.order_num_det=concAT(tod.prefix,tod.order_number) 
                            inner join		Products as pro
                            on				pro.Product_id=toi.product_id
                            where			vender_emailid='" + ssss + "' and order_num_det='" + Request.QueryString["oname"] + "' and toi.Product_id='" + Request.QueryString["pid"] + "'";
            DataSet dss = objcrud.dataset_(getorder);
            if (dss.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                {
                    string order_num = Request.QueryString["oname"];
                    string pid = Request.QueryString["pid"];
                    lblname.Text = dss.Tables[0].Rows[0]["order_num_det"].ToString();
                    lbldate.Text = dss.Tables[0].Rows[0]["order_date"].ToString();
                    //lblstatus.Text = dss.Tables[0].Rows[0]["Status"].ToString();
                    lbls.SelectedValue = dss.Tables[0].Rows[0]["Status"].ToString();

                    lblpname.Text = dss.Tables[0].Rows[0]["Product_Name"].ToString();
                    //lbldes.Text = dss.Tables[0].Rows[0]["Description"].ToString();
                    lblcname.Text = dss.Tables[0].Rows[0]["order_username"].ToString();
                    lblcid.Text = dss.Tables[0].Rows[0]["customer_emailid"].ToString();
                    lblcaddress.Text = dss.Tables[0].Rows[0]["order_caddress"].ToString();
                    lblcarea.Text = dss.Tables[0].Rows[0]["order_carea"].ToString();
                    lblcvilage.Text = dss.Tables[0].Rows[0]["order_cvillageorcity"].ToString();
                    lblpincode.Text = dss.Tables[0].Rows[0]["order_cpincode"].ToString();
                    lblbaseunit.Text = dss.Tables[0].Rows[0]["order_baseunit"].ToString();
                    lblmrp.Text = dss.Tables[0].Rows[0]["mrp"].ToString();
                    lblsellpr.Text = dss.Tables[0].Rows[0]["sell_price"].ToString();
                    lblquaty.Text = dss.Tables[0].Rows[0]["order_quantity"].ToString();
                    lbltax.Text = dss.Tables[0].Rows[0]["GST"].ToString() + '%';
                    lbldtype.Text = dss.Tables[0].Rows[0]["order_deliverytype"].ToString();
                    lblpromocode.Text = dss.Tables[0].Rows[0]["order_promocode"].ToString();
                    lblrqty.Text = dss.Tables[0].Rows[0]["Return_qty"].ToString();
                    lblreason.Text = dss.Tables[0].Rows[0]["Return_resion"].ToString();
                }
            }
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
        if (lbls.SelectedValue == "Return")
        {
            Response.Redirect("~/Vender/Order_Manage.aspx");
        }
        if (lbls.SelectedValue == "Canceled")
        {
            Response.Redirect("~/Vender/Cancel_Order.aspx");
        }
        else
        {
            Response.Redirect("~/Vender/Order_Manage.aspx");
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        con.Open();
        string strchnagestatus = "update  tblorderitem set Status = '" + lbls.SelectedValue.ToString()+ "' where vender_emailid='" + ssss + "' and order_num_det='" + Request.QueryString["oname"] + "' and Product_id='" + Request.QueryString["pid"] + "'";
        SqlCommand cmdststus = new SqlCommand(strchnagestatus,con);
        int row = cmdststus.ExecuteNonQuery();
        Response.Redirect("~/Vender/Order_Manage.aspx");

        con.Close();

    }

    protected void lbls_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}