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

public partial class test_Listing : System.Web.UI.Page
{
    //static DefalutData objDefalutData = new DefalutData();
    static string constr = ConfigurationManager.ConnectionStrings["skp"].ConnectionString;
    SqlConnection con = new SqlConnection(constr);
    SqlDataAdapter da;
    DataTable dt;
    SqlCommand cmd;
    CRUD objmcrud = new CRUD();
    string s = string.Empty;
    string s1 = string.Empty, ssss = null;
    DataSet dta = new DataSet();
    [WebMethod]
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        login();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            string selectlogin = "select * from tbl_login where status='Active' and email_id='" + ssss + "' and Vender='A1'";
            SqlDataReader dr = objmcrud.datareader(selectlogin);
            if (dr.Read())
            {
                if (lstmaingroup.Visible == false)
                {
                    string select = dr["group_name"].ToString();
                    string[] grpname = select.Split(',');
                    for (int j = 0; j < grpname.Length; j++)
                    {
                        s = "select * from Category_Group  where cat_grp_id='" + grpname[j] + "'";
                        s1 += s + " union ";
                        //lstmaingroup.Items.Add(grpname[j]);
                    }
                    string un = " union ";
                    if (s1.EndsWith(un))
                    {
                        s1 = s1.Remove(s1.LastIndexOf("union"));
                    }
                    dta = objmcrud.dataset_(s1);
                    lstmaingroup.Visible = true;
                    lstmaingroup.DataSource = dta;
                    lstmaingroup.DataTextField = "cat_grp_name";
                    lstmaingroup.DataValueField = "cat_grp_id";
                    lstmaingroup.DataBind();
                    lbl_chk.Visible = false;

                }
            }
            else
            {
                Response.Redirect("~/index.aspx");
            }
            con.Close();

        }
    }
    //protected void btnbrand_Click(object sender, EventArgs e)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("select * from tbl_brand where brand_name='" + txtbrand.Text + "'", con);
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.Read())
    //    {
    //        string lst = "add_product.aspx?cg=" + lstmaingroup.SelectedItem + "&ca=" + lstsubgroup.SelectedValue + "&sc=" + lstchildgroup.SelectedValue;
    //        Response.Write("<script>");
    //        Response.Write("window.open('" + lst + "','_parent')");
    //        Response.Write("</script>");


    //        //lblmsg.Visible = true;
    //        //lblmsg.Text = "yes";
    //        //btnck.Visible = false;
    //        //txtbr.Visible = false;
    //        //btnadp.Visible = true;
    //    }
    //    else
    //    {
    //        lblmsg.Text = "Brand Did not Match";
    //        lblmsg.Visible = true;
    //        //btnck.Visible = false;
    //        //txtbr.Visible = false;
    //        //btnap.Visible = true;
    //    }
    //    con.Close();

    //}

    protected void lstmaingroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cmdsk = "select * from Category_Group where cat_grp_name='" + lstmaingroup.SelectedItem + "'";
        DataTable dtsk = objmcrud.datatable_(cmdsk);
        int grpid = Convert.ToInt32(dtsk.Rows[0]["cat_grp_id"].ToString());
        String select = "select * from Category where cat_grp_id='" + grpid + "'";
        DataTable dt = objmcrud.datatable_(select);
        if (dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                lstsubgroup.Visible = true;
                lstsubgroup.ClearSelection();
                ////lbchildcategory.Visible = false;
                //brandandproduct.Visible = false;
                //        //txtcg.Text = lbmaincat.SelectedItem.ToString();
                lstsubgroup.DataSource = dt;
                lstsubgroup.DataTextField = "cat_name";
                lstsubgroup.DataValueField = "cat_id";
                lstsubgroup.DataBind();
                alert.Visible = false;
                chk_brand.Visible = false;
                lstchildgroup.Visible = false;
                dv_msg.Visible = false;
                brand_approval.Visible = false;
                txt_brand.Text = "";
                lbl_chk.Visible = false;
                apply_for_approval.Visible = false;
            }
        }
        else
        {
            alert.Visible = true;
            lstsubgroup.Visible = false;
            lstchildgroup.Visible = false;

            //lstchildsubgroup.Visible = false;
        }
    }

    protected void lstsubgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string select = "select * from Category where parentid='" + lstsubgroup.SelectedValue + "'";

        DataTable dt = objmcrud.datatable_(select);
        if (dt.Rows.Count > 0)
        {

            for (int j = 0; j < dt.Rows.Count; j++)
            {

                lstchildgroup.Visible = true;
                //txtcat.Text = lbcategory.SelectedItem.ToString();
                lstchildgroup.ClearSelection();
                lstchildgroup.DataSource = dt;
                lstchildgroup.DataTextField = "cat_name";
                lstchildgroup.DataValueField = "cat_id";
                lstchildgroup.DataBind();
                alert.Visible = false;
                lblst.Visible = true;
                btn_check.Visible = true;
                lbl_chk.Visible = false;
                //lstchildsubgroup.Visible = false;
                apply_for_approval.Visible = false;

            }
        }
        else
        {
            alert.Visible = true;
            //lstchildsubgroup.Visible = false;
            lstchildgroup.Visible = false;
        }

    }

    protected void lstchildgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        chk_brand.Visible = true;
        apply_for_approval.Visible = false;
    }

    protected void btn_check_Click(object sender, EventArgs e)
    {
        brand_approval.Visible = true;
        txt_brand.Text = "";
        lblst.Visible = false;
        btn_check.Visible = false;

    }
    protected void btn_chkbrand_Click(object sender, EventArgs e)
    {
        try
        {

            int flag = 0;
            string str = "select ven_brand_name,status from vender_brand_detail where ven_brand_name='" + txt_brand.Text + "' and v_email = '" + ssss + "'";

            SqlDataReader dr = objmcrud.datareader(str);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string name = dr["ven_brand_name"].ToString();
                    string brand = dr["status"].ToString();
                    if (brand == "Pending")
                    {
                        flag = 0;
                        dv_msg.Visible = true;
                        lbl_chk.Text = "Brand already Exist...And In Process for Approved";
                        //Approved.Visible = true;
                        lblst.Visible = true;
                        btn_check.Visible = true;
                        lbl_chk.Visible = true;
                        brand_name.InnerText = txt_brand.Text;
                        apply_for_approval.Visible = false;
                        brand_approval.Visible = false;
                        chk_brand.Visible = true;
                    }
                    else if (brand == "Decline")
                    {
                        apply_for_approval.Visible = false;
                        lbl_chk.Text = "You can't Add this Brand Name.<br> try any other Brand name";
                        brand_approval.Visible = true;
                        chk_brand.Visible = true;
                        brand_name.InnerText = name;
                        dv_msg.Visible = true;
                    }

                    else
                    {
                        flag = 1;
                        if (flag == 1)
                        {
                            apply_for_approval.Visible = false;
                            Approved.Visible = true;
                            brand_approval.Visible = false;
                            chk_brand.Visible = false;
                            brand_name.InnerText = name;
                            dv_msg.Visible = false;
                        }
                    }
                }
            }
            else
            {
                apply_for_approval.Visible = false;
                Approved.Visible = false;
                brand_approval.Visible = false;
                chk_brand.Visible = false;
                brand_name.InnerText = "";
                dv_msg.Visible = false;
            }

        }
        catch (Exception ex)
        {

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
    protected void lnk_applyfor_Click(object sender, EventArgs e)
    {
        Response.Redirect("addbrand.aspx?brand=" + txt_brand.Text + "&Cat_id=" + lstchildgroup.SelectedItem);
    }
    protected void btn_new_product_Click(object sender, EventArgs e)
    {
        int cat_group_id = Convert.ToInt32(lstmaingroup.SelectedValue.ToString());
        int cat_id = Convert.ToInt32(lstsubgroup.SelectedValue.ToString());
        int sub_cat_id = Convert.ToInt32(lstchildgroup.SelectedValue.ToString());

        DateTime date = DateTime.Now;
        string dateonly = date.Month.ToString() + date.Year.ToString().Substring(2) + "BOKPRD";
        string strins = "insert into Products(Prefix,Cat_group_id,Cat_id,Sub_cat_id,Product_status,Brand,Vender_id)values('" + dateonly + "','" + cat_group_id + "','" + cat_id + "','" + sub_cat_id + "','Draft','" + txt_brand.Text + "','" + ssss + "') ";
        objmcrud.crud(strins);
        string id = objmcrud.GetOrdId();
        string sid = dateonly + id;
        Response.Redirect("Add_Product.aspx?sid=" + sid + "&cat=" + cat_id + "&cica=" + sub_cat_id + "");
    }
}