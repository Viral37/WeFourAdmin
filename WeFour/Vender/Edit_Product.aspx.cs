using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
public partial class Vender_demo : System.Web.UI.Page
{
    static string constr = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(constr);
    CRUD objmcrud = new CRUD();
    string ssss = string.Empty, str = string.Empty;
    DataSet dsa = new DataSet();
    Image imsrc;
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
               DateTime date = DateTime.Now;
            string dateonly = date.Month.ToString() + date.Year.ToString().Substring(2);
            getdata();
            
        }
    }
    public void getdata()
    {
        str += @"select * from Products where Product_status='Draft' and Vender_id = '" + ssss + "' ";
        dsa = objmcrud.dataset_(str);
        datalistbox.DataSource = dsa;
        datalistbox.DataBind();

        
        
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



    protected void create_newlisting_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Vender/Listing.aspx");
    }

    protected void datalistbox_EditCommand(object source, DataListCommandEventArgs e)
    {
        datalistbox.EditItemIndex = e.Item.ItemIndex;
        getdata();
    }
   
    protected void lbtnedit_Click(object sender, EventArgs e)
    {
       
        LinkButton lbtn = (LinkButton)sender;
        string Proid = lbtn.CommandArgument;
        string prf = lbtn.CommandName;
        DataSet dsaa = new DataSet();
        string cat_grp_id = string.Empty, cat_id = string.Empty, sub_cat_id = string.Empty, brand = string.Empty;
        int a = 0;
        if (Proid != null)
        {
            string s = "select * from Products where Product_id='" + Proid + "'";
            dsaa = objmcrud.dataset_(s);
            if (dsaa.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsaa.Tables[0].Rows.Count; i++)
                {
                    cat_grp_id = dsaa.Tables[0].Rows[i]["Cat_group_id"].ToString();
                    cat_id = dsaa.Tables[0].Rows[i]["Cat_id"].ToString();
                    sub_cat_id = dsaa.Tables[0].Rows[i]["sub_cat_id"].ToString();
                    brand = dsaa.Tables[0].Rows[i]["Brand"].ToString();
                    
                }
            }
            //Server.Transfer("Mproduct.aspx?proname=" + Proid + "&status="+sts+"");
            //Response.Redirect("Mproduct.aspx?proname=" + Proid + "&cgroup=" + cat_grp_id + "&catid="+cat_id+" &subid="+sub_cat_id+" &brand=");
            Response.Redirect("Add_Product.aspx?sid=" + prf + Proid + "&cat=" + cat_id + "&cica=" + sub_cat_id + "");

            //string lst = "http://localhost:49514/Vender/ViewFull_order.aspx?oname=" + name + "&pname=" + vemail + "";
            Response.Write("<script>");
            Response.Write("window.open(_parent')");
            Response.Write("</script>");
        }
    }

    protected void lbtnremove_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string Proid = lbtn.CommandArgument;
        string prf = lbtn.CommandName;
        DataSet dsaa = new DataSet();
        if (Proid != null)
        {
            string s = "delete from Products where Product_id='" + Proid + "'";
            objmcrud.crud(s);
            
                ClientScript.RegisterStartupScript(typeof(Page), "alertMessage",
           "<script type='text/javascript'>alert('Product Delete Successfulyy From System.');window.location.replace('Edit_Product.aspx');</script>");
            

        }
        }

}